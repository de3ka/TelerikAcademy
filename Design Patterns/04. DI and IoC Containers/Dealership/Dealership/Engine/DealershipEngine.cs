using Dealership.CommandHandlers;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Common.IOProvider;
using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        // Commands constants
        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string CommentDoesNotExist = "The comment does not exist!";

        private readonly IDealershipFactory factory;
        private readonly IIOProvider ioProvider;
        private readonly ICommandHandler commandHandler;

        private ICollection<IUser> users;
        private IUser loggedUser;

        public DealershipEngine(IDealershipFactory factory, IIOProvider ioProvider, ICommandHandler commandHandler)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (ioProvider == null)
            {
                throw new ArgumentNullException(nameof(ioProvider));
            }

            if (commandHandler == null)
            {
                throw new ArgumentNullException(nameof(commandHandler));
            }

            this.factory = factory;
            this.ioProvider = ioProvider;
            this.commandHandler = commandHandler;

            this.users = new HashSet<IUser>();
            this.loggedUser = null;
        }

        public IUser LoggedUser { get { return this.loggedUser; } }

        public ICollection<IUser> Users { get { return this.users; } }

        public void SetLoggedUser(IUser user)
        {
            this.loggedUser = user;
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.loggedUser = null;
            this.users = new HashSet<IUser>();
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }


        private IEnumerable<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.ioProvider.Readline();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.factory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.ioProvider.Readline();
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.ioProvider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return UserNotLogged;
                }
            }

            return this.commandHandler.HandleCommand(command, this);

        }
    }
}

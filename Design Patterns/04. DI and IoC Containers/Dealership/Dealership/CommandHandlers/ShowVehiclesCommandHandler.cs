﻿using System.Linq;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class ShowVehiclesCommandHandler : BaseCommandHandler
    {
        private const string ShowVehiclesCommandName = "ShowVehicles";
        private const string NoSuchUser = "There is no user with username {0}!";


        protected override bool CanHandleCommand(ICommand command)
        {
            return command.Name == ShowVehiclesCommandHandler.ShowVehiclesCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];

            var user = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}

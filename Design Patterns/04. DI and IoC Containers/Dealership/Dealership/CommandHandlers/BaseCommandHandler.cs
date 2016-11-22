using System;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private ICommandHandler successor;

        public void SetSuccessor(ICommandHandler successor)
        {
            this.successor = successor;
        }
        
        public string HandleCommand(ICommand command, IEngine engine)
        { 
            if (this.CanHandleCommand(command))
            {
                return this.Handle(command, engine);
            }

            else if (this.successor != null)
            {
                return this.successor.HandleCommand(command, engine);
            }
            else
            {
                return string.Format(InvalidCommand, command.Name);
            }
        }

        public void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }

        protected abstract bool CanHandleCommand(ICommand command);
        protected abstract string Handle(ICommand command, IEngine engine);
    }
}

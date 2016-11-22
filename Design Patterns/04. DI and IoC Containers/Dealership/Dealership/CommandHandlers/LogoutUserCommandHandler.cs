using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LogoutUserCommandHandler : BaseCommandHandler
    {
        private const string LogoutUserCommandName = "LogoutUser";
        private const string UserLoggedOut = "You logged out!";

        protected override bool CanHandleCommand(ICommand command)
        {
            return command.Name == LogoutUserCommandHandler.LogoutUserCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            engine.SetLoggedUser(null);
            return UserLoggedOut;
        }
    }
}

using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public interface ICommandHandler
    {
        void SetSuccessor(ICommandHandler successor);

        string HandleCommand(ICommand command, IEngine engine);
    }
}

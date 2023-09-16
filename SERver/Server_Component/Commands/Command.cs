using Presenters;

namespace CommandLineUI.Commands
{
    interface Command
    {
        Task<CommandLineViewData> Execute();
    }
}

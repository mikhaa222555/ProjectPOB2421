using System.Windows.Input;

namespace ProjectPOB2421
{
    internal class RelayCommand : ICommand
    {
        private Action<object> loadTasks;
        private Func<object, bool> canLoadTasks;

        public RelayCommand(Action<object> loadTasks, Func<object, bool> canLoadTasks)
        {
            this.loadTasks = loadTasks;
            this.canLoadTasks = canLoadTasks;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUSBBackup
{ 
    class TaskPool
    {
        private Dictionary<String, Task> tasks = new Dictionary<String, Task>();

        public void AddTask(String key, Action action)
        {
            Task t = new Task(action);
            tasks.Add(key, t);
        }

        public void RunTask(String key)
        {
            if (tasks[key].Status.Equals(TaskStatus.Running) == false)
#if DEBUG
                Console.WriteLine("Task({0}) is started.", key);
#endif
                tasks[key].Start();
        }

        public void StopTask(String key)
        {
            if (tasks[key].Status.Equals(TaskStatus.Running) == true)
                tasks[key].Dispose();
#if DEBUG
            Console.WriteLine("Task({0}) is stopped.", key);
#endif
        }

        public void ClearTasks()
        {
        }
    }
}

using System;
using Utils.TaskSchedulerLib;

namespace Utils.TaskScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskSchedulerManager taskSchedulerManager = new TaskSchedulerManager();
            while (true)
            {
                Console.WriteLine("Press:");
                Console.WriteLine("1) to CREATE sample task");
                Console.WriteLine("2) to DELETE sample task");
                Console.WriteLine("3) to exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        // Change if you want
                        taskSchedulerManager.TaskName = "Scheduled task name";
                        taskSchedulerManager.SetExecAction("notepad.exe", "c:\\test.log", null);

                        taskSchedulerManager.CreateSampleTask();

                        Console.WriteLine("Task with name: {0} created.", taskSchedulerManager.TaskName);
                        break;

                    case "2":
                        taskSchedulerManager.DeleteSampleTask();

                        Console.WriteLine("Task with name: {0} deleted.", taskSchedulerManager.TaskName);
                        break;

                    case "3":
                        return;
                }
                Console.WriteLine();
            }
        }
    }
}

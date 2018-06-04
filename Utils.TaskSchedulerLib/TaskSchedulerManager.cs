using System;
using Microsoft.Win32.TaskScheduler;

namespace Utils.TaskSchedulerLib
{
    public class TaskSchedulerManager
    {

        /// <summary>
        /// Action executed by scheduled task
        /// </summary>
        private ExecAction ExecAction = new ExecAction("notepad.exe", "c:\\test.log", null);
        
        public string TaskName { get; set; } = "Test";

        /// <summary>
        /// Creates sample scheduled task, which will execute 1 minute after creation
        /// </summary>
        public void CreateSampleTask()
        {
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Does something";
                td.Principal.LogonType = TaskLogonType.InteractiveToken;

                // Create a trigger that fires 1 minute from now and then every 15 minutes for the
                // next 7 days.
                TimeTrigger tTrigger = (TimeTrigger)td.Triggers.Add(new TimeTrigger());
                tTrigger.StartBoundary = DateTime.Now + TimeSpan.FromMinutes(1);
                tTrigger.EndBoundary = DateTime.Today + TimeSpan.FromDays(7);
                tTrigger.ExecutionTimeLimit = TimeSpan.FromSeconds(15);
                tTrigger.Id = "Time test";
                tTrigger.Repetition.Duration = TimeSpan.FromMinutes(10);
                tTrigger.Repetition.Interval = TimeSpan.FromMinutes(2);
                tTrigger.Repetition.StopAtDurationEnd = true;

                // Add an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(ExecAction);
            
                // Register the task in the root folder

                ts.RootFolder.RegisterTaskDefinition(TaskName, td);
            }
        }

        /// <summary>
        /// Delete created Scheduled Task
        /// </summary>
        public void DeleteSampleTask()
        {
            using (TaskService ts = new TaskService())
            {
                Task t = ts.GetTask(TaskName);
                if (t == null) return;

                // In some cases you need Administrator permission

                /*
                // Check to make sure account privileges allow task deletion
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                
                    if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    throw new Exception($"Cannot delete task with your current identity '{identity.Name}' permissions level." +
                    "You likely need to run this application 'as administrator' even if you are using an administrator account.");
                */

                // Remove the task we just created
                ts.RootFolder.DeleteTask(TaskName);
            }
        }

        /// <summary>
        /// Sets new ExecAction object
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arguments"></param>
        /// <param name="workingDirectory"></param>
        public void SetExecAction(string path, string arguments, string workingDirectory)
        {
           ExecAction = new ExecAction(path, arguments, workingDirectory);
        }
    }
}

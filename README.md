# TaskScheduler
Konzolová aplikace, která vytváří plánované úlohy. Pracuje s Plánovačem úloh OS Windows.

Plánovač úloh je C# možné používat díky nuget balíčku **[TaskScheduler](https://www.nuget.org/packages/TaskScheduler/)**.
```csharp
using Microsoft.Win32.TaskScheduler;
```
```csharp
using (TaskService ts = new TaskService())
{ 
    // Settings
    TaskDefinition td = ts.NewTask();
    // Create
    ts.RootFolder.RegisterTaskDefinition(TaskName, td);
    // Or delete
    //ts.RootFolder.DeleteTask(TaskName);
}
```
---
Aplikace vytvářející úlohy se skládá z částí:
* TaskSchedulerClient -> .Net Core konzolová aplikace
* TaskSchedulerLib -> .Net Standard knihovna ovládající Win32 TaskScheduler

![Task Scheduler](Resources/TaskScheduler.gif)

## Použití
**Klientská čásť**:
1) Přidat referenci na knihovnu TaskSchedulerLib do projektu
```csharp
using Utils.TaskSchedulerLib;
```
2) Vytvořit instanci TaskManager -> třídy knihovny, která obsluhuje úlohu
```csharp
TaskSchedulerManager taskSchedulerManager = new TaskSchedulerManager();
```
3) Vytváření plánovaných úloh 
```csharp
// Scheduled task name
taskSchedulerManager.TaskName = "Scheduled task name";
// Action
taskSchedulerManager.SetExecAction("notepad.exe", "c:\\test.log", null);

taskSchedulerManager.CreateSampleTask();
```
4) Mazání vytvořené úlohy
```csharp
taskSchedulerManager.DeleteSampleTask();
```
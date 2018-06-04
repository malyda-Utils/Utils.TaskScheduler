# TaskScheduler
Konzolov� aplikace, kter� vytv��� pl�novan� �lohy. Pracuje s Pl�nova�em �loh OS Windows.

Pl�nova� �loh je C# mo�n� pou��vat d�ky nuget bal��ku **[TaskScheduler](https://www.nuget.org/packages/TaskScheduler/)**.
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
Aplikace vytv��ej�c� �lohy se skl�d� z ��st�:
* TaskSchedulerClient -> .Net Core konzolov� aplikace
* TaskSchedulerLib -> .Net Standard knihovna ovl�daj�c� Win32 TaskScheduler

![Task Scheduler](Resources/TaskScheduler.gif)

## Pou�it�
**Klientsk� ��s�**:
1) P�idat referenci na knihovnu TaskSchedulerLib do projektu
```csharp
using Utils.TaskSchedulerLib;
```
2) Vytvo�it instanci TaskManager -> t��dy knihovny, kter� obsluhuje �lohu
```csharp
TaskSchedulerManager taskSchedulerManager = new TaskSchedulerManager();
```
3) Vytv��en� pl�novan�ch �loh 
```csharp
// Scheduled task name
taskSchedulerManager.TaskName = "Scheduled task name";
// Action
taskSchedulerManager.SetExecAction("notepad.exe", "c:\\test.log", null);

taskSchedulerManager.CreateSampleTask();
```
4) Maz�n� vytvo�en� �lohy
```csharp
taskSchedulerManager.DeleteSampleTask();
```
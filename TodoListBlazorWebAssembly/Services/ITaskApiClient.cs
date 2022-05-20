using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoListBlazorWebAssembly
{
    public interface ITaskApiClient
    {
        Task<List<TasksModel>> GetTaskList();

        Task<TasksModel> GetTaskDetail(string id);
        Task<int> UpdateTask(TasksModel _task);

        Task<List<TasksModel>> GetTaskSearch(TaskListSearch taskListSearch);

        Task<int> CreateNewTask(TasksModel tasksModel);
    }
}

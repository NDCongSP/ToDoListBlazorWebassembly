using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoListBlazorWebAssembly
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient httpClient;
        public TaskApiClient(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public Task<int> CreateNewTask(TasksModel tasksModel)
        {
            throw new NotImplementedException();
        }

        public async Task<TasksModel> GetTaskDetail(string id)
        {
            var _result = await httpClient.GetFromJsonAsync<TasksModel>($"/api/tasks/{id}");
            return _result;
        }

        public async Task<List<TasksModel>> GetTaskList()
        {
            var result = await httpClient.GetFromJsonAsync<List<TasksModel>>("/api/tasks");
            return result;
        }

        public async Task<List<TasksModel>> GetTaskSearch(TaskListSearch taskListSearch)
        {
            var _result = await httpClient.GetFromJsonAsync<List<TasksModel>>($"/api/tasks/getsearch?name={taskListSearch.Name}&priority={taskListSearch.Priority}&status={taskListSearch.Status}");
            return _result;
        }

        public Task<int> UpdateTask(TasksModel _task)
        {
            throw new NotImplementedException();
        }
    }
}

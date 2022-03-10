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
        public HttpClient _httpClient;
        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TasksModel> GetTaskDetail(string id)
        {
            var _result = await _httpClient.GetFromJsonAsync<TasksModel>($"/api/tasks/{id}");
            return _result;
        }

        public async Task<List<TasksModel>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TasksModel>>("/api/tasks");
            return result;
        }
    }
}

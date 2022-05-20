using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoListBlazorWebAssembly.Pages
{
    public partial class TasksList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }

        private List<TasksModel> Tasks = new List<TasksModel>();

        private TaskListSearch _taskListSearch = new TaskListSearch();

        protected async override Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList();
            await base.OnInitializedAsync();
        }

        private async Task SearchForm(EditContext contex)
        {
            Tasks = await TaskApiClient.GetTaskSearch(_taskListSearch);
            StateHasChanged();
        }
    }
}

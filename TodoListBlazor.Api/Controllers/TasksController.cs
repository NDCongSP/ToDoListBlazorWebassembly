using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoListBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var _res = GlobalVariable.ConnectionDb.Query<TasksModel>("spTaskGetAll").ToList();
            return Ok(_res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var _res = GlobalVariable.ConnectionDb.Query<TasksModel>($"select * from task where Id = {id}").First();
            if (_res != null)
            {
                return Ok(_res);
            }
            else
            {
                return BadRequest("Null or error.");
            }
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> CreateData([FromBody] TasksModel request)
        {
            var _res = GlobalVariable.ConnectionDb.Execute(@"insert task(Name,Priority,Status) values (@Name,@Priority,@Status)", request);
            if (_res > 0)
            {
                return Ok(_res);
            }
            else
            {
                return BadRequest("Empty or error!");
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateData(int id, [FromBody] TasksModel _tasks)
        {
            var p = new DynamicParameters();
            p.Add("@id", id);
            p.Add("@name", _tasks.Name);
            p.Add("@priority", _tasks.Priority);
            p.Add("@status", _tasks.Status);
            var _res = GlobalVariable.ConnectionDb.Execute("spTaskUpdate", p, commandType: CommandType.StoredProcedure);

            if (_res > 0)
            {
                return Ok(_res);
            }
            else
            {
                return BadRequest("Empty or error!");
            }
        }
    }
}

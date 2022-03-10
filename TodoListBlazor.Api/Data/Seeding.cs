using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoListBlazor.Api
{
    public class Seeding
    {
        //List<User> userSeeding = new List<User>();

        List<TasksModel> tasks = new List<TasksModel>();

        public void SeedAsync()
        {
            string[] _name = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z" };
            foreach (var item in _name)
            {
                tasks.Add(new TasksModel()
                {
                    Name = item,
                    Priority=Priority.High,
                    Status=Status.Open
                });
            }

            var result = GlobalVariable.ConnectionDb.Execute(@"insert task(Name,Priority,Status) values (@Name, @Priority, @Status)",tasks);

            //var p = new DynamicParameters();
            //p.Add("@Firstname", "Mr");
            //p.Add("@LastName", "A");
            //p.Add("@Email", "admin1@gmail.com");
            //p.Add("@PhoneNumber", "0909123456");
            //p.Add("@UserName", "admin");
            //p.Add("@Password", "admin@123#");

            //var result = GlobalVariable.ConnectionDb.Execute("spUserInsert", p, commandType: CommandType.StoredProcedure);

            Console.WriteLine(result);
        }
    }
}

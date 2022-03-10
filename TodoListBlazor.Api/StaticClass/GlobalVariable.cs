using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListBlazor.Api
{
    public static class GlobalVariable
    {
        //public static IDbConnection ConnectionDb { get; set; } = new SqlConnection("Data Source=localhost;Database=todolist;UID=root;Password=100100; Min Pool Size=0;Max Pool Size=1000;Pooling=true; Connect Timeout=65535;");
        public static IDbConnection ConnectionDb { get; set; } = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=todolist;Integrated Security=True");

        public static Seeding SeedingHelper { get; set; } = new Seeding();
    }
}

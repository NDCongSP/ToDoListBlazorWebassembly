using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TaskListSearch
    {
        public string Name { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}

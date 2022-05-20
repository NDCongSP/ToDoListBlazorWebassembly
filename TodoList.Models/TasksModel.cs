using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TasksModel
    {
        public int Id { get; set; }
        [MaxLength(20,ErrorMessage ="You can not fill task name over than 20 characters")]
        [Required(ErrorMessage ="Please enter task name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Plese chose a priority")]
        public Priority? Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

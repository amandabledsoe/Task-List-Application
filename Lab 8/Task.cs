using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class Task
    {
        public string TaskAssignee { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }

        public Task()
        {

        }

        public Task(string taskAssignee, string taskDescription, DateTime dueDate, bool complete)
        {
            TaskDescription = taskDescription;
            TaskAssignee = taskAssignee;
            DueDate = dueDate;
            Complete = complete;
        }
    }
}

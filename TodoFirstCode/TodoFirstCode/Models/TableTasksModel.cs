using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFirstCode.Models
{
    public class TableTasksModel
    {
        public int TableTasksModelId { get; set; }
        public string task_name { get; set; }
        public string task_notes { get; set; }
        public DateTime Time_of_create { get; set; }

        public int TaskStatusId { get; set; }
        public TaskStatus Status { get; set; }
    }
}
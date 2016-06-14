using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFirstCode.Models
{
    public class TableTasksModel
    {
        public int TableTasksModelId { get; set; }
        public string TaskName { get; set; }
        public string TaskNotes { get; set; }
        public DateTime TimeCreate { get; set; }

        public int TaskStatusId { get; set; }
        public TaskStatus Status { get; set; }
    }
}
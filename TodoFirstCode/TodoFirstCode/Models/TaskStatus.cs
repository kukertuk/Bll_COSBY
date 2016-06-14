using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFirstCode.Models
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public IEnumerable<TableTasksModel> TaskModels { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFirstCode.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Condition { get; set; }

        public IEnumerable<Task> TaskModels { get; set; }
    }
}
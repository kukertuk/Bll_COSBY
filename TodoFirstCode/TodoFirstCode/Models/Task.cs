using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFirstCode.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime TimeCreate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoFirstCode.Models
{
    public class TaskContext : DbContext
    {
        static TaskContext()
        {
            Database.SetInitializer<TaskContext>(new ContextInitializer());
        }

        public TaskContext() : base("TaskDB")
    { }
        public DbSet<TableTasksModel> TableTasksModels { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
    }
}
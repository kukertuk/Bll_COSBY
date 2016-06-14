using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TodoFirstCode.Models
{
    class ContextInitializer : DropCreateDatabaseIfModelChanges<TaskContext>
    {
        protected override void Seed(TaskContext db)
        {
            TaskStatus S1 = new TaskStatus { Status = "Активно" };
            TaskStatus S2 = new TaskStatus { Status = "Завершено" };

            db.TaskStatuses.Add(S1);
            db.TaskStatuses.Add(S2);
            db.SaveChanges();
        }
    }
}
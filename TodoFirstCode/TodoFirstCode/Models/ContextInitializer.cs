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
            Status S1 = new Status { Condition = "Активно" };
            Status S2 = new Status { Condition = "Завершено" };

            db.Statuses.Add(S1);
            db.Statuses.Add(S2);
            db.SaveChanges();
        }
    }
}
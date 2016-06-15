using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoFirstCode.Models;
using System.Data.Entity;
using System.Data;

namespace Todolist.Controllers
{
    public class HomeController : Controller
    {
        TaskContext db = new TaskContext();


        public ActionResult Index()
        {
            var Task = db.Tasks.Include(p => p.Status);
            return View(Task.ToList());
        }

        public ActionResult Create()
        {
            SelectList condition = new SelectList(db.Statuses, "Id", "Condition");
            ViewBag.TaskStatuses = condition;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            task.TimeCreate = DateTime.Now;
            db.Tasks.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Task task = db.Tasks.Find(id);
            if (task != null)
            {
                SelectList status = new SelectList(db.Statuses, "Id", "Condition", task.StatusId);
                ViewBag.TaskStatuses = status;
                return View(task);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            task.TimeCreate = DateTime.Now;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            Task TaskDelet = db.Tasks.Find(id);

            return View(TaskDelet);
        }


        [HttpPost]
        public ActionResult Delete(int id, Task Task)
        {


            Task TaskDelet = db.Tasks.Find(id);
            if (TaskDelet != null)
            {
                db.Tasks.Remove(TaskDelet);
                db.SaveChanges();
            }

                return RedirectToAction("Index");
            
        }
    }
}
    



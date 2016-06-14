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
            var Task = db.TableTasksModels.Include(p => p.Status);
            return View(Task.ToList());
        }

        public ActionResult Create()
        {
            SelectList condition = new SelectList(db.TaskStatuses, "Id", "Status");
            ViewBag.TaskStatuses = condition;
            return View();
        }

        [HttpPost]
        public ActionResult Create(TableTasksModel task)
        {
            task.TimeCreate = DateTime.Now;
            db.TableTasksModels.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TableTasksModel task = db.TableTasksModels.Find(id);
            if (task != null)
            {
                SelectList status = new SelectList(db.TaskStatuses, "Id", "Status", task.TaskStatusId);
                ViewBag.TaskStatuses = status;
                return View(task);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(TableTasksModel task)
        {
            task.TimeCreate = DateTime.Now;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            {
                var TaskDelet = db.TableTasksModels.Include(p => p.Status).First();

                return View(TaskDelet);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var TaskDelet = db.TableTasksModels.Include(p => p.Status).First();

            try
            {
                db.TableTasksModels.Remove(TaskDelet);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(TaskDelet);
            }
        }
    }
}


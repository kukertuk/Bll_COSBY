using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todolist.Models;
using System.Data.Entity;

namespace Todolist.Controllers
{
    public class MainController : Controller
    {

        TodolistDBEntities db = new TodolistDBEntities();

        //Отображение всех задач со статусом из связанной таблицы
        public ActionResult Index()
        {
            var Task = db.Tasks.Include(p => p.Condition);
            return View(Task.ToList());
        }

        public ActionResult Create()
        {
            // Формирование списка задач для передачи в представление
            SelectList condition = new SelectList(db.Conditions, "Id", "Status");
            ViewBag.Conditions = condition;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            //Добавление задач в таблицу
            task.DateCreate = DateTime.Now;
            db.Tasks.Add(task);
            db.SaveChanges();
            // перенаправление на главную страницу
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Определение задачи
            Task task = db.Tasks.Find(id);
            if (task != null)
            {
                // Реализация выбора статуса задачи
                SelectList status = new SelectList(db.Conditions, "Id", "Status", task.StatusId);
                ViewBag.Conditions = status;
                return View(task);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            task.DateCreate = DateTime.Now;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            {
                //Представление удаляемой задачи
                var TaskDelet = (from data in db.Tasks
                                 where data.Id == id
                                 select data).First();
                return View(TaskDelet);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var TaskDelet = (from data in db.Tasks
                              where data.Id == id
                              select data).First();
            try
            {
                //Удаление сущности
                db.Tasks.Remove(TaskDelet);
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

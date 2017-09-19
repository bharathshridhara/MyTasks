using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTasks.Data;
using System.Threading;
using MyTasks.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MyTasks.Controllers
{
    public class HomeController : Controller
    {
        private ToDoRepository _repo;

        public HomeController()
        {
            _repo = new ToDoRepository();
        }
        [Authorize]
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<ToDoViewModels>>(_repo.GetAllTasksByUser(User.Identity.GetUserId()));
            
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(ToDoViewModels model)
        {
            var toDo = Mapper.Map<ToDo>(model);
            toDo.AppUserId = User.Identity.GetUserId() ;
            var task = await _repo.AddTask(toDo);
            return RedirectToAction("Index");
        }

        
        public async Task<ActionResult> Delete(long id)
        {
            var task = await _repo.DeleteTaskById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var toDo = Mapper.Map<ToDoViewModels>(_repo.GetTaskById(id));
            return View(toDo);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ToDoViewModels model)
        {
            var toDo = Mapper.Map<ToDo>(model);
            var task = await _repo.Update(toDo);
            return RedirectToAction("Index");
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
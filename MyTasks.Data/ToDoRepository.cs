using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Data
{
    public class ToDoRepository
    {
        private TasksDBContext _db;

        public ToDoRepository()
        {
            
        }
        public IEnumerable<ToDo> GetAllTasks()
        {
            using (_db = new TasksDBContext())
            {
                var model = _db.ToDos.ToList<ToDo>();
                return model;
            }
        }

        public ToDo GetTaskById(long id)
        {
            using (_db = new TasksDBContext())
            {
                var model = _db.ToDos.Where(x => x.Id == id).FirstOrDefault<ToDo>();
                return model;
            }
        }

        public IEnumerable<ToDo> GetAllTasksByUser(string id)
        {
            using (_db = new TasksDBContext())
            {
                var model = _db.ToDos.Where(x => x.AppUserId == id).ToList();
                return model;
            }
        }

        public async Task<bool> AddTask(ToDo task)
        {
            using (_db = new TasksDBContext())
            {
                _db.ToDos.Add(task);
                var x = await _db.SaveChangesAsync();
                return Convert.ToBoolean(x);
            }
        }

        public async Task<bool> DeleteTaskById(long id)
        {
            using (_db = new TasksDBContext())
            {
                var item = _db.ToDos.Where(y => y.Id == id).FirstOrDefault();
                _db.ToDos.Remove(item);
                var x = await _db.SaveChangesAsync();
                return Convert.ToBoolean(x);
            }
        }

        public async Task<bool> Update(ToDo toDo)
        {
            using (_db = new TasksDBContext())
            {
                var item = _db.ToDos.Where(y => y.Id == toDo.Id).FirstOrDefault();
                item.Complete = toDo.Complete;
                item.Description = toDo.Description;
                item.Title = toDo.Title;
                item.StartDate = toDo.StartDate;
                item.EndDate = toDo.EndDate;

                var x = await _db.SaveChangesAsync();
                return Convert.ToBoolean(x);
            }
        }

        
    }
}

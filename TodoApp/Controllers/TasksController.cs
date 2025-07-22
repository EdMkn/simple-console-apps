using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Text.Json;

namespace TodoApp.Controllers
{
    [Route("Tasks")]
    public class TasksController : Controller
    {
        private static readonly string filePath = "tasks.json";
        private static readonly List<Models.Task> tasks = LoadTasks();

        [HttpGet("")]
        public IActionResult Index()
        {
            var loadedTasks = LoadTasks(); // load from JSON file
            return View(loadedTasks);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
            public IActionResult Add(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                var task = new Models.Task
                {
                    Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
                    Description = description,
                    IsComplete = false
                };
                tasks.Add(task);
                SaveTasks();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                SaveTasks();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("MarkDone/{id}")]
        public IActionResult MarkDone(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsComplete = true;
                SaveTasks();
            }

            return RedirectToAction("Index");
        }

        // Persistance
        private static List<Models.Task> LoadTasks()
        {
            if (!System.IO.File.Exists(filePath))
                return [];

            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Models.Task>>(json) ?? [];
        }

        static readonly JsonSerializerOptions s_options = new() { WriteIndented = true };
        private static void SaveTasks()
        {
            
            var json = JsonSerializer.Serialize(tasks, s_options);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}

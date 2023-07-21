using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            // Obtener las tareas desde la base de datos
            var items = await todoItemService.GetIncompleteItemsAsync();

            // Colocar los tareas en un modelo
            var model = new TodoViewModel()
            {
                Items = items
            };

            // Genera la vista usando el modelo
            return View(model);
        }
    }
}

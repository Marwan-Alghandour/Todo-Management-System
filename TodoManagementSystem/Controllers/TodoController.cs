using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace TodoManagementSystem.Controllers
{
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [Route("/")]
        [Route("[action]")]
        public async Task<IActionResult> Index(string status)
        {
            ViewBag.status = status;
            if (string.IsNullOrEmpty(status) || status == "All")
            {
                return View(await _todoService.GetAllTodos());
            }
            return View(await _todoService.GetFilteredByStatusTodos(status));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(TodoAddRequest todoAddRequest)
        {
            await _todoService.AddTodo(todoAddRequest);
            return RedirectToAction("Index");
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            return View((await _todoService.GetTodoById(id)).ToTodoUpdateRequest());
        }

        [Route("[action]/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(TodoUpdateRequest? todoUpdateRequest)
        {
            await _todoService.UpdateTodo(todoUpdateRequest);
            return RedirectToAction("Index");
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            await _todoService.DeleteTodo(id);
            return RedirectToAction("Index");
        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> MarkAsCompleted(Guid? id)
        {
            await _todoService.MarkAsCompleted(id);
            return RedirectToAction("Index");
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuickStartWebApi.Data;
using QuickStartWebApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickStartWebApi.Controllers
{
    [Route("api/todos")]
    public class TodoApiController : Controller
    {
        private readonly TodoContext _context;

        public TodoApiController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItemModel { Name = "Item1" });
                _context.SaveChanges();

            }
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _context.TodoItems.ToList();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.TodoItems.Find(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }



    }
}
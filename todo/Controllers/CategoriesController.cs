//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using todo.Data;
//using todo.Models;

//namespace todo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoryController : ControllerBase
//    {
//        private readonly DataAccessContext _context;
//        public CategoryController(DataAccessContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var CategoryList = _context.categories.ToList();
//            return Ok(CategoryList);
//        }
//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var Category = _context.categories.SingleOrDefault(c => c.CategoryId == id);
//            if (Category != null)
//            {
//                return Ok(Category);
//            }
//            else
//            {
//                return NotFound();
//            }
//        }
//        [HttpPost]
//        public IActionResult Createnew(CategoryModel model)
//        {
//            try
//            {
//                var Category = new Category
//                {
//                    CategoryName = model.CategoryName,
//                };
//                _context.Add(model);
//                _context.SaveChanges();
//                return Ok(Category);
//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }
//        [HttpPut("id}")]
//        public IActionResult UpdateById (int id, CategoryModel model)
//        {
//            var Category = _context.categories.SingleOrDefault(c => c.CategoryId==id);
//            if(Category != null)
//            {
//                Category.CategoryName = model.CategoryName;
//                _context.SaveChanges();
//                return NoContent();
//            }
//            else
//            {
//                return NotFound();
//            }
//        }
//    } 
//}


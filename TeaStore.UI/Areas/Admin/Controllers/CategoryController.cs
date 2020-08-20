using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAll());
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}

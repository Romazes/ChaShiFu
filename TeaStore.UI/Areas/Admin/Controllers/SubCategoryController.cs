using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;
using TeaStore.UI.ViewModels;

namespace TeaStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        [TempData]
        public string StatusMessage { get; set; }

        public SubCategoryController(ISubCategoryRepository subCategoryRepository,
                                     ICategoryRepository categoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        //GET - INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _subCategoryRepository.GetAll());
        }

        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _categoryRepository.GetAll(),
                SubCategory = new SubCategory(),
                SubCategoryList = await _subCategoryRepository.GetAllListUniqueOrderBy()
            };

            return View(model);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _subCategoryRepository.GetAll().Result
                    .Where(n => n.Name == model.SubCategory.Name && n.Category.Id == model.SubCategory.CategoryId);

                if (doesSubCategoryExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : Данная под-категория уже существует для " + doesSubCategoryExists.First().Category.Name
                        + ". Пожалуйста измените название под-категории.";
                }
                else
                {
                    await _subCategoryRepository.Add(model.SubCategory);
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _categoryRepository.GetAll(),
                SubCategory = new SubCategory(),
                SubCategoryList = await _subCategoryRepository.GetAllListUniqueOrderBy(),
                StatusMessage = StatusMessage
            };

            return View(modelVM);
        }

        //GET - ALL SUBCATEGORY FOR CURRENT CATEGORY
        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            //List<SubCategory> subCategories = new List<SubCategory>();

            var subCategories = _subCategoryRepository.GetAll().Result.Where(n => n.CategoryId == id);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }
    }
}
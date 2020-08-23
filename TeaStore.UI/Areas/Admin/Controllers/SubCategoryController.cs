using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                SubCategoryList = await _subCategoryRepository.GetAllListOrderedUnique()
            };

            return View(model);
        }

    }
}

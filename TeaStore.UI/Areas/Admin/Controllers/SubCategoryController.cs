using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaStore.Core.Interfaces;

namespace TeaStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        //GET - INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _subCategoryRepository.GetAll());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TeaStore.Core.Interfaces;

namespace TeaStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatalogItemController : Controller
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        //For upload images to server.
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CatalogItemController(ICatalogItemRepository catalogItemRepository, IWebHostEnvironment webHostEnvironment)
        {
            _catalogItemRepository = catalogItemRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //GET - INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _catalogItemRepository.GetAll());
        }
    }
}

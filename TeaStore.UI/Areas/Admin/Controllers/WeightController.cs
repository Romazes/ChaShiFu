using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WeightController : Controller
    {
        private readonly IWeightRepository _weightRepository;

        public WeightController(IWeightRepository weightRepository)
        {
            _weightRepository = weightRepository;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _weightRepository.GetAll());
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "Value")] Weight weight )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _weightRepository.Add(weight);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(weight);
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weight = await _weightRepository.GetById(id ?? 0);
            if (weight == null)
            {
                return NotFound();
            }
            return View(weight);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id", "Name", "Value")] Weight weight)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _weightRepository.Update(weight);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(weight);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weight = await _weightRepository.GetById(id ?? 0);
            if (weight == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(weight);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weight = await _weightRepository.GetById(id);
            if (weight == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _weightRepository.Remove(weight);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        //GET - DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weight = await _weightRepository.GetById(id ?? 0);
            if (weight == null)
            {
                return NotFound();
            }

            return View(weight);
        }



    }
}

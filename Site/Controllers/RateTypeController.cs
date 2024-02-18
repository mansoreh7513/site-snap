using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.Admin;

using Snapp.DataAccessLayer.Entites;

namespace Snapp.Site.Controllers
{
    public class RateTypeController : Controller
    {
        private IAdmin _admin;

        public RateTypeController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetRateTypes();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RateTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddRateType(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            RateType rateType = await _admin.GetRateTypeById(id);

            RateTypeViewModel viewModel = new RateTypeViewModel()
            {
                Name = rateType.Name,
                OK = rateType.OK,
                ViewOrder = rateType.ViewOrder
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, RateTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateRateType(viewModel, id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
             _admin.DeleteRateType(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

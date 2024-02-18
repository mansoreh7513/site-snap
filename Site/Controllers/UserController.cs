using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.Admin;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;


using Snapp.DataAccessLayer.Entites;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Snapp.Core.ViewModels;
using Stimulsoft.Base;

namespace Snapp.Site.Controllers
{
    public class UserController : Controller
    {
        private IAdmin _admin;
        private PersianCalendar pc = new PersianCalendar();

        public UserController(IAdmin admin)
        {
            StiLicense.LoadFromString("");

            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetUsers();

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddUser(viewModel);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title", viewModel.RoleId);
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            User user = await _admin.GetUserById(id);
            UserDetail userDetail = await _admin.GetUserDetail(id);

            UserEditViewModel viewModel = new UserEditViewModel()
            {
                RoleId = user.RoleId,
                IsActive = user.IsActive,
                Username = user.Username,
                BirthDate = userDetail.BirthDate,
                FullName = userDetail.FullName
            };

            if (userDetail.BirthDate == null)
            {
                ViewBag.MyDate = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") + "/" +
                                 pc.GetDayOfMonth(DateTime.Now).ToString("00");
            }
            else
            {
                ViewBag.MyDate = userDetail.BirthDate;
            }

            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title", user.RoleId);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel viewModel, Guid id)
        {
            if (ModelState.IsValid)
            {
                _admin.UpdateUser(viewModel, id);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.MyDate = viewModel.BirthDate;
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title", viewModel.RoleId);
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteUser(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DriverProp(Guid id)
        {
            var result = await _admin.GetDriver(id);

            DriverPropViewModel viewModel = new DriverPropViewModel()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NationalCode = result.NationalCode,
                Tel = result.Tel
            };

            ViewBag.IsError = false;
            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DriverProp(Guid id, DriverPropViewModel viewModel)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                status = _admin.UpdateDriverProp(id, viewModel);
            }

            if (status)
            {
                ViewBag.IsError = false;
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsError = true;
                ViewBag.IsSuccess = false;
            }

            var result = await _admin.GetDriver(id);


            DriverPropViewModel model = new DriverPropViewModel()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NationalCode = result.NationalCode,
                Tel = result.Tel
            };

            return View(model);
        }

        public async Task<IActionResult> DriverCertificate(Guid id)
        {
            var driver = await _admin.GetDriver(id);

            DriverImgViewModel model = new DriverImgViewModel()
            {
                ImgName = driver.Img,
                IsConfirm = driver.IsConfirm
            };

            ViewBag.IsSuccess = false;
            ViewBag.IsError = false;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DriverCertificate(Guid id, DriverImgViewModel viewModel)
        {
            var driver = await _admin.GetDriver(id);

            bool result = false;

            if (ModelState.IsValid)
            {
                result = _admin.UpdateDriverCertificate(id, viewModel);
            }

            if (result)
            {
                ViewBag.IsSuccess = true;
                ViewBag.IsError = false;
            }
            else
            {
                ViewBag.IsSuccess = false;
                ViewBag.IsError = true;
            }

            DriverImgViewModel model = new DriverImgViewModel()
            {
                ImgName = driver.Img,
                IsConfirm = driver.IsConfirm
            };

            return View(model);
        }

        public async Task<IActionResult> DriverCar(Guid id)
        {
            var driver = await _admin.GetDriver(id);

            DriverCarViewModel viewModel = new DriverCarViewModel()
            {
                CarCode = driver.CarCode,
                CarId = driver.CarId,
                ColorId = driver.ColorId
            };

            if (driver.CarId == null)
            {
                ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name");
            }
            else
            {
                ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name", driver.CarId);
            }

            if (driver.ColorId == null)
            {
                ViewBag.ColorId = new SelectList(await _admin.GetColors(), "Id", "Name");
            }
            else
            {
                ViewBag.ColorId = new SelectList(await _admin.GetColors(), "Id", "Name", driver.ColorId);
            }

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DriverCar(Guid id, DriverCarViewModel viewModel)
        {
            bool result = false;

            if (ModelState.IsValid)
            {

                result = _admin.UpdateDriverCar(id, viewModel);

            }

            if (result)
            {
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsSuccess = false;
            }

            ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name", viewModel.CarId);
            ViewBag.ColorId = new SelectList(await _admin.GetColors(), "Id", "Name", viewModel.ColorId);

            return View(viewModel);
        }

        public IActionResult ShowPrint()
        {
            return View("ShowPrint");
        }

        public IActionResult Print()
        {
            StiReport report = new StiReport();

            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/reports/Report2.mrt"));

            var users = _admin.GetUsers().Result;

            List<Report2ViewModel> report2s = new List<Report2ViewModel>();

            foreach (var item in users)
            {
                Report2ViewModel report2 = new Report2ViewModel()
                {
                    NationalCode = "ندارد",
                    BirthDate = item.UserDetail.BirthDate,
                    FullName = item.UserDetail.FullName,
                    Username = item.Username
                };

                report2s.Add(report2);
            }

            report.RegData("dt2", report2s);
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Snapp.DataAccessLayer.Context;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entites;
using Snapp.Core.Generators;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Snapp.Core.Securities;

namespace Snapp.Core.Services
{
    public class AdminService : IAdmin
    {
        private DatabaseContext _context;

        public AdminService(DatabaseContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void AddCar(CarViewModel viewModel)
        {
            Car car = new Car()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name
            };

            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteCar(Guid id)
        {
            Car car = _context.Cars.Find(id);

            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();

               
            }
        }

        public async Task<Car> GetCarById(Guid id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars.OrderBy(c => c.Name).ToListAsync();
        }

        public bool UpdateCar(Guid id, CarViewModel viewModel)
        {
            Car car = _context.Cars.Find(id);

            if (car != null)
            {
                car.Name = viewModel.Name;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Color>> GetColors()
        {
            return await _context.Colors.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Color> GetColorById(Guid id)
        {
            return await _context.Colors.FindAsync(id);
        }

        public void AddColor(AdminColorViewModel viewModel)
        {
            Color color = new Color()
            {
                Id = CodeGenerators.GetId(),
                Code = viewModel.Code,
                Name = viewModel.Name
            };

            _context.Colors.Add(color);
            _context.SaveChanges();
        }

        public bool UpdateColor(AdminColorViewModel viewModel, Guid id)
        {
            Color color = _context.Colors.Find(id);

            if (color != null)
            {
                color.Name = viewModel.Name;
                color.Code = viewModel.Code;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteColor(Guid id)
        {
            Color color = _context.Colors.Find(id);

            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();

                
            }
        }

        public async Task<List<RateType>> GetRateTypes()
        {
            return await _context.RateTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<RateType> GetRateTypeById(Guid id)
        {
            return await _context.RateTypes.FindAsync(id);
        }

        public void AddRateType(RateTypeViewModel viewModel)
        {
            RateType rateType = new RateType()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                OK = viewModel.OK,
                ViewOrder = viewModel.ViewOrder
            };

            _context.RateTypes.Add(rateType);
            _context.SaveChanges();
        }

        public bool UpdateRateType(RateTypeViewModel viewModel, Guid id)
        {
            RateType rateType = _context.RateTypes.Find(id);

            if (rateType != null)
            {
                rateType.Name = viewModel.Name;
                rateType.OK = viewModel.OK;
                rateType.ViewOrder = viewModel.ViewOrder;

                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public void DeleteRateType(Guid id)
        {
            RateType rateType = _context.RateTypes.Find(id);

            if (rateType != null)
            {
                _context.RateTypes.Remove(rateType);
                _context.SaveChanges();

            }

        }

        public async Task<Setting> GetSetting()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public bool UpdateSiteSetting(SiteSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.Desc = viewModel.Desc;
                setting.Tel = viewModel.Tel;
                setting.Name = viewModel.Name;
                setting.Fax = viewModel.Fax;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePriceSetting(PriceSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.IsDistance = viewModel.IsDistance;
                setting.IsWeatherPirce = viewModel.IsWeatherPirce;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdateAboutSetting(AboutSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.About = viewModel.About;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTermsSetting(TermsSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.Terms = viewModel.Terms;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<PriceType>> GetPriceTypes()
        {
            return await _context.priceTypes.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<PriceType> GetPriceTypeById(Guid id)
        {
            return await _context.priceTypes.FindAsync(id);
        }

        public void AddPriceType(PriceTypeViewModel viewModel)
        {
            PriceType priceType = new PriceType()
            {
                End = viewModel.End,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Id = CodeGenerators.GetId(),
                Start = viewModel.Start
            };

            _context.priceTypes.Add(priceType);
            _context.SaveChanges();
        }

        public bool UpdatePriceType(PriceTypeViewModel viewModel, Guid id)
        {
            PriceType priceType = _context.priceTypes.Find(id);

            if (priceType != null)
            {
                priceType.End = viewModel.End;
                priceType.Start = viewModel.Start;
                priceType.Name = viewModel.Name;
                priceType.Price = viewModel.Price;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeletePriceType(Guid id)
        {
            PriceType priceType = _context.priceTypes.Find(id);

            _context.priceTypes.Remove(priceType);
            _context.SaveChanges();
        }

        public async Task<List<MonthType>> GetMonthTypes()
        {
            return await _context.MonthTypes.OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<MonthType> GetMonthTypeById(Guid id)
        {
            return await _context.MonthTypes.FindAsync(id);
        }

        public void AddMonthType(MonthTypeViewModel viewModel)
        {
            MonthType monthType = new MonthType()
            {
                Id = CodeGenerators.GetId(),
                End = viewModel.End,
                Name = viewModel.Name,
                Precent = viewModel.Percent,
                Start = viewModel.Start
            };

            _context.MonthTypes.Add(monthType);
            _context.SaveChanges();
        }

        public bool UpdateMonthType(MonthTypeViewModel viewModel, Guid id)
        {
            MonthType monthType = _context.MonthTypes.Find(id);

            if (monthType != null)
            {
                monthType.End = viewModel.End;
                monthType.Start = viewModel.Start;
                monthType.Name = viewModel.Name;
                monthType.Precent = viewModel.Percent;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteMonthType(Guid id)
        {
            MonthType monthType = _context.MonthTypes.Find(id);

            _context.MonthTypes.Remove(monthType);
            _context.SaveChanges();
        }

        public async Task<List<Humidity>> GetHumiditys()
        {
            return await _context.Humidities.OrderBy(h => h.Name).ToListAsync();
        }

        public async Task<Humidity> GetHumidityById(Guid id)
        {
            return await _context.Humidities.FindAsync(id);
        }

        public void AddHumidity(MonthTypeViewModel viewModel)
        {
            Humidity humidity = new Humidity()
            {
                End = viewModel.End,
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Precent = viewModel.Percent,
                Start = viewModel.Start
            };

            _context.Humidities.Add(humidity);
            _context.SaveChanges();
        }

        public bool UpdateHumidity(MonthTypeViewModel viewModel, Guid id)
        {
            Humidity humidity = _context.Humidities.Find(id);

            if (humidity != null)
            {
                humidity.End = viewModel.End;
                humidity.Name = viewModel.Name;
                humidity.Precent = viewModel.Percent;
                humidity.Start = viewModel.Start;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteHumidity(Guid id)
        {
            Temperature temperature = _context.temperatures.Find(id);

            if (temperature != null)
            {
                _context.temperatures.Remove(temperature);
                _context.SaveChanges();
            }
        }

        public async Task<List<Temperature>> GetTemperatures()
        {
            return await _context.temperatures.OrderBy(h => h.Name).ToListAsync();
        }

        public async Task<Temperature> GetTemperatureById(Guid id)
        {
            return await _context.temperatures.FindAsync(id);
        }

        public void AddTemperature(MonthTypeViewModel viewModel)
        {
            Temperature temperature = new Temperature()
            {
                End = viewModel.End,
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Precent = viewModel.Percent,
                Start = viewModel.Start
            };

            _context.temperatures.Add(temperature);
            _context.SaveChanges();
        }

        public bool UpdateTemperature(MonthTypeViewModel viewModel, Guid id)
        {
            Temperature temperature = _context.temperatures.Find(id);

            if (temperature != null)
            {
                temperature.End = viewModel.End;
                temperature.Name = viewModel.Name;
                temperature.Precent = viewModel.Percent;
                temperature.Start = viewModel.Start;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteTemperature(Guid id)
        {
            Temperature temperature = _context.temperatures.Find(id);

            if (temperature != null)
            {
                _context.temperatures.Remove(temperature);
                _context.SaveChanges();
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.OrderBy(r => r.Title).ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public void AddRole(RoleViewModel viewModel)
        {
            Role role = new Role()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Title = viewModel.Title
            };

            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public bool UpdateRole(RoleViewModel viewModel, Guid id)
        {
            Role role = _context.Roles.Find(id);

            if (role != null)
            {
                role.Name = viewModel.Name;
                role.Title = viewModel.Title;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteRole(Guid id)
        {
            Role role = _context.Roles.Find(id);

            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }

        public bool CheckUsername(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
       

        public void AddUser(UserViewModel viewModel)
        {
            User user = new User()
            {
                Id = CodeGenerators.GetId(),
                IsActive = viewModel.IsActive,
                Password = HashEncode.GetHashCode(HashEncode.GetHashCode(CodeGenerators.GetActiveCode())),
                RoleId = viewModel.RoleId,
                Token = null,
                Username = viewModel.Username,
                Wallet = 0
            };

            _context.Users.Add(user);

            UserDetail userDetail = new UserDetail()
            {
                UserId = user.Id,
                BirthDate = null,
                Date = DateTimeGenerator.GetShamsiDate(),
                Time = DateTimeGenerator.GetShamsiTime(),
                FullName = null
            };

            _context.UserDetails.Add(userDetail);

            if (GetRoleId(viewModel.RoleId) == "driver")
            {
                Driver driver = new Driver()
                {
                    IsConfirm = false,
                    Address = null,
                    Avatar = null,
                    CarCode = null,
                    CarId = null,
                    ColorId = null,
                    Img = null,
                    Tel = null,
                    NationalCode = null,
                    UserId = user.Id
                };

                _context.Drivers.Add(driver);
            }

            _context.SaveChanges();
        }

        public string GetRoleId(Guid id)
        {
            return _context.Roles.Find(id).Name;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Role).Include(u => u.UserDetail).OrderBy(u => u.Username).ToListAsync();
        }

        public void DeleteUser(Guid id)
        {
            User user = _context.Users.Find(id);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void AddDriver(Guid id)
        {
            Driver driver = new Driver()
            {
                IsConfirm = false,
                Address = null,
                Avatar = null,
                CarCode = null,
                CarId = null,
                ColorId = null,
                Img = null,
                Tel = null,
                NationalCode = null,
                UserId = id
            };

            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public void DeleteDriver(Guid id)
        {
            Driver driver = _context.Drivers.Find(id);

            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }

        public bool UpdateUser(UserEditViewModel viewModel, Guid id)
        {
            User user = _context.Users.Find(id);
            UserDetail userDetail = _context.UserDetails.Find(id);

            if (user != null)
            {
                userDetail.FullName = viewModel.FullName;
                userDetail.BirthDate = viewModel.BirthDate;
                user.RoleId = viewModel.RoleId;
                user.IsActive = viewModel.IsActive;

                user.Username = viewModel.Username;

                if (GetRoleId(viewModel.RoleId) == "driver")
                {
                    if (!_context.Drivers.Any(d => d.UserId == id))
                    {
                        AddDriver(id);
                    }
                }
                else
                {
                    if (_context.Drivers.Any(d => d.UserId == id))
                    {
                        DeleteDriver(id);
                    }
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }


        public bool CheckUsernameForUpdate(string username, Guid id)
        {
            return _context.Users.Any(u => u.Username == username && u.Id != id);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool UpdateDriverProp(Guid id, DriverPropViewModel viewModel)
        {
            Driver driver = _context.Drivers.Find(id);

            if (viewModel.Avatar != null)
            {
                string strExt = Path.GetExtension(viewModel.Avatar.FileName);

                if (strExt != ".jpg")
                {
                    return false;
                }

                string filePath = "";

                viewModel.AvatarName = CodeGenerators.GetFileName() + strExt;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/driver/", viewModel.AvatarName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Avatar.CopyTo(stream);
                }

                if (driver.Avatar != null)
                {
                    File.Delete("wwwroot/img/driver/" + driver.Avatar);
                }

                driver.Avatar = viewModel.AvatarName;
                driver.NationalCode = viewModel.NationalCode;
                driver.Address = viewModel.Address;
                driver.Tel = viewModel.Tel;

                _context.SaveChanges();

                return true;
            }
            else
            {
                if (driver.Avatar != null)
                {
                    driver.NationalCode = viewModel.NationalCode;
                    driver.Address = viewModel.Address;
                    driver.Tel = viewModel.Tel;

                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public async Task<Driver> GetDriver(Guid id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public bool UpdateDriverCertificate(Guid id, DriverImgViewModel viewModel)
        {
            Driver driver = _context.Drivers.Find(id);

            if (viewModel.Img != null)
            {
                string strExt = Path.GetExtension(viewModel.Img.FileName);

                if (strExt != ".jpg")
                {
                    return false;
                }

                string filePath = "";

                viewModel.ImgName = CodeGenerators.GetFileName() + strExt;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/driver/", viewModel.ImgName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Img.CopyTo(stream);
                }

                driver.Img = viewModel.ImgName;
                driver.IsConfirm = viewModel.IsConfirm;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool UpdateDriverCar(Guid id, DriverCarViewModel viewModel)
        {
            Driver driver = _context.Drivers.Find(id);

            driver.CarCode = viewModel.CarCode;
            driver.CarId = viewModel.CarId;
            driver.ColorId = viewModel.ColorId;

            _context.SaveChanges();

            return true;
        }

        public async Task<UserDetail> GetUserDetail(Guid id)
        {
            return await _context.UserDetails.FindAsync(id);
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            return await _context.Discounts.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(Guid id)
        {
            return await _context.Discounts.FindAsync(id);
        }

        public void AddDiscount(AdminDiscountViewModel viewModel)
        {
            Discount discount = new Discount()
            {
                Code = viewModel.Code,
                Desc = viewModel.Desc,
                Expire = viewModel.Expire,
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Percent = viewModel.Percent,
                Price = viewModel.Price,
                Start = viewModel.Start
            };

            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public bool UpdateDiscount(AdminDiscountViewModel viewModel, Guid id)
        {
            Discount discount = _context.Discounts.Find(id);

            if (discount != null)
            {
                discount.Code = viewModel.Code;
                discount.Start = viewModel.Start;
                discount.Expire = viewModel.Expire;
                discount.Desc = viewModel.Desc;
                discount.Name = viewModel.Name;
                discount.Percent = viewModel.Percent;
                discount.Price = viewModel.Price;

                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public void DeleteDiscount(Guid id)
        {
            Discount discount = _context.Discounts.Find(id);

            _context.Discounts.Remove(discount);
            _context.SaveChanges();
        }

        public int WeeklyFactor(string date)
        {
            if (!_context.Factors.Any(f => f.RefNumber != null && f.Date == date))
            {
                return 0;
            }

            return _context.Factors.Where(f => f.RefNumber != null && f.Date == date).ToList().Sum(f => f.Price);
        }

        public int MonthlyFactor(string month)
        {
            string strYear = DateTimeGenerator.GetShamsiDate().Substring(0, 4);

            if (!_context.Factors.Any(f => f.RefNumber != null && f.Date.Substring(5, 2) == month && f.Date.Substring(0, 4) == strYear))
            {
                return 0;
            }

            return _context.Factors.Where(f => f.RefNumber != null && f.Date.Substring(5, 2) == month && f.Date.Substring(0, 4) == strYear).ToList().Sum(f => f.Price);
        }

        public int WeeklyRegister(string date)
        {
            if (!_context.Users.Include(f => f.UserDetail).Any(f => f.IsActive == true && f.UserDetail.Date == date))
            {
                return 0;
            }

            return _context.Users.Include(f => f.UserDetail).Where(f => f.IsActive == true && f.UserDetail.Date == date).ToList().Count();
        }

        public int MonthlyRegister(string month)
        {
            string strYear = DateTimeGenerator.GetShamsiDate().Substring(0, 4);

            if (!_context.Users.Include(f => f.UserDetail).Any(f => f.IsActive == true && f.UserDetail.Date.Substring(5, 2) == month && f.UserDetail.Date.Substring(0, 4) == strYear))
            {
                return 0;
            }

            return _context.Users.Include(f => f.UserDetail).Where(f => f.IsActive == true && f.UserDetail.Date.Substring(5, 2) == month && f.UserDetail.Date.Substring(0, 4) == strYear).ToList().Count();
        }

        public async Task<List<Transact>> GetTransacts()
        {
            return await _context.Transacts.OrderByDescending(x => x.Date).ThenByDescending(x => x.StartTime).ToListAsync();
        }

        public void DeleteTransact(Guid id)
        {
            var transact = _context.Transacts.Find(id);

            _context.Transacts.Remove(transact);
            _context.SaveChanges();
        }

        public async Task<List<TransactRate>> GetTransactRates(Guid id)
        {
            return await _context.TransactRates.Where(x => x.TransactId == id).ToListAsync();
        }

        public async Task<List<Transact>> LastTransact()
        {
            return await _context.Transacts.Include(x => x.User).Where(x => x.Status == 2).OrderByDescending(x => x.Date).ThenByDescending(x => x.EndTime).Take(5).ToListAsync();
        }

        public int? WeeklyTransact(string date)
        {
            if (!_context.Transacts.Any(x => x.Status == 2 && x.Date == date))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(_context.Transacts.Where(x => x.Status == 2 && x.Date == date).Sum(x => x.Total));
            }
        }

        public async Task<List<Transact>> FillTransactInProcess(string date)
        {
            return await _context.Transacts.Include(x => x.User).Where(x => x.Status == 1 && x.Date == date)
                .OrderByDescending(x => x.StartTime).ToListAsync();
        }

        public async Task<List<Transact>> FillCancelTransact(string date)
        {
            return await _context.Transacts.Include(x => x.User).Where(x => x.Status == 3 && x.Date == date)
                .OrderByDescending(x => x.StartTime).ToListAsync();
        }
    }
}



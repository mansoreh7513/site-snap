﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Microsoft.EntityFrameworkCore;

using Snapp.DataAccessLayer.Context;
using Snapp.Core.Interfaces;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entites;
using Snapp.Core.ViewModels.Panel;

using Snapp.Core.Generators;

namespace Snapp.Core.Services
{
    public class PanelService : IPanel
    {
        private DatabaseContext _context;

        public PanelService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddAddress(Guid id, UserAddressViewModel viewModel)
        {
            UserAddresse addresse = new UserAddresse()
            {
                Desc = viewModel.Desc,
                Id = CodeGenerators.GetId(),
                Lat = viewModel.Lat,
                Lng = viewModel.Lng,
                Title = viewModel.Title,
                UserId = id
            };

            _context.UserAddresses.Add(addresse);
            _context.SaveChanges();
        }

        public void AddFactor(Factor factor)
        {
            _context.Factors.Add(factor);
            _context.SaveChanges();
        }

        public void AddTransact(Transact model)
        {
            _context.Transacts.Add(model);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public Guid? ExistsUserTransact(Guid id)
        {
            // 0 == Create
            // 1 == Driver
            // 2 == Success
            // 3 == Cancel

            Transact transact = _context.Transacts.FirstOrDefault(x => x.UserId == id && (x.Status == 0 || x.Status == 1 || x.Rate == 0));

            if (transact != null)
            {
                return transact.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Transact>> GetDriverTransacts(Guid id)
        {
            return await _context.Transacts.Where(x => x.DriverId == id && x.Status == 2).OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<Factor> GetFactor(Guid id)
        {
            return await _context.Factors.FindAsync(id);
        }

        public Guid GetFactorById(string orderNumber)
        {
            return _context.Factors.SingleOrDefault(f => f.OrderNumber == orderNumber).Id;
        }

        public float GetHumidityPercent(double id)
        {
            var hum = _context.Humidities.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (hum == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(hum.Precent / 100);
            }
        }

        public long GetPriceType(double id)
        {
            var priceType = _context.priceTypes.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (priceType == null)
            {
                return 0;
            }
            else
            {
                return priceType.Price;
            }
        }

        public string GetRoleName(string username)
        {
            return _context.Users.Include(u => u.Role).SingleOrDefault(u => u.Username == username).Role.Name;
        }

        public float GetTempPercent(double id)
        {
            var temp = _context.temperatures.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (temp == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(temp.Precent / 100);
            }
        }

        public async Task<Transact> GetTransactById(Guid id)
        {
            return await _context.Transacts.FindAsync(id);
        }

        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public async Task<List<UserAddresse>> GetUserAddresses(Guid id)
        {
            return await _context.UserAddresses.Where(a => a.UserId == id).ToListAsync();
        }

        public async Task<UserDetail> GetUserDetails(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.Username == username);
        }

        public Guid GetUserId(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username).Id;
        }

        public async Task<List<Transact>> GetUserTransacts(Guid id)
        {
            return await _context.Transacts.Where(x => x.UserId == id && x.Status == 2).OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public Transact GetUserTransact(Guid id)
        {
            return _context.Transacts.Find(id);
        }

        public void UpdateDriver(Guid id, Guid driverId)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.DriverId = driverId;
            _context.SaveChanges();
        }

        public void UpdateDriverRate(Guid id, bool rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.DriverRate = rate;
            _context.SaveChanges();
        }

        public bool UpdateFactor(Guid userid, string orderNumber, long price)
        {
            Factor factor = _context.Factors.SingleOrDefault(f => f.UserId == userid && f.BankName == null);

            if (factor != null)
            {
                factor.OrderNumber = orderNumber;
                factor.Price = Convert.ToInt32(price);

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trace, string refId)
        {
            Factor factor = _context.Factors.Find(id);
            User user = _context.Users.Find(factor.UserId);

            factor.Date = DateTimeGenerator.GetShamsiDate();
            factor.Time = DateTimeGenerator.GetShamsiTime();
            factor.Desc = desc;
            factor.TraceNumber = trace;
            factor.BankName = bank;
            factor.RefNumber = refId;

            user.Wallet += factor.Price;

            _context.SaveChanges();
        }

        public void UpdatePayment(Guid id)
        {
            
        }

        public void UpdateRate(Guid id, int rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Rate = rate;
            _context.SaveChanges();
        }

        public void UpdateStatus(Guid id, Guid? driverId, int status)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Status = status;

            if (driverId != null)
            {
                transact.DriverId = driverId;
            }

            _context.SaveChanges();
        }

        public bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel)
        {
            UserDetail user = _context.UserDetails.Find(id);

            if (user != null)
            {
                user.FullName = viewModel.FullName;
                user.BirthDate = viewModel.BirthDate;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.Include(x => x.UserDetail).FirstOrDefault(x => x.Id == id);
        }

        public Driver GetDriverById(Guid id)
        {
            return _context.Drivers.Include(x => x.Car).Include(x => x.Color).FirstOrDefault(x => x.UserId == id);
        }

        public List<Transact> GetTransactsNotAccept()
        {
            return _context.Transacts.Where(x => x.Status == 0).OrderByDescending(x => x.Date).ToList();
        }

        public Transact GetDriverConfrimTransact(Guid id)
        {
            return _context.Transacts.FirstOrDefault(x => x.DriverId == id && x.Status == 1);
        }

        public Transact GetUserConfrimTransact(Guid id)
        {
            return _context.Transacts.FirstOrDefault(x => x.UserId == id && x.Status == 1);
        }

        public void EndRequest(Guid id)
        {
            Transact transact = _context.Transacts.Find(id);

            if (transact.IsCash == false)
            {
                User user = _context.Users.Find(transact.UserId);

                user.Wallet -= transact.Total;
            
            }

            transact.Status = 2;
            _context.SaveChanges();
        }

        public void AddRate(Guid id, int rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Rate = rate;
            _context.SaveChanges();
        }
    }
}

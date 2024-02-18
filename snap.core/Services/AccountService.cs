using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Microsoft.EntityFrameworkCore;

using Snapp.Core.Senders;
using Snapp.Core.Generators;
using Snapp.Core.Securities;

using System.Threading.Tasks;

using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entites;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels;

namespace Snapp.Core.Services
{
    public class AccountService : IAccount
    {
        private DatabaseContext _context;

        public AccountService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> ActiveUser(ActiveViewModel viewModel)
        {
            //string password = HashEncode.GetHashCode(HashEncode.GetHashCode(viewModel.Code));
            string password = viewModel.Code;

            User user = _context.Users.SingleOrDefault(u => u.Password == password);

            if (user != null)
            {
                user.IsActive = true;
                user.Password = HashEncode.GetHashCode(HashEncode.GetHashCode(CodeGenerators.GetActiveCode()));

                _context.SaveChanges();
            }

            return await Task.FromResult(user);
        }

        public bool CheckMobileNumber(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public bool CheckUserRole(string role, string username)
        {
            Role myRole = _context.Roles.SingleOrDefault(r => r.Name == role);

            return _context.Users.Any(u => u.Username == username && u.RoleId == myRole.Id);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public Guid GetRoleByName(string name)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == name).Id;
        }

        public async Task<User> GetUser(string username)
        {
            return await Task.FromResult(_context.Users.SingleOrDefault(u => u.Username == username));
        }

        public async Task<User> RegisterDriver(RegisterViewModel viewModel)
        {
            if (!CheckMobileNumber(viewModel.Username))
            {
                string code = CodeGenerators.GetActiveCode();

                User user = new User()
                {
                    IsActive = false,
                    Id = CodeGenerators.GetId(),
                    //Password = HashEncode.GetHashCode(HashEncode.GetHashCode(code)),
                    Password = code,
                    RoleId = GetRoleByName("driver"),
                    Token = null,
                    Username = viewModel.Username
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

                _context.SaveChanges();

                try
                {
                    SmsSender.VerifySend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
            else
            {
                User user = await GetUser(viewModel.Username);

                string code = CodeGenerators.GetActiveCode();

                //UpdateUserPassword(user.Id, HashEncode.GetHashCode(HashEncode.GetHashCode(code)));
                UpdateUserPassword(user.Id, code);

                try
                {
                    SmsSender.VerifySend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
        }

        public async Task<User> RegisterUser(RegisterViewModel viewModel)
        {
            if (!CheckMobileNumber(viewModel.Username))
            {
                string code = CodeGenerators.GetActiveCode();

                User user = new User()
                {
                    IsActive = false,
                    Id = CodeGenerators.GetId(),
                    //Password = HashEncode.GetHashCode(HashEncode.GetHashCode(code)),
                    Password = code,
                    RoleId = GetRoleByName("user"),
                    Token = null,
                    Username = viewModel.Username
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
                _context.SaveChanges();

                try
                {
                    SmsSender.VerifySend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
            else
            {
                User user = await GetUser(viewModel.Username);

                string code = CodeGenerators.GetActiveCode();

                //UpdateUserPassword(user.Id, HashEncode.GetHashCode(HashEncode.GetHashCode(code)));
                UpdateUserPassword(user.Id, code);

                try
                {
                    SmsSender.VerifySend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
        }

        public void UpdateToken(Guid id, string token)
        {
            User user = _context.Users.Find(id);

            user.Password = null;
            user.Token = token;

            _context.SaveChanges();
        }

        public void UpdateUserPassword(Guid Id, string code)
        {
            User user = _context.Users.Find(Id);

            //user.Password = HashEncode.GetHashCode(HashEncode.GetHashCode(code));
            user.Password = code;

            _context.SaveChanges();
        }
    }
}

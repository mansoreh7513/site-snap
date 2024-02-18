using System;
using System.Collections.Generic;
using System.Text;

using Snapp.Core.ViewModels;

using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entites;

namespace Snapp.Core.Interfaces
{
    public interface IAccount : IDisposable
    {
        bool CheckMobileNumber(string username);

        Task<User> RegisterUser(RegisterViewModel viewModel);

        Task<User> RegisterDriver(RegisterViewModel viewModel);

        Guid GetRoleByName(string name);

        Task<User> GetUser(string username);

        void UpdateUserPassword(Guid Id, string code);

        Task<User> ActiveUser(ActiveViewModel viewModel);

        bool CheckUserRole(string role, string username);
    }
}

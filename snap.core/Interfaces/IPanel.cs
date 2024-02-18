using System;
using System.Collections.Generic;
using System.Text;

using Snapp.DataAccessLayer.Entites;

using Snapp.Core.ViewModels.Panel;

using System.Threading.Tasks;

namespace Snapp.Core.Interfaces
{
    public interface IPanel :  IDisposable
    {
        Task<UserDetail> GetUserDetails(string username);
        string GetRoleName(string username);
        Guid GetUserId(string username);
        User GetUserById(Guid id);
        Driver GetDriverById(Guid id);
        bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel);
        User GetUser(string username);
        long GetPriceType(double id);
        float GetTempPercent(double id);
        float GetHumidityPercent(double id);

        #region Addresses

        Task<List<UserAddresse>> GetUserAddresses(Guid id);
        void AddAddress(Guid id, UserAddressViewModel viewModel);


        #endregion

        #region Payment

        void AddFactor(Factor factor);
        bool UpdateFactor(Guid userid, string orderNumber, long price);
        Guid GetFactorById(string orderNumber);
        void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trace, string refId);
        Task<Factor> GetFactor(Guid id);
        #endregion

        #region Transact

        void AddTransact(Transact model);
        void UpdatePayment(Guid id);
        void UpdateRate(Guid id, int rate);
        Task<Transact> GetTransactById(Guid id);
        Task<List<Transact>> GetUserTransacts(Guid id);
        Task<List<Transact>> GetDriverTransacts(Guid id);
        void UpdateDriver(Guid id, Guid driverId);
        void UpdateDriverRate(Guid id, bool rate);
        void UpdateStatus(Guid id, Guid? driverId, int status);
        List<Transact> GetTransactsNotAccept();

        Transact GetUserTransact(Guid id);
        Guid? ExistsUserTransact(Guid id);

        #endregion

        #region Request

        Transact GetDriverConfrimTransact(Guid id);
        Transact GetUserConfrimTransact(Guid id);
        void EndRequest(Guid id);
        void AddRate(Guid id, int rate);

        #endregion
    }
}

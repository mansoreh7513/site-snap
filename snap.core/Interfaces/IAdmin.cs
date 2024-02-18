using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Snapp.Core.ViewModels.Admin;

using Snapp.DataAccessLayer.Entites;

namespace Snapp.Core.Interfaces
{
    public interface IAdmin : IDisposable
    {
        #region Car

        Task<List<Car>> GetCars();

        Task<Car> GetCarById(Guid id);

        void AddCar(CarViewModel viewModel);

        bool UpdateCar(Guid id, CarViewModel viewModel);

        void DeleteCar(Guid id);

        #endregion

        #region Color

        Task<List<Color>> GetColors();

        Task<Color> GetColorById(Guid id);

        void AddColor(AdminColorViewModel viewModel);

        bool UpdateColor(AdminColorViewModel viewModel, Guid id);

        void DeleteColor(Guid id);

        #endregion

        #region RateType

        Task<List<RateType>> GetRateTypes();

        Task<RateType> GetRateTypeById(Guid id);

        void AddRateType(RateTypeViewModel viewModel);

        bool UpdateRateType(RateTypeViewModel viewModel, Guid id);

        void DeleteRateType(Guid id);

        #endregion

        #region Setting

        Task<Setting> GetSetting();

        bool UpdateSiteSetting(SiteSettingViewModel viewModel);

        bool UpdatePriceSetting(PriceSettingViewModel viewModel);

        bool UpdateAboutSetting(AboutSettingViewModel viewModel);

        bool UpdateTermsSetting(TermsSettingViewModel viewModel);



        #endregion

        #region PriceType

        Task<List<PriceType>> GetPriceTypes();

        Task<PriceType> GetPriceTypeById(Guid id);

        void AddPriceType(PriceTypeViewModel viewModel);

        bool UpdatePriceType(PriceTypeViewModel viewModel, Guid id);

        void DeletePriceType(Guid id);

        #endregion

        #region MonthType

        Task<List<MonthType>> GetMonthTypes();

        Task<MonthType> GetMonthTypeById(Guid id);

        void AddMonthType(MonthTypeViewModel viewModel);

        bool UpdateMonthType(MonthTypeViewModel viewModel, Guid id);

        void DeleteMonthType(Guid id);

        #endregion

        #region Humidity

        Task<List<Humidity>> GetHumiditys();

        Task<Humidity> GetHumidityById(Guid id);

        void AddHumidity(MonthTypeViewModel viewModel);

        bool UpdateHumidity(MonthTypeViewModel viewModel, Guid id);

        void DeleteHumidity(Guid id);

        #endregion

        #region Temperature

        Task<List<Temperature>> GetTemperatures();

        Task<Temperature> GetTemperatureById(Guid id);

        void AddTemperature(MonthTypeViewModel viewModel);

        bool UpdateTemperature(MonthTypeViewModel viewModel, Guid id);

        void DeleteTemperature(Guid id);

        #endregion

        #region Role

        Task<List<Role>> GetRoles();

        Task<Role> GetRoleById(Guid id);

        void AddRole(RoleViewModel viewModel);

        bool UpdateRole(RoleViewModel viewModel, Guid id);

        void DeleteRole(Guid id);

        #endregion

        #region User

        string GetRoleId(Guid id);
        bool CheckUsername(string username);
        void AddUser(UserViewModel viewModel);
        //Guid AddUser(UserViewModel viewModel);
        Task<List<User>> GetUsers();
        void DeleteUser(Guid id);
        void AddDriver(Guid id);
        void DeleteDriver(Guid id);
        bool UpdateUser(UserEditViewModel viewModel, Guid id);
        bool CheckUsernameForUpdate(string username, Guid id);
        Task<User> GetUserById(Guid id);
        Task<UserDetail> GetUserDetail(Guid id);
        Task<Driver> GetDriver(Guid id);
        bool UpdateDriverProp(Guid id, DriverPropViewModel viewModel);
        bool UpdateDriverCertificate(Guid id, DriverImgViewModel viewModel);
        bool UpdateDriverCar(Guid id, DriverCarViewModel viewModel);
        #endregion

        #region Discount

        Task<List<Discount>> GetDiscounts();

        Task<Discount> GetDiscountById(Guid id);

        void AddDiscount(AdminDiscountViewModel viewModel);

        bool UpdateDiscount(AdminDiscountViewModel viewModel, Guid id);

        void DeleteDiscount(Guid id);

        #endregion


        #region Report

        int WeeklyFactor(string date);

        int MonthlyFactor(string month);

        int WeeklyRegister(string date);

        int MonthlyRegister(string month);

        #endregion

        #region Transact

        Task<List<Transact>> GetTransacts();
        void DeleteTransact(Guid id);
        Task<List<TransactRate>> GetTransactRates(Guid id);

        int? WeeklyTransact(string date);

        Task<List<Transact>> LastTransact();

        Task<List<Transact>> FillTransactInProcess(string date);
        Task<List<Transact>> FillCancelTransact(string date);
        #endregion

    }
}

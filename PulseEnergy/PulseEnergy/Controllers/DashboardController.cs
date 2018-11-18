using BusinessLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PulseEnergy.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private IUserBusiness userBusiness;
        private ISpendingBusiness spendingBusiness;

        public DashboardController(IUserBusiness userBusiness, ISpendingBusiness spendingBusiness)
        {
            this.userBusiness = userBusiness;
            this.spendingBusiness = spendingBusiness;
        }

        [Route("updateUserLanguage")]
        [HttpPut]
        public bool UpdateUserLanguage([FromBody]User user)
        {
            return this.userBusiness.UpdateUserLanguage(user);
        }

        [Route("{date}/getSpendingHourDate")]
        public List<Spending> GetSpendingByHourDate(string date)
        {
            return this.spendingBusiness.GetSpendingByHourDate(date);
        }

        [Route("{date}/getSpendingSevenDaysAgo")]
        public Spending GetSpendingSevenDaysAgo(string date)
        {
            return this.spendingBusiness.GetSpendingSevenDaysAgo(date);
        }

        [Route("{date}/getSpendingByFloor")]
        public List<Spending> GetSpendingByFloor(string date)
        {
            return this.spendingBusiness.GetSpendingByFloor(date);
        }

        [Route("{date}/getMaxSpendingByDevices")]
        public List<Spending> GetMaxSpendingByDevices(string date)
        {
            return this.spendingBusiness.GetMaxSpendingByDevices(date);
        }

        [Route("updateUserCurrency")]
        [HttpPut]
        public bool UpdateUserCurrency([FromBody]User user)
        {
            return this.userBusiness.UpdateUserCurrency(user);
        }
        [Route("{minDate}/{maxDate}/getSpendingHourDateBetween")]
        public List<Spending> GetSpendingByHourDateBetween(string minDate, string maxDate)
        {
            return this.spendingBusiness.GetSpendingByHourDateBetween(minDate, maxDate);
        }
        [Route("{minDate}/{maxDate}/getSpendingByFloorBetween")]
        public List<Spending> GetSpendingByFloorBetween(string minDate, string maxDate)
        {
            return this.spendingBusiness.GetSpendingByFloorBetween(minDate, maxDate);
        }
        [Route("getSpendingByMonthlyYears")]
        public List<Spending> GetSpendingByMonthlyYears()
        {
            return this.spendingBusiness.GetSpendingByMonthlyYears();
        }
        [Route("getSpendingByYears")]
        public List<Spending> GetSpendingByYears()
        {
            return this.spendingBusiness.GetSpendingByYears();
        }
        [Route("{date}/getSpendingHour23")]
        public List<Spending> GetSpendingByHour23(string date)
        {
            return this.spendingBusiness.GetSpendingByHour23(date);
        }
        [Route("getSpendingByLatestHour")]
        public List<Spending> GetSpendingByLatestHour()
        {
            return this.spendingBusiness.GetSpendingByLatestHour();
        }
    }
}
using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SpendingBusiness : ISpendingBusiness
    {
        private ISpendingRepository spendingRepository;

        public SpendingBusiness(ISpendingRepository spendingRepository)
        {
            this.spendingRepository = spendingRepository;
        }

        public List<Spending> GetSpendingByHourDate(string date)
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByHourDate(date);
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public Spending GetSpendingSevenDaysAgo(string date)
        {
            Spending spending = this.spendingRepository.GetSpendingSevenDaysAgo(date);
            if (spending != null)
            {
                return spending;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetSpendingByFloor(string date)
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByFloor(date);
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetMaxSpendingByDevices(string date)
        {
            List<Spending> spendingList = this.spendingRepository.GetMaxSpendingByDevices(date);
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetSpendingByHourDateBetween(string minDate, string maxDate)
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByHourDateBetween(minDate, maxDate);
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetSpendingByFloorBetween(string minDate, string maxDate)
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByFloorBetween(minDate, maxDate);
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetSpendingByMonthlyYears()
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByMonthlyYears();
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetSpendingByYears()
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByYears();
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
        public List<Spending> GetSpendingByHour23(string date)
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByHourDate(date);
            if (spendingList.Count > 0)
            {
                return spendingList.Where(s => s.Hour == 23).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Spending> GetSpendingByLatestHour()
        {
            List<Spending> spendingList = this.spendingRepository.GetSpendingByLatestHour();
            if (spendingList.Count > 0)
            {
                return spendingList;
            }
            else
            {
                return null;
            }
        }
    }
}

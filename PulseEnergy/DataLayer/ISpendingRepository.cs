﻿using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface ISpendingRepository
    {
        List<Spending> GetSpendingByHourDate(string date);
        Spending GetSpendingSevenDaysAgo(string date);
        List<Spending> GetSpendingByFloor(string date);
        List<Spending> GetMaxSpendingByDevices(string date);
        List<Spending> GetSpendingByHourDateBetween(string minDate, string maxDate);
        List<Spending> GetSpendingByFloorBetween(string minDate, string maxDate);
        List<Spending> GetSpendingByMonthlyYears();
        List<Spending> GetSpendingByYears();
        List<Spending> GetSpendingByLatestHour();
    }
}
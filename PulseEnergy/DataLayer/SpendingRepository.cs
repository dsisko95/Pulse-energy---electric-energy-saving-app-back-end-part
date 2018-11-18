using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class SpendingRepository : ISpendingRepository
    {
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public List<Spending> GetSpendingByHourDate(string date)
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT CAST(DateLog as date) AS ForDate, SUM( d.SpentW * s.Quantity) AS Total, DATEPART(hour,DateLog) AS Hours FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY DATEPART(hour,DateLog), CAST(DateLog as date) HAVING CONVERT(date, DateLog) = @date";
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.DateLog = dataReader.GetDateTime(0);
                    spending.Total = dataReader.GetInt32(1);
                    spending.Hour = dataReader.GetInt32(2);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public Spending GetSpendingSevenDaysAgo(string date)
        {
            Spending spending = new Spending();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT CAST(DateLog as date) AS ForDate, SUM( d.SpentW * s.Quantity) AS Total FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY CAST(DateLog as date) HAVING CONVERT(date, DateLog) = dateadd(day,-7, @date)";
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    spending.DateLog = dataReader.GetDateTime(0);
                    spending.Total = dataReader.GetInt32(1);
                }
            }
            return spending;
        }
        public List<Spending> GetSpendingByFloor(string date)
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT CAST(DateLog as date) AS ForDate, SUM( d.SpentW * s.Quantity) AS Total, Floor FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY CAST(DateLog as date), Floor HAVING CONVERT(date, DateLog) = @date";
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.DateLog = dataReader.GetDateTime(0);
                    spending.Total = dataReader.GetInt32(1);
                    spending.Floor = dataReader.GetString(2);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public List<Spending> GetMaxSpendingByDevices(string date)
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM(SELECT CAST(DateLog as date) AS ForDate, SUM(d.SpentW * s.Quantity) AS Sum, DATEPART(hour, DateLog) AS Hours, d.Name as Name, ROW_NUMBER() OVER(PARTITION BY DATEPART(hour, DateLog) ORDER BY SUM(d.SpentW* s.Quantity) DESC) AS rowNumber FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY DATEPART(hour, DateLog), CAST(DateLog as date), Name HAVING CONVERT(date, DateLog) = @date) sub WHERE sub.rowNumber = 1 ORDER BY Hours ASC;";
                command.Parameters.AddWithValue("@date", date);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.Total = dataReader.GetInt32(1);
                    spending.Hour = dataReader.GetInt32(2);
                    spending.DeviceName = dataReader.GetString(3);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public List<Spending> GetSpendingByHourDateBetween(string minDate, string maxDate)
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT CAST(DateLog as date) AS ForDate, SUM( d.SpentW * s.Quantity) AS Total, DATEPART(hour,DateLog) AS Hours FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY DATEPART(hour,DateLog), CAST(DateLog as date) HAVING CONVERT(date, DateLog) BETWEEN @minDate AND @maxDate";
                command.Parameters.AddWithValue("@minDate", minDate);
                command.Parameters.AddWithValue("@maxDate", maxDate);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.DateLog = dataReader.GetDateTime(0);
                    spending.Total = dataReader.GetInt32(1);
                    spending.Hour = dataReader.GetInt32(2);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public List<Spending> GetSpendingByFloorBetween(string minDate, string maxDate)
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT CAST(DateLog as date) AS ForDate, SUM( d.SpentW * s.Quantity) AS Total, Floor FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY CAST(DateLog as date), Floor HAVING CONVERT(date, DateLog) BETWEEN @minDate AND @maxDate";
                command.Parameters.AddWithValue("@minDate", minDate);
                command.Parameters.AddWithValue("@maxDate", maxDate);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.DateLog = dataReader.GetDateTime(0);
                    spending.Total = dataReader.GetInt32(1);
                    spending.Floor = dataReader.GetString(2);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public List<Spending> GetSpendingByMonthlyYears()
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT SUM( d.SpentW * s.Quantity) / 1000 AS Total, DATEPART(month,DateLog) AS Months, YEAR(s.DateLog) AS Years FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY DATEPART(month,s.DateLog), YEAR(s.DateLog)  ORDER BY Months ASC";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.Total = dataReader.GetInt32(0);
                    spending.Month = dataReader.GetInt32(1);
                    spending.Year = dataReader.GetInt32(2);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public List<Spending> GetSpendingByYears()
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT SUM( d.SpentW * s.Quantity) / 1000 AS Total, YEAR(s.DateLog) AS Years FROM Spendings s INNER JOIN Devices d ON d.Id = s.Device_Id GROUP BY YEAR(s.DateLog)";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.Total = dataReader.GetInt32(0);
                    spending.Year = dataReader.GetInt32(1);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
        public List<Spending> GetSpendingByLatestHour()
        {
            List<Spending> listToReturn = new List<Spending>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT d.Name, MAX(s.Quantity) AS Quantity, d.SpentW, s.Floor FROM Spendings s INNER JOIN Devices d ON s.Device_Id = d.Id WHERE CAST(DateLog as date) = '9-9-2018' AND DATEPART(hour, DateLog) = '23' GROUP BY d.Name, d.SpentW, s.Floor ORDER BY s.Floor ASC";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Spending spending = new Spending();
                    spending.DeviceName = dataReader.GetString(0);
                    spending.Quantity = dataReader.GetInt32(1);
                    spending.Spent = dataReader.GetInt32(2);
                    spending.Floor = dataReader.GetString(3);
                    listToReturn.Add(spending);
                }
            }
            return listToReturn;
        }
    }
}
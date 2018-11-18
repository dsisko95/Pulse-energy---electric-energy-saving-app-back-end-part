using System;

namespace DataLayer.Models
{
    public class Spending
    {
        public int Id { get; set; }
        public int Company_Id { get; set; }
        public int Device_Id { get; set; }
        public string PriorityLevel { get; set; }
        public string Floor { get; set; }
        public int Quantity { get; set; }
        public DateTime DateLog { get; set; }
        public int Hour { get; set; }
        public int Total { get; set; }
        public string DeviceName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Spent { get; set; }
    }
}
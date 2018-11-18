namespace DataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public int Company_Id { get; set; }
        public string SecurityQuestion { get; set; }
        public string Company_Name { get; set; }
        public string Company_TaxNumber { get; set; }
        public string Company_Phone { get; set; }
        public string Company_IdNumber { get; set; }
        public string Company_Location { get; set; }
    }
}
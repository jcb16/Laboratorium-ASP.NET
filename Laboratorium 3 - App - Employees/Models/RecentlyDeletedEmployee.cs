namespace Laboratorium_3___App___Employees.Models
{
    public class RecentlyDeletedEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DeletedDate { get; set; }
        public string Department { get; set; }

        public RecentlyDeletedEmployee(int id, string name, string surname, DateTime deletedDate, string department)
        {
            ID = id;
            Name = name;
            Surname = surname;
            DeletedDate = deletedDate;
            Department = department;
        }
    }
}
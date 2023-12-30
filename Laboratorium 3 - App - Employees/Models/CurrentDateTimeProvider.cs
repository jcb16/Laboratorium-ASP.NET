namespace Laboratorium_3___App___Employees.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentData()
        {
            //return DateTime.Now;
            DateTime d = DateTime.Now;
            return d;
        }
    }
}

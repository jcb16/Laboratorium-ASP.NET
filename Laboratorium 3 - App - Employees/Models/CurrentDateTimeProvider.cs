namespace Laboratorium_3___App___Employees.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            //return DateTime.Now;
            DateTime d = DateTime.Now;
            return d;
        }
    }
}

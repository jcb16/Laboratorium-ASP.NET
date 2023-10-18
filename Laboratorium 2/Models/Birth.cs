namespace Laboratorium_2.Models
{
    public class Birth
    {

        public string name { get; set; }
        public DateTime? date { get; set; }

        public int CountAge()
        {
            int wiek;
            if (((DateTime)date).Month == DateTime.Now.Month) 
            {
                wiek = (((DateTime.Now.Year - 1) * 12 + DateTime.Now.Month) - ((((DateTime)date).Year - 1) * 12 + ((DateTime)date).Month)) / 12 - 1;
                if (DateTime.Now.Day >= ((DateTime)date).Day)
                {
                    wiek++;
                }
            }
            else
            {
                wiek = (((DateTime.Now.Year - 1) * 12 + DateTime.Now.Month) - ((((DateTime)date).Year - 1) * 12 + ((DateTime)date).Month)) / 12;
            }



            return wiek;
        }

        public bool IsValid()
        {
            return name != null && date != null;
        }
    }


}

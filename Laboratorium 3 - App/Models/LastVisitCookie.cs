namespace Laboratorium_3___App.Models
{
    public class LastVisitCookie
    {
        public static readonly string CookieName = "visit";
        private readonly RequestDelegate _next;

        public LastVisitCookie(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            string? cookie = context.Request.Cookies[CookieName]; 
            if(cookie == null)
            {
                //pierwsza wizyta
                context.Items.Add(CookieName, "First visit");
            }
            else
            {
                //kolejna wizyta, odczytujemy z ciastka date ostatniej wizyty
                if(DateTime.TryParse(cookie, out var date)) 
                {
                    context.Items.Add(CookieName, date);
                }
                else
                {
                    context.Items.Add(CookieName, "Can't read date from cookie!");
                }
            }
            CookieOptions options = new CookieOptions { MaxAge = new TimeSpan(400, 0,0,0) };
            context.Response.Cookies.Append(CookieName, DateTime.Now.ToString(), options);
            await _next(context);
        }
    }
}

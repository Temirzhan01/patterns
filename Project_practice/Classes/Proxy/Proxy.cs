using Project_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_practice.Classes.Proxy
{
    public class Proxy : Page
    {
        public Proxy() { }
        public bool Ischeck(string log, string pass)
        {
            using (UserContext uc = new UserContext())
            {
                string logi = uc.Users.Where(e => e.login == log && e.password == pass).Select(x => x.login).FirstOrDefault();
                if (logi?.Any() ?? false)
                {
                    RealPage realPage = new RealPage();
                    return realPage.Ischeck(log, pass);
                }
                else
                {
                    UnrealPage unrealPage = new UnrealPage();
                    return unrealPage.Ischeck(log, pass);
                }
            }
        }
    }
}

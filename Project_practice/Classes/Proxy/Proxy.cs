using Project_practice.Models;
using Microsoft.EntityFrameworkCore;
using Project_practice.Classes.Proxy;
using Project_practice.Classes.Singleton;

namespace Project_practice.Classes.Proxy
{
    public class Proxy : Page
    {
        public Proxy() { }
        public bool Ischeck(string log, string pass)
        {
            using (ApplicationContext uc = new ApplicationContext())
            {
                string logi = uc.Users.Where(e => e.login == log && e.password == pass).Select(x => x.login).FirstOrDefault();
                int id = uc.Users.Where(e => e.login == log && e.password == pass).Select(i => i.Id).FirstOrDefault();
                if (logi?.Any() ?? false)
                {
                    UserInfo.Id = id;
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

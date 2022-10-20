using Newtonsoft.Json;
using Project_practice.Classes.Factory;

namespace Project_practice.Classes.Adapter
{
    public static class Adapter
    {
        public static string Converter(Card card) 
        {
            return JsonConvert.SerializeObject(card);
        }
    }
}

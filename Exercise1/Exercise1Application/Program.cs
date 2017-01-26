using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise1;

namespace Exercise1Application
{
    class Program
    {

        static List<Card> StartCollection = new List<Card>()
        {
            new Card("London","Riga"),
            new Card("Moscow", "Kiev"),
            new Card("Berlin","Paris"),
            new Card("Paris","Tallin"),
            new Card("Prague","Vilnius"),
            new Card("Vien","St.Petersburg"),
            new Card("Minsk","Amsterdam"),
            new Card("St.Petersburg","London"),
            new Card("Varshava","Berlin"),
            new Card("Bratislava","Vien"),
            new Card("Kiev","Prague"),
            new Card("Amsterdam","Bratislava"),
            new Card("Vilnius","Varshava"),
            new Card("Tallin","Minsk")
        };
        static List<Card> FinalCollection = new List<Card>()
        {
            new Card("Moscow", "Kiev"),
            new Card("Kiev", "Prague"),
            new Card("Prague", "Vilnius"),
            new Card("Vilnius", "Varshava"),
            new Card("Varshava", "Berlin"),
            new Card("Berlin", "Paris"),
            new Card("Paris", "Tallin"),
            new Card("Tallin", "Minsk"),
            new Card("Minsk", "Amsterdam"),
            new Card("Amsterdam", "Bratislava"),
            new Card("Bratislava", "Vien"),
            new Card("Vien", "St.Petersburg"),
            new Card("St.Petersburg", "London"),
            new Card("London", "Riga")
        };

        static void Main(string[] args)
        {
            foreach (Card card in StartCollection)
            {
                Console.WriteLine(card.ToString());
            }
            List<Card> fCollection = CardUtils.Sort(StartCollection);
            Console.WriteLine();
            foreach (Card card in fCollection)
            {
                Console.WriteLine(card.ToString());
            }
            Console.ReadLine();
        }
    }
}

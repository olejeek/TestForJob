using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class Card
    {
        public string DepartCity;
        public string ArrivalCity;

        public Card(string DepartCity, string ArrivalCity)
        {
            this.DepartCity = DepartCity;
            this.ArrivalCity = ArrivalCity;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", DepartCity, ArrivalCity);
        }

        public override int GetHashCode()
        {
            return (DepartCity + ArrivalCity).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Card temp = obj as Card;
            if (temp == null) return false;
            if (DepartCity == temp.DepartCity && ArrivalCity == temp.ArrivalCity) return true;
            else return false;
        }
    }
}

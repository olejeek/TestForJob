using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public static class CardUtils
    {
        public static List<Card> Sort(List<Card> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                throw new ArgumentNullException("cards", "List is empty or null");
            }

            Dictionary<string, Card> depCities = new Dictionary<string, Card>();
            HashSet<string> arrCities = new HashSet<string>();

            foreach (Card card in cards)
            {
                AddCardInDictionary(depCities, card, card.DepartCity);
                AddCityInHashSet(arrCities, card.ArrivalCity);
            }

            List<Card> sortedList = new List<Card>();
            sortedList.Add(FindFirstCard(depCities, arrCities));

            SortedListFiller(sortedList, depCities);
            
            return sortedList;
        }

        private static void AddCardInDictionary (Dictionary<string, Card> dic, Card card, string key)
        {
            if (dic.ContainsKey(key))
            {
                throw new ArgumentException("CardDictionary: Card set have duplicate cities.");
            }
            else
            {
                dic.Add(key, card);
            }
        }

        private static void AddCityInHashSet(HashSet<string> hSet, string city)
        {
            if (hSet.Contains(city))
            {
                throw new ArgumentException("CitySet: Card set have duplicate cities.");
            }
            else
            {
                hSet.Add(city);
            }
        }
        private static Card FindFirstCard(Dictionary<string, Card> departCities, HashSet<string> arrivalCities)
        {
            Card firstCard = null;
            for (int i = 0; i < departCities.Count; i++)
            {
                string city = departCities.Keys.ElementAt(i);
                if (!arrivalCities.Contains(city))
                {
                    firstCard = departCities[city];
                    departCities.Remove(city);
                    break;
                }
            }
            if (firstCard == null)
            {
                throw new ArgumentException("Not found first Card in Collection."+
                    " May be, Card collection contains loops.");
            }
            return firstCard;
        }
        private static void SortedListFiller(List<Card> sortList, Dictionary<string, Card> departCities)
        {
            while (departCities.Count > 0)
            {
                string lastCity = sortList[sortList.Count - 1].ArrivalCity;
                Card nextCard;
                if (departCities.TryGetValue(lastCity, out nextCard))
                {
                    sortList.Add(nextCard);
                    departCities.Remove(lastCity);
                }
                else
                {
                    throw new ArgumentException("Not found next Card in Card collection."+
                        "May be there is a break in the journey.");
                }
            }
        }
    }
}

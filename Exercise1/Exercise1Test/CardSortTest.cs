using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise1;
using System.Collections.Generic;

namespace Exercise1Test
{
    [TestClass]
    public class CardSortTest
    {
        //List<string> cities = new List<string> {"Moscow", "London", "Berlin", "Paris", "Prague", "Vien",
        //    "Amsterdam", "Bratislava", "Varshava", "Kiev", "Minsk", "Riga", "Tallin", "Vilnius", "St.Petersburg"};
        List<Card> StartCollection = new List<Card>()
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
        List<Card> FinalCollection = new List<Card>()
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

        //сортировка полной коллекции
        [TestMethod]
        public void SortFullCollection()
        {
            List<Card> fCollection = CardUtils.Sort(StartCollection);
            for (int i=0; i<FinalCollection.Count; i++)
            {
                if (!fCollection[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }
            
        }

        //сортировка коллекции из одного элемента
        [TestMethod]
        public void SortOneElementCollection()
        {
            List<Card> oneElementList = new List<Card>() { new Card("Moscow", "Minsk") };
            List<Card> finalCollection = new List<Card>() { new Card("Moscow", "Minsk") };
            oneElementList = CardUtils.Sort(oneElementList);
            for (int i = 0; i < finalCollection.Count; i++)
            {
                if (!finalCollection[i].Equals(oneElementList[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }
        }

        //сортировка коллекции из нуля элементов
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortEmptyCollection()
        {
            CardUtils.Sort(new List<Card>());
        }

        //сортировка null
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortNullCollection()
        {
            CardUtils.Sort(null);
        }

        //сортировка отсортированной коллекции
        [TestMethod]
        public void SortSortedCollection()
        {
            List<Card> fCollection = CardUtils.Sort(FinalCollection);
            for (int i = 0; i < FinalCollection.Count; i++)
            {
                if (!fCollection[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }
        }

        //сортировка обратно отсортированной коллекции
        [TestMethod]
        public void SortReverseSortedCollection()
        {
            FinalCollection.Reverse();
            List<Card> fCollection = CardUtils.Sort(FinalCollection);
            FinalCollection.Reverse();
            for (int i = 0; i < FinalCollection.Count; i++)
            {
                if (!fCollection[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }
        }

        //сортировка коллекции, обратной тестовой
        [TestMethod]
        public void SortReverseStartCollection()
        {
            StartCollection.Reverse();
            List<Card> fCollection = CardUtils.Sort(StartCollection);
            for (int i = 0; i < FinalCollection.Count; i++)
            {
                if (!fCollection[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }
        }

        //сортировка коллекции в обратном направлении
        [TestMethod]
        public void SortReverseFinalCollection()
        {
            FinalCollection.Reverse();
            for (int i = 0; i < FinalCollection.Count; i++)
            {
                string temp = FinalCollection[i].ArrivalCity;
                FinalCollection[i].ArrivalCity = FinalCollection[i].DepartCity;
                FinalCollection[i].DepartCity = temp;
            }

            for (int i = 0; i < StartCollection.Count; i++)
            {
                string temp = StartCollection[i].ArrivalCity;
                StartCollection[i].ArrivalCity = StartCollection[i].DepartCity;
                StartCollection[i].DepartCity = temp;
            }
            List<Card> fColletion = CardUtils.Sort(StartCollection);
            for (int i = 0; i < fColletion.Count; i++)
            {
                if (!fColletion[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection!");
                }
            }
        }

        //сортировка коллекции без первой карты
        [TestMethod]
        public void SortCollectionWithoutFirstCard()
        {
            StartCollection.RemoveAt(1);
            FinalCollection.RemoveAt(0);
            List<Card> fCollection = CardUtils.Sort(StartCollection);
            for (int i = 0; i < FinalCollection.Count; i++)
            {
                if (!fCollection[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }

        }

        //сортировка коллекции без последней карты
        [TestMethod]
        public void SortCollectionWithoutLastCard()
        {
            StartCollection.RemoveAt(0);
            FinalCollection.RemoveAt(FinalCollection.Count-1);
            List<Card> fCollection = CardUtils.Sort(StartCollection);
            for (int i = 0; i < FinalCollection.Count; i++)
            {
                if (!fCollection[i].Equals(FinalCollection[i]))
                {
                    Assert.Fail("Wrong sort collection");
                }
            }

        }

        //сортировка коллекции без какой-либо карты
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortCollectionWithoutAnyCard()
        {
            StartCollection.RemoveAt(10);
            FinalCollection.RemoveAt(1);
            List<Card> fColletion = CardUtils.Sort(StartCollection);

        }

        //сортировка коллекции в виде кольца
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortLoopCollection()
        {
            StartCollection[1] = new Card("Riga", "Kiev");
            List<Card> fColletion = CardUtils.Sort(StartCollection);

        }

        //сортировка коллекции с кольцом
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortCollectionWithLoop()
        {
            StartCollection[0] = new Card("London", "Amsterdam");
            List<Card> fColletion = CardUtils.Sort(StartCollection);

        }

        //сортировка коллекции с ответвлениями
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortCollectionWithForks()
        {
            StartCollection[13] = new Card("Paris", "Riga");
            List<Card> fColletion = CardUtils.Sort(StartCollection);

        }

    }
}

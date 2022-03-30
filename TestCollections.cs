using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenth_Laboratory;

namespace Eleventh_Laboratory
{
    public class TestCollections
    {
        Stopwatch stopWatch = new Stopwatch();
        public List<Region> firstCollection = new List<Region>();
        public List<string> secondCollection = new List<string>();
        public SortedDictionary<Place, Region> thirdCollection = new SortedDictionary<Place, Region>();
        public SortedDictionary<string, Region> fourthCollection = new SortedDictionary<string, Region>();

        public TestCollections(bool make)
        {
            if (make == true)
                for (int i = 0; i < 1000; i++)
                {
                    Region region = new Region();
                    region.Init();
                    firstCollection.Add(region);
                    secondCollection.Add(region.ToString());
                    thirdCollection.Add(region.BasePlace, region);
                    fourthCollection.Add(region.BasePlace.ToString(), region);
                }
        }

        public void Show()
        {
            foreach (Region place in firstCollection)
            {
                Console.WriteLine("(firstCollection) " + place);
            }
            foreach (String place in secondCollection)
            {
                Console.WriteLine("(secondCollection) " +  place);
            }
            foreach (KeyValuePair<Place, Region> place in thirdCollection)
            {
                Console.WriteLine($"(thirdCollection) (Ключ) {place.Key} (Значение) {place.Value}.");
            }
            foreach (KeyValuePair<string, Region> place in fourthCollection)
            {
                Console.WriteLine($"(fourthCollection) (Ключ) {place.Key} (Значение) {place.Value}.");
            }
        }

        public void Add(Region region)
        {
            firstCollection.Add(region);
            secondCollection.Add(region.ToString());
            thirdCollection.Add(region.BasePlace, region);
            fourthCollection.Add(region.BasePlace.ToString(), region);
        }

        public void Delete(Region region)
        {
            firstCollection.Remove(region);
            secondCollection.Remove(region.ToString());
            thirdCollection.Remove(region);
            fourthCollection.Remove(region.ToString());
        }

        public void Find(Region region, string type)
        {
            stopWatch.Start();
            if (firstCollection.Contains(region))
            {
                stopWatch.Stop();
                Console.WriteLine($"Время на поиск {type} элемента в List<Region> = {stopWatch.ElapsedTicks}.");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"На поиск {type} элемента в List<Region> было затрачено {stopWatch.ElapsedTicks}, но он не был найден.");
            }

            stopWatch.Restart();
            if (secondCollection.Contains(region.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine($"Время на поиск {type} элемента в List<string> = {stopWatch.ElapsedTicks}.");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"На поиск {type} элемента в List<string> было затрачено {stopWatch.ElapsedTicks}, но он не был найден.");
            }

            stopWatch.Restart();
            if (thirdCollection.ContainsKey(region.BasePlace))
            {
                stopWatch.Stop();
                Console.WriteLine($"Время на поиск {type} элемента по ключу в SortedDictionary<Place, Region> = {stopWatch.ElapsedTicks}.");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"На поиск {type} элемента по ключу в SortedDictionary<Place, Region> было затрачено {stopWatch.ElapsedTicks}, но он не был найден.");
            }

            stopWatch.Restart();
            if (thirdCollection.ContainsValue(region))
            {
                stopWatch.Stop();
                Console.WriteLine($"Время на поиск {type} элемента по значению в SortedDictionary<Place, Region> = {stopWatch.ElapsedTicks}.");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"На поиск {type} элемента по значению в SortedDictionary<Place, Region> было затрачено {stopWatch.ElapsedTicks}, но он не был найден.");
            }

            stopWatch.Restart();
            if (fourthCollection.ContainsKey(region.BasePlace.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine($"Время на поиск {type} элемента по ключу в SortedDictionary<string, Region> = {stopWatch.ElapsedTicks}.");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"На поиск {type} элемента по ключу в SortedDictionary<string, Region> было затрачено {stopWatch.ElapsedTicks}, но он не был найден.");
            }

            stopWatch.Restart();
            if (fourthCollection.ContainsValue(region))
            {
                stopWatch.Stop();
                Console.WriteLine($"Время на поиск {type} элемента по значению в SortedDictionary<string, Region> = {stopWatch.ElapsedTicks}.");
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine($"На поиск {type} элемента по значаению в SortedDictionary<string, Region> было затрачено {stopWatch.ElapsedTicks}, но он не был найден.");
            }
            Console.WriteLine();
        }
    }
}
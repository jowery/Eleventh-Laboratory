using System;
using Tenth_Laboratory;
using System.Collections;
using System.Collections.Generic;

namespace Eleventh_Laboratory
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int amount = 0, amountDictionary = 0, choice = 0, classType, elementsCount = 0, regionsCount = 0,regionsCountDictionary = 0, metropolisesCount = 0, metropolisesCountDictionary = 0, select, searchResult = 0;
            bool exist = false, discrepancy = true, check = false, checkSmall = false, ok = false;
            object toFind = new object();
            Region toAdd = new Region();
            Region toDelete = new Region();
            ArrayList places = new ArrayList();
            ArrayList shallowCopyPlaces = new ArrayList();
            ArrayList clonePlaces = new ArrayList();
            Dictionary<int, Place> placesDictionary = new Dictionary<int, Place>();
            Dictionary<int, Place> shallowCopyPlacesDictionary = new Dictionary<int, Place>();
            Dictionary<int, Place> clonePlacesDictionary = new Dictionary<int, Place>();
            TestCollections testCollections = new TestCollections(false);
            while (choice != 25)
            {
                Menu.ShowOptions();
                choice = Menu.InputAndValidateIntNumber(1, 25, "Выберите пункт меню:");
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        if (amount < 1)
                        {
                            amount = Menu.InputAndValidateIntNumber(1, int.MaxValue, "Введите количество элементов коллекции ArrayList:");
                            Console.WriteLine();
                            if (amount > 0)
                            {
                                Console.WriteLine("Создать коллекцию ArrayList объектов классов \"Место\", \"Область\", \"Город\", \"Мегаполис\", \"Адрес\" с:\n1) случайными элементами\n2) с вводом элементов\n");
                                do
                                {
                                    select = Menu.InputAndValidateIntNumber(1, 2, "Выберите пункт меню:");
                                    Console.WriteLine();
                                    if (select == 1)
                                    {
                                        check = true;
                                        places.Capacity = amount;
                                        for (int i = 0; i < places.Capacity; i++)
                                        {
                                            int num = random.Next(5);
                                            switch (num)
                                            {
                                                case 0:
                                                    places.Add(new Place());
                                                    ((Place)places[i]).Init();
                                                    Console.WriteLine("Создано место:");
                                                    ((Place)places[i]).VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    break;
                                                case 1:
                                                    places.Add(new Region());
                                                    ((Region)places[i]).Init();
                                                    Console.WriteLine("Создана область:");
                                                    ((Region)places[i]).VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    regionsCount++;
                                                    break;
                                                case 2:
                                                    places.Add(new City());
                                                    ((City)places[i]).Init();
                                                    Console.WriteLine("Создан город:");
                                                    ((City)places[i]).VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    break;
                                                case 3:
                                                    places.Add(new Metropolis());
                                                    ((Metropolis)places[i]).Init();
                                                    Console.WriteLine("Создан мегаполис:");
                                                    ((Metropolis)places[i]).VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    metropolisesCount++;
                                                    break;
                                                case 4:
                                                    places.Add(new Address());
                                                    ((Address)places[i]).Init();
                                                    Console.WriteLine("Создан адрес:");
                                                    ((Address)places[i]).VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    break;
                                            }
                                        }
                                    }
                                    else if (select == 2)
                                    {
                                        check = true;
                                        places.Capacity = amount;
                                        for (int i = 0; i < places.Capacity; i++)
                                        {
                                            do
                                            {
                                                int num = Menu.InputAndValidateIntNumber(1, 5, "Чем будет являться объект коллекции ArrayList?\n1) Местом.\n2) Областью.\n3) Городом.\n4) Мегаполисом.\n5) Адресом.\n");
                                                switch (num)
                                                {
                                                    case 1:
                                                        checkSmall = true;
                                                        places.Add(new Place(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод.")));
                                                        ((Place)places[i]).VirtualShow();
                                                        Console.WriteLine();
                                                        break;
                                                    case 2:
                                                        checkSmall = true;
                                                        places.Add(new Region(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название области:"), Menu.InputIntNumber("Введите количество городов:", "Неверный ввод.")));
                                                        ((Region)places[i]).VirtualShow();
                                                        Console.WriteLine();
                                                        regionsCount++;
                                                        break;
                                                    case 3:
                                                        checkSmall = true;
                                                        places.Add(new City(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название города:"), Menu.InputIntNumber("Введите население города:", "Неверный ввод.")));
                                                        ((City)places[i]).VirtualShow();
                                                        Console.WriteLine();
                                                        break;
                                                    case 4:
                                                        checkSmall = true;
                                                        places.Add(new Metropolis(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название мегаполиса:"), Menu.InputIntNumber("Введите население мегаполиса:", "Неверный ввод."), Menu.InputDoubleNumber("Введите площадь мегаполиса:", "Неверный ввод.")));
                                                        ((Metropolis)places[i]).VirtualShow();
                                                        Console.WriteLine();
                                                        metropolisesCount++;
                                                        break;
                                                    case 5:
                                                        checkSmall = true;
                                                        places.Add(new Address(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название улицы:"), Menu.InputIntNumber("Введите номер дома:", "Неверный ввод.")));
                                                        ((Address)places[i]).VirtualShow();
                                                        Console.WriteLine();
                                                        break;
                                                }
                                            } while (checkSmall == false);
                                        }
                                    }
                                } while (check == false);
                            }
                            else
                            {
                                Console.WriteLine("В коллекции ArrayList базовой иерархии должен быть минимум один объект.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы уже создали коллекцию ArrayList.");
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        if (places.Count > 0)
                        {
                            foreach (Place place in places)
                            {
                                place.VirtualShow();
                                Console.WriteLine("--------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        if (places.Count > 0)
                        {
                            int num = Menu.InputAndValidateIntNumber(1, 5, "Добавить в коллекцию ArrayList: \n1) место\n2) область\n3) город\n4) мегаполис\n5) адрес\n");
                            switch (num)
                            {
                                case 1:
                                    places.Add(new Place());
                                    ((Place)places[places.Count-1]).Init();
                                    Console.WriteLine("Создано место:");
                                    ((Place)places[places.Count - 1]).VirtualShow();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    places.Add(new Region());
                                    ((Region)places[places.Count - 1]).Init();
                                    Console.WriteLine("Создана область:");
                                    ((Region)places[places.Count - 1]).VirtualShow();
                                    Console.WriteLine();
                                    regionsCount++;
                                    break;
                                case 3:
                                    places.Add(new City());
                                    ((City)places[places.Count - 1]).Init();
                                    Console.WriteLine("Создан город:");
                                    ((City)places[places.Count - 1]).VirtualShow();
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    places.Add(new Metropolis());
                                    ((Metropolis)places[places.Count - 1]).Init();
                                    Console.WriteLine("Создан мегаполис:");
                                    ((Metropolis)places[places.Count - 1]).VirtualShow();
                                    Console.WriteLine();
                                    metropolisesCount++;
                                    break;
                                case 5:
                                    places.Add(new Address());
                                    ((Address)places[places.Count - 1]).Init();
                                    Console.WriteLine("Создан адрес:");
                                    ((Address)places[places.Count - 1]).VirtualShow();
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        if (places.Count > 0)
                        {
                            int num = Menu.InputAndValidateIntNumber(1, places.Count, "Введите номер объекта, который хотите удалить:");
                            if (num <= places.Count & num >= 1)
                                places.RemoveAt(num - 1);
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        if (places.Count > 0)
                        {
                            if (regionsCount > 0)
                            {
                                String input = Menu.InputString("Введите название области:");
                                Console.WriteLine();
                                foreach (Place place in places)
                                {
                                    if (place is Region)
                                    {
                                        if (((Region)place).Name == input)
                                        {
                                            discrepancy = false;
                                            foreach (City city in ((Region)place).Cities)
                                                Console.Write(city.Name + " ");
                                        }
                                    }
                                }
                                Console.WriteLine();
                                if (discrepancy == true)
                                {
                                    Console.WriteLine("Не найдено указанной области.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не было создано ни одной области.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 6:
                        int sum = 0;
                        if (places.Count > 0)
                        {
                            if (regionsCount > 0)
                            {
                                String input = Menu.InputString("Введите название области:");
                                Console.WriteLine();
                                foreach (Place place in places)
                                {
                                    if (place is Region)
                                    {
                                        if (((Region)place).Name == input)
                                        {
                                            discrepancy = false;
                                            foreach (City city in ((Region)place).Cities)
                                                sum += city.Population;
                                        }
                                    }
                                }
                                Console.WriteLine();
                                if (discrepancy == true)
                                {
                                    Console.WriteLine("Не найдено указанной области.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine($"{sum} общее количество жителей в {input}.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не было создано ни одной области.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 7:
                        double s = 0;
                        if (places.Count > 0)
                        {
                            if (metropolisesCount > 0)
                            {
                                Console.WriteLine();
                                foreach (Place place in places)
                                {
                                    if (place is Metropolis)
                                    {
                                        discrepancy = false;
                                        s += ((Metropolis)place).Square;
                                    }
                                }
                                Console.WriteLine();
                                if (discrepancy == true)
                                {
                                    Console.WriteLine("Не ни одного мегаполиса.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine($"Средняя площадь мегаполисов = {s / metropolisesCount}.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не было создано ни одного мегаполиса.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 8:
                        if (places.Count > 0)
                        {
                            shallowCopyPlaces = (ArrayList)places.Clone();
                            Console.WriteLine("Поверхностное копирование:");
                            foreach(Place place in shallowCopyPlaces)
                                Console.WriteLine(place);
                            Console.WriteLine();
                            foreach (Place place in places)
                            {
                                Place copy = (Place)place.Clone();
                                clonePlaces.Add(copy);
                            }
                            Console.WriteLine("Клонирование:");
                            foreach (Place place in clonePlaces)
                                Console.WriteLine(place);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 9:
                        if (places.Count > 0)
                        {
                            do
                            {
                                classType = Menu.InputAndValidateIntNumber(1, 5, "Выберите класс объекта, который вы хотите найти:\n1) Место.\n2) Область.\n3) Город.\n4) Мегаполис.\n5) Адрес.");
                                Console.WriteLine();
                                switch (classType)
                                {
                                    case 1:
                                        ok = true;
                                        toFind = new Place(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 2:
                                        ok = true;
                                        toFind = new Region(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название области:"), Menu.InputIntNumber("Введите количество городов:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        ok = true;
                                        toFind = new City(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название города:"), Menu.InputIntNumber("Введите население города:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 4:
                                        ok = true;
                                        toFind = new Metropolis(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название мегаполиса:"), Menu.InputIntNumber("Введите население мегаполиса:", "Неверный ввод."), Menu.InputDoubleNumber("Введите площадь мегаполиса:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 5:
                                        ok = true;
                                        toFind = new Address(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название улицы:"), Menu.InputIntNumber("Введите номер дома:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                }
                            } while (ok == false);
                            ok = false;
                            places.Sort();
                            searchResult = places.BinarySearch(toFind);
                            if (searchResult >= 0 & classType > 0 & classType < 6)
                            {
                                Console.WriteLine($"Искомый элемент находится на {searchResult + 1} позиции.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($"Искомый элемент отсутствует в массиве.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция ArrayList не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 10:
                        if (amountDictionary < 1)
                        {
                            amountDictionary = Menu.InputAndValidateIntNumber(1, int.MaxValue, "Введите количество элементов обобщенной коллекции ArrayList:");
                            Console.WriteLine();
                            if (amountDictionary > 0)
                            {
                                Console.WriteLine("Создать обобщенную коллекцию Dictionary<K,T> объектов классов \"Место\", \"Область\", \"Город\", \"Мегаполис\", \"Адрес\" с:\n1) случайными элементами\n2) с вводом элементов\n");
                                do
                                {
                                    select = Menu.InputAndValidateIntNumber(1, 2, "Выберите пункт меню:");
                                    Console.WriteLine();
                                    if (select == 1)
                                    {
                                        check = true;
                                        for (int i = 0; i < amountDictionary; i++)
                                        {
                                            int num = random.Next(5);
                                            switch (num)
                                            {
                                                case 0:
                                                    placesDictionary.Add(i + 1, new Place());
                                                    placesDictionary[i + 1].Init();
                                                    Console.WriteLine("Создано место:");
                                                    placesDictionary[i + 1].VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    elementsCount++;
                                                    break;
                                                case 1:
                                                    placesDictionary.Add(i + 1, new Region());
                                                    placesDictionary[i + 1].Init();
                                                    Console.WriteLine("Создана область:");
                                                    placesDictionary[i + 1].VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    regionsCount++;
                                                    elementsCount++;
                                                    break;
                                                case 2:
                                                    placesDictionary.Add(i + 1, new City());
                                                    placesDictionary[i + 1].Init();
                                                    Console.WriteLine("Создан город:");
                                                    placesDictionary[i + 1].VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    elementsCount++;
                                                    break;
                                                case 3:
                                                    placesDictionary.Add(i + 1, new Metropolis());
                                                    placesDictionary[i + 1].Init();
                                                    Console.WriteLine("Создан мегаполис:");
                                                    placesDictionary[i + 1].VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    metropolisesCountDictionary++;
                                                    elementsCount++;
                                                    break;
                                                case 4:
                                                    placesDictionary.Add(i + 1, new Address());
                                                    placesDictionary[i + 1].Init();
                                                    Console.WriteLine("Создан адрес:");
                                                    placesDictionary[i + 1].VirtualShow();
                                                    Console.WriteLine("--------------------");
                                                    elementsCount++;
                                                    break;
                                            }
                                        }
                                    }
                                    else if (select == 2)
                                    {
                                        check = true;
                                        for (int i = 0; i < amountDictionary; i++)
                                        {
                                            do
                                            {
                                                int num = Menu.InputAndValidateIntNumber(1, 5, "Чем будет являться объект обобщенной коллекции Dictionary<K,T>?\n1) Местом.\n2) Областью.\n3) Городом.\n4) Мегаполисом.\n5) Адресом.\n");
                                                switch (num)
                                                {
                                                    case 1:
                                                        checkSmall = true;
                                                        placesDictionary.Add(i + 1, new Place(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод.")));
                                                        placesDictionary[i + 1].VirtualShow();
                                                        Console.WriteLine();
                                                        elementsCount++;
                                                        break;
                                                    case 2:
                                                        checkSmall = true;
                                                        placesDictionary.Add(i + 1, new Region(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название области:"), Menu.InputIntNumber("Введите количество городов:", "Неверный ввод.")));
                                                        ((Region)placesDictionary[i + 1]).VirtualShow();
                                                        Console.WriteLine();
                                                        regionsCountDictionary++;
                                                        elementsCount++;
                                                        break;
                                                    case 3:
                                                        checkSmall = true;
                                                        placesDictionary.Add(i + 1, new City(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название города:"), Menu.InputIntNumber("Введите население города:", "Неверный ввод.")));
                                                        ((City)placesDictionary[i + 1]).VirtualShow();
                                                        Console.WriteLine();
                                                        elementsCount++;
                                                        break;
                                                    case 4:
                                                        checkSmall = true;
                                                        placesDictionary.Add(i + 1, new Metropolis(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название мегаполиса:"), Menu.InputIntNumber("Введите население мегаполиса:", "Неверный ввод."), Menu.InputDoubleNumber("Введите площадь мегаполиса:", "Неверный ввод.")));
                                                        ((Metropolis)placesDictionary[i + 1]).VirtualShow();
                                                        Console.WriteLine();
                                                        metropolisesCountDictionary++;
                                                        elementsCount++;
                                                        break;
                                                    case 5:
                                                        checkSmall = true;
                                                        placesDictionary.Add(i + 1, new Address(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название улицы:"), Menu.InputIntNumber("Введите номер дома:", "Неверный ввод.")));
                                                        ((Address)placesDictionary[i + 1]).VirtualShow();
                                                        Console.WriteLine();
                                                        elementsCount++;
                                                        break;
                                                }
                                            } while (checkSmall == false);
                                        }
                                    }
                                } while (check == false);
                            }
                            else
                            {
                                Console.WriteLine("В обобщенной коллекции Dictionary<K,T> должен быть минимум один объект.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы уже создали обобщенную коллекцию Dictionary<K,T>.");
                            Console.WriteLine();
                        }
                        break;
                    case 11:
                        if (placesDictionary.Count > 0)
                        {
                            foreach (KeyValuePair<int, Place> place in placesDictionary)
                            {
                                Console.WriteLine($"Ключ: {place.Key}, Значение: {place.Value}.");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 12:
                        if (placesDictionary.Count > 0)
                        {
                            int num = Menu.InputAndValidateIntNumber(1, 5, "Добавить в обобщенную коллекцию Dictionary<K,T>: \n1) место\n2) область\n3) город\n4) мегаполис\n5) адрес\n");
                            switch (num)
                            {
                                case 1:
                                    elementsCount++;
                                    placesDictionary.Add(elementsCount, new Place());
                                    placesDictionary[placesDictionary.Count].Init();
                                    Console.WriteLine("Создано место:");
                                    placesDictionary[placesDictionary.Count].VirtualShow();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    elementsCount++;
                                    placesDictionary.Add(elementsCount, new Region());
                                    ((Region)placesDictionary[placesDictionary.Count]).Init();
                                    Console.WriteLine("Создана область:");
                                    ((Region)placesDictionary[placesDictionary.Count]).VirtualShow();
                                    Console.WriteLine();
                                    regionsCountDictionary++;
                                    break;
                                case 3:
                                    elementsCount++;
                                    placesDictionary.Add(elementsCount, new City());
                                    ((City)placesDictionary[placesDictionary.Count]).Init();
                                    Console.WriteLine("Создан город:");
                                    ((City)placesDictionary[placesDictionary.Count]).VirtualShow();
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    elementsCount++;
                                    placesDictionary.Add(elementsCount, new Metropolis());
                                    ((Metropolis)placesDictionary[placesDictionary.Count]).Init();
                                    Console.WriteLine("Создан мегаполис:");
                                    ((Metropolis)placesDictionary[placesDictionary.Count]).VirtualShow();
                                    Console.WriteLine();
                                    metropolisesCountDictionary++;
                                    break;
                                case 5:
                                    elementsCount++;
                                    placesDictionary.Add(elementsCount, new Address());
                                    ((Address)placesDictionary[placesDictionary.Count]).Init();
                                    Console.WriteLine("Создан адрес:");
                                    ((Address)placesDictionary[placesDictionary.Count]).VirtualShow();
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 13:
                        if (placesDictionary.Count > 0)
                        {
                            int num = Menu.InputAndValidateIntNumber(1, placesDictionary.Count, "Введите ключ объекта, который хотите удалить:");
                            if (num <= placesDictionary.Count & num >= 1)
                            {
                                placesDictionary.Remove(num);
                                elementsCount--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 14:
                        if (placesDictionary.Count > 0)
                        {
                            if (regionsCountDictionary > 0)
                            {
                                String input = Menu.InputString("Введите название области:");
                                Console.WriteLine();
                                foreach (KeyValuePair<int, Place> place in placesDictionary)
                                {
                                    if (place.Value is Region)
                                    {
                                        if (((Region)place.Value).Name == input)
                                        {
                                            discrepancy = false;
                                            foreach (City city in ((Region)place.Value).Cities)
                                                Console.Write(city.Name + " ");
                                        }
                                    }
                                }
                                Console.WriteLine();
                                if (discrepancy == true)
                                {
                                    Console.WriteLine("Не найдено указанной области.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не было создано ни одной области.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 15:
                        int sumDictionary = 0;
                        if (placesDictionary.Count > 0)
                        {
                            if (regionsCountDictionary > 0)
                            {
                                String input = Menu.InputString("Введите название области:");
                                Console.WriteLine();
                                foreach (KeyValuePair<int, Place> place in placesDictionary)
                                {
                                    if (place.Value is Region)
                                    {
                                        if (((Region)place.Value).Name == input)
                                        {
                                            discrepancy = false;
                                            foreach (City city in ((Region)place.Value).Cities)
                                                sumDictionary += city.Population;
                                        }
                                    }
                                }
                                Console.WriteLine();
                                if (discrepancy == true)
                                {
                                    Console.WriteLine("Не найдено указанной области.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine($"{sumDictionary} общее количество жителей в {input}.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не было создано ни одной области.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 16:
                        double sDictionary = 0;
                        if (placesDictionary.Count > 0)
                        {
                            if (metropolisesCountDictionary > 0)
                            {
                                Console.WriteLine();
                                foreach (KeyValuePair<int, Place> place in placesDictionary)
                                {
                                    if (place.Value is Metropolis)
                                    {
                                        discrepancy = false;
                                        sDictionary += ((Metropolis)place.Value).Square;
                                    }
                                }
                                Console.WriteLine();
                                if (discrepancy == true)
                                {
                                    Console.WriteLine("Не ни одного мегаполиса.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine($"Средняя площадь мегаполисов = {sDictionary / metropolisesCountDictionary}.");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не было создано ни одного мегаполиса.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 17:
                        if (placesDictionary.Count > 0)
                        {
                            foreach (KeyValuePair<int, Place> place in placesDictionary)
                            {
                                Place copy = (Place)place.Value.ShallowCopy();
                                shallowCopyPlacesDictionary.Add(place.Key, copy);
                            }
                            Console.WriteLine("Поверхностное копирование:");
                            foreach (KeyValuePair<int, Place> place in shallowCopyPlacesDictionary)
                                Console.WriteLine($"Ключ: {place.Key}, Значение: {place.Value}.");
                            Console.WriteLine();
                            foreach (KeyValuePair<int, Place> place in placesDictionary)
                            {
                                Place copy = (Place)place.Value.Clone();
                                shallowCopyPlacesDictionary.Add(place.Key, copy);
                            }
                            Console.WriteLine("Клонирование:");
                            foreach (KeyValuePair<int, Place> place in clonePlacesDictionary)
                                Console.WriteLine($"Ключ: {place.Key}, Значение: {place.Value}.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 18:
                        if (placesDictionary.Count > 0)
                        {
                            do
                            {
                                classType = Menu.InputAndValidateIntNumber(1, 5, "Выберите класс объекта, который вы хотите найти:\n1) Место.\n2) Область.\n3) Город.\n4) Мегаполис.\n5) Адрес.");
                                Console.WriteLine();
                                switch (classType)
                                {
                                    case 1:
                                        ok = true;
                                        toFind = new Place(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 2:
                                        ok = true;
                                        toFind = new Region(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название области:"), Menu.InputIntNumber("Введите количество городов:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        ok = true;
                                        toFind = new City(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название города:"), Menu.InputIntNumber("Введите население города:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 4:
                                        ok = true;
                                        toFind = new Metropolis(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название мегаполиса:"), Menu.InputIntNumber("Введите население мегаполиса:", "Неверный ввод."), Menu.InputDoubleNumber("Введите площадь мегаполиса:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                    case 5:
                                        ok = true;
                                        toFind = new Address(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название улицы:"), Menu.InputIntNumber("Введите номер дома:", "Неверный ввод."));
                                        Console.WriteLine();
                                        break;
                                }
                            } while (ok == false);
                            ok = false;
                            foreach (KeyValuePair<int, Place> place in placesDictionary)
                                if (place.Value.Equals(toFind))
                                    searchResult = place.Key;
                            if (searchResult >= 0 & classType > 0 & classType < 6)
                            {
                                Console.WriteLine($"Искомый элемент находится на {searchResult} позиции.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($"Искомый элемент отсутствует в обобщенной коллекции Dictionary<K,T>.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обобщенная коллекция Dictionary<K,T> не сформирована.");
                            Console.WriteLine();
                        }
                        break;
                    case 19:
                        if (!exist)
                        {
                            testCollections = new TestCollections(true);
                            testCollections.Show();
                            exist = true;
                        }
                        else
                        {
                            Console.WriteLine("Объект коллекции TestCollections не инициализирован.");
                            Console.WriteLine();
                        }
                        break;
                    case 20:
                        if (exist)
                            testCollections.Show();
                        else
                        {
                            Console.WriteLine("Объект коллекции TestCollections не инициализирован.");
                            Console.WriteLine();
                        }
                        break;
                    case 21:
                        if (exist)
                        {
                            toAdd.Init();
                            testCollections.Add(toAdd);
                        }
                        else
                        {
                            Console.WriteLine("Объект коллекции TestCollections не инициализирован.");
                            Console.WriteLine();
                        }
                        break;
                    case 22:
                        if (exist)
                        {
                            toDelete = new Region(Menu.InputDoubleNumber("Введите координату по оси x:", "Неверный ввод."), Menu.InputDoubleNumber("Введите координату по оси y:", "Неверный ввод."), Menu.InputString("Введите название области:"), Menu.InputIntNumber("Введите количество городов:", "Неверный ввод."));
                            testCollections.Delete(toDelete);
                        }
                        else
                        {
                            Console.WriteLine("Объект коллекции TestCollections не инициализирован.");
                            Console.WriteLine();
                        }
                        break;
                    case 23:
                        if (exist)
                        {
                            Region first = (Region)testCollections.firstCollection[0].Clone();
                            Region middle = (Region)testCollections.firstCollection[499].Clone();
                            Region last = (Region)testCollections.firstCollection[999].Clone();
                            Region unknown = new Region(0, 0, "Неизвестный", 1);
                            testCollections.Find(first, "первого");
                            Console.WriteLine();
                            testCollections.Find(middle, "среднего");
                            Console.WriteLine();
                            testCollections.Find(last, "последнего");
                            Console.WriteLine();
                            testCollections.Find(unknown, "неизвестного");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Объект коллекции TestCollections не инициализирован.");
                            Console.WriteLine();
                        } 
                        break;
                    case 24:
                        Console.Clear();
                        break;
                    case 25:
                        break;
                }
            }
        }
    }
}
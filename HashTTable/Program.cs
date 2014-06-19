using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTTable
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            MyHash<string> ht = new MyHash<string>(901);
            int index, key, keyDel;
            string elToAdd, elToDel;

            //Заполнение хэш-таблицы
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nPlease, enter a key and an element to ADD");
                key = int.Parse(Console.ReadLine());
                elToAdd = Console.ReadLine();
                index = ht.AddHash(key, elToAdd);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Index is " + index);
                Console.WriteLine("Size is {0}", ht.Size);
            } while (key != 777);

            //Проверка методов поиска
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEnter a key to FIND ITS VALUE");
                key = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Red;
                ht.PrintHashList(key);
            } while (key != 777);

            //Удаление элементов из таблицы
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEnter a key and a value to DELETE an element");
                keyDel = int.Parse(Console.ReadLine());
                elToDel = Console.ReadLine();

                ht.Delete(keyDel, elToDel);
            } while (keyDel != 777);

            //Поиск с учетом удалений
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEnter a key to FIND ITS VALUE");
                key = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Red;
                ht.PrintHashList(key);
                Console.WriteLine("Size is {0}", ht.Size);
            } while (key != 777);

            Console.ReadLine();
        }
    }
}

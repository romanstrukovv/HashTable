using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTTable
{
    public struct THashItem<T> where T : IComparable //структура элемента в хэш-таблице
    {
        public int i;
        public MyList<T> hashList;

    }

    public class MyHash<Tval> where Tval : IComparable
    {
        public int sizeTable; // размер хэш-таблицы
        //static int step = 37; // сдвиг в случае коллизии
        int size; //количество элементов в таблице
        public THashItem<Tval>[] h;


        //Конструктор с установкой размера таблицы
        public MyHash(int sizeTable)
        {
            this.sizeTable = sizeTable;
            this.h = new THashItem<Tval>[sizeTable];
            HashInit();
        }


        #region Вспомогательные методы и свойства

        /*  void ClearVisit()
        {
            for (int i = 0; i < h.Length; i++)
                h[i].visit = true;
        }*/
        /*  protected int CompareTo(object obj, int i)
          {
              return this.h[i].key.CompareTo(obj);
          }*/
        /*  /// <summary>
          /// Инициализация хэш-таблицы
          /// </summary>
          public void HashInit()
          {
              size = 0;
              for (int i = 0; i < sizeTable; i++)
              {

                  this.h[i].hashList. = true;                
              }
          }*/
        /*/// <summary>
       /// Инициализация хэш-таблицы
       /// </summary>
       void HashInit()
       {
           for (int i = 0; i < h.Length; i++)
           {
               for (int j = 0; j < h[i].hashList.Count - 1; j++)
               {
                   h[i].hashList[j].empty = true;
               }
           }
       }*/


        /// <summary>
        /// Формирование индекса элемента по ключу (хэш-функция)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int HashKey(int key)
        {
            int result = 0;

            for (int i = 0; i < key.ToString().Length; i++)
            {
                result += key.ToString()[i] * i;
                result %= sizeTable;
            }
            return result;
        }

        /// <summary>
        /// Инициализация хэш-таблицы
        /// </summary>
        void HashInit()
        {
            for (int i = 0; i < h.Length; i++)
            {
                h[i].hashList = new MyList<Tval>();
            }
        }

        /// <summary>
        /// Количество элементов в хэш-таблице
        /// </summary>
        public int Size
        {
            get { return this.size; }
        }

        /// <summary>
        /// Размер хэш-таблицы
        /// </summary>
        public int SizeTable
        {
            get { return this.sizeTable; }
        }

        #endregion

        #region Основные методы

        /// <summary>
        /// Добавление элемента по "ключ-значение"
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int AddHash(int key, Tval val)
        {

            int index = -1;
            if (size != sizeTable - 1)
            {
                index = HashKey(key);
                /* if (h[index].empty)
                 {
                     h[index].empty = false;
                     h[index].visit = true;
                     h[index].val = val;
                     h[index].key = key;
                     size++;
                     return index;
                 }*/

                /*index = (index + step) % sizeTable;
                while (!h[index].empty)
                    index = (index + step) % sizeTable;*/
                h[index].hashList.Add(key, val);
                size++;
                return index;
            }
            else throw new Exception("The table is inundated");
        }

        /// <summary>
        /// Поиск значения элемента в хэш-таблице по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Tval FindHashVal(int key)
        {
            int index = HashKey(key);
            if (h[index].hashList[key] != null) { return h[index].hashList[key].val; }
            else { throw new Exception("No such element"); }
            /* bool ok;

             if ((h[index].empty) || (h[index].key.CompareTo(key) == -1) || (h[index].key.CompareTo(key) == 1))
             {
                 index = (index + step) % sizeTable;
                 ok = false;

                 while (!ok)
                 {
                     if (!h[index].empty && h[index].key.CompareTo(key) == 0)
                     {
                         ok = true;
                     }
                     else index = (index + step) % sizeTable;
                 }
                 if (ok)
                 {
                     return h[index].val;
                 }
                 else throw new Exception("No such element");
             }
             else return h[index].val;*/

        }

        /// <summary>
        /// Вывод списка элемента хеш-таблицы
        /// </summary>
        /// <param name="key"></param>
        public void PrintHashList(int key)
        {
            int index = HashKey(key);
            h[index].hashList.PrintList(key);
        }

        /// <summary>
        /// Удаление элемента из хэш-таблицы по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Delete(int key, Tval val)
        {
            if (size != 0)
            {
                int index = HashKey(key);
                h[index].hashList.DeleteNode(key, val);
                size--;

                /*else
                {
                    index = FindHashIndex(key);
                    if (index != int.MaxValue)
                    {
                        h[index].hashList.GetVal(key) = true;
                        h[index].visit = false;
                        h[index].key = 0;
                        size--;
                        return h[index].key;
                    */
            }
            else throw new Exception("The hash-table is empty");
        }

        /*  /// <summary>
       /// Поиск индекса элемента в хэш-таблице по ключу
       /// </summary>
       /// <param name="key"></param>
       /// <returns></returns>
       public Tval FindHashIndex(int key)
       {
           //ClearVisit();
           int index = HashKey(key);
           return h[index].collisList.GetVal(key);
          /* int result = int.MaxValue;
           bool ok;

           if (h[index].empty || (h[index].key.CompareTo(key) == 1) || (h[index].key.CompareTo(key) == -1))
           {
               index = (index + step) % sizeTable;
               ok = false; 
               //int i = 0;
               while (!ok) //&& h[index].visit
               {
                   if (!h[index].empty && (h[index].key.CompareTo(key) == 0))
                       ok = true;
                   else
                   {
                       index = (index + step) % sizeTable;
                      // i++;
                   }
               }
               if (ok)
               {
                   result = index;
                   return result;
               }           
           }
           else
               result = index;
           return result;
       }*/
        #endregion
    }
}


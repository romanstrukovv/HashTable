using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTTable
{
    public class Node<T>
    {
        public T val; // значение 
        public int key; // ключ
        public bool empty; // пуст ли        
        public Node<T> next; //следующий узел

        public Node(int key, T val, Node<T> next)
        {
            this.key = key;
            this.val = val;
            this.next = next;
        }
    }

    public class MyList<Tval> where Tval : IComparable
    {
        public static Node<Tval> head = new Node<Tval>(0, default(Tval), null);  //узел головы
        public static int count;  //количество элементов в списке
        public  Node<Tval> p = new Node<Tval>(0, default(Tval), head); //вспомогательный узел

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MyList()
        {
            head = null;
            count = 0;
        }

        protected int CompareTo(Tval obj)
          {
              return this.p.val.ToString().CompareTo(obj.ToString());
          }

        /// <summary>
        /// Добавление элемент в начало списка
        /// </summary>
        /// <param name="element"></param>
        public void Add(int key, Tval val)
        {
            Node<Tval> x = new Node<Tval>(key, val, head);
            head = x;

            count++;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="key"></param>
        public void DeleteNode(int key, Tval val)
        {
            if (head != null)
            {

                if ((head.key == key) && (head.val.ToString().CompareTo(val.ToString())) == 0)
                {
                    head = head.next;
                    count--;
                    return;
                }
                else
                {
                    p = head;

                    if (p.next == null)
                    {
                        throw new Exception("No such element");
                    }

                    else
                    {
                        while ((p.next.key != key) && ((p.next.val.ToString().CompareTo(val.ToString()) == 1) || (p.next.val.ToString().CompareTo(val.ToString()) == -1)))
                        {
                            p = p.next;
                        }
                        p.next = p.next.next;
                        count--;

                        return;
                    }
                }             
            }
            else throw new Exception("The list is empty");
        }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count
        {
            get
            {
                if (count >= 0)
                    return count;
                else throw new Exception("The list is empty");
            }
            set { count = value; }
        }

        public void PrintList(int key)
        {
            if (head != null)
            {
                p = head;
                int numOfElement = 0;

                do
                {
                    if (p.key == key)
                    {
                        Console.WriteLine("{0} element is:  {1}", numOfElement, p.val);
                    }
                    numOfElement++;
                    p = p.next;
                } while (p != null);
            }
        }

        #region Индексации

        /// <summary>
        /// Индексация списка с возварщением узла
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node<Tval> this[int key]
        {
            get
            {
                if (head != null)
                {
                    p = head;
                    while (p.key != key)
                    {
                        p = p.next;
                    }

                    return p;
                }
                else throw new Exception("The list is empty");
            }

            set
            {
                if (head != null)
                {
                    while (p.key != key)
                    {
                        p = p.next;
                    }

                    p = value;
                }
                else throw new Exception("The list is empty");
            }
        }

        /* /// <summary>
         /// Индексация списка с возварщением значения
         /// </summary>
         /// <param name="i"></param>
         /// <returns></returns>
       
         public Tval this[double i]
         {
             set
             {
                 if (head != null)
                 {
                     if (i == 0)
                     {
                         p = head;
                         p.val = value;
                     }
                     else
                     {
                         p = head;
                         for (int k = 0; k < i; k++)
                             p = p.next;

                         p.val = value;
                     }
                 }
                 else throw new ArgumentOutOfRangeException();
             }

             get
             {
                 if (head != null)
                 {
                     if (i == 0)
                     {
                         p = head;
                         return p.val;
                     }
                     else
                     {
                         p = head;
                         for (int k = 0; k < i; k++)
                             p = p.next;

                         return p.val;
                     }
                 }
                 else throw new ArgumentOutOfRangeException();
             }*/

    }
        #endregion

}



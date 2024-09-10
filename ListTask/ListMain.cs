using System;

namespace ListTask
{
    internal class ListMain
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();

            list1.AddFirst(8);
            list1.AddFirst(7);
            list1.AddFirst(1);
            list1.AddFirst(2);
            list1.AddFirst(3);
            list1.AddFirst(4);

            SinglyLinkedList<int> list2 = new SinglyLinkedList<int>();

            list2.AddFirst(8);

            SinglyLinkedList<string> list3 = new SinglyLinkedList<string>();

            list3.AddFirst("string1");
            list3.AddFirst("string2");
            list3.AddFirst("string3");

            Console.WriteLine("Размер списка: " + list1.GetCount());

            Console.WriteLine("Значение первого элемента: " + list1.GetFirstElement());

            Console.WriteLine("Значение элемента по индексу: " + list3.GetData(1));

            Console.WriteLine("Старое значение элемента по индексу: " + list1.SetData(2, 6));

            Console.WriteLine(list1);

            Console.WriteLine("Значение удаленного элемента по индексу: " + list1.DeleteElement(4));

            Console.WriteLine(list1);

            list1.AddFirst(0);
            Console.WriteLine("Вставка элемента в начало: " + list1);

            list1.AddByIndex(1, 10);
            Console.WriteLine("Вставка элемента по индексу: " + list1);

            Console.WriteLine("Удаление узла по значению: " + list1.DeleteData(4));
            Console.WriteLine(list1);
           
            Console.WriteLine("Значение удаленного первого элемента: " + list1.GetDeletedFirstElement());

            list1.Reverse();
            Console.WriteLine("Разворот списка: " + list1);

            Console.WriteLine("Копия списка: " + list2.GetCopy());

            Console.ReadLine();
        }
    }
}
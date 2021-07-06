using System;
using System.Collections.Generic;
using CSharpCheatSheet.Services.Interfaces;

namespace CSharpCheatSheet.Services
{
    public class CodepediaService : ICodepediaService
    {
        #region 
        public void SampleList()
        {
            WriteTitle("Cheat Sheet", "Start\n", ConsoleColor.DarkCyan);
            CheatSheetList();
            WriteTitle("\nCheat Sheet", "End", ConsoleColor.DarkCyan);
        }

        public void CheatSheetList()
        {
            WriteTitle("List", "Start\n", ConsoleColor.Cyan);

            List<int> list = new List<int>() { 99, 90, 343, 807, 7, 1, 2, 54, 98765 };
            WriteLine("list.IndexOf(90)", list.IndexOf(90));
            WriteLine("list[1]", list[1]);
        }
        #endregion

        #region LinkedList
        // Linked List: https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
        public void SampleLinkedListAddLast()
        {
            // Creating a linkedlist
            // Using LinkedList class
            LinkedList<String> my_list = new LinkedList<String>();

            // Adding elements in the LinkedList
            // Using AddLast() method
            my_list.AddLast("Zoya");
            my_list.AddLast("Shilpa");
            my_list.AddLast("Rohit");
            my_list.AddLast("Rohan");
            my_list.AddLast("Juhi");
            my_list.AddLast("Zoya");

            Console.WriteLine("Best students of XYZ university:");

            // Accessing the elements of 
            // LinkedList Using foreach loop
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }
        }

        public void SampleLinkedListRemove()
        {
            // Creating a linkedlist
            // Using LinkedList class
            LinkedList<String> my_list = new LinkedList<String>();

            // Adding elements in the LinkedList
            // Using AddLast() method
            my_list.AddLast("Zoya");
            my_list.AddLast("Shilpa");
            my_list.AddLast("Rohit");
            my_list.AddLast("Rohan");
            my_list.AddLast("Juhi");
            my_list.AddLast("Zoya");

            // Inital number of elements
            Console.WriteLine("Best students of XYZ " +
                             "university initially:");

            // Accessing the elements of 
            // Linkedlist Using foreach loop
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // After using Remove(LinkedListNode)
            // method
            Console.WriteLine("Best students of XYZ" +
                             " university in 2000:");

            my_list.Remove(my_list.First);

            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // After using Remove(T) method
            Console.WriteLine("Best students of XYZ" +
                             " university in 2001:");

            my_list.Remove("Rohit");

            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // After using RemoveFirst() method
            Console.WriteLine("Best students of XYZ" +
                             " university in 2002:");

            my_list.RemoveFirst();

            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // After using RemoveLast() method
            Console.WriteLine("Best students of XYZ" +
                             " university in 2003:");

            my_list.RemoveLast();

            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // After using Clear() method
            my_list.Clear();
            Console.WriteLine("Number of students: {0}",
                                         my_list.Count);
        }

        public void SampleLinkedListContains()
        {
            // Creating a linkedlist
            // Using LinkedList class
            LinkedList<String> my_list = new LinkedList<String>();

            // Adding elements in the Linkedlist
            // Using AddLast() method
            my_list.AddLast("Zoya");
            my_list.AddLast("Shilpa");
            my_list.AddLast("Rohit");
            my_list.AddLast("Rohan");
            my_list.AddLast("Juhi");

            // Check if the given element
            // is available or not
            if (my_list.Contains("Shilpa") == true)
            {
                Console.WriteLine("Element Found...!!");
            }
            else
            {
                Console.WriteLine("Element Not found...!!");
            }
        }
        #endregion

        private void WriteTitle(string label, object value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{label}: {value}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WriteLine(string label, object value)
        {
            Console.WriteLine($"    {label}: {value}");
        }

        private void WriteLine(string label)
        {
            Console.WriteLine($"    {label}");
        }
    }
}

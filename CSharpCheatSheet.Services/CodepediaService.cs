using System;
using System.Collections.Generic;
using System.Text;
using CSharpCheatSheet.Services.Interfaces;
using Microsoft.Extensions.Logging;

/// <summary>
/// Topics so far:
/// StringBuilder
/// List
/// LinkedList
/// Create Alphabet
/// Yield (in create alphabet)
/// Array
/// Multidimentional array
/// Jagged array
/// Multidimentional convined with jagged array.
/// </summary>
namespace CSharpCheatSheet.Services
{
    public class CodepediaService : ICodepediaService
    {
        private readonly ILogger _logger;

        public CodepediaService(ILogger<AlgorithmService> logger)
        {
            _logger = logger;
        }

        public void RunInMain(bool onlySelected)
        {

            showIncrementDecrement(10);
            if (!onlySelected)
            {
                LoopArray();
                DemoArray();
                DemoBiDimendionalArray();
                DemoJaggedArray();
                MultidimensionaConbineJaggedArray();
                BuildAlphabet();
                SampleStringBuilderWithNoText();
                SampleStringBuilder();
                SampleList();
                CheatSheetList();
                SampleLinkedListAddLast();
                SampleLinkedListRemove();
                SampleLinkedListContains();
            }
        }

        #region incrementDecrement
        public void showIncrementDecrement(int i)
        {

            int a = i;
            int x = ++a;
            Console.WriteLine($"i:{i} a:{a} x:{x}");

            int b = i;
            int y = b++;
            Console.WriteLine($"i:{i} b:{b} y:{y}");

        }
        #endregion

        #region Yield
        public IEnumerable<char> YieldReturnAlphabet(char startChar, char endChar)
        {
            for (char c = startChar; c <= endChar; c++)
            {
                yield return c;
            }
        }

        public IEnumerable<char> YieldTruncateAlphabet(char startChar, char endChar, char truncateChar)
        {
            for (char c = startChar; c <= endChar; c++)
            {
                yield return c;

                if (c == truncateChar)
                {
                    yield break;
                }
            }
        }
        #endregion

        #region Arrays
        public void LoopArray()
        {
            // declares an Array of integers.
            int[] intArray;

            // allocating memory for 5 integers.
            intArray = new int[5];

            // initialize the first elements
            // of the array
            intArray[0] = 10;

            // initialize the second elements
            // of the array
            intArray[1] = 20;

            // so on...
            intArray[2] = 30;
            intArray[3] = 40;
            intArray[4] = 50;

            // accessing the elements
            // using for loop
            Console.Write("For loop :");
            for (int i = 0; i < intArray.Length; i++)
                Console.Write(" " + intArray[i]);

            Console.WriteLine("");
            Console.Write("For-each loop :");

            // using for-each loop
            foreach (int i in intArray)
                Console.Write(" " + i);

            Console.WriteLine("");
            Console.Write("while loop :");

            // using while loop
            int j = 0;
            while (j < intArray.Length)
            {
                Console.Write(" " + intArray[j]);
                j++;
            }

            Console.WriteLine("");
            Console.Write("Do-while loop :");

            // using do-while loop
            int k = 0;
            do
            {
                Console.Write(" " + intArray[k]);
                k++;
            } while (k < intArray.Length);
        }

        public void DemoArray()
        {
            int[] x;  // can store int values
            string[] s; // can store string values
            double[] d; // can store double values
                        //Student[] stud1; // can store instances of Student class which is custom class

            // defining array with size 5. 
            // But not assigns values
            int[] intArray1 = new int[5];

            // defining array with size 5 and assigning
            // values at the same time
            int[] intArray2 = new int[5] { 1, 2, 3, 4, 5 };

            // defining array with 5 elements which 
            // indicates the size of an array
            int[] intArray3 = { 1, 2, 3, 4, 5 };

            // Declaration of the array
            string[] str1, str2;

            // Initialization of array
            str1 = new string[5] { "Element 1", "Element 2", "Element 3", "Element 4", "Element 5" };

            str2 = new string[5] { "Element 1", "Element 2", "Element 3", "Element 4", "Element 5" };

            /// Errors
            /// compile-time error: must give size of an array
            //int[] intArray = new int[];

            /// error : wrong initialization of an array
            //string[] str1;
            //str1 = {"Element 1", "Element 2", "Element 3", "Element 4" };
        }

        public void DemoBiDimendionalArray()
        {
            // Two-dimensional array
            int[,] intarray = new int[,] { { 1, 2 },
                                         { 3, 4 },
                                         { 5, 6 },
                                         { 7, 8 } };

            // The same array with dimensions 
            // specified 4 row and 2 column.
            int[,] intarray_d = new int[4, 2] { { 1, 2 }, { 3, 4 },
                                             { 5, 6 }, { 7, 8 } };

            // A similar array with string elements.
            string[,] str = new string[4, 2] { { "one", "two" },
                                            { "three", "four" },
                                            { "five", "six" },
                                            { "seven", "eight" } };

            // Three-dimensional array.
            int[,,] intarray3D = new int[,,] { { { 1, 2, 3 },
                                             { 4, 5, 6 } },
                                             { { 7, 8, 9 },
                                           { 10, 11, 12 } } };


            // The same array with dimensions 
            // specified 2, 2 and 3.
            int[,,] intarray3Dd = new int[2, 2, 3] { { { 1, 2, 3 },
                                                  { 4, 5, 6 } },
                                                  { { 7, 8, 9 },
                                                { 10, 11, 12 } } };

            // Accessing array elements.
            Console.WriteLine("2DArray[0][0] : " + intarray[0, 0]);
            Console.WriteLine("2DArray[0][1] : " + intarray[0, 1]);
            Console.WriteLine("2DArray[1][1] : " + intarray[1, 1]);
            Console.WriteLine("2DArray[2][0] " + intarray[2, 0]);

            Console.WriteLine("2DArray[1][1] (other) : "
                                     + intarray_d[1, 1]);

            Console.WriteLine("2DArray[1][0] (other)"
                                 + intarray_d[1, 0]);

            Console.WriteLine("3DArray[1][0][1] : "
                               + intarray3D[1, 0, 1]);

            Console.WriteLine("3DArray[1][1][2] : "
                              + intarray3D[1, 1, 2]);

            Console.WriteLine("3DArray[0][1][1] (other): "
                                 + intarray3Dd[0, 1, 1]);

            Console.WriteLine("3DArray[1][0][2] (other): "
                                 + intarray3Dd[1, 0, 2]);

            // using nested loop show string elements
            Console.WriteLine("To String element");
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 2; j++)
                    Console.Write(str[i, j] + " ");
        }

        public void DemoJaggedArray()
        {
            /*----------2D Array---------------*/
            // Declare the array of two elements:
            int[][] arr = new int[2][];

            // Initialize the elements:
            arr[0] = new int[5] { 1, 3, 5, 7, 9 };
            arr[1] = new int[4] { 2, 4, 6, 8 };

            // Another way of Declare and
            // Initialize of elements
            int[][] arr1 = { new int[] { 1, 3, 5, 7, 9 },
                         new int[] { 2, 4, 6, 8 } };

            // Display the array elements:
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element [" + i + "] Array: ");
                for (int j = 0; j < arr[i].Length; j++)
                    Console.Write(arr[i][j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine("Another Array");

            // Display the another array elements:
            for (int i = 0; i < arr1.Length; i++)
            {
                System.Console.Write("Element [" + i + "] Array: ");
                for (int j = 0; j < arr1[i].Length; j++)
                    Console.Write(arr1[i][j] + " ");
                Console.WriteLine();
            }
        }

        public void MultidimensionaConbineJaggedArray()
        {
            int[][,] arr = new int[3][,] {new int[, ] {{1, 3}, {5, 7}},
                                    new int[, ] {{0, 2}, {4, 6}, {8, 10}},
                                    new int[, ] {{11, 22}, {99, 88}, {0, 9}}};

            // Display the array elements:
            for (int i = 0; i < arr.Length; i++)
            {
                int x = 0;
                for (int j = 0; j < arr[i].GetLength(x); j++)
                {
                    for (int k = 0; k < arr[j].Rank; k++)
                        Console.Write(" arr[" + i + "][" + j + ", " + k + "]:"
                                                       + arr[i][j, k] + " ");
                    Console.WriteLine();
                }
                x++;
                Console.WriteLine();
            }
        }

        #endregion

        #region Alphabet
        public void BuildAlphabet()
        {
            // using yield
            foreach (char c in GetAlphabet())
            {
                Console.WriteLine(c);
            }

            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{Convert.ToChar(i + 65)} - {Convert.ToChar(i + 97)}");
            }

            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine(c);
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                Console.WriteLine(c);
            }

            /*
             public class EnglishAlphabetProvider : IAlphabetProvider //TODO: I like this provider, extensions, helpers, utils, etc.
                {
                    public IEnumerable<char> GetAlphabet()
                    {
                        for (char c = 'A'; c <= 'Z'; c++)
                        {
                            yield return c;
                        } 
                    }
                }

                IAlphabetProvider provider = new EnglishAlphabetProvider();

                foreach (char c in provider.GetAlphabet())
                {
                    //do something with letter 
                } 
             * */
        }

        private IEnumerable<char> GetAlphabet()
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                yield return c;
            }
        }
        #endregion

        #region StringBuilder
        public void SampleStringBuilder()
        {
            // Create a StringBuilder that expects to hold 50 characters.
            // Initialize the StringBuilder with "ABC".
            StringBuilder sb = new StringBuilder("ABC", 50);

            // Append three characters (D, E, and F) to the end of the StringBuilder.
            sb.Append(new char[] { 'D', 'E', 'F' });

            // Append a format string to the end of the StringBuilder.
            sb.AppendFormat("GHI{0}{1}", 'J', 'k');

            // Display the number of characters in the StringBuilder and its string.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

            // Insert a string at the beginning of the StringBuilder.
            sb.Insert(0, "Alphabet: ");

            // Replace all lowercase k's with uppercase K's.
            sb.Replace('k', 'K');

            // Display the number of characters in the StringBuilder and its string.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

            // This code produces the following output.
            //
            // 11 chars: ABCDEFGHIJk
            // 21 chars: Alphabet: ABCDEFGHIJK
        }

        public void SampleStringBuilderWithNoText()
        {
            // Create a StringBuilder object with no text.
            StringBuilder sb = new StringBuilder();
            // Append some text.
            sb.Append('*', 10).Append(" Adding Text to a StringBuilder Object ").Append('*', 10);
            sb.AppendLine("\n");
            sb.AppendLine("Some code points and their corresponding characters:");
            // Append some formatted text.
            for (int ctr = 0; ctr <= 256; ctr++)
            {
                sb.AppendFormat("{0,12:X4} {1,12}", ctr, Convert.ToChar(ctr));
                sb.AppendLine();
            }
            // Find the end of the introduction to the column.
            int pos = sb.ToString().IndexOf("characters:") + 11 +
                      Environment.NewLine.Length;
            // Insert a column header.
            sb.Insert(pos, String.Format("{2}{0,12:X4} {1,12}{2}", "Code Unit",
                                         "Character", "\n"));

            // Convert the StringBuilder to a string and display it.      
            Console.WriteLine(sb.ToString());
        }

        #endregion

        #region List<T>
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

        #region LinkedList<T>
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
            _logger.LogInformation($"{label}: {value}");
            System.Diagnostics.Debug.WriteLine("guey 2");
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

using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCheatSheet.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CSharpCheatSheet.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly ILogger _logger;

        public AlgorithmService(ILogger<AlgorithmService> logger)
        {
            _logger = logger;
        }

        public void RunInMain(bool onlySelected)
        {
            if (!onlySelected)
            {
                Console.WriteLine("--- Microsoft: Reverse a word Recursive");
                string word2 = "122someconcatenatedwordstoreverseyes223";
                var reversedWord2 = this.ReverseWordRecursive(word2, 0);
                Console.WriteLine($"Word: {word2}");
                Console.WriteLine($"ReversedWord: {reversedWord2}\n");

                Console.WriteLine("--- Microsoft: Reverse a word Iterative 2 pointers");
                string word4 = "123someconcatenatedwordstoreverseyes123";
                var reversedWord4 = this.ReverseWordTwoPointers(word4);
                Console.WriteLine($"Word: {word4}");
                Console.WriteLine($"ReversedWord: {reversedWord4}\n");

                Console.WriteLine("--- Microsoft: Reverse a word left right");
                string word3 = "111someconcatenatedwordstoreverseyes111";
                var reversedWord3 = this.ReverseWordLeftRight(word3);
                Console.WriteLine($"Word: {word3}");
                Console.WriteLine($"ReversedWord: {reversedWord3}\n");

                Console.WriteLine("--- Microsoft: Reverse a word Swapper");
                string word1 = "someconcatenatedwordstoreverseyes";
                var reversedWord1 = this.ReverseWordSwapper(word1);
                Console.WriteLine($"Word: {word1}");
                Console.WriteLine($"ReversedWord: {reversedWord1}\n");

                Console.WriteLine("--- Microsoft: Reverse a word Stack");
                string word = "someconcatenatedwordstoreverseyes";
                var reversedWord = this.ReverseWordWStack(word);
                Console.WriteLine($"Word: {word}");
                Console.WriteLine($"ReversedWord: {reversedWord}\n");

                Console.WriteLine("--- AWS Interview for DevOpsWJson: 2nd largest, second smallest");
                int[] arr3 = new int[] { 5, 5, 6, 7, 8, 4, 5, 7, 4, 1, 1, 33, 88, 87, 67, 741, 845, 2, 9, 0, 845 };
                int[] copyArray3 = new int[arr3.Length]; // need to copy if one unsorted ref sticks
                Array.Copy(arr3, copyArray3, arr3.Length);
                (int, int) arrSorted3 = SecondLargestSecondSmallest(copyArray3);
                Console.WriteLine($"Array: {JsonConvert.SerializeObject(arr3)}");
                Console.WriteLine($"Second Smallest/Second Largest: {JsonConvert.SerializeObject(arrSorted3)}\n");

                Console.WriteLine("--- Insert Sort");
                int[] arr2 = new int[10] { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };
                int[] copyArray2 = new int[10]; // need to copy if one unsorted ref sticks
                Array.Copy(arr2, copyArray2, 10);
                int[] arrSorted2 = InsertSort(copyArray2);
                Console.WriteLine($"Unsorted array: {JsonConvert.SerializeObject(arr2)}");
                Console.WriteLine($"Sorted array: {JsonConvert.SerializeObject(arrSorted2)}\n");

                Console.WriteLine("--- Selection Sort");
                int[] arr1 = new int[10] { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };
                int[] copyArray1 = new int[10]; // need to copy if one unsorted ref sticks
                Array.Copy(arr1, copyArray1, 10);
                int[] arrSorted1 = SelectionSort(copyArray1);
                Console.WriteLine($"Unsorted array: {JsonConvert.SerializeObject(arr1)}");
                Console.WriteLine($"Sorted array: {JsonConvert.SerializeObject(arrSorted1)}\n");

                Console.WriteLine("--- Bubble Sort");
                int[] arr = new int[10] { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };
                int[] copyArray = new int[10]; // need to copy if one unsorted ref sticks
                Array.Copy(arr, copyArray, 10);
                int[] arrSorted = BubbleSort(copyArray);
                Console.WriteLine($"Unsorted array: {JsonConvert.SerializeObject(arr)}");
                Console.WriteLine($"Sorted array: {JsonConvert.SerializeObject(arrSorted)}\n");

                Console.WriteLine("--- Recursive Factorial");
                int num = 5;
                var factorial = this.RecursiveFactorial(num);
                Console.WriteLine($"num to factorial: {num}");
                Console.WriteLine($"factorial: {factorial}\n");

                Console.WriteLine("--- Merge Sort");
                int[] unstoredArr = new int[10] { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };
                int[] copyUnstoredAArray = new int[10]; // need to copy if one unsorted ref sticks
                Array.Copy(unstoredArr, copyUnstoredAArray, 10);
                int[] arraySorted = MergeSort(copyUnstoredAArray);
                Console.WriteLine($"Unsorted array: {JsonConvert.SerializeObject(unstoredArr)}");
                Console.WriteLine($"Sorted array: {JsonConvert.SerializeObject(arraySorted)}\n");
            }

            Console.WriteLine("--- Quick Sort");
            int[] unstoredArr1 = { 7, 1, 2, 4, 5, 99, 0, 3, 5, 8, 66, 8, 55, 8, 1 };
            Console.WriteLine($"Unsorted array: {JsonConvert.SerializeObject(unstoredArr1)}");
            QuickSort(unstoredArr1, 0, unstoredArr1.Length - 1);
            
            Console.WriteLine($"Sorted array: {JsonConvert.SerializeObject(unstoredArr1)}\n");
        }

        public int RecursiveFactorial(int num)
        {
            /// 5! = 120
            /// 5 * 4! = 120
            /// 5 * 4 * 3! = 120
            /// 5 * 4 * 3 * 2! = 120
            /// 5 * 4 * 3 * 2 * 1! = 120
            /// 5 * 4 * 3 * 2 * 1 * 0! = 120 -- no ned to get here as 0 and 1 factorial is 1, so when 0 it is the exit, if not becomes eternal with a stack overflow error.
            /// 
            if (num == 0)
                return 1; //0! == 0;

            return num * RecursiveFactorial(num - 1); // no num-- because it grabs value first and then decreases
        }

        public string ReverseWordTwoPointers(string word)
        {
            ///https://www.geeksforgeeks.org/program-reverse-string-iterative-recursive/
            /// Using stack would be 
            /// Time complexity : O(n) 
            /// Auxiliary Space : O(1)

            int n = word.Length;

            /// If evens last two will swap, if odds no need to swap the unaccounted
            /// for of the int div truncating decimal since it is the middle one.
            char[] arr = word.ToCharArray();

            for (int i = 0, j = n - 1; i < j; i++, j--)
            {
                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return string.Join("", arr);
        }

        public string ReverseWordLeftRight(string word)
        {
            /// Same as Two pointers basically.
            ///https://www.geeksforgeeks.org/program-reverse-string-iterative-recursive/
            /// Using stack would be 
            /// Time complexity : O(n) 
            /// Auxiliary Space : O(1)

            char[] temparray = word.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return String.Join("", temparray);
        }

        public string ReverseWordRecursive(string word, int i)
        {
            ///https://www.geeksforgeeks.org/program-reverse-string-iterative-recursive/
            /// Using stack would be 
            /// Time complexity : O(n) 
            /// Auxiliary Space : O(1)

            char[] arr = word.ToCharArray();
            ReverseWordRecursiveInner(arr, i); //void not need to return since it is a arr are by ref.   
            return string.Join("", arr);
        }

        private void ReverseWordRecursiveInner(char[] arr, int i)
        {
            int n = arr.Length;

            if (i == n / 2) // This is the exit, need this if not infinite loop.
                return;

            char temp = arr[(n - 1) - i];
            arr[(n - 1) - i] = arr[i];
            arr[i] = temp;
            Console.WriteLine($"{i}"); // later stack over flow error
            i++; //need here, for some reason if I do in function call won't work.
            ReverseWordRecursiveInner(arr, i/*i+1 works ; i++ no work*/); // This is the "iterator"; i++ stack overflow

            /*
            Because return AddMethod(input1++, input2--); first passes your inputs, and THEN increments and decrements.

            Try return AddMethod(++input1, --input2);
            */
        }

        public string ReverseWordSwapper(string word)
        {
            /// Using stack would be 
            /// Time complexity : O(n) 
            /// Auxiliary Space : O(1)

            int n = word.Length;

            /// If evens last two will swap, if odds no need to swap the unaccounted
            /// for of the int div truncating decimal since it is the middle one.
            char[] arr = word.ToCharArray();

            for (int i = 0; i < n / 2; i++)
            {
                char temp = arr[(n - 1) - i];
                arr[(n - 1) - i] = arr[i];
                arr[i] = temp;
            }

            return string.Join("", arr);
        }

        public string ReverseWordWStack(string word)
        {
            /// Using stack would be 
            /// Time complexity : O(n) 
            /// Auxiliary Space : O(n)

            int n = word.Length;
            char[] charArr = word.ToCharArray();

            /// Stack (LIFO): last in first out.
            Stack<char> stack = new Stack<char>();

            /// Stack<char> stack = new Stack<char>(charArr); coud do it this way, but bottom way shows push explicitly.
            for (int i = 0; i < n; i++)
            {
                stack.Push(charArr[i]);
            }

            for (int i = 0; i < n; i++)
            {
                /// Can do peek pop, or straight pop.
                //charArr[i] = stack.Peek();
                //stack.Pop();

                charArr[i] = stack.Pop();
            }

            return string.Join("", charArr);
        }

        public (int, int) SecondLargestSecondSmallest(int[] arr)
        {
            // Init local variables.
            int min = int.MaxValue;
            int max = int.MinValue;
            int secondMin = min;
            int secondMax = max;
            (int min, int max) secondMinMax = (0, 0);
            int n = arr.Length;

            // If not at least 2 return empty tuple.
            if (n < 2)
                return secondMinMax;

            for (int i = 0; i < n; i++)
            {
                int current = arr[i];

                if (current < secondMin)
                {
                    if (current < min)
                    {
                        secondMin = min;
                        min = current;
                    }
                    else if (current > min)
                    {
                        secondMin = current;
                    }
                }

                if (current > secondMax)
                {
                    if (current > max)
                    {
                        secondMax = max;
                        max = current;
                    }
                    else if (current < max)
                    {
                        secondMax = current;
                    }
                }

                secondMinMax.min = secondMin;
                secondMinMax.max = secondMax;
            }

            // Dictionary indicating min and max would be more explicit, but O(n) worst in space, and wanted to practice tuple.
            return secondMinMax;
        }

        public void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = Partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {

            // pivot
            int pivot = arr[high];

            // Index of smaller element and
            // indicates the right position
            // of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller
                // than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of
                    // smaller element
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return (i + 1);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public int[] MergeSort(int[] arr)
        {
            int n = arr.Length;

            MergeSortInternalSort(arr, 0, n - 1); // Can pass array as reference and not set value.

            return arr;
        }

        public void MergeSortInternalSort(int[] arr, int l, int r)
        {
            int n = arr.Length;

            if (l < r) // Circuit breaker if no recursion goes infinite
            {
                int m = l + (r - l) / 2;//??? same results, but bottom one is easier.
                //int m = (l + r) / 2;
                Console.WriteLine($"l:{l},m:{m},r:{r}");
                MergeSortInternalSort(arr, l, m); // now pass m as right.
                MergeSortInternalSort(arr, m + 1, r); // now pass m+1 as left, the next one of m above.
                MergeSortInternalMerge(arr, l, m, r);
            }
        }

        public void MergeSortInternalMerge(int[] arr, int l, int m, int r)
        {
            // need to get 2 halves arrays, left and right, no seed to get lengths.
            int nL = m - l + 1;
            int nR = r - m;
            Console.WriteLine($"nL:{nL},nR:{nR}");

            int[] L = new int[nL];
            int[] R = new int[nR];
            int i = 0;
            int j = 0;//initializing because of the first while

            for (i = 0; i < nL; i++)
            {
                L[i] = arr[l + i];
            }

            for (j = 0; j < nR; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            // Don't forget to reinitialize
            i = 0;
            j = 0;

            // Need to switch and put into array.
            int k = l;
            while (i < nL && j < nR)
            {
                if (L[i] <= R[j])
                {                    
                    arr[k] = L[i];
                    i++; // First action and then increment, not viceversa as I had.
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < nL)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < nR)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public int[] InsertSort(int[] arr)
        {
            int n = arr.Length;

            for (int wall = 1; wall < n; wall++)
            {
                int unsorted = arr[wall];

                int i;
                for (i = wall; i > 0 && arr[i - 1] > unsorted; i--)
                {
                    arr[i] = arr[i - 1];
                }

                arr[i] = unsorted;
            }

            return arr;
        }

        public int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int wall = n - 1; wall > 0; wall--)
            {
                int sorted = 0;
                for (int j = sorted + 1; j <= wall; j++)
                {
                    // Console.WriteLine($"arr[j] > arr[sorted]: {arr[j]} > {arr[sorted]}");
                    if (arr[j] > arr[sorted])
                    {
                        sorted = j;
                    }
                }

                /// Swap
                if (arr[sorted] > arr[wall])
                {
                    int temp = arr[wall];
                    arr[wall] = arr[sorted];
                    arr[sorted] = temp;
                }
            }

            return arr;
        }

        public int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;

            /// Wall
            bool swapped;
            for (int i = n - 1; i > 0; i--)
            {
                /// Get first and second; j => last n (wall); j+1 => j < 1
                swapped = false;
                for (int j = 0; j < i; j++)
                {
                    /// Swap
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            return arr;
        }

        // https://leetcode.com/problems/word-ladder-ii/
        // https://leetcode.com/problems/minimum-genetic-mutation/

        /// <summary>
        /// 127. Word Ladder
        /// A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:
        /// 
        /// Every adjacent pair of words differs by a single letter.
        /// Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
        /// sk == endWord
        /// Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in the shortest transformation sequence from beginWord to endWord, or 0 if no such sequence exists.
        /// 
        /// Example 1:
        /// Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
        /// Output: 5
        /// Explanation: One shortest transformation sequence is "hit" -> "hot" -> "dot" -> "dog" -> cog", which is 5 words long.
        /// 
        /// Example 2:
        /// Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
        /// Output: 0
        /// Explanation: The endWord "cog" is not in wordList, therefore there is no valid transformation sequence. 
        /// 
        /// Constraints:
        /// 
        /// 1 <= beginWord.length <= 10
        /// endWord.length == beginWord.length
        /// 1 <= wordList.length <= 5000
        /// wordList[i].length == beginWord.length
        /// beginWord, endWord, and wordList[i] consist of lowercase English letters.
        /// beginWord != endWord
        /// All the words in wordList are unique.
        /// </summary>
        /// <param name="beginWord">starting word</param>
        /// <param name="endWord">ending word</param>
        /// <param name="wordList">list of words to traverse</param>
        /// <returns>minimum path to get to end word if any </returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            _logger.LogError("Guey");
            System.Diagnostics.Debug.WriteLine("guey 2");
            HashSet<string> words = new HashSet<string>(wordList);
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(beginWord);
            visited.Add(beginWord);

            int level = 0;
            while (queue.Count > 0)
            {
                level++;
                int count = queue.Count;

                for (int i = 0; i < count; i++)
                {
                    var currentWord = queue.Dequeue();
                    if (currentWord.Equals(endWord, StringComparison.Ordinal))
                    {
                        return level;
                    }

                    char[] letters = currentWord.ToCharArray();
                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        for (int k = 0; k < 26; k++)
                        {
                            char currentChar = letters[j];
                            letters[j] = (char)('a' + k);

                            string newWord = new String(letters);
                            if (words.Contains(newWord) && !visited.Contains(newWord))
                            {
                                visited.Add(newWord);
                                queue.Enqueue(newWord);
                            }

                            letters[j] = currentChar;
                        }
                    }
                }
            }

            return 0;
        }

        /// <summary>
        ///	LeetCode: Roman to Integer  (easy)        
        ///	Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        ///	
        ///	Symbol       Value
        ///	I             1
        ///	V             5
        ///	X             10
        ///	L             50
        ///	C             100
        ///	D             500
        ///	M             1000
        ///	
        ///	For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
        ///	
        ///	Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
        ///	
        ///	I can be placed before V (5) and X (10) to make 4 and 9. 
        ///	X can be placed before L (50) and C (100) to make 40 and 90. 
        ///	C can be placed before D (500) and M (1000) to make 400 and 900.
        ///	
        ///	Given a roman numeral, convert it to an integer.
        ///	
        ///	Example 1:        
        ///	Input: s = "III"
        ///	Output: 3
        ///	
        ///	Example 2:        
        ///	Input: s = "IV"
        ///	Output: 4
        ///	
        ///	Example 3:        
        ///	Input: s = "IX"
        ///	Output: 9
        ///	
        ///	Example 4:        
        ///	Input: s = "LVIII"
        ///	Output: 58
        ///	Explanation: L = 50, V= 5, III = 3.
        ///	
        ///	Example 5:        
        ///	Input: s = "MCMXCIV"
        ///	Output: 1994
        ///	Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
        ///	
        ///	Constraints:        
        ///	1 <= s.length <= 15
        ///	s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
        ///	It is guaranteed that s is a valid roman numeral in the range [1, 3999].
        /// </summary>
        /// <param name="s">string parm</param>
        /// <returns>Int output</returns>
        public int RomanToInt(string s)
        {
            int result = 0;
            IDictionary<string, int> numeralsDict = new Dictionary<string, int>();
            numeralsDict["I"] = 1;
            numeralsDict["IV"] = 4;
            numeralsDict["V"] = 5;
            numeralsDict["IX"] = 9;
            numeralsDict["X"] = 10;
            numeralsDict["XL"] = 40;
            numeralsDict["L"] = 50;
            numeralsDict["XC"] = 90;
            numeralsDict["C"] = 100;
            numeralsDict["CD"] = 400;
            numeralsDict["D"] = 500;
            numeralsDict["CM"] = 900;
            numeralsDict["M"] = 1000;
            int n = s.Length;

            int prevVal = 0;
            for (int i = 0; i < n; i++)
            {
                string prev = "";
                if (i > 0)
                {
                    prev = s[i - 1].ToString();
                }

                string current = s[i].ToString();

                if (numeralsDict.ContainsKey(prev + current) && i > 0)
                {
                    result += numeralsDict[prev + current];
                    result -= prevVal;
                }
                else
                {
                    result += numeralsDict[current];
                    prevVal = numeralsDict[current];
                }

            }

            return result;
        }

        public int RomanToInt2(string s)
        {
            int result = 0;

            int n = s.Length;
            if (n == 0)
            {
                return result;
            }

            IDictionary<char, int> numeralsDict = new Dictionary<char, int>()
            {
                {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
            };


            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    result += numeralsDict[s[i]];
                    continue;
                }

                if (numeralsDict[s[i - 1]] < numeralsDict[s[i]])
                {
                    result += numeralsDict[s[i]] - (numeralsDict[s[i - 1]] * 2);
                }
                else
                {
                    result += numeralsDict[s[i]];
                }
            }

            return result;
        }

        /// <summary>
        /// LeetCode: First Unique Character in a String.
        /// 
        /// Given a string s, return the first non-repeating character in it and return its index.
        /// If it does not exist, return -1.
        /// 
        /// Input: s = "leetcode"
        /// Output: 0
        /// 
        /// Input: s = "loveleetcode"
        /// Output: 2
        /// 
        /// Input: s = "aabb"
        /// Output: -1
        /// 
        /// Constraints:
        /// 1 <= s.length <= 105
        /// s consists of only lowercase English letters.
        /// </summary>
        /// <param name="s">string parm</param>
        /// <returns>Int output</returns>
        public int FirstUniqChar(string s)
        {
            // Convert to hashset to get unique occurrences and loop less times
            var charHash = s.ToHashSet();

            foreach (var item in charHash)
            {
                var count = s.Count(x => x == item);
                if (count == 1)
                {
                    return s.IndexOf(item);
                }
            }

            return -1;
        }
    }
}

using System.Collections.Generic;

namespace CSharpCheatSheet.Services.Interfaces
{
    public interface IAlgorithmService
    {
        int[] BubbleSort(int[] arr);
        int FirstUniqChar(string s);
        int[] MergeSort(int[] arr);
        int LadderLength(string beginWord, string endWord, IList<string> wordList);
        int RecursiveFactorial(int num);
        string ReverseWordLeftRight(string word);
        string ReverseWordRecursive(string word, int i);
        string ReverseWordSwapper(string word);
        string ReverseWordTwoPointers(string word);
        string ReverseWordWStack(string word);
        int RomanToInt(string s);
        int RomanToInt2(string s);
        void RunInMain(bool onlySelected);
        (int min, int max) SecondLargestSecondSmallest(int[] arr);
        int[] SelectionSort(int[] arr);
        int[] QuickSort(int[] arr);
    }
}
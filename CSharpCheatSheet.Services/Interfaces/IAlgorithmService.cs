using System.Collections.Generic;

namespace CSharpCheatSheet.Services.Interfaces
{
    public interface IAlgorithmService
    {
        int[] BubbleSort(int[] arr);
        int FirstUniqChar(string s);
        int[] InsertSort(int[] arr);
        int LadderLength(string beginWord, string endWord, IList<string> wordList);
        int RomanToInt(string s);
        int RomanToInt2(string s);
        void RunInMain(bool onlySelected);
        int[] SelectionSort(int[] arr);
    }
}
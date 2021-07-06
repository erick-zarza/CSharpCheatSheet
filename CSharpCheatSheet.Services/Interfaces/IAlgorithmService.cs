using System.Collections.Generic;

namespace CSharpCheatSheet.Services.Interfaces
{
    public interface IAlgorithmService
    {
        int FirstUniqChar(string s);
        int LadderLength(string beginWord, string endWord, IList<string> wordList);
        int RomanToInt(string s);
        int RomanToInt2(string s);
    }
}
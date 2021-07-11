using System.Collections.Generic;

namespace CSharpCheatSheet.Services.Interfaces
{
    public interface ICodepediaService
    {
        void CheatSheetList();        
        void RunInMain(bool onlySelected);
        void SampleLinkedListAddLast();
        void SampleLinkedListContains();
        void SampleLinkedListRemove();
        void SampleList();
        IEnumerable<char> YieldReturnAlphabet(char startChar, char endChar);
        IEnumerable<char> YieldTruncateAlphabet(char startChar, char endChar, char truncateChar);
    }
}
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;
using CSharpCheatSheet.Services;
using CSharpCheatSheet.Services.Interfaces;

namespace CSharpCheatSheet.UnitTests
{
    public class AlgorithmUnitTests
    {
        public AlgorithmUnitTests()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAlgorithmService, AlgorithmService>()
                .BuildServiceProvider();

            //do the actual work here
            AlgorithmService = serviceProvider.GetService<IAlgorithmService>();
        }

        public IAlgorithmService AlgorithmService { get; set; }

        [Theory]
        [InlineData("hit", "cog", null, 5)] // Need to fix to pass list.
        [InlineData("hit", "cog", null, 0)] // Need to fix to pass list.
        [InlineData("hot", "dog", null, 3)] // Need to fix to pass list.
        public void CharDiffs_Solve(string beginWord, string endWord, IList<string> wordList, int expected)
        {
            // Arrange    
            if (expected == 5) wordList = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            if (expected == 0) wordList = new List<string>() { "hot", "dot", "dog", "lot", "log" };
            if (expected == 3) wordList = new List<string>() { "hot", "dog", "dot" };

            // Act
            var result = this.AlgorithmService.LadderLength(beginWord, endWord, wordList);

            // Assert
            Assert.Equal(expected: expected, actual: result);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("MDCXCV", 1695)]
        public void RomanToInt_Solve(string s, int output)
        {
            // Act
            var result = this.AlgorithmService.RomanToInt(s);

            // Assert
            Assert.Equal(expected: output, actual: result);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("MDCXCV", 1695)]
        public void RomanToInt_Solve2(string s, int output)
        {
            // Act
            var result = this.AlgorithmService.RomanToInt2(s);

            // Assert
            Assert.Equal(expected: output, actual: result);
        }

        [Theory]
        [InlineData("leetcode", 0)]
        [InlineData("loveleetcode", 2)]
        [InlineData("aabb", -1)]
        public void FirstUniqChar_Solve(string s, int output)
        {
            // Act
            var result = this.AlgorithmService.FirstUniqChar(s);

            // Assert
            Assert.Equal(expected: output, actual: result);
        }
    }
}

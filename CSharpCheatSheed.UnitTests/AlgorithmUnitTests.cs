using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;
using CSharpCheatSheet.Services;
using CSharpCheatSheet.Services.Interfaces;
using Xunit.Abstractions;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using System;

namespace CSharpCheatSheet.UnitTests
{
    public class AlgorithmUnitTests
    {
        public AlgorithmUnitTests(ITestOutputHelper output)
        {
            Output = output;

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging((builder) => builder.AddXUnit(Output))
                .AddSingleton<IAlgorithmService, AlgorithmService>()
                .BuildServiceProvider();

            //do the actual work here
            AlgorithmService = serviceProvider.GetService<IAlgorithmService>();


        }

        public IAlgorithmService AlgorithmService { get; set; }

        private ITestOutputHelper Output { get; }

        [Fact]
        public void ReverseWordWLeftRight()
        {
            // Arrange
            string word = "someconcatenatedwordstoreverseyes";
            char[] chars = word.ToCharArray();
            Array.Reverse<char>(chars);
            string expected = new string(chars);
            //string expected = string.join("", chars); //alternative

            // Act
            var result = AlgorithmService.ReverseWordLeftRight(word);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ReverseWordWRecursive()
        {
            // Arrange
            string word = "someconcatenatedwordstoreverseyes";
            char[] chars = word.ToCharArray();
            Array.Reverse<char>(chars);
            string expected = new string(chars);
            //string expected = string.join("", chars); //alternative

            // Act
            var result = AlgorithmService.ReverseWordRecursive(word);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ReverseWordWStack()
        {
            // Arrange
            string word = "someconcatenatedwordstoreverse";
            char[] chars = word.ToCharArray();
            Array.Reverse<char>(chars);
            string expected = new string(chars);
            //string expected = string.join("", chars); //alternative

            // Act
            var result = AlgorithmService.ReverseWordWStack(word);

            // Assert
            result.Should().Be(expected);
        }        

        [Fact]
        public void SecondMinSecondMax_Success()
        {
            // Arrange
            int[] arr = { 5, 5, 6, 7, 8, 4, 5, 7, 4, 1, 1, 33, 88, 87, 67, 845, 2, 9 };
            (int min, int max) expected = (2, 88);

            // Act
            var tupleMinMax = AlgorithmService.SecondLargestSecondSmallest(arr);

            // Assert
            tupleMinMax.min.Should().Be(expected.min);
            tupleMinMax.max.Should().Be(expected.max);
        }

        [Fact]
        public void InsertSort_Success()
        {
            // Arrange
            int[] arr = { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };

            // Act
            int[] sortedArr = AlgorithmService.InsertSort(arr);

            // Assert
            sortedArr.Should().BeInAscendingOrder();

        }

        [Fact]
        public void SelectionSort_Success()
        {
            // Arrange
            int[] arr = { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };

            // Act
            int[] sortedArr = AlgorithmService.SelectionSort(arr);

            // Assert
            sortedArr.Should().BeInAscendingOrder();

        }

        [Fact]
        public void BubbleSort_Success()
        {
            // Arrange
            int[] arr = { 5, 6, 7, 8, 4, 5, 7, 2, 1, 1 };

            // Act
            int[] sortedArr = AlgorithmService.BubbleSort(arr);

            // Assert
            sortedArr.Should().BeInAscendingOrder();

        }

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

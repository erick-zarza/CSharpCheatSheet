using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;
using CSharpCheatSheet.Services;
using CSharpCheatSheet.Services.Interfaces;
using Xunit.Abstractions;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using System.Linq;

namespace CSharpCheatSheet.UnitTests
{
    public class CodepediaUnitTests
    {
        public CodepediaUnitTests(ITestOutputHelper output)
        {
            Output = output;

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging((builder) => builder.AddXUnit(Output))
                .AddSingleton<ICodepediaService, CodepediaService>()
                .BuildServiceProvider();

            //do the actual work here
            CodepediaService = serviceProvider.GetService<ICodepediaService>();


        }

        public ICodepediaService CodepediaService { get; set; }

        private ITestOutputHelper Output { get; }

        [Fact]
        public void YieldReturnAlphabet_Success()
        {
            // Arrange
            char a = 'a', z = 'z';
            int expected = 26;

            // Act
            /// Wanted to use IEnumerable<T>, but it doesn't have the Count functionality 
            /// thus the conversion. IEnumerable<T> => ToList() => ICollection<T>
            ICollection<char> alphabet = CodepediaService.YieldReturnAlphabet(a, z).ToList();

            // Assert
            alphabet.Count.Should().Be(expected);

        }

        [Fact]
        public void YieldTruncateAlphabet_Success()
        {
            // Arrange
            char a = 'a', z = 'z', truncateChar = 'd';
            int expected = 4;

            // Act
            /// Wanted to use IEnumerable<T>, but it doesn't have the Count functionality 
            /// thus the conversion. IEnumerable<T> => ToList() => ICollection<T>
            ICollection<char> alphabet = CodepediaService.YieldTruncateAlphabet(a, z, truncateChar).ToList();

            // Assert
            alphabet.Count.Should().Be(expected);

        }
    }
}

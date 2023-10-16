using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredCoffeeMachine.DataProcessor.Parsing;

namespace WiredMachineCoffee.DataProcessor.Parsing
{
    public class CsvLineParserTests
    {

        [Fact]
        public void ShouldParseValidLine() 
        {
            string[] csvLines = new[] { "Cappuccino;10/27/2022,8:05:16,AM" };
           var machineDataItems = CsvLineParser.Parse(csvLines);   
            Assert.NotNull(machineDataItems);
            Assert.Single(machineDataItems);
            Assert.Equal("Cappuccino", machineDataItems[2].CoffeeType);

        }

    }
}

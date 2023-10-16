using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredCoffeeMachine.DataProcessor.Model;

namespace WiredCoffeeMachine.DataProcessor.Data
{
    public class ConsoleCoffeeCountStore : ICoffeeCountStore
    {
        private readonly TextWriter _textWriter;
        public ConsoleCoffeeCountStore(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }
        public void Save(CoffeeCountItem item) {
            var line = $"{item.CoffeeType}:{item.Count}";
            _textWriter.WriteLine(line);
        }
    }
}

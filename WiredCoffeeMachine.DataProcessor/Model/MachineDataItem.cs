using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredCoffeeMachine.DataProcessor.Model
{
    //public record MachineDataItem(string CoffeeType, DateTime CreatedAt);

    public class MachineDataItem {
        public string CoffeeType { get;  }
        public DateTime createdAt { get; }

        public MachineDataItem(string coffeeType, DateTime createdAt)
        {
            CoffeeType = coffeeType;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredCoffeeMachine.DataProcessor.Model;

namespace WiredCoffeeMachine.DataProcessor.Data
{
    public interface ICoffeeCountStore
    {
        void Save(CoffeeCountItem item);
    }
}

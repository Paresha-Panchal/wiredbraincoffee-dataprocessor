using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredCoffeeMachine.DataProcessor.Data;
using WiredCoffeeMachine.DataProcessor.Model;

namespace WiredCoffeeMachine.DataProcessor.Processing
{
    public class MachineDataProcessor
    {

        private readonly Dictionary<string, int> _countPerCoffeeType = new();
        private readonly ICoffeeCountStore _coffeeCountStore;
        private MachineDataItem? _previousItem;
        public MachineDataProcessor(ICoffeeCountStore coffeecountstore)
        {
            _coffeeCountStore = coffeecountstore;

        }
        public void ProcessItems(MachineDataItem[] dataItems) 
        {
            //_previousItem = null;
            _countPerCoffeeType.Clear();

            foreach(var dataItem in dataItems)
            {
                ProcessItem(dataItem);
            }
            SaveCountPerCoffeeType();
        }
        private void ProcessItem(MachineDataItem dataItem)
        {
            if (!IsNewerThanPreviousItem(dataItem))
            {
                return;
            }
            if (!_countPerCoffeeType.ContainsKey(dataItem.CoffeeType))
            {
                _countPerCoffeeType.Add(dataItem.CoffeeType, 1);
            }
            else
            {
                _countPerCoffeeType[dataItem.CoffeeType]++;
            }
            _previousItem = dataItem;
        }


        private bool IsNewerThanPreviousItem(MachineDataItem dataItem)
        {
            return _previousItem is null
                || _previousItem.createdAt < dataItem.createdAt;
        }
        private void SaveCountPerCoffeeType()
        {
            foreach (var entry in _countPerCoffeeType)
            {
                var line = $"{entry.Key}{entry.Value}";
                Console.WriteLine(line);

                _coffeeCountStore.Save(new CoffeeCountItem(entry.Key, entry.Value));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredCoffeeMachine.DataProcessor.Model;
using System.Globalization;
namespace WiredCoffeeMachine.DataProcessor.Parsing
{
    public class CsvLineParser
    {

        public static MachineDataItem[] Parse(string[] csvlines)
        {
            var machineDataItems = new List<MachineDataItem>();

            foreach (var csvLine in csvlines)
            {
                if (string.IsNullOrWhiteSpace(csvLine))
                {
                    continue;
                }
                var machineDatatItem = Parse(csvLine);
                    machineDataItems.Add(machineDatatItem); 
            }
            return machineDataItems.ToArray();
        
        }
        private static MachineDataItem Parse(string csvLine) 
        {
           // var lineItems = csvLine.Split(";");
            //if (lineitems.length != 2)
            //{
            //    throw new exception($"invalid csv line: {csvline}");
            //}
          //  return new machinedataitem(lineitems[0], datetime.parse(lineitems[1]));
            var lineItems = csvLine.Split(';');

            if (lineItems.Length != 2)
            {
                throw new Exception($"Invalid csv line: {csvLine}");
            }

            if (!DateTime.TryParse(lineItems[1], CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out DateTime dateTime))
            {
                throw new Exception($"Invalid datetime in csv line: {csvLine}");
            }

            return new MachineDataItem(lineItems[0], dateTime);

        }
    }
}

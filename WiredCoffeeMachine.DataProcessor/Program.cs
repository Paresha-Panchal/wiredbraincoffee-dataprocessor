using WiredCoffeeMachine.DataProcessor.Data;
using WiredCoffeeMachine.DataProcessor.Model;
using WiredCoffeeMachine.DataProcessor.Parsing;
using WiredCoffeeMachine.DataProcessor.Processing;

Console.WriteLine("---------------------------------------------");
Console.WriteLine("     Wired Brain Coffee - Data Processor     ");
Console.WriteLine("---------------------------------------------");
Console.WriteLine();

const string fileName = "C:\\Users\\PareshaPanchal\\source\\repos\\WiredCoffeeMachine.DataProcessor\\WiredCoffeeMachine.DataProcessor\\Processing\\CoffeeMachineData.csv";
string[] csvLines = File.ReadAllLines(fileName);

MachineDataItem[] machineDatatItems = CsvLineParser.Parse(csvLines);

var machineDataProcessor = new MachineDataProcessor();
Console.WriteLine();
Console.WriteLine($"File {fileName} was sucessfully processed!");
Console.ReadLine();
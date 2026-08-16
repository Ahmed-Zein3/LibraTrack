using LibraTrack.Models;

namespace LibraTrack.Demos
{
    public class ValueReferenceDemo
    {
        public static void Run()
        {
            Console.WriteLine("========Struct VS Record==== \n");

            // Structs are value types, so when you assign one struct to another, a copy of the value is made.
            LoanPeriod period1 = new();
            period1.DueDate = DateTime.UtcNow.AddDays(14);
            LoanPeriod period2 = period1;

            Console.WriteLine($"Period 1 Due Date: {period1.DueDate}, Period 2 Due Date: {period2.DueDate}");
            period2.DueDate = DateTime.UtcNow.AddDays(7);
            Console.WriteLine("=======After Change=======\n");
            Console.WriteLine($"Period 1 Due Date: {period1.DueDate}, Period 2 Due Date: {period2.DueDate}");
            Console.WriteLine();

            Console.WriteLine("========  Record  ======\n");

            // Classes are reference types, so assigning one class variable to another
            // makes both variables refer to the same object in memory.

            LoanRecord record1 = new();
            record1.DueDate = DateTime.UtcNow.AddDays(14);
            LoanRecord record2 = record1;
            Console.WriteLine($"record 1 Due Date: {record1.DueDate}, record 2 Due Date: {record2.DueDate}");
            Console.WriteLine("=======After Change=======\n");
            record2.DueDate = DateTime.UtcNow.AddDays(7);
            Console.WriteLine($"record 1 Due Date: {record1.DueDate}, record 2 Due Date: {record2.DueDate}");

        }
    }
}

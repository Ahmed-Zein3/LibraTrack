using LibraTrack.Core.Entities;



namespace LibraTrack.Demos
{
    public class OopDemo
    {
        public static void DisplayLibraryItems()
        {
            List<LibraryItem> items = new()
            {
                new Book { ItemId = 1, Title = "The Great Gatsby" },
                new Dvd { ItemId = 2, Title = "Inception" },
                new Magazine { ItemId = 3, Title = "National Geographic"}
            };

            foreach (var item in items)
            {
                Console.WriteLine($"Item ID: {item.ItemId}, Title: {item.Title}, Loan Period: " +
                    $"{item.GetLoanPeriodDays()} days \n");
            }
        }
    }
}

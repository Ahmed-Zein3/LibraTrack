using LibraTrack.Demos;
using LibraTrack.Exceptions;
using LibraTrack.Models;
using LibraTrack.Services;


namespace LibraTrack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayLibraryItems();

            Console.WriteLine();

            ValueReferenceDemo.Run();

            Console.WriteLine();

            TryCatchTests();

            Console.WriteLine();

            TestLoanLimit();

            Console.WriteLine();

            TestCheckoutAndReturn();
        }

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


        public static void TryCatchTests()
        {
            Member member = new()
            {
                MemberId = 1,
                Name = "Ahmed",
                Email = "ahmed@example.com"
            };

            LibraryItem item = new Book
            {
                ItemId = 1,
                Title = "The Great Gatsby"
            };

            Catalog catalog = new();
            catalog.AddItem(item);

            try
            {
                catalog.Checkout(member, item);
            }
            catch (ItemNotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public static void TestLoanLimit()
        {
            Member member1 = new()
            {
                MemberId = 2,
                Name = "Test Member",
                Email = "test@example.com"
            };

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    member1.Borrow();
                }
            }
            catch (MemberLoanLimitExceededException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestCheckoutAndReturn()
        {
            Member member2 = new()
            {
                MemberId = 12,
                Name = "Test Member",
                Email = "test@example.com"
            };

            LibraryItem item = new Book
            {
                ItemId = 5,
                Title = "Song Of Ice And Fire"
            };

            Catalog catalog = new();

            catalog.AddItem(item);

            catalog.Checkout(member2, item);

            Console.WriteLine($"Active Loans: {member2.ActiveLoanCount}");
            Console.WriteLine($"Item Available: {item.IsAvailable}\n");

            catalog.Return(member2, item);
            Console.WriteLine($"Active Loans: {member2.ActiveLoanCount}");
            Console.WriteLine($"Item Available: {item.IsAvailable}");
        }









    }
}

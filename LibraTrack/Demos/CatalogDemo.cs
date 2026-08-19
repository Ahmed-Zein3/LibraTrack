using LibraTrack.Core.Entities;

using LibraTrack.Services;

namespace LibraTrack.Demos
{
    public class CatalogDemo
    {


        public static async Task TestCatalogAdd(Catalog catalog)
        {
            Book book = new()
            {
                Title = "Clean Code"
            };
            await catalog.AddItemAsync(book);
        }
        public static async Task TestCatalogGetAll(Catalog catalog)
        {
            var items = await catalog.GetAllAsync();
            foreach (var item in items)
            {
                Console.WriteLine($"Item ID: {item.ItemId}, Title: {item.Title}");
            }
        }

        //public static async Task TestCatalogCheckout(Catalog catalog, int memberId, int itemId)
        //{
        //    var member = await catalog.GetMemberByIdAsync(memberId);
        //    var item = await catalog.GetByIdAsync(itemId);

        //    if (member != null && item != null)
        //    {
        //        await catalog.CheckoutAsync(member, item);
        //    }
        //}

        //public static async Task TestCatalogReturn(Catalog catalog, int memberId, int itemId)
        //{
        //    var member = await catalog.GetMemberByIdAsync(memberId);
        //    var item = await catalog.GetByIdAsync(itemId);

        //    if (member != null && item != null)
        //    {
        //        await catalog.ReturnAsync(member, item);
        //    }
        //}


        public static async Task TestOpenLoansQuery(Catalog catalog)
        {
            var loans = await catalog.GetOpenLoansAsync();

            foreach (var loan in loans)
            {
                Console.WriteLine(
                    $"Loan ID: {loan.LoanId}, Member ID: {loan.MemberId}, " +
                    $"Item ID: {loan.ItemId}, Due Date: {loan.DueDate}");
            }
        }

        public static async Task TestStoredProcedureCheckout(Catalog catalog)
        {
            await catalog.CheckoutUsingStoredProcedureAsync(1, 2);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using LibraTrack.Data;
using LibraTrack.Exceptions;
using LibraTrack.Models;


namespace LibraTrack.Services
{
    public class Catalog
    {
        //private Dictionary<int, LibraryItem> _items = new();
        private readonly LibraryDbContext _context;

        public Catalog(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(LibraryItem item)
        {
            await _context.LibraryItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<LibraryItem?> GetByIdAsync(int itemId)
        {
            return await _context.LibraryItems
                .FindAsync(itemId);
        }
        public async Task<Member?> GetMemberByIdAsync(int memberId)
        {
            return await _context.Members.FindAsync(memberId);
        }
        public async Task<List<LibraryItem>> GetAllAsync()
        {
            return await _context.LibraryItems.ToListAsync();
        }

        //public void Checkout(Member member, LibraryItem item)
        //{
        //    if(item.IsAvailable == false)
        //    {
        //        throw new ItemNotAvailableException("Item is not available.");
        //    }
        //    member.Borrow();
        //    item.Checkout();
        //}
        public async Task CheckoutAsync(Member member, LibraryItem item)
        {
            if (!item.IsAvailable)
            {
                throw new ItemNotAvailableException("Item is not available.");
            }

            member.Borrow();
            item.Checkout();

            LoanRecord loan = new()
            {
                MemberId = member.MemberId,
                ItemId = item.ItemId,
                DueDate = DateTime.UtcNow.AddDays(item.GetLoanPeriodDays())
            };

            await _context.Loans.AddAsync(loan);

            await _context.SaveChangesAsync();
        }

        public async Task ReturnAsync(Member member, LibraryItem item)
        {
            member.ReturnLoan();
            item.Return();

            var loan = await _context.Loans
                .FirstOrDefaultAsync(l =>
                    l.MemberId == member.MemberId &&
                    l.ItemId == item.ItemId &&
                    l.ReturnedDate == null);

            if (loan != null)
            {
                loan.ReturnedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<LoanRecord>> GetOpenLoansAsync()
        {
            return await _context.Loans
                .Where(l => l.ReturnedDate == null)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.LibraryItems
                .OfType<Book>()
                .ToListAsync();
        }

        public async Task<List<LibraryItem>> SearchByTitleAsync(string title)
        {
            return await _context.LibraryItems
                .Where(item => item.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<List<LibraryItem>> GetAvailableItemsAsync()
        {
            return await _context.LibraryItems
                .Where(item => item.IsAvailable)
                .ToListAsync();
        }

        public async Task<LibraryItem?> FindByTitleAsync(string title)
        {
            return await _context.LibraryItems
                .FirstOrDefaultAsync(item => item.Title == title);
        }
        public async Task<bool> HasAvailableItemsAsync()
        {
            return await _context.LibraryItems
                .AnyAsync(item => item.IsAvailable);
        }

        public async Task<int> GetAvailableItemCountAsync()
        {
            return await _context.LibraryItems
                .CountAsync(item => item.IsAvailable);
        }

        public async Task<List<LibraryItem>> GetItemsSortedByTitleAsync()
        {
            return await _context.LibraryItems
                .OrderBy(item => item.Title)
                .ToListAsync();
        }

        public async Task<List<Member>> GetMembersWithMultipleLoansAsync()
        {
            return await _context.Members
                .Where(m => _context.Loans
                    .Count(l => l.MemberId == m.MemberId && l.ReturnedDate == null) > 1)
                .ToListAsync();
        }

        public async Task<List<LoanRecord>> GetOverdueLoansAsync()
        {
            return await _context.Loans
                .Where(l => l.ReturnedDate == null && l.DueDate < DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task CheckoutUsingStoredProcedureAsync(int memberId, int itemId)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC dbo.sp_CheckoutItem @MemberId = {memberId}, @ItemId = {itemId}");
        }
    }
}

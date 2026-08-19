using LibraTrack.Core.Entities;
using LibraTrack.Core.Interfaces;
using LibraTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraTrack.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<LoanRecord?> GetByIdAsync(int loanId)
        {
            return await _context.Loans.FindAsync(loanId);
        }

        public async Task<List<LoanRecord>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task AddAsync(LoanRecord loan)
        {
            await _context.Loans.AddAsync(loan);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<LoanRecord?> GetOpenLoanAsync(int memberId, int itemId)
        {
            return await _context.Loans
                .FirstOrDefaultAsync(l =>
                    l.MemberId == memberId &&
                    l.ItemId == itemId &&
                    l.ReturnedDate == null);
        }
    }
}
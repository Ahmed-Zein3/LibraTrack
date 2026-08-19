using LibraTrack.Core.Entities;
using LibraTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraTrack.Services
{
    public class ReportingService
    {
        private readonly LibraryDbContext _context;

        public ReportingService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetMembersWithMultipleLoansAsync()
        {
            return await _context.Members
                .Where(m => _context.Loans
                    .Count(l =>
                        l.MemberId == m.MemberId &&
                        l.ReturnedDate == null) > 1)
                .ToListAsync();
        }

        public async Task<List<LoanRecord>> GetOverdueLoansAsync()
        {
            return await _context.Loans
                .Where(l =>
                    l.ReturnedDate == null &&
                    l.DueDate < DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
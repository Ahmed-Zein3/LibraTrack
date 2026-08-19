using LibraTrack.Core.Entities;

namespace LibraTrack.Core.Interfaces
{
    public interface ILoanRepository
    {
        Task<LoanRecord?> GetByIdAsync(int loanId);

        Task<List<LoanRecord>> GetAllAsync();

        Task AddAsync(LoanRecord loan);

        Task<LoanRecord?> GetOpenLoanAsync(int memberId, int itemId);

        Task SaveChangesAsync();

        
    }
}
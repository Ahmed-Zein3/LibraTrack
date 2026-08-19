using LibraTrack.Core.Entities;
using LibraTrack.Core.Exceptions;
using LibraTrack.Core.Interfaces;

namespace LibraTrack.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

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

            await _loanRepository.AddAsync(loan);
            await _loanRepository.SaveChangesAsync();
        }

        public async Task ReturnAsync(Member member, LibraryItem item)
        {
            var loan = await _loanRepository.GetOpenLoanAsync(
                member.MemberId,
                item.ItemId);

            if (loan == null)
            {
                return;
            }

            member.ReturnLoan();
            item.Return();

            loan.ReturnedDate = DateTime.UtcNow;

            await _loanRepository.SaveChangesAsync();
        }
    }
}
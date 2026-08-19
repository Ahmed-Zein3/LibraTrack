using LibraTrack.Core.Entities;
namespace LibraTrack.Core.Entities
{
    public class Dvd : LibraryItem
    {
        public override int GetLoanPeriodDays()
        {
            return 5; // Default loan period of 5 days for DVDs
        }
    }
}

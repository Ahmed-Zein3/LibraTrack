


namespace LibraTrack.Core.Entities
{
    public class Book : LibraryItem
    {
        public override int GetLoanPeriodDays()
        {
            return 14; // Default loan period of 14 days
        }
    }
}

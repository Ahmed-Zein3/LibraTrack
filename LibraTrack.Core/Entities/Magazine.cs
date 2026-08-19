
namespace LibraTrack.Core.Entities
{
   public class Magazine : LibraryItem
    {
       public override int GetLoanPeriodDays()
        {
            return 3; // Default loan period of 3 days for magazines
        }
    }
}


using LibraTrack.Core.Entities;
namespace LibraTrack.Core.Exceptions
{
   public class MemberLoanLimitExceededException:Exception
    {
        public MemberLoanLimitExceededException (string message):base(message)
            {

        }
    }
}

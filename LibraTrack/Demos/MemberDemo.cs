
using LibraTrack.Core.Entities;
using LibraTrack.Core.Exceptions;

namespace LibraTrack.Demos
{
    public class MemberDemo
    {
        public static void TestLoanLimit()
        {
            Member member1 = new()
            {
                MemberId = 2,
                Name = "Test Member",
                Email = "test@example.com"
            };

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    member1.Borrow();
                }
            }
            catch (MemberLoanLimitExceededException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

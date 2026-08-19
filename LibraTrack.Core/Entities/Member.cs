using LibraTrack.Core.Exceptions;
namespace LibraTrack.Core.Entities
{
    public class Member
    {
        private int _memberId;
        public int MemberId
        {
            get { return _memberId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Member ID must be greater than zero.");
                }
                _memberId = value;
            }
        }

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _name = value;
            }
        }


        private string _email = string.Empty;
        public string Email
        { 
            get { return _email; }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Invalid email address.");
                }
                _email = value;
            }

        }

        public int LoanLimit { get; private set; } = 5;
        public int ActiveLoanCount { get; private set; }

        public void Borrow()
        {
            if(ActiveLoanCount >= LoanLimit)
            {
                throw new MemberLoanLimitExceededException("you hit the loan limit");
            }
            ActiveLoanCount++;
        }

        public void ReturnLoan()
        {
            if(ActiveLoanCount > 0)
            {
                ActiveLoanCount--;

            }
        }
    }



}

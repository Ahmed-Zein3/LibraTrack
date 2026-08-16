using LibraTrack.Interfaces;
namespace LibraTrack
{
    public abstract class LibraryItem: IBorrowable
    {
        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Item ID must be greater than zero.");
                }
                _itemId = value;
            }
        }

        private string _title= string.Empty;

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty.");
                }
                _title = value;
            }
        }
        public bool IsAvailable { get; private set; } = true;


        public void Checkout()
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("Item is not available.");
            }
            IsAvailable = false;
        }

        public void Return()
        {   
            IsAvailable = true;
        }

        public virtual int GetLoanPeriodDays()
        {
                        return 14; // Default loan period of 14 days
        }



    }






}


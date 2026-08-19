namespace LibraTrack.Core.Interfaces
{
    public interface IBorrowable
    {
        void Checkout();
        void Return();
    }
}
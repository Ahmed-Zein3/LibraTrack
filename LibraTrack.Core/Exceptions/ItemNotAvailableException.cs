using LibraTrack.Core.Entities;

namespace LibraTrack.Core.Exceptions
{
    public class ItemNotAvailableException : Exception
    {
        public ItemNotAvailableException(string message) : base(message)
        {

        }
    }
}


using LibraTrack.Exceptions;
using LibraTrack.Models;

namespace LibraTrack.Services
{
    public class Catalog
    {
        private Dictionary<int, LibraryItem> _items = new();

        public void AddItem(LibraryItem item)
        {
            _items[item.ItemId] = item;
        }

        public LibraryItem? GetById(int itemId)
        {
            if (_items.TryGetValue(itemId, out var item))
            {
                return item;
            }
            return null;
        }

        public IEnumerable<LibraryItem> GetAll()
        {
            return _items.Values;
        }

        public void Checkout(Member member, LibraryItem item)
        {
            if(item.IsAvailable == false)
            {
                throw new ItemNotAvailableException("Item is not available.");
            }
            member.Borrow();
            item.Checkout();
        }

        public void Return(Member member, LibraryItem item)
        {
            member.ReturnLoan();
            item.Return();  
        }


    }
}

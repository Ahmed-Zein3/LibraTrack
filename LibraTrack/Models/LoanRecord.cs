namespace LibraTrack.Models
{
    public class LoanRecord
    {
        public int LoanId { get; set; }

        public int MemberId { get; set; }
        public int ItemId { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public Member Member { get; set; } = null!;
        public LibraryItem Item { get; set; } = null!;
    }
}
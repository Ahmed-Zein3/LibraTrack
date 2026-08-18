using Microsoft.EntityFrameworkCore;
using LibraTrack.Data;
using LibraTrack.Models;


namespace LibraTrack.Demos
{
    public class EfCoreDemo
    {
        public static async Task TestAddMember()
        {
            using LibraryDbContext context = new();
            Member member = new()
            {

                Name = "Ahmed Zein",
                Email = "ahmed.zein@example.com"
            };
            context.Members.Add(member);
            await context.SaveChangesAsync();
        }

        public static async Task TestGetMembers()
        {
            using LibraryDbContext context = new();
            var members = await context.Members.ToListAsync();
            foreach (var member in members)
            {
                Console.WriteLine($"Member ID: {member.MemberId}, Name: {member.Name}, Email: {member.Email}");
            }
        }
        public static async Task TestFindMember()
        {
            using LibraryDbContext context = new();
            var findMember = await context.Members
                          .FirstOrDefaultAsync(m => m.Email == "ahmedzein@example.com");
            if (findMember != null)
            {
                Console.WriteLine($"Member ID: {findMember.MemberId}, Name: {findMember.Name}, Email: {findMember.Email}");
            }
        }
    }
}

using Communicator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Communicator.Infrastructure.Data
{
    public class CommunicatorContext : DbContext
    {
        public CommunicatorContext(DbContextOptions<CommunicatorContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Chat>().ToTable("Chat");
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}
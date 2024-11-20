using Microsoft.EntityFrameworkCore;
using PasswordHashing.Models;

namespace PasswordHashing.Data
{
    public class PasswordDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public PasswordDbContext(DbContextOptions<PasswordDbContext> options) : base(options) { }
    }
}
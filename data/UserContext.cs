using Microsoft.EntityFrameworkCore;
using PeopleApi.Models;
using System.Collections.Generic;

namespace PeopleApi.data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
    }
}

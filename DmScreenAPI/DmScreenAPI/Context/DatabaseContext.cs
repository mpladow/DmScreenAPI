using DmScreenAPI.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<CreatureCard> CreatureCards {get; set;}
        public DbSet<CreatureAction> CreatureAction { get; set; }
        public DbSet<CreatureCardAction> CreatureCardActions { get; set; }
        //the below tables hold session information
        public DbSet<AccountCreatureCard> AccountCreatureCards { get; set; }
        public DbSet<AccountResource> AccountResources { get; set; }
        public DbSet<AccountNotes> AccountNotes { get; set; }


    }
}

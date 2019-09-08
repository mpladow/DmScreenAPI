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
        public DbSet<Cheatsheet> Cheatsheets { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<CreatureCard> CreatureCards {get; set;}
        public DbSet<AccountCreatureCard> AccountCreatureCards { get; set; }
        public DbSet<AccountResource> AccountResources { get; set; }
        public DbSet<AccountNotes> AccountNotes { get; set; }
        public DbSet<System.Action> Actions { get; set; }


    }
}

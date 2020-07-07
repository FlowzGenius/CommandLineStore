using CommandLineStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CommandLineStore.DataContext
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> opt) : base(opt)
        {

        }

        public DbSet<CommandLine> CommandLines { get; set; }
    }
}

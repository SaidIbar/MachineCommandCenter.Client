using MachineCommandCenter.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MachineCommandCenter.Shared.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Machine> Machines { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Machine>().HasData(new Machine
            {

                MachineId = Guid.NewGuid(),
                Name = "Telehandler",
                MachineStatus = MachineStatus.Offline,
                SentDataDateTime = new DateTime(2021 - 11 - 01)
            });

            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Single Man Lift",
                MachineStatus = MachineStatus.Online,
                SentDataDateTime = new DateTime(2021 - 11 - 01)
            });
            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Wheel Tractor-Scraper",
                MachineStatus = MachineStatus.Offline,
                SentDataDateTime = new DateTime(2021 - 11 - 01)
            });

            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Skid Steer Loader",
                MachineStatus = MachineStatus.Online,
                SentDataDateTime = new DateTime(2021 - 11 - 01)
            });
            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Scissor Lift",
                MachineStatus = MachineStatus.Online,
                SentDataDateTime = new DateTime(2021 - 11 - 01)
            });

            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Forklift",
                MachineStatus = MachineStatus.Offline,
                SentDataDateTime = new DateTime(2021 - 10 - 30)
            });
            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Bulldozer",
                MachineStatus = MachineStatus.Offline,
                SentDataDateTime = new DateTime(2021 - 10 - 31)
            });

            modelBuilder.Entity<Machine>().HasData(new Machine
            {
                MachineId = Guid.NewGuid(),
                Name = "Backhoe Loader",
                MachineStatus = MachineStatus.Online,
                SentDataDateTime = new DateTime(2021 - 11 - 01)
            });
        }

        private static Guid GuidFromString(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(input));
                return new Guid(hash);
            }
        }
    }
}

using ComputerHardwareGuide.DAL.Models;
using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.DAL.Models.Components.CPUs;
using ComputerHardwareGuide.DAL.Models.Components.GPUs;
using ComputerHardwareGuide.DAL.Models.Components.Motherboards;
using ComputerHardwareGuide.DAL.Models.Components.PowerUnits;
using ComputerHardwareGuide.DAL.Models.Components.RAMs;
using ComputerHardwareGuide.DAL.Models.Components.ROMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ComputerHardwareGuide.DAL
{
    public class AppContext : DbContext, IAppContext
    {
        private string _connectionString;

        public DbSet<Firm> Firms { get; set; }
        public DbSet<FirmComponentType> FirmComponentTypes { get; set; }
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }
        public DbSet<LookupComponentType> LookupComponentTypes { get; set; }

        public DbSet<ComponentPicture> ComponentPictures { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<LookupComponentType> LookupComponentType { get; set; }
        public DbSet<ComponentCPU> ComponentCPUs { get; set; }
        public DbSet<ComponentRAM> ComponentRAMs { get; set; }
        public DbSet<ComponentGPU> ComponentGPUs { get; set; }
        public DbSet<ComponentHDD> ComponentHDDs { get; set; }
        public DbSet<ComponentSSD> ComponentSSDs { get; set; }
        public DbSet<ComponentPowerUnit> ComponentPowerUnits { get; set; }
        public DbSet<PowerSupport> PowerSupports { get; set; }
        public DbSet<ComponentMotherboard> ComponentMotherboards { get; set; }
        public DbSet<MotherboardInterface> MotherboardInterfaces { get; set; }

        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<AssemblyComponent> AssemblyComponents { get; set; }


        public AppContext(string connectionString, bool isCreated = true)
        {
            _connectionString = connectionString;
            if (!isCreated)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentType>()
                        .Property(e => e.Id)
                        .HasConversion<int>();

            modelBuilder.Entity<ComponentType>().HasData(
                Enum.GetValues(typeof(ComponentTypeEnumeration))
                    .Cast<ComponentTypeEnumeration>()
                    .Select(e => new ComponentType()
                    {
                        Id = (int)e,
                        Name = e.ToString()
                    })
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

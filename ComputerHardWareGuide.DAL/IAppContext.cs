using ComputerHardwareGuide.DAL.Models;
using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.DAL.Models.Components.CPUs;
using ComputerHardwareGuide.DAL.Models.Components.GPUs;
using ComputerHardwareGuide.DAL.Models.Components.Motherboards;
using ComputerHardwareGuide.DAL.Models.Components.PowerUnits;
using ComputerHardwareGuide.DAL.Models.Components.RAMs;
using ComputerHardwareGuide.DAL.Models.Components.ROMs;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerHardwareGuide.DAL
{
    public interface IAppContext
    {
        DbSet<Firm> Firms { get; set; }
        DbSet<FirmComponentType> FirmComponentTypes { get; set; }
        DbSet<Lookup> Lookups { get; set; }
        DbSet<LookupValue> LookupValues { get; set; }
        DbSet<LookupComponentType> LookupComponentTypes { get; set; }
        DbSet<ComponentPicture> ComponentPictures { get; set; }
        DbSet<ComponentType> ComponentTypes { get; set; }
        DbSet<ComponentCPU> ComponentCPUs { get; set; }
        DbSet<ComponentRAM> ComponentRAMs { get; set; }
        DbSet<ComponentGPU> ComponentGPUs { get; set; }
        DbSet<ComponentHDD> ComponentHDDs { get; set; }
        DbSet<ComponentSSD> ComponentSSDs { get; set; }
        DbSet<ComponentPowerUnit> ComponentPowerUnits { get; set; }
        DbSet<PowerSupport> PowerSupports { get; set; }
        DbSet<ComponentMotherboard> ComponentMotherboards { get; set; }
        DbSet<MotherboardInterface> MotherboardInterfaces { get; set; }
        DbSet<Assembly> Assemblies { get; set; }
        DbSet<AssemblyComponent> AssemblyComponents { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

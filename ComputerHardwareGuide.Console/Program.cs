using ComputerHardwareGuide.DAL.Models;
using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.DAL.Models.Components.CPUs;
using ComputerHardwareGuide.DAL.Models.Components.GPUs;
using ComputerHardwareGuide.DAL.Models.Components.Motherboards;
using ComputerHardwareGuide.DAL.Models.Components.PowerUnits;
using ComputerHardwareGuide.DAL.Models.Components.RAMs;
using ComputerHardwareGuide.DAL.Models.Components.ROMs;
using System.IO;
using System.Linq;

namespace ComputerHardwareGuide.Console
{
    class Program
    {
        const string conn = "Data Source=localhost;Initial Catalog=ComputerGuideDB;Integrated Security=True;";
        static void Main(string[] args)
        {
            using (var context = new DAL.AppContext(conn, false))
            {
                var componentTypes = context.ComponentTypes.AsQueryable().ToList();

                #region Firms
                var firms = new Firm[]
                {
                    new Firm { Name = "Asus"   , Country = "Taiwan"       },
                    new Firm { Name = "AMD"    , Country = "USA"          },
                    new Firm { Name = "Samsung", Country = "South Korea"  },
                    new Firm { Name = "Intel"  , Country = "USA"          },
                    new Firm { Name = "Sapphire" , Country = "USA"        },
                    new Firm { Name = "Gigabyte" , Country = "USA"        },
                    new Firm { Name = "Corsair" , Country = "USA"         },
                    new Firm { Name = "Western Digital" , Country = "USA" },
                };
                context.Firms.AddRange(firms);
                #endregion
                context.SaveChanges();

                #region FirmComponentTypes
                var firmComponentTypes = new FirmComponentType[]
                {
                    new FirmComponentType
                    {
                        Firm = firms[0],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[0],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.Motherboard)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[0],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[1],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[1],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.CPU)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[1],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.HDD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[1],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.SSD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[1],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.RAM)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[2],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.HDD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[2],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.SSD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[2],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.RAM)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[3],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.CPU)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[3],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.HDD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[3],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.SSD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[4],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[5],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.Motherboard)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[6],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.PowerUnit)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[7],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.HDD)
                    },
                    new FirmComponentType
                    {
                        Firm = firms[7],
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.SSD)
                    },
                };
                context.FirmComponentTypes.AddRange(firmComponentTypes);
                #endregion
                context.SaveChanges();

                #region Lookups
                var lookups = new Lookup[]
                {
                    new Lookup { Key = "socket"           , Name = "Socket"               },
                    new Lookup { Key = "processorFamily"  , Name = "Processor family"     },
                    new Lookup { Key = "ramType"          , Name = "RAM Type"             },
                    new Lookup { Key = "process"          , Name = "Process of processor" },
                    new Lookup { Key = "chipset"          , Name = "Chipset"              },
                    new Lookup { Key = "sizeFormFactor"   , Name = "Size form-factor"     },
                    new Lookup { Key = "gpuResolution"    , Name = "GPU Resolution"       },
                    new Lookup { Key = "gpuType"          , Name = "GPU Type"             },
                    new Lookup { Key = "gpuInterface"     , Name = "GPU Interface"        },
                    new Lookup { Key = "powerSupply"      , Name = "Power supply"         },
                    new Lookup { Key = "timings"          , Name = "Timings"              },
                    new Lookup { Key = "romFormFactor"    , Name = "ROM Form-factor"      },
                    new Lookup { Key = "typeOfMemoryCells", Name = "Type of memory cells" },
                    new Lookup { Key = "romInterface"     , Name = "ROM Interface"        },
                };
                context.Lookups.AddRange(lookups);
                #endregion
                context.SaveChanges();

                #region LookupValues
                var lookupValues = new LookupValue[]
                {
                    // Sockets
                    new LookupValue { DisplayText = "AM3", Value = "AM3", Lookup = lookups[0] },
                    new LookupValue { DisplayText = "AM3+", Value = "AM3+", Lookup = lookups[0] },
                    new LookupValue { DisplayText = "AM4", Value = "AM4", Lookup = lookups[0] },
                    new LookupValue { DisplayText = "1150", Value = "1150", Lookup = lookups[0] },
                    new LookupValue { DisplayText = "1151", Value = "1151", Lookup = lookups[0] },
                    // Processor family
                    new LookupValue { DisplayText = "AMD FX-series", Value = "AMD FX-series", Lookup = lookups[1] },
                    new LookupValue { DisplayText = "AMD Ryzen 5", Value = "AMD Ryzen 5", Lookup = lookups[1] },
                    new LookupValue { DisplayText = "AMD Ryzen 7", Value = "AMD Ryzen 7", Lookup = lookups[1] },
                    new LookupValue { DisplayText = "Intel Core i5", Value = "Intel Core i5", Lookup = lookups[1] },
                    new LookupValue { DisplayText = "Intel Core i7", Value = "Intel Core i7", Lookup = lookups[1] },
                    // RAM Type
                    new LookupValue { DisplayText = "DDR3 SDRAM", Value = "DDR3 SDRAM", Lookup = lookups[2] },
                    new LookupValue { DisplayText = "DDR3L SDRAM", Value = "DDR3L SDRAM", Lookup = lookups[2] },
                    new LookupValue { DisplayText = "DDR4 SDRAM", Value = "DDR4 SDRAM", Lookup = lookups[2] },
                    // Process of processor
                    new LookupValue { DisplayText = "14nm", Value = "14nm", Lookup = lookups[3] },
                    new LookupValue { DisplayText = "12nm", Value = "12nm", Lookup = lookups[3] },
                    new LookupValue { DisplayText = "10nm", Value = "10nm", Lookup = lookups[3] },
                    new LookupValue { DisplayText = "7nm", Value = "7nm", Lookup = lookups[3] },
                    // Chipset
                    new LookupValue { DisplayText = "AMD B450", Value = "AMD B450", Lookup = lookups[4] },
                    new LookupValue { DisplayText = "AMD X570", Value = "AMD X570", Lookup = lookups[4] },
                    new LookupValue { DisplayText = "Intel B250", Value = "Intel B250", Lookup = lookups[4] },
                    new LookupValue { DisplayText = "Intel B360", Value = "Intel B360", Lookup = lookups[4] },
                    // Size form-factor
                    new LookupValue { DisplayText = "ATX", Value = "ATX", Lookup = lookups[5] },
                    new LookupValue { DisplayText = "EATX", Value = "EATX", Lookup = lookups[5] },
                    new LookupValue { DisplayText = "Micro-ATX", Value = "Micro-ATX", Lookup = lookups[5] },
                    new LookupValue { DisplayText = "Mini-ATX", Value = "Mini-ATX", Lookup = lookups[5] },
                    // GPU Resolution
                    new LookupValue { DisplayText = "2560x1600", Value = "2560x1600", Lookup = lookups[6] },
                    new LookupValue { DisplayText = "4096x2160", Value = "4096x2160", Lookup = lookups[6] },
                    new LookupValue { DisplayText = "5120x2880", Value = "5120x2880", Lookup = lookups[6] },
                    new LookupValue { DisplayText = "7680x4320", Value = "7680x4320", Lookup = lookups[6] },
                    // GPU Type
                    new LookupValue { DisplayText = "GDDR3", Value = "GDDR3", Lookup = lookups[7] },
                    new LookupValue { DisplayText = "GDDR4", Value = "GDDR4", Lookup = lookups[7] },
                    new LookupValue { DisplayText = "GDDR5", Value = "GDDR5", Lookup = lookups[7] },
                    new LookupValue { DisplayText = "GDDR5X", Value = "GDDR5X", Lookup = lookups[7] },
                    new LookupValue { DisplayText = "GDDR6", Value = "GDDR6", Lookup = lookups[7] },
                    // GPU Interface
                    new LookupValue { DisplayText = "PCI Express 3.0", Value = "PCI Express 3.0", Lookup = lookups[8] },
                    new LookupValue { DisplayText = "PCI-Express 4.0", Value = "PCI-Express 4.0", Lookup = lookups[8] },
                    new LookupValue { DisplayText = "PCI-Express x16", Value = "PCI-Express x16", Lookup = lookups[8] },
                    new LookupValue { DisplayText = "PCI-Express x16 3.0", Value = "PCI-Express x16 3.0", Lookup = lookups[8] },
                    new LookupValue { DisplayText = "PCI-Express x16 4.0", Value = "PCI-Express x16 4.0", Lookup = lookups[8] },
                    // Power supply (GPU)
                    new LookupValue { DisplayText = "6 pin", Value = "6 pin", Lookup = lookups[9] },
                    new LookupValue { DisplayText = "8 pin", Value = "8 pin", Lookup = lookups[9] },
                    new LookupValue { DisplayText = "6+8 pin", Value = "6+8 pin", Lookup = lookups[9] },
                    new LookupValue { DisplayText = "8+8 pin", Value = "8+8 pin", Lookup = lookups[9] },
                    // Power supply (MB)
                    new LookupValue { DisplayText = "24-pin ATX", Value = "24-pin ATX", Lookup = lookups[9] },
                    new LookupValue { DisplayText = "8-pin ATX", Value = "8-pin ATX", Lookup = lookups[9] },
                    new LookupValue { DisplayText = "4-pin ATX", Value = "4-pin ATX", Lookup = lookups[9] },
                    // Timings
                    new LookupValue { DisplayText = "CL15", Value = "CL15", Lookup = lookups[10] },
                    new LookupValue { DisplayText = "CL16", Value = "CL16", Lookup = lookups[10] },
                    new LookupValue { DisplayText = "CL17", Value = "CL17", Lookup = lookups[10] },
                    new LookupValue { DisplayText = "CL18", Value = "CL18", Lookup = lookups[10] },
                    new LookupValue { DisplayText = "CL19", Value = "CL19", Lookup = lookups[10] },
                    // ROM Form-factor
                    new LookupValue { DisplayText = "2.5", Value = "2.5", Lookup = lookups[11] },
                    new LookupValue { DisplayText = "3.5", Value = "3.5", Lookup = lookups[11] },
                    // Type of memory cells
                    new LookupValue { DisplayText = "MLC", Value = "MLC", Lookup = lookups[12] },
                    new LookupValue { DisplayText = "TLC", Value = "TLC", Lookup = lookups[12] },
                    new LookupValue { DisplayText = "3D V-NAND", Value = "3D V-NAND", Lookup = lookups[12] },
                    // ROM Interface
                    new LookupValue { DisplayText = "SATA III", Value = "SATA III", Lookup = lookups[13] },
                    new LookupValue { DisplayText = "M.2", Value = "M.2", Lookup = lookups[13] },
                };
                context.LookupValues.AddRange(lookupValues);
                #endregion
                context.SaveChanges();

                #region LookupComponentType
                var lookupComponentTypes = new LookupComponentType[]
                {
                    new LookupComponentType { Lookup = lookups[0], ComponentType = componentTypes[0] },
                    new LookupComponentType { Lookup = lookups[0], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[1], ComponentType = componentTypes[0] },
                    new LookupComponentType { Lookup = lookups[2], ComponentType = componentTypes[0] },
                    new LookupComponentType { Lookup = lookups[2], ComponentType = componentTypes[1] },
                    new LookupComponentType { Lookup = lookups[2], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[3], ComponentType = componentTypes[0] },
                    new LookupComponentType { Lookup = lookups[4], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[5], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[6], ComponentType = componentTypes[2] },
                    new LookupComponentType { Lookup = lookups[7], ComponentType = componentTypes[2] },
                    new LookupComponentType { Lookup = lookups[8], ComponentType = componentTypes[2] },
                    new LookupComponentType { Lookup = lookups[8], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[9], ComponentType = componentTypes[2] },
                    new LookupComponentType { Lookup = lookups[9], ComponentType = componentTypes[3] },
                    new LookupComponentType { Lookup = lookups[9], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[10], ComponentType = componentTypes[1] },
                    new LookupComponentType { Lookup = lookups[11], ComponentType = componentTypes[5] },
                    new LookupComponentType { Lookup = lookups[12], ComponentType = componentTypes[5] },
                    new LookupComponentType { Lookup = lookups[13], ComponentType = componentTypes[4] },
                    new LookupComponentType { Lookup = lookups[13], ComponentType = componentTypes[5] },
                };
                context.LookupComponentTypes.AddRange(lookupComponentTypes);
                #endregion
                context.SaveChanges();

                #region CPUs
                var cpus = new ComponentCPU[]
                {
                    new ComponentCPU 
                    {
                        CacheL2 = 4,
                        CacheL3 = 32,
                        CorsCount = 8,
                        ThreadsCount = 16,
                        Cost = 6948 / 27,
                        Price = 8600 / 27,
                        InternalClockSpeed = 3.6,
                        MaximumClockSpeed = 4.4,
                        Firm = firms[1],
                        Generation = 3,
                        HasIntegratedGPU = false,
                        Model = "3700X",
                        Name = "AMD Ryzen 7 3700X 3.6GHz/32MB (100-100000071BOX) sAM4",
                        Process = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Process of processor" && x.Value == "7nm"),
                        ProcessorFamily = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Processor family" && x.Value == "AMD Ryzen 7"),
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Socket = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Socket" && x.Value == "AM4"),
                        TDP = 65,
                        YearOfIssue = 2019,
                    },
                    new ComponentCPU
                    {
                        CacheL2 = 3,
                        CacheL3 = 32,
                        CorsCount = 6,
                        ThreadsCount = 12,
                        Cost = 5450 / 27,
                        Price = 6750 / 27,
                        InternalClockSpeed = 3.8,
                        MaximumClockSpeed = 4.4,
                        Firm = firms[1],
                        Generation = 3,
                        HasIntegratedGPU = false,
                        Model = "3600X",
                        Name = "AMD Ryzen 5 3600X 3.8GHz/32MB (100-100000022BOX) sAM4",
                        Process = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Process of processor" && x.Value == "7nm"),
                        ProcessorFamily = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Processor family" && x.Value == "AMD Ryzen 5"),
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Socket = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Socket" && x.Value == "AM4"),
                        TDP = 95,
                        YearOfIssue = 2019,
                    },
                    new ComponentCPU
                    {
                        CacheL2 = 2,
                        CacheL3 = 12,
                        CorsCount = 8,
                        ThreadsCount = 8,
                        Cost = 9788 / 27,
                        Price = 12130 / 27,
                        InternalClockSpeed = 3.6,
                        MaximumClockSpeed = 4.9,
                        Firm = firms[3],
                        Generation = 9,
                        HasIntegratedGPU = true,
                        Model = "9700K",
                        Name = "Intel Core i7 9700K 3.6GHz (12MB, Coffee Lake, 95W, S1151)",
                        Process = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Process of processor" && x.Value == "14nm"),
                        ProcessorFamily = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Processor family" && x.Value == "Intel Core i7"),
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Socket = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Socket" && x.Value == "1151"),
                        TDP = 95,
                        YearOfIssue = 2018,
                    },
                };
                context.ComponentCPUs.AddRange(cpus);
                #endregion
                context.SaveChanges();

                #region GPUs
                var gpus = new ComponentGPU[]
                {
                    new ComponentGPU
                    {
                        Cost = 1877 / 27,
                        Price = 2549 / 27,
                        Firm = firms[0],
                        Name = "Asus PCI-Ex GeForce GT 1030 Phoenix OC 2GB GDDR5 (64bit)",
                        FrequencyOfCore = 1531,
                        FrequencyOfMemory = 6008,
                        Volume = 2,
                        MemoryBandWidth = 64,
                        MinimumPowerNeeds = 280,
                        PowerSupply = null,
                        GPUInterface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Interface" && x.Value == "PCI-Express x16 3.0"),
                        GPUType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Type" && x.Value == "GDDR5"),
                        Resolution = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Resolution" && x.Value == "4096x2160"),
                        Size = "184x111x36",
                        YearOfIssue = 2016,
                    },
                    new ComponentGPU
                    {
                        Cost = 4265 / 27,
                        Price = 4999 / 27,
                        Firm = firms[0],
                        Name = "Asus PCI-Ex GeForce GTX 1050 Ti ROG Strix 4GB GDDR5 (128bit)",
                        FrequencyOfCore = 1392,
                        FrequencyOfMemory = 7008,
                        Volume = 4,
                        MemoryBandWidth = 128,
                        MinimumPowerNeeds = 400,
                        PowerSupply = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "6 pin"),
                        GPUInterface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Interface" && x.Value == "PCI-Express x16 3.0"),
                        GPUType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Type" && x.Value == "GDDR5"),
                        Resolution = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Resolution" && x.Value == "7680x4320"),
                        Size = "241x129x40",
                        YearOfIssue = 2017,
                    },
                    new ComponentGPU
                    {
                        Cost = 11087 / 27,
                        Price = 13099 / 27,
                        Firm = firms[4],
                        Name = "Sapphire PCI-Ex Radeon RX 5700 XT 8G Pulse 8GB GDDR6 (256bit)",
                        FrequencyOfCore = 1925,
                        FrequencyOfMemory = 14000,
                        Volume = 8,
                        MemoryBandWidth = 256,
                        MinimumPowerNeeds = 600,
                        PowerSupply = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "6+8 pin"),
                        GPUInterface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Interface" && x.Value == "PCI-Express x16 4.0"),
                        GPUType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Type" && x.Value == "GDDR6"),
                        Resolution = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Resolution" && x.Value == "5120x2880"),
                        Size = "254x135x46.5",
                        YearOfIssue = 2019,
                    },
                };
                context.ComponentGPUs.AddRange(gpus);
                #endregion
                context.SaveChanges();

                #region Motherboards
                var motherboards = new ComponentMotherboard[]
                {
                    new ComponentMotherboard
                    {
                        Cost = 870 / 27,
                        Price = 1519 / 27,
                        YearOfIssue = 2015,
                        CountOfRAMSlots = 4,
                        Firm = firms[5],
                        MaximumMemoryVolume = 64,
                        Name = "Gigabyte GA-B250M-D3H (s1151, Intel B250, PCI-Ex16)",
                        Size = "244x225",
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Socket = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Socket" && x.Value == "1151"),
                        Chipset = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Chipset" && x.Value == "Intel B250"),
                        SizeFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Size form-factor" && x.Value == "Micro-ATX"),
                    },
                    new ComponentMotherboard
                    {
                        Cost = 2755 / 27,
                        Price = 3025 / 27,
                        YearOfIssue = 2017,
                        CountOfRAMSlots = 4,
                        Firm = firms[0],
                        MaximumMemoryVolume = 64,
                        Name = "Asus TUF B450-Pro Gaming (sAM4, AMD B450, PCI-Ex16)",
                        Size = "305x244",
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Socket = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Socket" && x.Value == "AM4"),
                        Chipset = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Chipset" && x.Value == "AMD B450"),
                        SizeFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Size form-factor" && x.Value == "ATX"),
                    },
                    new ComponentMotherboard
                    {
                        Cost = 4333 / 27,
                        Price = 5287 / 27,
                        YearOfIssue = 2019,
                        CountOfRAMSlots = 4,
                        Firm = firms[5],
                        MaximumMemoryVolume = 64,
                        Name = "Gigabyte X570 Gaming X (sAM4, AMD X570, PCI-Ex16)",
                        Size = "305x244",
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Socket = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Socket" && x.Value == "AM4"),
                        Chipset = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Chipset" && x.Value == "AMD X570"),
                        SizeFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Size form-factor" && x.Value == "ATX"),
                    },
                };
                context.ComponentMotherboards.AddRange(motherboards);
                #endregion
                context.SaveChanges();

                #region Motherboard Interfaces
                var motherboardInterfaces = new MotherboardInterface[]
                {
                    // Gigabyte GA-B250M-D3H (s1151, Intel B250, PCI-Ex16)
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[0],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "24-pin ATX"),
                        Count = 1,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[0],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8-pin ATX"),
                        Count = 1,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[0],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        Count = 6,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[0],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Interface" && x.Value == "PCI-Express x16"),
                        Count = 4,
                    },
                    // Asus TUF B450-Pro Gaming (sAM4, AMD B450, PCI-Ex16)
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[1],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "24-pin ATX"),
                        Count = 1,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[1],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8-pin ATX"),
                        Count = 1,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[1],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        Count = 6,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[1],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Interface" && x.Value == "PCI-Express x16 3.0"),
                        Count = 1,
                    },
                    // Gigabyte X570 Gaming X (sAM4, AMD X570, PCI-Ex16)
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[2],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "24-pin ATX"),
                        Count = 1,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[2],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8-pin ATX"),
                        Count = 1,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[2],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        Count = 6,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[2],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "M.2"),
                        Count = 2,
                    },
                    new MotherboardInterface
                    {
                        ComponentMotherboard = motherboards[2],
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "GPU Interface" && x.Value == "PCI-Express x16 4.0"),
                        Count = 1,
                    },
                };
                context.MotherboardInterfaces.AddRange(motherboardInterfaces);
                #endregion
                context.SaveChanges();

                #region PowerUnits
                var powerUnits = new ComponentPowerUnit[]
                {
                    new ComponentPowerUnit
                    {
                        Cost = 1465 / 27,
                        Price = 1796 / 27,
                        CountOfSATA = 4,
                        FanDiameter = 120,
                        Firm = firms[6],
                        Name = "Corsair CX450 (CP-9020120-EU) 450W",
                        Power = 450,
                        YearOfIssue = 2016,
                    },
                    new ComponentPowerUnit
                    {
                        Cost = 2768 / 27,
                        Price = 3009 / 27,
                        CountOfSATA = 8,
                        FanDiameter = 120,
                        Firm = firms[6],
                        Name = "Corsair CX750 (CP-9020123-EU) 750W",
                        Size = "160х150х86",
                        Power = 750,
                        YearOfIssue = 2018,
                    },
                    new ComponentPowerUnit
                    {
                        Cost = 5634 / 27,
                        Price = 6384 / 27,
                        CountOfSATA = 12,
                        FanDiameter = 135,
                        Firm = firms[6],
                        Name = "Corsair RM1000i (CP-9020084-EU) 1000W",
                        Power = 1000,
                        YearOfIssue = 2019,
                    },
                };
                context.ComponentPowerUnits.AddRange(powerUnits);
                #endregion
                context.SaveChanges();

                #region PowerSupports
                var powerSupports = new PowerSupport[]
                {
                    // Corsair CX450 (CP-9020120-EU) 450W
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[0],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "24-pin ATX"),
                        Count = 1
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[0],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8-pin ATX"),
                        Count = 1
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[0],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "4-pin ATX"),
                        Count = 2
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[0],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8 pin"),
                        Count = 1
                    },
                    // Corsair CX750 (CP-9020123-EU) 750W
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[1],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "24-pin ATX"),
                        Count = 1
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[1],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8-pin ATX"),
                        Count = 1
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[1],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "4-pin ATX"),
                        Count = 2
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[1],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8 pin"),
                        Count = 4
                    },
                    // Corsair RM1000i (CP-9020084-EU) 1000W
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[2],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "24-pin ATX"),
                        Count = 1
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[2],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8-pin ATX"),
                        Count = 2
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[2],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "4-pin ATX"),
                        Count = 4
                    },
                    new PowerSupport
                    {
                        ComponentPowerUnit = powerUnits[2],
                        PowerConnection = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Power supply" && x.Value == "8 pin"),
                        Count = 8
                    },
                };
                context.PowerSupports.AddRange(powerSupports);
                #endregion
                context.SaveChanges();

                #region RAMs
                var rams = new ComponentRAM[]
                {
                    new ComponentRAM
                    {
                        Cost = 1004 / 27,
                        Price = 1210 / 27,
                        Name = "AMD DDR4-3000 8192MB PC4-24000 R9",
                        Firm = firms[1],
                        Frequency = 3000,
                        HasRadiators = true,
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Timings = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Timings" && x.Value == "CL16"),
                        Volume = 8,
                        YearOfIssue = 2017,
                    },
                    new ComponentRAM
                    {
                        Cost = 2458 / 27,
                        Price = 2999 / 27,
                        Name = "Samsung DDR4-2933 16GB PC4-23500 ECC",
                        Firm = firms[2],
                        Frequency = 2933,
                        HasRadiators = false,
                        RAMType = lookupValues.FirstOrDefault(x => x.Lookup.Name == "RAM Type" && x.Value == "DDR4 SDRAM"),
                        Timings = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Timings" && x.Value == "CL17"),
                        Volume = 16,
                        YearOfIssue = 2016,
                    },
                };
                context.ComponentRAMs.AddRange(rams);
                #endregion
                context.SaveChanges();

                #region HDDs
                var hdds = new ComponentHDD[]
                {
                    new ComponentHDD
                    {
                        Cost = 1359 / 27,
                        Price = 1509 / 27,
                        Name = "Western Digital Purple 1TB 64MB 5400rpm WD10PURZ",
                        Firm = firms[7],
                        MeanTimeBetweenFailures = 1000000,
                        Volume = 1000,
                        ReadingSpeed = 210,
                        WritingSpeed = 210,
                        ReadOnlyMemoryFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Form-factor" && x.Value == "3.5"),
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        RotationSpeedPerMinute = 5400,
                        Size = "101,6x26,1х147",
                        Weight = 550,
                        YearOfIssue = 2016,
                    },
                    new ComponentHDD
                    {
                        Cost = 2200 / 27,
                        Price = 2355 / 27,
                        Name = "Western Digital Gold 1TB 7200rpm 128MB WD1005FBYZ",
                        Firm = firms[7],
                        MeanTimeBetweenFailures = 2000000,
                        Volume = 1000,
                        ReadingSpeed = 286,
                        WritingSpeed = 286,
                        ReadOnlyMemoryFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Form-factor" && x.Value == "3.5"),
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        RotationSpeedPerMinute = 7200,
                        Size = "101.6x26.1x147",
                        Weight = 641,
                        YearOfIssue = 2018,
                    },
                };
                context.ComponentHDDs.AddRange(hdds);
                #endregion
                context.SaveChanges();

                #region SSDs
                var ssds = new ComponentSSD[]
                {
                    new ComponentSSD
                    {
                        Cost = 1300 / 27,
                        Price = 1499 / 27,
                        Name = "Samsung 860 Evo-Series 250GB 2.5\" SATA III",
                        Firm = firms[2],
                        MeanTimeBetweenFailures = 1500000,
                        Volume = 250,
                        ReadingSpeed = 550,
                        WritingSpeed = 520,
                        ReadOnlyMemoryFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Form-factor" && x.Value == "2.5"),
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        TypeOfCellMemory = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Type of memory cells" && x.Value == "MLC"),
                        Size = "100x69.85x6.8",
                        Weight = 51,
                        YearOfIssue = 2017,
                    },
                    new ComponentSSD
                    {
                        Cost = 2650 / 27,
                        Price = 2875 / 27,
                        Name = "Samsung PM883 Enterprise 240GB 2.5\" SATA III",
                        Firm = firms[2],
                        MeanTimeBetweenFailures = 2000000,
                        Volume = 240,
                        ReadingSpeed = 550,
                        WritingSpeed = 320,
                        ReadOnlyMemoryFormFactor = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Form-factor" && x.Value == "2.5"),
                        Interface = lookupValues.FirstOrDefault(x => x.Lookup.Name == "ROM Interface" && x.Value == "SATA III"),
                        TypeOfCellMemory = lookupValues.FirstOrDefault(x => x.Lookup.Name == "Type of memory cells" && x.Value == "TLC"),
                        Size = "100.2x69.85x7.17",
                        Weight = 50,
                        YearOfIssue = 2018,
                    },
                };
                context.ComponentSSDs.AddRange(ssds);
                #endregion
                context.SaveChanges();

                #region Component Pictures
                var currentDirectory = @"C:\Users\Asus\source\repos\ComputerHardwareGuide\ComputerHardwareGuide\ComputerHardwareGuide.Console\Images";
                var pictures = new ComponentPicture[]
                {
                    // CPUs
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.CPU),
                        ComponentId = cpus[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "CPUs", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.CPU),
                        ComponentId = cpus[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "CPUs", "2.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.CPU),
                        ComponentId = cpus[2].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "CPUs", "3.jpg")),
                    },
                    // GPUs
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU),
                        ComponentId = gpus[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "GPUs", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU),
                        ComponentId = gpus[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "GPUs", "2.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.GPU),
                        ComponentId = gpus[2].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "GPUs", "3.jpg")),
                    },
                    // Motherboards
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.Motherboard),
                        ComponentId = motherboards[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "Motherboards", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.Motherboard),
                        ComponentId = motherboards[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "Motherboards", "2.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.Motherboard),
                        ComponentId = motherboards[2].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "Motherboards", "3.jpg")),
                    },
                    // PowerUnits
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.PowerUnit),
                        ComponentId = powerUnits[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "PowerUnits", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.PowerUnit),
                        ComponentId = powerUnits[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "PowerUnits", "2.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.PowerUnit),
                        ComponentId = powerUnits[2].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "PowerUnits", "3.jpg")),
                    },
                    // RAMs
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.RAM),
                        ComponentId = rams[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "RAMs", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.RAM),
                        ComponentId = rams[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "RAMs", "2.jpg")),
                    },
                    // HDDs
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.HDD),
                        ComponentId = hdds[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "HDDs", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.HDD),
                        ComponentId = hdds[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "HDDs", "2.jpg")),
                    },
                    // SSDs
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.SSD),
                        ComponentId = ssds[0].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "SSDs", "1.jpg")),
                    },
                    new ComponentPicture
                    {
                        ComponentType = componentTypes.FirstOrDefault(x => x.ComponentTypeEnumeration == ComponentTypeEnumeration.SSD),
                        ComponentId = ssds[1].Id,
                        FileStream = File.ReadAllBytes(Path.Combine(currentDirectory, "SSDs", "2.jpg")),
                    },
                };
                context.ComponentPictures.AddRange(pictures);
                #endregion
                context.SaveChanges();
            }
        }
    }
}

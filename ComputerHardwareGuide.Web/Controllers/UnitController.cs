using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ComputerHardwareGuide.Web.Models;
using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.Web.ViewModels;
using ComputerHardwareGuide.Web.Extensions;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : BaseComputerHardwareGuideController
    {
        public UnitController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public GetUnitVM Get(ComponentTypeEnumeration type)
        {
            var units = new List<Unit>();
            switch (type)
            {
                case ComponentTypeEnumeration.CPU:
                    SetCpuUnits(units);
                    break;
                case ComponentTypeEnumeration.RAM:
                    SetRamUnits(units);
                    break;
                case ComponentTypeEnumeration.GPU:
                    SetGpuUnits(units);
                    break;
                case ComponentTypeEnumeration.PowerUnit:
                    SetPowerUnitUnits(units);
                    break;
                case ComponentTypeEnumeration.Motherboard:
                    SetMotherboardUnits(units);
                    break;
                case ComponentTypeEnumeration.HDD:
                    SetHddUnits(units);
                    break;
                case ComponentTypeEnumeration.SSD:
                    SetSsdUnits(units);
                    break;
            }

            return new GetUnitVM
            {
                Type = type,
                TypeName = type.ToString(),
                Units = units
            };
        }

        private void SetCpuUnits(List<Unit> units)
        {
            var query = AppContext.ComponentCPUs.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Internal Clock Speed Unit
            var internalClockSpeedUnit = new Unit
            {
                Key = "InternalClockSpeed",
                Name = "Internal Clock Speed",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minInternalClockSpeed",
                        Text = "Minimum",
                        Value = query.Min(x => x.InternalClockSpeed)
                    },
                    new Option
                    {
                        Key = "maxInternalClockSpeed",
                        Text = "Maximum",
                        Value = query.Max(x => x.InternalClockSpeed)
                    },
                }
            };
            units.Add(internalClockSpeedUnit);
            #endregion

            #region Maximum Clock Speed Unit
            var maximumClockSpeedUnit = new Unit
            {
                Key = "MaximumClockSpeed",
                Name = "Maximum Clock Speed Unit",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minMaximumClockSpeed",
                        Text = "Minimum",
                        Value = query.Min(x => x.MaximumClockSpeed)
                    },
                    new Option
                    {
                        Key = "maxMaximumClockSpeed",
                        Text = "Maximum",
                        Value = query.Max(x => x.MaximumClockSpeed)
                    },
                }
            };
            units.Add(maximumClockSpeedUnit);
            #endregion

            #region Has Integrated GPU Unit
            var hasIntegratedGPUUnit = new Unit
            {
                Key = "HasIntegratedGPU",
                Name = "Has Integrated GPU",
                UnitType = UnitType.RadiobuttonGroup,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "hasIntegratedGPU",
                        Text = "Yes",
                        Value = true
                    },
                    new Option
                    {
                        Key = "hasIntegratedGPU",
                        Text = "No",
                        Value = false
                    },
                }
            };
            units.Add(hasIntegratedGPUUnit);
            #endregion

            #region Year Of Issue Unit
            var yearOfIssuesUnit = new Unit
            {
                Key = "yearOfIssue",
                Name = "Years Of Issue",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.YearOfIssue != null)
                .Select(x => x.YearOfIssue)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "yearOfIssue",
                    Text = x.ToString(),
                    Value = x
                }).ToList()
            };
            units.Add(yearOfIssuesUnit);
            #endregion

            #region Cors Count Unit
            var corsCountUnit = new Unit
            {
                Key = "corsCount",
                Name = "Amount of cores",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.CorsCount != null)
                .Select(x => x.CorsCount)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "corsCount",
                    Text = x.ToString(),
                    Value = x
                }).ToList()
            };
            units.Add(corsCountUnit);
            #endregion

            #region Threads Count Unit
            var threadsCountUnit = new Unit
            {
                Key = "threadsCount",
                Name = "Amount of threads",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.ThreadsCount != null)
                .Select(x => x.ThreadsCount)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "threadsCount",
                    Text = x.ToString(),
                    Value = x
                }).ToList()
            };
            units.Add(threadsCountUnit);
            #endregion
        }

        private void SetRamUnits(List<Unit> units)
        {
            var query = AppContext.ComponentRAMs.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Has Radiators Unit
            var hasIntegratedGPUUnit = new Unit
            {
                Key = "HasRadiators",
                Name = "Has Radiators",
                UnitType = UnitType.RadiobuttonGroup,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "hasRadiators",
                        Text = "Yes",
                        Value = true
                    },
                    new Option
                    {
                        Key = "hasRadiators",
                        Text = "No",
                        Value = false
                    },
                }
            };
            units.Add(hasIntegratedGPUUnit);
            #endregion

            #region Volume Unit
            var volumeUnit = new Unit
            {
                Key = "volume",
                Name = "Volume",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.Volume != null)
                .Select(x => x.Volume)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "volume",
                    Text = $"{x}GB",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion

            #region Frequency Unit
            var frequencyUnit = new Unit
            {
                Key = "frequency",
                Name = "Frequency",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.Frequency != null)
                .Select(x => x.Frequency)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "frequency",
                    Text = $"{x}MHz",
                    Value = x
                }).ToList()
            };
            units.Add(frequencyUnit);
            #endregion
        }

        private void SetGpuUnits(List<Unit> units)
        {
            var query = AppContext.ComponentGPUs.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Minimum Power Needs Unit
            var minimumPowerNeedsUnit = new Unit
            {
                Key = "MinimumPowerNeeds",
                Name = "Minimum Power Needs",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minMinimumPowerNeeds",
                        Text = "Minimum",
                        Value = query.Min(x => x.MinimumPowerNeeds)
                    },
                    new Option
                    {
                        Key = "maxMinimumPowerNeeds",
                        Text = "Maximum",
                        Value = query.Max(x => x.MinimumPowerNeeds)
                    },
                }
            };
            units.Add(minimumPowerNeedsUnit);
            #endregion

            #region Memory BandWidth Unit
            var memoryBandWidthUnit = new Unit
            {
                Key = "memoryBandWidth",
                Name = "Memory BandWidth",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.MemoryBandWidth != null)
                .Select(x => x.MemoryBandWidth)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "memoryBandWidth",
                    Text = $"{x}bit",
                    Value = x
                }).ToList()
            };
            units.Add(memoryBandWidthUnit);
            #endregion

            #region Volume Unit
            var volumeUnit = new Unit
            {
                Key = "volume",
                Name = "Volume",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.Volume != null)
                .Select(x => x.Volume)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "volume",
                    Text = $"{x}GB",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion
        }

        private void SetPowerUnitUnits(List<Unit> units)
        {
            var query = AppContext.ComponentPowerUnits.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Power Unit
            var powerUnit = new Unit
            {
                Key = "power",
                Name = "Power",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.Power != null)
                .Select(x => x.Power)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "power",
                    Text = $"{x}W",
                    Value = x
                }).ToList()
            };
            units.Add(powerUnit);
            #endregion

            #region Fan Diameter Unit
            var fanDiameterUnit = new Unit
            {
                Key = "fanDiameter",
                Name = "Fan Diameter",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.FanDiameter != null)
                .Select(x => x.FanDiameter)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "fanDiameter",
                    Text = $"{x}W",
                    Value = x
                }).ToList()
            };
            units.Add(fanDiameterUnit);
            #endregion

            #region Count Of SATA Unit
            var countOfSATAUnit = new Unit
            {
                Key = "countOfSATA",
                Name = "Count of SATA",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.CountOfSATA != null)
                .Select(x => x.CountOfSATA)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "countOfSATA",
                    Text = $"{x}",
                    Value = x
                }).ToList()
            };
            units.Add(countOfSATAUnit);
            #endregion
        }

        private void SetMotherboardUnits(List<Unit> units)
        {
            var query = AppContext.ComponentMotherboards.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Count Of RAM Slots Unit
            var countOfRAMSlotsUnit = new Unit
            {
                Key = "countOfRAMSlots",
                Name = "Count of RAM slots",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.CountOfRAMSlots != null)
                .Select(x => x.CountOfRAMSlots)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "countOfRAMSlots",
                    Text = $"{x}",
                    Value = x
                }).ToList()
            };
            units.Add(countOfRAMSlotsUnit);
            #endregion

            #region Maximum Memory Volume Unit
            var maximumMemoryVolumeUnit = new Unit
            {
                Key = "maximumMemoryVolume",
                Name = "Maximum memory volume",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.MaximumMemoryVolume != null)
                .Select(x => x.MaximumMemoryVolume)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "maximumMemoryVolume",
                    Text = $"{x}GB",
                    Value = x
                }).ToList()
            };
            units.Add(maximumMemoryVolumeUnit);
            #endregion

            #region Interfaces Unit
            var interfacesQuery = (from q in query
                                   join i in AppContext.MotherboardInterfaces.AsQueryable()
                                   on q equals i.ComponentMotherboard
                                   join lv in AppContext.LookupValues.Include(x => x.Lookup).ThenInclude(x => x.LookupValues).AsQueryable()
                                   on i.Interface equals lv
                                   select lv.Lookup).DistinctBy(x => x.Id);

            var interfacesUnits = interfacesQuery.Select(x => new Unit
            {
                Key = x.Key,
                Name = x.Name,
                UnitType = UnitType.CheckboxGroup,
                Options = x.LookupValues
                .Select(l => new Option
                {
                    Key = "interfaces",
                    Text = $"{l.DisplayText}",
                    Value = l.Id
                })
            });
            units.AddRange(interfacesUnits);
            #endregion
        }

        private void SetHddUnits(List<Unit> units)
        {
            var query = AppContext.ComponentHDDs.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Reading Speed Unit
            var readingSpeedUnit = new Unit
            {
                Key = "ReadingSpeed",
                Name = "Reading Speed",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minReadingSpeed",
                        Text = "Minimum",
                        Value = query.Min(x => x.ReadingSpeed)
                    },
                    new Option
                    {
                        Key = "maxReadingSpeed",
                        Text = "Maximum",
                        Value = query.Max(x => x.ReadingSpeed)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Writing Speed Unit
            var writingSpeedUnit = new Unit
            {
                Key = "WritingSpeed",
                Name = "Writing Speed",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minWritingSpeed",
                        Text = "Minimum",
                        Value = query.Min(x => x.WritingSpeed)
                    },
                    new Option
                    {
                        Key = "maxWritingSpeed",
                        Text = "Maximum",
                        Value = query.Max(x => x.WritingSpeed)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Volume Unit
            var volumeUnit = new Unit
            {
                Key = "volume",
                Name = "Volume",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.Volume != null)
                .Select(x => x.Volume)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "volume",
                    Text = $"{x}GB",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion

            #region Mean Time Between Failures Unit
            var meanTimeBetweenFailuresUnit = new Unit
            {
                Key = "meanTimeBetweenFailures",
                Name = "Mean Time Between Failures (hours)",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.MeanTimeBetweenFailures != null)
                .Select(x => x.MeanTimeBetweenFailures)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "meanTimeBetweenFailures",
                    Text = $"{x}",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion

            #region Read Only Memory Form Factor Unit
            var readOnlyMemoryFormFactorUnit = new Unit
            {
                Key = "readOnlyMemoryFormFactor",
                Name = "Read Only Memory Form Factor",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.ReadOnlyMemoryFormFactor != null)
                .Select(x => x.ReadOnlyMemoryFormFactor)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "readOnlyMemoryFormFactor",
                    Text = $"{x}",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion
        }

        private void SetSsdUnits(List<Unit> units)
        {
            var query = AppContext.ComponentSSDs.AsQueryable();

            #region Search Unit
            var searchUnit = new Unit
            {
                Key = "search",
                Name = "Search",
                UnitType = UnitType.Text,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "search",
                        Text = "Search",
                        Value = string.Empty
                    }
                }
            };
            units.Add(searchUnit);
            #endregion

            #region Price Unit
            var priceUnit = new Unit
            {
                Key = "Price",
                Name = "Price",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minPrice",
                        Text = "Minimum",
                        Value = query.Min(x => x.Price)
                    },
                    new Option
                    {
                        Key = "maxPrice",
                        Text = "Maximum",
                        Value = query.Max(x => x.Price)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Reading Speed Unit
            var readingSpeedUnit = new Unit
            {
                Key = "ReadingSpeed",
                Name = "Reading Speed",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minReadingSpeed",
                        Text = "Minimum",
                        Value = query.Min(x => x.ReadingSpeed)
                    },
                    new Option
                    {
                        Key = "maxReadingSpeed",
                        Text = "Maximum",
                        Value = query.Max(x => x.ReadingSpeed)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Writing Speed Unit
            var writingSpeedUnit = new Unit
            {
                Key = "WritingSpeed",
                Name = "Writing Speed",
                UnitType = UnitType.Range,
                Options = new Option[]
                {
                    new Option
                    {
                        Key = "minWritingSpeed",
                        Text = "Minimum",
                        Value = query.Min(x => x.WritingSpeed)
                    },
                    new Option
                    {
                        Key = "maxWritingSpeed",
                        Text = "Maximum",
                        Value = query.Max(x => x.WritingSpeed)
                    },
                }
            };
            units.Add(priceUnit);
            #endregion

            #region Volume Unit
            var volumeUnit = new Unit
            {
                Key = "volume",
                Name = "Volume",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.Volume != null)
                .Select(x => x.Volume)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "volume",
                    Text = $"{x}GB",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion

            #region Mean Time Between Failures Unit
            var meanTimeBetweenFailuresUnit = new Unit
            {
                Key = "meanTimeBetweenFailures",
                Name = "Mean Time Between Failures (hours)",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.MeanTimeBetweenFailures != null)
                .Select(x => x.MeanTimeBetweenFailures)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "meanTimeBetweenFailures",
                    Text = $"{x}",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion

            #region Read Only Memory Form Factor Unit
            var readOnlyMemoryFormFactorUnit = new Unit
            {
                Key = "readOnlyMemoryFormFactor",
                Name = "Read Only Memory Form Factor",
                UnitType = UnitType.CheckboxGroup,
                Options = query.Where(x => x.ReadOnlyMemoryFormFactor != null)
                .Select(x => x.ReadOnlyMemoryFormFactor)
                .Distinct()
                .Select(x => new Option
                {
                    Key = "readOnlyMemoryFormFactor",
                    Text = $"{x}",
                    Value = x
                }).ToList()
            };
            units.Add(volumeUnit);
            #endregion
        }
    }
}

using ComputerHardwareGuide.DAL;
using ComputerHardwareGuide.DAL.Models.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    public abstract class BaseComputerHardwareGuideController : ControllerBase
    {
        protected IAppContext AppContext { get; set; }
        public BaseComputerHardwareGuideController(IAppContext appContext)
        {
            AppContext = appContext;
        }

        protected void LoadPictures(BaseComponent component, int? count = 1)
        {
            var query = AppContext.ComponentPictures.Include(x => x.ComponentType)
                                                                      .AsQueryable()
                                                                      .Where(x => x.ComponentId == component.Id
                                                                      && x.ComponentType.Id == (int)component.Type);
            component.ComponentPictures = count.HasValue ? query.Take(count.Value) : query;
        }

        protected void LoadPictures(IEnumerable<BaseComponent> components, int? count = 1)
        {

            foreach (var component in components)
            {
                var query = AppContext.ComponentPictures.Include(x => x.ComponentType)
                                                                          .AsQueryable()
                                                                          .Where(x => x.ComponentId == component.Id
                                                                          && x.ComponentType.Id == (int)component.Type);
                component.ComponentPictures = count.HasValue ? query.Take(count.Value) : query;
            }
        }

        protected IQueryable<BaseComponent> GetQuery(ComponentTypeEnumeration type)
        {
            var query = (IQueryable<BaseComponent>)null;

            switch (type)
            {
                case ComponentTypeEnumeration.CPU:
                    query = AppContext.ComponentCPUs.Include(x => x.Firm)
                                                .Include(x => x.Socket)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.ProcessorFamily)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.RAMType)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.Process)
                                                    .ThenInclude(x => x.Lookup)
                                                .AsQueryable();
                    break;
                case ComponentTypeEnumeration.RAM:
                    query = AppContext.ComponentRAMs.Include(x => x.Firm)
                                                    .Include(x => x.RAMType)
                                                        .ThenInclude(x => x.Lookup)
                                                    .Include(x => x.Timings)
                                                        .ThenInclude(x => x.Lookup)
                                                    .AsQueryable();
                    break;
                case ComponentTypeEnumeration.GPU:
                    query = AppContext.ComponentGPUs.Include(x => x.Firm)
                                                .Include(x => x.Resolution)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.GPUType)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.GPUInterface)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.PowerSupply)
                                                    .ThenInclude(x => x.Lookup)
                                                .AsQueryable();
                    break;
                case ComponentTypeEnumeration.PowerUnit:
                    query = AppContext.ComponentPowerUnits.Include(x => x.Firm)
                                                          .Include(x => x.PowerSupports)
                                                            .ThenInclude(x => x.PowerConnection)
                                                            .ThenInclude(x => x.Lookup)
                                                          .AsQueryable();
                    break;
                case ComponentTypeEnumeration.Motherboard:
                    query = AppContext.ComponentMotherboards.Include(x => x.Firm)
                                                            .Include(x => x.Socket)
                                                                .ThenInclude(x => x.Lookup)
                                                            .Include(x => x.Chipset)
                                                                .ThenInclude(x => x.Lookup)
                                                            .Include(x => x.SizeFormFactor)
                                                                .ThenInclude(x => x.Lookup)
                                                            .Include(x => x.RAMType)
                                                                .ThenInclude(x => x.Lookup)
                                                            .Include(x => x.MotherboardInterfaces)
                                                                .ThenInclude(x => x.Interface)
                                                                .ThenInclude(x => x.Lookup)
                                                            .AsQueryable();
                    break;
                case ComponentTypeEnumeration.HDD:
                    query = AppContext.ComponentHDDs.Include(x => x.Firm)
                                                    .Include(x => x.ReadOnlyMemoryFormFactor)
                                                        .ThenInclude(x => x.Lookup)
                                                    .Include(x => x.Interface)
                                                        .ThenInclude(x => x.Lookup)
                                                    .AsQueryable();
                    break;
                case ComponentTypeEnumeration.SSD:
                    query = AppContext.ComponentSSDs.Include(x => x.Firm)
                                                    .Include(x => x.ReadOnlyMemoryFormFactor)
                                                        .ThenInclude(x => x.Lookup)
                                                    .Include(x => x.TypeOfCellMemory)
                                                        .ThenInclude(x => x.Lookup)
                                                    .Include(x => x.Interface)
                                                        .ThenInclude(x => x.Lookup)
                                                    .AsQueryable();
                    break;
                case ComponentTypeEnumeration.CoolingSystem:
                    break;
                case ComponentTypeEnumeration.Case:
                    break;
                default:
                    break;
            }
            return query;
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models.Components.GPUs;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GPUController : BaseComputerHardwareGuideController
    {
        public GPUController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<ComponentGPU>> Get(
            double? minPrice,
            double? maxPrice,
            double? minMinimumPowerNeeds,
            double? maxMinimumPowerNeeds,
            [FromQuery] IEnumerable<int> memoryBandWidth,
            [FromQuery] IEnumerable<int> volume,
            [FromQuery] IEnumerable<int> firmId,
            [FromQuery] IEnumerable<int> resolution,
            [FromQuery] IEnumerable<int> gpuType,
            [FromQuery] IEnumerable<int> gpuInterface,
            [FromQuery] IEnumerable<int> powerSupply,
            string search
        )
        {
            var query = AppContext.ComponentGPUs.Include(x => x.Firm)
                                                .Include(x => x.Resolution)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.GPUType)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.GPUInterface)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.PowerSupply)
                                                    .ThenInclude(x => x.Lookup)
                                                .AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(x => x.Price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= maxPrice);
            }

            if (minMinimumPowerNeeds.HasValue)
            {
                query = query.Where(x => x.MinimumPowerNeeds >= minMinimumPowerNeeds);
            }
            if (maxMinimumPowerNeeds.HasValue)
            {
                query = query.Where(x => x.MinimumPowerNeeds <= maxMinimumPowerNeeds);
            }

            if (firmId?.Count() > 0)
            {
                query = query.Where(x => firmId.Any(i => x.Firm.Id == i));
            }

            if (memoryBandWidth?.Count() > 0)
            {
                var memoryList = memoryBandWidth.ToList();
                query = query.Where(x => memoryList.Contains((int)x.MemoryBandWidth.Value));
            }

            if (volume?.Count() > 0)
            {
                var volumeList = volume.ToList();
                query = query.Where(x => volumeList.Contains((int)x.Volume.Value));
            }

            if (resolution?.Count() > 0)
            {
                query = query.Where(x => resolution.Any(i => x.Resolution.Id == i));
            }

            if (gpuType?.Count() > 0)
            {
                query = query.Where(x => gpuType.Any(i => x.GPUType.Id == i));
            }

            if (gpuInterface?.Count() > 0)
            {
                query = query.Where(x => gpuInterface.Any(i => x.GPUInterface.Id == i));
            }

            if (powerSupply?.Count() > 0)
            {
                query = query.Where(x => powerSupply.Any(i => x.PowerSupply.Id == i));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            LoadPictures(query);

            return await query.ToListAsync();
        }
    }
}

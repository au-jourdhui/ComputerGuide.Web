using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models.Components.RAMs;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RAMController : BaseComputerHardwareGuideController
    {
        public RAMController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<ComponentRAM>> Get(
            double? minPrice,
            double? maxPrice,
            bool? hasRadiators,
            [FromQuery] IEnumerable<int> firmId,
            [FromQuery] IEnumerable<double> volume,
            [FromQuery] IEnumerable<int> frequency,
            [FromQuery] IEnumerable<int> ramType,
            [FromQuery] IEnumerable<int> timings,
            string search
        )
        {
            var query = AppContext.ComponentRAMs.Include(x => x.Firm)
                                                .Include(x => x.RAMType)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.Timings)
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

            if (hasRadiators.HasValue)
            {
                query = query.Where(x => x.HasRadiators == hasRadiators);
            }

            if (firmId?.Count() > 0)
            {
                query = query.Where(x => firmId.Any(i => x.Firm.Id == i));
            }

            if (volume?.Count() > 0)
            {
                var volumeList = volume.ToList();
                query = query.Where(x => volumeList.Contains((int)x.Volume.Value));
            }

            if (frequency?.Count() > 0)
            {
                var frequencyList = frequency.ToList();
                query = query.Where(x => frequencyList.Contains(x.Frequency.Value));
            }

            if (timings?.Count() > 0)
            {
                query = query.Where(x => timings.Any(i => x.Timings.Id == i));
            }

            if (ramType?.Count() > 0)
            {
                query = query.Where(x => ramType.Any(i => x.RAMType.Id == i));
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
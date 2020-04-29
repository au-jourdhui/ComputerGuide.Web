using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models.Components.ROMs;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HDDController : BaseComputerHardwareGuideController
    {
        public HDDController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<ComponentHDD>> Get(
            double? minPrice,
            double? maxPrice,
            double? minReadingSpeed,
            double? maxReadingSpeed,
            double? minWritingSpeed,
            double? maxWritingSpeed,
            [FromQuery] IEnumerable<int> volume,
            [FromQuery] IEnumerable<int> meanTimeBetweenFailures,
            [FromQuery] IEnumerable<int> firmId,
            [FromQuery] IEnumerable<int> readOnlyMemoryFormFactor,
            [FromQuery] IEnumerable<int> @interface,
            string search
        )
        {
            var query = AppContext.ComponentHDDs.Include(x => x.Firm)
                                                .Include(x => x.ReadOnlyMemoryFormFactor)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.Interface)
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

            if (minReadingSpeed.HasValue)
            {
                query = query.Where(x => x.ReadingSpeed >= minReadingSpeed);
            }
            if (maxReadingSpeed.HasValue)
            {
                query = query.Where(x => x.ReadingSpeed <= maxReadingSpeed);
            }

            if (minWritingSpeed.HasValue)
            {
                query = query.Where(x => x.WritingSpeed >= minWritingSpeed);
            }
            if (maxWritingSpeed.HasValue)
            {
                query = query.Where(x => x.WritingSpeed <= maxWritingSpeed);
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

            if (meanTimeBetweenFailures?.Count() > 0)
            {
                query = query.Where(x => meanTimeBetweenFailures.Any(i => x.MeanTimeBetweenFailures == i));
            }

            if (readOnlyMemoryFormFactor?.Count() > 0)
            {
                query = query.Where(x => readOnlyMemoryFormFactor.Any(i => x.ReadOnlyMemoryFormFactor.Id == i));
            }

            if (@interface?.Count() > 0)
            {
                query = query.Where(x => @interface.Any(i => x.Interface.Id == i));
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

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL.Models.Components.CPUs;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CPUController : BaseComputerHardwareGuideController
    {
        public CPUController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<ComponentCPU>> Get(
            double? minPrice,
            double? maxPrice,
            double? minInternalClockSpeed,
            double? maxInternalClockSpeed,
            double? minMaximumClockSpeed,
            double? maxMaximumClockSpeed,
            bool? hasIntegratedGPU,
            [FromQuery] IEnumerable<int> yearOfIssue,
            [FromQuery] IEnumerable<int> corsCount,
            [FromQuery] IEnumerable<int> threadsCount,
            [FromQuery] IEnumerable<int> socket,
            [FromQuery] IEnumerable<int> firmId,
            [FromQuery] IEnumerable<int> processorFamily,
            [FromQuery] IEnumerable<int> ramType,
            [FromQuery] IEnumerable<int> process,
            string search
        )
        {
            var query = AppContext.ComponentCPUs.Include(x => x.Firm)
                                                .Include(x => x.Socket)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.ProcessorFamily)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.RAMType)
                                                    .ThenInclude(x => x.Lookup)
                                                .Include(x => x.Process)
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

            if (firmId?.Count() > 0)
            {
                query = query.Where(x => firmId.Any(i => x.Firm.Id == i));
            }

            if (yearOfIssue?.Count() > 0)
            {
                var yearList = yearOfIssue.ToList();
                query = query.Where(x => yearList.Contains(x.YearOfIssue.Value));
            }

            if (minInternalClockSpeed.HasValue)
            {
                query = query.Where(x => x.InternalClockSpeed >= minInternalClockSpeed);
            }
            if (maxInternalClockSpeed.HasValue)
            {
                query = query.Where(x => x.InternalClockSpeed <= maxInternalClockSpeed);
            }

            if (minMaximumClockSpeed.HasValue)
            {
                query = query.Where(x => x.MaximumClockSpeed >= minMaximumClockSpeed);
            }
            if (maxMaximumClockSpeed.HasValue)
            {
                query = query.Where(x => x.MaximumClockSpeed <= maxMaximumClockSpeed);
            }

            if (hasIntegratedGPU.HasValue)
            {
                query = query.Where(x => x.HasIntegratedGPU == hasIntegratedGPU);
            }

            if (corsCount?.Count() > 0)
            {
                var corsList = corsCount.ToList();
                query = query.Where(x => corsList.Contains(x.CorsCount.Value));
            }

            if (threadsCount?.Count() > 0)
            {
                var threadsList = threadsCount.ToList();
                query = query.Where(x => threadsList.Contains(x.ThreadsCount.Value));
            }

            if (socket?.Count() > 0)
            {
                query = query.Where(x => socket.Any(i => x.Socket.Id == i));
            }

            if (processorFamily?.Count() > 0)
            {
                query = query.Where(x => processorFamily.Any(i => x.ProcessorFamily.Id == i));
            }

            if (ramType?.Count() > 0)
            {
                query = query.Where(x => ramType.Any(i => x.RAMType.Id == i));
            }

            if (process?.Count() > 0)
            {
                query = query.Where(x => process.Any(i => x.Process.Id == i));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search) || x.Model.Contains(search));
            }

            LoadPictures(query);

            return await query.ToListAsync();
        }
    }
}

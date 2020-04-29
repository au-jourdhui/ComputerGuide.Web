using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models.Components.Motherboards;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotherboardController : BaseComputerHardwareGuideController
    {
        public MotherboardController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<ComponentMotherboard>> Get(
            double? minPrice,
            double? maxPrice,
            [FromQuery] IEnumerable<int> countOfRAMSlots,
            [FromQuery] IEnumerable<double> maximumMemoryVolume,
            [FromQuery] IEnumerable<int> firmId,
            [FromQuery] IEnumerable<int> socket,
            [FromQuery] IEnumerable<int> chipset,
            [FromQuery] IEnumerable<int> sizeFormFactor,
            [FromQuery] IEnumerable<int> ramType,
            [FromQuery] IEnumerable<int> interfaces,
            string search
        )
        {
            var query = AppContext.ComponentMotherboards.Include(x => x.Firm)
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

            if (countOfRAMSlots?.Count() > 0)
            {
                var list = countOfRAMSlots.ToList();
                query = query.Where(x => list.Contains(x.CountOfRAMSlots.Value));
            }

            if (maximumMemoryVolume?.Count() > 0)
            {
                var list = maximumMemoryVolume.ToList();
                query = query.Where(x => list.Contains(x.MaximumMemoryVolume.Value));
            }

            if (socket?.Count() > 0)
            {
                query = query.Where(x => socket.Any(i => x.Socket.Id == i));
            }

            if (chipset?.Count() > 0)
            {
                query = query.Where(x => chipset.Any(i => x.Chipset.Id == i));
            }

            if (sizeFormFactor?.Count() > 0)
            {
                query = query.Where(x => sizeFormFactor.Any(i => x.SizeFormFactor.Id == i));
            }

            if (ramType?.Count() > 0)
            {
                query = query.Where(x => ramType.Any(i => x.RAMType.Id == i));
            }

            if (interfaces?.Count() > 0)
            {
                var groups = interfaces.GroupBy(x => x).Select(x => new { Id = x, Count = x.Count() });
                foreach (var group in groups)
                {
                    query = query.Where(x => x.MotherboardInterfaces.Any(m => m.Interface.Id == group.Id.Key && m.Count >= group.Count));
                }
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

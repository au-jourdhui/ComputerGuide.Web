using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models.Components.PowerUnits;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerUnitController : BaseComputerHardwareGuideController
    {
        public PowerUnitController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<ComponentPowerUnit>> Get(
            double? minPrice,
            double? maxPrice,
            [FromQuery] IEnumerable<int> firmId,
            [FromQuery] IEnumerable<int> power,
            [FromQuery] IEnumerable<int> fanDiameter,
            [FromQuery] IEnumerable<int> countOfSATA,
            [FromQuery] IEnumerable<int> powerSupports,
            string search
        )
        {
            var query = AppContext.ComponentPowerUnits.Include(x => x.Firm)
                                                      .Include(x => x.PowerSupports)
                                                        .ThenInclude(x => x.PowerConnection)
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

            if (power?.Count() > 0)
            {
                var powerList = power.ToList();
                query = query.Where(x => powerList.Contains(x.Power.Value));
            }

            if (fanDiameter?.Count() > 0)
            {
                var fanDiameterList = fanDiameter.ToList();
                query = query.Where(x => fanDiameterList.Contains(x.FanDiameter.Value));
            }

            if (countOfSATA?.Count() > 0)
            {
                var countOfSATAList = countOfSATA.ToList();
                query = query.Where(x => countOfSATAList.Contains(x.CountOfSATA.Value));
            }

            var groups = powerSupports.GroupBy(x => x).Select(x => new { Id = x, Count = x.Count() });
            foreach (var group in groups)
            {
                query = query.Where(x => x.PowerSupports.Any(m => m.PowerConnection.Id == group.Id.Key && m.Count >= group.Count));
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

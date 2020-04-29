using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.Web.Extensions;

namespace ComputerHardwareGuide.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LookupController : BaseComputerHardwareGuideController
	{
		public LookupController(IAppContext appContext) : base(appContext) { }

		[HttpGet]
		public async Task<IEnumerable<Lookup>> Get(ComponentTypeEnumeration? type = null)
		{
			var lookups = await (from l in AppContext.Lookups.AsQueryable()
						         join lc in AppContext.LookupComponentTypes.AsQueryable()
						         on l equals lc.Lookup
						         join ct in AppContext.ComponentTypes.AsQueryable()
						         on lc.ComponentType equals ct
						         where type == null ||
						         ct.Id == (int)type
						         orderby l.Name
						         select l).ToListAsync();

			foreach (var lookup in lookups.DistinctBy(x => x.Id))
			{
				lookup.LookupValues = await (from lv in AppContext.LookupValues.AsQueryable()
											 join l in AppContext.Lookups.AsQueryable()
											 on lv.Lookup equals l
											 where l.Id == lookup.Id
											 select lv).ToListAsync();
			}

			return lookups;
		}
	}
}

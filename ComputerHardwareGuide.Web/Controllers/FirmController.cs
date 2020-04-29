using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.DAL.Models;
using System.Linq;
using ComputerHardwareGuide.Web.Extensions;

namespace ComputerHardwareGuide.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FirmController : BaseComputerHardwareGuideController
	{
		public FirmController(IAppContext appContext) : base(appContext) { }

		[HttpGet]
		public IEnumerable<Firm> Get(ComponentTypeEnumeration? type = null)
		{
			return (from f in AppContext.Firms.AsQueryable()
				    join fct in AppContext.FirmComponentTypes.AsQueryable()
				    on f equals fct.Firm
				    join ct in AppContext.ComponentTypes.AsQueryable()
				    on fct.ComponentType equals ct
				    where type == null ||
				    ct.Id == (int)type
				    select f).DistinctBy(x => x.Id);
		}
	}
}

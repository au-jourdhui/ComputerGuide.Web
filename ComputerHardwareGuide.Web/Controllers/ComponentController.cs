using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models.Components.RAMs;
using ComputerHardwareGuide.DAL.Models.Components;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentController : BaseComputerHardwareGuideController
    {
        public ComponentController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<BaseComponent> Get(int id, ComponentTypeEnumeration type)
        {
            var query = GetQuery(type);

            LoadPictures(query, null);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
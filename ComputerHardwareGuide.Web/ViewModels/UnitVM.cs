using ComputerHardwareGuide.DAL.Models.Components;
using ComputerHardwareGuide.Web.Models;
using System.Collections.Generic;

namespace ComputerHardwareGuide.Web.ViewModels
{
    public class GetUnitVM
    {
        public string TypeName { get; set; }
        public ComponentTypeEnumeration Type { get; set; }
        public IEnumerable<Unit> Units { get; set; }

        public GetUnitVM()
        {
            Units = new List<Unit>();
        }
    }
}

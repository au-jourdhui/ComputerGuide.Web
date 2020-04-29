using ComputerHardwareGuide.DAL.Models.Components;

namespace ComputerHardwareGuide.Web.ViewModels
{
    public class AddAssemblyComponentVM
    {
        public int AssemblyId { get; set; }
        public int ComponentId { get; set; }
        public ComponentTypeEnumeration Type { get; set; }
        public int Quantity { get; set; } = 1;
    }
}

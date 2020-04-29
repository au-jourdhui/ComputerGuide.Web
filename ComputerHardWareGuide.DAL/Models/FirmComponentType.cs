using ComputerHardwareGuide.DAL.Models.Components;

namespace ComputerHardwareGuide.DAL.Models
{
    public class FirmComponentType : BaseEntity
    {
        public Firm Firm { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}

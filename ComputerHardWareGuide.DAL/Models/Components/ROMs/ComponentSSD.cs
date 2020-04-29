namespace ComputerHardwareGuide.DAL.Models.Components.ROMs
{
    public class ComponentSSD : ComponentROM
    {
        public LookupValue TypeOfCellMemory { get; set; }
        public override ComponentTypeEnumeration Type => ComponentTypeEnumeration.SSD;
    }
}

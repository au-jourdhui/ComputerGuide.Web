namespace ComputerHardwareGuide.DAL.Models
{
    public class LookupValue : BaseEntity
    {
        public string Value { get; set; }
        public string DisplayText { get; set; }

        public Lookup Lookup { get; set; }
    }
}

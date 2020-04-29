using System.Collections.Generic;

namespace ComputerHardwareGuide.Web.Models
{
    public class Unit
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public IEnumerable<Option> Options { get; set; }
        public UnitType UnitType { get; set; }
        public string UnitTypeName => this.UnitType.ToString();
        public Unit()
        {
            Options = new List<Option>();
        }
    }
}

using ComputerHardwareGuide.DAL.Models.Components;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ComputerHardwareGuide.DAL.Models
{
    public class Assembly : BaseEntity
    {
        public string Name { get; set; }
        public int ToPrice { get; set; }

        public List<AssemblyComponent> AssemblyComponents { get; set; }
    }
}

using NTierArchitecture.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Models
{
    public sealed class Document:Entity
    {
        public string Name { get; set; }
        public Meet Meets{ get; set; }
    }
}

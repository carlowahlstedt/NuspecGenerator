using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuspecGenerator
{
    public class Dependency
    {
        public string ID { get; set; }
        public Version VersionNumber { get; set; }
    }
}

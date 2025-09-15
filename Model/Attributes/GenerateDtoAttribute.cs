using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class GenerateDtoAttribute : Attribute
    {
    }
}

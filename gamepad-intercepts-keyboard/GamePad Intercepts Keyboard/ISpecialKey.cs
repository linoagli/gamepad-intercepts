using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts_Keyboard
{
    internal interface ISpecialKey : IKey
    {
        bool IsSpecialFeatureActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Core;

namespace Prism.ConsoleTest.Components
{
    class SpatialComponent : IComponent
    {
        public float X { get; set; }
        public float Y { get; set; }
        public void Init()
        {
            X = 0;
            Y = 0;
        }
    }
}

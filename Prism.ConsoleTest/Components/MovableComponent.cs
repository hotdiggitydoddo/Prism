using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Core;

namespace Prism.ConsoleTest.Components
{
    class MovableComponent : IComponent
    {
        public float VelX { get; set; }
        public float VelY { get; set; }
        public void Init()
        {
            VelX = 0;
            VelY = 0;
        }

        public int TypeIndex()
        {
            return (int)ComponentTypes.Movable;
        }
    }
}

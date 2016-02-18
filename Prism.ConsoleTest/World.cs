using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.ConsoleTest.Components;
using Prism.Core;

namespace Prism.ConsoleTest
{
    enum ComponentTypes
    {
        Spatial,
        Movable
    }

    class World
    {
        private EntityManager _em;

        public World(int maxEntities)
        {
            _em = new EntityManager(maxEntities);
            _em.RegisterComponentHandler<SpatialComponent>();
            _em.RegisterComponentHandler<MovableComponent>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.ConsoleTest.Components;
using Prism.ConsoleTest.Subsystems;
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

            _em.AddSubsystem<PhysicsSubsystem>();

            var entity = _em.CreateEntity();

            var spatial = _em.AddComponent<SpatialComponent>(entity);
            spatial.X = 5;
            spatial.Y = 10;

            var movable = _em.AddComponent<MovableComponent>(entity);
            movable.VelX = .1f;
            movable.VelY = .1f;

            entity = _em.CreateEntity();

            spatial = _em.AddComponent<SpatialComponent>(entity);
            spatial.X = 52;
            spatial.Y = 22;

            movable = _em.AddComponent<MovableComponent>(entity);
            movable.VelX = .17f;
            movable.VelY = .17f;

            _em.Update(.1666f);

        }
    }
}

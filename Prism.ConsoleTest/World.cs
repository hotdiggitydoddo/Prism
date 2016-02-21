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

    class World : WorldBase
    {
        public World(int maxEntities) : base(maxEntities)
        {
            EntityManager.RegisterComponentHandler<SpatialComponent>();
            EntityManager.RegisterComponentHandler<MovableComponent>();

            EntityManager.AddSubsystem<PhysicsSubsystem>();

            var entity = EntityManager.CreateEntity();

            var spatial = EntityManager.AddComponent<SpatialComponent>(entity);
            spatial.X = 5;
            spatial.Y = 10;

            var movable = EntityManager.AddComponent<MovableComponent>(entity);
            movable.VelX = .1f;
            movable.VelY = .1f;

            entity = EntityManager.CreateEntity();

            spatial = EntityManager.AddComponent<SpatialComponent>(entity);
            spatial.X = 52;
            spatial.Y = 22;

            movable = EntityManager.AddComponent<MovableComponent>(entity);
            movable.VelX = .17f;
            movable.VelY = .17f;

            EntityManager.Update(.1666f);

        }
    }
}

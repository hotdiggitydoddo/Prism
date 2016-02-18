using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.ConsoleTest.Components;
using Prism.Core;

namespace Prism.ConsoleTest.Subsystems
{
    class PhysicsSubsystem : Subsystem
    {
        private ComponentHandler<SpatialComponent> _spatials;
        private ComponentHandler<MovableComponent> _movables;
          
        public PhysicsSubsystem() : base((int)ComponentTypes.Spatial, (int)ComponentTypes.Movable) { }
        public override void Notify(Message message)
        {
            throw new NotImplementedException();
        }

        public override void RegisterComponentHandlers(EntityManager em)
        {
            _spatials = em.GetComponentHandler<SpatialComponent>();
            _movables = em.GetComponentHandler<MovableComponent>();
        }

        public override void Update(float dt)
        {
            foreach (var entity in Entities)
            {
                var spatial = _spatials.GetComponent(entity);
                var movable = _movables.GetComponent(entity);

                spatial.X += movable.VelX;
                spatial.Y += movable.VelY;

                Console.WriteLine("Entity #{0} Position: (X: {1}, Y: {2})", entity, spatial.X, spatial.Y);
            }
        }
    }
}

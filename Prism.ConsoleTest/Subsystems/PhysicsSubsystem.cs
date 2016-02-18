using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Core;

namespace Prism.ConsoleTest.Subsystems
{
    class PhysicsSubsystem : Subsystem
    {
        public PhysicsSubsystem() : base((int)ComponentTypes.Spatial, (int)ComponentTypes.Movable)
        {
            
        }
        public override void Notify(Message message)
        {
            throw new NotImplementedException();
        }

        public override void Update(float dt)
        {
            foreach (var entity in Entities)
            {
                
            }
        }
    }
}

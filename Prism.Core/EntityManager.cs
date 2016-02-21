using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public class EntityManager
    {
        private BitSet[] _entityComponentMasks;
        private readonly Stack<uint> _freeEntities;
        private uint _nextId = 0;
        private Dictionary<Type, IComponentHandler> _componentHandlers;
        private WorldBase _world;


        public EntityManager(WorldBase world, int startingAmount)
        {
            _world = world;
            _freeEntities = new Stack<uint>();
            _entityComponentMasks = new BitSet[startingAmount];

            for (int i = 0; i < startingAmount; i++)
                _entityComponentMasks[i] = new BitSet();

            _componentHandlers = new Dictionary<Type, IComponentHandler>();
        }

        public uint CreateEntity()
        {
            uint entity;
            if (_freeEntities.Any())
                entity = _freeEntities.Pop();
            else
            {
                entity = _nextId;
                _nextId++;
                AccommodateEntity((int)entity);
            }
            _entityComponentMasks[(int)entity].ClearAll();
            return entity;
        }

        public BitSet GetComponentMask(uint entity)
        {
            return _entityComponentMasks[(int) entity];
        }

        public T AddSubsystem<T>() where T : Subsystem, new()
        {
            var subsystem = new T();
            _world.SubsystemManager.AddSubsystem(subsystem);
            return subsystem;
        }

        public T AddComponent<T>(uint entity) where T : IComponent, new()
        {
            var handler = GetComponentHandler<T>();
            var comp = handler.AssignComponentToEntity(entity);

            _entityComponentMasks[entity].SetBit(comp.TypeIndex());
            _world.SubsystemManager.OnComponentChanged(entity);

            return comp;
        }

        public T RemoveComponent<T>(uint entity) where T : IComponent, new()
        {
            var handler = GetComponentHandler<T>();
            var comp = handler.RemoveComponentFromEntity(entity);

            _entityComponentMasks[entity].ClearBit(comp.TypeIndex());
            _world.SubsystemManager.OnComponentChanged(entity);

            return comp;
        }

        public void RegisterComponentHandler<T>() where T : IComponent, new()
        {
            var handler = new ComponentHandler<T>(1000);
            _componentHandlers.Add(typeof(T), handler);
        }

        public ComponentHandler<T> GetComponentHandler<T>() where T : IComponent, new()
        {
            return _componentHandlers[typeof (T)] as ComponentHandler<T>;
        }

        public bool HasComponents(uint entity, BitSet componentTypes)
        {
            return componentTypes.IsSubsetOf(_entityComponentMasks[entity]);
        }

        public void Update(float dt)
        {
            _world.SubsystemManager.Update(dt);
        }

        void AccommodateEntity(int id)
        {
            if (_entityComponentMasks.Length <= id)
            {
                var oldLength = _entityComponentMasks.Length;

                Array.Resize(ref _entityComponentMasks, _entityComponentMasks.Length + 100);

                for (int i = oldLength; i < _entityComponentMasks.Length; i++)
                    _entityComponentMasks[i] = new BitSet();
            }
        }
    }
}

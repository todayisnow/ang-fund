using System;
using System.Collections.Generic;
using System.Linq;

namespace Events.Ioc
{
    public class MyContainer : IMyContainer
    {
        private readonly Dictionary<Type, Type> _iocDictionary= new Dictionary<Type, Type>();
        public void Register <TFrom,TTo>()
        {
            _iocDictionary[typeof(TFrom)] = typeof(TTo);
        }
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            
            if (!_iocDictionary.ContainsKey(type))
                throw new Exception($"Type {type.Name} cannot be resolved");
            var typeTo = _iocDictionary[type];
            if(!typeTo.GetConstructors().Any())
                return Activator.CreateInstance(typeTo);
            var typeToConstructor = typeTo.GetConstructors().First();
            return !typeToConstructor.GetParameters().Any() ? Activator.CreateInstance(typeTo) : Activator.CreateInstance(typeTo, typeToConstructor.GetParameters().Select(param => Resolve(param.ParameterType)).ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Task1.DoNotChange;

namespace Task1
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _mappedTypes = new Dictionary<Type, Type>();

        public void AddAssembly(Assembly assembly)
        {
            var mappedTypes = GetMappedTypes(assembly);

            foreach (var type in mappedTypes)
		{
			var contract = (type.GetCustomAttributes(typeof(ExportAttribute)).FirstOrDefault() as ExportAttribute)
				?.Contract;
			if (contract != null)
				AddType(type, contract);
			else
				AddType(type);
		}
                    AddType(type);
                else if ((type.GetCustomAttributes(typeof(ExportAttribute)).FirstOrDefault() as ExportAttribute)?.Contract != null)
                    AddType(type,
                        (type.GetCustomAttributes(typeof(ExportAttribute)).First() as ExportAttribute)?.Contract);
                else
                    AddType(type);
        }

        public void AddType(Type type)
        {
            // If Already added, update the injection type
            if (_mappedTypes.ContainsKey(type))
                _mappedTypes[type] = type;
            _mappedTypes.Add(type, type);
        }

        public void AddType(Type type, Type baseType)
        {
            //TODO: ask why we should check it
            // If Already added, update the injection type
            //if (_mappedTypes.ContainsKey(baseType))
            //  _mappedTypes[baseType] = type;
            
            AddType(type);
            _mappedTypes.Add(baseType, type);
        }

        public T Get<T>()
        {
            if (!_mappedTypes.Any())
                throw new Exception("No entity has been added yet");
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            Type resolvedType;
            try
            {
                resolvedType = _mappedTypes[type];
            }
            catch(Exception resolveException)
            {
                throw new Exception("Unable to find type : " + type, resolveException);
            }
            // Inject marked properties
            var props = resolvedType.GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ImportAttribute)));
            // Inject marked fields
            var fields = resolvedType.GetFields().Where(
                field => Attribute.IsDefined(field, typeof(ImportAttribute)));

            object resolvedObject;
            if (Attribute.IsDefined(resolvedType, typeof(ImportConstructorAttribute)))
            {
                // Inject marked classes
                var ctor = resolvedType.GetConstructors().First();
                var ctorParameters = ctor.GetParameters();
                // Iterate through parameters and add each parameter
                resolvedObject = ctor.Invoke(ctorParameters.Select(p => Resolve(p.ParameterType)).ToArray());
            }
            else
            {
                // If constructor hasn't parameter, create an instance of object
                resolvedObject = Activator.CreateInstance(resolvedType); 
            }
            foreach (var prop in props)
            {
                prop.SetValue(resolvedObject,Resolve(prop.PropertyType));
            }
            foreach (var field in fields)
            {
                field.SetValue(resolvedObject,Resolve(field.FieldType));
            }
            return resolvedObject;
        }

        private static IEnumerable<Type> GetMappedTypes(Assembly assembly)
        {
            return assembly.GetTypes().Where(t =>
                Attribute.IsDefined(t, typeof(ExportAttribute)) ||
                Attribute.IsDefined(t, typeof(ImportConstructorAttribute)) ||
                t.GetProperties().Any(p => Attribute.IsDefined(p, typeof(ImportAttribute))) ||
                t.GetFields().Any(f => Attribute.IsDefined(f, typeof(ImportAttribute))));
        }
    }
}
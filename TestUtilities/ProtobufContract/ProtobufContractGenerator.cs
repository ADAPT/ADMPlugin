using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using ProtoBuf.Meta;

namespace TestUtilities.ProtobufContract
{
    public class ProtobufContractGenerator
    {
        private readonly ProtobufElementMapper _mapper;
        private RuntimeTypeModel _model;

        public ProtobufContractGenerator(string protobufMappingFile)
        {
            _mapper = new ProtobufElementMapper(protobufMappingFile);
            if(!_mapper.IsMappingDocumentLoaded)
                _mapper = null;

            _model = TypeModel.Create();
        }


        public RuntimeTypeModel GenerateContractCode(string assemblyName)
        {
            if (_mapper == null)
                return null;

            if (!File.Exists(assemblyName))
                return null;

            _model = TypeModel.Create();

            var assembly = Assembly.LoadFrom(assemblyName);
            var namespaces = assembly.GetTypes().Select(x => x.Namespace).Distinct();
            
            foreach(string ns in namespaces)
                LoadNamespace(ns, assembly);

            return _model;
        }

        private void LoadNamespace(string namespaceName, Assembly assembly)
        {
            var classNames = GetTypesInNamespace(assembly, namespaceName);
            LoadTypes(namespaceName, classNames.ToList());
        }

        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .Where(x => x.IsInterface == false).ToArray();
        }

        private void LoadTypes(string namespaceToLoad, IEnumerable<Type> types)
        {
            foreach (Type t in types)
            {
                AddContractFor(namespaceToLoad, t);

            }
        }

        private void AddContractFor(string namespaceToLoad, Type type)
        {
            if (AlreadyLoaded(type))
                return;

            if (HasBaseType(type))
            {
                AddContractForBaseType(namespaceToLoad, type);
            }

            var fieldsAndProperties = new List<string>();
            fieldsAndProperties.AddRange(GetProperties(type));
            fieldsAndProperties.AddRange(GetFields(type));

            foreach (string field in fieldsAndProperties)
            {
                var typeWithNamespace = namespaceToLoad + "." + type.Name + "." + field;
                var id = _mapper.Map(typeWithNamespace);
                
                if(type.GetGenericArguments().Count() > 1)
                    continue;

                _model[type].Add(id, field);

                var sb = new StringBuilder();
                sb.Append("model[typeof(");
                sb.Append(type.Name);
                sb.Append(")].Add(");
                sb.Append(id);
                sb.Append(@", """);
                sb.Append(field);
                sb.Append(@""");");
                
                Debug.WriteLine(sb.ToString());
            }
        }

        private IEnumerable<string> GetFields(Type type)
        {
            var privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var names = new List<string>();
            foreach (var field in privateFields)
            {
                if (!field.IsDefined(typeof(CompilerGeneratedAttribute), false))
                    names.Add(field.Name);
            }
            return names;
        }

        private IEnumerable<string> GetProperties(Type type)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var names = new List<string>();
            foreach (var property in properties)
            {
                if (!property.PropertyType.Name.StartsWith("Func") &&
                    !property.PropertyType.Name.StartsWith("Action"))
                    names.Add(property.Name);
            }

            return names;
        }

        private void AddContractForBaseType(string namespaceToLoad, Type type)
        {
            var baseType = type.BaseType;
            var typeWithNamespace = namespaceToLoad + "." + type.Name;

            if (!AlreadyLoaded(baseType))
                AddContractFor(namespaceToLoad, baseType);

            var id = _mapper.Map(typeWithNamespace);

            _model[baseType].AddSubType(id, type);

            var sb2 = new StringBuilder();
            sb2.Append("model[typeof(");
            sb2.Append(baseType.Name);
            sb2.Append(")].AddSubType(");
            sb2.Append(id);
            sb2.Append(", typeof(");
            sb2.Append(type.Name);
            sb2.Append("));");

            Debug.WriteLine(sb2.ToString());
        }


        private bool HasBaseType(Type type)
        {
            if (type.BaseType != typeof(Object))
            {
                return true;
            }

            return false;
        }

        private bool AlreadyLoaded(Type type)
        {
            if (_model[type].GetFields().Count() != 0)
                return true;

            return false;
        }
    }
}

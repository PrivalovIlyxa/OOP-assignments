﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BaseShape;
using System.IO;


namespace PluginSystem
{
    public class PluginLoader<T> where T : Shape
    {
        public static ICollection<Type> LoadPlugins(string path)
        {
            string[] dllFileNames = null;

            if (Directory.Exists((path)))
            {
                dllFileNames = Directory.GetFiles(path, "*.dll");

                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                foreach (string dllFile in dllFileNames)
                {
                    AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                    Assembly assembly = Assembly.Load(an);
                    assemblies.Add(assembly);
                }

                Type pluginType = typeof(T);
                ICollection<Type> pluginTypes = new List<Type>();
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();

                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                //if (type.GetInterface(pluginType.FullName) != null)
                                if (pluginType.IsAssignableFrom(type))
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }
                return pluginTypes;
            }
            return null;
        }
    }
}

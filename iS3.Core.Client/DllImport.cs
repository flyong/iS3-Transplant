﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public class DllImport
    {
        public static Dictionary<string, Extensions> domainExtension = new Dictionary<string, Extensions>();
        public static List<Tools> toolList = new List<Tools>();
        public static Dictionary<string, Assembly> assemblyDict = new Dictionary<string, Assembly>();
        static List<Assembly> _loadedExtensions = new List<Assembly>();
        static List<Assembly> _loadedTools = new List<Assembly>();
        public static void InitExtension()
        {
            if (domainExtension != null)
            {
                foreach (var key in domainExtension.Keys)
                {
                    domainExtension[key].init();
                }
            }
        }
        public static void InitTool()
        {
            if (toolList != null)
            {
                foreach (var tool in toolList)
                {
                    tool.init();
                }
            }
        }
        public static void LoadExtension()
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            //Assembly exeAssembly = Assembly.GetExecutingAssembly();
            string exeLocation = System.IO.Directory.GetCurrentDirectory();
            string extensionsPath = exeLocation + "\\extensions";

            if (!Directory.Exists(extensionsPath))
                return;

            // try to load *.dll in bin\extensions\
            var files = Directory.EnumerateFiles(extensionsPath, "*.dll",
                SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                // skip the assembly that has been loaded
                string shortName = Path.GetFileName(file);
                if (allAssemblies.Any(x => x.ManifestModule.Name == shortName))
                    continue;

                // Assembly.LoadFile doesn't resolve dependencies, 
                // so don't use Assembly.LoadFile
                Assembly assembly = Assembly.LoadFrom(file);
                if (assembly != null)
                    _loadedExtensions.Add(assembly);
            }

            // call init() in extensions
            foreach (Assembly assembly in _loadedExtensions)
            {
                // call init() function in the loaded assembly
                var types = from type in assembly.GetTypes()
                            where type.IsSubclassOf(typeof(Extensions))
                            select type;
                foreach (var type in types)
                {
                    object obj = Activator.CreateInstance(type);
                    Extensions extension = obj as Extensions;
                    if (extension == null)
                        continue;
                    domainExtension[extension.domain] = extension;

                }
                if (assembly.FullName.Split(',').Length > 0)
                {
                    assemblyDict[assembly.FullName.Split(',')[0]] = assembly;
                }

            }
        }
        public static void LoadTools()
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            //Assembly exeAssembly = Assembly.GetExecutingAssembly();
            string exeLocation = System.IO.Directory.GetCurrentDirectory();
            string toolsPath = exeLocation + "\\tools";

            if (!Directory.Exists(toolsPath))
                return;

            // try to load *.dll in bin\extensions\
            var files = Directory.EnumerateFiles(toolsPath, "*.dll",
                SearchOption.TopDirectoryOnly);
            try
            {


                foreach (string file in files)
                {
                    // skip the assembly that has been loaded
                    string shortName = Path.GetFileName(file);
                    if (allAssemblies.Any(x => x.ManifestModule.Name == shortName))
                        continue;

                    // Assembly.LoadFile doesn't resolve dependencies, 
                    // so don't use Assembly.LoadFile
                    Assembly assembly = Assembly.LoadFrom(file);
                    if (assembly != null)
                        _loadedTools.Add(assembly);
                }

                // call init() in extensions
                foreach (Assembly assembly in _loadedTools)
                {
                    // call init() function in the loaded assembly
                    var types = from type in assembly.GetTypes()
                                where type.IsSubclassOf(typeof(Tools))
                                select type;
                    foreach (var type in types)
                    {
                        object obj = Activator.CreateInstance(type);
                        Tools tool = obj as Tools;
                        if (tool == null)
                            continue;
                        toolList.Add(tool);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
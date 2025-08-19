using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Loading
{
    /// <summary>
    /// Discovers plugins by scanning .NET assemblies in a folder and loading all public types
    /// implementing <see cref="IImageEffect"/>. This is a dynamic add/remove mechanism without
    /// changing the rest of the application.
    /// </summary>
    public sealed class PluginCatalog
    {
        public IReadOnlyList<IImageEffect> LoadFromFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath)) throw new ArgumentException("Folder path is required", nameof(folderPath));
            if (!Directory.Exists(folderPath)) throw new DirectoryNotFoundException(folderPath);

            var effects = new List<IImageEffect>();
            var assemblyFiles = Directory.EnumerateFiles(folderPath, "*.dll", SearchOption.TopDirectoryOnly);
            foreach (var file in assemblyFiles)
            {
                Assembly? asm = null;
                try
                {
                    asm = Assembly.LoadFrom(file);
                }
                catch
                {
                    continue;
                }

                try
                {
                    var candidates = asm
                        .GetTypes()
                        .Where(t => typeof(IImageEffect).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null);

                    foreach (var type in candidates)
                    {
                        if (Activator.CreateInstance(type) is IImageEffect effect)
                        {
                            effects.Add(effect);
                        }
                    }
                }
                catch
                {
                    // ignore assembly/type load errors to keep catalog resilient
                }
            }

            return effects;
        }
    }
}



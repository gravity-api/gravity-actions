/*
 * CHANGE LOG - keep only last 5 threads
 */
using System;
using System.IO;
using System.Reflection;

namespace Gravity.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Assembly"/> and <see cref="System.Reflection"/> objects.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Writes an embedded resource to a file.
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> from which to read the resource.</param>
        /// <param name="path">Path on which to write the file. The file name must match the resource file name.</param>
        public static void WriteEmbeddedResource(this Assembly assembly, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var fileReference = Array
                .Find(assembly.GetManifestResourceNames(), i => i.EndsWith(Path.GetFileName(path), StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(fileReference))
            {
                return;
            }

            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using var resource = assembly.GetManifestResourceStream(fileReference);
            using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
            resource.CopyTo(file);
        }

        /// <summary>
        /// Reads an embedded resource.
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> from which to read the resource.</param>
        /// <param name="name">Resource name. Name must match the resource file name.</param>
        public static string ReadEmbeddedResource(this Assembly assembly, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            var fileReference = Array.Find(assembly.GetManifestResourceNames(), i => i.EndsWith(Path.GetFileName(name), StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(fileReference))
            {
                return string.Empty;
            }

            var stream = assembly.GetManifestResourceStream(fileReference);
            using StreamReader reader = new(stream);
            return reader.ReadToEnd();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
namespace MannusWallPaper
{
    public static class AssemblyExtension
    {
        #region Public Extension Methods
        /// <summary>
        /// Finds a file next to assembly, for example the configuration file
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="FileNotFoundException">In case of the file is not found</exception>
        /// <returns>path to the file</returns>
        public static string FindFileNextToAssembly(this Assembly assembly, string fileName)
        {
            string uriString = assembly.CodeBase;          
            Uri uri = new Uri(uriString);
            string path = Path.Combine(Path.GetDirectoryName(uri.LocalPath), fileName);
            if (!File.Exists(path)) throw new FileNotFoundException("File is not found next to assembly", path);
            return path;
        }
        #endregion
    }
}
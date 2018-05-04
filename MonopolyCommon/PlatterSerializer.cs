using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace MonopolyCommon
{
    /// <summary>
    /// Class to provide platter de/serialization.
    /// </summary>
    public static class PlatterSerializer
    {
        /// <summary>
        /// Serialize platter to file = saving
        /// </summary>
        /// <param name="_platter">platter to serialize/save</param>
        /// <returns>true if succeded</returns>
        public static bool Serialize(Platter _platter)
        {
            var fileInfo = new FileInfo(_platter.PathFile);
            if (fileInfo.Directory != null && fileInfo.Directory.Exists)
            {
                var serializer = new XmlSerializer(typeof(Platter));
                using (var sw = new StreamWriter(_platter.PathFile))
                {
                    try
                    {
                        serializer.Serialize(sw, _platter);
                    }
                    catch (InvalidOperationException e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deserialize file to platter = loading
        /// </summary>
        /// <param name="_path">path of the file to deserialize/load</param>
        /// <returns></returns>
        public static Platter Deserialize(string _path)
        {
            var fileInfo = new FileInfo(_path);
            if (fileInfo.Exists)
            {
                Platter platter = null;
                using (var sr = new StreamReader(_path))
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(Platter));
                        platter = (Platter) serializer.Deserialize(sr);

                        //TODO : CHECK IF COIN CASE

                        platter.PathFile = fileInfo.FullName;
                        platter.AlreadySerialize = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        MessageBox.Show(e.Message);
                        return null;
                    }
                }
                return platter;
            }
            return null;
        }
    }
}

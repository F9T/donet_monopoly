using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace MonopolyCommon
{
    public static class PlatterSerializer
    {
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
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static Platter Deserialize(string _path)
        {
            var fileInfo = new FileInfo(_path);
            if (fileInfo.Exists)
            {
                Platter platter = null;
                var serializer = new XmlSerializer(typeof(Platter));
                using (var sr = new StreamReader(_path))
                {
                    try
                    {
                        platter = (Platter) serializer.Deserialize(sr);
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

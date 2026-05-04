using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dal;

internal class XMLTools
{
    public static void SaveListToXMLSerializer<T>(List<T> list, string filePath)
    {
        using FileStream file = new FileStream(filePath, FileMode.Create);
        XmlSerializer x = new XmlSerializer(typeof(List<T>));
        x.Serialize(file, list);
    }

    public static List<T> LoadListFromXMLSerializer<T>(string filePath)
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0) return new List<T>();
        using FileStream file = new FileStream(filePath, FileMode.Open);
        XmlSerializer x = new XmlSerializer(typeof(List<T>));
        return (List<T>)x.Deserialize(file)!;
    }


   
}

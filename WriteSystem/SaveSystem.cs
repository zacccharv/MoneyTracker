using System.Xml.Serialization;
using MoneyTracker.Data.LineItems;

namespace MoneyTracker.WriteSystem;

public static class SaveSystem
    {
        static string _path = $"D:/c# projects/MoneyTracker/Data/Database/MoneyData.txt";
        // public static GameData LoadGame()
        // {
        //     if (File.Exists(_path))
        //     {
        //         XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        //         FileStream fileStream = new(_path, FileMode.Open);    

        //         GameData data = serializer.Deserialize(fileStream) as GameData;

        //         fileStream.Close();

        //         return data;
        //     }
        //     else
        //     {
        //         Debug.LogError($"Save file not found at {_path}");
        //         return new GameData();
        //     }
        // }

        public static void SaveGame(ILineItems lineItems)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ILineItems));

            FileStream fileStream = new(_path, FileMode.Create);

            serializer.Serialize(fileStream, lineItems);

            fileStream.Close();
        }
}

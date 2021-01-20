using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public static class UpdateDatabaseService 
    {

        public static string GetPlayerHealth()
        {
            //var data = LoadPlayerData();
            //return data.PlayerHealth;
            return null;
        }

        public static string GetPlayerScore()
        {
            return string.Empty;
        }


        public static void UpdatePlayerHealth()
        {

        }

        //public static void UpdatePlayerScore(int value, )
        //{
        //    SavePlayerData();
        //}

        public static Player LoadPlayerData()
        {
            string path = Application.persistentDataPath + "/player.data";
            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                Player data = formatter.Deserialize(stream) as Player;
                stream.Close();

                return data;
            }
            else
            {
                return null;
            }
        }

        public static void SavePlayerData(int score, int health, int location)
        {
            
            var playerData = new Player
            {
                PlayerHealth = health.ToString(),
                PlayerScore = score.ToString(),
                PlayerLocation = location.ToString()
            };

            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/player.data";

            var stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, playerData);
            stream.Close();

            //var playerData = new Player();
            //using (StreamReader reader = new StreamReader("Assets/Data/pixelflow.json"))
            //{
            //    var json = reader.ReadToEnd();
            //    playerData = JsonUtility.FromJson<Player>(json);
            //}

            // return playerData;
        }
    }
}

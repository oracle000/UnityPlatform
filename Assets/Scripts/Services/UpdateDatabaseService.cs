using System.IO;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class UpdateDatabaseService : IUpdateDatabaseService 
    {

        public string GetPlayerHealth()
        {
            var data = ReadJSONFile();
            return data.PlayerHealth;
        }

        public string GetPlayerScore()
        {
            return null;
        }


        public void UpdatePlayerHealth()
        {

        }

        public void UpdatePlayerScore()
        {

        }
        

        public Player ReadJSONFile()
        {
            var playerData = new Player();
            using (StreamReader reader = new StreamReader("Assets/Data/pixelflow.json"))
            {
                var json = reader.ReadToEnd();
                playerData = JsonUtility.FromJson<Player>(json);
            }

            return playerData;
        }
    }

    interface IUpdateDatabaseService
    {

        void UpdatePlayerScore();
        void UpdatePlayerHealth();
        string GetPlayerHealth();

        Player ReadJSONFile();
    }
}


using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class Player
    {
        public string PlayerScore;
        public string PlayerHealth;
        public string PlayerLocation;

        public Player()
        {

        }

        public Player(string score, string health, string location)
        {
            PlayerScore = score;
            PlayerHealth = health;
            PlayerLocation = location;
        }
    }
}

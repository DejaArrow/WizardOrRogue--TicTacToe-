using System;

namespace WoR
{
    public struct Score 
    {
        public int Points {get; set;}
        public string PlayerName {get; set;}

        public Score(int points, string playerName)
        {
            this.Points = points;
            this.PlayerName = playerName;
        }

        public override string ToString()
        {
            return $"Name: {PlayerName, 15}.   |    Score: {Points} ";
        }

    }
}
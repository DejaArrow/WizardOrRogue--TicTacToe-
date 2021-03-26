using System;
using System.Collections.Generic;

namespace WoR
{
    /// <summary>
    /// Strategy Design Pattern.
    /// <!-- Having different scoring alogorithms provides a reason to choose between a wizard or a rogue. A Wizard does better on the straights, Rogues work best on diagonals-->
    /// </summary>
    public abstract class CalculateScoreAlgorithm
    {
        public abstract int CalculateScore(string winType);
        
    }

    public class WizardScoreAlgorithm : CalculateScoreAlgorithm
    {
        public override int CalculateScore(string winType)
        {
            switch (winType.ToLower())
            {
                case "horizontal win": 
                    return Program.rmd.Next(75, 100);
                
                case "vertical win": 
                    return Program.rmd.Next(75, 100);
               
                case "diagonal win": 
                    return Program.rmd.Next(0, 50);
                
                default: return 0;
                
            }
            //A Wizard scores bonus points for vertical or horizontal wins. 
        }
    }

    public class RogueScoreAlgorithm : CalculateScoreAlgorithm
    {
        public override int CalculateScore(string winType)
        {
            switch (winType.ToLower())
            {
                case "horizontal win": 
                    return Program.rmd.Next(0, 50);
                
                case "vertical win": 
                    return Program.rmd.Next(0, 50);
               
                case "diagonal win": 
                    return Program.rmd.Next(85, 100);
                
                default: return 0;
                
            }
            //A Rogue scores bonus points for scoring diagonally. 
        }
    }
  
    public static class ScoreBoard
    /// <summary>
    /// Singleton Design Pattern
    /// </summary>
    {


        public static CalculateScoreAlgorithm ScoreAlgorithm{get; set;}

        private static object _lockThis = new object();
        //Lock Object to prevent more than one thread accessing the scoreboard at the same time. 
        static List<Score> ScoreList = new List<Score>();

        public static void getScore()
        {
            lock(_lockThis)
            {
                Console.WriteLine("====High Scores====");
                foreach (Score score in ScoreList)
                    {
                        Console.WriteLine(score.ToString());
                    }
            }
        }

        public static void addScore(string playerName, int score)
        {
            lock(_lockThis)
            {
                ScoreList.Add(new Score(score, playerName));
                SortScore();
            }
        }

        private static void SortScore()
        {
            lock (_lockThis)
            {

                Score temp;
                for (int j = 0; j <= ScoreList.Count - 2; j++)
                {
                    for (int i = 0; i <= ScoreList.Count - j - 2; i++)
                    {
                        if (ScoreList[i].Points < ScoreList[i + 1].Points)
                        {
                            temp = ScoreList[i];
                            ScoreList[i] = ScoreList[i + 1];
                            ScoreList[i + 1] = temp;
                        }
                    }
                } // Bubble Sorts the Score into Ascending order for display.
            }

        }
    }
}





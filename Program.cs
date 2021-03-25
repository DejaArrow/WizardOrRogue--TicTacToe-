using System;

namespace WoR
{
    //Wizards or Rogues

    public static class Program
    {
        public static Random rmd = new Random();
        static Character player1 = null;
        static Character player2 = null;
        public static char playerMarker = ' ';
        static int noOfTurns = 0; 
        //Counts number of turns. Once it is equal to 10, it'll end the game and show winner.

        public static char[] TTTBoard =
        {
            '1', '2', '3','4', '5', '6','7', '8', '9'
        };
        //Numbers available for players to select, to place their marker. 

        static void Main(string[] args)
        {
            int player = 1;
            int input = 0;
            bool inputCorrect = true;
            string characterType;




            do
            {
                Console.WriteLine($"Player {player}, Are you a Wizard  or a Rogue?: ");
                characterType = Console.ReadLine();
                switch (characterType.ToLower())
                {
                    case "wizard":
                        Console.WriteLine("Do you play with Fire or Ice?");
                        characterType = Console.ReadLine();
                        //Calling the Factory Method Design Pattern
                        CharacterFactory wizard = new WizardCharacterFactory();
                        if (player == 1)
                        {
                            player1 = wizard.CreateCharacter(characterType);
                        }
                        else
                        {
                            player2 = wizard.CreateCharacter(characterType);
                        }
                        player++;
                        break;


                    case "rogue":
                        Console.WriteLine("Do you a stealth or a trapper?");
                        characterType = Console.ReadLine();
                        CharacterFactory rogue = new RogueCharacterFactory();
                        if (player == 1)
                        {
                            player1 = rogue.CreateCharacter(characterType);
                        }
                        else
                        {
                            player2 = rogue.CreateCharacter(characterType);
                        }
                        player++;
                        break;
                    default: throw new ArgumentException("Invalid subClass.", "subClass");
                }
            } while (player < 3);

            Console.WriteLine($"Player 1,{player1.GetType()} ");
            Console.WriteLine($"Player 2,{player2.GetType()} ");
            player = 2;

            do 
            {
                if (player == 2)
                {
                    player = 1;
                   
                }
                else if (player == 1)
                {
                    player = 2;
                    
                }

                DrawBoard();
                noOfTurns++;

                if (noOfTurns == 10)
                {
                    Tie();

                }
                //Alternates player turns.




                do
                {
                    Console.WriteLine($"\n Player {player}: It's your turn!");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (TTTBoard[0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (TTTBoard[1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (TTTBoard[2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (TTTBoard[3] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (TTTBoard[4] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (TTTBoard[5] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (TTTBoard[6] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (TTTBoard[7] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (TTTBoard[8] == '9'))
                        inputCorrect = true;
                    else
                    {

                        Console.WriteLine("Please try again.");
                        inputCorrect = false;

                    }

                    if (inputCorrect)
                    {
                        SIFT(player, input);
                    }
                    //Replaces number on tile with player marker.


                } while (!inputCorrect);

                HorizontalWin();
                VerticalWin();
                DiagonalWin();
                //Checks win conditions.

            } while (true);


        }

        public static void DrawBoard()

        {


            //Draws tic tac toe board on console. 
            {
                Console.Clear();
                Console.WriteLine($"Player 1,{player1.GetType()} ");
                Console.WriteLine($"Player 2,{player2.GetType()} ");
                Console.WriteLine("  -------------------------");
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", TTTBoard[0], TTTBoard[1], TTTBoard[2]);
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  -------------------------");
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", TTTBoard[3], TTTBoard[4], TTTBoard[5]);
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  -------------------------");
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", TTTBoard[6], TTTBoard[7], TTTBoard[8]);
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  -------------------------");


            }
        }

        public static void BoardReset()
        {
            char[] TTTBoardInitialize =
            {
                '1', '2', '3','4', '5', '6','7', '8', '9'
            };

            TTTBoard = TTTBoardInitialize;
            DrawBoard();
            noOfTurns = 0;
            //Resets board after win condition met.
        }
        public static void SIFT(int player, int input)
        {

            if (player == 1){ playerMarker = player1.DrawSymbol; }
            else if (player == 2) { playerMarker = player2.DrawSymbol; }
            

            switch (input)
            {
                case 1: TTTBoard[0] = playerMarker; break;
                case 2: TTTBoard[1] = playerMarker; break;
                case 3: TTTBoard[2] = playerMarker; break;
                case 4: TTTBoard[3] = playerMarker; break;
                case 5: TTTBoard[4] = playerMarker; break;
                case 6: TTTBoard[5] = playerMarker; break;
                case 7: TTTBoard[6] = playerMarker; break;
                case 8: TTTBoard[7] = playerMarker; break;
                case 9: TTTBoard[8] = playerMarker; break;
            }

            Console.ForegroundColor = ConsoleColor.Gray;

        }
        public static void HorizontalWin()
        {
            char[] playerSignatures = { player1.DrawSymbol, player2.DrawSymbol };

            foreach (char playerSignature in playerSignatures)
            {
                if (((TTTBoard[0] == playerSignature) && (TTTBoard[1] == playerSignature) && (TTTBoard[2] == playerSignature))
                    || ((TTTBoard[3] == playerSignature) && (TTTBoard[4] == playerSignature) && (TTTBoard[5] == playerSignature))
                    || ((TTTBoard[6] == playerSignature) && (TTTBoard[7] == playerSignature) && (TTTBoard[8] == playerSignature)))
                {
                    Console.Clear();
                    if (playerSignature == player1.DrawSymbol)
                    {
                        Console.WriteLine("Congratulations Player 1. You win! ");
                        //Part of the Strategy Design Pattern
                        if (player1.GetType() == typeof(IceWizard) || player1.GetType() == typeof(FireWizard))
                        {
                            ScoreBoard.ScoreAlgorithm = new WizardScoreAlgorithm();
                            ScoreBoard.addScore("player 1", ScoreBoard.ScoreAlgorithm.CalculateScore("horizontal win"));
                        }
                        if (player1.GetType() == typeof(StealthRogue) || player1.GetType() == typeof(TrapperRogue))
                        {
                            ScoreBoard.ScoreAlgorithm = new RogueScoreAlgorithm();
                            ScoreBoard.addScore("player 1", ScoreBoard.ScoreAlgorithm.CalculateScore("horizontal win"));
                        }

                    }
                    else 
                    {
                        Console.WriteLine("Congratulations Player 2. You win! ");
                        if (player2.GetType() == typeof(IceWizard) || player2.GetType() == typeof(FireWizard))
                        {
                            ScoreBoard.ScoreAlgorithm = new WizardScoreAlgorithm();
                            ScoreBoard.addScore("player 2", ScoreBoard.ScoreAlgorithm.CalculateScore("horizontal win"));
                        }
                        if (player2.GetType() == typeof(StealthRogue) || player2.GetType() == typeof(TrapperRogue))
                        {
                            ScoreBoard.ScoreAlgorithm = new RogueScoreAlgorithm();
                            ScoreBoard.addScore("player 2", ScoreBoard.ScoreAlgorithm.CalculateScore("horizontal win"));
                        }
                    }
                    ScoreBoard.getScore();



                    Console.WriteLine("Please press any key to reset the game");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            } //Checks board for horizontal win
        }
        public static void VerticalWin()
        {
            char[] playerSignatures = { player1.DrawSymbol, player2.DrawSymbol };
            foreach (char playerSignatue in playerSignatures)
            {
                if (((TTTBoard[0] == playerSignatue) && (TTTBoard[3] == playerSignatue) && (TTTBoard[6] == playerSignatue))
                    || ((TTTBoard[1] == playerSignatue) && (TTTBoard[4] == playerSignatue) && (TTTBoard[7] == playerSignatue))
                    || ((TTTBoard[2] == playerSignatue) && (TTTBoard[5] == playerSignatue) && (TTTBoard[8] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == player1.DrawSymbol)
                    {
                        Console.WriteLine("Congratulations Player 1. You win! ");
                        //Part of the Strategy Design Pattern
                        if (player1.GetType() == typeof(IceWizard) || player1.GetType() == typeof(FireWizard))
                        {
                            ScoreBoard.ScoreAlgorithm = new WizardScoreAlgorithm();
                            ScoreBoard.addScore("player 1", ScoreBoard.ScoreAlgorithm.CalculateScore("vertical win"));
                        }
                        if (player1.GetType() == typeof(StealthRogue) || player1.GetType() == typeof(TrapperRogue))
                        {
                            ScoreBoard.ScoreAlgorithm = new RogueScoreAlgorithm();
                            ScoreBoard.addScore("player 1", ScoreBoard.ScoreAlgorithm.CalculateScore("vertical win"));
                        }

                    }
                    else
                    {
                        Console.WriteLine("Congratulations Player 2. You win! ");
                        if (player2.GetType() == typeof(IceWizard) || player2.GetType() == typeof(FireWizard))
                        {
                            ScoreBoard.ScoreAlgorithm = new WizardScoreAlgorithm();
                            ScoreBoard.addScore("player 2", ScoreBoard.ScoreAlgorithm.CalculateScore("vertical win"));
                        }
                        if (player2.GetType() == typeof(StealthRogue) || player2.GetType() == typeof(TrapperRogue))
                        {
                            ScoreBoard.ScoreAlgorithm = new RogueScoreAlgorithm();
                            ScoreBoard.addScore("player 2", ScoreBoard.ScoreAlgorithm.CalculateScore("vertical win"));
                        }
                    }
                    ScoreBoard.getScore();


                    Console.WriteLine("Please press any key to reset the game");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            } //Checks board for vertical win
        }

        public static void DiagonalWin()
        {
            char[] playerSignatures = { player1.DrawSymbol, player2.DrawSymbol };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((TTTBoard[0] == playerSignatue) && (TTTBoard[4] == playerSignatue) && (TTTBoard[8] == playerSignatue))
                    || ((TTTBoard[6] == playerSignatue) && (TTTBoard[4] == playerSignatue) && (TTTBoard[2] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == player1.DrawSymbol)
                    {
                        Console.WriteLine("Congratulations Player 1. You win! ");
                        //Part of the Strategy Design Pattern
                        if (player1.GetType() == typeof(IceWizard) || player1.GetType() == typeof(FireWizard))
                        {
                            ScoreBoard.ScoreAlgorithm = new WizardScoreAlgorithm();
                            ScoreBoard.addScore("player 1", ScoreBoard.ScoreAlgorithm.CalculateScore("diagonal win"));
                        }
                        if (player1.GetType() == typeof(StealthRogue) || player1.GetType() == typeof(TrapperRogue))
                        {
                            ScoreBoard.ScoreAlgorithm = new RogueScoreAlgorithm();
                            ScoreBoard.addScore("player 1", ScoreBoard.ScoreAlgorithm.CalculateScore("diagonal win"));
                        }

                    }
                    else 
                    {
                        Console.WriteLine("Congratulations Player 2. You win! ");
                        if (player2.GetType() == typeof(IceWizard) || player2.GetType() == typeof(FireWizard))
                        {
                            ScoreBoard.ScoreAlgorithm = new WizardScoreAlgorithm();
                            ScoreBoard.addScore("player 2", ScoreBoard.ScoreAlgorithm.CalculateScore("diagonal win"));
                        }
                        if (player2.GetType() == typeof(StealthRogue) || player2.GetType() == typeof(TrapperRogue))
                        {
                            ScoreBoard.ScoreAlgorithm = new RogueScoreAlgorithm();
                            ScoreBoard.addScore("player 2", ScoreBoard.ScoreAlgorithm.CalculateScore("diagonal win"));
                        }
                    }
                    ScoreBoard.getScore();


                    Console.WriteLine("Please press any key to reset the game");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            } //Checks board for diagonal win
        }

        public static void Tie()
        {

            {
                Console.WriteLine("Tie!" +
                                  "\nPlease press any key to reset the game and try again!");
                Console.ReadKey();
                BoardReset();

            }
        } //Calls a tie if all turns are taken up.
    }
}

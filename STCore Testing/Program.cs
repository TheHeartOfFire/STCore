using STCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STCore.EventArgs;

namespace STCore_Testing
{
    internal class Program
    {
        private static GameCore game;

        static void Main(string[] args)
        {
            game = new GameCore();

            game.Initialize(3);

            game.InitStarted += Game_InitStarted;
            game.InitEnded += Game_InitEnded;
            game.PlayingStarted += Game_PlayingStarted;
            game.PlayingRoundStarted += Game_PlayingRoundStarted;
            game.GetScoreboard().PlayingPointsChanged += Program_PlayingPointsChanged;
            game.PlayingRoundEnded += Game_PlayingRoundEnded;
            game.PlayingEnded += Game_PlayingEnded;
            game.GameOverStarted += Game_GameOverStarted;
            game.GetTieBreaker().GameOverTieStarted += Program_GameOverTieStarted;
            game.GetTieBreaker().GameOverTieEnded += Program_GameOverTieEnded;
            game.GameOverEnded += Game_GameOverEnded;

            DoRounds();
        }

        private static void DoRounds()
        {
            int readerIndex = 0;
            while(game.GetCurrentRound() <= game.GetRoundCount())
            {
                Console.WriteLine("What are the selections for this round? Enter " + game.GetPlayerCount() + " selections.");
                string input = Console.ReadLine();
                var stage1 = input.Split(',');
                int[] selections = new int[stage1.Length];
                for (int i = 0; i < selections.Length; i++)
                    selections[i] = int.Parse(stage1[i]);

                game.ProcessRound(readerIndex, selections, false, false);
                readerIndex = (readerIndex + 1) % game.GetPlayerCount();
            }

        }

        private static void Game_GameOverEnded(GameOverArgs e)
        {
            Console.WriteLine("Winner is: " + e.Winner);
            Console.WriteLine("Points: " + e.Scoreboard.GetPoints().ToString());
            Console.WriteLine("Tokens: " + e.TieBreaker.GetTokens().ToString());

            Console.WriteLine("GAME_OVER: End");
            Console.ReadLine();
        }


        private static void Program_GameOverTieEnded(TieBreakArgs e)
            => Console.WriteLine("GAME_OVER: TIEBREAKER: End\nPlayer " + (e.Winner+1).ToString() + " won the tie!");

        private static void Program_GameOverTieStarted()
            => Console.WriteLine("GAME_OVER: TIEBREAKER: Start");

        private static void Game_GameOverStarted()
            => Console.WriteLine("GAME_OVER: Start");

        private static void Game_PlayingEnded()
            => Console.WriteLine("PLAYING: End");

        private static void Game_PlayingRoundEnded()
            => Console.WriteLine("PLAYING: ROUND: End");

        private static void Program_PlayingPointsChanged(PointsChangedArgs e)
            => Console.WriteLine("PLAYING: POINTS: Change\n" +
                "Player " + (e.Player + 1).ToString() + " received " + e.PointDelta.ToString() + " points!");

        private static void Game_PlayingRoundStarted(RoundArgs e)
            => Console.WriteLine("PLAYING: ROUND: Start\n" +
                "Reader: " + e.ReaderIndex + "\n" +
                "Selections: " + e.Selections.ToString() + "\n" +
                "Wild: " + (e.IsShield ? "Shield" : e.IsSword ? "Sword" : "None"));

        private static void Game_PlayingStarted()
            => Console.WriteLine("PLAYING: Start");

        private static void Game_InitEnded(InitArgs e)
            => Console.WriteLine("INIT: End\n" +
                "Starting a " + e.PlayerCount.ToString() + " player game!");

        private static void Game_InitStarted()
            => Console.WriteLine("INIT: Start");
    }
}

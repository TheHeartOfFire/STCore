using STCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCore_Testing
{
    internal class Program
    {
        private static GameCore game;

        static void Main(string[] args)
        {
            game = new GameCore(3);
            
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

        private static void Game_GameOverEnded()
        {
            Console.WriteLine("Winner is: " + game.GetWinner());

            Console.WriteLine("GAME_OVER: End");
            Console.ReadLine();
        }


        private static void Program_GameOverTieEnded()
            => Console.WriteLine("GAME_OVER: TIEBREAKER: End");

        private static void Program_GameOverTieStarted()
            => Console.WriteLine("GAME_OVER: TIEBREAKER: Start");

        private static void Game_GameOverStarted()
            => Console.WriteLine("GAME_OVER: Start");

        private static void Game_PlayingEnded()
            => Console.WriteLine("PLAYING: End");

        private static void Game_PlayingRoundEnded()
            => Console.WriteLine("PLAYING: ROUND: End");

        private static void Program_PlayingPointsChanged()
            => Console.WriteLine("PLAYING: POINTS: Change");

        private static void Game_PlayingRoundStarted()
            => Console.WriteLine("PLAYING: ROUND: Start");

        private static void Game_PlayingStarted()
            => Console.WriteLine("PLAYING: Start");

        private static void Game_InitEnded()
            => Console.WriteLine("INIT: End");

        private static void Game_InitStarted()
            => Console.WriteLine("INIT: Start");
    }
}

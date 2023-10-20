using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STCore.GameCore;

namespace STCore
{
    public class TieBreaker
    {
        private readonly int[] tokens;
        public int[] GetTokens() => tokens;
        public event Notify GameOverTieStarted;
        protected virtual void OnGameOverTieStarted() => GameOverTieStarted?.Invoke();
        public event Notify GameOverTieEnded;
        protected virtual void OnGameOverTieEnded() => GameOverTieEnded?.Invoke();
        public TieBreaker(int playerCount)
        {
            tokens = new int[playerCount];
            GenerateTokens();
        }

        private void GenerateTokens()
        {
            List<int> possibleTokens = new List<int>();
            for(int i = 0; i < tokens.Length; i++) 
                possibleTokens.Add(i);

            var rand = new Random();
            for (int i = 0; i < tokens.Length; i++)
            {
                int idx = rand.Next(0, possibleTokens.Count());
                tokens[i] = possibleTokens[idx];
                possibleTokens.RemoveAt(idx);
            }
        }

        public int BreakTie(int player1, int player2)
        {
            if (tokens[player1] > tokens[player2])
                return player1;
            return player2;
        }
        
        public int BreakTie(int[] players)
        {
            OnGameOverTieStarted();
            if (players.Length < 2) return players[0];
            if(players.Length < 3) return BreakTie(players[0], players[1]);

            int winner = 0;

            for (int i = 1; i < players.Length; i++)
                winner = Array.IndexOf(players, BreakTie(players[winner], players[i]));

            Console.WriteLine("TieBreaker.BreakTie(int[] players) | Actual winner: " + winner);

            OnGameOverTieEnded();
            return winner;
        }
    }
}

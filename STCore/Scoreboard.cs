using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STCore.EventArgs;
using static STCore.GameCore;

namespace STCore
{
    public class Scoreboard
    {
        private int[] points;
        public int[] GetPoints() => points;
        public event PointsChangedEventHandler PlayingPointsChanged;
        protected virtual void OnPlayingPointsChanged(PointsChangedArgs e) => PlayingPointsChanged?.Invoke(e);
        public Scoreboard(int playerCount)
        {
            points = new int[playerCount];
        }

        /// <summary>
        /// Add a qty of points to a idx player
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="qty"></param>
        public void AddPoints(int idx, int qty)
        {
            points[idx] += qty;
            OnPlayingPointsChanged(new PointsChangedArgs(qty, idx, points));
        }
        /// <summary>
        /// Iterates through every score in points to find the largest one, then return a list of players with that score.
        /// </summary>
        /// <returns>List<int> of players who have the winning score.</int></returns>
        public List<int> GetWinners()
        {
            List<int> winners = new List<int>();

            int winningScore = 0;

            foreach (int score in points)
                if (score > winningScore)
                    winningScore = score;

            for (int i = 0; i < points.Length; i++)
                if (points[i] == winningScore)
                    winners.Add(i);

            return winners;
        }
    }
}

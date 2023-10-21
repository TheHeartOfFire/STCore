using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCore
{
    public class EventArgs
    {
        public class InitArgs : System.EventArgs 
        {
            public int PlayerCount { get; }
            public TieBreaker TieBreaker { get; }
            public InitArgs(int playerCount, TieBreaker tieBreaker)
            {
                PlayerCount = playerCount;
                TieBreaker = tieBreaker;
            }
        }
        public class RoundArgs : System.EventArgs
        {
            public int ReaderIndex { get; }
            public int[] Selections { get; }
            public bool IsShield { get; }
            public bool IsSword { get; }
            public Scoreboard Scoreboard { get; }
            public RoundArgs(int readerIndex, int[] selections, bool isShield, bool isSword, Scoreboard scoreboard)
            {
                ReaderIndex = readerIndex;
                Selections = selections;
                IsShield = isShield;
                IsSword = isSword;
                Scoreboard = scoreboard;
            }
        }
        public class PointsChangedArgs : System.EventArgs
        {
            public int PointDelta { get; }
            public int Player { get; }
            public int[] NewPoints { get; }
            public PointsChangedArgs(int pointDelta, int player, int[] newPoints)
            {
                PointDelta = pointDelta;
                Player = player;
                NewPoints = newPoints;
            }
        }
        public class TieBreakArgs : System.EventArgs
        {
            public int[] Tokens { get; }
            public int[] TiedPlayers { get; }
            public int Winner { get; }

            public TieBreakArgs(int[] tokens, int[] tiedPlayers, int winner)
            {
                Tokens = tokens;
                TiedPlayers = tiedPlayers;
                Winner = winner;
            }
        }
        public class GameOverArgs : System.EventArgs
        {
            public int Winner { get; }
            public Scoreboard Scoreboard { get; }
            public TieBreaker TieBreaker { get; }
            public GameOverArgs(int winner, Scoreboard scoreboard, TieBreaker tieBreaker)
            {
                Winner = winner;
                Scoreboard = scoreboard;
                TieBreaker = tieBreaker;
            }
        }



    }
}

using STCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STCore_Testing
{
    public class STCoreUnitTests
    {
        private readonly GameCore _sut;

        public STCoreUnitTests()
        {
            _sut = new GameCore();
        }


        [Theory]
        //3 player games
        //No tie
        [InlineData(3, new int[] { 0 }), InlineData(3, new int[] { 1 }),
            InlineData(3, new int[] { 2 })]
        //2 way ties
        [InlineData(3, new int[] { 0, 1 }), InlineData(3, new int[] { 0, 2 }),
            InlineData(3, new int[] { 1, 2 })]
        //3 way ties
        [InlineData(3, new int[] { 0, 1, 2 })]

        //4 player games
        //No tie
        [InlineData(4, new int[] { 0 }), InlineData(4, new int[] { 1 }),
            InlineData(4, new int[] { 2 }), InlineData(4, new int[] { 3 })]
        //2 way tie
        [InlineData(4, new int[] { 0, 1 }), InlineData(4, new int[] { 0, 2 }),
            InlineData(4, new int[] { 0, 3 }), InlineData(4, new int[] { 1, 2 }),
            InlineData(4, new int[] { 1, 3 }), InlineData(4, new int[] { 2, 3 })]
        //3 way tie
        [InlineData(4, new int[] { 0, 1, 2 }), InlineData(4, new int[] { 0, 1, 3 }),
            InlineData(4, new int[] { 1, 2, 3 })]
        //4 way tie
        [InlineData(4, new int[] { 0, 1, 2, 3 })]

        //5 player games
        //No tie
        [InlineData(5, new int[] { 0 }), InlineData(5, new int[] { 1 }),
            InlineData(5, new int[] { 2 }), InlineData(5, new int[] { 3 }),
            InlineData(5, new int[] { 4 })]
        //2 way tie
        [InlineData(5, new int[] { 0, 1 }), InlineData(5, new int[] { 0, 2 }),
            InlineData(5, new int[] { 0, 3 }), InlineData(5, new int[] { 0, 4 }),
            InlineData(5, new int[] { 1, 2 }), InlineData(5, new int[] { 1, 3 }),
            InlineData(5, new int[] { 1, 4 }), InlineData(5, new int[] { 2, 3 }),
            InlineData(5, new int[] { 2, 4 }), InlineData(5, new int[] { 3, 4 })]
        //3 way tie
        [InlineData(5, new int[] { 0, 1, 2 }), InlineData(5, new int[] { 0, 1, 3 }),
            InlineData(5, new int[] { 0, 1, 4 }), InlineData(5, new int[] { 1, 2, 3 }),
            InlineData(5, new int[] { 1, 2, 4 }), InlineData(5, new int[] { 2, 3, 4 })]
        //4 way tie
        [InlineData(5, new int[] { 0, 1, 2, 3 }), InlineData(5, new int[] { 0, 1, 2, 4 }),
            InlineData(5, new int[] { 1, 2, 3, 4 })]
        //5 way tie
        [InlineData(5, new int[] { 0, 1, 2, 3, 4 })]

        //6 player game
        //No tie
        [InlineData(6, new int[] { 0 }), InlineData(6, new int[] { 1 }),
            InlineData(6, new int[] { 2 }), InlineData(6, new int[] { 3 }),
            InlineData(6, new int[] { 4 }), InlineData(6, new int[] { 5 })]
        //2 way tie
        [InlineData(6, new int[] { 0, 1 }), InlineData(6, new int[] { 0, 2 }),
            InlineData(6, new int[] { 0, 3 }), InlineData(6, new int[] { 0, 4 }),
            InlineData(6, new int[] { 0, 5 }), InlineData(6, new int[] { 1, 2 }),
            InlineData(6, new int[] { 1, 3 }), InlineData(6, new int[] { 1, 4 }),
            InlineData(6, new int[] { 1, 5 }), InlineData(6, new int[] { 2, 3 }),
            InlineData(6, new int[] { 2, 4 }), InlineData(6, new int[] { 2, 5 }),
            InlineData(6, new int[] { 3, 4 }), InlineData(6, new int[] { 3, 5 }),
            InlineData(6, new int[] { 4, 5 })]
        //3 way tie
        [InlineData(6, new int[] { 0, 1, 2 }), InlineData(6, new int[] { 0, 1, 3 }),
            InlineData(6, new int[] { 0, 1, 4 }), InlineData(6, new int[] { 0, 1, 5 }),
            InlineData(6, new int[] { 1, 2, 3 }), InlineData(6, new int[] { 1, 2, 4 }),
            InlineData(6, new int[] { 1, 2, 5 }), InlineData(6, new int[] { 2, 3, 4 }),
            InlineData(6, new int[] { 2, 3, 5 }), InlineData(6, new int[] { 3, 4, 5 })]
        //4 way tie
        [InlineData(6, new int[] { 0, 1, 2, 3 }), InlineData(6, new int[] { 0, 1, 2, 4 }),
            InlineData(6, new int[] { 0, 1, 2, 5 }), InlineData(6, new int[] { 1, 2, 3, 4 }),
            InlineData(6, new int[] { 1, 2, 3, 5 }), InlineData(6, new int[] { 2, 3, 4, 5 })]
        //5 way tie
        [InlineData(6, new int[] { 0, 1, 2, 3, 4 }), InlineData(6, new int[] { 0, 1, 2, 3, 5 }),
            InlineData(6, new int[] { 1, 2, 3, 4, 5 })]
        //6 way tie
        [InlineData(6, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void FullGame(int players, int[] tieingPlayers)
        {
            _sut.Initialize(players);

            var withPoints = new int[players];
            var withoutPoints = new int[players];
            for (int i = 0; i < players; i++)
            {
                if (tieingPlayers.Contains(i) || tieingPlayers.Length == 1)
                    withPoints[i] = 1;
                withoutPoints[i] = i;
            }

            for (int i = 0; i < players * 2; i++)
                _sut.ProcessRound(i % players,
                    tieingPlayers.Contains(i) ? withPoints : withoutPoints,
                    false, false);

            var expected = _sut.GetTieBreaker().BreakTie(tieingPlayers);
            var actual = _sut.GetWinner();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 0 }, new int[] { -1, -1, -1, 1, -1, -1 }, // shield, round 4
           new int[] { 1, 0, 2 },// reader 0 | points 0, 0, 0 | no point increase
           new int[] { 2, 2, 1 },// reader 1 | points 1, 1, 0 | +1 to 0 and 1
           new int[] { 0, 1, 2 },// reader 2 | points 1, 1, 0 | no point increase
           new int[] { 1, 0, 1 },// reader 0 | points 1, 0, 0 | shield, -1 to 1
           new int[] { 2, 1, 2 },// reader 1 | points 1, 0, 0 | no point increase
           new int[] { 0, 2, 0 })]//reader 2 | points 2, 0, 1 | +1 to 0 and 2

        [InlineData(new int[] { 1 }, new int[] { -1, -1, -1, 0, -1, -1, -1, -1 },// sword round 4
            new int[] { 1, 1, 2, 2 },// reader 0 | points 1, 1, 0, 0 | +1 to 0 and 1
            new int[] { 0, 3, 0, 3 },// reader 1 | points 1, 2, 0, 1 | +1 to 1 and 3
            new int[] { 2, 0, 0, 2 },// reader 2 | points 1, 3, 1, 1 | +1 to 1 and 2
            new int[] { 3, 1, 1, 3 },// reader 3 | points 0, 3, 1, 1 | sword, -1 to 0
            new int[] { 2, 2, 1, 1 },// reader 0 | points 1, 4, 1, 1 | +1 to 0 and 1
            new int[] { 3, 3, 0, 0 },// reader 1 | points 2, 5, 1, 1 | +1 to 0 and 1
            new int[] { 0, 2, 2, 0 },// reader 2 | points 2, 6, 2, 1 | +1 to 1 and 2
            new int[] { 1, 3, 3, 1 })]//reader 3 | points 3, 6, 2, 2 | +1 to 0 and 4

        [InlineData(new int[] { 0, 1, 2 }, new int[] { -1, -1, -1, -1, -1, 0, -1, 1, -1, -1 },// sword round 6, shield round 8
            new int[] { 2, 2, 4, 0, 2 },// reader 0 | points 2, 1, 0, 0, 1 | +2 to 0, +1 to 1 and 4
            new int[] { 4, 3, 3, 2, 0 },// reader 1 | points 2, 2, 1, 0, 1 | +1 to 1 and 2
            new int[] { 0, 3, 1, 0, 2 },// reader 2 | points 2, 2, 1, 0, 1 | no point increase
            new int[] { 1, 0, 4, 3, 4 },// reader 3 | points 2, 2, 1, 0, 1 | no point increase
            new int[] { 2, 1, 4, 2, 4 },// reader 4 | points 2, 2, 2, 0, 2 | +1 to 2 and 4
            new int[] { 3, 1, 2, 3, 0 },// reader 0 | points 2, 2, 2, 0, 2 | sword, 3 slected by reader, 3 guessed correctly, no point change
            new int[] { 0, 4, 4, 2, 1 },// reader 1 | points 2, 3, 3, 0, 2 | +1 to 1 and 2
            new int[] { 4, 2, 3, 1, 0 },// reader 2 | points 2, 3, 3, -1, 2| shield, no consensus, -1 to 3 [reader + 1]
            new int[] { 2, 4, 0, 2, 1 },// reader 3 | points 3, 3, 3, 0, 2 | +1 to 0 and 3
            new int[] { 3, 1, 0, 3, 4 })]//reader 4 | points 3, 3, 3, 0, 2 | no point increase

        [InlineData(new int[] { 4 }, new int[] { -1, -1, -1, -1, -1, -1, -1, 1, -1, -1, 0, -1 },// shield round 7, sword round 10
            new int[] { 4, 2, 2, 4, 4, 0 },// reader 0 | points 2, 0, 0, 1, 1, 0 | +2 to 0, +1 to 3 and 4
            new int[] { 1, 4, 1, 0, 4, 0 },// reader 1 | points 2, 1, 0, 1, 2, 0 | +1 to 1 and 4
            new int[] { 2, 5, 1, 2, 1, 2 },// reader 2 | points 2, 1, 1, 1, 3, 0 | +1 to 2 and 4
            new int[] { 3, 0, 2, 3, 1, 2 },// reader 3 | points 3, 1, 1, 2, 3, 0 | +1 to 0 and 3
            new int[] { 1, 1, 5, 4, 0, 0 },// reader 4 | points 3, 1, 1, 2, 4, 1 | +1 to 4 and 5
            new int[] { 5, 5, 0, 1, 3, 3 },// reader 5 | points 3, 1, 1, 2, 5, 2 | +1 to 4 and 5
            new int[] { 0, 4, 4, 2, 3, 2 },// reader 0 | points 3, 1, 1, 2, 4, 2 | shield, -1 to 4
            new int[] { 4, 2, 2, 1, 0, 0 },// reader 1 | points 3, 2, 2, 2, 4, 2 | +1 to 1 and 2
            new int[] { 2, 4, 0, 3, 3, 1 },// reader 2 | points 3, 2, 2, 2, 4, 2 | no point increase
            new int[] { 3, 1, 0, 2, 4, 4 },// reader 3 | points 3, 2, 1, 2, 4, 2 | sword, -1 to 2
            new int[] { 1, 5, 5, 0, 0, 1 },// reader 4 | points 3, 2, 1, 3, 5, 2 | +1 to 3 and 4
            new int[] { 5, 0, 2, 4, 4, 5 })]//reader 5 | points 4, 2, 1, 3, 5, 3 | +1 to 0 and 5

        [InlineData(new int[] { 1, 2 }, new int[] { -1, -1, -1, 0, -1, -1, -1, -1 },// sword round 4
            new int[] { 1, 3, 2, 0 },// reader 0 | points  0, 0, 0, 0 | no point increase
            new int[] { 3, 1, 2, 1 },// reader 1 | points  0, 1, 0, 1 | +1 to 1 and 3
            new int[] { -1, 0, 2, 1 },//reader 2 | points -1, 1, 1, 1 | -1 to 0, +1 to 2
            new int[] { 2, 1, 3, -1 },//reader 3 | points -1, 1, 1, 0 | sword, -1 to 3
            new int[] { 3, 2, 1, 1 },// reader 0 | points -1, 1, 1, 0 | no point increase
            new int[] { -1, 1, 0, 3 },//reader 1 | points -2, 2, 1, 0 | -1 to 0, +1 to 1
            new int[] { 0, 3, 2, 2 },// reader 2 | points -2, 2, 2, 1 | +1 to 2 and 3
            new int[] { 2, 3, 1, 0 })]//reader 3 | points -2, 2, 2, 1 | no point change
        public void RealisticFullGame(int[] winners, int[] wilds, params int[][] selections)
        {
            var players = selections[0].Length;
            _sut.Initialize(players);

            for (int i = 0; i < selections.Length; i++)
                _sut.ProcessRound(i % players,
                    selections[i],
                    wilds[i] == 1, wilds[i] == 0);

            var expected = _sut.GetTieBreaker().BreakTie(winners);
            var actual = _sut.GetWinner();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 1, 0, 0 },0,  1)]
        [InlineData(new int[] { -1, 0, 0 },0,  -1)]
        [InlineData(new int[] { 0, 1, 0 }, 1, 1)]
        [InlineData(new int[] { 0, -1, 0 }, 1, -1)]
        [InlineData(new int[] { 0, 0, 1 }, 2, 1)]
        [InlineData(new int[] { 0, 0, -1 }, 2, -1)]
        public void AddPoints(int[] expected,int playerIndex,  int points)
        {
            _sut.Initialize(3);

            _sut.GetScoreboard().AddPoints(playerIndex, points);

            var actual = _sut.GetScoreboard().GetPoints();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TokenDistribution()
        {
            _sut.Initialize(3);
            var tokens = _sut.GetTieBreaker().GetTokens();

            int[] valueQty = new int[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
                valueQty[tokens[i]]++;

            var actual = 1;

            foreach (var value in valueQty)
                actual *= value;

            Assert.Equal(1, actual);

        }
    }
}

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
        private readonly GameCore _sut3;
        private readonly GameCore _sut4;
        private readonly GameCore _sut5;
        private readonly GameCore _sut6;

        public STCoreUnitTests()
        {
            _sut3 = new GameCore(3);
            _sut4 = new GameCore(4);
            _sut5 = new GameCore(5);
            _sut6 = new GameCore(6);
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
        [InlineData(3, new int[] {0, 1, 2})]

        //4 player games
        //No tie
        [InlineData(4, new int[] { 0 }), InlineData(4, new int[] { 1 }), 
            InlineData(4, new int[] { 2 }), InlineData(4, new int[] { 3 })]
        //2 way tie
        [InlineData(4, new int[] { 0, 1 }), InlineData(4, new int[] { 0, 2 }), 
            InlineData(4, new int[] { 0, 3 }), InlineData(4, new int[] { 1, 2 }), 
            InlineData(4, new int[] { 1, 3 }), InlineData(4, new int[] { 2, 3 })]
        //3 way tie
        [InlineData(4, new int[] {0, 1, 2}), InlineData(4, new int[] { 0, 1, 3 }), 
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
        [InlineData(5, new int[] {0, 1, 2, 3, 4})]

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
        [InlineData(5, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void FullGame(int players, int[] tyeingPlayers)
        {
            GameCore _sut;

            var withPoints = new int[players];
            var withoutPoints = new int[players];
            for (int i = 0; i < players; i++)
            {
                if(tyeingPlayers.Length == 1)
                {
                    withPoints[i]++;
                    if(tyeingPlayers[0] == i)
                        withPoints[i]++;
                }

                if (tyeingPlayers.Length > 1)
                    if (tyeingPlayers.Contains(i))
                        withPoints[i] = 1;
                withoutPoints[i] = i;
            }

            switch (players)
            {
                case 3:
                    _sut = _sut3;
                    break;
                case 4:
                    _sut = _sut4;
                    break;
                case 5:
                    _sut = _sut5;
                    break;
                case 6:
                    _sut = _sut6;
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(players));

            }

            for (int i = 0; i < players * 2; i++)
                _sut.ProcessRound(i % players,
                    i == tyeingPlayers[0] ? withPoints : withoutPoints,
                    false, false);

            var expected = _sut.GetTieBreaker().BreakTie(tyeingPlayers);
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
            _sut3.GetScoreboard().AddPoints(playerIndex, points);

            var actual = _sut3.GetScoreboard().GetPoints();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TokenDistribution()
        {
            var tokens = _sut3.GetTieBreaker().GetTokens();
            int[] valueQty = new int[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
                valueQty[tokens[i]]++;

            var actual = 1;

            foreach (var value in valueQty)
                actual *= value;

            Assert.Equal(1, actual);

        }

        [Theory]
        [InlineData(0,1)]
        [InlineData(0,2)]
        [InlineData(1,2)]
        public void BreakTie(int p1Index, int p2Index)
        {
            var tokens = _sut3.GetTieBreaker().GetTokens();
            var p1 = tokens[p1Index];
            var p2 = tokens[p2Index];

            var expected = p1Index;
            if(p2 > p1)
                expected = p2Index;

            var actual = _sut3.GetTieBreaker().BreakTie(p1Index, p2Index);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Break3Tie()
        {
            var tokens = _sut3.GetTieBreaker().GetTokens();

            var expected = 0;

            if (tokens[0] < tokens[1])
                if (tokens[1] < tokens[2])
                    expected = 2;
                else
                    expected = 1;
            else
                if(tokens[0] < tokens[2])
                    expected = 2;

            var actual = _sut3.GetTieBreaker().BreakTie(new int[] {0, 1, 2});
            Assert.Equal(expected, actual);

        }
    }
}

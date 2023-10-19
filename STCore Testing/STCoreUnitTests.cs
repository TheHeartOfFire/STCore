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
        [InlineData(0, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(1, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(2, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(0, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(1, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 })]
        [InlineData(2, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 1, 1 })]
        public void ThreePlayerRoundsNoTie(int expected, params int[][] selections)
        {
            for (int i = 0; i < selections.Length; i++)
                _sut3.ProcessRound(i % 3, selections[i], false, false);

            var actual = _sut3.GetWinner();
            Assert.Equal( expected, actual);
        }
        
        [Theory]
        [InlineData(0,1,new int[] { 1, 1, 0 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(0,2,new int[] { 0, 1, 2 }, new int[] { 1, 0, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(1,2,new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]

        [InlineData(0,1,new int[] { 1, 1, 0 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(0,2,new int[] { 0, 1, 2 }, new int[] { 1, 0, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 1, 0, 1 }, new int[] { 0, 1, 2 })]
        [InlineData(1,2,new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 1 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new int[] { 0, 1, 1 })]
        public void ThreePlayerRounds2WayTie(int p1Index, int p2Index, params int[][] selections)
        {
            for (int i = 0; i < selections.Length; i++)
                _sut3.ProcessRound(i % 3, selections[i], false, false);

            var expected = _sut3.GetTieBreaker().BreakTie(p1Index, p2Index);
            var actual = _sut3.GetWinner();
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

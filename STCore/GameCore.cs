using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STCore.EventArgs;

namespace STCore
{
    public class GameCore
    {
        public delegate void Notify();
        public delegate void InitEventHandler(InitArgs e);
        public delegate void RoundEventHandler(RoundArgs e);
        public delegate void PointsChangedEventHandler(PointsChangedArgs e);
        public delegate void TieBreakEventHandler(TieBreakArgs e);
        public delegate void GameOverEventHandler(GameOverArgs e);
        //INIT Events
        public event Notify InitStarted;
        protected virtual void OnInitStarted() => InitStarted?.Invoke();
        public event InitEventHandler InitEnded;
        protected virtual void OnInitEnded(InitArgs e) => InitEnded?.Invoke(e);
        //PLAYING Events
        public event Notify PlayingStarted;
        protected virtual void OnPlayingStarted() => PlayingStarted?.Invoke();
        public event RoundEventHandler PlayingRoundStarted;
        protected virtual void OnPlayingRoundStarted(RoundArgs e) => PlayingRoundStarted?.Invoke(e);
        public event Notify PlayingRoundEnded;
        protected virtual void OnPlayingRoundEnded() => PlayingRoundEnded?.Invoke();
        public event Notify PlayingEnded;
        protected virtual void OnPlayingEnded() => PlayingEnded?.Invoke();
        //GAME_OVER Events
        public event Notify GameOverStarted;
        protected virtual void OnGameOverStarted() => GameOverStarted?.Invoke();
        public event GameOverEventHandler GameOverEnded;
        protected virtual void OnGameOverEnded(GameOverArgs e) => GameOverEnded?.Invoke(e);

        public enum GAMESTATE
        {
            INIT,
            PLAYING,
            GAME_OVER
        };

        private GAMESTATE CurrentGameState;
        public void ChangeGameState(GAMESTATE newState)
        {
            switch (CurrentGameState)
            {
                case GAMESTATE.INIT:
                    OnInitEnded(new InitArgs( PlayerCount, breaker));
                    break;
                    case GAMESTATE.PLAYING:
                    OnPlayingEnded();
                    break ;
                    case GAMESTATE.GAME_OVER:
                    OnGameOverEnded( new GameOverArgs(winner, score, breaker));
                    break;
            }
            CurrentGameState = newState;
            switch (CurrentGameState)
            {
                case GAMESTATE.INIT:
                    OnInitStarted();
                    break;
                case GAMESTATE.PLAYING:
                    OnPlayingStarted();
                    break;
                case GAMESTATE.GAME_OVER:
                    OnGameOverStarted();
                    break;
            }
        }
        public string GetGameState()
        {
            string state = "ERROR: INVALID GAME STATE";
            switch(CurrentGameState)
            {
                case GAMESTATE.INIT: 
                    state = "INIT";
                    break;
                case GAMESTATE.PLAYING:
                    state = "PLAYING";
                    break;
                case GAMESTATE.GAME_OVER:
                    state = "GAME OVER";
                    break;

            };

            return state;
        }

        private int PlayerCount;
        public int GetPlayerCount() => PlayerCount;
        public int GetRoundCount() => PlayerCount * 2;
        private int currentRound = 1;
        public int GetCurrentRound() => currentRound;
        private Scoreboard score;
        public Scoreboard GetScoreboard() => score;
        private TieBreaker breaker;
        public TieBreaker GetTieBreaker() => breaker;
        private int winner = -1;
        public int GetWinner() => winner;
        
        public void Initialize(int playerCount)
        {
            ChangeGameState(GAMESTATE.INIT);
            PlayerCount = playerCount;
            score = new Scoreboard(playerCount);
            breaker = new TieBreaker(playerCount);
            ChangeGameState(GAMESTATE.PLAYING);
        }

        public void ProcessRound(int readerIndex, int[] selections, bool isShield, bool isSword)
        {
            if (CurrentGameState != GAMESTATE.PLAYING)
                throw new Exception("Invalid gamestate: Tried to process a round while still initializing! Please run x before trying to process a round.");

            OnPlayingRoundStarted(new RoundArgs(readerIndex, selections, isShield, isSword, score));

            if (selections[readerIndex] == -1)
            {
                score.AddPoints(readerIndex, -1);
            }
            else if (isShield)
            {
                Dictionary<int, int> vote = new Dictionary<int, int>();

                for (int i = 0; i < selections.Length; i++)
                {
                    if (!vote.ContainsKey(selections[i]))
                        vote.Add(selections[i], 0);

                    vote[selections[i]]++;
                }

                int loser = readerIndex == 0 ? 1 : 0;

                foreach (int i in vote.Keys)
                    if (vote[i] > vote[loser] && i != readerIndex)
                        loser = i;

                

                score.AddPoints(vote.Keys.Count == selections.Length ? (readerIndex + 1) % selections.Length : loser, -1);
            }
            else if (isSword)
            {
                score.AddPoints(selections[readerIndex], -1);

                for (int i = 0; i < selections.Length; i++)
                    if (selections[i] == selections[readerIndex] && i != readerIndex)
                        score.AddPoints(i, 1);
            }
            else for (int i = 0; i < selections.Length; i++)
            {

                if(i != readerIndex)
                {
                    if (selections[i] == -1)
                    {
                        score.AddPoints(i, -1);
                        score.AddPoints(readerIndex, 1);
                        
                    }
                    else if (selections[i] == selections[readerIndex])
                    {
                        score.AddPoints(i, 1);
                        score.AddPoints(readerIndex, 1);
                    }
                }
            }

            OnPlayingRoundEnded(); //TODO: add event args to show new current round
            currentRound++;
            if (GetCurrentRound() > GetRoundCount())
                winner = ProcessGameEnd();
        }

        private int ProcessGameEnd()
        {

            ChangeGameState(GAMESTATE.GAME_OVER);

            var winners = score.GetWinners();
            
            if(winners.Count == 1)
                return winners[0];

            OnGameOverEnded(new GameOverArgs(winner, score, breaker));
            return breaker.BreakTie(winners.ToArray());
        }
    }
}

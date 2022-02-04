namespace ArmchairCricket.Gameplay
{
    public class Scorer
    {
        private int[] runs;
        private int[] wickets;
        private MatchState matchState = MatchState.FirstInnings;
        public Scorer()
        {
            runs = new int[2];
            wickets = new int[2];
            runs[0] = 0;
            runs[1] = 0;
            wickets[0] = 0;
            wickets[1] = 0;
        }
        public void Score(BallOutcome outcome)
        {
            int i = GetInningsIndex();
            switch (outcome)
            {
                case BallOutcome.Wicket:
                    wickets[i]++;
                    break;
                case BallOutcome.OneRun:
                    runs[i] = runs[i] + 1;
                    break;
                case BallOutcome.TwoRuns:
                    runs[i] = runs[i] + 2;
                    break;
                case BallOutcome.ThreeRuns:
                    runs[i] = runs[i] + 3;
                    break;
                case BallOutcome.FourRuns:
                    runs[i] = runs[i] + 4;
                    break;
                case BallOutcome.SixRuns:
                    runs[i] = runs[i] + 6;
                    break;
            }
            EvaluateState();
        }

        private void EvaluateState()
        {
            switch (matchState)
            {
                case MatchState.FirstInnings:
                    if (wickets[0] >= 10)
                    {
                        matchState = MatchState.SecondInnings;
                    }
                    break;
                case MatchState.SecondInnings:
                    if (wickets[1] >= 10 || runs[1] > runs[0])
                    {
                        matchState = MatchState.MatchFinished;
                    }
                    break;
                case MatchState.MatchFinished:
                    break;
                default:
                    throw new Exception("Invalid match state " + matchState);
            }
        }
        private int GetInningsIndex()
        {
            int i;
            switch (matchState)
            {
                case MatchState.FirstInnings:
                    i = 0;
                    break;
                case MatchState.SecondInnings:
                    i = 1;
                    break;
                default:
                    throw new Exception("Invalid match state " + matchState);
            }
            return i;
        }
        public string GetLatestScore()
        {
            String s;
            switch (matchState)
            {
                case MatchState.FirstInnings:
                    s = getInningsScoreString(0);
                    break;
                case MatchState.SecondInnings:
                    s = getInningsScoreString(1) + " (opposition scored "
                        + getInningsScoreString(0) + ")";
                    break;
                case MatchState.MatchFinished:
                    if (runs[0] > runs[1])
                    {
                        s = "Team batting first won by " + pluralizeString(runs[0] - runs[1], "run");
                    }
                    else if (runs[1] > runs[0])
                    {
                        s = "Team batting second won by " + pluralizeString(10 - wickets[1], "wicket");
                    }
                    else
                    {
                        s = "Match tied";
                    }
                    break;
                default:
                    s = "UNKNOWN";
                    break;
            }
            return s;
        }
        private string pluralizeString(int i, string word)
        {
            string s;
            if (i == 1)
            {
                s = i + " " + word;
            }
            else
            {
                s = i + " " + word + "s";
            }
            return s;
        }
        private string getInningsScoreString(int i)
        {
            string s;
            if (wickets[i] < 10)
            {
                s = runs[i] + "-" + wickets[i];
            }
            else
            {
                s = runs[i] + " all out";
            }
            return s;
        }

        public bool IsEndOfMatch()
        {
            return (matchState == MatchState.MatchFinished);
        }
    }
}

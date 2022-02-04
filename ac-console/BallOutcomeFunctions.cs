namespace ArmchairCricket.Gameplay
{
    public static class BallOutcomeFunctions
    {
        public static int NumRuns(this BallOutcome outcome) {
            int runs = 0;
            switch (outcome)
            {
                case BallOutcome.Wicket:
                    break;
                case BallOutcome.OneRun:
                    runs = 1;
                    break;
                case BallOutcome.TwoRuns:
                    runs = 2;
                    break;
                case BallOutcome.ThreeRuns:
                    runs = 3;
                    break;
                case BallOutcome.FourRuns:
                    runs = 4;
                    break;
                case BallOutcome.SixRuns:
                    runs = 6;
                    break;
            }
            return runs;
        }

        public static bool isWicket(this BallOutcome ballOutcome) {
            return ballOutcome == BallOutcome.Wicket;
        }
    }
}

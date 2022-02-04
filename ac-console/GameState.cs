namespace ArmchairCricket.Gameplay
{
    public class GameState
    {
        public const int CARDS_IN_HAND = 6;
        private Pack pack;
        private Scorer scorer;
        private Card[] batterHand;
        private Card[] bowlerHand;
        public GameState()
        {
            pack = new Pack();
            pack.Shuffle();

            scorer = new Scorer();

            batterHand = new Card[CARDS_IN_HAND];
            bowlerHand = new Card[CARDS_IN_HAND];
            
            for (int i = 0; i < CARDS_IN_HAND; i++)
            {
                batterHand[i] = pack.dealNextCard();
                bowlerHand[i] = pack.dealNextCard();
            }
        }

        public void Update(int bowlIndex, int batIndex, BallOutcome outcome)
        {
            bowlerHand[bowlIndex] = pack.dealNextCard();
            batterHand[batIndex] = pack.dealNextCard();

            scorer.Score(outcome);
        }
        public Card[] BatterHand 
        {
            get
            {
                return batterHand;
            }
        }

        public Card[] BowlerHand
        {
            get
            {
                return bowlerHand;
            }
        }

        public String GetLatestScore()
        {
            return scorer.GetLatestScore();
        }
        public bool IsEndOfInnings()
        {
            return scorer.IsEndOfMatch();
        }
    }
}

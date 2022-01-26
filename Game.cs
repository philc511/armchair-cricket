namespace ArmchairCricket.Gameplay
{
    public class Game
    {
        public const int CARDS_IN_HAND = 6;
        private Pack pack = null;
        private Scorer scorer = null;
        private Card[] playerOneHand = null;
        private Card[] playerTwoHand = null;
        private Card currentBowlingCard = null;
        private Card currentBattingCard = null;
        private RulesEngine rules = null;
        private bool isPlayerOneBatting = true;
        public Game()
        {
            pack = new Pack();
            scorer = new Scorer();
            pack.Shuffle();
            rules = new RulesEngine();
            playerOneHand = new Card[CARDS_IN_HAND];
            playerTwoHand = new Card[CARDS_IN_HAND];
            for (int i = 0; i < CARDS_IN_HAND; i++)
            {
                playerOneHand[i] = pack.dealNextCard();
                playerTwoHand[i] = pack.dealNextCard();
            }
        }
        public bool PlayerOneBatting
        {
            get
            {
                return isPlayerOneBatting;
            }
            set 
            {
                isPlayerOneBatting = value;
            }
        }

        public Card[] PlayerOneHand 
        {
            get
            {
                return playerOneHand;
            }
        }

        public Card[] PlayerTwoHand
        {
            get
            {
                return playerTwoHand;
            }
        }

        public void ChooseBowlerCard(int i)
        {
            if (isPlayerOneBatting)
            {
                Card c = playerTwoHand[i];
                currentBowlingCard = c;
                playerTwoHand[i] = pack.dealNextCard();
            }
            else
            {
                Card c = playerOneHand[i];
                currentBowlingCard = c;
                playerOneHand[i] = pack.dealNextCard();
            }
        }
        public void ChooseBatterCard(int i)
        {
            if (isPlayerOneBatting)
            {
                Card c = playerOneHand[i];
                currentBattingCard = c;
                playerOneHand[i] = pack.dealNextCard();
            }
            else
            {
                Card c = playerTwoHand[i];
                currentBattingCard = c;
                playerTwoHand[i] = pack.dealNextCard();
            }
        }

        public String GetBallOutcome()
        {
            BallOutcome result = rules.GetOutcome(currentBowlingCard, currentBattingCard);
            scorer.Score(result);
            return result.ToString();
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

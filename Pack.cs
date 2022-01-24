namespace ArmchairCricket.Gameplay
{
    public class Pack
    {
        private Card[] cards = null;
        private int currentCardCounter = 0;
        public static int numCardsInPack = 2 * 11 * Enum.GetNames(typeof(Suit)).Length;

        public Pack()
        {
            cards = new Card[numCardsInPack];
            int index = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                for (int j = 1; j <= 11; j++)
                {
                    cards[index] = new Card(s, j);
                    index++;
                    cards[index] = new Card(s, j);
                    index++;
                }
            }
        }

        public Card dealNextCard()
        {
            Card dealtCard = cards[currentCardCounter];
            currentCardCounter++;
            if (currentCardCounter >= numCardsInPack)
            {
                currentCardCounter = 0;
            }
            return dealtCard;
        }

        internal void Shuffle()
        {
            Random rnd = new Random();
            Card tmp = null;
            for (int i = 0; i < 1000; i++)
            {
                int first = rnd.Next(numCardsInPack);
                int second = rnd.Next(numCardsInPack);
                tmp = cards[first];
                cards[first] = cards[second];
                cards[second] = tmp;
            }
        }
    }
}

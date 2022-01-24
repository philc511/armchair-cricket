namespace ArmchairCricket.Gameplay
{
    public class Card
    {
        private Suit theSuit;
        private int theValue;
        public Card()
        {
        }

        public Card(Suit s, int i)
        {
            theSuit = s;
            theValue = i;
        }

        public Suit Suit
        {
            get
            {
                return theSuit;
            }
            set
            {
                theSuit = value;
            }
        }
        public int Value
        {
            get
            {
                return theValue;
            }
            set
            {
                theValue = value;
            }
        }
        public override string ToString()
        {
            return (theValue + "\n" + theSuit);
        }
        
    }
}

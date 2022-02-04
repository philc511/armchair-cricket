using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmchairCricket.Gameplay
{
    public class RulesEngine
    {
        public BallOutcome GetOutcome(Card bowlingCard, Card battingCard)
        {
            BallOutcome result = BallOutcome.DotBall;
            if (bowlingCard.Suit == battingCard.Suit)
            {
                result = HandleSameSuit(bowlingCard.Value, battingCard.Value);
            }
            else
            {
                result = HandleDifferentSuit(bowlingCard.Value, battingCard.Value);
            }
            return result;
        }
        private BallOutcome HandleSameSuit(int bowlValue, int batValue)
        {
            BallOutcome result = BallOutcome.DotBall;
            int diff = batValue - bowlValue;
            if (diff > 0)
            {
                switch (diff)
                {
                    case 1:
                    case 2:
                    case 3:
                        result = BallOutcome.OneRun;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        result = BallOutcome.TwoRuns;
                        break;
                    case 7:
                    case 8:
                        result = BallOutcome.ThreeRuns;
                        break;
                    case 9:
                    case 10:
                        result = BallOutcome.FourRuns;
                        break;
                    case 11:
                        result = BallOutcome.SixRuns;
                        break;
                    default:
                        throw new Exception("Unknown combination of balls");
                }
            }
            return result;
        }
        private BallOutcome HandleDifferentSuit(int bowlValue, int batValue)
        {
            BallOutcome result = BallOutcome.DotBall;
            if (batValue < bowlValue)
            {
                result = BallOutcome.Wicket;
            }
            return result;
        }

    }


}

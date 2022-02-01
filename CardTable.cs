class CardTable
Pack
BowlerHand
BatterHand

method BallOutcome bowl()

bowlcard = BowlerHand.getCard()
batcard = BatterHand.getCard()

outcome = RuleEngine.getoutcome(bowlcard, batcard)

bowlerHand.replace(bowlcard)
batterHand.replace(batcard)

return outcome

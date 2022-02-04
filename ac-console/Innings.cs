using ArmchairCricket.Gameplay;

public class Innings {
    public String Play(
        GameState gameState, 
        BowlingStrategy bowlingStrategy, 
        BattingStrategy battingStrategy, 
        RulesEngine rulesEngine)
    {
        while(!gameState.IsEndOfInnings())
        {
            var bowlIndex = bowlingStrategy.ChooseCard();
            var batIndex = battingStrategy.ChooseCard(gameState.BowlerHand[bowlIndex]);

            var outcome = rulesEngine.GetOutcome(gameState.BowlerHand[bowlIndex], gameState.BatterHand[batIndex]);

            gameState.Update(bowlIndex, batIndex, outcome);
            Console.WriteLine(gameState.GetLatestScore());
        }
        return gameState.GetLatestScore();
    }
}
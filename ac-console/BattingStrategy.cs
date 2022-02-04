// See https://aka.ms/new-console-template for more information
using ArmchairCricket.Gameplay;

public class BattingStrategy
{
    private GameState game;

    public BattingStrategy(GameState game)
    {
        this.game = game;
    }

    public int ChooseCard(Card bowlCard)
    {
        int mostRuns = -1;
        int index = -1;
        // look for most runs
        for (int i = 0; i < 6; i++) {
            var outcome = new RulesEngine().GetOutcome(bowlCard, game.BatterHand[i]);
            if (!outcome.isWicket()) {
                var runs = outcome.NumRuns();
                if (runs > mostRuns) {
                    mostRuns = runs;
                    index = i;
                }
            }
        }

        // TODO wicket falling - need to discard the lowest card
        return index;
    }
}
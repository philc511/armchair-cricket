// See https://aka.ms/new-console-template for more information
using ArmchairCricket.Gameplay;

public class BowlingStrategy
{
    private GameState game;

    public BowlingStrategy(GameState game)
    {
        this.game = game;
    }

    public int ChooseCard()
    {
        return new Random().Next(6);
    }
}
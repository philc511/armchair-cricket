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
        return new Random().Next(6);
    }
}
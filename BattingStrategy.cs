// See https://aka.ms/new-console-template for more information
using ArmchairCricket.Gameplay;

internal class BattingStrategy
{
    private Game game;

    public BattingStrategy(Game game)
    {
        this.game = game;
    }

    internal int ChooseCard()
    {
        return new Random().Next(6);    
    }
}
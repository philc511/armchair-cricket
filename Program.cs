// See https://aka.ms/new-console-template for more information
using ArmchairCricket.Gameplay;

var game = new Game(); 
var battingStrategy = new BattingStrategy(game);
var bowlingStrategy = new BowlingStrategy(game);
game.PlayerOneBatting = false;

while(true) {
    game.ChooseBowlerCard(bowlingStrategy.ChooseCard());

    game.ChooseBatterCard(battingStrategy.ChooseCard());

    Console.WriteLine(game.GetBallOutcome().ToString());

    Console.WriteLine(game.GetLatestScore());
    if (game.IsEndOfInnings())
    {
        Console.WriteLine("Game over");
        break;
    }

}

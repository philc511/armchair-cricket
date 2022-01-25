// See https://aka.ms/new-console-template for more information
using ArmchairCricket.Gameplay;

Console.WriteLine("Hello, World!");


var game = new ArmchairCricket.Gameplay.Game(); 
var systemStrategy = new Strategy(game);
game.PlayerOneBatting = false;

while(true) {
    game.ChoosePlayerOneCard(0);

    int systemCardIndex = systemStrategy.ChoosePlayerTwoCard();

    game.ChoosePlayerTwoCard(systemCardIndex);

    Console.WriteLine(game.GetBallOutcome().ToString());

    Console.WriteLine(game.GetLatestScore());
    if (game.IsEndOfInnings())
    {
        Console.WriteLine("Game over");
        break;
    }

}

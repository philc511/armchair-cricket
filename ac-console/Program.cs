// See https://aka.ms/new-console-template for more information
using ArmchairCricket.Gameplay;

var game = new GameState(); 
var battingStrategy = new BattingStrategy(game);
var bowlingStrategy = new BowlingStrategy(game);
var rulesEngine = new RulesEngine();
var innings = new Innings();

Console.WriteLine(innings.Play(game, bowlingStrategy, battingStrategy, rulesEngine));

using Xunit;
using ArmchairCricket.Gameplay;
namespace ac_test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        BattingStrategy strategy = new BattingStrategy(null);
        strategy.ChooseCard(new Card(Suit.Balls, 10));
    }
}
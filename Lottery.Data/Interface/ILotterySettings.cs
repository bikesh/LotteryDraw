namespace Lottery.Data.Interface
{
    public interface ILotterySettings
    {
        int PrimaryNumbersCount { get; }
        int SecondayNumbersCount { get; }
    }
}
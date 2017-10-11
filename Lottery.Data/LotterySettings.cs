using Lottery.Data.Interface;

namespace Lottery.Data
{
    public class LotterySettings : ILotterySettings
    {
        private int _secondaryNumbersCount;
        private int _primaryNumbersCount;

        public int PrimaryNumbersCount { get { return _primaryNumbersCount; } }
        public int SecondayNumbersCount { get { return _secondaryNumbersCount; } }

        public LotterySettings(int primaryNumbersCount, int secondaryNumbersCount)
        {
            _primaryNumbersCount = primaryNumbersCount;
            _secondaryNumbersCount = secondaryNumbersCount;
        }
    }
}
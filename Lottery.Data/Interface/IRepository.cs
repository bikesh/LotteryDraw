using System;
using System.Collections.Generic;
using Lottery.Data.Interface;

namespace Lottery.Data.Interface
{
    public interface IRepository
    {
        IEnumerable<ILottery> GetAllLottery();
        ILottery GetLotteryByDate(DateTime date);
        List<string> Save(ILottery newLottery);
        List<string> SaveWinningNumbers(string lotteryName, List<PrimaryNumbers> primaryNumbers, List<SecondaryNumbers> secondaryNumbers);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data.Interface
{
    public interface ILottery
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime DateOfDraw { get; set; }
        int TotalAmountOfPrimaryNumbers { get; set; }
        LotteryRange PrimaryNumbersRange { get; set; }
        int TotalAmountOfSecondaryNumbers { get; set; }
        LotteryRange SecondaryNumbersRange { get; set; }
        IEnumerable<PrimaryNumbers> WinningPrimaryNumbers { get; set; }
        IEnumerable<SecondaryNumbers> WinningSecondaryNumbers { get; set; }
    }
}

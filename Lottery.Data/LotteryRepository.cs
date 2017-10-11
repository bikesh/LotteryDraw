using System;
using System.Collections.Generic;
using System.Linq;
using Lottery.Data.Interface;
using System.ComponentModel.DataAnnotations;

namespace Lottery.Data
{
    public class LotteryRepository : IRepository
    {
        public static List<ILottery> lotteryTable { get; set; }

        public LotteryRepository()
        {
            if (lotteryTable == null)
                lotteryTable = new List<ILottery>();
        }

        public IEnumerable<ILottery> GetAllLottery()
        {
            return lotteryTable;
        }

        public ILottery GetLotteryByDate(DateTime date)
        {
            return lotteryTable.FirstOrDefault(x => x.DateOfDraw.Equals(date.Date));
        }

        public List<string> Save(ILottery newLottery)
        {
            List<string> message = new List<string>();
            ICollection<ValidationResult> validationResults = null;
            bool isValid = Validator.TryValidateObject(newLottery, new ValidationContext(newLottery), validationResults,true);

            if (isValid)
            {
                lotteryTable.Add(newLottery);
            }
            else
            {
                message = validationResults
                    .Select(x => x.ErrorMessage)
                    .ToList();
            }

            return message;
        }

        public List<string> SaveWinningNumbers(string lotteryName, List<PrimaryNumbers> primaryNumbers, List<SecondaryNumbers> secondaryNumbers)
        {
            List<string> message = new List<string>();

            var lottery = lotteryTable.FirstOrDefault(x => x.Name.Equals(lotteryName, StringComparison.InvariantCultureIgnoreCase));

            if (lottery == null)
                message.Add("key not found.");

            foreach (var item in primaryNumbers)
            {
                if (item.Value < lottery.PrimaryNumbersRange.From || item.Value > lottery.PrimaryNumbersRange.To)
                {
                    message.Add("primary number not in range or incorrect format");
                    break;
                }
            }

            foreach (var item in secondaryNumbers)
            {
                if (item.Value < lottery.SecondaryNumbersRange.From || item.Value > lottery.SecondaryNumbersRange.To)
                {
                    message.Add("secondary number not in range or incorrect format");
                    break;
                }
            }

            if (message.Count == 0)
            {
                ICollection<ValidationResult> validationResults = null;
                bool isValid = Validator.TryValidateObject(primaryNumbers, new ValidationContext(primaryNumbers), validationResults);

                if (isValid)
                {
                    lottery.WinningPrimaryNumbers = primaryNumbers;
                    lottery.WinningSecondaryNumbers = secondaryNumbers;
                }
            }
            return message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lottery.Data.Interface;

namespace Lottery.Data
{
    public class Lottery : ILottery
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateOfDraw { get; set; }
        public int TotalAmountOfPrimaryNumbers { get; set; }
        public LotteryRange PrimaryNumbersRange { get; set; }
        public int TotalAmountOfSecondaryNumbers { get; set; }
        public LotteryRange SecondaryNumbersRange { get; set; }
        public IEnumerable<PrimaryNumbers> WinningPrimaryNumbers { get; set; }
        public IEnumerable<SecondaryNumbers> WinningSecondaryNumbers { get; set; }
        public string WinningPrimaryNumbersCsv
        {
            get
            {
                if (WinningPrimaryNumbers == null)
                    return string.Empty;

                return string.Join(",", WinningPrimaryNumbers.Select(x=>x.Value));
            }
        }

        public string WinningSecondaryNumbersCsv
        {
            get
            {
                if (WinningSecondaryNumbers == null)
                    return string.Empty;

                return string.Join(",", WinningSecondaryNumbers.Select(x=>x.Value));
            }
        }

        public Lottery()
        {
        }
    }





  



   

    public class FileLoger : ILogger
    {
        public void LogException(Exception exception)
        {
            throw new NotImplementedException(nameof(FileLoger));
        }
    }

    public interface ILogger
    {
        void LogException(Exception exception);
    }
}
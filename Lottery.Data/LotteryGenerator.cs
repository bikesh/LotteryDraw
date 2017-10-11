using System;
using System.Collections.Generic;
using Lottery.Data.Interface;
using System.ComponentModel.DataAnnotations;

namespace Lottery.Data
{
    public class LotteryGenerator : ILotteryGenerator
    {
        private DateTime _dateOfDraw;
        private ILotterySettings _lotterSettings;
        private IRepository _repository;
        private ILogger _logger;

        public LotteryGenerator(ILotterySettings lotterSettings, IRepository repository, ILogger logger, DateTime dateOfDraw)
        {
            _lotterSettings = lotterSettings;
            _dateOfDraw = dateOfDraw;
            _repository = repository;
            _logger = logger;
        }

        public LotteryGenerator(DateTime dateOfDraw) : this(
            new LotterySettings(5, 2),
            new LotteryRepository(),
            new FileLoger(),
            dateOfDraw)
        {

        }

        public Lottery GenerateWinningNumbers()
        {
            // find if it has been generated for the date

            var lottery = new Lottery();

            var primaryRange = GetRange(typeof(PrimaryNumbers));
            var secondaryRange = GetRange(typeof(SecondaryNumbers));

            var winningPrimaryNumbers = new List<int>();
            var winingSecondaryNumbers = new List<int>();

            // generate primary numbers
            for (int i = 0; i < _lotterSettings.PrimaryNumbersCount; i++)
            {
                int generatedPrimary;
                if (i == 0)
                {
                    generatedPrimary = GenerateRandom((int)primaryRange.Minimum, (int)primaryRange.Maximum);
                    winningPrimaryNumbers.Add(generatedPrimary);
                    continue;
                }
                do
                {
                    generatedPrimary = GenerateRandom((int)primaryRange.Minimum, (int)primaryRange.Maximum);
                } while (winningPrimaryNumbers.Contains(generatedPrimary));
                winningPrimaryNumbers.Add(generatedPrimary);
            }

            // generate secondary numbers
            for (int i = 0; i < _lotterSettings.SecondayNumbersCount; i++)
            {
                int generatedSecondary;
                if (i == 0)
                {
                    generatedSecondary = GenerateRandom((int)secondaryRange.Minimum, (int)secondaryRange.Maximum);
                    winingSecondaryNumbers.Add(generatedSecondary);
                    continue;
                }
                do
                {
                    generatedSecondary = GenerateRandom((int)primaryRange.Minimum, (int)primaryRange.Maximum);
                } while (winingSecondaryNumbers.Contains(generatedSecondary));
                winningPrimaryNumbers.Add(generatedSecondary);
            }
            return lottery;
        }

        private RangeAttribute GetRange(Type type, string propertyName = "Value")
        {
            var attrs = (RangeAttribute[])type.GetProperty(propertyName).GetCustomAttributes(typeof(RangeAttribute), false);
            return attrs[0];
        }

        public int GenerateRandom(int from, int to)
        {
            return new Random().Next((int)from, (int)to);
        }
    }
}
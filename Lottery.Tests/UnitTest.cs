
using NUnit.Framework;
using Moq;
using Lottery.Data;
using Lottery.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Tests
{
    [TestFixture]
    public class UnitTest
    {
        List<Data.Lottery> lotteries = new List<Data.Lottery>()
            {
                new Data.Lottery() {Name = "follo", Description="follo udent", DateOfDraw= new System.DateTime(2017,1,5), PrimaryNumbersRange = new LotteryRange() { From = 1, To = 49 }, TotalAmountOfPrimaryNumbers = 49, SecondaryNumbersRange = new LotteryRange() { From = 1, To= 10}, TotalAmountOfSecondaryNumbers = 10 },
                new Data.Lottery() {Name = "urbod", Description="uio dose hoies", DateOfDraw= new System.DateTime(2017,1,6), PrimaryNumbersRange = new LotteryRange() { From = 1, To = 30 }, TotalAmountOfPrimaryNumbers = 30, SecondaryNumbersRange = new LotteryRange() { From = 1, To= 5}, TotalAmountOfSecondaryNumbers = 5 },
                new Data.Lottery() {Name = "dfdis", Description="asfas dose hoies", DateOfDraw= new System.DateTime(2017,1,6), PrimaryNumbersRange = new LotteryRange() { From = 1, To = 30 }, TotalAmountOfPrimaryNumbers = 30, SecondaryNumbersRange = new LotteryRange() { From = 1, To= 5}, TotalAmountOfSecondaryNumbers = 5 }
            };

        [Test]
        public void Test_that_lottery_is_added()
        {
            // arrange
            var lottery = new Mock<ILottery>();
            lottery.SetupAllProperties();
            lottery.SetupGet(x => x.Name).Returns("owdwo");
            lottery.SetupGet(x => x.Description).Returns("owdwo");
            lottery.SetupGet(x => x.DateOfDraw).Returns(new System.DateTime(2017, 1, 1));
            LotteryRepository repo = new LotteryRepository();

            // act
            repo.Save(lottery.Object);

            // assert
            Assert.That(repo.GetAllLottery().Count() == 1);
        }

        [Test]
        public void Test_that_lottery_is_updated()
        {
            // arrange
            var lotteryName = "follo";
            Data.Lottery lottery = new Data.Lottery();
            var repo = new LotteryRepository();
            repo.Save(lotteries[0]);
            var winningPrimary = new List<PrimaryNumbers>()
            {
                new PrimaryNumbers() { Value = 1},
                new PrimaryNumbers() { Value = 49},
            };

            var winningSecondary = new List<SecondaryNumbers>()
            {
                new SecondaryNumbers() { Value = 2},
                new SecondaryNumbers() { Value = 10},
            };

            // act
            var messages = repo.SaveWinningNumbers(lotteryName, winningPrimary, winningSecondary);

            // assert
            Assert.That(messages.Count == 0);
        }

        [Test]
        public void Test_that_shows_message_when_numbers_not_in_range()
        {
            // arrange
            var lotteryName = "urbod";
            Data.Lottery lottery = new Data.Lottery();
            var repo = new LotteryRepository();
            repo.Save(lotteries[1]);
            var winningPrimary = new List<PrimaryNumbers>()
            {
                new PrimaryNumbers() { Value = 1},
                new PrimaryNumbers() { Value = 49},
            };

            var winningSecondary = new List<SecondaryNumbers>()
            {
                new SecondaryNumbers() { Value = 2},
                new SecondaryNumbers() { Value = 10},
            };

            // act
            var messages = repo.SaveWinningNumbers(lotteryName, winningPrimary, winningSecondary);

            // assert
            Assert.That(messages.Count > 0);
        }
        
    }
}

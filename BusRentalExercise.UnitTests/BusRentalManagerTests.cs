using System;
using Xunit;

namespace BusRentalExercise.UnitTests {
    public class BusRentalManagerTests : IClassFixture<BusRentalFixture> {
        readonly double initialFee = 2500;

        readonly BusRentalFixture fixture;

        public BusRentalManagerTests(BusRentalFixture fixture) {
           this.fixture = fixture;
        }

        [Fact]
        public void CalculateBusPrice_567km_ExpectedPrice7102() {
            //The distance in kilometers to travel
            double distance = 567;

            //Bus Logic
            double first100km = 1000;
            double next100to500 = 3200;
            double rest = 402;

            double expectedPrice = initialFee + first100km + next100to500 + rest;
            AssertPrice(distance, expectedPrice);
        }

        [Fact]
        public void CalculateBusPrice_421km_ExpectedPrice6068() {
            double distance = 421;

            double first100km = 1000;
            double next100to421 = 2568;

            double expectedPrice = initialFee + first100km + next100to421;
            AssertPrice(distance, expectedPrice);
        }

        [Fact]
        public void CalculateBusPrice_37km_ExpectedPrice2870() {
            double distance = 37;
            double kilometerPrice = 370;

            double expectedPrice = initialFee + kilometerPrice;
            AssertPrice(distance, expectedPrice);
        }

        [Fact]
        public void CalculateBusPrice_0km_ExpectedPrice2500() {
            double distance = 0;

            double expectedPrice = initialFee;
            AssertPrice(distance, expectedPrice);
        }

        [Fact]
        public void CalculateBusPrice_Negativekm_ExpectArgumentOutOfRangeException() {
            double distance = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => fixture.BusRentalManager.CalculateBusPrice(distance));
        }

        void AssertPrice(double distance, double expectedPrice) {
            double price = fixture.BusRentalManager.CalculateBusPrice(distance);
            Assert.Equal(price, expectedPrice);
        }
    }
}

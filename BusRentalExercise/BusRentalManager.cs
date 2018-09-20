using System;

namespace BusRentalExercise {
    public class BusRentalManager {
        readonly double INITIAL_FEE = 2500;
        readonly double kmPriceUnder100 = 10;
        readonly double kmPriceUnder500 = 8;
        readonly double kmPriceOver500 = 6;

        public double CalculateBusPrice(double distanceInKilometers) {
            double price = 0;
            if (distanceInKilometers >= 0) {
                if (distanceInKilometers > 500) {
                    price += kmPriceUnder100 * 100;
                    price += kmPriceUnder500 * 400;
                    price += kmPriceOver500 * (distanceInKilometers - 500);
                } else if (distanceInKilometers > 100) {
                    price += kmPriceUnder100 * 100;
                    price += kmPriceUnder500 * (distanceInKilometers - 100);
                } else {
                    price = distanceInKilometers * kmPriceUnder100;
                }
                price += INITIAL_FEE;
                return price;
            }
            throw new ArgumentOutOfRangeException(nameof(distanceInKilometers), "Negative values not allowed!");
        }
    }
}

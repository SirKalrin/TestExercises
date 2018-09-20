using System;
using Xunit;

namespace BusRentalExercise.UnitTests {
    public class BusRentalFixture {

        public BusRentalManager BusRentalManager { get; }

        public BusRentalFixture() {
            BusRentalManager = new BusRentalManager();
        }
    }
}

using System.Collections.Generic;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MineField.Entities;

namespace MineField.Tests
{
    [TestClass]
    public class MineCounterTests
    {
        [TestMethod]
        public void CalculateWhenFieldPassedThenAppropriateResultExpected()
        {
            // .***.
            // .*.*.
            // .***.
            // .....
            // ....*
            var field = new Field(
                5,
                5,
                new List<MinePoint>
                    {
                        new MinePoint(0, 1),
                        new MinePoint(0, 2),
                        new MinePoint(0, 3),
                        new MinePoint(1, 1),
                        new MinePoint(1, 3),
                        new MinePoint(2, 1),
                        new MinePoint(2, 2),
                        new MinePoint(2, 3),
                        new MinePoint(4, 4)
                    });

            var expected = new[,]
                               {
                                   { 2, 3, 2, 1, 0 },
                                   { -1, -1, -1, 2, 0 },
                                   { -1, 8, -1, 3, 0 },
                                   { -1, -1, -1, 3, 1 },
                                   { 2, 3, 2, 2, -1 }
                               };

            var counter = new MineCounter();
            var result = counter.Calculate(field);

            result.Should().Equal(expected);
        }
    }
}

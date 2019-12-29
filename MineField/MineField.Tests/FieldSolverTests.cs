using System;
using System.Collections.Generic;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MineField.Entities;

using Rhino.Mocks;

namespace MineField.Tests
{
    [TestClass]
    public class FieldSolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitWhenNullGivenThenArgumentNullExceptionExpected()
        {
            var solver = new FieldSolver(null);
        }

        [TestMethod]
        public void GetTextualRepresentationWhenFieldGivenThenCharArrayExpected()
        {
            var mines = new List<MinePoint> { new MinePoint(0, 0) };
            var field = new Field(3, 3, mines);

            var counter = new[,] { { -1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 0 } };
            var expected = new[,] { { '*', '1', '.' }, { '1', '1', '.' }, { '.', '.', '.' } };

            var mineCounter = MockRepository.GenerateMock<IMineCounter>();
            mineCounter.Stub(c => c.Calculate(Arg<Field>.Is.Equal(field))).Return(counter);

            var solver = new FieldSolver(mineCounter);
            var result = solver.GetTextualRepresentation(field);

            result.Should().Equal(expected);
        }
    }
}

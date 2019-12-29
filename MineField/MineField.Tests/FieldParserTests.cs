using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MineField.Entities;

namespace MineField.Tests
{
    [TestClass]
    public class FieldParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitWhenInvalidValuePassedThenArgumentExceptionExpected()
        {
            var parser = new FieldParser(-1);
        }

        [TestMethod]
        public void ParseAsyncWhenInvalidWidthPassedThenArgumentExceptionExpected()
        {
            var parser = new FieldParser();

            Func<Task> act = async () => await parser.ParseAsync(-1, 100, "dummy");
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ParseAsyncWhenInvalidHeightPassedThenArgumentExceptionExpected()
        {
            var parser = new FieldParser();

            Func<Task> act = async () => await parser.ParseAsync(100, -1, "dummy");
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ParseAsyncWhenNullPassedAsFieldThenArgumentNullExceptionExpected()
        {
            var parser = new FieldParser();

            Func<Task> act = async () => await parser.ParseAsync(100, 100, null);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ParseAsyncWhenSquareGivenThenFieldInstanceExpected()
        {
            var input = String.Format("*....{0}..*..{0}.....{0}*....{0}....*", Environment.NewLine);
            var expected = new Field(
                5,
                5,
                new List<MinePoint>
                    {
                        new MinePoint(0, 0),
                        new MinePoint(2, 1),
                        new MinePoint(0, 3),
                        new MinePoint(4, 4)
                    });

            var parser = new FieldParser();
            var actual = parser.ParseAsync(5, 5, input).Result;

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ParseAsyncWhenRectangleFieldGivenThenFieldInstanceExpected()
        {
            var input = String.Format("..{0}*.{0}*.{0}..", Environment.NewLine);
            var expected = new Field(
                2,
                4,
                new List<MinePoint>
                    {
                        new MinePoint(0, 1),
                        new MinePoint(0, 2),
                    });

            var parser = new FieldParser();
            var actual = parser.ParseAsync(2, 4, input).Result;

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ParseAsyncWhenInvalidInputWithShortLineGivenThenExceptionExpected()
        {
            var parser = new FieldParser();
            Func<Task> act = async () => await parser.ParseAsync(10, 10, "...");

            act.ShouldThrow<Exception>();
        }
    }
}

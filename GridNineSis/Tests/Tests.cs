using Gridnine.FlightCodingTest;
using GridNineSis.Code;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace GridNineSis.Tests
{
    [TestFixture]
    public class UndoBufferTests
    {
        [TestCase]
        public void ApplyOldFlightExcludeRuleTest()
        {
            var builder = new FlightBuilder();
            var overallFlightsCount = builder.GetFlights().Count;
            Assert.That(overallFlightsCount, Is.EqualTo(6));

            var oldFlightslessFlights = builder.GetFlights().ApplyOldFlightExcludeRule();
            Assert.That(oldFlightslessFlights.Count, Is.EqualTo(5));
        }

        [TestCase]
        public void ApplyFlyTimeErrorExcludeRuleTest()
        {
            var builder = new FlightBuilder();
            var overallFlightsCount = builder.GetFlights().Count;
            Assert.That(overallFlightsCount, Is.EqualTo(6));

            var oldFlightslessFlights = builder.GetFlights().ApplyFlyTimeErrorExcludeRule();
            Assert.That(oldFlightslessFlights.Count, Is.EqualTo(5));
        }

        [TestCase]
        public void ApplyStayTimeErrorExcludeRuleTest()
        {
            var builder = new FlightBuilder();
            var overallFlightsCount = builder.GetFlights().Count;
            Assert.That(overallFlightsCount, Is.EqualTo(6));

            var oldFlightslessFlights = builder.GetFlights().ApplyStayTimeErrorExcludeRule();
            Assert.That(oldFlightslessFlights.Count, Is.EqualTo(4));
        }

        //[Test]
        //public void UndoAddTest()
        //{
        //    var buffer = new UndoBuffer<int>(2);
        //    buffer.Add(1);
        //    buffer.Add(2);
        //    buffer.Add(3);

        //    Assert.That(buffer.TryGetUndo(out var undo), Is.True);
        //    buffer.Add(4);
        //    Assert.That(buffer.UndoCount, Is.EqualTo(2));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(0));

        //    Assert.That(buffer.TryGetUndo(out undo), Is.True);
        //    Assert.That(undo, Is.EqualTo(4));

        //    Assert.That(buffer.TryGetUndo(out undo), Is.True);
        //    Assert.That(undo, Is.EqualTo(2));
        //    Assert.That(buffer.UndoCount, Is.EqualTo(0));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(2));

        //    buffer.Add(5);
        //    Assert.That(buffer.UndoCount, Is.EqualTo(1));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(0));
        //}

        //[Test]
        //public void BoundTest()
        //{
        //    var buffer = new UndoBuffer<int>(2);
        //    buffer.Add(1);
        //    buffer.Add(2);
        //    buffer.Add(3);
        //    Assert.That(buffer.UndoCount, Is.EqualTo(2));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(0));

        //    Assert.That(buffer.TryGetUndo(out var undo), Is.True);
        //    Assert.That(buffer.UndoCount, Is.EqualTo(1));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(1));

        //    Assert.That(buffer.TryGetUndo(out undo), Is.True);
        //    Assert.That(buffer.UndoCount, Is.EqualTo(0));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(2));

        //    Assert.That(buffer.TryGetUndo(out undo), Is.False);
        //    Assert.That(buffer.UndoCount, Is.EqualTo(0));
        //    Assert.That(buffer.RedoCount, Is.EqualTo(2));

        //    buffer.Add(4);

        //    Assert.That(buffer.TryGetRedo(out var redo), Is.False);
        //}
    }
}
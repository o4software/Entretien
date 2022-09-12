using NUnit.Framework;

namespace Entretien.Test
{
    [TestFixture]
    public class TestMtfSimulator
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void GenerateScenario_Should_Generate_Random_Prices()
        {
            var scenario = MtfSimulator.GenerateScenario(100, 20, 0.05);

            Assert.NotNull(scenario);
            Assert.AreEqual(20, scenario.Length);

            foreach (var price in scenario)
            {
                Assert.IsTrue(Math.Abs(10 - price) >= 5);
            }
        }

        [Test]
        public void GenerateMtf_Should_Generate_Random_Mtf()
        {
            var mtf = MtfSimulator.GenerateMtf(100, 20, 0.05, 10);

            Assert.NotNull(mtf);
            Assert.AreEqual(10, mtf.GetLength(0));
            Assert.AreEqual(20, mtf.GetLength(1));

            foreach (var price in mtf)
            {
                Assert.IsTrue(Math.Abs(10 - price) >= 5);
            }
        }

        [Test]
        public void CaculateStatistics_Should_Return_Coherent_Values()
        {
            var mtf = MtfSimulator.GenerateMtf(100, 20, 0.05, 10);
            var statistics = MtfSimulator.CalculateStatistics(mtf);

            Assert.NotNull(statistics);
            Assert.AreEqual(20, statistics.AverageInTime.Length);
            Assert.AreEqual(20, statistics.StandardDeviationInTime.Length);
        }
    }
}
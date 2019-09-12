using System.Threading.Tasks;

using KolkoKrzyzyk.UWP.Core.Services;

using NUnit.Framework;

namespace KolkoKrzyzyk.UWP.Core.Tests.NUnit
{
    using System.Linq;

    // TODO WTS: Add appropriate unit tests.
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsContentGridDataAsync()
        {
            var actual = await SampleDataService.GetContentGridDataAsync();

            Assert.AreNotEqual(0, actual.Count());
        }
    }
}

using System.Net.Http.Headers;
using NUnit.Framework;

namespace RihnoMockDemo
{
    [TestFixture]
    public class MainClassForTests
    {
        private MainClassForTest _mainClassForTest;

        [SetUp]
        public void SetUp()
        {
            _mainClassForTest = new MainClassForTest();
        }

        [Test]
        public void Test()
        {
            var data = _mainClassForTest.TestPlugIns();

        }
    }
}
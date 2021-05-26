using NSubstitute;
using NUnit.Framework;
using Rhino.Mocks;

namespace RihnoMockDemo
{
    public class CreatePlugInsTestsWithNsubtitute
    {
        private CreatePlugIns _createPlugIns;

        [SetUp]
        public void SetUp()
        {
            var fakePlugInsWithNSubtitute = Substitute.For<IPlugIns>();
            var fakePlugInsWithRhinoMock = MockRepository.GenerateMock<IPlugIns>();

            _createPlugIns = new CreatePlugIns(fakePlugInsWithNSubtitute, fakePlugInsWithRhinoMock);

        }

        [Test]
        public void FirstTest()
        {
            var tempNSub = _createPlugIns.GetAllPlugIns();
            var tempRhinoMock = _createPlugIns.GetAllPlugInsRhinoMock();
        }
    }
}
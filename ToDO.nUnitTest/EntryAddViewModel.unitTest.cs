using NUnit.Framework;

namespace ToDO.nUnitTest
{
    [TestFixture]
    class EntryAddViewModel
    {
        [Test]
        public void EntryAddViewModel_New_AreNotNull()
        {
            var newEntr = new ToDO.EntryAddViewModel();
            Assert.AreNotEqual(null, newEntr);
        }
        [Test]
        public void EntryAddViewModel_New_TitleAreNull()
        {
            var newEntr = new ToDO.EntryAddViewModel();
            Assert.AreEqual(null,newEntr.Title);
        }
        [Test]
        public void EntryAddViewModel_New_TitleAreNotNull()
        {
            var newEntr = new ToDO.EntryAddViewModel() {Title = "Test"};
            Assert.AreEqual("Test", newEntr.Title);
            Assert.AreNotEqual("TEST", newEntr.Title);
        }
    }
}

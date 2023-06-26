using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Push_PushingStringToTheStack_IncreasesTheCountByOne()
        {
            var list = new Stack<string>();
            list.Push("hello");
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void Push_PushingNullToTheStack_ThrowsArgumentNullException()
        {
            var list = new Stack<string>();
            
            Assert.That(()=> list.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Pop_PopingElementFromEmptyStack_ThrowsInvalidOperationException()
        {
            var list = new Stack<string>();

            Assert.That(() => list.Pop(), Throws.InvalidOperationException);
        }
        [Test]
        public void Pop_PopingElementFromStack_RemovesTheLastElementOfTheStack()
        {
            var list = new Stack<string>();
            list.Push("hello");
            list.Push("world");
            var element = list.Pop();
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_PeekingElementFromStack_ReturnsTheLastElemenFromStack()
        {
            var list = new Stack<string>();
            list.Push("hello");
            list.Push("world");
            var element = list.Peek();
            Assert.That(element, Is.EqualTo("world"));
        }

        [Test]
        public void Peek_PeekingElementFromEmptyStack_ThrowsInvalidOperationException()
        {
            var list = new Stack<string>();

            Assert.That(() => list.Peek(), Throws.InvalidOperationException);
        }
    }
}

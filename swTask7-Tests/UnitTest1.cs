using swTask7;
using static swTask7.cntSolutions;
namespace swTask7_Tests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            Assert.IsTrue(CntSolutions(3.0,3.0,3.0) == 0);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(CntSolutions(3.0, 33, 3.0) == 2);
        }


        [Test]
        public void Test3()
        {
            Assert.IsFalse(CntSolutions(3.0, 3.0, 3.0) == 1);
        }

    }
}
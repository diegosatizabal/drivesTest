using DiskManager.DrivesCalculation;
using NUnit.Framework;

namespace DiskManagerTest.DrivesCalculation
{
    [TestFixture]
    public class DiskSpaceTests
    {
        IDiskSpace diskSpaceMgr;

        int[] used1 = { 300, 500, 150 };
        int[] total1 = { 350, 750, 900 };

        [SetUp]
        public void Setup()
        {
            diskSpaceMgr = new DiskSpace();
        }

        [Test]
        public void shouldGiveErrorOnNullParameter()
        {
            Assert.AreEqual(diskSpaceMgr.minDrives(used1, null), -1);
        }

        [Test]
        public void shouldCalculateProperValues()
        {
            int Result = diskSpaceMgr.minDrives(used1, total1);

            //Total disk space
            Assert.AreEqual(diskSpaceMgr.TotalAvailiableSpace, 2000);

            //Total disk space
            Assert.AreEqual(diskSpaceMgr.TotalUsedSpace, 950);

            //Min drives required
            Assert.AreEqual(Result, 2);
        }

        [TestCase(
            new int[] { 300, 525, 110 },
            new int[] { 350, 600, 115 },
            ExpectedResult = 2)]
        [TestCase(
            new int[] { 1, 200, 200, 199, 200, 200 },
            new int[] { 1000, 200, 200, 200, 200, 200 },
            ExpectedResult = 1)]
        [TestCase(
            new int[] { 750, 800, 850, 900, 950 },
            new int[] { 800, 850, 900, 950, 1000 },
            ExpectedResult = 5)]
        [TestCase(
            new int[] { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 },
            new int[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 },
            ExpectedResult = 49)]
        [TestCase(
            new int[] { 331, 242, 384, 366, 428, 114, 145, 89, 381, 170, 329, 190, 482, 246, 2, 38, 220, 290, 402, 385 },
            new int[] { 992, 509, 997, 946, 976, 873, 771, 565, 693, 714, 755, 878, 897, 789, 969, 727, 765, 521, 961, 906 },
            ExpectedResult = 6)]
        public int shouldGiveTheRightValue(int[] usedArr, int[] spaceArr)
        {
            return diskSpaceMgr.minDrives(usedArr, spaceArr);
        }
    }
}

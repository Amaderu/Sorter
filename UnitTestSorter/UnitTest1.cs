using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestSorter;

namespace UnitTestSorter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SortMethods()
        {
            Sorter.MainWindow mw = new Sorter.MainWindow();
            CollectionAssert.AreEqual(mw.sort_five(new int[5] { 1, 3, 2, 1, 4 }), new int[5] { 1, 1, 2, 3, 4 });
            CollectionAssert.AreEqual(mw.sort_five(new int[5] { 1, 3, 2, 1, 4 }), new int[5] { 1, 1, 2, 3, 4 });
            CollectionAssert.AreEqual(mw.sort_five(new int[5] { 1, 3, 2, 1, 4 }), new int[5] { 1, 1, 2, 3, 4 });
        }
    }
}

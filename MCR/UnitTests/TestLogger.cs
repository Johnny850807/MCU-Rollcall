using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCR.utils;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TestLogger
    {
        [TestMethod]
        public void loggerShouldWorkWellInParallel()
        {
            Log.d("Test", "Test started");
            Log.err("Test", "ERR thrown", new DivideByZeroException());
            
            Parallel.For(0, 100000, (i) =>
            {
                Log.d("Test", "Test-" + i);
                Log.err("Test", "ERR-" + i, new DivideByZeroException());
            });
        }
    }
}

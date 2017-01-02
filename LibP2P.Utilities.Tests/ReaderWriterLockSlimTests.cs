using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibP2P.Utilities.Extensions;
using NUnit.Framework;

namespace LibP2P.Utilities.Tests
{
    [TestFixture]
    public class ReaderWriterLockSlimTests
    {
        [Test]
        public void Read_CanTimeout()
        {
            using (var rwls = new ReaderWriterLockSlim())
            {
                var task = Task.Factory.StartNew(() => rwls.Write(() => Thread.Sleep(100)));

                Assert.Throws<TimeoutException>(() => rwls.Read(() => { }, 50));

                task.Wait();
            }
        }

        [Test]
        public void Write_CanTimeout()
        {
            using (var rwls = new ReaderWriterLockSlim())
            {
                var task = Task.Factory.StartNew(() => rwls.Write(() => Thread.Sleep(100)));

                Assert.Throws<TimeoutException>(() => rwls.Write(() => { }, 10));

                task.Wait();
            }
        }
    }
}

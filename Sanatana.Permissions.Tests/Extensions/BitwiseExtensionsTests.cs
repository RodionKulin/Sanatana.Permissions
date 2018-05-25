using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanatana.Permissions.Entities;
using Sanatana.Permissions.Extensions;
using Sanatana.Permissions.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Extensions.Tests
{
    [TestClass()]
    public class BitwiseExtensionsTests
    {
        [TestMethod()]
        public void IncludeTest()
        {
            long value1 = (long)Permission.Create;
            long value2 = (long)Permission.Update;
            long sum = value1.Include(value2);

            bool valueExists1 = BitwiseExtensions.Has(sum, value1);
            bool valueExists2 = BitwiseExtensions.Has(sum, value2);

            Assert.IsTrue(valueExists1);
            Assert.IsTrue(valueExists2);
        }

        [TestMethod()]
        public void IncludeSameTest()
        {
            long value1 = (long)Permission.Create;
            long value2 = (long)Permission.Update;
            long singleInclude = value1.Include(value2);

            long multipleInclude = value1.Include(value2)
                .Include(value2);

            Assert.AreEqual(singleInclude, multipleInclude);
        }

        [TestMethod()]
        public void IncludeManyTest()
        {
            long value1 = (long)Permission.Create;
            long value2 = (long)Permission.Update;
            long value3 = (long)Permission.Moderate;
            long sum1 = value1.Include(value2);
            long sum2 = value1.Include(value3);
            long totalSum = sum1.Include(sum2);

            Assert.IsTrue(totalSum.Has(value1));
            Assert.IsTrue(totalSum.Has(value2));
            Assert.IsTrue(totalSum.Has(value3));
        }

        [TestMethod()]
        public void RemoveManyTest()
        {
            long value1 = (long)Permission.Create;
            long value2 = (long)Permission.Update;
            long value3 = (long)Permission.Moderate;
            long sum1 = value1.Include(value2);
            long sum2 = value1.Include(value3);
            long totalSum = sum1.Remove(sum2);

            Assert.AreEqual(false, totalSum.Has(value1));
            Assert.AreEqual(true, totalSum.Has(value2));
            Assert.AreEqual(false, totalSum.Has(value3));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntAndArrayExtensions.NUnitTests
{
    [TestFixture]
    public class IAExtensionsTests
    {
        #region NRootFromNumber Tests
        [TestCase(4,2,0,ExpectedResult = 2)]
        [TestCase(9,2,3,ExpectedResult = 3)]
        [TestCase(0,2,2,ExpectedResult =0 )]
        [TestCase(1, 1, 1, ExpectedResult = 1)]
        [TestCase(1234,12,4,ExpectedResult = 1.8097)]
        [TestCase(64728,42,7,ExpectedResult = 1.3018166)]
        [TestCase(421,529,5,ExpectedResult = 1.01149)]
        [TestCase(double.MaxValue,290,10,ExpectedResult = 11.5597194762)]
        [TestCase(1244.124,18,4,ExpectedResult = 1.4857)]
        [TestCase(123.333,30,4,ExpectedResult = 1.1741)]
        [TestCase(double.Epsilon,12,2,ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.PositiveInfinity,123,412,ExpectedResult = double.PositiveInfinity)]
        [TestCase(-2,421,42,ExpectedResult = double.NaN)]
        [TestCase(double.NegativeInfinity,1233,12,ExpectedResult = double.NaN)]
       
        public double NRootFromNumber_PositiveValue_Answer(double number,int n,int eps)
        {
            return IntAndArrayExtentions.IAExtensions.NRootFromNumber(number,n,eps);
        }

        [TestCase(12,41,-2)]
        public void NRootFromNumber_epsLessThenZero_ArgumentException(double number,int rootPower,int eps)
        {

            var ex = Assert.Catch<Exception>(() => IntAndArrayExtentions.IAExtensions.NRootFromNumber(number,rootPower,eps));

            StringAssert.Contains(String.Format("Value of {0} must be greater then 0",nameof(eps)), ex.Message);
        }

        [TestCase(4,-4,1)]
        public void NRootFromNumber_nRootLessThenZero_ArgumentException(double number, int rootPower, int eps)
        {
            var ex = Assert.Catch<Exception>(() => IntAndArrayExtentions.IAExtensions.NRootFromNumber(number, rootPower, eps));

            StringAssert.Contains(String.Format("Value of {0} must be greater then 0", nameof(rootPower)), ex.Message);
        }
#endregion
    }
}

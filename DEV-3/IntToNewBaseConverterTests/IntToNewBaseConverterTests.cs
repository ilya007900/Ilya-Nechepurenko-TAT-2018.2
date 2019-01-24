using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DEV_3;

namespace DEV_3Tests
{
    [TestClass]
    public class IntToNewBaseConverterTests
    {
        [TestMethod]
        public void Convert_8ToBase8_10returned()
        {
            int toBase = 8;
            int number = 8;
            string expected = "10";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_0ToBase2_0returned()
        {
            int toBase = 2;
            int number = 0;
            string expected = "0";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_0ToBase4_0returned()
        {
            int toBase = 4;
            int number = 0;
            string expected = "0";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_0ToBase20_0returned()
        {
            int toBase = 20;
            int number = 0;
            string expected = "0";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_1478ToBase2_10111000110returned()
        {
            int toBase = 2;
            int number = 1478;
            string expected = "10111000110";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_1478ToBase4_113012returned()
        {
            int toBase = 4;
            int number = 1478;
            string expected = "113012";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_1478ToBase20_3DIreturned()
        {
            int toBase = 20;
            int number = 1478;
            string expected = "3DI";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_Minus79274ToBase2_Minus10011010110101010returned()
        {
            int toBase = 2;
            int number = -79274;
            string expected = "-10011010110101010";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_Minus79274ToBase4_Minus103112222returned()
        {
            int toBase = 4;
            int number = -79274;
            string expected = "-103112222";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_Minus79274ToBase20_Minus9I3Ereturned()
        {
            int toBase = 20;
            int number = -79274;
            string expected = "-9I3E";

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBase0_ExceptionThrowed()
        {
            int toBase = 0;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBase1_ExceptionThrowed()
        {
            int toBase = 1;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBase21_ExceptionThrowed()
        {
            int toBase = 21;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBase55_ExceptionThrowed()
        {
            int toBase = 55;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBaseMinus31_ExceptionThrowed()
        {
            int toBase = -31;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBaseMaxInt_ExceptionThrowed()
        {
            int toBase = int.MaxValue;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_8ToBaseMinInt_ExceptionThrowed()
        {
            int toBase = int.MinValue;
            int number = 8;

            IntToNewBaseConverter converter = new IntToNewBaseConverter(number);
            string actual = converter.ConvertToNewSystem(toBase);
        }
    }
}
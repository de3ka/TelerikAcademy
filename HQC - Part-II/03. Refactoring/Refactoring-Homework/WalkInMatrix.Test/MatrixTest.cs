using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalkInMatrix.Models;

namespace WalkInMatrix.Test
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void MatrixConstructorShouldCreateValidMatrix()
        {
            Matrix matrix = new Matrix(3, 3);
            var pos = new Position(2, 2);
            matrix[pos] = 5;

            Assert.AreEqual(5, matrix[pos]);
            Assert.AreEqual(0, matrix[new Position(2, 1)]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MatrixShouldThrowOnInvalidIndexer()
        {
            Matrix matrix = new Matrix(3, 3);
            matrix[new Position(5, 5)] = 4;
        }
    }
}

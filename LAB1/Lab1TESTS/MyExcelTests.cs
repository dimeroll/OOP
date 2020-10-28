using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabCalculator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MyExcel.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void Evaluate_MminMmaxExpression_CorrectResult()
        {   
            //arrange
            string expression = "mmax(1,2,3,4,5,6,7,8,-15,-16,-17,115,-90)+mmin(-1,-9,-8,-7,-14,-9,900,1000000,9000,-8)";
            double expectedResult = 101;

            //act
            double actualResult = Calculator.Evaluate(expression);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void Evaluate_EqualNotEqualExpression_CorrectResult()
        {
            //arrange
            string expression = "((5=5)+(1000000=-1000000))<>((5<>6)+(10<>11)-(15<>15))";
            double expectedResult = 0;

            //act
            double actualResult = Calculator.Evaluate(expression);

            //assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void Evaluate_GreaterGreaterEqualLessLessEqualExpression_CorrectResult()
        {
            //arrange
            string expression = "(500>=500)+(100>100)+(200<200)+(300<=300)";
            double expectedResult = 2;

            //act
            double actualResult = Calculator.Evaluate(expression);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void SetTable_QuantityOfColumnsAndRows_CorrectResult()
        {
            //arrange
            Table Tab = new Table();
            int expectedResult = 100;

            //act
            Tab.SetTable(101, 201);
            int actualResult = Tab.ColCount - Tab.RowCount;

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void AddToFromCells_AddingOfNewCells_CorrectResult()
        {
            //arrange
            Cell cellA = new Cell("A2", 2, 0);
            Cell cellC = new Cell("C3", 3, 2);
            Cell cellD = new Cell("D5", 5, 3);
            List<Cell> nft = new List<Cell>() { cellC, cellD };
            cellA.new_FromThis = nft;
            string expectedResult = "C3 D5 A2 A2";

            //act
            cellA.AddToFromCells();
            string ares = "";
            foreach (Cell cell in cellA.FromThis) 
                ares += cell.Index + " ";
            string actualResult = ares + cellC.ToThis[0].Index + " " + cellD.ToThis[0].Index;

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

}
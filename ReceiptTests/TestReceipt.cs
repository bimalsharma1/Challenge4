using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReceiptTests
{
    [TestClass]
    public class TestReceipt
    {
        [TestMethod]
        public void TestReceiptValues()
        {
            var receipt = new Receipt.Classes.Receipts();
            receipt.AddItem(1, "Newspaper", 1.50m);
            receipt.AddItem(1, "Milk", 3m);
            receipt.AddItem(2, "Bread", 2.50m);
            var expected = @"1 Newspaper @ $1.50 = $1.50
1 Milk @ $3.00 = $3.00
2 Bread @ $2.50 = $5.00
Sub Total = $9.50
Tax (10%) = $0.95
Total = $10.45";
            Assert.AreEqual(expected, receipt.ToString());
        }
    }
}

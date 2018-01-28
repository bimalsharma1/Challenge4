using System;
using System.Collections.Generic;
using Receipt.Models;
using Receipt.Classes;
using System.Globalization;

namespace Receipt.Classes
{
    public class Receipts
    {
        public List<ReceiptModel> receipts = new List<ReceiptModel>();
        string currencyFormat = "C2";

        public Receipts()
        {

        }

        public override string ToString()
        {
            return PrintReceipt();
        }

        public void AddItem(int quantity, string description, decimal price)
        {
            ReceiptModel receipt = new ReceiptModel
            {
                quantity = quantity,
                description = description,
                price = Math.Round(price, 2)
            };
            receipts.Add(receipt);
        }

        private string PrintReceipt()
        {
            var receipt = "";
            decimal subTotal = 0;

            foreach (var r in receipts)
            {
                var productTotal = GetTotalOfProduct(r.price, r.quantity);
                subTotal = decimal.Add(subTotal, productTotal);
                receipt += AddReceiptLine(r, productTotal);
            }

            var tax = Math.Round(subTotal * 10 / 100, 2);
            var total = Math.Round(subTotal + tax, 2);
            receipt += AddSubTotalLine(subTotal);
            receipt += AddTaxLine(subTotal, tax);
            receipt += AddTotalLine(total);

            return receipt;
        }

        private decimal GetTotalOfProduct(decimal price, int quantity)
        {
            return Math.Round(decimal.Multiply(price, (decimal)quantity), 2);
        }

        private string AddReceiptLine(ReceiptModel r, decimal productTotal)
        {
            return r.quantity.ToString() + " "
                + r.description + " @ " + r.price.ToString(currencyFormat, CultureInfo.CurrentCulture) + " = "
                + productTotal.ToString(currencyFormat, CultureInfo.CurrentCulture) + System.Environment.NewLine;
        }

        private string AddSubTotalLine(decimal subTotal)
        {
            return "Sub Total = " + subTotal.ToString(currencyFormat, CultureInfo.CurrentCulture) + System.Environment.NewLine;
        }

        private string AddTaxLine(decimal subTotal, decimal tax)
        {
            
            return "Tax (10%) = " + tax.ToString(currencyFormat, CultureInfo.CurrentCulture) + System.Environment.NewLine;
        }

        private string AddTotalLine(decimal total)
        {
            return "Total = " + total.ToString(currencyFormat, CultureInfo.CurrentCulture);
        }
    }
}

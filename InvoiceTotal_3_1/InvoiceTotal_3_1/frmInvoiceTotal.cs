using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal_3_1
{
    /*
     Drew Watson
     Lab assignment 1 
     3.1X
     Friedman
     Component Spring 2018
     */


    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Variables
            decimal discountPercent, discountAmount, invoiceTotal;

            //Calculates total for invoice, I tried letting VS refactor my code here for fun
            calculateTotal(out discountPercent, out discountAmount, out invoiceTotal);

            //Converts and places totals to txtboxes
            txtDiscountPercent.Text = discountPercent.ToString("p1");
            txtDicountAmount.Text = discountAmount.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            //Changes focus to txtSubtotal
            txtSubtotal.Focus();
        }

        private void calculateTotal(out decimal discountPercent, out decimal discountAmount, out decimal invoiceTotal)
        {
            //Variables declared
            decimal subtotal = 0;
            discountPercent = 0m;
            discountAmount = 0;
            invoiceTotal = 0;

            //Converts txtSubtotal.Text to a decimal
            subtotal = Convert.ToDecimal(txtSubtotal.Text);

            /*
             * Calculates the discount for the invoice
               Subtotal is equal to or greater than 500 then you get a 20% discount
               Subtotal is between 250 and 499 then you get a 15% discount
               Subtotal is between 100 and 249 then you get a 10% discount
               Subtotal is equal to or greater than 500 then you get no discount
            */
            if (subtotal >= 500)
            {
                discountPercent = .2m;
            }

            else if (subtotal >= 250 && subtotal < 500)
            {
                discountPercent = .15m;
            }

            else if (subtotal >= 100 && subtotal < 250)
            {
                discountPercent = .1m;
            }

            //Calculates the discount amount
            discountAmount = subtotal * discountPercent;

            //Calculates the total for the invoice
            invoiceTotal = subtotal - discountAmount;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

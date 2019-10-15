using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Media;
/// <summary>
/// Created by Ryan
/// October 4th 2019
/// Cash register summative
/// </summary>
namespace CashRegisterSummative
{
    public partial class Form1 : Form
    {
        //defining variables
        double drinkPrice = 2.50;
        double friesPrice = 4.0;
        double ticketsPrice = 10.0;
        double tax = 0.13;
        double  drinkTotal, friesTotal, ticketsTotal;
        double total, totalTax, drinkNumber, friesNumber, ticketsNumber;
        double change;
        double tendered;
        double price;

        private void Button2_Click(object sender, EventArgs e)
        {
            //print receipt
        
            //round prices
            total = Math.Round(total, 2);
            totalTax = Math.Round(totalTax, 2);
            price = Math.Round(price, 2);
            change = Math.Round(change, 2);

            //graphics options
            Graphics g = this.CreateGraphics();
            Font titleFont = new Font("Times New Roman", 12);
            SolidBrush titleBrush = new SolidBrush(Color.Black);

            //audio
            SoundPlayer receipt = new SoundPlayer(Properties.Resources.receipt);

            //print the receipt
            
            g.DrawString("Stratford Warriors", titleFont, titleBrush, 320, 45);
            Thread.Sleep(500);
            receipt.Play();
            g.DrawString("Order number " + price*1000, titleFont, titleBrush, 300, 75);
            Thread.Sleep(500);
            g.DrawString("October 15th 2019" , titleFont, titleBrush, 300, 95);
            Thread.Sleep(500);
            g.DrawString("Fries              " + friesNumber + " @ $" + friesPrice, titleFont, titleBrush, 300, 125);
            Thread.Sleep(500);
            g.DrawString("Drinks            " + drinkNumber + " @ $" + drinkPrice, titleFont, titleBrush, 300, 145);
            Thread.Sleep(500);
            g.DrawString("Tickets           " + ticketsNumber + " @ $" + ticketsPrice, titleFont, titleBrush, 300, 165);
            Thread.Sleep(500);
            g.DrawString("Subtotal         $ " + total, titleFont, titleBrush, 300, 195);
            Thread.Sleep(500);
            g.DrawString("Tax               $ " + totalTax, titleFont, titleBrush, 300, 215);
            Thread.Sleep(500);
            g.DrawString("Total             $ " + price, titleFont, titleBrush, 300, 235);
            Thread.Sleep(500);
            g.DrawString("Tendered             $ " + tendered, titleFont, titleBrush, 300, 265);
            Thread.Sleep(500);
            g.DrawString("Change             $ " + change, titleFont, titleBrush, 300, 285);
            Thread.Sleep(500);
            g.DrawString("Have a nice day!", titleFont, titleBrush, 315, 315);
        }

        
        
        //calculate change
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //change to int
                tendered = Convert.ToInt16(tenderedInput.Text);
                change = tendered - price;
                changeLabel.Text = change.ToString("C");

                //if not enough money is paid
                if (tendered < price)
                {
                    changeLabel.Text = "Please enter a valid amount";
                }
            }
            catch
            {
                changeLabel.Text = "Please enter a valid amount";
            }
        }

        

       


        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //record the number of each item, change to int
                drinkNumber = Convert.ToInt16(drinksInput.Text);
                friesNumber = Convert.ToInt16(friesInput.Text);
                ticketsNumber = Convert.ToInt16(ticketsInput.Text);

                //calculate prices 
                drinkTotal = drinkNumber * drinkPrice;
                friesTotal = friesNumber * friesPrice;
                ticketsTotal = ticketsNumber * ticketsPrice;

                //calculate tax and totals
                total = ticketsTotal + friesTotal + drinkTotal;
                totalTax = total * tax;
                price = totalTax + total;

                //print numbers and prices
                subtotalLabel.Text = total.ToString("C");
                taxesLabel.Text = totalTax.ToString("C");
                totalpriceLabel.Text =  price.ToString("C");
            }
            catch
            {
                subtotalLabel.Text = "Enter items please";
            }
          
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
          
        }
    }
}

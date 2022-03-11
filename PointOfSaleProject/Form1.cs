using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSaleProject
{
    public partial class Form1 : Form
    {
        public double SavedPrice = 0.0;
        public double SavedPay = 0.0;
        public bool cartlocked = false;

        public Form1()
        {
            InitializeComponent();
        }

        void FoodSelected(String foodandprice, double price)
        {
            double salefin = price + Convert.ToDouble(SaleTextBox.Text); 

            SaleTextBox.Text = salefin.ToString();
            cartList.Items.Add(foodandprice);
            button12.Enabled = true;
        }

        void AllFoodButtons(Boolean set)
        {
            button1.Enabled = set;
            button2.Enabled = set;
            button3.Enabled = set;
            button4.Enabled = set;
            button5.Enabled = set;
            button6.Enabled = set;
            button7.Enabled = set;
            button8.Enabled = set;
            button9.Enabled = set;
            button10.Enabled = set;
        }

        private void cartList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cartlocked)
            {
                if (cartList.SelectedItems.Count != 0)
                {
                    while (cartList.SelectedIndex != -1)
                    {
                        //Console.WriteLine(cartList.GetItemText(cartList.SelectedItem));
                        switch (cartList.GetItemText(cartList.SelectedItem))
                        {
                            case "Chicken - P80":
                                double salefin = Convert.ToDouble(SaleTextBox.Text) - 80.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "2 Pieces Chicken - P150":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 150.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Burger - P40":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 40.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "French Fries - P20":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 20.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Pizza - P70":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 70.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Hotdog - P15":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 15.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Baked Potato - P65":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 65.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Mom's Spaghetti - P55":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 55.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Ribs - P155":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 155.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                            case "Coke - P20":
                                salefin = Convert.ToDouble(SaleTextBox.Text) - 20.0;
                                SaleTextBox.Text = salefin.ToString();
                                break;
                        }
                        cartList.Items.RemoveAt(cartList.SelectedIndex);
                        if (cartList.Items.Count == 0)
                        {
                            button12.Enabled = false;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FoodSelected("Chicken - P80", 80.0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FoodSelected("2 Pieces Chicken - P150", 150.0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FoodSelected("Burger - P40", 40.0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FoodSelected("French Fries - P20", 20.0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FoodSelected("Pizza - P70", 70.0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FoodSelected("Hotdog - P15", 15.0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FoodSelected("Baked Potato - P65", 65.0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FoodSelected("Mom's Spaghetti - P55", 55.0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FoodSelected("Ribs - P155", 155.0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FoodSelected("Coke - P20", 20.0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SavedPrice = Convert.ToDouble(SaleTextBox.Text);

            SaleTextBox.Text = "0.00";
            label3.Text = "Enter Payment: (P" + SavedPrice.ToString() + ")";
            SaleTextBox.ReadOnly = false;
            button12.Enabled = false;
            button13.Enabled = true;
            button11.Text = "Reset";
            button11.Enabled = true;
            AllFoodButtons(false);
            cartlocked = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SavedPay = Convert.ToDouble(SaleTextBox.Text);

            if (SavedPay < SavedPrice)
            {
                MessageBox.Show("The Payment is lower than the price!", "Lower than Price!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                button13.Enabled = false;
                button11.Enabled = true;
                label3.Text = "Change: (Total Price: P" + SavedPrice.ToString() + ", Paid: P" + SavedPay.ToString() + ")";
                SaleTextBox.ReadOnly = true;
                SaleTextBox.Text = (SavedPay - SavedPrice).ToString();
                button11.Text = "Next Customer";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label3.Text = "Sale:";
            SaleTextBox.ReadOnly = true;
            SaleTextBox.Text = "0.00";
            button11.Text = "Next Customer";
            button11.Enabled = false;
            button12.Enabled = true;
            button13.Enabled = false;
            AllFoodButtons(true);
            cartlocked = false;
            cartList.Items.Clear();
        }
    }
}

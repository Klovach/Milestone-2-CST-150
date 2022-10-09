using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_Prototype
{
    public partial class Form1 : Form
    {
        // List to hold Product objects.
        List<Product> productsList = new List<Product>();
        public Form1()
        {
            InitializeComponent();

            // All Products.
            Product White_Bread = new Product();
            White_Bread.name = "White Bread";
            White_Bread.quantity = 50;
            White_Bread.price_per_unit = 3.99m;

            Product Wheat_Bread = new Product();
            Wheat_Bread.name = "Wheat Bread";
            Wheat_Bread.quantity = 48;
            Wheat_Bread.price_per_unit = 3.99m;

            Product Rye_Bread = new Product();
            Rye_Bread.name = "Rye Bread";
            Rye_Bread.quantity = 6;
            Rye_Bread.price_per_unit = 5.99m;

            Product Sourdough_Bread = new Product();
            Sourdough_Bread.name = "Sourdough Bread";
            Sourdough_Bread.quantity = 28;
            Sourdough_Bread.price_per_unit = 6.99m;

            Product Multigrain_Bread = new Product();
            Multigrain_Bread.name = "Multigrain Bread";
            Multigrain_Bread.quantity = 20;
            Multigrain_Bread.price_per_unit = 4.99m;
           
            Product Pita_Bread = new Product();
            Pita_Bread.name = "Pita Bread";
            Pita_Bread.quantity = 16;
            Pita_Bread.price_per_unit = 6.99m;
           

            Product Brioche = new Product();
            Brioche.name = "Brioche";
            Brioche.quantity = 14;
            Brioche.price_per_unit = 5.99m;
           

            Product Bagels = new Product();
            Bagels.name = "Bagels";
            Bagels.quantity = 50;
            Bagels.price_per_unit = 3.99m;
            
            Product Focaccia = new Product();
            Focaccia.name = "Focaccia";
            Focaccia.quantity = 8;
            Focaccia.price_per_unit = 5.99m;
          
            Product Ciabatta = new Product();
            Ciabatta.name = "Ciabatta";
            Ciabatta.quantity = 8;
            Ciabatta.price_per_unit = 5.99m;


            // Add Items to Products
            lstProducts.Items.Add(White_Bread);
            lstProducts.Items.Add(Wheat_Bread);
            lstProducts.Items.Add(Rye_Bread);
            lstProducts.Items.Add(Sourdough_Bread);
            lstProducts.Items.Add(Multigrain_Bread);
            lstProducts.Items.Add(Pita_Bread);
            lstProducts.Items.Add(Brioche);
            lstProducts.Items.Add(Bagels);
            lstProducts.Items.Add(Focaccia);
            lstProducts.Items.Add(Ciabatta); 
        }


        /* This will display the product's data in the textboxes when they have been 
         selected by the user. If there is no data in the selected row or the row has
        been deleted by the user an exception is thrown. */
        private void lstProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Product products = (Product)lstProducts.SelectedItem;
            if (products != null && products.name != null) 
            {
                txtProductName.Text = products.name;
                txtQuantityPerUnit.Text = products.quantity.ToString();
                txtPricePerUnit.Text = products.price_per_unit.ToString();
            }
            else if (products != null && products.name != null)
            {
                throw new DeletedRowInaccessibleException();
            }
        }

        /* The GetProductData method accepts a product object entered by the user     
        * as an argument. The data entered by the user via the following textboxes is 
        * distributed to the object's properties. */
        private void GetProductData(Product products)         {
            decimal price;
            int quantity; 

            // Get the product name.
            products.name = txtNewName.Text;

            // Get Product Quantity 
            if (int.TryParse(txtNewQuantity.Text, out quantity))
            {
                products.quantity = quantity;
            }
            else
            { 
                MessageBox.Show("Invalid quantity.");
            }


            // Get Product Price 
            if (decimal.TryParse(txtNewPrice.Text, out price))
            {
                products.price_per_unit = price;
            }
            else
            {
                MessageBox.Show("Invalid price");            
            }        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create a Product object.
            Product products = new Product();
            // Get the product data.
            GetProductData(products);           
            // Add the Product object to the list.             
            productsList.Add(products);
            // Add an entry to the list box.
            lstProducts.Items.Add(products);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            // Close the form.
            Application.Exit(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNewName.Clear();
            txtNewQuantity.Clear();
            txtNewPrice.Clear();
            txtNewName.Focus();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product products = (Product)lstProducts.SelectedItem;
            // Remove from the List.             
            productsList.Remove(products);
            // Remove an entry from the list box.
            lstProducts.Items.Remove(products);
            // Notify the user that an item has been removed. 
            MessageBox.Show("An item been removed from the database.");
        }
    }
    }



  
using ProductCatalog.Controller;
using ProductCatalog.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductCatalog.View
{
    public partial class FrmPencarian : Form
    {
        public FrmPencarian()
        {
            InitializeComponent();
            
            InisialisasiListView();
            cmbFilter.SelectedIndex = 0;
        }

        private void InisialisasiListView()
        {
            lvwProduct.View = System.Windows.Forms.View.Details;
            lvwProduct.FullRowSelect = true;
            lvwProduct.GridLines = true;

            lvwProduct.Columns.Add("No.", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Product Id", 120, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Product Name", 750, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Stock", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Price", 70, HorizontalAlignment.Right);
            lvwProduct.Columns.Add("Category", 300, HorizontalAlignment.Left);
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            List<Product> list = new List<Product>();
            ProductController productController = new ProductController();
            switch (this.cmbFilter.SelectedIndex)
            {
                case 0:
                    list = productController.ReadAll();
                    break;
                case 1:
                    {
                        Product product = productController.ReadByProductId(this.txtKeyword.Text);
                        bool flag = product != null;
                        if (flag)
                        {
                            list.Add(product);
                        }
                        break;
                    }
                case 2:
                    list = productController.ReadByProductName(this.txtKeyword.Text);
                    break;
                default:
                    list = productController.ReadByCategory(this.txtKeyword.Text);
                    break;
            }
            this.lvwProduct.Items.Clear();
            bool flag2 = list == null;
            if (flag2)
            {
                MessageBox.Show("Pencarian data product tidak ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                foreach (Product product2 in list)
                {
                    ListViewItem listViewItem = new ListViewItem((this.lvwProduct.Items.Count + 1).ToString());
                    listViewItem.SubItems.Add(product2.product_id);
                    listViewItem.SubItems.Add(product2.product_name);
                    listViewItem.SubItems.Add(product2.stock.ToString());
                    listViewItem.SubItems.Add(product2.price.ToString());
                    listViewItem.SubItems.Add(product2.category);
                    this.lvwProduct.Items.Add(listViewItem);
                }
            }
        }

        private void FrmPencarian_Load(object sender, EventArgs e)
        {

        }
    }
}

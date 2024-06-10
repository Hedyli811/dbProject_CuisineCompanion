using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeTeachingAssignmentMDI
{
    public partial class frmBrowseInventory : Form
    {
        public frmBrowseInventory()
        {
            InitializeComponent();
        }

        private void frmBrowseInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }
        private void LoadInventory()
        {

            string sql = "SELECT DishID,DishName FROM CookedDish\r\n";
            DataTable dt = DataAccess.GetData(sql);

            dt.AddEmptyRow("DishName", "DishID");

            cmbInventory.Bind("DishName", "DishID", dt);

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT FoodName,Price,PurchaseDate FROM Inventory I INNER JOIN Inventory_CookedDish IC ON I.InventoryID = IC.InventoryID\r\n";
                if (cmbInventory.SelectedIndex > 0)
                {
                    sql += $" WHERE IC.DishID = {cmbInventory.SelectedValue}";
                }
                else
                {
                    MessageBox.Show("Pls select a dish");
                }

                DataTable dt = DataAccess.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    dgvInventory.ReadOnly = true;
                    dgvInventory.DataSource = dt;
                    dgvInventory.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("there no recored ");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }
    }
}

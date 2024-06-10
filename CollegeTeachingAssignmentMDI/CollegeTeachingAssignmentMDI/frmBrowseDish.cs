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
    public partial class frmBrowseDish : Form
    {
        public frmBrowseDish()
        {
            InitializeComponent();
        }

        private void frmBrowseDish_Load(object sender, EventArgs e)
        {
            LoadDish();
        }

        private void LoadDish()
        {

            string sql = "SELECT InventoryID,FoodName FROM Inventory";
            DataTable dt = DataAccess.GetData(sql);

            dt.AddEmptyRow("FoodName", "InventoryID"); 

            cmbDish.Bind("FoodName", "InventoryID", dt);

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT  DishName,Comment,DateOfMade,Rating FROM CookedDish C INNER JOIN Inventory_CookedDish IC ON C.DishID = IC.DishID ";
                if (cmbDish.SelectedIndex > 0)
                {
                    sql += $" WHERE IC.InventoryID = {cmbDish.SelectedValue}";
                }
                else
                {
                    MessageBox.Show("Pls select a dish");
                }

                DataTable dt = DataAccess.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    dgvDish.ReadOnly = true;
                    dgvDish.DataSource = dt;
                    dgvDish.AutoResizeColumns();
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

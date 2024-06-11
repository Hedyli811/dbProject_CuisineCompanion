using CollegeTeachingAssignmentMDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuisineCompanionMDI
{
    public partial class frmManytoMany : Form
    {
        #region private fields
        int currentInventoryID;
        int currentDishID;
        int currentQty;


        int firstCourseId;
        int firstInstructorId;
        int firstTerm;

        int lastCourseId;
        int lastInstructorId;
        int lastTerm;

        int? previousCourseId;
        int? previousInstructorId;
        int? previousTerm;

        int? nextCourseId;
        int? nextInstructorId;
        int? nextTerm;

        private FormState currentState;


        #endregion
        public frmManytoMany()
        {
            InitializeComponent();
        }

        #region event handler



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //update to make sure we have the latest

                LoadDish();
                LoadInventory();

                SetState(FormState.Add);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure you want to delete this", "are you sure", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteAssignment();
                    LoadFirstIngredient();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());

            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentState == FormState.View)
                {
                    SetState(FormState.Edit);
                }
                else
                {
                    if (this.ValidateChildren())
                    {
                        if (currentState == FormState.Add)
                        {
                            CreateIngredient();
                            LoadFirstIngredient();
                        }
                        else
                        {
                            UpdateIngredient();
                        }

                    }
                    else
                    {
                        MessageBox.Show("pls resolve your validation errors");
                    }
                    SetState(FormState.View);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SetState(FormState.View);
                DisplayCurrentAssignment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
 
        #endregion

        #region form state

        private void SetState(FormState state)
        {
            currentState = state;
            LoadState(state);

        }

        private void LoadState(FormState state)
        {
            if (state == FormState.View)
            {
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Text = "Edit";
                AllowInputs(false);
                errorProvider.Clear();

            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                AllowInputs(true);
                if (state == FormState.Add)
                {
                    grpIngredient.ClearChildControls(defaultSelectedIndex: -1);
                    //UIUtilities.ClearChildControls(grpAssignments);
                }

            }

            EnableNavigation(currentState == FormState.View);

        }

        private void AllowInputs(bool allowInput)
        {
            txtQty.ReadOnly = !allowInput;
            cmbInventory.Enabled = allowInput;
            cmbDish.Enabled = allowInput;
        }

        #endregion

        #region load data
        /// <summary>
        /// Retrieves the instructors and populates the combobox
        /// Filter list to not include instructors on sabbatical - satisfies our first business rule
        /// </summary>
        private void LoadInventory()
        {
            string sqlInstructors = "SELECT InventoryID,FoodName FROM Inventory";
            UIUtilities.Bind(cmbInventory, "FoodName", "InventoryID", DataAccess.GetData(sqlInstructors));
        }

        private void LoadDish()
        {
            string sqlCourses = "SELECT DishID,DishName FROM CookedDish ORDER BY DishID";
            UIUtilities.Bind(cmbDish, "DishName", "DishID", DataAccess.GetData(sqlCourses));

  
        }

        private void LoadFirstIngredient()
        {
            DataTable firstAssignment = DataAccess.GetData("SELECT TOP 1 InventoryID,DishID,QuantityRequired FROM Inventory_CookedDish");

            if (firstAssignment.Rows.Count > 0)
            {
                DataRow firstRow = firstAssignment.Rows[0];

                currentInventoryID = Convert.ToInt32(firstRow["InventoryID"]);
                currentDishID = Convert.ToInt32(firstRow["DishID"]);
                currentQty = Convert.ToInt32(firstRow["QuantityRequired"]);

                LoadCurrentPosition();
                DisplayCurrentAssignment();
            }
        }

        private void LoadCurrentPosition()
        {
            DataTable dt = GetAssignmentPositionDataTable();
            LoadCurrentPosition(dt.Rows[0]);
            EnableNavigation(true);
        }

        private void LoadCurrentPosition(DataRow dataRow)
        {
            firstCourseId = Convert.ToInt32(dataRow["FirstCourseId"]);
            firstInstructorId = Convert.ToInt32(dataRow["FirstInstructorID"]);
            firstTerm = Convert.ToInt32(dataRow["FirstTerm"]);

            previousInstructorId = DataUtil.GetInteger(dataRow, "PrevInstructorID");
            previousCourseId = dataRow.GetInteger("PrevCourseID");
            previousTerm = dataRow.GetInteger("PrevTerm");

            nextCourseId = dataRow.GetInteger("NextCourseID");
            nextInstructorId = dataRow.GetInteger("NextInstructorID");
            nextTerm = dataRow.GetInteger("NextTerm");

            lastCourseId = Convert.ToInt32(dataRow["LastCourseID"]);
            lastInstructorId = Convert.ToInt32(dataRow["LastInstructorID"]);
            lastTerm = Convert.ToInt32(dataRow["LastTerm"]);

        }

        private void DisplayCurrentAssignment()
        {
            DataTable dtAssignment = GetAssignmentDataTable();
            if (dtAssignment.Rows.Count == 1)
            {
                DisplayCurrentAssignment(dtAssignment.Rows[0]);
            }
        }

        private void DisplayCurrentAssignment(DataRow dataRow)
        {
            int qty = Convert.ToInt32(dataRow["QuantityRequired"]);
            int inventoryID = Convert.ToInt32(dataRow["InventoryID"]);

            cmbDish.SelectedValue = dataRow["DishID"];
            cmbInventory.SelectedValue = inventoryID;

            txtQty.Text = qty.ToString();

            this.DisplayParentStatusStripMessage("ingredients loaded");
            //UIUtilities.DisplayParentStatusStripMessage(this, "assignmentd loaded" );

        }



        #endregion


        #region retrieve data

        private DataTable GetAssignmentPositionDataTable()
        {
            string sql = $@"
           		  SELECT 
	            q.NextCourseID,
	            q.NextInstructorID,
	            q.NextTerm,
	            q.PrevCourseID,
	            q.PrevInstructorID,
	            q.PrevTerm,
	            q.RowNumber,

            (SELECT TOP(1) InventoryID  FROM Inventory_CookedDish ORDER BY InventoryID ASC)AS FirstCourseID,
            (SELECT TOP(1) DishID  FROM Inventory_CookedDish ORDER BY InventoryID ASC)AS FirstInstructorID,
            (SELECT TOP(1) QuantityRequired  FROM Inventory_CookedDish ORDER BY InventoryID ASC)AS FirstTerm,
            (SELECT TOP(1) InventoryID  FROM Inventory_CookedDish ORDER BY InventoryID DESC)AS LastCourseID,
            (SELECT TOP(1) DishID  FROM Inventory_CookedDish ORDER BY InventoryID DESC)AS LastInstructorID,
            (SELECT TOP(1) QuantityRequired  FROM Inventory_CookedDish ORDER BY InventoryID DESC)AS LastTerm
			FROM
			(
			SELECT InventoryID,DishID,QuantityRequired ,
            LEAD(InventoryID) OVER(ORDER BY InventoryID) AS NextCourseID,
            LEAD(DishID) OVER(ORDER BY InventoryID) AS NextInstructorID,
            LEAD(QuantityRequired) OVER(ORDER BY InventoryID) AS NextTerm,
            LAG(InventoryID) OVER(ORDER BY InventoryID) AS PrevCourseID,
            LAG(DishID) OVER(ORDER BY InventoryID) AS PrevInstructorID,
            LAG(QuantityRequired) OVER(ORDER BY InventoryID) AS PrevTerm,
            ROW_NUMBER() OVER(ORDER BY InventoryID) AS RowNumber 
			FROM Inventory_CookedDish ) AS q
			WHERE q.InventoryID = {currentInventoryID} AND q.DishID = {currentDishID} AND q.QuantityRequired = {currentQty}

            ";

            DataTable dt = DataAccess.GetData(sql);
            return dt;
        }

        private DataTable GetAssignmentDataTable()
        {
            string sql = $"SELECT * FROM Inventory_CookedDish WHERE DishID = {currentDishID} AND InventoryID = {currentInventoryID} AND QuantityRequired = {currentQty}";
            return DataAccess.GetData(sql);
        }

        #endregion

        #region send data

        private void CreateIngredient()
        {
            int dishID = Convert.ToInt32(cmbDish.SelectedValue);
            int inventoryID = Convert.ToInt32(cmbInventory.SelectedValue);
            int consumeQty = Convert.ToInt32(txtQty.Text);

            if (GetLeftQty(inventoryID, dishID, consumeQty) > 0)
            {

                int qty = Convert.ToInt32(txtQty.Text);

                string sql = $@"
            INSERT INTO Inventory_CookedDish(DishID,InventoryID,QuantityRequired)
            VALUES
            ({dishID},{inventoryID},'{qty}')
            ";

                int rowsAffected = DataAccess.SendData(sql);
                if (rowsAffected == 1)
                {
                    MessageBox.Show("created");
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            else
            {
                MessageBox.Show($"you don't have enough stock.left quantity of {cmbInventory.GetItemText(cmbInventory.SelectedItem)} is {GetLeftQty(currentInventoryID, currentDishID, 0)} ");

            }
        }

        private void DeleteAssignment()
        {
            string sql = $@"DELETE FROM Inventory_CookedDish 
                        WHERE InventoryID = {currentInventoryID} AND DishID = {currentDishID}  AND QuantityRequired = {currentQty}";

            int rowsAffected = DataAccess.SendData(sql);
            if (rowsAffected == 1)
            {
                MessageBox.Show("deleted");
            }
            else
            {
                MessageBox.Show("failed");
            }

        }

        private void UpdateIngredient()
        {
            string sql = $@"
  
            UPDATE Inventory_CookedDish
            SET InventoryID = '{cmbInventory.SelectedValue}',
            DishID = '{cmbDish.SelectedValue}',
            QuantityRequired = '{txtQty.Text}'
            WHERE InventoryID =  {currentInventoryID} AND DishID = {currentDishID} 
                        ";

            int consumeQty = Convert.ToInt32(txtQty.Text);

            int leftQty = GetLeftQty(currentInventoryID, currentDishID, consumeQty);

            if (leftQty >= 0)
            {
                int rowsAffected = DataAccess.SendData(sql);
                if (rowsAffected == 0)
                {
                    MessageBox.Show("the database reported no rows effected");
                }
                else if (rowsAffected == 1)
                {
                    MessageBox.Show("updated");
                }
                else
                {
                    MessageBox.Show("something went wrong pls verify your data ");
                }


            }
            else
            {
                MessageBox.Show($"not enough ingredient. left quantity of {cmbInventory.GetItemText(cmbInventory.SelectedItem)} is {GetLeftQty(currentInventoryID, currentDishID, 0)}");

            }


        }

        private int GetLeftQty(int inventoryID, int dishID,int consumeQty)
        {
            string sqlInventoryQuantity = "SELECT Quantity FROM Inventory WHERE InventoryID = 1";
            string sqlTotalQuantity = "SELECT SUM(QuantityRequired) AS TotalQuantity FROM Inventory_CookedDish WHERE InventoryID =1 ";

            DataTable dtInventory = DataAccess.GetData(sqlInventoryQuantity);
            DataTable dtQuantity = DataAccess.GetData(sqlTotalQuantity); 

            int inventoryQuantity = Convert.ToInt32(dtInventory.Rows[0][0]);
            int totalQty = Convert.ToInt32(dtQuantity.Rows[0][0]);

            return inventoryQuantity - totalQty - consumeQty;

        }

        #endregion


        #region navigation 

        private void Navagation_Handler(object sender, EventArgs e)
        {
            if (sender == btnFirst)
            {
                currentInventoryID = firstCourseId;
                currentDishID = firstInstructorId;
                currentQty = firstTerm;

            }
            else if (sender == btnNext)
            {
                currentInventoryID = nextCourseId.Value;
                currentDishID = nextInstructorId.Value;
                currentQty = nextTerm.Value;
            }
            else if (sender == btnPrevious)
            {
                currentInventoryID = previousCourseId.Value;
                currentDishID = previousInstructorId.Value;
                currentQty = previousTerm.Value;

            }
            else if (sender == btnLast)
            {
                currentInventoryID = lastCourseId;
                currentDishID = lastInstructorId;
                currentQty = lastTerm;

            }
            else
            {
                return;
            }

            LoadCurrentPosition();
            DisplayCurrentAssignment();

        }

        private void EnableNavigation(bool enable)
        {
            if (enable)
            {
                btnPrevious.Enabled = previousInstructorId != null
                    && previousTerm != null
                    && previousCourseId != null;

                btnNext.Enabled = nextInstructorId != null
                    && nextCourseId != null
                    && nextTerm != null;
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }

            btnFirst.Enabled = enable;
            btnLast.Enabled = enable;
        }

        #endregion

        #region validation 

        private void txtTerm_Validating(object sender, CancelEventArgs e)
        {
            TextBox? txt = sender as TextBox;
            if (txt == null)
                return;

            string? errorMsg = string.Empty;

            if (txt.Text == string.Empty)
            {
                errorMsg = $"{txt.Tag} is required ";
                e.Cancel = true;
            }
            if (txt == txtQty)
            {
                if (!Validator.IsNumeric(txt.Text))
                {
                    errorMsg = $"{txt.Tag} is not numeric ";
                    e.Cancel = true;

                }
            }

            errorProvider.SetError(txt, errorMsg);
        }
        private void cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox? cmb = sender as ComboBox;
            if (cmb == null) return;

            string errorMsg = string.Empty;

            if (cmb.SelectedIndex == -1)
            {
                errorMsg = $"{cmb.Tag} is required ";
            }

            this.errorProvider.SetError(cmb, errorMsg);
        }

        #endregion



        private void frmManytoMany_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInventory();
                LoadDish();
                LoadFirstIngredient();
                SetState(FormState.View);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}

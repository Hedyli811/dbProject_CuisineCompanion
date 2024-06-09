using System.Data;
using System.Diagnostics;

namespace CollegeTeachingAssignmentMDI
{
    public partial class frmInventory : Form
    {
        private int currentId;
        private int firstId;
        private int lastId;
        private int? nextId;
        private int? previousId;
        private int rowNumber;


        private FormState currentState;


        public frmInventory()
        {
            InitializeComponent();
        }

        #region event handler

        private void Navigation_Handler(object sender, EventArgs e)
        {
            if (sender == btnFirst)
            {
                currentId = firstId;
            }
            else if (sender == btnLast)
            {
                currentId = lastId;
            }
            else if (sender == btnNext)
            {
                if (nextId != null)
                    currentId = nextId.Value;
                else
                    MessageBox.Show("The last is currently displayed");
            }
            else if (sender == btnPrevious)
            {
                if (previousId != null)
                    currentId = previousId.Value;
                else
                    MessageBox.Show("The first is currently displayed");
            }
            else
            {
                return;
            }
            LoadCurrentPosition();
            DisplayCurrentCourse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Course?", "Are you sure",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteCourse();
            }
            LoadFirstCourse();


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
                 if (ValidateChildren())
                {
                    if (currentState == FormState.View)
                    {
                        SetState(FormState.Edit);
                    }
                    else
                    {
                        if (txtInventoryId.Text == string.Empty)
                        {
                            CreateCourse();
                            LoadFirstCourse();
                        }
                        else
                        {
                            UpdateCourse();
                        }

                        SetState(FormState.View);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetState(FormState.View);
            DisplayCurrentCourse();

        }


        #endregion

        private void frmCourses_Load(object sender, EventArgs e)
        {
            LoadFirstCourse();
            SetState(FormState.View);
        }

        private void DisableNavigation()
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
        }

        private void NavigationButtonManagement()
        {
            btnPrevious.Enabled = previousId != null;
            btnNext.Enabled = nextId != null;

            btnFirst.Enabled = currentId != firstId;
            btnLast.Enabled = currentId != lastId;
        }

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
                InputsReadOnly(true);
                NavigationButtonManagement();
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                InputsReadOnly(false);
                if (state == FormState.Add)
                {
                    //clear grp 
                    UIUtilities.ClearControls(grpCourses.Controls);

                }
                DisableNavigation();
            }
        }


        private void InputsReadOnly(bool readOnly)
        {
            txtFoodName.ReadOnly = readOnly;
            txtPrice.ReadOnly = readOnly;
            dtpPurchase.Enabled = !readOnly;
        }




        #endregion

        #region load data


        private void LoadFirstCourse()
        {
            currentId = GetFirstCourseId();
            LoadCurrentPosition();
            DisplayCurrentCourse();

        }

        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();
        }
        private void LoadPositionInfo(DataRow PositionRow)
        {
            int foodCount = Convert.ToInt32(PositionRow["FoodCount"]);
            currentId = Convert.ToInt32(PositionRow["InventoryID"]);
            firstId = Convert.ToInt32(PositionRow["FirstCourseId"]);
            lastId = Convert.ToInt32(PositionRow["LastCourseId"]);
            rowNumber = Convert.ToInt32(PositionRow["RowNumber"]);
            nextId = PositionRow["NextCourseId"] != DBNull.Value ?
            Convert.ToInt32(PositionRow["NextCourseId"]) : null;
            previousId = PositionRow["PreviousCourseId"] != DBNull.Value ?
            Convert.ToInt32(PositionRow["PreviousCourseId"]) : null;

            this.DisplayParentStatusStripMessage($"displaying food {rowNumber} out of {foodCount}");
        }

        #region display data row

        private void DisplayCurrentCourse()
        {
            DataRow currentCourseRow = GetInventoryDataRow(currentId);
            DisplayCourse(currentCourseRow);
        }

        private void DisplayCourse(DataRow selectedCourse)
        {
            txtInventoryId.Text = selectedCourse["InventoryID"].ToString();
            txtFoodName.Text = selectedCourse["FoodName"].ToString();
            txtPrice.Text = selectedCourse["Price"].ToString(); 
            dtpPurchase.Value = Convert.ToDateTime(selectedCourse["PurchaseDate"]);
        }


        #endregion

        #endregion
        private int GetFirstCourseId()
        {
            int id = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) InventoryID FROM Inventory ORDER BY PurchaseDate"));
            return id;
        }

        #region Get Data Row
        private DataRow GetInventoryDataRow(int id)
        {
            string sqlCourseById = $"SELECT * FROM Inventory WHERE InventoryID = {id}";
            DataTable dt = DataAccess.GetData(sqlCourseById);
            return dt.Rows[0];
        }


        private DataRow GetPositionDataRow(int id)
        {
            string sqlNav = $@"
            SELECT 
            (SELECT COUNT(1) FROM Inventory) AS FoodCount,
            InventoryID,
            (
            SELECT TOP(1) InventoryID as FirstCourseId FROM Inventory ORDER BY PurchaseDate
            ) as FirstCourseId,
            q.PreviousCourseId,
            q.NextCourseId,
            (
            SELECT TOP(1) InventoryID as LastCourseId FROM Inventory ORDER BY PurchaseDate Desc
            ) as LastCourseId,
            q.RowNumber
            FROM
            (
            SELECT InventoryID, FoodName,
            LEAD(InventoryID) OVER(ORDER BY PurchaseDate) AS NextCourseId,
            LAG(InventoryID) OVER(ORDER BY PurchaseDate) AS PreviousCourseId,
            ROW_NUMBER() OVER(ORDER BY PurchaseDate) AS 'RowNumber'
            FROM Inventory
            ) AS q
            WHERE q.InventoryID = {id}
            ORDER BY q.FoodName";
            DataTable dt = DataAccess.GetData(sqlNav);
            return dt.Rows[0];
        }

        #endregion

        #region Send Data

        private void UpdateCourse()
        {
            string sqlUpdateCourse = $@"
                 UPDATE Inventory
                 SET FoodName = '{txtFoodName.Text.Trim()}'
                 ,Price = {txtPrice.Text}
                 ,PurchaseDate = {dtpPurchase.Value} 
                 WHERE CourseId = {txtInventoryId.Text}";

            Debug.WriteLine(sqlUpdateCourse);

            int rowsAffected = DataAccess.SendData(sqlUpdateCourse);

            if(rowsAffected == 0)
            {
                MessageBox.Show("the database reported no rows effected");
            }
            else if(rowsAffected == 1)
            {
                MessageBox.Show("course updated");
            }
            else
            {
                MessageBox.Show("something went wrong pls verify your data ");
            }
        }

        private void CreateCourse()
        {
            string formattedDate = dtpPurchase.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sqlInsertCourse = $@"
                     INSERT INTO Inventory
                     (
                        FoodName,
                        Price,
                        PurchaseDate)
                     VALUES
                     (
                        '{txtFoodName.Text.Trim()}'
                        ,'{txtPrice.Text}'
                        ,'{formattedDate}'
                     )";


            int rowsAffected = DataAccess.SendData(sqlInsertCourse);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Course created.");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected.");
            }
        }

        private void DeleteCourse()
        {
            string sqlDelete = $"DELETE FROM Inventory WHERE InventoryID = {txtInventoryId.Text}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Course was deleted");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected");
            }

        }
        #endregion

        #region validation


        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errMsg = null;

            if (txt.Text == string.Empty)
            {
                errMsg = $"{txt.Tag} is required.";
                e.Cancel = true;
            }
            if(sender == txtPrice  )
            {
                if(!IsNumeric(txt.Text))
                {
                    errMsg = $"{txt.Tag} must be fill";
                }
            }
        }
        
        private bool IsNumeric(string value)
        {
            return int.TryParse(value,out _);
        }

        #endregion
    }
}

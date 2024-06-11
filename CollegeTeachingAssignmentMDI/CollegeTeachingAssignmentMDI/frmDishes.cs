using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeTeachingAssignmentMDI
{
    public partial class frmDishes : Form
    {
        private int currentId;
        private int firstId;
        private int lastId;
        private int? nextId;
        private int? previousId; 
        private int rowNumber;

        private FormState currentState;
        public frmDishes()
        {
            InitializeComponent();
        }

        #region event handler

        private void frmInstructors_Load(object sender, EventArgs e)
        {
            LoadFirstCourse();
            SetState(FormState.View);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
            this.DisplayParentStatusStripMessage("adding...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this dish?", "Are you sure",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteDish();
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
                else if (ValidateChildren())
                {
                    if (currentState == FormState.View)
                    {
                        SetState(FormState.Edit);
                    }
                    else
                    {
                        if (txtDishID.Text == string.Empty)
                        {
                            CreateDish();
                            LoadFirstCourse();
                        }
                        else
                        {
                            UpdateDish();
                        }

                        SetState(FormState.View);
                        LoadCurrentPosition();
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
            DisplayCurrentInstructor();
            LoadCurrentPosition();
        }


        #endregion

        #region navigation


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
            DisplayCurrentInstructor();
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
                    UIUtilities.ClearControls(grpInstructors.Controls);

                }
                DisableNavigation();
            }
        }


        private void InputsReadOnly(bool readOnly)
        {
            txtDishName.ReadOnly = readOnly;
            txtComment.ReadOnly = readOnly;
            dtpMade.Enabled = !readOnly;
            trackBarRating.Enabled = !readOnly;
        }




        #endregion


        #region load data

        private void LoadFirstCourse()
        {
            currentId = GetFirstInstructorId();
            LoadCurrentPosition();
            DisplayCurrentInstructor();

        }


        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();
        }

        private void LoadPositionInfo(DataRow PositionRow)
        {
            int DishesCount = Convert.ToInt32(PositionRow["DishesCount"]);
            currentId = Convert.ToInt32(PositionRow["DishID"]);
            firstId = Convert.ToInt32(PositionRow["FirstCourseId"]);
            lastId = Convert.ToInt32(PositionRow["LastCourseId"]);
            rowNumber = Convert.ToInt32(PositionRow["RowNumber"]);
            nextId = PositionRow["NextCourseId"] != DBNull.Value ?
            Convert.ToInt32(PositionRow["NextCourseId"]) : null;
            previousId = PositionRow["PreviousCourseId"] != DBNull.Value ?
            Convert.ToInt32(PositionRow["PreviousCourseId"]) : null;
            this.DisplayParentStatusStripMessage($"Display Dish {rowNumber} out of {DishesCount}");

        }


        #endregion

        #region get data row

        private int GetFirstInstructorId()
        {
            int id = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) DishID FROM CookedDish ORDER BY DishID"));
            return id;
        }



        private void DisplayCurrentInstructor()
        {
            DataRow currentInstructorRow = GetInstructorDataRow(currentId);
            DisplayInstructor(currentInstructorRow);
        }
        private void DisplayInstructor(DataRow selectedInstructor)
        {
            
            txtDishID.Text = selectedInstructor["DishID"].ToString();
            txtDishName.Text = selectedInstructor["DishName"].ToString();
            txtComment.Text = selectedInstructor["Comment"].ToString(); 
            dtpMade.Value = Convert.ToDateTime(selectedInstructor["DateOfMade"]);
            trackBarRating.Value = Convert.ToInt32(selectedInstructor["Rating"]);

         }

        private DataRow GetInstructorDataRow(int id)
        {
            string sqlById = $"SELECT * FROM CookedDish WHERE DishID = {id}";
            DataTable dt = DataAccess.GetData(sqlById);
            return dt.Rows[0];
        }

        private DataRow GetPositionDataRow(int id)
        {
            string sqlNav = $@"
              SELECT 
              (SELECT COUNT(1) FROM CookedDish) AS DishesCount,
              DishID,
              (
              SELECT TOP(1) DishID as FirstCourseId FROM CookedDish ORDER BY DishID
              ) as FirstCourseId,
              q.PreviousCourseId,
              q.NextCourseId,
              (
              SELECT TOP(1) DishID as LastCourseId FROM CookedDish ORDER BY DishID Desc
              ) as LastCourseId,
              q.RowNumber
              FROM
              (
              SELECT DishID, DishName,
              LEAD(DishID) OVER(ORDER BY DishID) AS NextCourseId,
              LAG(DishID) OVER(ORDER BY DishID) AS PreviousCourseId,
              ROW_NUMBER() OVER(ORDER BY DishID) AS 'RowNumber'
              FROM CookedDish
              ) AS q
              WHERE q.DishID = {id}
              ORDER BY q.DishID";
            DataTable dt = DataAccess.GetData(sqlNav);
            return dt.Rows[0];
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
  
        }

        private bool IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        #endregion

        #region send data

        private void CreateDish()
        {
            string formattedDate = dtpMade.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sqlInsertCourse = $@"
             INSERT INTO CookedDish
             (
                DishName,
                Comment,
                DateOfMade,
	            Rating)
             VALUES
             (
                '{txtDishName.Text.Trim()}'
                ,'{txtComment.Text}'
                ,'{formattedDate}'
                ,'{trackBarRating.Value}'
            
             )";


            int rowsAffected = DataAccess.SendData(sqlInsertCourse);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Dish created.");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected.");
            }

        }
        private void DeleteDish()
        {
            string sqlDelete = $" DELETE FROM CookedDish WHERE DishID = {txtDishID.Text}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Dish was deleted");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected");
            }

        }


        private void UpdateDish()
        {
            string sqlUpdateCourse = $@"
    UPDATE CookedDish
    SET DishName = '{txtDishName.Text.Trim()}'
    ,Comment = '{txtComment.Text}'  -- 正确添加单引号
    ,DateOfMade = '{dtpMade.Value}'  -- 正确添加单引号
    ,Rating = '{trackBarRating.Value}'
    WHERE DishID = {txtDishID.Text}";


            Debug.WriteLine(sqlUpdateCourse);

            int rowsAffected = DataAccess.SendData(sqlUpdateCourse);

            if (rowsAffected == 0)
            {
                MessageBox.Show("the database reported no rows effected");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Dish updated");
            }
            else
            {
                MessageBox.Show("something went wrong pls verify your data ");
            }
        }



        #endregion

    }
}

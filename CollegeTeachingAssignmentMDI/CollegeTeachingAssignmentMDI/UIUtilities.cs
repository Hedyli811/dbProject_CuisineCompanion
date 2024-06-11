using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeTeachingAssignmentMDI
{
    public static  class UIUtilities
    {
        public static void ClearControls(this Control.ControlCollection controlsCollection)
        {
            foreach (Control control in controlsCollection)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case ComboBox combo:
                        combo.SelectedIndex = 0;
                        break;
                    case GroupBox groupBox:
                        ClearControls(groupBox.Controls);
                        break;
                }
            }
        }

        public static void DisplayParentStatusStripMessage(this Form form, string message)
        {
            DisplayParentStatusStripMessage(form, message, Color.Black);
        }

        public static void DisplayParentStatusStripMessage(this Form form, string message, Color color)
        {
            frmMDIParent? perentMdi = form.MdiParent as frmMDIParent;
            if (perentMdi != null)
            {
                perentMdi.DisplayStatusMessage(message, color);
            }
        }

        public static void AddEmptyRow(this DataTable dt, string emptyColumn, string nullColumn)
        {
            DataRow dr = dt.NewRow();
            //dr[emptyColumn] = string.Empty;
            dr[emptyColumn] = "-- Select an Item --";
            dr[nullColumn] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
        }

        public static void Bind(this ComboBox cmb, string displayMember, string valueMember, object? dataSource)
        {
            cmb.DataSource = dataSource;
            cmb.ValueMember = valueMember;
            cmb.DisplayMember = displayMember;
        }

        public static void ClearChildControls(this Control control, int defaultSelectedIndex = 0)
        {
            ClearControls(control.Controls, defaultSelectedIndex);
        }
        public static void ClearControls(this Control.ControlCollection controlsCollection, int defaultSelectedIndex = 0)
        {
            foreach (Control control in controlsCollection)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case ComboBox combo:
                        combo.SelectedIndex = 0;
                        break;
                    case GroupBox groupBox:
                        ClearControls(groupBox.Controls);
                        break;
                }
            }
        }
    }
}

namespace CollegeTeachingAssignmentMDI
{
    partial class frmBrowseInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDisplay = new Button();
            cmbInventory = new ComboBox();
            dgvInventory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(307, 33);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(130, 58);
            btnDisplay.TabIndex = 0;
            btnDisplay.Text = "Display related ingredients";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // cmbInventory
            // 
            cmbInventory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInventory.FormattingEnabled = true;
            cmbInventory.Location = new Point(73, 49);
            cmbInventory.Name = "cmbInventory";
            cmbInventory.Size = new Size(216, 28);
            cmbInventory.TabIndex = 1;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(73, 120);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(364, 297);
            dgvInventory.TabIndex = 2;
            // 
            // frmBrowseInventory
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 467);
            Controls.Add(dgvInventory);
            Controls.Add(cmbInventory);
            Controls.Add(btnDisplay);
            Name = "frmBrowseInventory";
            Text = "frmBrowseInventory";
            Load += frmBrowseInventory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDisplay;
        private ComboBox cmbInventory;
        private DataGridView dgvInventory;
    }
}
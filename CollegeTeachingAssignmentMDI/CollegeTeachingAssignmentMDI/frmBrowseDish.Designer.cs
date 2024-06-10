namespace CollegeTeachingAssignmentMDI
{
    partial class frmBrowseDish
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
            cmbDish = new ComboBox();
            btnDisplay = new Button();
            dgvDish = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDish).BeginInit();
            SuspendLayout();
            // 
            // cmbDish
            // 
            cmbDish.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDish.FormattingEnabled = true;
            cmbDish.Location = new Point(79, 55);
            cmbDish.Name = "cmbDish";
            cmbDish.Size = new Size(259, 28);
            cmbDish.TabIndex = 0;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(559, 55);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(172, 29);
            btnDisplay.TabIndex = 1;
            btnDisplay.Text = "Display Dish";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // dgvDish
            // 
            dgvDish.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDish.Location = new Point(79, 124);
            dgvDish.Name = "dgvDish";
            dgvDish.RowHeadersWidth = 51;
            dgvDish.Size = new Size(652, 296);
            dgvDish.TabIndex = 2;
            // 
            // frmBrowseDish
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDish);
            Controls.Add(btnDisplay);
            Controls.Add(cmbDish);
            Name = "frmBrowseDish";
            Text = "frmBrowseDish";
            Load += frmBrowseDish_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDish).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbDish;
        private Button btnDisplay;
        private DataGridView dgvDish;
    }
}
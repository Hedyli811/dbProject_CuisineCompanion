namespace CuisineCompanionMDI
{
    partial class frmManytoMany
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
            components = new System.ComponentModel.Container();
            cmbInventory = new ComboBox();
            cmbDish = new ComboBox();
            txtQty = new TextBox();
            lblInventory = new Label();
            lblDish = new Label();
            lblQty = new Label();
            btnCancel = new Button();
            btnLast = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnFirst = new Button();
            btnSave = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            grpIngredient = new GroupBox();
            errorProvider = new ErrorProvider(components);
            grpIngredient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // cmbInventory
            // 
            cmbInventory.FormattingEnabled = true;
            cmbInventory.Location = new Point(240, 79);
            cmbInventory.Name = "cmbInventory";
            cmbInventory.Size = new Size(237, 28);
            cmbInventory.TabIndex = 1;
            // 
            // cmbDish
            // 
            cmbDish.FormattingEnabled = true;
            cmbDish.Location = new Point(240, 131);
            cmbDish.Name = "cmbDish";
            cmbDish.Size = new Size(237, 28);
            cmbDish.TabIndex = 2;
            // 
            // txtQty
            // 
            txtQty.Location = new Point(240, 195);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(237, 27);
            txtQty.TabIndex = 3;
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Location = new Point(135, 82);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(85, 20);
            lblInventory.TabIndex = 4;
            lblInventory.Text = "Ingredient";
            // 
            // lblDish
            // 
            lblDish.AutoSize = true;
            lblDish.Location = new Point(135, 139);
            lblDish.Name = "lblDish";
            lblDish.Size = new Size(40, 20);
            lblDish.TabIndex = 5;
            lblDish.Text = "Dish";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(28, 202);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(192, 20);
            lblQty.TabIndex = 6;
            lblQty.Text = "ingredient used quantity ";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(493, 329);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 35);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(493, 290);
            btnLast.Margin = new Padding(4, 5, 4, 5);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(115, 29);
            btnLast.TabIndex = 30;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navagation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(101, 329);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 35);
            btnAdd.TabIndex = 31;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(231, 329);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 35);
            btnDelete.TabIndex = 32;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(101, 290);
            btnFirst.Margin = new Padding(4, 5, 4, 5);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(115, 29);
            btnFirst.TabIndex = 29;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navagation_Handler;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(362, 329);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 35);
            btnSave.TabIndex = 33;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(231, 290);
            btnPrevious.Margin = new Padding(4, 5, 4, 5);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(115, 29);
            btnPrevious.TabIndex = 28;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navagation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(362, 290);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(115, 29);
            btnNext.TabIndex = 27;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navagation_Handler;
            // 
            // grpIngredient
            // 
            grpIngredient.Controls.Add(cmbInventory);
            grpIngredient.Controls.Add(btnCancel);
            grpIngredient.Controls.Add(cmbDish);
            grpIngredient.Controls.Add(btnLast);
            grpIngredient.Controls.Add(txtQty);
            grpIngredient.Controls.Add(btnAdd);
            grpIngredient.Controls.Add(lblInventory);
            grpIngredient.Controls.Add(btnDelete);
            grpIngredient.Controls.Add(lblDish);
            grpIngredient.Controls.Add(btnFirst);
            grpIngredient.Controls.Add(lblQty);
            grpIngredient.Controls.Add(btnSave);
            grpIngredient.Controls.Add(btnNext);
            grpIngredient.Controls.Add(btnPrevious);
            grpIngredient.Location = new Point(12, 12);
            grpIngredient.Name = "grpIngredient";
            grpIngredient.Size = new Size(698, 426);
            grpIngredient.TabIndex = 35;
            grpIngredient.TabStop = false;
            grpIngredient.Text = "Ingredient";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmManytoMany
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 451);
            Controls.Add(grpIngredient);
            Name = "frmManytoMany";
            Text = "frmManytoMany";
            Load += frmManytoMany_Load;
            grpIngredient.ResumeLayout(false);
            grpIngredient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbInventory;
        private ComboBox cmbDish;
        private TextBox txtQty;
        private Label lblInventory;
        private Label lblDish;
        private Label lblQty;
        private Button btnCancel;
        private Button btnLast;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnFirst;
        private Button btnSave;
        private Button btnPrevious;
        private Button btnNext;
        private GroupBox grpIngredient;
        private ErrorProvider errorProvider;
    }
}
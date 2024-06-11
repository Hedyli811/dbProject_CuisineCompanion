namespace CollegeTeachingAssignmentMDI
{


    partial class frmInventory
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
            grpCourses = new GroupBox();
            dtpPurchase = new DateTimePicker();
            txtInventoryId = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnLast = new Button();
            btnAdd = new Button();
            label4 = new Label();
            btnDelete = new Button();
            btnFirst = new Button();
            btnSave = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            txtPrice = new TextBox();
            label3 = new Label();
            txtFoodName = new TextBox();
            label2 = new Label();
            errorProvider = new ErrorProvider(components);
            qty = new Label();
            txtQty = new TextBox();
            grpCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // grpCourses
            // 
            grpCourses.Controls.Add(txtQty);
            grpCourses.Controls.Add(qty);
            grpCourses.Controls.Add(dtpPurchase);
            grpCourses.Controls.Add(txtInventoryId);
            grpCourses.Controls.Add(label1);
            grpCourses.Controls.Add(btnCancel);
            grpCourses.Controls.Add(btnLast);
            grpCourses.Controls.Add(btnAdd);
            grpCourses.Controls.Add(label4);
            grpCourses.Controls.Add(btnDelete);
            grpCourses.Controls.Add(btnFirst);
            grpCourses.Controls.Add(btnSave);
            grpCourses.Controls.Add(btnPrevious);
            grpCourses.Controls.Add(btnNext);
            grpCourses.Controls.Add(txtPrice);
            grpCourses.Controls.Add(label3);
            grpCourses.Controls.Add(txtFoodName);
            grpCourses.Controls.Add(label2);
            grpCourses.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCourses.Location = new Point(50, 79);
            grpCourses.Margin = new Padding(4, 5, 4, 5);
            grpCourses.Name = "grpCourses";
            grpCourses.Padding = new Padding(4, 5, 4, 5);
            grpCourses.Size = new Size(645, 497);
            grpCourses.TabIndex = 9;
            grpCourses.TabStop = false;
            grpCourses.Text = "Inventory Details";
            // 
            // dtpPurchase
            // 
            dtpPurchase.Location = new Point(74, 265);
            dtpPurchase.Name = "dtpPurchase";
            dtpPurchase.Size = new Size(250, 26);
            dtpPurchase.TabIndex = 29;
            // 
            // txtInventoryId
            // 
            txtInventoryId.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInventoryId.Location = new Point(74, 63);
            txtInventoryId.Margin = new Padding(4, 5, 4, 5);
            txtInventoryId.Name = "txtInventoryId";
            txtInventoryId.ReadOnly = true;
            txtInventoryId.Size = new Size(502, 23);
            txtInventoryId.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 20);
            label1.TabIndex = 27;
            label1.Text = "Id:";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(459, 389);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 72);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(459, 314);
            btnLast.Margin = new Padding(4, 5, 4, 5);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(122, 66);
            btnLast.TabIndex = 22;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(68, 389);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(122, 72);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 231);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 4;
            label4.Text = "Purchase Date:";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(198, 389);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 72);
            btnDelete.TabIndex = 24;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(68, 314);
            btnFirst.Margin = new Padding(4, 5, 4, 5);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(122, 66);
            btnFirst.TabIndex = 21;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(328, 389);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 72);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(198, 314);
            btnPrevious.Margin = new Padding(4, 5, 4, 5);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(122, 66);
            btnPrevious.TabIndex = 20;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(328, 314);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(122, 66);
            btnNext.TabIndex = 19;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(74, 195);
            txtPrice.Margin = new Padding(4, 5, 4, 5);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(502, 23);
            txtPrice.TabIndex = 3;
            txtPrice.Tag = "Credits";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 165);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 2;
            label3.Text = "Price:";
            // 
            // txtFoodName
            // 
            txtFoodName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFoodName.Location = new Point(74, 129);
            txtFoodName.Margin = new Padding(4, 5, 4, 5);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.Size = new Size(502, 23);
            txtFoodName.TabIndex = 1;
            txtFoodName.Tag = "Course name";
            txtFoodName.Validating += txt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 99);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 0;
            label2.Text = "Food Name:";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // qty
            // 
            qty.AutoSize = true;
            qty.Location = new Point(354, 231);
            qty.Name = "qty";
            qty.Size = new Size(79, 20);
            qty.TabIndex = 30;
            qty.Text = "Quantity";
            // 
            // txtQty
            // 
            txtQty.Location = new Point(354, 265);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(125, 26);
            txtQty.TabIndex = 31;
            // 
            // frmInventory
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 646);
            Controls.Add(grpCourses);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmInventory";
            Text = "frmInventory";
            Load += frmCourses_Load;
            grpCourses.ResumeLayout(false);
            grpCourses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpCourses;
        private System.Windows.Forms.TextBox txtInventoryId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPurchaseDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DateTimePicker dtpPurchase;
        private TextBox txtQty;
        private Label qty;
    }



}

namespace CollegeTeachingAssignmentMDI
{
    partial class frmDishes
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
            grpInstructors = new GroupBox();
            trackBarRating = new TrackBar();
            dtpMade = new DateTimePicker();
            label5 = new Label();
            txtDishID = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnLast = new Button();
            label8 = new Label();
            btnAdd = new Button();
            label4 = new Label();
            btnDelete = new Button();
            btnFirst = new Button();
            btnSave = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            txtComment = new TextBox();
            label3 = new Label();
            txtDishName = new TextBox();
            label2 = new Label();
            errProvider = new ErrorProvider(components);
            grpInstructors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // grpInstructors
            // 
            grpInstructors.Controls.Add(trackBarRating);
            grpInstructors.Controls.Add(dtpMade);
            grpInstructors.Controls.Add(label5);
            grpInstructors.Controls.Add(txtDishID);
            grpInstructors.Controls.Add(label1);
            grpInstructors.Controls.Add(btnCancel);
            grpInstructors.Controls.Add(btnLast);
            grpInstructors.Controls.Add(label8);
            grpInstructors.Controls.Add(btnAdd);
            grpInstructors.Controls.Add(label4);
            grpInstructors.Controls.Add(btnDelete);
            grpInstructors.Controls.Add(btnFirst);
            grpInstructors.Controls.Add(btnSave);
            grpInstructors.Controls.Add(btnPrevious);
            grpInstructors.Controls.Add(btnNext);
            grpInstructors.Controls.Add(txtComment);
            grpInstructors.Controls.Add(label3);
            grpInstructors.Controls.Add(txtDishName);
            grpInstructors.Controls.Add(label2);
            grpInstructors.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpInstructors.Location = new Point(46, 42);
            grpInstructors.Margin = new Padding(4, 5, 4, 5);
            grpInstructors.Name = "grpInstructors";
            grpInstructors.Padding = new Padding(4, 5, 4, 5);
            grpInstructors.Size = new Size(645, 565);
            grpInstructors.TabIndex = 8;
            grpInstructors.TabStop = false;
            grpInstructors.Text = "Dish Details";
            // 
            // trackBarRating
            // 
            trackBarRating.Location = new Point(74, 338);
            trackBarRating.Maximum = 5;
            trackBarRating.Name = "trackBarRating";
            trackBarRating.Size = new Size(502, 56);
            trackBarRating.TabIndex = 32;
            // 
            // dtpMade
            // 
            dtpMade.Location = new Point(74, 254);
            dtpMade.Name = "dtpMade";
            dtpMade.Size = new Size(250, 26);
            dtpMade.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 299);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 29;
            label5.Text = "Rating:";
            // 
            // txtDishID
            // 
            txtDishID.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDishID.Location = new Point(74, 63);
            txtDishID.Margin = new Padding(4, 5, 4, 5);
            txtDishID.Name = "txtDishID";
            txtDishID.ReadOnly = true;
            txtDishID.Size = new Size(502, 23);
            txtDishID.TabIndex = 28;
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
            btnCancel.Location = new Point(471, 488);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 35);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(471, 449);
            btnLast.Margin = new Padding(4, 5, 4, 5);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(115, 29);
            btnLast.TabIndex = 22;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(69, 312);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(79, 488);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 35);
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
            label4.Size = new Size(128, 20);
            label4.TabIndex = 4;
            label4.Text = "Date of Made:";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(209, 488);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 35);
            btnDelete.TabIndex = 24;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(79, 449);
            btnFirst.Margin = new Padding(4, 5, 4, 5);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(115, 29);
            btnFirst.TabIndex = 21;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(340, 488);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 35);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(209, 449);
            btnPrevious.Margin = new Padding(4, 5, 4, 5);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(115, 29);
            btnPrevious.TabIndex = 20;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(340, 449);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(115, 29);
            btnNext.TabIndex = 19;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // txtComment
            // 
            txtComment.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtComment.Location = new Point(74, 195);
            txtComment.Margin = new Padding(4, 5, 4, 5);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(502, 23);
            txtComment.TabIndex = 3;
            txtComment.Tag = "Last name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 165);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 2;
            label3.Text = "Comment:";
            // 
            // txtDishName
            // 
            txtDishName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDishName.Location = new Point(74, 129);
            txtDishName.Margin = new Padding(4, 5, 4, 5);
            txtDishName.Name = "txtDishName";
            txtDishName.Size = new Size(502, 23);
            txtDishName.TabIndex = 1;
            txtDishName.Tag = "First name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 98);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 0;
            label2.Text = "Dish Name:";
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // frmDishes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 646);
            Controls.Add(grpInstructors);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmDishes";
            Text = "frmDishes";
            Load += frmInstructors_Load;
            grpInstructors.ResumeLayout(false);
            grpInstructors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpInstructors;
        private System.Windows.Forms.TextBox txtDishID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDishName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errProvider;
        private Label label5;
        private DateTimePicker dtpMade;
        private TrackBar trackBarRating;
    }


}

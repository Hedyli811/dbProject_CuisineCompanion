namespace CollegeTeachingAssignmentMDI
{
    partial class frmLogin
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
            lblUserName = new Label();
            lblPsw = new Label();
            txtUserName = new TextBox();
            txtPsw = new TextBox();
            btnCancel = new Button();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(82, 58);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(42, 20);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "User";
            // 
            // lblPsw
            // 
            lblPsw.AutoSize = true;
            lblPsw.Location = new Point(82, 101);
            lblPsw.Name = "lblPsw";
            lblPsw.Size = new Size(78, 20);
            lblPsw.TabIndex = 1;
            lblPsw.Text = "Password";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(192, 55);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(125, 27);
            txtUserName.TabIndex = 2;
            // 
            // txtPsw
            // 
            txtPsw.Location = new Point(192, 98);
            txtPsw.Name = "txtPsw";
            txtPsw.Size = new Size(125, 27);
            txtPsw.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(95, 183);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(223, 183);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 268);
            Controls.Add(btnLogin);
            Controls.Add(btnCancel);
            Controls.Add(txtPsw);
            Controls.Add(txtUserName);
            Controls.Add(lblPsw);
            Controls.Add(lblUserName);
            Name = "frmLogin";
            Text = "frmLogin";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserName;
        private Label lblPsw;
        private TextBox txtUserName;
        private TextBox txtPsw;
        private Button btnCancel;
        private Button btnLogin;
    }
}
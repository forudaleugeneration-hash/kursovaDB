namespace LibraryApp.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.CheckBox chkShowRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            textBoxUsername = new TextBox();
            lblPassword = new Label();
            textBoxPassword = new TextBox();
            lblEmail = new Label();
            textBoxEmail = new TextBox();
            lblFullName = new Label();
            textBoxFullName = new TextBox();
            chkShowRegister = new CheckBox();
            btnLogin = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(467, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Библиотека";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft Sans Serif", 9F);
            lblUsername.Location = new Point(58, 87);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(44, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Логин:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Microsoft Sans Serif", 10F);
            textBoxUsername.Location = new Point(58, 110);
            textBoxUsername.Margin = new Padding(4, 3, 4, 3);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(303, 23);
            textBoxUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 9F);
            lblPassword.Location = new Point(58, 150);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(54, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Microsoft Sans Serif", 10F);
            textBoxPassword.Location = new Point(58, 173);
            textBoxPassword.Margin = new Padding(4, 3, 4, 3);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(303, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 9F);
            lblEmail.Location = new Point(58, 219);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            lblEmail.Visible = false;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Microsoft Sans Serif", 10F);
            textBoxEmail.Location = new Point(58, 242);
            textBoxEmail.Margin = new Padding(4, 3, 4, 3);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(303, 23);
            textBoxEmail.TabIndex = 6;
            textBoxEmail.Visible = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Microsoft Sans Serif", 9F);
            lblFullName.Location = new Point(58, 283);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(80, 15);
            lblFullName.TabIndex = 7;
            lblFullName.Text = "Полное имя:";
            lblFullName.Visible = false;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Font = new Font("Microsoft Sans Serif", 10F);
            textBoxFullName.Location = new Point(58, 306);
            textBoxFullName.Margin = new Padding(4, 3, 4, 3);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(303, 23);
            textBoxFullName.TabIndex = 8;
            textBoxFullName.Visible = false;
            // 
            // chkShowRegister
            // 
            chkShowRegister.AutoSize = true;
            chkShowRegister.Font = new Font("Microsoft Sans Serif", 9F);
            chkShowRegister.Location = new Point(58, 352);
            chkShowRegister.Margin = new Padding(4, 3, 4, 3);
            chkShowRegister.Name = "chkShowRegister";
            chkShowRegister.Size = new Size(230, 19);
            chkShowRegister.TabIndex = 9;
            chkShowRegister.Text = "Регистрация нового пользователя";
            chkShowRegister.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(125, 404);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(163, 46);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(46, 204, 113);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(125, 404);
            btnRegister.Margin = new Padding(4, 3, 4, 3);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(163, 46);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(467, 457);
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(lblPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(lblEmail);
            Controls.Add(textBoxEmail);
            Controls.Add(lblFullName);
            Controls.Add(textBoxFullName);
            Controls.Add(chkShowRegister);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
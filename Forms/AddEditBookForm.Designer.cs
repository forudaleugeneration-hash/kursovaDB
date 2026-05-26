namespace LibraryApp.Forms
{
    partial class AddEditBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ComboBox comboBoxAuthor;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label lblTotalCopies;
        private System.Windows.Forms.NumericUpDown numericTotalCopies;
        private System.Windows.Forms.Label lblAnnotation;
        private System.Windows.Forms.RichTextBox richTextBoxAnnotation;
        private System.Windows.Forms.CheckBox checkBoxIsNew;
        private System.Windows.Forms.CheckBox checkBoxIsHit;
        private System.Windows.Forms.CheckBox checkBoxIsOnline;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBoxCover;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button btnLoadCover;
        private System.Windows.Forms.Button btnDeleteCover;
        private System.Windows.Forms.Label lblCoverStatus;
        private System.Windows.Forms.GroupBox groupBoxPdf;
        private System.Windows.Forms.Button btnLoadPdf;
        private System.Windows.Forms.Button btnDeletePdf;
        private System.Windows.Forms.Label lblPdfStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.comboBoxAuthor = new System.Windows.Forms.ComboBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.lblTotalCopies = new System.Windows.Forms.Label();
            this.numericTotalCopies = new System.Windows.Forms.NumericUpDown();
            this.lblAnnotation = new System.Windows.Forms.Label();
            this.richTextBoxAnnotation = new System.Windows.Forms.RichTextBox();
            this.checkBoxIsNew = new System.Windows.Forms.CheckBox();
            this.checkBoxIsHit = new System.Windows.Forms.CheckBox();
            this.checkBoxIsOnline = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxCover = new System.Windows.Forms.GroupBox();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.btnLoadCover = new System.Windows.Forms.Button();
            this.btnDeleteCover = new System.Windows.Forms.Button();
            this.lblCoverStatus = new System.Windows.Forms.Label();
            this.groupBoxPdf = new System.Windows.Forms.GroupBox();
            this.btnLoadPdf = new System.Windows.Forms.Button();
            this.btnDeletePdf = new System.Windows.Forms.Button();
            this.lblPdfStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericTotalCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.groupBoxCover.SuspendLayout();
            this.groupBoxPdf.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 13);
            this.lblTitle.Text = "Название книги:";

            // textBoxTitle
            this.textBoxTitle.Location = new System.Drawing.Point(20, 40);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(400, 20);

            // lblAuthor
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(20, 75);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(40, 13);
            this.lblAuthor.Text = "Автор:";

            // comboBoxAuthor
            this.comboBoxAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthor.Location = new System.Drawing.Point(20, 95);
            this.comboBoxAuthor.Name = "comboBoxAuthor";
            this.comboBoxAuthor.Size = new System.Drawing.Size(400, 21);

            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(20, 130);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.Text = "Жанр:";

            // comboBoxGenre
            this.comboBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenre.Location = new System.Drawing.Point(20, 150);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(400, 21);

            // lblYear
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 185);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(73, 13);
            this.lblYear.Text = "Год издания:";

            // textBoxYear
            this.textBoxYear.Location = new System.Drawing.Point(20, 205);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(80, 20);

            // lblLanguage
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(115, 185);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(35, 13);
            this.lblLanguage.Text = "Язык:";

            // comboBoxLanguage
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Items.AddRange(new object[] { "Русский", "Английский", "Французский", "Немецкий", "Испанский" });
            this.comboBoxLanguage.Location = new System.Drawing.Point(155, 202);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(120, 21);

            // lblTotalCopies
            this.lblTotalCopies.AutoSize = true;
            this.lblTotalCopies.Location = new System.Drawing.Point(290, 185);
            this.lblTotalCopies.Name = "lblTotalCopies";
            this.lblTotalCopies.Size = new System.Drawing.Size(40, 13);
            this.lblTotalCopies.Text = "Копий:";

            // numericTotalCopies
            this.numericTotalCopies.Location = new System.Drawing.Point(335, 203);
            this.numericTotalCopies.Name = "numericTotalCopies";
            this.numericTotalCopies.Size = new System.Drawing.Size(55, 20);
            this.numericTotalCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericTotalCopies.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numericTotalCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblAnnotation
            this.lblAnnotation.AutoSize = true;
            this.lblAnnotation.Location = new System.Drawing.Point(20, 235);
            this.lblAnnotation.Name = "lblAnnotation";
            this.lblAnnotation.Size = new System.Drawing.Size(66, 13);
            this.lblAnnotation.Text = "Аннотация:";

            // richTextBoxAnnotation
            this.richTextBoxAnnotation.Location = new System.Drawing.Point(20, 255);
            this.richTextBoxAnnotation.Name = "richTextBoxAnnotation";
            this.richTextBoxAnnotation.Size = new System.Drawing.Size(400, 90);
            this.richTextBoxAnnotation.Text = "";

            // checkBoxIsNew
            this.checkBoxIsNew.AutoSize = true;
            this.checkBoxIsNew.Location = new System.Drawing.Point(20, 355);
            this.checkBoxIsNew.Name = "checkBoxIsNew";
            this.checkBoxIsNew.Size = new System.Drawing.Size(70, 17);
            this.checkBoxIsNew.Text = "Новинка";
            this.checkBoxIsNew.UseVisualStyleBackColor = true;

            // checkBoxIsHit
            this.checkBoxIsHit.AutoSize = true;
            this.checkBoxIsHit.Location = new System.Drawing.Point(120, 355);
            this.checkBoxIsHit.Name = "checkBoxIsHit";
            this.checkBoxIsHit.Size = new System.Drawing.Size(78, 17);
            this.checkBoxIsHit.Text = "Хит чтения";
            this.checkBoxIsHit.UseVisualStyleBackColor = true;

            // checkBoxIsOnline
            this.checkBoxIsOnline.AutoSize = true;
            this.checkBoxIsOnline.Location = new System.Drawing.Point(230, 355);
            this.checkBoxIsOnline.Name = "checkBoxIsOnline";
            this.checkBoxIsOnline.Size = new System.Drawing.Size(93, 17);
            this.checkBoxIsOnline.Text = "Онлайн (PDF)";
            this.checkBoxIsOnline.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(440, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.Text = "Сохранить";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.UseVisualStyleBackColor = false;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(590, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;

            // groupBoxCover
            this.groupBoxCover.Text = "Обложка";
            this.groupBoxCover.Location = new System.Drawing.Point(440, 20);
            this.groupBoxCover.Name = "groupBoxCover";
            this.groupBoxCover.Size = new System.Drawing.Size(280, 200);

            // pictureBoxCover
            this.pictureBoxCover.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(15, 20);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(250, 115);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            // btnLoadCover
            this.btnLoadCover.Location = new System.Drawing.Point(15, 143);
            this.btnLoadCover.Name = "btnLoadCover";
            this.btnLoadCover.Size = new System.Drawing.Size(120, 25);
            this.btnLoadCover.Text = "Загрузить";
            this.btnLoadCover.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnLoadCover.ForeColor = System.Drawing.Color.White;
            this.btnLoadCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCover.UseVisualStyleBackColor = false;

            // btnDeleteCover
            this.btnDeleteCover.Location = new System.Drawing.Point(145, 143);
            this.btnDeleteCover.Name = "btnDeleteCover";
            this.btnDeleteCover.Size = new System.Drawing.Size(120, 25);
            this.btnDeleteCover.Text = "Удалить";
            this.btnDeleteCover.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteCover.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCover.UseVisualStyleBackColor = false;
            this.btnDeleteCover.Visible = false;

            // lblCoverStatus
            this.lblCoverStatus.AutoSize = true;
            this.lblCoverStatus.Location = new System.Drawing.Point(15, 175);
            this.lblCoverStatus.Name = "lblCoverStatus";
            this.lblCoverStatus.Size = new System.Drawing.Size(54, 13);
            this.lblCoverStatus.Text = "JPG, PNG";

            this.groupBoxCover.Controls.Add(this.pictureBoxCover);
            this.groupBoxCover.Controls.Add(this.btnLoadCover);
            this.groupBoxCover.Controls.Add(this.btnDeleteCover);
            this.groupBoxCover.Controls.Add(this.lblCoverStatus);

            // groupBoxPdf
            this.groupBoxPdf.Text = "PDF файл";
            this.groupBoxPdf.Location = new System.Drawing.Point(440, 230);
            this.groupBoxPdf.Name = "groupBoxPdf";
            this.groupBoxPdf.Size = new System.Drawing.Size(280, 120);

            // btnLoadPdf
            this.btnLoadPdf.Location = new System.Drawing.Point(15, 25);
            this.btnLoadPdf.Name = "btnLoadPdf";
            this.btnLoadPdf.Size = new System.Drawing.Size(120, 28);
            this.btnLoadPdf.Text = "Загрузить PDF";
            this.btnLoadPdf.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnLoadPdf.ForeColor = System.Drawing.Color.White;
            this.btnLoadPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPdf.UseVisualStyleBackColor = false;

            // btnDeletePdf
            this.btnDeletePdf.Location = new System.Drawing.Point(145, 25);
            this.btnDeletePdf.Name = "btnDeletePdf";
            this.btnDeletePdf.Size = new System.Drawing.Size(120, 28);
            this.btnDeletePdf.Text = "Удалить PDF";
            this.btnDeletePdf.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeletePdf.ForeColor = System.Drawing.Color.White;
            this.btnDeletePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePdf.UseVisualStyleBackColor = false;
            this.btnDeletePdf.Visible = false;

            // lblPdfStatus
            this.lblPdfStatus.AutoSize = true;
            this.lblPdfStatus.Location = new System.Drawing.Point(15, 60);
            this.lblPdfStatus.Name = "lblPdfStatus";
            this.lblPdfStatus.Size = new System.Drawing.Size(88, 13);
            this.lblPdfStatus.Text = "PDF не загружен";

            this.groupBoxPdf.Controls.Add(this.btnLoadPdf);
            this.groupBoxPdf.Controls.Add(this.btnDeletePdf);
            this.groupBoxPdf.Controls.Add(this.lblPdfStatus);

            // AddEditBookForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 430);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxPdf);
            this.Controls.Add(this.groupBoxCover);
            this.Controls.Add(this.checkBoxIsOnline);
            this.Controls.Add(this.checkBoxIsHit);
            this.Controls.Add(this.checkBoxIsNew);
            this.Controls.Add(this.richTextBoxAnnotation);
            this.Controls.Add(this.lblAnnotation);
            this.Controls.Add(this.numericTotalCopies);
            this.Controls.Add(this.lblTotalCopies);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.comboBoxGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.comboBoxAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddEditBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление книги";
            ((System.ComponentModel.ISupportInitialize)(this.numericTotalCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.groupBoxCover.ResumeLayout(false);
            this.groupBoxCover.PerformLayout();
            this.groupBoxPdf.ResumeLayout(false);
            this.groupBoxPdf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
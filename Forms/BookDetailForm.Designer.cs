namespace LibraryApp.Forms
{
    partial class BookDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.RichTextBox richTextBoxAnnotation;
        private System.Windows.Forms.Button btnAddToBookmarks;
        private System.Windows.Forms.Button btnRentBook;
        private System.Windows.Forms.Button btnReadOnline;
        private System.Windows.Forms.Panel panelReservationCode;
        private System.Windows.Forms.Label lblReservationCode;
        private System.Windows.Forms.Label lblReservationInfo;
        private System.Windows.Forms.DataGridView dataGridViewReviews;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewUser;
        private System.Windows.Forms.GroupBox groupAddReview;
        private System.Windows.Forms.NumericUpDown numericRating;
        private System.Windows.Forms.Label lblYourRating;
        private System.Windows.Forms.RichTextBox richTextBoxReview;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.Label lblAnnotationTitle;
        private System.Windows.Forms.Label lblReviewsTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBoxCover = new PictureBox();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblGenre = new Label();
            lblYear = new Label();
            lblLanguage = new Label();
            lblType = new Label();
            lblRating = new Label();
            lblAvailability = new Label();
            lblAnnotationTitle = new Label();
            richTextBoxAnnotation = new RichTextBox();
            btnAddToBookmarks = new Button();
            btnRentBook = new Button();
            btnReadOnline = new Button();
            panelReservationCode = new Panel();
            lblReservationCode = new Label();
            lblReservationInfo = new Label();
            lblReviewsTitle = new Label();
            dataGridViewReviews = new DataGridView();
            colReviewRating = new DataGridViewTextBoxColumn();
            colReviewComment = new DataGridViewTextBoxColumn();
            colReviewDate = new DataGridViewTextBoxColumn();
            colReviewUser = new DataGridViewTextBoxColumn();
            groupAddReview = new GroupBox();
            lblYourRating = new Label();
            numericRating = new NumericUpDown();
            richTextBoxReview = new RichTextBox();
            btnAddReview = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).BeginInit();
            panelReservationCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviews).BeginInit();
            groupAddReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericRating).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCover
            // 
            pictureBoxCover.BackColor = Color.FromArgb(236, 240, 241);
            pictureBoxCover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCover.Location = new Point(23, 23);
            pictureBoxCover.Margin = new Padding(4, 3, 4, 3);
            pictureBoxCover.Name = "pictureBoxCover";
            pictureBoxCover.Size = new Size(210, 288);
            pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCover.TabIndex = 0;
            pictureBoxCover.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(257, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(105, 24);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Название";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Microsoft Sans Serif", 10F);
            lblAuthor.Location = new Point(257, 63);
            lblAuthor.Margin = new Padding(4, 0, 4, 0);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(51, 17);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Автор:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(257, 90);
            lblGenre.Margin = new Padding(4, 0, 4, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(41, 15);
            lblGenre.TabIndex = 3;
            lblGenre.Text = "Жанр:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(257, 111);
            lblYear.Margin = new Padding(4, 0, 4, 0);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(29, 15);
            lblYear.TabIndex = 4;
            lblYear.Text = "Год:";
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(257, 132);
            lblLanguage.Margin = new Padding(4, 0, 4, 0);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(37, 15);
            lblLanguage.TabIndex = 5;
            lblLanguage.Text = "Язык:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblType.Location = new Point(257, 156);
            lblType.Margin = new Padding(4, 0, 4, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(35, 15);
            lblType.TabIndex = 6;
            lblType.Text = "Тип:";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblRating.Location = new Point(257, 182);
            lblRating.Margin = new Padding(4, 0, 4, 0);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(73, 17);
            lblRating.TabIndex = 7;
            lblRating.Text = "Рейтинг:";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblAvailability.Location = new Point(257, 208);
            lblAvailability.Margin = new Padding(4, 0, 4, 0);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(80, 17);
            lblAvailability.TabIndex = 8;
            lblAvailability.Text = "Доступна";
            // 
            // lblAnnotationTitle
            // 
            lblAnnotationTitle.AutoSize = true;
            lblAnnotationTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblAnnotationTitle.Location = new Point(566, 335);
            lblAnnotationTitle.Margin = new Padding(4, 0, 4, 0);
            lblAnnotationTitle.Name = "lblAnnotationTitle";
            lblAnnotationTitle.Size = new Size(94, 17);
            lblAnnotationTitle.TabIndex = 4;
            lblAnnotationTitle.Text = "Аннотация:";
            // 
            // richTextBoxAnnotation
            // 
            richTextBoxAnnotation.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxAnnotation.Location = new Point(566, 363);
            richTextBoxAnnotation.Margin = new Padding(4, 3, 4, 3);
            richTextBoxAnnotation.Name = "richTextBoxAnnotation";
            richTextBoxAnnotation.ReadOnly = true;
            richTextBoxAnnotation.Size = new Size(390, 69);
            richTextBoxAnnotation.TabIndex = 3;
            richTextBoxAnnotation.Text = "";
            // 
            // btnAddToBookmarks
            // 
            btnAddToBookmarks.BackColor = Color.FromArgb(241, 196, 15);
            btnAddToBookmarks.FlatStyle = FlatStyle.Flat;
            btnAddToBookmarks.ForeColor = Color.White;
            btnAddToBookmarks.Location = new Point(257, 240);
            btnAddToBookmarks.Margin = new Padding(4, 3, 4, 3);
            btnAddToBookmarks.Name = "btnAddToBookmarks";
            btnAddToBookmarks.Size = new Size(140, 35);
            btnAddToBookmarks.TabIndex = 8;
            btnAddToBookmarks.Text = "🔖 В закладки";
            btnAddToBookmarks.UseVisualStyleBackColor = false;
            // 
            // btnRentBook
            // 
            btnRentBook.BackColor = Color.FromArgb(46, 204, 113);
            btnRentBook.FlatStyle = FlatStyle.Flat;
            btnRentBook.ForeColor = Color.White;
            btnRentBook.Location = new Point(408, 240);
            btnRentBook.Margin = new Padding(4, 3, 4, 3);
            btnRentBook.Name = "btnRentBook";
            btnRentBook.Size = new Size(233, 35);
            btnRentBook.TabIndex = 7;
            btnRentBook.Text = "📖 Забронировать";
            btnRentBook.UseVisualStyleBackColor = false;
            // 
            // btnReadOnline
            // 
            btnReadOnline.BackColor = Color.Gray;
            btnReadOnline.FlatStyle = FlatStyle.Flat;
            btnReadOnline.ForeColor = Color.White;
            btnReadOnline.Location = new Point(653, 240);
            btnReadOnline.Margin = new Padding(4, 3, 4, 3);
            btnReadOnline.Name = "btnReadOnline";
            btnReadOnline.Size = new Size(175, 35);
            btnReadOnline.TabIndex = 6;
            btnReadOnline.Text = "🔒 Читать";
            btnReadOnline.UseVisualStyleBackColor = false;
            btnReadOnline.Visible = false;
            // 
            // panelReservationCode
            // 
            panelReservationCode.BackColor = Color.FromArgb(46, 204, 113);
            panelReservationCode.Controls.Add(lblReservationCode);
            panelReservationCode.Controls.Add(lblReservationInfo);
            panelReservationCode.Location = new Point(257, 283);
            panelReservationCode.Margin = new Padding(4, 3, 4, 3);
            panelReservationCode.Name = "panelReservationCode";
            panelReservationCode.Size = new Size(572, 40);
            panelReservationCode.TabIndex = 5;
            panelReservationCode.Visible = false;
            // 
            // lblReservationCode
            // 
            lblReservationCode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblReservationCode.ForeColor = Color.White;
            lblReservationCode.Location = new Point(6, 6);
            lblReservationCode.Margin = new Padding(4, 0, 4, 0);
            lblReservationCode.Name = "lblReservationCode";
            lblReservationCode.Size = new Size(233, 29);
            lblReservationCode.TabIndex = 0;
            lblReservationCode.Text = "Код: XXXXXXXX";
            // 
            // lblReservationInfo
            // 
            lblReservationInfo.Font = new Font("Microsoft Sans Serif", 7F);
            lblReservationInfo.ForeColor = Color.White;
            lblReservationInfo.Location = new Point(245, 6);
            lblReservationInfo.Margin = new Padding(4, 0, 4, 0);
            lblReservationInfo.Name = "lblReservationInfo";
            lblReservationInfo.Size = new Size(321, 29);
            lblReservationInfo.TabIndex = 1;
            lblReservationInfo.Text = "Предъявите код библиотекарю";
            // 
            // lblReviewsTitle
            // 
            lblReviewsTitle.AutoSize = true;
            lblReviewsTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblReviewsTitle.Location = new Point(23, 335);
            lblReviewsTitle.Margin = new Padding(4, 0, 4, 0);
            lblReviewsTitle.Name = "lblReviewsTitle";
            lblReviewsTitle.Size = new Size(71, 17);
            lblReviewsTitle.TabIndex = 2;
            lblReviewsTitle.Text = "Отзывы:";
            // 
            // dataGridViewReviews
            // 
            dataGridViewReviews.AllowUserToAddRows = false;
            dataGridViewReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReviews.Columns.AddRange(new DataGridViewColumn[] { colReviewRating, colReviewComment, colReviewDate, colReviewUser });
            dataGridViewReviews.Location = new Point(23, 363);
            dataGridViewReviews.Margin = new Padding(4, 3, 4, 3);
            dataGridViewReviews.Name = "dataGridViewReviews";
            dataGridViewReviews.ReadOnly = true;
            dataGridViewReviews.Size = new Size(525, 219);
            dataGridViewReviews.TabIndex = 1;
            // 
            // colReviewRating
            // 
            colReviewRating.HeaderText = "Оценка";
            colReviewRating.Name = "colReviewRating";
            colReviewRating.ReadOnly = true;
            // 
            // colReviewComment
            // 
            colReviewComment.HeaderText = "Отзыв";
            colReviewComment.Name = "colReviewComment";
            colReviewComment.ReadOnly = true;
            // 
            // colReviewDate
            // 
            colReviewDate.HeaderText = "Дата";
            colReviewDate.Name = "colReviewDate";
            colReviewDate.ReadOnly = true;
            // 
            // colReviewUser
            // 
            colReviewUser.HeaderText = "Пользователь";
            colReviewUser.Name = "colReviewUser";
            colReviewUser.ReadOnly = true;
            // 
            // groupAddReview
            // 
            groupAddReview.Controls.Add(lblYourRating);
            groupAddReview.Controls.Add(numericRating);
            groupAddReview.Controls.Add(richTextBoxReview);
            groupAddReview.Controls.Add(btnAddReview);
            groupAddReview.Location = new Point(566, 444);
            groupAddReview.Margin = new Padding(4, 3, 4, 3);
            groupAddReview.Name = "groupAddReview";
            groupAddReview.Padding = new Padding(4, 3, 4, 3);
            groupAddReview.Size = new Size(391, 138);
            groupAddReview.TabIndex = 0;
            groupAddReview.TabStop = false;
            groupAddReview.Text = "Оставить отзыв";
            // 
            // lblYourRating
            // 
            lblYourRating.AutoSize = true;
            lblYourRating.Location = new Point(18, 29);
            lblYourRating.Margin = new Padding(4, 0, 4, 0);
            lblYourRating.Name = "lblYourRating";
            lblYourRating.Size = new Size(51, 15);
            lblYourRating.TabIndex = 0;
            lblYourRating.Text = "Оценка:";
            // 
            // numericRating
            // 
            numericRating.Location = new Point(93, 27);
            numericRating.Margin = new Padding(4, 3, 4, 3);
            numericRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericRating.Name = "numericRating";
            numericRating.Size = new Size(58, 23);
            numericRating.TabIndex = 1;
            numericRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // richTextBoxReview
            // 
            richTextBoxReview.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxReview.Location = new Point(18, 58);
            richTextBoxReview.Margin = new Padding(4, 3, 4, 3);
            richTextBoxReview.Name = "richTextBoxReview";
            richTextBoxReview.Size = new Size(355, 46);
            richTextBoxReview.TabIndex = 2;
            richTextBoxReview.Text = "";
            // 
            // btnAddReview
            // 
            btnAddReview.BackColor = Color.FromArgb(52, 152, 219);
            btnAddReview.FlatStyle = FlatStyle.Flat;
            btnAddReview.ForeColor = Color.White;
            btnAddReview.Location = new Point(93, 110);
            btnAddReview.Margin = new Padding(4, 3, 4, 3);
            btnAddReview.Name = "btnAddReview";
            btnAddReview.Size = new Size(198, 29);
            btnAddReview.TabIndex = 3;
            btnAddReview.Text = "Отправить";
            btnAddReview.UseVisualStyleBackColor = false;
            // 
            // BookDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 600);
            Controls.Add(groupAddReview);
            Controls.Add(dataGridViewReviews);
            Controls.Add(lblReviewsTitle);
            Controls.Add(richTextBoxAnnotation);
            Controls.Add(lblAnnotationTitle);
            Controls.Add(panelReservationCode);
            Controls.Add(btnReadOnline);
            Controls.Add(btnRentBook);
            Controls.Add(btnAddToBookmarks);
            Controls.Add(lblAvailability);
            Controls.Add(lblRating);
            Controls.Add(lblType);
            Controls.Add(lblLanguage);
            Controls.Add(lblYear);
            Controls.Add(lblGenre);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxCover);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "BookDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Информация о книге";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).EndInit();
            panelReservationCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviews).EndInit();
            groupAddReview.ResumeLayout(false);
            groupAddReview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
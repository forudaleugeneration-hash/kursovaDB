namespace LibraryApp.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.Label lblLoanedBooksTitle;
        private System.Windows.Forms.DataGridView dataGridViewLoanedBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanCode;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnCancelReservation;
        private System.Windows.Forms.Label lblBookmarksTitle;
        private System.Windows.Forms.DataGridView dataGridViewBookmarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookmarkTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookmarkAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookmarkGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookmarkRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookmarkDate;
        private System.Windows.Forms.Button btnRemoveBookmark;
        private System.Windows.Forms.Label lblReadHistoryTitle;
        private System.Windows.Forms.DataGridView dataGridViewReadHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryRating;
        private System.Windows.Forms.Button btnClearHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUserName = new Label();
            lblEmail = new Label();
            lblRegistrationDate = new Label();
            lblLoanedBooksTitle = new Label();
            dataGridViewLoanedBooks = new DataGridView();
            colLoanDate = new DataGridViewTextBoxColumn();
            colLoanDueDate = new DataGridViewTextBoxColumn();
            colLoanTitle = new DataGridViewTextBoxColumn();
            colLoanAuthor = new DataGridViewTextBoxColumn();
            colLoanStatus = new DataGridViewTextBoxColumn();
            colLoanCode = new DataGridViewTextBoxColumn();
            btnReturnBook = new Button();
            btnCancelReservation = new Button();
            lblBookmarksTitle = new Label();
            dataGridViewBookmarks = new DataGridView();
            colBookmarkTitle = new DataGridViewTextBoxColumn();
            colBookmarkAuthor = new DataGridViewTextBoxColumn();
            colBookmarkGenre = new DataGridViewTextBoxColumn();
            colBookmarkRating = new DataGridViewTextBoxColumn();
            colBookmarkDate = new DataGridViewTextBoxColumn();
            btnRemoveBookmark = new Button();
            lblReadHistoryTitle = new Label();
            dataGridViewReadHistory = new DataGridView();
            colHistoryDate = new DataGridViewTextBoxColumn();
            colHistoryTitle = new DataGridViewTextBoxColumn();
            colHistoryAuthor = new DataGridViewTextBoxColumn();
            colHistoryRating = new DataGridViewTextBoxColumn();
            btnClearHistory = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoanedBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookmarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReadHistory).BeginInit();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblUserName.Location = new Point(23, 23);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(0, 24);
            lblUserName.TabIndex = 12;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(23, 63);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(0, 15);
            lblEmail.TabIndex = 11;
            // 
            // lblRegistrationDate
            // 
            lblRegistrationDate.AutoSize = true;
            lblRegistrationDate.Location = new Point(23, 87);
            lblRegistrationDate.Margin = new Padding(4, 0, 4, 0);
            lblRegistrationDate.Name = "lblRegistrationDate";
            lblRegistrationDate.Size = new Size(0, 15);
            lblRegistrationDate.TabIndex = 10;
            // 
            // lblLoanedBooksTitle
            // 
            lblLoanedBooksTitle.AutoSize = true;
            lblLoanedBooksTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblLoanedBooksTitle.Location = new Point(23, 121);
            lblLoanedBooksTitle.Margin = new Padding(4, 0, 4, 0);
            lblLoanedBooksTitle.Name = "lblLoanedBooksTitle";
            lblLoanedBooksTitle.Size = new Size(89, 17);
            lblLoanedBooksTitle.TabIndex = 9;
            lblLoanedBooksTitle.Text = "Мои книги:";
            // 
            // dataGridViewLoanedBooks
            // 
            dataGridViewLoanedBooks.AllowUserToAddRows = false;
            dataGridViewLoanedBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLoanedBooks.Columns.AddRange(new DataGridViewColumn[] { colLoanDate, colLoanDueDate, colLoanTitle, colLoanAuthor, colLoanStatus, colLoanCode });
            dataGridViewLoanedBooks.Location = new Point(23, 150);
            dataGridViewLoanedBooks.Margin = new Padding(4, 3, 4, 3);
            dataGridViewLoanedBooks.Name = "dataGridViewLoanedBooks";
            dataGridViewLoanedBooks.ReadOnly = true;
            dataGridViewLoanedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLoanedBooks.Size = new Size(863, 127);
            dataGridViewLoanedBooks.TabIndex = 8;
            // 
            // colLoanDate
            // 
            colLoanDate.HeaderText = "Дата";
            colLoanDate.Name = "colLoanDate";
            colLoanDate.ReadOnly = true;
            // 
            // colLoanDueDate
            // 
            colLoanDueDate.HeaderText = "Вернуть до";
            colLoanDueDate.Name = "colLoanDueDate";
            colLoanDueDate.ReadOnly = true;
            // 
            // colLoanTitle
            // 
            colLoanTitle.HeaderText = "Книга";
            colLoanTitle.Name = "colLoanTitle";
            colLoanTitle.ReadOnly = true;
            // 
            // colLoanAuthor
            // 
            colLoanAuthor.HeaderText = "Автор";
            colLoanAuthor.Name = "colLoanAuthor";
            colLoanAuthor.ReadOnly = true;
            // 
            // colLoanStatus
            // 
            colLoanStatus.HeaderText = "Статус";
            colLoanStatus.Name = "colLoanStatus";
            colLoanStatus.ReadOnly = true;
            // 
            // colLoanCode
            // 
            colLoanCode.HeaderText = "Код";
            colLoanCode.Name = "colLoanCode";
            colLoanCode.ReadOnly = true;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.FromArgb(231, 76, 60);
            btnReturnBook.FlatStyle = FlatStyle.Flat;
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(898, 150);
            btnReturnBook.Margin = new Padding(4, 3, 4, 3);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(117, 58);
            btnReturnBook.TabIndex = 7;
            btnReturnBook.Text = "Вернуть";
            btnReturnBook.UseVisualStyleBackColor = false;
            // 
            // btnCancelReservation
            // 
            btnCancelReservation.BackColor = Color.FromArgb(230, 126, 34);
            btnCancelReservation.FlatStyle = FlatStyle.Flat;
            btnCancelReservation.ForeColor = Color.White;
            btnCancelReservation.Location = new Point(898, 213);
            btnCancelReservation.Margin = new Padding(4, 3, 4, 3);
            btnCancelReservation.Name = "btnCancelReservation";
            btnCancelReservation.Size = new Size(117, 58);
            btnCancelReservation.TabIndex = 6;
            btnCancelReservation.Text = "Отменить бронь";
            btnCancelReservation.UseVisualStyleBackColor = false;
            btnCancelReservation.Visible = false;
            // 
            // lblBookmarksTitle
            // 
            lblBookmarksTitle.AutoSize = true;
            lblBookmarksTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblBookmarksTitle.Location = new Point(23, 294);
            lblBookmarksTitle.Margin = new Padding(4, 0, 4, 0);
            lblBookmarksTitle.Name = "lblBookmarksTitle";
            lblBookmarksTitle.Size = new Size(84, 17);
            lblBookmarksTitle.TabIndex = 5;
            lblBookmarksTitle.Text = "Закладки:";
            // 
            // dataGridViewBookmarks
            // 
            dataGridViewBookmarks.AllowUserToAddRows = false;
            dataGridViewBookmarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBookmarks.Columns.AddRange(new DataGridViewColumn[] { colBookmarkTitle, colBookmarkAuthor, colBookmarkGenre, colBookmarkRating, colBookmarkDate });
            dataGridViewBookmarks.Location = new Point(23, 323);
            dataGridViewBookmarks.Margin = new Padding(4, 3, 4, 3);
            dataGridViewBookmarks.Name = "dataGridViewBookmarks";
            dataGridViewBookmarks.ReadOnly = true;
            dataGridViewBookmarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBookmarks.Size = new Size(863, 127);
            dataGridViewBookmarks.TabIndex = 4;
            // 
            // colBookmarkTitle
            // 
            colBookmarkTitle.HeaderText = "Книга";
            colBookmarkTitle.Name = "colBookmarkTitle";
            colBookmarkTitle.ReadOnly = true;
            // 
            // colBookmarkAuthor
            // 
            colBookmarkAuthor.HeaderText = "Автор";
            colBookmarkAuthor.Name = "colBookmarkAuthor";
            colBookmarkAuthor.ReadOnly = true;
            // 
            // colBookmarkGenre
            // 
            colBookmarkGenre.HeaderText = "Жанр";
            colBookmarkGenre.Name = "colBookmarkGenre";
            colBookmarkGenre.ReadOnly = true;
            // 
            // colBookmarkRating
            // 
            colBookmarkRating.HeaderText = "Рейтинг";
            colBookmarkRating.Name = "colBookmarkRating";
            colBookmarkRating.ReadOnly = true;
            // 
            // colBookmarkDate
            // 
            colBookmarkDate.HeaderText = "Добавлено";
            colBookmarkDate.Name = "colBookmarkDate";
            colBookmarkDate.ReadOnly = true;
            // 
            // btnRemoveBookmark
            // 
            btnRemoveBookmark.BackColor = Color.FromArgb(241, 196, 15);
            btnRemoveBookmark.FlatStyle = FlatStyle.Flat;
            btnRemoveBookmark.ForeColor = Color.White;
            btnRemoveBookmark.Location = new Point(898, 360);
            btnRemoveBookmark.Margin = new Padding(4, 3, 4, 3);
            btnRemoveBookmark.Name = "btnRemoveBookmark";
            btnRemoveBookmark.Size = new Size(117, 64);
            btnRemoveBookmark.TabIndex = 3;
            btnRemoveBookmark.Text = "Убрать";
            btnRemoveBookmark.UseVisualStyleBackColor = false;
            // 
            // lblReadHistoryTitle
            // 
            lblReadHistoryTitle.AutoSize = true;
            lblReadHistoryTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblReadHistoryTitle.Location = new Point(23, 467);
            lblReadHistoryTitle.Margin = new Padding(4, 0, 4, 0);
            lblReadHistoryTitle.Name = "lblReadHistoryTitle";
            lblReadHistoryTitle.Size = new Size(76, 17);
            lblReadHistoryTitle.TabIndex = 2;
            lblReadHistoryTitle.Text = "История:";
            // 
            // dataGridViewReadHistory
            // 
            dataGridViewReadHistory.AllowUserToAddRows = false;
            dataGridViewReadHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReadHistory.Columns.AddRange(new DataGridViewColumn[] { colHistoryDate, colHistoryTitle, colHistoryAuthor, colHistoryRating });
            dataGridViewReadHistory.Location = new Point(23, 496);
            dataGridViewReadHistory.Margin = new Padding(4, 3, 4, 3);
            dataGridViewReadHistory.Name = "dataGridViewReadHistory";
            dataGridViewReadHistory.ReadOnly = true;
            dataGridViewReadHistory.Size = new Size(863, 173);
            dataGridViewReadHistory.TabIndex = 1;
            // 
            // colHistoryDate
            // 
            colHistoryDate.HeaderText = "Дата прочтения";
            colHistoryDate.Name = "colHistoryDate";
            colHistoryDate.ReadOnly = true;
            // 
            // colHistoryTitle
            // 
            colHistoryTitle.HeaderText = "Книга";
            colHistoryTitle.Name = "colHistoryTitle";
            colHistoryTitle.ReadOnly = true;
            // 
            // colHistoryAuthor
            // 
            colHistoryAuthor.HeaderText = "Автор";
            colHistoryAuthor.Name = "colHistoryAuthor";
            colHistoryAuthor.ReadOnly = true;
            // 
            // colHistoryRating
            // 
            colHistoryRating.HeaderText = "Рейтинг";
            colHistoryRating.Name = "colHistoryRating";
            colHistoryRating.ReadOnly = true;
            // 
            // btnClearHistory
            // 
            btnClearHistory.BackColor = Color.FromArgb(149, 165, 166);
            btnClearHistory.FlatStyle = FlatStyle.Flat;
            btnClearHistory.ForeColor = Color.White;
            btnClearHistory.Location = new Point(898, 554);
            btnClearHistory.Margin = new Padding(4, 3, 4, 3);
            btnClearHistory.Name = "btnClearHistory";
            btnClearHistory.Size = new Size(117, 58);
            btnClearHistory.TabIndex = 0;
            btnClearHistory.Text = "Очистить историю";
            btnClearHistory.UseVisualStyleBackColor = false;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 692);
            Controls.Add(btnClearHistory);
            Controls.Add(dataGridViewReadHistory);
            Controls.Add(lblReadHistoryTitle);
            Controls.Add(btnRemoveBookmark);
            Controls.Add(dataGridViewBookmarks);
            Controls.Add(lblBookmarksTitle);
            Controls.Add(btnCancelReservation);
            Controls.Add(btnReturnBook);
            Controls.Add(dataGridViewLoanedBooks);
            Controls.Add(lblLoanedBooksTitle);
            Controls.Add(lblRegistrationDate);
            Controls.Add(lblEmail);
            Controls.Add(lblUserName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Личный кабинет";
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoanedBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookmarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReadHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
namespace LibraryApp.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabAuthors;
        private System.Windows.Forms.TabPage tabGenres;
        private System.Windows.Forms.TabPage tabPickups;
        private System.Windows.Forms.Label lblAdminInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoansCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewsCount;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnToggleActive;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.DataGridView dataGridViewAuthors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthorBookCount;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Button btnEditAuthor;
        private System.Windows.Forms.Button btnDeleteAuthor;
        private System.Windows.Forms.DataGridView dataGridViewGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenreBookCount;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Button btnEditGenre;
        private System.Windows.Forms.Button btnDeleteGenre;
        private System.Windows.Forms.DataGridView dataGridViewPickups;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReservationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibrarian;
        private System.Windows.Forms.TextBox textBoxReservationCode;
        private System.Windows.Forms.Button btnVerifyCode;
        private System.Windows.Forms.Button btnConfirmPickup;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnCancelReservationAdmin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabUsers = new TabPage();
            btnEditUser = new Button();
            btnToggleActive = new Button();
            btnDeleteUser = new Button();
            dataGridViewUsers = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colActive = new DataGridViewTextBoxColumn();
            colRegDate = new DataGridViewTextBoxColumn();
            colLoansCount = new DataGridViewTextBoxColumn();
            colReviewsCount = new DataGridViewTextBoxColumn();
            tabBooks = new TabPage();
            btnAddBook = new Button();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            dataGridViewBooks = new DataGridView();
            tabAuthors = new TabPage();
            btnAddAuthor = new Button();
            btnEditAuthor = new Button();
            btnDeleteAuthor = new Button();
            dataGridViewAuthors = new DataGridView();
            colAuthorId = new DataGridViewTextBoxColumn();
            colAuthorName = new DataGridViewTextBoxColumn();
            colAuthorBookCount = new DataGridViewTextBoxColumn();
            tabGenres = new TabPage();
            btnAddGenre = new Button();
            btnEditGenre = new Button();
            btnDeleteGenre = new Button();
            dataGridViewGenres = new DataGridView();
            colGenreId = new DataGridViewTextBoxColumn();
            colGenreName = new DataGridViewTextBoxColumn();
            colGenreBookCount = new DataGridViewTextBoxColumn();
            tabPickups = new TabPage();
            lblCode = new Label();
            textBoxReservationCode = new TextBox();
            btnVerifyCode = new Button();
            btnConfirmPickup = new Button();
            btnReturnBook = new Button();
            btnCancelReservationAdmin = new Button();
            dataGridViewPickups = new DataGridView();
            colPickupId = new DataGridViewTextBoxColumn();
            colReservationCode = new DataGridViewTextBoxColumn();
            colPickupBook = new DataGridViewTextBoxColumn();
            colPickupUser = new DataGridViewTextBoxColumn();
            colPickupDate = new DataGridViewTextBoxColumn();
            colPickupStatus = new DataGridViewTextBoxColumn();
            colPickupActual = new DataGridViewTextBoxColumn();
            colLibrarian = new DataGridViewTextBoxColumn();
            lblAdminInfo = new Label();
            btnRefresh = new Button();
            colBookId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colYear = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colRating = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colCopies = new DataGridViewTextBoxColumn();
            colIsNew = new DataGridViewTextBoxColumn();
            colIsHit = new DataGridViewTextBoxColumn();
            colBookLoans = new DataGridViewTextBoxColumn();
            colBookReviews = new DataGridViewTextBoxColumn();
            tabControl.SuspendLayout();
            tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            tabAuthors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuthors).BeginInit();
            tabGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGenres).BeginInit();
            tabPickups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPickups).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabUsers);
            tabControl.Controls.Add(tabBooks);
            tabControl.Controls.Add(tabAuthors);
            tabControl.Controls.Add(tabGenres);
            tabControl.Controls.Add(tabPickups);
            tabControl.Location = new Point(6, 52);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1254, 704);
            tabControl.TabIndex = 2;
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(btnEditUser);
            tabUsers.Controls.Add(btnToggleActive);
            tabUsers.Controls.Add(btnDeleteUser);
            tabUsers.Controls.Add(dataGridViewUsers);
            tabUsers.Location = new Point(4, 24);
            tabUsers.Margin = new Padding(4, 3, 4, 3);
            tabUsers.Name = "tabUsers";
            tabUsers.Size = new Size(1246, 676);
            tabUsers.TabIndex = 0;
            tabUsers.Text = "Пользователи";
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.FromArgb(52, 152, 219);
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(12, 12);
            btnEditUser.Margin = new Padding(4, 3, 4, 3);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(163, 32);
            btnEditUser.TabIndex = 0;
            btnEditUser.Text = "Изменить роль";
            btnEditUser.UseVisualStyleBackColor = false;
            // 
            // btnToggleActive
            // 
            btnToggleActive.BackColor = Color.FromArgb(241, 196, 15);
            btnToggleActive.FlatStyle = FlatStyle.Flat;
            btnToggleActive.ForeColor = Color.White;
            btnToggleActive.Location = new Point(187, 12);
            btnToggleActive.Margin = new Padding(4, 3, 4, 3);
            btnToggleActive.Name = "btnToggleActive";
            btnToggleActive.Size = new Size(210, 32);
            btnToggleActive.TabIndex = 1;
            btnToggleActive.Text = "Блокировать / Разблокировать";
            btnToggleActive.UseVisualStyleBackColor = false;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(408, 12);
            btnDeleteUser.Margin = new Padding(4, 3, 4, 3);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(163, 32);
            btnDeleteUser.TabIndex = 2;
            btnDeleteUser.Text = "Удалить";
            btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.Columns.AddRange(new DataGridViewColumn[] { colUserId, colUsername, colEmail, colFullName, colRole, colActive, colRegDate, colLoansCount, colReviewsCount });
            dataGridViewUsers.Location = new Point(12, 58);
            dataGridViewUsers.Margin = new Padding(4, 3, 4, 3);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(1213, 600);
            dataGridViewUsers.TabIndex = 3;
            // 
            // colUserId
            // 
            colUserId.HeaderText = "ID";
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;
            colUserId.Visible = false;
            // 
            // colUsername
            // 
            colUsername.HeaderText = "Логин";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Имя";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colRole
            // 
            colRole.HeaderText = "Роль";
            colRole.Name = "colRole";
            colRole.ReadOnly = true;
            // 
            // colActive
            // 
            colActive.HeaderText = "Активен";
            colActive.Name = "colActive";
            colActive.ReadOnly = true;
            // 
            // colRegDate
            // 
            colRegDate.HeaderText = "Регистрация";
            colRegDate.Name = "colRegDate";
            colRegDate.ReadOnly = true;
            // 
            // colLoansCount
            // 
            colLoansCount.HeaderText = "Книг на руках";
            colLoansCount.Name = "colLoansCount";
            colLoansCount.ReadOnly = true;
            // 
            // colReviewsCount
            // 
            colReviewsCount.HeaderText = "Отзывов";
            colReviewsCount.Name = "colReviewsCount";
            colReviewsCount.ReadOnly = true;
            // 
            // tabBooks
            // 
            tabBooks.Controls.Add(btnAddBook);
            tabBooks.Controls.Add(btnEditBook);
            tabBooks.Controls.Add(btnDeleteBook);
            tabBooks.Controls.Add(dataGridViewBooks);
            tabBooks.Location = new Point(4, 24);
            tabBooks.Margin = new Padding(4, 3, 4, 3);
            tabBooks.Name = "tabBooks";
            tabBooks.Size = new Size(1246, 676);
            tabBooks.TabIndex = 1;
            tabBooks.Text = "Книги";
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.FromArgb(46, 204, 113);
            btnAddBook.FlatStyle = FlatStyle.Flat;
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(12, 12);
            btnAddBook.Margin = new Padding(4, 3, 4, 3);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(163, 32);
            btnAddBook.TabIndex = 0;
            btnAddBook.Text = "Добавить книгу";
            btnAddBook.UseVisualStyleBackColor = false;
            // 
            // btnEditBook
            // 
            btnEditBook.BackColor = Color.FromArgb(52, 152, 219);
            btnEditBook.FlatStyle = FlatStyle.Flat;
            btnEditBook.ForeColor = Color.White;
            btnEditBook.Location = new Point(187, 12);
            btnEditBook.Margin = new Padding(4, 3, 4, 3);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(163, 32);
            btnEditBook.TabIndex = 1;
            btnEditBook.Text = "Редактировать";
            btnEditBook.UseVisualStyleBackColor = false;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteBook.FlatStyle = FlatStyle.Flat;
            btnDeleteBook.ForeColor = Color.White;
            btnDeleteBook.Location = new Point(362, 12);
            btnDeleteBook.Margin = new Padding(4, 3, 4, 3);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(163, 32);
            btnDeleteBook.TabIndex = 2;
            btnDeleteBook.Text = "Удалить";
            btnDeleteBook.UseVisualStyleBackColor = false;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.AllowUserToAddRows = false;
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBooks.Columns.AddRange(new DataGridViewColumn[] { colBookId, colTitle, colAuthor, colYear, colGenre, colType, colRating, colStatus, colCopies, colIsNew, colIsHit, colBookLoans, colBookReviews });
            dataGridViewBooks.Location = new Point(12, 58);
            dataGridViewBooks.Margin = new Padding(4, 3, 4, 3);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(1213, 600);
            dataGridViewBooks.TabIndex = 3;
            dataGridViewBooks.CellContentClick += dataGridViewBooks_CellContentClick;
            // 
            // tabAuthors
            // 
            tabAuthors.Controls.Add(btnAddAuthor);
            tabAuthors.Controls.Add(btnEditAuthor);
            tabAuthors.Controls.Add(btnDeleteAuthor);
            tabAuthors.Controls.Add(dataGridViewAuthors);
            tabAuthors.Location = new Point(4, 24);
            tabAuthors.Margin = new Padding(4, 3, 4, 3);
            tabAuthors.Name = "tabAuthors";
            tabAuthors.Size = new Size(1246, 676);
            tabAuthors.TabIndex = 2;
            tabAuthors.Text = "Авторы";
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.BackColor = Color.FromArgb(46, 204, 113);
            btnAddAuthor.FlatStyle = FlatStyle.Flat;
            btnAddAuthor.ForeColor = Color.White;
            btnAddAuthor.Location = new Point(12, 12);
            btnAddAuthor.Margin = new Padding(4, 3, 4, 3);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(163, 32);
            btnAddAuthor.TabIndex = 0;
            btnAddAuthor.Text = "Добавить автора";
            btnAddAuthor.UseVisualStyleBackColor = false;
            // 
            // btnEditAuthor
            // 
            btnEditAuthor.BackColor = Color.FromArgb(52, 152, 219);
            btnEditAuthor.FlatStyle = FlatStyle.Flat;
            btnEditAuthor.ForeColor = Color.White;
            btnEditAuthor.Location = new Point(187, 12);
            btnEditAuthor.Margin = new Padding(4, 3, 4, 3);
            btnEditAuthor.Name = "btnEditAuthor";
            btnEditAuthor.Size = new Size(163, 32);
            btnEditAuthor.TabIndex = 1;
            btnEditAuthor.Text = "Редактировать";
            btnEditAuthor.UseVisualStyleBackColor = false;
            // 
            // btnDeleteAuthor
            // 
            btnDeleteAuthor.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteAuthor.FlatStyle = FlatStyle.Flat;
            btnDeleteAuthor.ForeColor = Color.White;
            btnDeleteAuthor.Location = new Point(362, 12);
            btnDeleteAuthor.Margin = new Padding(4, 3, 4, 3);
            btnDeleteAuthor.Name = "btnDeleteAuthor";
            btnDeleteAuthor.Size = new Size(163, 32);
            btnDeleteAuthor.TabIndex = 2;
            btnDeleteAuthor.Text = "Удалить";
            btnDeleteAuthor.UseVisualStyleBackColor = false;
            // 
            // dataGridViewAuthors
            // 
            dataGridViewAuthors.AllowUserToAddRows = false;
            dataGridViewAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAuthors.Columns.AddRange(new DataGridViewColumn[] { colAuthorId, colAuthorName, colAuthorBookCount });
            dataGridViewAuthors.Location = new Point(12, 58);
            dataGridViewAuthors.Margin = new Padding(4, 3, 4, 3);
            dataGridViewAuthors.Name = "dataGridViewAuthors";
            dataGridViewAuthors.ReadOnly = true;
            dataGridViewAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAuthors.Size = new Size(1213, 600);
            dataGridViewAuthors.TabIndex = 3;
            // 
            // colAuthorId
            // 
            colAuthorId.HeaderText = "ID";
            colAuthorId.Name = "colAuthorId";
            colAuthorId.ReadOnly = true;
            colAuthorId.Visible = false;
            // 
            // colAuthorName
            // 
            colAuthorName.HeaderText = "Автор";
            colAuthorName.Name = "colAuthorName";
            colAuthorName.ReadOnly = true;
            // 
            // colAuthorBookCount
            // 
            colAuthorBookCount.HeaderText = "Книг";
            colAuthorBookCount.Name = "colAuthorBookCount";
            colAuthorBookCount.ReadOnly = true;
            // 
            // tabGenres
            // 
            tabGenres.Controls.Add(btnAddGenre);
            tabGenres.Controls.Add(btnEditGenre);
            tabGenres.Controls.Add(btnDeleteGenre);
            tabGenres.Controls.Add(dataGridViewGenres);
            tabGenres.Location = new Point(4, 24);
            tabGenres.Margin = new Padding(4, 3, 4, 3);
            tabGenres.Name = "tabGenres";
            tabGenres.Size = new Size(1246, 676);
            tabGenres.TabIndex = 3;
            tabGenres.Text = "Жанры";
            // 
            // btnAddGenre
            // 
            btnAddGenre.BackColor = Color.FromArgb(46, 204, 113);
            btnAddGenre.FlatStyle = FlatStyle.Flat;
            btnAddGenre.ForeColor = Color.White;
            btnAddGenre.Location = new Point(12, 12);
            btnAddGenre.Margin = new Padding(4, 3, 4, 3);
            btnAddGenre.Name = "btnAddGenre";
            btnAddGenre.Size = new Size(163, 32);
            btnAddGenre.TabIndex = 0;
            btnAddGenre.Text = "Добавить жанр";
            btnAddGenre.UseVisualStyleBackColor = false;
            // 
            // btnEditGenre
            // 
            btnEditGenre.BackColor = Color.FromArgb(52, 152, 219);
            btnEditGenre.FlatStyle = FlatStyle.Flat;
            btnEditGenre.ForeColor = Color.White;
            btnEditGenre.Location = new Point(187, 12);
            btnEditGenre.Margin = new Padding(4, 3, 4, 3);
            btnEditGenre.Name = "btnEditGenre";
            btnEditGenre.Size = new Size(163, 32);
            btnEditGenre.TabIndex = 1;
            btnEditGenre.Text = "Редактировать";
            btnEditGenre.UseVisualStyleBackColor = false;
            // 
            // btnDeleteGenre
            // 
            btnDeleteGenre.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteGenre.FlatStyle = FlatStyle.Flat;
            btnDeleteGenre.ForeColor = Color.White;
            btnDeleteGenre.Location = new Point(362, 12);
            btnDeleteGenre.Margin = new Padding(4, 3, 4, 3);
            btnDeleteGenre.Name = "btnDeleteGenre";
            btnDeleteGenre.Size = new Size(163, 32);
            btnDeleteGenre.TabIndex = 2;
            btnDeleteGenre.Text = "Удалить";
            btnDeleteGenre.UseVisualStyleBackColor = false;
            // 
            // dataGridViewGenres
            // 
            dataGridViewGenres.AllowUserToAddRows = false;
            dataGridViewGenres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGenres.Columns.AddRange(new DataGridViewColumn[] { colGenreId, colGenreName, colGenreBookCount });
            dataGridViewGenres.Location = new Point(12, 58);
            dataGridViewGenres.Margin = new Padding(4, 3, 4, 3);
            dataGridViewGenres.Name = "dataGridViewGenres";
            dataGridViewGenres.ReadOnly = true;
            dataGridViewGenres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGenres.Size = new Size(1213, 600);
            dataGridViewGenres.TabIndex = 3;
            // 
            // colGenreId
            // 
            colGenreId.HeaderText = "ID";
            colGenreId.Name = "colGenreId";
            colGenreId.ReadOnly = true;
            colGenreId.Visible = false;
            // 
            // colGenreName
            // 
            colGenreName.HeaderText = "Жанр";
            colGenreName.Name = "colGenreName";
            colGenreName.ReadOnly = true;
            // 
            // colGenreBookCount
            // 
            colGenreBookCount.HeaderText = "Книг";
            colGenreBookCount.Name = "colGenreBookCount";
            colGenreBookCount.ReadOnly = true;
            // 
            // tabPickups
            // 
            tabPickups.Controls.Add(lblCode);
            tabPickups.Controls.Add(textBoxReservationCode);
            tabPickups.Controls.Add(btnVerifyCode);
            tabPickups.Controls.Add(btnConfirmPickup);
            tabPickups.Controls.Add(btnReturnBook);
            tabPickups.Controls.Add(btnCancelReservationAdmin);
            tabPickups.Controls.Add(dataGridViewPickups);
            tabPickups.Location = new Point(4, 24);
            tabPickups.Margin = new Padding(4, 3, 4, 3);
            tabPickups.Name = "tabPickups";
            tabPickups.Size = new Size(1246, 676);
            tabPickups.TabIndex = 4;
            tabPickups.Text = "Выдача книг";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(12, 15);
            lblCode.Margin = new Padding(4, 0, 4, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(30, 15);
            lblCode.TabIndex = 0;
            lblCode.Text = "Код:";
            // 
            // textBoxReservationCode
            // 
            textBoxReservationCode.CharacterCasing = CharacterCasing.Upper;
            textBoxReservationCode.Location = new Point(58, 12);
            textBoxReservationCode.Margin = new Padding(4, 3, 4, 3);
            textBoxReservationCode.MaxLength = 8;
            textBoxReservationCode.Name = "textBoxReservationCode";
            textBoxReservationCode.Size = new Size(139, 23);
            textBoxReservationCode.TabIndex = 1;
            // 
            // btnVerifyCode
            // 
            btnVerifyCode.BackColor = Color.FromArgb(52, 152, 219);
            btnVerifyCode.FlatStyle = FlatStyle.Flat;
            btnVerifyCode.ForeColor = Color.White;
            btnVerifyCode.Location = new Point(210, 9);
            btnVerifyCode.Margin = new Padding(4, 3, 4, 3);
            btnVerifyCode.Name = "btnVerifyCode";
            btnVerifyCode.Size = new Size(117, 32);
            btnVerifyCode.TabIndex = 2;
            btnVerifyCode.Text = "Проверить";
            btnVerifyCode.UseVisualStyleBackColor = false;
            // 
            // btnConfirmPickup
            // 
            btnConfirmPickup.BackColor = Color.FromArgb(46, 204, 113);
            btnConfirmPickup.FlatStyle = FlatStyle.Flat;
            btnConfirmPickup.ForeColor = Color.White;
            btnConfirmPickup.Location = new Point(338, 9);
            btnConfirmPickup.Margin = new Padding(4, 3, 4, 3);
            btnConfirmPickup.Name = "btnConfirmPickup";
            btnConfirmPickup.Size = new Size(117, 32);
            btnConfirmPickup.TabIndex = 3;
            btnConfirmPickup.Text = "Выдать";
            btnConfirmPickup.UseVisualStyleBackColor = false;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.FromArgb(231, 76, 60);
            btnReturnBook.FlatStyle = FlatStyle.Flat;
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(467, 9);
            btnReturnBook.Margin = new Padding(4, 3, 4, 3);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(117, 32);
            btnReturnBook.TabIndex = 4;
            btnReturnBook.Text = "Возврат";
            btnReturnBook.UseVisualStyleBackColor = false;
            // 
            // btnCancelReservationAdmin
            // 
            btnCancelReservationAdmin.BackColor = Color.FromArgb(230, 126, 34);
            btnCancelReservationAdmin.FlatStyle = FlatStyle.Flat;
            btnCancelReservationAdmin.ForeColor = Color.White;
            btnCancelReservationAdmin.Location = new Point(595, 9);
            btnCancelReservationAdmin.Margin = new Padding(4, 3, 4, 3);
            btnCancelReservationAdmin.Name = "btnCancelReservationAdmin";
            btnCancelReservationAdmin.Size = new Size(140, 32);
            btnCancelReservationAdmin.TabIndex = 5;
            btnCancelReservationAdmin.Text = "Отменить бронь";
            btnCancelReservationAdmin.UseVisualStyleBackColor = false;
            // 
            // dataGridViewPickups
            // 
            dataGridViewPickups.AllowUserToAddRows = false;
            dataGridViewPickups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPickups.Columns.AddRange(new DataGridViewColumn[] { colPickupId, colReservationCode, colPickupBook, colPickupUser, colPickupDate, colPickupStatus, colPickupActual, colLibrarian });
            dataGridViewPickups.Location = new Point(12, 58);
            dataGridViewPickups.Margin = new Padding(4, 3, 4, 3);
            dataGridViewPickups.Name = "dataGridViewPickups";
            dataGridViewPickups.ReadOnly = true;
            dataGridViewPickups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPickups.Size = new Size(1213, 600);
            dataGridViewPickups.TabIndex = 6;
            // 
            // colPickupId
            // 
            colPickupId.HeaderText = "ID";
            colPickupId.Name = "colPickupId";
            colPickupId.ReadOnly = true;
            colPickupId.Visible = false;
            // 
            // colReservationCode
            // 
            colReservationCode.HeaderText = "Код";
            colReservationCode.Name = "colReservationCode";
            colReservationCode.ReadOnly = true;
            // 
            // colPickupBook
            // 
            colPickupBook.HeaderText = "Книга";
            colPickupBook.Name = "colPickupBook";
            colPickupBook.ReadOnly = true;
            // 
            // colPickupUser
            // 
            colPickupUser.HeaderText = "Пользователь";
            colPickupUser.Name = "colPickupUser";
            colPickupUser.ReadOnly = true;
            // 
            // colPickupDate
            // 
            colPickupDate.HeaderText = "Бронирование";
            colPickupDate.Name = "colPickupDate";
            colPickupDate.ReadOnly = true;
            // 
            // colPickupStatus
            // 
            colPickupStatus.HeaderText = "Статус";
            colPickupStatus.Name = "colPickupStatus";
            colPickupStatus.ReadOnly = true;
            // 
            // colPickupActual
            // 
            colPickupActual.HeaderText = "Выдача";
            colPickupActual.Name = "colPickupActual";
            colPickupActual.ReadOnly = true;
            // 
            // colLibrarian
            // 
            colLibrarian.HeaderText = "Библиотекарь";
            colLibrarian.Name = "colLibrarian";
            colLibrarian.ReadOnly = true;
            // 
            // lblAdminInfo
            // 
            lblAdminInfo.AutoSize = true;
            lblAdminInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblAdminInfo.ForeColor = Color.White;
            lblAdminInfo.Location = new Point(14, 12);
            lblAdminInfo.Margin = new Padding(4, 0, 4, 0);
            lblAdminInfo.Name = "lblAdminInfo";
            lblAdminInfo.Size = new Size(0, 17);
            lblAdminInfo.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1143, 6);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(117, 35);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // colBookId
            // 
            colBookId.HeaderText = "ID";
            colBookId.Name = "colBookId";
            colBookId.ReadOnly = true;
            colBookId.Visible = false;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Название";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Автор";
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colYear
            // 
            colYear.HeaderText = "Год";
            colYear.Name = "colYear";
            colYear.ReadOnly = true;
            // 
            // colGenre
            // 
            colGenre.HeaderText = "Жанр";
            colGenre.Name = "colGenre";
            colGenre.ReadOnly = true;
            // 
            // colType
            // 
            colType.HeaderText = "Тип";
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colRating
            // 
            colRating.HeaderText = "Рейтинг";
            colRating.Name = "colRating";
            colRating.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Статус";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colCopies
            // 
            colCopies.HeaderText = "Копий";
            colCopies.Name = "colCopies";
            colCopies.ReadOnly = true;
            // 
            // colIsNew
            // 
            colIsNew.HeaderText = "Новинка";
            colIsNew.Name = "colIsNew";
            colIsNew.ReadOnly = true;
            // 
            // colIsHit
            // 
            colIsHit.HeaderText = "Хит";
            colIsHit.Name = "colIsHit";
            colIsHit.ReadOnly = true;
            // 
            // colBookLoans
            // 
            colBookLoans.HeaderText = "Выдач";
            colBookLoans.Name = "colBookLoans";
            colBookLoans.ReadOnly = true;
            // 
            // colBookReviews
            // 
            colBookReviews.HeaderText = "Отзывов";
            colBookReviews.Name = "colBookReviews";
            colBookReviews.ReadOnly = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(1283, 808);
            Controls.Add(btnRefresh);
            Controls.Add(lblAdminInfo);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Админ-панель библиотеки";
            tabControl.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            tabBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            tabAuthors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuthors).EndInit();
            tabGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewGenres).EndInit();
            tabPickups.ResumeLayout(false);
            tabPickups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPickups).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblCode;
        private DataGridViewTextBoxColumn colBookId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colYear;
        private DataGridViewTextBoxColumn colGenre;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colRating;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colCopies;
        private DataGridViewTextBoxColumn colIsNew;
        private DataGridViewTextBoxColumn colIsHit;
        private DataGridViewTextBoxColumn colBookLoans;
        private DataGridViewTextBoxColumn colBookReviews;
    }
}
namespace LibraryApp.Forms
{
    partial class CatalogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPopularity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYearFrom;
        private System.Windows.Forms.TextBox textBoxYearFrom;
        private System.Windows.Forms.Label lblYearTo;
        private System.Windows.Forms.TextBox textBoxYearTo;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.ComboBox comboBoxSortBy;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblResultCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.lblYearFrom = new System.Windows.Forms.Label();
            this.textBoxYearFrom = new System.Windows.Forms.TextBox();
            this.lblYearTo = new System.Windows.Forms.Label();
            this.textBoxYearTo = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.comboBoxSortBy = new System.Windows.Forms.ComboBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.colBookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPopularity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResultCount = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();

            // filterPanel
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Location = new System.Drawing.Point(10, 10);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(960, 110);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 13);
            this.lblTitle.Text = "Название:";

            // textBoxTitle
            this.textBoxTitle.Location = new System.Drawing.Point(80, 12);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(200, 20);

            // lblAuthor
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(300, 15);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(40, 13);
            this.lblAuthor.Text = "Автор:";

            // textBoxAuthor
            this.textBoxAuthor.Location = new System.Drawing.Point(350, 12);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(200, 20);

            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(570, 15);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.Text = "Жанр:";

            // comboBoxGenre
            this.comboBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenre.Location = new System.Drawing.Point(620, 12);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(200, 21);

            // lblYearFrom
            this.lblYearFrom.AutoSize = true;
            this.lblYearFrom.Location = new System.Drawing.Point(10, 45);
            this.lblYearFrom.Name = "lblYearFrom";
            this.lblYearFrom.Size = new System.Drawing.Size(44, 13);
            this.lblYearFrom.Text = "Год от:";

            // textBoxYearFrom
            this.textBoxYearFrom.Location = new System.Drawing.Point(60, 42);
            this.textBoxYearFrom.Name = "textBoxYearFrom";
            this.textBoxYearFrom.Size = new System.Drawing.Size(70, 20);

            // lblYearTo
            this.lblYearTo.AutoSize = true;
            this.lblYearTo.Location = new System.Drawing.Point(140, 45);
            this.lblYearTo.Name = "lblYearTo";
            this.lblYearTo.Size = new System.Drawing.Size(22, 13);
            this.lblYearTo.Text = "до:";

            // textBoxYearTo
            this.textBoxYearTo.Location = new System.Drawing.Point(170, 42);
            this.textBoxYearTo.Name = "textBoxYearTo";
            this.textBoxYearTo.Size = new System.Drawing.Size(70, 20);

            // lblLanguage
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(260, 45);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(35, 13);
            this.lblLanguage.Text = "Язык:";

            // comboBoxLanguage
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Items.AddRange(new object[] { "Все языки", "Русский", "Английский", "Французский", "Немецкий" });
            this.comboBoxLanguage.Location = new System.Drawing.Point(300, 42);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(120, 21);

            // lblSortBy
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Location = new System.Drawing.Point(440, 45);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(66, 13);
            this.lblSortBy.Text = "Сортировка:";

            // comboBoxSortBy
            this.comboBoxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortBy.Items.AddRange(new object[] { "По популярности", "По дате поступления", "По рейтингу" });
            this.comboBoxSortBy.Location = new System.Drawing.Point(515, 42);
            this.comboBoxSortBy.Name = "comboBoxSortBy";
            this.comboBoxSortBy.Size = new System.Drawing.Size(180, 21);

            // btnApplyFilters
            this.btnApplyFilters.Location = new System.Drawing.Point(720, 75);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(140, 28);
            this.btnApplyFilters.Text = "Применить фильтры";
            this.btnApplyFilters.UseVisualStyleBackColor = true;

            // btnResetFilters
            this.btnResetFilters.Location = new System.Drawing.Point(720, 40);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(140, 28);
            this.btnResetFilters.Text = "Сбросить фильтры";
            this.btnResetFilters.UseVisualStyleBackColor = true;

            // dataGridViewBooks
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(10, 150);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(960, 470);

            // Колонки таблицы книг
            this.colBookId.HeaderText = "ID";
            this.colBookId.Name = "colBookId";
            this.colBookId.Visible = false;

            this.colTitle.HeaderText = "Название";
            this.colTitle.Name = "colTitle";

            this.colAuthor.HeaderText = "Автор";
            this.colAuthor.Name = "colAuthor";

            this.colGenre.HeaderText = "Жанр";
            this.colGenre.Name = "colGenre";

            this.colYear.HeaderText = "Год";
            this.colYear.Name = "colYear";

            this.colLanguage.HeaderText = "Язык";
            this.colLanguage.Name = "colLanguage";

            this.colRating.HeaderText = "Рейтинг";
            this.colRating.Name = "colRating";

            this.colPopularity.HeaderText = "Популярность";
            this.colPopularity.Name = "colPopularity";

            this.colAvailable.HeaderText = "Доступна";
            this.colAvailable.Name = "colAvailable";

            this.dataGridViewBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colBookId, this.colTitle, this.colAuthor, this.colGenre,
                this.colYear, this.colLanguage, this.colRating, this.colPopularity, this.colAvailable});

            // lblResultCount
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(10, 130);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(0, 13);
            this.lblResultCount.Text = "";

            // CatalogForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 631);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.filterPanel);
            this.Name = "CatalogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог книг";

            this.filterPanel.Controls.Add(this.lblTitle);
            this.filterPanel.Controls.Add(this.textBoxTitle);
            this.filterPanel.Controls.Add(this.lblAuthor);
            this.filterPanel.Controls.Add(this.textBoxAuthor);
            this.filterPanel.Controls.Add(this.lblGenre);
            this.filterPanel.Controls.Add(this.comboBoxGenre);
            this.filterPanel.Controls.Add(this.lblYearFrom);
            this.filterPanel.Controls.Add(this.textBoxYearFrom);
            this.filterPanel.Controls.Add(this.lblYearTo);
            this.filterPanel.Controls.Add(this.textBoxYearTo);
            this.filterPanel.Controls.Add(this.lblLanguage);
            this.filterPanel.Controls.Add(this.comboBoxLanguage);
            this.filterPanel.Controls.Add(this.lblSortBy);
            this.filterPanel.Controls.Add(this.comboBoxSortBy);
            this.filterPanel.Controls.Add(this.btnApplyFilters);
            this.filterPanel.Controls.Add(this.btnResetFilters);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
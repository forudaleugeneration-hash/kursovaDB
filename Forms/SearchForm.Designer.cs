namespace LibraryApp.Forms
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultAvailable;
        private System.Windows.Forms.Label lblResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.colResultId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();

            // lblSearchBy
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchBy.Location = new System.Drawing.Point(20, 20);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(52, 17);
            this.lblSearchBy.Text = "Поиск";

            // textBoxSearch
            this.textBoxSearch.Location = new System.Drawing.Point(20, 50);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(500, 20);

            // comboBoxSearch
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.Location = new System.Drawing.Point(20, 50);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(500, 21);
            this.comboBoxSearch.Visible = false;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(540, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 28);
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(660, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 28);
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;

            // lblResults
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblResults.Location = new System.Drawing.Point(20, 90);
            this.lblResults.Text = "Результаты поиска:";

            // dataGridViewResults
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(20, 115);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.ReadOnly = true;
            this.dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResults.Size = new System.Drawing.Size(750, 380);

            // Колонки результатов поиска
            this.colResultId.HeaderText = "ID";
            this.colResultId.Name = "colResultId";
            this.colResultId.Visible = false;

            this.colResultTitle.HeaderText = "Название";
            this.colResultTitle.Name = "colResultTitle";

            this.colResultAuthor.HeaderText = "Автор";
            this.colResultAuthor.Name = "colResultAuthor";

            this.colResultGenre.HeaderText = "Жанр";
            this.colResultGenre.Name = "colResultGenre";

            this.colResultYear.HeaderText = "Год";
            this.colResultYear.Name = "colResultYear";

            this.colResultRating.HeaderText = "Рейтинг";
            this.colResultRating.Name = "colResultRating";

            this.colResultAvailable.HeaderText = "Доступна";
            this.colResultAvailable.Name = "colResultAvailable";

            this.dataGridViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colResultId, this.colResultTitle, this.colResultAuthor, this.colResultGenre,
                this.colResultYear, this.colResultRating, this.colResultAvailable});

            // SearchForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.lblSearchBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
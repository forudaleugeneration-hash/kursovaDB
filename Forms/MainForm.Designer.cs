namespace LibraryApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnAdminPanel;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPopular;
        private System.Windows.Forms.TabPage tabNew;
        private System.Windows.Forms.TabPage tabRecommended;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPopular;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutNew;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutRecommended;

        // Шаблон карточки книги
        private System.Windows.Forms.Panel cardTemplate;
        private System.Windows.Forms.Panel coverTemplate;
        private System.Windows.Forms.Label coverIconTemplate;
        private System.Windows.Forms.Label titleTemplate;
        private System.Windows.Forms.Label authorTemplate;
        private System.Windows.Forms.Label ratingTemplate;
        private System.Windows.Forms.Label statusTemplate;
        private System.Windows.Forms.Button detailTemplate;

        private System.Windows.Forms.GroupBox groupQuickSearch;
        private System.Windows.Forms.TextBox textBoxQuickSearch;
        private System.Windows.Forms.Button btnQuickSearch;
        private System.Windows.Forms.Button btnQuickSearchAuthor;
        private System.Windows.Forms.Button btnQuickSearchGenre;
        private System.Windows.Forms.Button btnQuickSearchTitle;

        private System.Windows.Forms.GroupBox groupRecommendations;
        private System.Windows.Forms.ListBox listBoxRecommendations;
        private System.Windows.Forms.Label lblRecommendationInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblWelcome = new Label();
            lblRole = new Label();
            btnCatalog = new Button();
            btnProfile = new Button();
            btnAdminPanel = new Button();
            btnLogout = new Button();
            tabControl1 = new TabControl();
            tabPopular = new TabPage();
            flowLayoutPopular = new FlowLayoutPanel();
            cardTemplate = new Panel();
            coverTemplate = new Panel();
            coverIconTemplate = new Label();
            titleTemplate = new Label();
            authorTemplate = new Label();
            ratingTemplate = new Label();
            statusTemplate = new Label();
            detailTemplate = new Button();
            tabNew = new TabPage();
            flowLayoutNew = new FlowLayoutPanel();
            tabRecommended = new TabPage();
            flowLayoutRecommended = new FlowLayoutPanel();
            groupQuickSearch = new GroupBox();
            textBoxQuickSearch = new TextBox();
            btnQuickSearch = new Button();
            btnQuickSearchAuthor = new Button();
            btnQuickSearchGenre = new Button();
            btnQuickSearchTitle = new Button();
            groupRecommendations = new GroupBox();
            lblRecommendationInfo = new Label();
            listBoxRecommendations = new ListBox();
            panelTop.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPopular.SuspendLayout();
            flowLayoutPopular.SuspendLayout();
            cardTemplate.SuspendLayout();
            coverTemplate.SuspendLayout();
            tabNew.SuspendLayout();
            tabRecommended.SuspendLayout();
            groupQuickSearch.SuspendLayout();
            groupRecommendations.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(44, 62, 80);
            panelTop.Controls.Add(lblWelcome);
            panelTop.Controls.Add(lblRole);
            panelTop.Controls.Add(btnCatalog);
            panelTop.Controls.Add(btnProfile);
            panelTop.Controls.Add(btnAdminPanel);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1377, 69);
            panelTop.TabIndex = 3;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(14, 9);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(204, 24);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Добро пожаловать!";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Microsoft Sans Serif", 8F);
            lblRole.ForeColor = Color.FromArgb(189, 195, 199);
            lblRole.Location = new Point(14, 40);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(80, 13);
            lblRole.TabIndex = 1;
            lblRole.Text = "Пользователь";
            // 
            // btnCatalog
            // 
            btnCatalog.BackColor = Color.FromArgb(52, 152, 219);
            btnCatalog.FlatStyle = FlatStyle.Flat;
            btnCatalog.ForeColor = Color.White;
            btnCatalog.Location = new Point(943, 12);
            btnCatalog.Margin = new Padding(4, 3, 4, 3);
            btnCatalog.Name = "btnCatalog";
            btnCatalog.Size = new Size(140, 40);
            btnCatalog.TabIndex = 2;
            btnCatalog.Text = "Каталог";
            btnCatalog.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(46, 204, 113);
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(1095, 12);
            btnProfile.Margin = new Padding(4, 3, 4, 3);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(140, 40);
            btnProfile.TabIndex = 3;
            btnProfile.Text = "Профиль";
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.BackColor = Color.FromArgb(155, 89, 182);
            btnAdminPanel.FlatStyle = FlatStyle.Flat;
            btnAdminPanel.ForeColor = Color.White;
            btnAdminPanel.Location = new Point(818, 12);
            btnAdminPanel.Margin = new Padding(4, 3, 4, 3);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new Size(117, 40);
            btnAdminPanel.TabIndex = 4;
            btnAdminPanel.Text = "Админ";
            btnAdminPanel.UseVisualStyleBackColor = false;
            btnAdminPanel.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1242, 12);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(117, 40);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPopular);
            tabControl1.Controls.Add(tabNew);
            tabControl1.Controls.Add(tabRecommended);
            tabControl1.Location = new Point(14, 81);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(875, 404);
            tabControl1.TabIndex = 2;
            // 
            // tabPopular
            // 
            tabPopular.Controls.Add(flowLayoutPopular);
            tabPopular.Location = new Point(4, 24);
            tabPopular.Margin = new Padding(4, 3, 4, 3);
            tabPopular.Name = "tabPopular";
            tabPopular.Size = new Size(867, 376);
            tabPopular.TabIndex = 0;
            tabPopular.Text = "Хиты чтения";
            // 
            // flowLayoutPopular
            // 
            flowLayoutPopular.AutoScroll = true;
            flowLayoutPopular.BackColor = Color.White;
            flowLayoutPopular.Controls.Add(cardTemplate);
            flowLayoutPopular.Dock = DockStyle.Fill;
            flowLayoutPopular.Location = new Point(0, 0);
            flowLayoutPopular.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPopular.Name = "flowLayoutPopular";
            flowLayoutPopular.Padding = new Padding(6, 6, 6, 6);
            flowLayoutPopular.Size = new Size(867, 376);
            flowLayoutPopular.TabIndex = 0;
            // 
            // cardTemplate
            // 
            cardTemplate.BackColor = Color.White;
            cardTemplate.BorderStyle = BorderStyle.FixedSingle;
            cardTemplate.Controls.Add(coverTemplate);
            cardTemplate.Controls.Add(titleTemplate);
            cardTemplate.Controls.Add(authorTemplate);
            cardTemplate.Controls.Add(ratingTemplate);
            cardTemplate.Controls.Add(statusTemplate);
            cardTemplate.Controls.Add(detailTemplate);
            cardTemplate.Location = new Point(10, 9);
            cardTemplate.Margin = new Padding(4, 3, 4, 3);
            cardTemplate.Name = "cardTemplate";
            cardTemplate.Size = new Size(233, 323);
            cardTemplate.TabIndex = 0;
            // 
            // coverTemplate
            // 
            coverTemplate.BackColor = Color.FromArgb(52, 152, 219);
            coverTemplate.Controls.Add(coverIconTemplate);
            coverTemplate.Location = new Point(6, 6);
            coverTemplate.Margin = new Padding(4, 3, 4, 3);
            coverTemplate.Name = "coverTemplate";
            coverTemplate.Size = new Size(222, 138);
            coverTemplate.TabIndex = 0;
            // 
            // coverIconTemplate
            // 
            coverIconTemplate.Dock = DockStyle.Fill;
            coverIconTemplate.Font = new Font("Microsoft Sans Serif", 40F);
            coverIconTemplate.ForeColor = Color.White;
            coverIconTemplate.Location = new Point(0, 0);
            coverIconTemplate.Margin = new Padding(4, 0, 4, 0);
            coverIconTemplate.Name = "coverIconTemplate";
            coverIconTemplate.Size = new Size(222, 138);
            coverIconTemplate.TabIndex = 0;
            coverIconTemplate.Text = "📚";
            coverIconTemplate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleTemplate
            // 
            titleTemplate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            titleTemplate.Location = new Point(6, 150);
            titleTemplate.Margin = new Padding(4, 0, 4, 0);
            titleTemplate.Name = "titleTemplate";
            titleTemplate.Size = new Size(222, 40);
            titleTemplate.TabIndex = 1;
            titleTemplate.Text = "Название книги";
            // 
            // authorTemplate
            // 
            authorTemplate.AutoSize = true;
            authorTemplate.Font = new Font("Microsoft Sans Serif", 8F);
            authorTemplate.ForeColor = Color.Gray;
            authorTemplate.Location = new Point(6, 190);
            authorTemplate.Margin = new Padding(4, 0, 4, 0);
            authorTemplate.Name = "authorTemplate";
            authorTemplate.Size = new Size(37, 13);
            authorTemplate.TabIndex = 2;
            authorTemplate.Text = "Автор";
            // 
            // ratingTemplate
            // 
            ratingTemplate.AutoSize = true;
            ratingTemplate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            ratingTemplate.Location = new Point(6, 213);
            ratingTemplate.Margin = new Padding(4, 0, 4, 0);
            ratingTemplate.Name = "ratingTemplate";
            ratingTemplate.Size = new Size(42, 15);
            ratingTemplate.TabIndex = 3;
            ratingTemplate.Text = "⭐ 4.5";
            // 
            // statusTemplate
            // 
            statusTemplate.AutoSize = true;
            statusTemplate.Font = new Font("Microsoft Sans Serif", 8F);
            statusTemplate.ForeColor = Color.Green;
            statusTemplate.Location = new Point(6, 237);
            statusTemplate.Margin = new Padding(4, 0, 4, 0);
            statusTemplate.Name = "statusTemplate";
            statusTemplate.Size = new Size(71, 13);
            statusTemplate.TabIndex = 4;
            statusTemplate.Text = "✅ Доступна";
            // 
            // detailTemplate
            // 
            detailTemplate.BackColor = Color.FromArgb(52, 152, 219);
            detailTemplate.FlatStyle = FlatStyle.Flat;
            detailTemplate.ForeColor = Color.White;
            detailTemplate.Location = new Point(58, 277);
            detailTemplate.Margin = new Padding(4, 3, 4, 3);
            detailTemplate.Name = "detailTemplate";
            detailTemplate.Size = new Size(117, 35);
            detailTemplate.TabIndex = 5;
            detailTemplate.Text = "Подробнее";
            detailTemplate.UseVisualStyleBackColor = false;
            // 
            // tabNew
            // 
            tabNew.Controls.Add(flowLayoutNew);
            tabNew.Location = new Point(4, 24);
            tabNew.Margin = new Padding(4, 3, 4, 3);
            tabNew.Name = "tabNew";
            tabNew.Size = new Size(867, 376);
            tabNew.TabIndex = 1;
            tabNew.Text = "Новинки";
            // 
            // flowLayoutNew
            // 
            flowLayoutNew.AutoScroll = true;
            flowLayoutNew.BackColor = Color.White;
            flowLayoutNew.Dock = DockStyle.Fill;
            flowLayoutNew.Location = new Point(0, 0);
            flowLayoutNew.Margin = new Padding(4, 3, 4, 3);
            flowLayoutNew.Name = "flowLayoutNew";
            flowLayoutNew.Padding = new Padding(6, 6, 6, 6);
            flowLayoutNew.Size = new Size(867, 376);
            flowLayoutNew.TabIndex = 0;
            // 
            // tabRecommended
            // 
            tabRecommended.Controls.Add(flowLayoutRecommended);
            tabRecommended.Location = new Point(4, 24);
            tabRecommended.Margin = new Padding(4, 3, 4, 3);
            tabRecommended.Name = "tabRecommended";
            tabRecommended.Size = new Size(867, 376);
            tabRecommended.TabIndex = 2;
            tabRecommended.Text = "Рекомендуемые";
            // 
            // flowLayoutRecommended
            // 
            flowLayoutRecommended.AutoScroll = true;
            flowLayoutRecommended.BackColor = Color.White;
            flowLayoutRecommended.Dock = DockStyle.Fill;
            flowLayoutRecommended.Location = new Point(0, 0);
            flowLayoutRecommended.Margin = new Padding(4, 3, 4, 3);
            flowLayoutRecommended.Name = "flowLayoutRecommended";
            flowLayoutRecommended.Padding = new Padding(6, 6, 6, 6);
            flowLayoutRecommended.Size = new Size(867, 376);
            flowLayoutRecommended.TabIndex = 0;
            // 
            // groupQuickSearch
            // 
            groupQuickSearch.Controls.Add(textBoxQuickSearch);
            groupQuickSearch.Controls.Add(btnQuickSearch);
            groupQuickSearch.Controls.Add(btnQuickSearchAuthor);
            groupQuickSearch.Controls.Add(btnQuickSearchGenre);
            groupQuickSearch.Controls.Add(btnQuickSearchTitle);
            groupQuickSearch.Location = new Point(898, 81);
            groupQuickSearch.Margin = new Padding(4, 3, 4, 3);
            groupQuickSearch.Name = "groupQuickSearch";
            groupQuickSearch.Padding = new Padding(4, 3, 4, 3);
            groupQuickSearch.Size = new Size(461, 404);
            groupQuickSearch.TabIndex = 1;
            groupQuickSearch.TabStop = false;
            groupQuickSearch.Text = "Быстрый поиск";
            // 
            // textBoxQuickSearch
            // 
            textBoxQuickSearch.Location = new Point(18, 29);
            textBoxQuickSearch.Margin = new Padding(4, 3, 4, 3);
            textBoxQuickSearch.Name = "textBoxQuickSearch";
            textBoxQuickSearch.Size = new Size(303, 23);
            textBoxQuickSearch.TabIndex = 0;
            // 
            // btnQuickSearch
            // 
            btnQuickSearch.Location = new Point(332, 28);
            btnQuickSearch.Margin = new Padding(4, 3, 4, 3);
            btnQuickSearch.Name = "btnQuickSearch";
            btnQuickSearch.Size = new Size(111, 29);
            btnQuickSearch.TabIndex = 1;
            btnQuickSearch.Text = "Найти";
            // 
            // btnQuickSearchAuthor
            // 
            btnQuickSearchAuthor.Location = new Point(18, 75);
            btnQuickSearchAuthor.Margin = new Padding(4, 3, 4, 3);
            btnQuickSearchAuthor.Name = "btnQuickSearchAuthor";
            btnQuickSearchAuthor.Size = new Size(426, 40);
            btnQuickSearchAuthor.TabIndex = 2;
            btnQuickSearchAuthor.Text = "Поиск по автору";
            // 
            // btnQuickSearchGenre
            // 
            btnQuickSearchGenre.Location = new Point(18, 127);
            btnQuickSearchGenre.Margin = new Padding(4, 3, 4, 3);
            btnQuickSearchGenre.Name = "btnQuickSearchGenre";
            btnQuickSearchGenre.Size = new Size(426, 40);
            btnQuickSearchGenre.TabIndex = 3;
            btnQuickSearchGenre.Text = "Поиск по жанру";
            // 
            // btnQuickSearchTitle
            // 
            btnQuickSearchTitle.Location = new Point(18, 179);
            btnQuickSearchTitle.Margin = new Padding(4, 3, 4, 3);
            btnQuickSearchTitle.Name = "btnQuickSearchTitle";
            btnQuickSearchTitle.Size = new Size(426, 40);
            btnQuickSearchTitle.TabIndex = 4;
            btnQuickSearchTitle.Text = "Поиск по названию";
            // 
            // groupRecommendations
            // 
            groupRecommendations.Controls.Add(lblRecommendationInfo);
            groupRecommendations.Controls.Add(listBoxRecommendations);
            groupRecommendations.Location = new Point(14, 496);
            groupRecommendations.Margin = new Padding(4, 3, 4, 3);
            groupRecommendations.Name = "groupRecommendations";
            groupRecommendations.Padding = new Padding(4, 3, 4, 3);
            groupRecommendations.Size = new Size(1345, 173);
            groupRecommendations.TabIndex = 0;
            groupRecommendations.TabStop = false;
            groupRecommendations.Text = "Рекомендации для вас";
            // 
            // lblRecommendationInfo
            // 
            lblRecommendationInfo.AutoSize = true;
            lblRecommendationInfo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblRecommendationInfo.ForeColor = Color.FromArgb(52, 152, 219);
            lblRecommendationInfo.Location = new Point(12, 23);
            lblRecommendationInfo.Margin = new Padding(4, 0, 4, 0);
            lblRecommendationInfo.Name = "lblRecommendationInfo";
            lblRecommendationInfo.Size = new Size(156, 15);
            lblRecommendationInfo.TabIndex = 0;
            lblRecommendationInfo.Text = "Рекомендуемые книги";
            // 
            // listBoxRecommendations
            // 
            listBoxRecommendations.BorderStyle = BorderStyle.None;
            listBoxRecommendations.Font = new Font("Microsoft Sans Serif", 9F);
            listBoxRecommendations.Location = new Point(12, 46);
            listBoxRecommendations.Margin = new Padding(4, 3, 4, 3);
            listBoxRecommendations.Name = "listBoxRecommendations";
            listBoxRecommendations.Size = new Size(1318, 105);
            listBoxRecommendations.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1377, 692);
            Controls.Add(groupRecommendations);
            Controls.Add(groupQuickSearch);
            Controls.Add(tabControl1);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Библиотека - Главная";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPopular.ResumeLayout(false);
            flowLayoutPopular.ResumeLayout(false);
            cardTemplate.ResumeLayout(false);
            cardTemplate.PerformLayout();
            coverTemplate.ResumeLayout(false);
            tabNew.ResumeLayout(false);
            tabRecommended.ResumeLayout(false);
            groupQuickSearch.ResumeLayout(false);
            groupQuickSearch.PerformLayout();
            groupRecommendations.ResumeLayout(false);
            groupRecommendations.PerformLayout();
            ResumeLayout(false);
        }
    }
}
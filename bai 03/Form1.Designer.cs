using static System.Net.Mime.MediaTypeNames;

namespace Bài_3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportCsvToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblInput;
        private TableLayoutPanel tblRight;

        private Label lblProductId;
        private Label lblProductName;
        private Label lblUnitPrice;
        private Label lblQuantity;
        private Label lblCategory;
        private Label lblAvatar;
        private Label lblSearch;

        private TextBox txtProductId;
        private TextBox txtProductName;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtSearch;

        private ComboBox cboCategory;

        private PictureBox picAvatar;
        private Button btnChooseImage;

        private FlowLayoutPanel pnlButtons;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;

        private ErrorProvider errorProvider1;

        private DataGridView dgvProducts;

        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;

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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportCsvToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            tblMain = new TableLayoutPanel();
            tblInput = new TableLayoutPanel();
            lblProductId = new Label();
            txtProductId = new TextBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblUnitPrice = new Label();
            txtUnitPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblAvatar = new Label();
            picAvatar = new PictureBox();
            btnChooseImage = new Button();
            pnlButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            tblRight = new TableLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tblMain.SuspendLayout();
            tblInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlButtons.SuspendLayout();
            tblRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1200, 24);
            menuStrip1.TabIndex = 2;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCsvToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exportCsvToolStripMenuItem
            // 
            exportCsvToolStripMenuItem.Name = "exportCsvToolStripMenuItem";
            exportCsvToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exportCsvToolStripMenuItem.Size = new Size(171, 22);
            exportCsvToolStripMenuItem.Text = "Export CSV";
            exportCsvToolStripMenuItem.Click += this.exportCsvToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            exitToolStripMenuItem.Size = new Size(171, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += this.exitToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 678);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1200, 22);
            statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(117, 17);
            lblStatus.Text = "Tổng số sản phẩm: 0";
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tblMain.Controls.Add(tblInput, 0, 0);
            tblMain.Controls.Add(tblRight, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 24);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(8);
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1200, 654);
            tblMain.TabIndex = 0;
            // 
            // tblInput
            // 
            tblInput.ColumnCount = 2;
            tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            tblInput.Controls.Add(lblProductId, 0, 0);
            tblInput.Controls.Add(txtProductId, 1, 0);
            tblInput.Controls.Add(lblProductName, 0, 1);
            tblInput.Controls.Add(txtProductName, 1, 1);
            tblInput.Controls.Add(lblUnitPrice, 0, 2);
            tblInput.Controls.Add(txtUnitPrice, 1, 2);
            tblInput.Controls.Add(lblQuantity, 0, 3);
            tblInput.Controls.Add(txtQuantity, 1, 3);
            tblInput.Controls.Add(lblCategory, 0, 4);
            tblInput.Controls.Add(cboCategory, 1, 4);
            tblInput.Controls.Add(lblAvatar, 0, 5);
            tblInput.Controls.Add(picAvatar, 1, 5);
            tblInput.Controls.Add(btnChooseImage, 1, 6);
            tblInput.Controls.Add(pnlButtons, 0, 7);
            tblInput.Dock = DockStyle.Fill;
            tblInput.Location = new Point(11, 11);
            tblInput.Name = "tblInput";
            tblInput.RowCount = 8;
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tblInput.Size = new Size(408, 632);
            tblInput.TabIndex = 0;
            // 
            // lblProductId
            // 
            lblProductId.Anchor = AnchorStyles.Left;
            lblProductId.Location = new Point(3, 9);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(100, 23);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã SP";
            // 
            // txtProductId
            // 
            txtProductId.Dock = DockStyle.Fill;
            txtProductId.Location = new Point(133, 3);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(272, 23);
            txtProductId.TabIndex = 1;
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.Left;
            lblProductName.Location = new Point(3, 51);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(100, 23);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên SP";
            // 
            // txtProductName
            // 
            txtProductName.Dock = DockStyle.Fill;
            txtProductName.Location = new Point(133, 45);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(272, 23);
            txtProductName.TabIndex = 3;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.Anchor = AnchorStyles.Left;
            lblUnitPrice.Location = new Point(3, 93);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(100, 23);
            lblUnitPrice.TabIndex = 4;
            lblUnitPrice.Text = "Đơn giá";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Dock = DockStyle.Fill;
            txtUnitPrice.Location = new Point(133, 87);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(272, 23);
            txtUnitPrice.TabIndex = 5;
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Left;
            lblQuantity.Location = new Point(3, 135);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 23);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Số lượng";
            // 
            // txtQuantity
            // 
            txtQuantity.Dock = DockStyle.Fill;
            txtQuantity.Location = new Point(133, 129);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(272, 23);
            txtQuantity.TabIndex = 7;
            // 
            // lblCategory
            // 
            lblCategory.Anchor = AnchorStyles.Left;
            lblCategory.Location = new Point(3, 177);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Danh mục";
            // 
            // cboCategory
            // 
            cboCategory.Dock = DockStyle.Fill;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(133, 171);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(272, 23);
            cboCategory.TabIndex = 9;
            // 
            // lblAvatar
            // 
            lblAvatar.Anchor = AnchorStyles.Left;
            lblAvatar.Location = new Point(3, 361);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(100, 23);
            lblAvatar.TabIndex = 10;
            lblAvatar.Text = "Ảnh SP";
            // 
            // picAvatar
            // 
            picAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picAvatar.BackColor = Color.White;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(133, 213);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(272, 319);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 11;
            picAvatar.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Dock = DockStyle.Fill;
            btnChooseImage.Location = new Point(133, 538);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(272, 36);
            btnChooseImage.TabIndex = 12;
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.Click += this.btnChooseImage_Click;
            // 
            // pnlButtons
            // 
            tblInput.SetColumnSpan(pnlButtons, 2);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(3, 580);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(402, 49);
            pnlButtons.TabIndex = 13;
            pnlButtons.WrapContents = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.Click += this.btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(89, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Click += this.btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(175, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.Click += this.btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(251, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.Click += this.btnClear_Click;
            // 
            // tblRight
            // 
            tblRight.ColumnCount = 2;
            tblRight.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRight.Controls.Add(lblSearch, 0, 0);
            tblRight.Controls.Add(txtSearch, 1, 0);
            tblRight.Controls.Add(dgvProducts, 0, 1);
            tblRight.Dock = DockStyle.Fill;
            tblRight.Location = new Point(425, 11);
            tblRight.Name = "tblRight";
            tblRight.RowCount = 2;
            tblRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRight.Size = new Size(764, 632);
            tblRight.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.Location = new Point(3, 9);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(74, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(83, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(678, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += this.txtSearch_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tblRight.SetColumnSpan(dgvProducts, 2);
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 45);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(758, 584);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellClick += this.dgvProducts_CellClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(tblMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 550);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 3 - TechMart Product Manager";
            Load += this.Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tblMain.ResumeLayout(false);
            tblInput.ResumeLayout(false);
            tblInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlButtons.ResumeLayout(false);
            tblRight.ResumeLayout(false);
            tblRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
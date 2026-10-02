using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bài_3
{
    public partial class Form1 : Form
    {
        private BindingList<Product> products =
            new BindingList<Product>();

        private BindingSource bindingSource =
            new BindingSource();

        private Product? selectedProduct = null;

        public Form1()
        {
            InitializeComponent();

            bindingSource.DataSource =
                products;

            dgvProducts.DataSource =
                bindingSource;
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void Form1_Load(
            object? sender,
            EventArgs e)
        {
            BindingList<Category> categories =
                new BindingList<Category>();

            categories.Add(
                new Category(
                    1,
                    "Điện thoại"));

            categories.Add(
                new Category(
                    2,
                    "Laptop"));

            categories.Add(
                new Category(
                    3,
                    "Phụ kiện"));

            cboCategory.DataSource =
                categories;

            cboCategory.DisplayMember =
                "Name";

            cboCategory.ValueMember =
                "Id";

            ClearInputs();

            UpdateStatus();
        }

        // =====================================================
        // VALIDATION
        // =====================================================

        private bool ValidateInputs()
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(
                txtProductName.Text))
            {
                errorProvider1.SetError(
                    txtProductName,
                    "Tên SP không được để trống.");

                valid = false;
            }

            if (!decimal.TryParse(
                txtUnitPrice.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal price))
            {
                errorProvider1.SetError(
                    txtUnitPrice,
                    "Đơn giá phải là số.");

                valid = false;
            }
            else if (price <= 0)
            {
                errorProvider1.SetError(
                    txtUnitPrice,
                    "Đơn giá phải > 0.");

                valid = false;
            }

            if (!int.TryParse(
                txtQuantity.Text.Trim(),
                out int quantity))
            {
                errorProvider1.SetError(
                    txtQuantity,
                    "Số lượng phải là số nguyên.");

                valid = false;
            }
            else if (quantity < 0)
            {
                errorProvider1.SetError(
                    txtQuantity,
                    "Số lượng phải >= 0.");

                valid = false;
            }

            return valid;
        }

        // =====================================================
        // ADD
        // =====================================================

        private void btnAdd_Click(
            object? sender,
            EventArgs e)
        {
            if (!ValidateInputs())
                return;

            decimal.TryParse(
                txtUnitPrice.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal price);

            int.TryParse(
                txtQuantity.Text.Trim(),
                out int quantity);

            string productId =
                txtProductId.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                productId))
            {
                productId =
                    "SP" +
                    (products.Count + 1)
                    .ToString("000");
            }

            if (products.Any(
                p => p.ProductId.Equals(
                    productId,
                    StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(
                    txtProductId,
                    "Mã SP đã tồn tại.");

                return;
            }

            Category? category =
                cboCategory.SelectedItem as Category;

            Product product =
                new Product();

            product.ProductId =
                productId;

            product.ProductName =
                txtProductName.Text.Trim();

            product.UnitPrice =
                price;

            product.Quantity =
                quantity;

            if (category != null)
            {
                product.CategoryId =
                    category.Id;

                product.CategoryName =
                    category.Name;
            }

            product.AvatarPath =
                picAvatar.Tag as string ?? "";

            products.Add(product);

            bindingSource.DataSource =
                products;

            bindingSource.ResetBindings(false);

            UpdateStatus();

            ClearInputs();
        }

        // =====================================================
        // UPDATE
        // =====================================================

        private void btnUpdate_Click(
            object? sender,
            EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show(
                    "Hãy chọn sản phẩm cần cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (!ValidateInputs())
                return;

            decimal.TryParse(
                txtUnitPrice.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal price);

            int.TryParse(
                txtQuantity.Text.Trim(),
                out int quantity);

            string productId =
                txtProductId.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                productId))
            {
                errorProvider1.SetError(
                    txtProductId,
                    "Mã SP không được để trống.");

                return;
            }

            if (products.Any(
                p => p != selectedProduct &&
                p.ProductId.Equals(
                    productId,
                    StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(
                    txtProductId,
                    "Mã SP đã tồn tại.");

                return;
            }

            Category? category =
                cboCategory.SelectedItem as Category;

            selectedProduct.ProductId =
                productId;

            selectedProduct.ProductName =
                txtProductName.Text.Trim();

            selectedProduct.UnitPrice =
                price;

            selectedProduct.Quantity =
                quantity;

            if (category != null)
            {
                selectedProduct.CategoryId =
                    category.Id;

                selectedProduct.CategoryName =
                    category.Name;
            }

            selectedProduct.AvatarPath =
                picAvatar.Tag as string ?? "";

            bindingSource.ResetBindings(false);

            UpdateStatus();
        }

        // =====================================================
        // DELETE
        // =====================================================

        private void btnDelete_Click(
            object? sender,
            EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show(
                    "Hãy chọn sản phẩm cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm \""
                    + selectedProduct.ProductName
                    + "\"?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            products.Remove(
                selectedProduct);

            selectedProduct = null;

            bindingSource.DataSource =
                products;

            bindingSource.ResetBindings(false);

            UpdateStatus();

            ClearInputs();
        }

        // =====================================================
        // CLEAR / LAM MOI
        // =====================================================

        private void btnClear_Click(
            object? sender,
            EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            selectedProduct = null;

            errorProvider1.Clear();

            txtProductId.Clear();

            txtProductName.Clear();

            txtUnitPrice.Clear();

            txtQuantity.Text = "0";

            if (cboCategory.Items.Count > 0)
            {
                cboCategory.SelectedIndex = 0;
            }

            picAvatar.Tag = null;

            if (picAvatar.Image != null)
            {
                Image oldImage =
                    picAvatar.Image;

                picAvatar.Image = null;

                oldImage.Dispose();
            }

            dgvProducts.ClearSelection();
        }

        // =====================================================
        // GRID CLICK
        // =====================================================

        private void dgvProducts_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >=
                dgvProducts.Rows.Count)
                return;

            Product? product =
                dgvProducts.Rows[e.RowIndex]
                .DataBoundItem as Product;

            if (product == null)
                return;

            selectedProduct =
                product;

            txtProductId.Text =
                product.ProductId;

            txtProductName.Text =
                product.ProductName;

            txtUnitPrice.Text =
                product.UnitPrice.ToString("N0");

            txtQuantity.Text =
                product.Quantity.ToString();

            cboCategory.SelectedValue =
                product.CategoryId;

            LoadImage(
                product.AvatarPath);
        }

        // =====================================================
        // CHOOSE IMAGE
        // =====================================================

        private void btnChooseImage_Click(
            object? sender,
            EventArgs e)
        {
            using OpenFileDialog dialog =
                new OpenFileDialog();

            dialog.Title =
                "Chọn ảnh sản phẩm";

            dialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            dialog.Multiselect = false;

            if (dialog.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            LoadImage(
                dialog.FileName);
        }

        // =====================================================
        // LOAD IMAGE
        // =====================================================

        private void LoadImage(
            string? path)
        {
            picAvatar.Tag =
                path;

            if (picAvatar.Image != null)
            {
                Image oldImage =
                    picAvatar.Image;

                picAvatar.Image =
                    null;

                oldImage.Dispose();
            }

            if (string.IsNullOrWhiteSpace(path))
                return;

            if (!File.Exists(path))
                return;

            try
            {
                using Image temp =
                    Image.FromFile(path);

                picAvatar.Image =
                    new Bitmap(temp);
            }
            catch
            {
                picAvatar.Image =
                    null;
            }
        }

        // =====================================================
        // SEARCH
        // =====================================================

        private void txtSearch_TextChanged(
            object? sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                bindingSource.DataSource =
                    products;
            }
            else
            {
                BindingList<Product> result =
                    new BindingList<Product>(
                        products
                        .Where(
                            p => p.ProductName
                            .IndexOf(
                                keyword,
                                StringComparison
                                .OrdinalIgnoreCase)
                            >= 0)
                        .ToList());

                bindingSource.DataSource =
                    result;
            }

            dgvProducts.DataSource =
                bindingSource;
        }

        // =====================================================
        // STATUS
        // =====================================================

        private void UpdateStatus()
        {
            lblStatus.Text =
                "Tổng số sản phẩm: "
                + products.Count;
        }

        // =====================================================
        // EXPORT CSV
        // =====================================================

        private void exportCsvToolStripMenuItem_Click(
            object? sender,
            EventArgs e)
        {
            if (products.Count == 0)
            {
                MessageBox.Show(
                    "Danh sách sản phẩm đang trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using SaveFileDialog dialog =
                new SaveFileDialog();

            dialog.Title =
                "Xuất danh sách sản phẩm";

            dialog.Filter =
                "CSV files (*.csv)|*.csv";

            dialog.FileName =
                "TechMartProducts.csv";

            if (dialog.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder csv =
                    new StringBuilder();

                csv.AppendLine(
                    "Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng");

                foreach (Product product
                    in products)
                {
                    csv.AppendLine(
                        Csv(product.ProductId)
                        + ","
                        + Csv(product.ProductName)
                        + ","
                        + Csv(product.CategoryName)
                        + ","
                        + product.UnitPrice.ToString(
                            "N0",
                            CultureInfo.InvariantCulture)
                        + ","
                        + product.Quantity);
                }

                File.WriteAllText(
                    dialog.FileName,
                    csv.ToString(),
                    new UTF8Encoding(true));

                MessageBox.Show(
                    "Xuất CSV thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xuất CSV: "
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string Csv(string value)
        {
            if (value == null)
                value = "";

            return "\""
                + value.Replace(
                    "\"",
                    "\"\"")
                + "\"";
        }

        // =====================================================
        // EXIT
        // =====================================================

        private void exitToolStripMenuItem_Click(
            object? sender,
            EventArgs e)
        {
            Application.Exit();
        }
    }
}
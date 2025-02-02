﻿using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using POS_System.Properties;
using System.IO;
using System.Data.SqlClient;
using POS_BUS;
using POS_DAL.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data;
using System.Linq;
namespace POS_System
{

    public partial class frmPay : Form
    {
        private List<SANPHAM> cartItems;
        private readonly SanPhamService sanPhamService = new SanPhamService();
        private readonly string totalAmount;
        private readonly string amountInWords;
        private readonly string customerType;
        private readonly frmOrder orderForm;
        private DataTable selectedProductsTable = new DataTable();

        public frmPay(string soTien, string tienBangChu, string khach, string sl, frmOrder orderForm, List<SANPHAM> cartItems, DataTable selectedProductsTable)
        {
            InitializeComponent();
            lbl_tienSo.Text = soTien;
            lbl_tienChu.Text = tienBangChu;
            lblKhach.Text = khach;
            lblSL.Text = sl;
            this.orderForm = orderForm;
            this.cartItems = cartItems;
            this.cartItems = cartItems;
            DisplayCartItems();
        }
        private void InitializeSelectedProductsTable()
        {
            if (selectedProductsTable.Columns.Count == 0)
            {
                selectedProductsTable.Columns.Add("Mã Sản Phẩm", typeof(string)); // MASP
                selectedProductsTable.Columns.Add("Tên Sản Phẩm", typeof(string)); // TENSP
                selectedProductsTable.Columns.Add("Số Lượng", typeof(int)); // SL
                selectedProductsTable.Columns.Add("Giá Tiền", typeof(decimal)); // GIATIEN
                selectedProductsTable.Columns.Add("Thành Tiền", typeof(decimal)); // SL * GIATIEN
            }
        }
        private void DisplayCartItems()
        {
            //// Hiển thị dữ liệu giỏ hàng trên DataGridView trong Form2
            //foreach (var item in cartItems)
            //{
            //    selectedProductsTable.Rows.Add(item.MASP, item.TENSP, item.SL, item.GIATIEN, item.SL * item.GIATIEN);
            //}
            InitializeSelectedProductsTable(); // Đảm bảo bảng được định nghĩa

            foreach (var item in cartItems)
            {
                selectedProductsTable.Rows.Add(
                    item.MASP,
                    item.TENSP,
                    item.SL,
                    item.GIATIEN,
                    item.SL * item.GIATIEN
                );
            }
        }

        private string SoThanhChu(string soTien)
        {
            try
            {
                int number = int.Parse(soTien);
                if (number == 0) return "Không đồng";

                string[] donVi = { "", "nghìn", "triệu", "tỷ" };
                string[] chuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string ketQua = "";
                int donViIndex = 0;

                while (number > 0)
                {
                    int n = number % 1000;
                    if (n > 0)
                    {
                        // Remove the đồng from DocBaChuSo result
                        string docSo = DocBaChuSo(n, chuSo);
                        if (donViIndex == 0)
                        {
                            // For the first group (thousands), format as "nghìn đồng"
                            ketQua = docSo + " " + donVi[donViIndex] + " đồng" + ketQua;
                        }
                        else
                        {
                            ketQua = docSo + " " + donVi[donViIndex] + " " + ketQua;
                        }
                    }
                    number /= 1000;
                    donViIndex++;
                }
                return ketQua.Trim();
            }
            catch
            {
                return "Số không hợp lệ";
            }
        }

        private string DocBaChuSo(int n, string[] chuSo)
        {
            string ketQua = "";
            int tram = n / 100;
            int chuc = (n % 100) / 10;
            int donVi = n % 10;

            if (tram > 0) ketQua += chuSo[tram] + " trăm ";

            if (chuc > 1)
            {
                ketQua += chuSo[chuc] + " mươi ";
                if (donVi > 0) ketQua += chuSo[donVi];
            }
            else if (chuc == 1)
            {
                ketQua += "mười ";
                if (donVi > 0) ketQua += chuSo[donVi];
            }
            else if (donVi > 0)
            {
                ketQua += "lẻ " + chuSo[donVi];
            }

            return ketQua.Trim();
        }

        private bool isTienMatSelected = false;
        private bool isMoMoSelected = false;
        private bool isChuyenKhoanSelected = false;
        private void btn_ttienMat_Click(object sender, EventArgs e)
        {
            isTienMatSelected = true;
            isMoMoSelected = false;
            isChuyenKhoanSelected = false;
            UpdateButtonStyles();
            picPay.BackgroundImage = null; // Không hiển thị hình ảnh cho Tiền mặt
            picPay.Image = null; // Xóa hình ảnh QR Code nếu có
        }
        private void btn_ttmoMo_Click(object sender, EventArgs e)
        {
            isMoMoSelected = !isMoMoSelected; // Toggle trạng thái
            isTienMatSelected = false; // Hủy chọn các nút khác
            isChuyenKhoanSelected = false;

            UpdateButtonStyles(); // Cập nhật giao diện

            if (isMoMoSelected)
            {
                // Hiển thị QR Code MoMo từ tệp ảnh
                picPay.Image = Image.FromFile(@"D:\POS\Images\momo_qrcode.jpg"); // Đảm bảo đường dẫn chính xác
                picPay.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo hình ảnh vừa khung
            }
            else
            {
                picPay.Image = null; // Xóa hình ảnh khi bỏ chọn
            }
        }

        private void btn_ttchuyenKhoan_Click(object sender, EventArgs e)
        {
            isChuyenKhoanSelected = !isChuyenKhoanSelected; // Toggle trạng thái
            isTienMatSelected = false; // Hủy chọn các nút khác
            isMoMoSelected = false;

            UpdateButtonStyles(); // Cập nhật giao diện

            if (isChuyenKhoanSelected)
            {
                // Hiển thị QR Code Chuyển Khoản từ tệp ảnh
                picPay.Image = Image.FromFile(@"D:\POS\Images\bank_qrcode.jpg"); // Đảm bảo đường dẫn chính xác
                picPay.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo hình ảnh vừa khung
            }
            else
            {
                picPay.Image = null; // Xóa hình ảnh khi bỏ chọn
            }
        }
        private Image GenerateQRCode(string qrCodeData)
        {
            // Tạo đối tượng QRCodeGenerator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeDataObj = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeDataObj);

            // Chuyển đổi QR Code thành hình ảnh
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
        private void UpdateButtonStyles()
        {
            // Cập nhật màu nền cho các nút dựa trên trạng thái
            btn_ttienMat.BackColor = isTienMatSelected ? Color.Blue : Color.White;
            btn_ttmoMo.BackColor = isMoMoSelected ? Color.Blue : Color.White;
            btn_ttchuyenKhoan.BackColor = isChuyenKhoanSelected ? Color.Blue : Color.White;
        }
        private void btn_quayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_taoHD_Click(object sender, EventArgs e)
        {
            //if (isTienMatSelected || isMoMoSelected || isChuyenKhoanSelected)
            //{
            //    string hinhThucThanhToan = "";

            //    if (isTienMatSelected)
            //        hinhThucThanhToan = "Tiền mặt";
            //    else if (isMoMoSelected)
            //        hinhThucThanhToan = "MoMo";
            //    else if (isChuyenKhoanSelected)
            //        hinhThucThanhToan = "Chuyển khoản";

            //    // Lấy thông tin hóa đơn
            //    string soTien = lbl_tienSo.Text;
            //    string tenKhachHang = lblKhach.Text; // Lấy tên khách hàng từ giao diện (nếu có)
            //    string maHoaDon = Guid.NewGuid().ToString().Substring(0, 11); // Tạo mã hóa đơn ngẫu nhiên

            //    try
            //    {
            //        // Tạo đối tượng hóa đơn
            //        HOADON hoaDon = new HOADON
            //        {
            //            MAHD = maHoaDon,
            //            TENKH = tenKhachHang,
            //            SL = int.Parse(lblSL.Text),
            //            THOIGIAN = DateTime.Now,
            //            HINHTHUC = hinhThucThanhToan
            //        };

            //        // Gọi lớp service để thêm hóa đơn vào cơ sở dữ liệu
            //        HoaDonService hoaDonService = new HoaDonService();
            //        hoaDonService.Add(hoaDon);

            //        MessageBox.Show("Hóa đơn đã được tạo thành công", "Thông báo");

            //        // Đóng form thanh toán và reset giỏ hàng
            //        this.Close();
            //        orderForm.ResetCart();


            //        //updateCTHD(maHoaDon, DataTable);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi tạo hóa đơn: " + ex.Message, "Lỗi");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Cảnh báo");
            //}
            if (isTienMatSelected || isMoMoSelected || isChuyenKhoanSelected)
            {
                string hinhThucThanhToan = isTienMatSelected ? "Tiền mặt" :
                                           isMoMoSelected ? "MoMo" : "Chuyển khoản";
                string maHoaDon = Guid.NewGuid().ToString().Substring(0, 11);

                try
                {
                    using (var dbContext = new POSContextDB())
                    {
                        // Tạo hóa đơn
                        HOADON hoaDon = new HOADON
                        {
                            MAHD = maHoaDon,
                            TENKH = lblKhach.Text,
                            SL = int.Parse(lblSL.Text),
                            THOIGIAN = DateTime.Now,
                            HINHTHUC = hinhThucThanhToan
                        };
                        dbContext.HOADON.Add(hoaDon);

                        // Tạo chi tiết hóa đơn
                        foreach (var item in cartItems)
                        {
                            CTHD cthd = new CTHD
                            {
                                MAHD = maHoaDon,
                                MASP = item.MASP,
                                SL = (int)item.SL,
                                GIATIEN = (decimal)(item.GIATIEN * item.SL),
                                HINHTHUC = hinhThucThanhToan
                            };
                            dbContext.CTHD.Add(cthd);

                            // Cập nhật số lượng trong kho
                            var sanPham = dbContext.SANPHAM.FirstOrDefault(sp => sp.MASP == item.MASP);
                            if (sanPham != null)
                            {
                                sanPham.SL -= item.SL;
                            }
                        }

                        dbContext.SaveChanges();
                        MessageBox.Show("Thanh toán thành công!", "Thông báo");
                        this.Hide();
                        orderForm.ResetCart(); // Reset giỏ hàng trong `frmOrder`
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Cảnh báo");
            }
        }

        private void frmPay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblKhach_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tienChu_Click(object sender, EventArgs e)
        {

        }

        private void frmPay_Load(object sender, EventArgs e)
        {

        }
    }
}

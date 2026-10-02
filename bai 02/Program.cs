using System;
using System.Collections.Generic;

abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private decimal _giaGoc;

    public string MaPT
    {
        get { return _maPT; }
        set { _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value; }
    }

    public string TenHang
    {
        get { return _tenHang; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ten hang khong duoc de trong!");
            _tenHang = value;
        }
    }

    public int NamSanXuat
    {
        get { return _namSanXuat; }
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException("Nam san xuat khong hop le!");
            _namSanXuat = value;
        }
    }

    public decimal GiaGoc
    {
        get { return _giaGoc; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Gia goc phai lon hon 0!");
            _giaGoc = value;
        }
    }

    public PhuongTien(string ma, string ten, int nam, decimal gia)
    {
        MaPT = ma;
        TenHang = ten;
        NamSanXuat = nam;
        GiaGoc = gia;
    }

    public abstract decimal TinhGiaLanBanh();

    public virtual string GetInfo()
    {
        return "Ma PT: " + MaPT +
               ", Ten hang: " + TenHang +
               ", Nam SX: " + NamSanXuat +
               ", Gia goc: " + GiaGoc.ToString("N0") + " VNĐ";
    }
}

class OTo : PhuongTien
{
    public int SoChoNgoi { get; set; }
    public double DungTichDongCo { get; set; }

    public OTo(string ma, string ten, int nam, decimal gia, int cho, double dungTich)
        : base(ma, ten, nam, gia)
    {
        if (cho <= 0)
            throw new ArgumentException("So cho ngoi phai lon hon 0!");

        if (dungTich <= 0)
            throw new ArgumentException("Dung tich dong co phai lon hon 0!");

        SoChoNgoi = cho;
        DungTichDongCo = dungTich;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
            return GiaGoc * 1.42m;

        return GiaGoc * 1.10m;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               ", So cho: " + SoChoNgoi +
               ", Dung tich dong co: " + DungTichDongCo + "L";
    }
}

class XeMay : PhuongTien
{
    public int DungTichXylanh { get; set; }

    public XeMay(string ma, string ten, int nam, decimal gia, int xylanh)
        : base(ma, ten, nam, gia)
    {
        DungTichXylanh = xylanh;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
            return GiaGoc * 1.02m;

        return GiaGoc * 1.05m;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               ", Dung tich xylanh: " + DungTichXylanh + "cc";
    }
}

class QuanLyPhuongTien
{
    private List<PhuongTien> ds = new List<PhuongTien>();

    public void AddPhuongTien(PhuongTien pt)
    {
        ds.Add(pt);
    }

    public void DisplayAll()
    {
        if (ds.Count == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        foreach (PhuongTien pt in ds)
        {
            Console.WriteLine(pt.GetInfo());
            Console.WriteLine("Gia lan banh: " +
                pt.TinhGiaLanBanh().ToString("N0") + " VNĐ");
            Console.WriteLine();
        }
    }

    public PhuongTien FindMaxGiaLanBanh()
    {
        if (ds.Count == 0)
            return null;

        PhuongTien max = ds[0];

        foreach (PhuongTien pt in ds)
        {
            if (pt.TinhGiaLanBanh() > max.TinhGiaLanBanh())
                max = pt;
        }

        return max;
    }

    public void SearchByName(string keyword)
    {
        bool timThay = false;

        foreach (PhuongTien pt in ds)
        {
            if (pt.TenHang.ToLower().Contains(keyword.ToLower()))
            {
                Console.WriteLine(pt.GetInfo());
                Console.WriteLine("Gia lan banh: " +
                    pt.TinhGiaLanBanh().ToString("N0") + " VNĐ");
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay)
            Console.WriteLine("Khong tim thay phuong tien!");
    }
}

class Program
{
    static void Main()
    {
        QuanLyPhuongTien ql = new QuanLyPhuongTien();
        int chon;

        do
        {
            Console.WriteLine("===== QUAN LY HE THONG PHUONG TIEN =====");
            Console.WriteLine("1. Them o to");
            Console.WriteLine("2. Them xe may");
            Console.WriteLine("3. Hien thi danh sach");
            Console.WriteLine("4. Tim gia lan banh cao nhat");
            Console.WriteLine("5. Tim theo ten hang");
            Console.WriteLine("0. Thoat");
            Console.Write("Nhap lua chon: ");

            chon = int.Parse(Console.ReadLine());

            try
            {
                if (chon == 1)
                {
                    Console.Write("Nhap ma PT: ");
                    string ma = Console.ReadLine();

                    Console.Write("Nhap ten hang: ");
                    string ten = Console.ReadLine();

                    Console.Write("Nhap nam san xuat: ");
                    int nam = int.Parse(Console.ReadLine());

                    Console.Write("Nhap gia goc: ");
                    decimal gia = decimal.Parse(Console.ReadLine());

                    Console.Write("Nhap so cho ngoi: ");
                    int cho = int.Parse(Console.ReadLine());

                    Console.Write("Nhap dung tich dong co: ");
                    double dungTich = double.Parse(Console.ReadLine());

                    ql.AddPhuongTien(
                        new OTo(ma, ten, nam, gia, cho, dungTich)
                    );

                    Console.WriteLine("Them o to thanh cong!");
                }
                else if (chon == 2)
                {
                    Console.Write("Nhap ma PT: ");
                    string ma = Console.ReadLine();

                    Console.Write("Nhap ten hang: ");
                    string ten = Console.ReadLine();

                    Console.Write("Nhap nam san xuat: ");
                    int nam = int.Parse(Console.ReadLine());

                    Console.Write("Nhap gia goc: ");
                    decimal gia = decimal.Parse(Console.ReadLine());

                    Console.Write("Nhap dung tich xylanh: ");
                    int xylanh = int.Parse(Console.ReadLine());

                    ql.AddPhuongTien(
                        new XeMay(ma, ten, nam, gia, xylanh)
                    );

                    Console.WriteLine("Them xe may thanh cong!");
                }
                else if (chon == 3)
                {
                    ql.DisplayAll();
                }
                else if (chon == 4)
                {
                    PhuongTien max = ql.FindMaxGiaLanBanh();

                    if (max == null)
                        Console.WriteLine("Danh sach rong!");
                    else
                    {
                        Console.WriteLine(max.GetInfo());
                        Console.WriteLine("Gia lan banh: " +
                            max.TinhGiaLanBanh().ToString("N0") + " VNĐ");
                    }
                }
                else if (chon == 5)
                {
                    Console.Write("Nhap ten hang can tim: ");
                    ql.SearchByName(Console.ReadLine());
                }
                else if (chon == 0)
                {
                    Console.WriteLine("Ket thuc chuong trinh!");
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Du lieu nhap khong hop le!");
            }

            Console.WriteLine();

        } while (chon != 0);
    }
}

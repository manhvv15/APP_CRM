using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppCRM.Views.CaiDat.CaiDatTongDaiDienThoai
{
    /// <summary>
    /// Interaction logic for frmKetNoiTongDaiDienThoai.xaml
    /// </summary>
    public partial class frmKetNoiTongDaiDienThoai : Window
    {
        private Model.APIEntity.DataLogin_Employee DataEmp;
        public frmKetNoiTongDaiDienThoai(Model.APIEntity.DataLogin_Employee dtE)
        {
            InitializeComponent();
            DataEmp = dtE;
            if(clsBien.TrangThaiTongDai=="Đã kết nối")
            {
                btnKetNoi.Visibility = Visibility.Collapsed;
                btnHuyKetNoi.Visibility = Visibility.Visible;
            }
            else if(clsBien.TrangThaiTongDai=="Kết nối")
            {
                btnKetNoi.Visibility = Visibility.Visible;
                btnHuyKetNoi.Visibility = Visibility.Collapsed;
            }
            tb_NhapThongTin.Text = "HNCX00440";
            tb_MatKhau.Password = "RLFTq3u4XMZlB4B";
            tb_Domain.Text = "hncx00440.oncall";
        }

        private void btnKetNoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dialogKetNoiLaiTongDai dialog = new dialogKetNoiLaiTongDai("Kết nối tổng đài",DataEmp);
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
            {
                btnKetNoi.Visibility = Visibility.Collapsed;
                btnHuyKetNoi.Visibility = Visibility.Visible;
                clsBien.TrangThaiTongDai = "Đã kết nối";
            }
            
        }
        private void btnHuyKetNoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dialogKetNoiLaiTongDai dialog = new dialogKetNoiLaiTongDai("Huỷ kết nối tổng đài",DataEmp);
            dialog.ShowDialog();
            if(dialog.DialogResult.HasValue && dialog.DialogResult.Value)
            {
                btnKetNoi.Visibility = Visibility.Visible;
                btnHuyKetNoi.Visibility = Visibility.Collapsed;
                clsBien.TrangThaiTongDai = "Kết nối";
            }
            
        }
    }
}

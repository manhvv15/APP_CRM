﻿using System;
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

namespace AppCRM.Views.CaiDat.Email
{
    /// <summary>
    /// Interaction logic for frmHuyLuuKetNoiEmail.xaml
    /// </summary>
    public partial class frmHuyLuuKetNoiEmail : Window
    {
        public frmHuyLuuKetNoiEmail()
        {
            InitializeComponent();
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}

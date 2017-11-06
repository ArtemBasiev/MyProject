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
using System.Windows.Xps.Packaging;
using Microsoft.Win32;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraRichEdit;


namespace GreatestApplicatioInMyLife
{
    /// <summary>
    /// Логика взаимодействия для instruction.xaml
    /// </summary>
    public partial class instruction : Window
    {
        public instruction()
        {
            InitializeComponent();
        }

        private void navBarItem1_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\mainwindow.html");
            wb_main.Source=uric;
        }

        private void navBarItem2_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\doctypes.html");
            wb_main.Source = uric;
        }

        private void navBarItem3_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\docadd.html");
            wb_main.Source = uric;
        }

        private void navBarDer1_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\ditypes.html");
            wb_main.Source = uric;
        }

        private void navBarDer2_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\diadd.html");
            wb_main.Source = uric;
        }

        private void navBarRep1_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\reptypes.html");
            wb_main.Source = uric;
        }

        private void navBarRep2_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\repadd.html");
            wb_main.Source = uric;
        }

        private void navBarWp1_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\wp.html");
            wb_main.Source = uric;
        }

        private void navBarWp2_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\wpadd.html");
            wb_main.Source = uric;
        }

        private void barAdm1_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\adminwindow.html");
            wb_main.Source = uric;
        }

        private void barAdm2_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\roles.html");
            wb_main.Source = uric;
        }

        private void barAdm3_Click(object sender, EventArgs e)
        {
            Uri uric = new Uri("C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\insdocs\\adminpas.html");
            wb_main.Source = uric;
        }

        private void avBarItem3_Click(object sender, EventArgs e)
        {

        }

      
 
    }
}

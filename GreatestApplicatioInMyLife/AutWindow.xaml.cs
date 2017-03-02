using System;
using System.Security;
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
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using DevExpress.Xpf;
using DevExpress.XtraGrid;

namespace GreatestApplicatioInMyLife
{
    /// <summary>
    /// Логика взаимодействия для AutWindow.xaml
    /// </summary>
    public partial class AutWindow : Window
    {
        public FbConnection fb;
        public AutWindow()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow openmain = new MainWindow();

            //InsertDialog openinsert = new InsertDialog();
            FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

            fb_con.Charset = "UTF8";
            fb_con.UserID = "SYSDBA";
            fb_con.Password = "masterkey";
            fb_con.Database = "C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\DB\\MAINDB.fdb";
            fb_con.ServerType = 0;

            fb = new FbConnection(fb_con.ToString());


            try
            {
                fb.Open();
                //openinsert.conforins = this;

                openmain.preh = this;
                openmain.Show();
                this.Close();
            }

            catch
            {

                System.Windows.MessageBox.Show("Введенные данные неверны");


            }
        }
    }
}

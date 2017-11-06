using FirebirdSql.Data.FirebirdClient;
using GreatestApplicatioInMyLife.UserControls;
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

namespace GreatestApplicatioInMyLife
{
    public partial class Insert_Cus : Window
    {

        public uc_dockpanel_di con_ins_cus;
        public Insert_Cus()
        {
            InitializeComponent();
        }

        private void bt_create_cus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FbCommand sqlforin = new FbCommand("INS_OBJECTS", con_ins_cus.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fname.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sname.Text;
                sqlforin.ExecuteNonQuery();


                tb_fname.Clear();
                tb_sname.Clear();

                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }
    }
}

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
                FbCommand sqlforin = new FbCommand("INS_CUS", con_ins_cus.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@NAME", FbDbType.VarChar).Value = tb_name_cus.Text;
                sqlforin.Parameters.Add("@CONT_NAME", FbDbType.VarChar).Value = tb_conname.Text;
                sqlforin.Parameters.Add("@ADR", FbDbType.VarChar).Value = tb_adr_cus.Text;
                sqlforin.Parameters.Add("@TEL", FbDbType.VarChar).Value = tb_tel_cus.Text;
                sqlforin.Parameters.Add("@INN", FbDbType.VarChar).Value = tb_inn_cus.Text;
                sqlforin.ExecuteNonQuery();


                tb_name_cus.Clear();
                tb_conname.Clear();
                tb_adr_cus.Clear();
                tb_inn_cus.Clear();
                tb_tel_cus.Clear();
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }
    }
}

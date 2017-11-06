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
    /// <summary>
    /// Логика взаимодействия для Insert_Prov.xaml
    /// </summary>
    public partial class Insert_Prov : Window
    {

        public uc_dockpanel_di con_ins_prov;
        public Insert_Prov()
        {
            InitializeComponent();
        }

        private void bt_create_prov_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FbCommand sqlforin = new FbCommand("INS_CONTRACTORS", con_ins_prov.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.VarChar).Value = "pro";
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fname_prov.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sname_prov.Text;
                sqlforin.Parameters.Add("@ADR", FbDbType.VarChar).Value = tb_adr_prov.Text;
                sqlforin.Parameters.Add("@INN", FbDbType.VarChar).Value = tb_inn_prov.Text;
                sqlforin.Parameters.Add("@TEL", FbDbType.VarChar).Value = tb_tel_prov.Text;
                sqlforin.Parameters.Add("@CONT_NAME", FbDbType.VarChar).Value = tb_contname_prov.Text;
                sqlforin.Parameters.Add("@POS", FbDbType.VarChar).Value = null;
                sqlforin.ExecuteNonQuery();


                tb_contname_prov.Clear();
                tb_sname_prov.Clear();
                tb_fname_prov.Clear();
                tb_adr_prov.Clear();
                tb_inn_prov.Clear();
                tb_tel_prov.Clear();
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }
    }
}

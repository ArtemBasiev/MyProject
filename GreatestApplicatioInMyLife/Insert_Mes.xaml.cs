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
    public partial class Insert_Mes : Window
    {


        public uc_dockpanel_di con_ins_mes;
        public Insert_Mes()
        {
            InitializeComponent();
        }

        private void bt_create_mes_Click(object sender, RoutedEventArgs e)
        {

            //if (tb_fn_mes.Text=="")
            //{ System.Windows.MessageBox.Show("Введите полное наименование единицы измерения!"); }
            //else if (tb_sn_mes.Text == "")
            //{ System.Windows.MessageBox.Show("Введите сокращенное наименование единицы измерения!"); }
            
                try
                {
                    FbCommand sqlforin = new FbCommand("INS_MES", con_ins_mes.presh.preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fn_mes.Text;
                    sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sn_mes.Text;
                    sqlforin.ExecuteNonQuery();


                    tb_fn_mes.Clear();
                    tb_sn_mes.Clear();
                    System.Windows.MessageBox.Show("Запись успешно добавлена!");
                }


                catch
                {
                    System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
                }
            
        }
    }
}

using FirebirdSql.Data.FirebirdClient;
using GreatestApplicatioInMyLife.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
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

    public partial class Insert_War : Window
    {
        public uc_dockpanel_di con_ins_war;
        public Insert_War()
        {
            InitializeComponent();
        }




        private void bt_create_war_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                FbCommand sqlforin = new FbCommand("INS_WAR", con_ins_war.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fn_war.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sn_war.Text;
                sqlforin.Parameters.Add("@ADR", FbDbType.VarChar).Value = tb_adr_war.Text;
      
                sqlforin.ExecuteNonQuery();


                tb_fn_war.Clear();
                tb_sn_war.Clear();
                tb_adr_war.Clear();
         
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }

    
    
    }
}

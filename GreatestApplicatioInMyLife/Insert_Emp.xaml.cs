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
    
    public partial class Insert_Emp : Window
    {

        public uc_dockpanel_di con_ins_emp;
        public Insert_Emp()
        {
            InitializeComponent();
        }

        private void bt_create_emp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FbCommand sqlforin = new FbCommand("INS_EMP", con_ins_emp.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fn_emp.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sn_emp.Text;
                sqlforin.Parameters.Add("@INN", FbDbType.VarChar).Value = tb_inn_emp.Text;
                sqlforin.Parameters.Add("@POS", FbDbType.VarChar).Value = tb_pos_emp.Text;
                sqlforin.ExecuteNonQuery();


                tb_fn_emp.Clear();
                tb_sn_emp.Clear();
                tb_inn_emp.Clear();
                tb_pos_emp.Clear();
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }
    }
}

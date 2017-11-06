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
    /// Логика взаимодействия для insert_di_char.xaml
    /// </summary>
    public partial class insert_di_char : Window
    {

        public uc_dockpanel_di con;
        public insert_di_char()
        {
            InitializeComponent();
        }

        private void bt_create_cus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FbCommand sqlforin = new FbCommand("IUD_DI_CHAR", con.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.VarChar).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.VarChar).Value = null;
                sqlforin.Parameters.Add("@ID_TYPE", FbDbType.VarChar).Value = con.grid_tree.GetFocusedRowCellValue("ID");
                sqlforin.Parameters.Add("@NAME", FbDbType.VarChar).Value = tb_fname.Text;
               
                sqlforin.ExecuteNonQuery();


                tb_fname.Clear();
                

                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }

        private void bt_can_cr_cus_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

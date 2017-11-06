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
    /// <summary>
    /// Логика взаимодействия для add_group_nom.xaml
    /// </summary>
    public partial class add_group_nom : Window
    {
        public uc_dockpanel_di con;
        public add_group_nom()
        {
            InitializeComponent();
        }

        private void bt_create_group_Click(object sender, RoutedEventArgs e)
        {
             try
            {



                FbCommand sqlforin = new FbCommand("IUD_CHAR_GROUP", con.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value =null;
                 sqlforin.Parameters.Add("@NAME", FbDbType.VarChar).Value = name.Text;
               
      
                sqlforin.ExecuteNonQuery();


                  this.Close();

         
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }
        
    }
}

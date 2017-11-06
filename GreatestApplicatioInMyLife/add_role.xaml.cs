using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using GreatestApplicatioInMyLife.UserControls;

namespace GreatestApplicatioInMyLife
{
    /// <summary>
    /// Логика взаимодействия для add_role.xaml
    /// </summary>
    public partial class add_role : Window
    {

        public Admin_panel con;
        public add_role()
        {
            InitializeComponent();
        }


       

        private void bt_create_arr_Click(object sender, RoutedEventArgs e)
        {
            try
            {




                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_ROLES", con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = null;
                sqlforin.Parameters.Add("@ID_NAME", FbDbType.Date).Value = name.Text;
            


              
                sqlforin.ExecuteNonQuery();



                this.Close();
                con.grid_roles.ItemsSource = con.dt_grid_roles();
                con.prop_grid_roles(con.grid_roles);
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
              

            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }

        }


        private void bt_can_cr_arr_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

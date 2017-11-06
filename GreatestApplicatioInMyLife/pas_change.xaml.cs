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
using DevExpress.Xpf.Editors;
using DevExpress.XtraGrid;
using GreatestApplicatioInMyLife.UserControls;
using System.IO;

namespace GreatestApplicatioInMyLife
{
    /// <summary>
    /// Логика взаимодействия для pas_change.xaml
    /// </summary>
    public partial class pas_change : Window
    {
        public Admin_panel conec;

        public pas_change()
        {
            InitializeComponent();
        }

        private void oldpas_GotFocus(object sender, RoutedEventArgs e)
        {
            bt_change_pas.IsEnabled = true;
        }

        private void bt_change_pas_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                ////////////////////////////////Процедура проверки пароля
                FbCommand sqlpas = new FbCommand("select * from CHECK_ADMIN_PAS('" + oldpas.Text + "')", conec.preh.fb);
                FbDataReader readerpas = sqlpas.ExecuteReader();
                DataTable dt_pas = new DataTable();
                dt_pas.Load(readerpas);
                if (dt_pas.Rows[0][0].ToString() == "1")
                {
                    System.Windows.MessageBox.Show("Введенный вами старый пароль неверный!");
                }
                else
                {
                    try
                    {
                        if (newpas.Text == "")
                        {
                            System.Windows.MessageBox.Show("Введите новый пароль!");
                        }
                        else
                        {
                            //Команда изменения
                            FbCommand sqlforin = new FbCommand("CHANGE_ADMIN_PAS", conec.preh.fb);
                            sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforin.Parameters.Add("@PAS", FbDbType.VarChar).Value = newpas.Text;

                            sqlforin.ExecuteNonQuery();
                            this.Close();
                            System.Windows.MessageBox.Show("Пароль успешно изменен!");
                        }
                                      
 
                    }

                    catch
                    {

                        System.Windows.MessageBox.Show("Введенный вами новый пароль неккоректен!");


                    }
                }


            }
            catch { System.Windows.MessageBox.Show("Укажите все необходимые данные!"); }
        }
    }
}

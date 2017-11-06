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
    /// Логика взаимодействия для add_user.xaml
    /// </summary>
    public partial class add_user : Window
    {
        public Admin_panel con;

        public add_user()
        {
            InitializeComponent();
        }

        /////////////////////Заполнение комбобокса поставщики------------------------
        public void load_cb_prov()
        {
            cb_emp.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from SEL_EMP_CB", con.preh.fb);

            FbDataReader readercomb = sqlforcomb.ExecuteReader();

            if (readercomb.HasRows) // если есть данные
            {

                DataSet newset1 = new DataSet("newset1");
                DataTable dtcomb = new DataTable();
                while (readercomb.Read())
                {
                    try
                    {
                        string resultvalue = readercomb.GetString(0);
                        cb_emp.Items.Add(resultvalue);
                    }
                    catch { }

                }
            }
        }



        private void window_add_arr_Activated(object sender, EventArgs e)
        {
            load_cb_prov();
            //dp_cr_date_arr.Text = DateTime.Today.ToString();
        }

        private void bt_create_arr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              



                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_USERS", con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = null;
                sqlforin.Parameters.Add("@ID_ROLE", FbDbType.Date).Value = con.grid_roles.GetFocusedRowCellValue("ID").ToString() ;
                sqlforin.Parameters.Add("@NAME_RES", FbDbType.VarChar).Value = cb_emp.Text;
                sqlforin.Parameters.Add("@PAS", FbDbType.Integer).Value = pas.Text;


                //FbDataReader reader_ret_id = sqlforin.ExecuteReader();
                //DataTable dt_ret_id = new DataTable();
                //dt_ret_id.Load(reader_ret_id);
                //con.return_id_doc = dt_ret_id.Rows[0][0].ToString();
                sqlforin.ExecuteNonQuery();



                //dp_cr_date_arr.Text =DateTime.Today.ToString();
                //cb_prov.Clear();
                //comment_arr.Clear();
                this.Close();
                con.grid_roles.ItemsSource = con.dt_grid_roles();
                con.prop_grid_roles(con.grid_roles);
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
                //add_details_arr open_add_det = new add_details_arr();
                //open_add_det.con1 = this;

                //open_add_det.ShowDialog();

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

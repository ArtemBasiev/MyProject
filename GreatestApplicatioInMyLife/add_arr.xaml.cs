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
    public partial class add_arr : Window
    {

        public MainWindow con;
        public add_arr()
        {
            InitializeComponent();
        }

        /////////////////////Заполнение комбобокса поставщики------------------------
        public void load_cb_prov()
        {
            cb_prov.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_PROV", con.preh.fb);

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
                        cb_prov.Items.Add(resultvalue);
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
            //Вытаскиваем ID поставщика
            FbCommand sqlforcombsrav = new FbCommand("select ID from GET_ID_CONTR where SN ='" + cb_prov.Text + "'", con.preh.fb);
            FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
            DataTable wdf = new DataTable();
            wdf.Load(readercombsrav);



            //Команда добавления
            FbCommand sqlforin = new FbCommand("IUD_DOCUMENT_ARRIVE", con.preh.fb);
            sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
            sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
            sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = 0;
            sqlforin.Parameters.Add("@CREATOR", FbDbType.Date).Value = con.preh.id_main_res.ToString();
            sqlforin.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = comment_arr.Text;
            sqlforin.Parameters.Add("@CONTRACTOR", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();
            sqlforin.Parameters.Add("@ID_WH", FbDbType.Integer).Value = con.preh.id_main_war.ToString();


            //FbDataReader reader_ret_id = sqlforin.ExecuteReader();
            //DataTable dt_ret_id = new DataTable();
            //dt_ret_id.Load(reader_ret_id);
            //con.return_id_doc = dt_ret_id.Rows[0][0].ToString();
            sqlforin.ExecuteNonQuery();

            

            //dp_cr_date_arr.Text =DateTime.Today.ToString();
            //cb_prov.Clear();
            //comment_arr.Clear();
            this.Close();
            con.gc_arrive_list.ItemsSource = con.dt_grid_list_arrived();
            con.prop_grid_arr(con.gc_arrive_list);
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

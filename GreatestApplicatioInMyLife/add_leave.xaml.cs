using FirebirdSql.Data.FirebirdClient;
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
    /// Логика взаимодействия для add_leave.xaml
    /// </summary>
    public partial class add_leave : Window
    {

         public MainWindow con;
      
        public add_leave()
        {
            InitializeComponent();
        }

        /////////////////////Заполнение комбобокса поставщики------------------------
        public void load_cb_obj()
        {
            cb_obj.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_OBJ", con.preh.fb);

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
                        cb_obj.Items.Add(resultvalue);
                    }
                    catch { }

                }
            }
        }



        private void window_add_arr_Activated(object sender, EventArgs e)
        {
            load_cb_obj();
          
        }

        private void bt_create_leave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Вытаскиваем ID объекта
                FbCommand sqlforcombsrav = new FbCommand("select ID from GET_ID_OBJ where SN ='" + cb_obj.Text + "'", con.preh.fb);
                FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
                DataTable wdf = new DataTable();
                wdf.Load(readercombsrav);

  

                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_DOCUMENT_LEAVE", con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = 0;
                sqlforin.Parameters.Add("@CREATOR", FbDbType.Date).Value = con.preh.id_main_res.ToString();
                sqlforin.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = comment_arr.Text;
                sqlforin.Parameters.Add("@ID_WH", FbDbType.Integer).Value = con.preh.id_main_war.ToString();
                sqlforin.Parameters.Add("@ID_OBJECT", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();

                sqlforin.ExecuteNonQuery();


                this.Close();
                con.gc_leave_list.ItemsSource = con.dt_grid_list_leave();
                con.prop_grid_leave(con.gc_leave_list);
                System.Windows.MessageBox.Show("Запись успешно добавлена!");


            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }

        }


        private void bt_can_cr_leave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

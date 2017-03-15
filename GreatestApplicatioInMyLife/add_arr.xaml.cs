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
            dp_cr_date_arr.Text = DateTime.Today.ToString();
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

            //Вытаскиваем ID типа документа
            FbCommand sqlforiddoc = new FbCommand("select ID from GET_ID_TYPE_DOC where FN ='Приход'", con.preh.fb);
            FbDataReader readeriddoc = sqlforiddoc.ExecuteReader();
            DataTable dt_id_doc = new DataTable();
            dt_id_doc.Load(readeriddoc);

            //Команда добавления
            FbCommand sqlforin = new FbCommand("INS_ARR", con.preh.fb);
            sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
            sqlforin.Parameters.Add("@T_DOC", FbDbType.Integer).Value = dt_id_doc.Rows[0][0].ToString();
            sqlforin.Parameters.Add("@CR_DATE", FbDbType.Date).Value = dp_cr_date_arr.Text;
            sqlforin.Parameters.Add("@COM", FbDbType.VarChar).Value = comment_arr.Text;
            sqlforin.Parameters.Add("@SUMM", FbDbType.Decimal).Value = 0;
            sqlforin.Parameters.Add("@CONTR", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();


            FbDataReader reader_ret_id = sqlforin.ExecuteReader();
            DataTable dt_ret_id = new DataTable();
            dt_ret_id.Load(reader_ret_id);
            con.return_id_doc = dt_ret_id.Rows[0][0].ToString();
            sqlforin.ExecuteNonQuery();

            

            dp_cr_date_arr.Text =DateTime.Today.ToString();
            cb_prov.Clear();
            comment_arr.Clear();
            System.Windows.MessageBox.Show("Запись успешно добавлена!");
            add_details_arr open_add_det = new add_details_arr();
            open_add_det.con1 = this;
            this.Close();
            open_add_det.ShowDialog();
           
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

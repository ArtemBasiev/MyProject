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
    public partial class Insert_Nom : Window
    {

        public uc_dockpanel_di con;
        public Insert_Nom()
        {
            InitializeComponent();
        }

        
        
        ////----------------------------Заполнение комбобокса тип номенклатуры----------------------
        public void  load_cb_nom()
        {
            cb_type_nom.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from PROC_GET_TYPE_NOM", con.presh.preh.fb);

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
                        cb_type_nom.Items.Add(resultvalue);
                    }
                    catch { }

                }



            }
        }


        ////----------------------------Заполнение комбобокса группа----------------------
        public void load_cb_group()
        {
            cb_group_nom.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_KIND_NOM", con.presh.preh.fb);

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
                        cb_group_nom.Items.Add(resultvalue);
                    }
                    catch { }

                }



            }
        }



        ////----------------------------Заполнение комбобокса единицы измерения----------------------
        public void load_cb_mes()
        {
            cb_mes.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_MEASURE", con.presh.preh.fb);
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
                        cb_mes.Items.Add(resultvalue);
                    }
                    catch { }

                }



            }
        }




        //-----------------------------------------------Событие активации окна--------------
        private void window_unity_di_Activated(object sender, EventArgs e)
        {
            load_cb_nom();
            load_cb_group();
            load_cb_mes();
        }

        private void bt_add_group_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_create_nom_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Вытаскиваем ID типа номенклатуры
                FbCommand sqlforcombsrav = new FbCommand("select ID_TYPE from GET_ID_TYPE_NOM where FN ='" + cb_type_nom.Text + "'", con.presh.preh.fb);
                FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
                DataTable wdf = new DataTable();
                wdf.Load(readercombsrav);


                //Вытаскиваем ID группы
                FbCommand sqlforcom_group = new FbCommand("select ID_KIND from GET_ID_KIND_NOM where FN ='" + cb_group_nom.Text + "'", con.presh.preh.fb);
                FbDataReader reader_id_group = sqlforcom_group.ExecuteReader();
                DataTable dt_id_group = new DataTable();
                dt_id_group.Load(reader_id_group);

                //Вытаскиваем ID единицы измерения
                FbCommand sqlforcom_mes = new FbCommand("select ID_MES from GET_ID_MES where FN ='" + cb_mes.Text + "'", con.presh.preh.fb);
                FbDataReader readercom_mes = sqlforcom_mes.ExecuteReader();
                DataTable dt_id_mes = new DataTable();
                dt_id_mes.Load(readercom_mes);

                string jkg = dt_id_mes.Rows[0][0].ToString();

                //Команда добавления
                FbCommand sqlforin = new FbCommand("INS_NOM", con.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fn_nom.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sn_nom.Text;
                sqlforin.Parameters.Add("@TNOM", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();
                sqlforin.Parameters.Add("@MES", FbDbType.Integer).Value = dt_id_mes.Rows[0][0].ToString();
                sqlforin.Parameters.Add("@KNOM", FbDbType.Integer).Value = dt_id_group.Rows[0][0].ToString();
                sqlforin.Parameters.Add("@ART", FbDbType.VarChar).Value = tb_art.Text;
                sqlforin.Parameters.Add("@PURCH", FbDbType.Decimal).Value = calc_purch.Text;
                sqlforin.Parameters.Add("@SEL", FbDbType.Decimal).Value = calc_sel.Text;
                sqlforin.ExecuteNonQuery();
               

                    tb_fn_nom.Clear();
                    tb_sn_nom.Clear();
                    cb_type_nom.Clear();
                    cb_group_nom.Clear();
                    cb_mes.Clear();
                    tb_art.Clear();
                    calc_purch.Clear();
                    calc_sel.Clear();
                    System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }

        private void bt_can_cr_nom_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

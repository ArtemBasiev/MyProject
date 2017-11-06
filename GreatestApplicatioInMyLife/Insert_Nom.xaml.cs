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
using System.ComponentModel;


namespace GreatestApplicatioInMyLife
{
    public partial class Insert_Nom : Window
    {
        //public DataTable dt_for_char ;
        DataTable dt_for_char = new DataTable();
        public uc_dockpanel_di con;
        public Insert_Nom()
        {
            InitializeComponent();
        }

        
        
        //////----------------------------Заполнение комбобокса тип номенклатуры----------------------
        //public void  load_cb_nom()
        //{
        //    cb_type_nom.Items.Clear();
        //    FbCommand sqlforcomb = new FbCommand("select * from PROC_GET_TYPE_NOM", con.presh.preh.fb);

        //    FbDataReader readercomb = sqlforcomb.ExecuteReader();

        //    if (readercomb.HasRows) // если есть данные
        //    {

        //        DataSet newset1 = new DataSet("newset1");
        //        DataTable dtcomb = new DataTable();
        //        while (readercomb.Read())
        //        {
        //            try
        //            {
        //                string resultvalue = readercomb.GetString(0);
        //                cb_type_nom.Items.Add(resultvalue);
        //            }
        //            catch { }

        //        }



        //    }
        //}


        //////----------------------------Заполнение комбобокса группа----------------------
        //public void load_cb_group()
        //{
        //    cb_group_nom.Items.Clear();
        //    FbCommand sqlforcomb = new FbCommand("select * from GET_KIND_NOM", con.presh.preh.fb);

        //    FbDataReader readercomb = sqlforcomb.ExecuteReader();

        //    if (readercomb.HasRows) // если есть данные
        //    {

        //        DataSet newset1 = new DataSet("newset1");
        //        DataTable dtcomb = new DataTable();
        //        while (readercomb.Read())
        //        {
        //            try
        //            {
        //                string resultvalue = readercomb.GetString(0);
        //                cb_group_nom.Items.Add(resultvalue);
        //            }
        //            catch { }

        //        }



        //    }
        //}




        //////----------------------------Заполнение grid group nom---------------------
        //public void load_gr_group()
        //{
        //    DataTable dt = new DataTable();
        //    //flag = false;
        //    if (con.presh.preh.fb.State == ConnectionState.Closed)
        //    { con.presh.preh.fb.Open(); }
        //    FbCommand command = new FbCommand("select * from LOAD_TYPE_NOM", con.presh.preh.fb);
        //    FbDataReader reader = command.ExecuteReader();
        //    dt.Load(reader);
        //    dt.Columns[0].ColumnName = "ID";
        //    dt.Columns[1].ColumnName = "Тип номенклатуры";
        //    dt.Columns[2].ColumnName = "Группа";
           
  
        //    grid_group_nom.ItemsSource = dt;

        //    grid_group_nom.Columns[0].Visible = false;

        //    grid_group_nom.Columns[1].GroupIndex = 0;

           
        //    grid_group_nom.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
        //    grid_group_nom.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
        //    //flag = true;
        //    //return dt;
        //}





        //////----------------------------Заполнение комбобокса характеристика----------------------
        //public void load_cb_char()
        //{
        //    cb_char.Items.Clear();
        //    FbCommand sqlforcomb = new FbCommand("select * from GET_CHAR_FOR_COMB", con.presh.preh.fb);
        //    FbDataReader readercomb = sqlforcomb.ExecuteReader();

        //    if (readercomb.HasRows) // если есть данные
        //    {

        //        DataSet newset1 = new DataSet("newset1");
        //        DataTable dtcomb = new DataTable();
        //        while (readercomb.Read())
        //        {
        //            try
        //            {
        //                string resultvalue = readercomb.GetString(0);
        //                cb_char.Items.Add(resultvalue);
        //            }
        //            catch { }

        //        }



        //    }
        //}


        //////----------------------------Заполнение комбобокса значения характеристик----------------------
        //public void load_cb_values()
        //{
        //    cb_values.Items.Clear();
        //    FbCommand sqlforcomb = new FbCommand("select NAME_VAL from GET_VALUES_FOR_COMB where NAME_CHAR ='"+cb_char.Text+"'", con.presh.preh.fb);
        //    FbDataReader readercomb = sqlforcomb.ExecuteReader();

        //    if (readercomb.HasRows) // если есть данные
        //    {

        //        DataSet newset1 = new DataSet("newset1");
        //        DataTable dtcomb = new DataTable();
        //        while (readercomb.Read())
        //        {
        //            try
        //            {
        //                string resultvalue = readercomb.GetString(0);
        //                cb_values.Items.Add(resultvalue);
        //            }
        //            catch { }

        //        }



        //    }
        //}


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

            
            //load_cb_char();
            //load_gr_group();
            load_cb_mes();
        }




        //////-----------------------------------------------С------------
        //private void bt_create_nom_Click(object sender, RoutedEventArgs e)
        //{


           
        //}

        private void bt_can_cr_nom_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }





        private void grid_group_nom_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void bt_save_nom_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Вытаскиваем ID единицы измерения
                FbCommand sqlforcom_mes = new FbCommand("select ID_MES from GET_ID_MES where FN ='" + cb_mes.Text + "'", con.presh.preh.fb);
                FbDataReader readercom_mes = sqlforcom_mes.ExecuteReader();
                DataTable dt_id_mes = new DataTable();
                dt_id_mes.Load(readercom_mes);

                //string jkg = grid_group_nom.GetFocusedRowCellValue("ID").ToString();

                //Команда добавления
                FbCommand sqlforin = new FbCommand("NOM_UPD_FOR_INS", con.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fn_nom.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sn_nom.Text;
                sqlforin.Parameters.Add("@KN", FbDbType.Integer).Value = con.grid_tree.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@MES", FbDbType.Integer).Value = dt_id_mes.Rows[0][0].ToString();
                sqlforin.Parameters.Add("@ART", FbDbType.VarChar).Value = tb_art.Text;
                sqlforin.ExecuteNonQuery();


                ////Команда добавления характеристик


                //if (grid_added_char.VisibleRowCount >0)
                //{
                //for (int i=0; i < grid_added_char.VisibleRowCount; i++)
                //{

                //    FbCommand sqlforin_char = new FbCommand("INS_CHAR_FROM_GRID", con.presh.preh.fb);
                //    sqlforin_char.CommandType = System.Data.CommandType.StoredProcedure;
                //    sqlforin_char.Parameters.Add("@NAME_CHAR", FbDbType.VarChar).Value = grid_added_char.GetCellValue(i, "Характеристика").ToString();
                //    sqlforin_char.Parameters.Add("@PRICE", FbDbType.VarChar).Value = grid_added_char.GetCellValue(i, "Учетная цена").ToString();
                //    sqlforin_char.ExecuteNonQuery();

                //}

                //      }

                tb_fn_nom.Clear();
                tb_sn_nom.Clear();
                cb_mes.Clear();
                tb_art.Clear();

                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }

        //private void bt_back_Click(object sender, RoutedEventArgs e)
        //{
        //    tab_nom.SelectedItem = tab_item_nom;
        //}



        //////Заполнение комбобокса значения характеристик
        //private void cb_char_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        //{
        //    load_cb_values();
        //}


        //////Добавление характеристики в грид контрол
        //private void bt_add_char_to_drid_Click(object sender, RoutedEventArgs e)
        //{
       



        //    //if (grid_added_char.VisibleRowCount == 0)
        //    //{
        //    //    FbCommand sql = new FbCommand(" select * from COMPILE_CHAR('" + cb_char.Text + "', '" + cb_values.Text + "', " + cal_price.Text + ") ", con.presh.preh.fb);

        //    //    FbDataReader readercom_char = sql.ExecuteReader();
        //    //    dt_for_char.Load(readercom_char);

        //    //    dt_for_char.Columns[0].ColumnName = "Характеристика";
        //    //    dt_for_char.Columns[1].ColumnName = "Учетная цена";
        //    //}
        //    //else
        //    //{
        //        FbCommand sql = new FbCommand(" select * from COMPILE_CHAR('" + cb_char.Text + "', '" + cb_values.Text + "', " + cal_price.Text + ") ", con.presh.preh.fb);

        //        FbDataReader readercom_char = sql.ExecuteReader();
        //        DataTable dt_row = new DataTable();
        //        dt_row.Load(readercom_char);

        //        dt_for_char.Rows.Add(new Object[] { dt_row.Rows[0][0], dt_row.Rows[0][1] });
        //    //}
               

        //    grid_added_char.ItemsSource = dt_for_char;
        //    grid_added_char.Columns[0].Width = 260;

           
        //}



        //////Удаление характеристики из грид контрола
        //private void bt_del_char_from_grid_Click(object sender, RoutedEventArgs e)
        //{
        //    dt_for_char.Rows.Clear();
        //    grid_added_char.ItemsSource = dt_for_char;
        //    grid_added_char.Columns[0].Width = 260;
        //}

        //private void grid_added_char_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (dt_for_char.Columns.Count==0)
        //    {
        //        dt_for_char.Columns.Add("Характеристика", typeof(string));
        //        dt_for_char.Columns.Add("Учетная цена", typeof(decimal));
        //        grid_added_char.ItemsSource = dt_for_char;
        //        grid_added_char.Columns[0].Width = 260;
        //    }
        //}

  
    }
}

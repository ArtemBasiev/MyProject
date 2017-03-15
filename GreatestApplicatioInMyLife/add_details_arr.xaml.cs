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
    public partial class add_details_arr : Window
    {

        public add_arr con1;
        public MainWindow con;
        public add_details_arr()
        {
            InitializeComponent();
        }




        private void calc_sel_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }

        private void cg_choosing_nom_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cg_choosing_nom.ItemsSource = con.LoadGridNom();
                con.prop_gr_nom(cg_choosing_nom);
            }
            catch
            {
                cg_choosing_nom.ItemsSource = con1.con.LoadGridNom();
                con1.con.prop_gr_nom(cg_choosing_nom);
            }
        }


        /////////////////////////Расчет суммы для поля
        public void account_summ()
        {
            if (calc_sel.Text != "")
            {
                try
                {
                    FbCommand sqlforin = new FbCommand("select SUMM from GET_ID_TOV(" + cg_choosing_nom.GetFocusedRowCellValue("ID") + ", " + calc_sel.Text + ",'p')", con.preh.fb);
                    FbDataReader readercomb = sqlforin.ExecuteReader();
                    DataTable dtcomb = new DataTable();
                    dtcomb.Load(readercomb);
                    tb_sum.Text = dtcomb.Rows[0][0].ToString();
                }
                catch
                {
                    FbCommand sqlforin = new FbCommand("select SUMM from GET_ID_TOV(" + cg_choosing_nom.GetFocusedRowCellValue("ID") + ", " + calc_sel.Text + ",'p')", con1.con.preh.fb);
                    FbDataReader readercomb = sqlforin.ExecuteReader();
                    DataTable dtcomb = new DataTable();
                    dtcomb.Load(readercomb);
                    tb_sum.Text = dtcomb.Rows[0][0].ToString();
                }
            }
        }
        private void calc_sel_LostFocus(object sender, RoutedEventArgs e)
        {
            account_summ();
        }

        private void bt_add_det_Click(object sender, RoutedEventArgs e)
        {
            account_summ();
            try
            {
                try
                {
                    //Команда добавления
                    FbCommand sqlforin = new FbCommand("INS_ARR_DET", con1.con.preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@ID_DOC", FbDbType.Integer).Value = con1.con.return_id_doc;
                    sqlforin.Parameters.Add("@NOM", FbDbType.Date).Value = cg_choosing_nom.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@COUNTING", FbDbType.VarChar).Value = calc_sel.Text;
                    sqlforin.Parameters.Add("@SUMM", FbDbType.Decimal).Value = tb_sum.Text;
                    sqlforin.ExecuteNonQuery();
                    calc_sel.Clear();
                    tb_sum.Clear();
                    System.Windows.MessageBox.Show("Товар успешно добавлен!");
                }
                //catch { System.Windows.MessageBox.Show("Невозможно добавить товар!"); }

                catch
                {

                    //Команда добавления
                    FbCommand sqlforin = new FbCommand("INS_ARR_DET", con.preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@ID_DOC", FbDbType.Integer).Value = con.return_id_doc;
                    sqlforin.Parameters.Add("@NOM", FbDbType.Date).Value = cg_choosing_nom.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@COUNTING", FbDbType.VarChar).Value = calc_sel.Text;
                    sqlforin.Parameters.Add("@SUMM", FbDbType.Decimal).Value = tb_sum.Text;
                    sqlforin.ExecuteNonQuery();
                    calc_sel.Clear();
                    tb_sum.Clear();
                    System.Windows.MessageBox.Show("Товар успешно добавлен!");
                }
            }
            catch { System.Windows.MessageBox.Show("Невозможно добавить товар!"); }
            
        }

        private void window_add_details_arr_Closed(object sender, EventArgs e)
        {
            try
            {
                //Команда обновления суммы
                FbCommand sqlforin = new FbCommand("GET_SUM_DOC", con1.con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@ID_DOC", FbDbType.Integer).Value = con1.con.return_id_doc;
                sqlforin.ExecuteNonQuery();
                con1.con.gc_arrive_list.ItemsSource = con1.con.dt_grid_list_arrived();
                con1.con.prop_grid_arr(con1.con.gc_arrive_list);
                
            }
            catch
            {
                //Команда обновления суммы
                FbCommand sqlforin = new FbCommand("GET_SUM_DOC", con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@ID_DOC", FbDbType.Integer).Value = con.return_id_doc;
                sqlforin.ExecuteNonQuery();
                con.gc_arrive_list.ItemsSource = con.dt_grid_list_arrived();
                con.prop_grid_arr(con.gc_arrive_list);
                con.view_rgid_arr.MoveFocusedRow(con.indexfocrow);
            }
        }

    
    }
}

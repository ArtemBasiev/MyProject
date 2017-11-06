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
    /// Логика взаимодействия для add_detail_move.xaml
    /// </summary>
    public partial class add_detail_move : Window
    {
        public string id_selected_char;

        public add_move con1;
        public MainWindow con;


        public add_detail_move()
        {
            InitializeComponent();
        }


        private void calc_sel_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }







        private void bt_add_det_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_MOVE", con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = null;
                sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = con.gc_move_list.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = id_selected_char.ToString();
                sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = culc_sum.Text;


                //FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_LEAVE('I', NULL, " + con.gc_arrive_list.GetFocusedRowCellValue("ID").ToString() + ", " + id_selected_char.ToString() + ", " + culc_sum.Text+")", con.preh.fb);
                FbDataReader reader = sqlforin.ExecuteReader();
                dt.Load(reader);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    System.Windows.MessageBox.Show("Данное количество номенклатуры недоступно!");
                }
                else
                {
                    sqlforin.ExecuteNonQuery();
                    this.Close();

                    con.gc_move_list.ItemsSource = con.dt_grid_list_move();
                    con.prop_grid_move(con.gc_move_list);

                    System.Windows.MessageBox.Show("Товар успешно добавлен!");
                }



            }
            catch { System.Windows.MessageBox.Show("Невозможно добавить номенклатуру!"); }

        }

        private void be_nom_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            frame_char_leavemove open_unity = new frame_char_leavemove();
            open_unity.conm = this;
            open_unity.Tag = "move";
            open_unity.ShowDialog();
        }
    }
}

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

        public string id_selected_char;

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



      
   
     

        private void bt_add_det_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                
                    //Команда добавления
                    FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_ARRIVE", con.preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                    sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = null;
                    sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = con.gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = id_selected_char.ToString();
                    sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = culc_sum.Text;
            
             
                    sqlforin.ExecuteNonQuery();
                    this.Close();

                    con.gc_arrive_list.ItemsSource = con.dt_grid_list_arrived();
                    con.prop_grid_arr(con.gc_arrive_list);
                  
                    System.Windows.MessageBox.Show("Товар успешно добавлен!");
               
            }
            catch { System.Windows.MessageBox.Show("Невозможно добавить номенклатуру!"); }
            
        }

        private void be_nom_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            frame_char_arrive open_unity = new frame_char_arrive();
            open_unity.con1 = this;
            open_unity.ShowDialog();
        }

      

    
    }
}

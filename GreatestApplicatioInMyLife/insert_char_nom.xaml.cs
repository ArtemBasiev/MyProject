using FirebirdSql.Data.FirebirdClient;
using GreatestApplicatioInMyLife.UserControls;
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
    /// Логика взаимодействия для insert_char_nom.xaml
    /// </summary>
    

    public partial class insert_char_nom : Window
    {

        public string id_char;
        public uc_dockpanel_di con;
        public insert_char_nom()
        {
            InitializeComponent();
        }


        private void be_char_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (con.uc_dp_di.Tag.ToString() == "nom")
                {

                    frame_char open_unity = new frame_char();
                    open_unity.con1 = this;
                    open_unity.ShowDialog();

                }

                else
                {

                }

            }

            catch { }
        }

        private void bt_create_nom_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {


                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_NOM_CHAR", con.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = 0;
                sqlforin.Parameters.Add("@ID_NOM", FbDbType.Integer).Value = con.grid_di.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = id_char;
                sqlforin.Parameters.Add("@ACC_PRICE", FbDbType.Decimal).Value = ce_price.Text;
                sqlforin.ExecuteNonQuery();

                id_char = null;
                con.LoadGridChar(con.grid_di_det, con.grid_di);
                this.Close();

                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }

        }

        private void bt_can_cr_nom_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   

     
    }
}

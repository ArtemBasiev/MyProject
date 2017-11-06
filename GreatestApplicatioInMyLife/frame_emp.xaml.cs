using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для frame_emp.xaml
    /// </summary>
    public partial class frame_emp : Window
    {
        public Admin_panel con1;

        public frame_emp()
        {
            InitializeComponent();
        }

        private void mainwindow_Activated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            
            if (con1.preh.fb.State == ConnectionState.Closed)
            { con1.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_EMP_FRAME", con1.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Имя";
            dt.Columns[2].ColumnName = "Должность";
      


            grid_master_char.ItemsSource = dt;
            grid_master_char.Columns[1].Width = 250;
            grid_master_char.Columns[0].Visible = false;
            grid_master_char.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            grid_master_char.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
           
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_RESPONSIBLES", con1.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "I";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = null;
                sqlforin.Parameters.Add("@ID_WAR", FbDbType.Integer).Value = con1.grid_war.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_RES", FbDbType.Integer).Value = grid_master_char.GetFocusedRowCellValue("ID").ToString();
            
                sqlforin.ExecuteNonQuery();
                //flag = false;


                con1.grid_war.ItemsSource = con1.dt_grid_war();
                con1.prop_grid_war(con1.grid_war);
                //flag = true;
                System.Windows.MessageBox.Show("Запись успешно обновлена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            this.Close();
        }



    }
}

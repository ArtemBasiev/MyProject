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
    /// Логика взаимодействия для frame_char.xaml
    /// </summary>
    public partial class frame_char : Window
    {
        public insert_char_nom con1 ;
        public frame_char()
        {
            InitializeComponent();
        }

      

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_create_Click(object sender, RoutedEventArgs e)
        {
            con1.id_char = grid_master_char.GetFocusedRowCellValue("ID").ToString();
            con1.be_char.Text = grid_master_char.GetFocusedRowCellValue("Характеристика").ToString();
            this.Close();

        }

        private void mainwindow_Activated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con1.con.presh.flag = false;
            if (con1.con.presh.preh.fb.State == ConnectionState.Closed)
            { con1.con.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_TYPE_CHARACTERS", con1.con.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
      
            dt.Columns[1].ColumnName = "Тип";
            

            grid_tree_char.ItemsSource = dt;
            grid_tree_char.Columns[1].Width = 250;
            grid_tree_char.Columns[0].Visible = false;
            grid_tree_char.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            con1.con.presh.flag = true;


        }

        private void grid_tree_char_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            con1.con.presh.flag = false;
            if (con1.con.presh.preh.fb.State == ConnectionState.Closed)
            { con1.con.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select ID, NAME from SEL_CHAR_VALUES where ID_CHAR ="+grid_tree_char.GetFocusedRowCellValue("ID"), con1.con.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";

            dt.Columns[1].ColumnName = "Характеристика";


            grid_master_char.ItemsSource = dt;
            grid_master_char.Columns[0].Visible = false;
            grid_master_char.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            con1.con.presh.flag = true;
        }
    }
}

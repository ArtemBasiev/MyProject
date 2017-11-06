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
    /// Логика взаимодействия для frame_char_leavemove.xaml
    /// </summary>
    public partial class frame_char_leavemove : Window
    {

        public add_detail_leave con1;
        public add_detail_move conm;
        public frame_char_leavemove()
        {
            InitializeComponent();
        }

        private void mainwindow_Activated(object sender, EventArgs e)
        {
           
            if (this.Tag.ToString()=="move")
            {
                DataTable dt = new DataTable();
                conm.con.flag = false;
                if (conm.con.preh.fb.State == ConnectionState.Closed)
                { conm.con.preh.fb.Open(); }
                FbCommand command = new FbCommand("select * from SEL_CHAR_OST_FRAME(" + conm.con.preh.id_main_war + ")", conm.con.preh.fb);
                FbDataReader reader = command.ExecuteReader();

                dt.Load(reader);
                dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Группа";
                dt.Columns[2].ColumnName = "Номенклатура";
                dt.Columns[3].ColumnName = "Характеристика";
                dt.Columns[4].ColumnName = "Осталось на складе";
                dt.Columns[5].ColumnName = "Единица измерения";
                dt.Columns[6].ColumnName = "Артикул";
                dt.Columns[7].ColumnName = "Цена";


                grid_master_char.ItemsSource = dt;
                grid_master_char.Columns[1].Width = 250;
                grid_master_char.Columns[0].Visible = false;
                grid_master_char.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
                conm.con.flag = true;
            }
            else
                if(this.Tag.ToString()=="leave")
            {
                DataTable dt = new DataTable();
                con1.con.flag = false;
                if (con1.con.preh.fb.State == ConnectionState.Closed)
                { con1.con.preh.fb.Open(); }
                FbCommand command = new FbCommand("select * from SEL_CHAR_OST_FRAME(" + con1.con.preh.id_main_war + ")", con1.con.preh.fb);
                FbDataReader reader = command.ExecuteReader();

                dt.Load(reader);
                dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Группа";
                dt.Columns[2].ColumnName = "Номенклатура";
                dt.Columns[3].ColumnName = "Характеристика";
                dt.Columns[4].ColumnName = "Осталось на складе";
                dt.Columns[5].ColumnName = "Единица измерения";
                dt.Columns[6].ColumnName = "Артикул";
                dt.Columns[7].ColumnName = "Цена";


                grid_master_char.ItemsSource = dt;
                grid_master_char.Columns[1].Width = 250;
                grid_master_char.Columns[0].Visible = false;
                grid_master_char.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
                con1.con.flag = true;
            }
          
          
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_create_Click(object sender, RoutedEventArgs e)
        {
            if (this.Tag.ToString() == "move")
            {
                conm.id_selected_char = grid_master_char.GetFocusedRowCellValue("ID").ToString();
                conm.be_nom.Text = grid_master_char.GetFocusedRowCellValue("Номенклатура").ToString() + "-" + grid_master_char.GetFocusedRowCellValue("Характеристика").ToString();
                this.Close();
            }
            else
            {
                con1.id_selected_char = grid_master_char.GetFocusedRowCellValue("ID").ToString();
                con1.be_nom.Text = grid_master_char.GetFocusedRowCellValue("Номенклатура").ToString() + "-" + grid_master_char.GetFocusedRowCellValue("Характеристика").ToString();
                this.Close();
            }
            
        }

    }
}

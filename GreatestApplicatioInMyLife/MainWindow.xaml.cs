using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.Xpf;
using System.ComponentModel;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Bars;


namespace GreatestApplicatioInMyLife
{
    public partial class MainWindow : Window
    {

        //---------------------------------------------------------------------------------------------------------------------
        //----------------Глобальные переменные------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
       public string flag_grid_fill;
        public Boolean flag;
        public AutWindow preh;




        public MainWindow()
        {
            InitializeComponent();
        }





        //---------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника единицы измерения------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridMes()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_MES", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "Наименование";
            flag = true;
            return dt;
        }






        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника номенклатуры------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridNom()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_NOM", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Columns.Add(" ", typeof(Boolean));
                dt.Load(reader);
                int start = -1;
                int count = dt.Rows.Count;

                while (start < count - 1)
                {
                    try
                    {
                        start = start + 1;
                        dt.Rows[start][0] = false;
                    }
                    catch { }
                }

                dt.Columns[1].ColumnName = "Наименование";
                dt.Columns[2].ColumnName = "Единица измерения";
                dt.Columns[3].ColumnName = "Артикул";
                dt.Columns[4].ColumnName = "Тип номенклатуры";

            }
            flag = true;
            return dt;
        }






        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание тулбара для справочника номенклатуры------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public ToolBarControl bar_nom()
        {
            var tool_bar_control_nom = new ToolBarControl() { Margin = new Thickness(5, 5, 10, 10) };
            var bar_but_add_nom = new BarButtonItem() { Content = "Добавить" };
            var bar_but_del_nom = new BarButtonItem() { Content = "Удалить" };
            var bar_but_refresh_nom = new BarButtonItem() { Content = "Обновить" };

            tool_bar_control_nom.Items.Add(bar_but_add_nom);
            tool_bar_control_nom.Items.Add(bar_but_del_nom);
            tool_bar_control_nom.Items.Add(bar_but_refresh_nom);


           
         
           

           //bar_but_add_nom.Content = new Image() { Source = "c:\work\test.jpg" };
            //Glyphs content = bar_but_add_nom.Background as ImageBrush;
            return tool_bar_control_nom;
        }





        //---------------------------------------------------------------------------------------------------------------------------------
        //----------------------Динамичесоке создание панели----------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------
        public void create_di_panel(string name_panel, DataTable dt_for_grid, ToolBarControl pivotat_toolbar)
        {
            var st_panel = new StackPanel();
            var doc_panel = new DocumentPanel() { Caption = name_panel };
            var di_grid_control = new GridControl() { AutoGenerateColumns = AutoGenerateColumnsMode.AddNew, MaxHeight = 500, EnableSmartColumnsGeneration = true };
            var grid_view = new TableView();
            di_grid_control.View = grid_view;
            di_grid_control.ItemsSource = dt_for_grid;
          
            //di_grid_control.MouseDown += p3_MouseDown;
            if (flag_grid_fill == "nom")
            {
                
                di_grid_control.Columns[0].Width = 20;
                di_grid_control.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
                di_grid_control.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
                di_grid_control.Columns[3].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
                di_grid_control.Columns[4].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
                di_grid_control.Columns[4].GroupIndex = 0;
            }
            else if (flag_grid_fill == "mes")
              {
                  di_grid_control.Columns[0].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
              }


            st_panel.Children.Add(pivotat_toolbar);
            st_panel.Children.Add(di_grid_control);
            doc_panel.Content=st_panel;
            DocumentHost.Add(doc_panel);
             
        }




        void p3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void Nom_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

            flag_grid_fill = "nom";
            create_di_panel("Справочник номенклатура", LoadGridNom(),bar_nom());
         
            
     
        
        }

        private void brbtMeasure_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            flag_grid_fill = "mes";
            create_di_panel("Справочник единицы измерения", LoadGridMes(), bar_nom());
        }

        private void btExitApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }


    }
}

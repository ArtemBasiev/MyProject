using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using FirebirdSql.Data.FirebirdClient;
using GreatestApplicatioInMyLife.UserControls;
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
    /// Логика взаимодействия для frame_doc.xaml
    /// </summary>
    public partial class frame_doc : Window
    {
        public  uc_dockpanel_di  conshow;
        public frame_doc()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////-------------------------Работа с документами----------------////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////











        /////////////////////////DataTable для списка документов прихода -------------------------------
        public DataTable dt_grid_list_arrived()
        {
            DataTable dt = new DataTable();
           
            if (conshow.presh.preh.fb.State == ConnectionState.Closed)
            { conshow.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_DOCUMENT_ARRIVE_SHOW("+conshow.grid_di.GetFocusedRowCellValue("ID").ToString()+", " + conshow.presh.preh.id_main_war.ToString() + ")", conshow.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Номер документа";
            dt.Columns[2].ColumnName = "Создатель";
            dt.Columns[3].ColumnName = "Дата создания";
            dt.Columns[4].ColumnName = "Поставщик";
            dt.Columns[5].ColumnName = "Сумма";
            dt.Columns[6].ColumnName = "Комментарий";


           
            return dt;
        }


        //////////////////Свойства грида приход
        public void prop_grid_arr(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[6].Width = 250;


        }


        /////////////////////////DataTable для списка деталей документов прихода -------------------------------
        public DataTable dt_grid_det_arrived()
        {
            DataTable dt = new DataTable();

            if (conshow.presh.preh.fb.State == ConnectionState.Closed)
            { conshow.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_DOCUMENT_DETAIL where ID_DOCUMENT = " + gc_arrive_list.GetFocusedRowCellValue("ID").ToString(), conshow.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            //dt.Columns[1].ColumnName = "ID документа";
            //dt.Columns[2].ColumnName = "ID документа";
            dt.Columns[3].ColumnName = "Артикул";
            dt.Columns[4].ColumnName = "Номенклатура";
            dt.Columns[5].ColumnName = "Характеристика";
            dt.Columns[6].ColumnName = "Количество";
            dt.Columns[7].ColumnName = "Единица измерения";
            dt.Columns[8].ColumnName = "Цена руб.";
            dt.Columns[9].ColumnName = "Сумма руб.";
        
            return dt;
        }


        /////////Grid_properties для деталей прихода
        public void prop_gr_det_arr(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].Visible = false;
            name_grid.Columns[4].Width = 150;
            name_grid.Columns[5].Width = 250;
            name_grid.Columns[4].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;


        }





        private void gc_arrive_list_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
                gc_arrive_list.ItemsSource = dt_grid_list_arrived();
                prop_grid_arr(gc_arrive_list);
              
            }
            catch { }
        }







        private void view_rgid_arr_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
      
                
                  
                    gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                    prop_gr_det_arr(gc_arrive_det);
                
            }
            catch { }
        }


    



    

        ///////////////////////////////////Кнопка обновления прихода
        private void but_refresh_list_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_arrive_list.ItemsSource = dt_grid_list_arrived();
            prop_grid_arr(gc_arrive_list);
        }


        ///////////////////////////////////Кнопка обновления деталей прихода
        private void but_refresh_det_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_arrive_det.ItemsSource = dt_grid_det_arrived();
            prop_gr_det_arr(gc_arrive_det);

        }


   
        ////////////////////////////////////////Отчет по приходу...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void but_report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report_Window repwindshow = new Report_Window();
            repwindshow.Tag = "one_arr_sh";
            repwindshow.fordoc = this;
            repwindshow.Show();
        }





        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////-----------------Документ расход-------///////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////DataTable для списка документов расхода -------------------------------
        public DataTable dt_grid_list_leave()
        {
            DataTable dt = new DataTable();

            if (conshow.presh.preh.fb.State == ConnectionState.Closed)
            { conshow.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_DOCUMENT_LEAVE_SHOW(" + conshow.grid_di.GetFocusedRowCellValue("ID").ToString() + ", " + conshow.presh.preh.id_main_war.ToString() + ")", conshow.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Номер документа";
            dt.Columns[2].ColumnName = "Создатель";
            dt.Columns[3].ColumnName = "Дата создания";
            dt.Columns[4].ColumnName = "Объект";
            dt.Columns[5].ColumnName = "Сумма";
            dt.Columns[6].ColumnName = "Комментарий";


           
            return dt;
        }


        //////////////////Свойства грида расход
        public void prop_grid_leave(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[6].Width = 250;

      


        }


        /////////////////////////DataTable для списка деталей документов расхода -------------------------------
        public DataTable dt_grid_det_leave()
        {
            DataTable dt = new DataTable();

            if (conshow.presh.preh.fb.State == ConnectionState.Closed)
            { conshow.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_DOCUMENT_DETAIL where ID_DOCUMENT = " + gc_leave_list.GetFocusedRowCellValue("ID").ToString(), conshow.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            //dt.Columns[1].ColumnName = "ID документа";
            //dt.Columns[2].ColumnName = "ID документа";
            dt.Columns[3].ColumnName = "Артикул";
            dt.Columns[4].ColumnName = "Номенклатура";
            dt.Columns[5].ColumnName = "Характеристика";
            dt.Columns[6].ColumnName = "Количество";
            dt.Columns[7].ColumnName = "Единица измерения";
            dt.Columns[8].ColumnName = "Цена руб.";
            dt.Columns[9].ColumnName = "Сумма руб.";
         
            return dt;
        }


        /////////Grid_properties для деталей прихода
        public void prop_gr_det_leave(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].Visible = false;
            name_grid.Columns[4].Width = 150;
            name_grid.Columns[5].Width = 250;
            name_grid.Columns[4].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;


        }





        private void gc_leave_list_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                gc_leave_list.ItemsSource = dt_grid_list_leave();
                prop_grid_leave(gc_leave_list);
            }
            catch { }
        }






        private void view_rgid_leave_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                //return_id_doc = gc_leave_list.GetFocusedRowCellValue("ID").ToString();
                gc_leave_det.ItemsSource = dt_grid_det_leave();
                prop_gr_det_leave(gc_leave_det);
            }
            catch { }

        }







        ///////////////////////////////////Кнопка обновления расхода
        private void but_refresh_list_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_leave_list.ItemsSource = dt_grid_list_leave();
            prop_grid_leave(gc_leave_list);
        }


        ///////////////////////////////////Кнопка обновления деталей расхода
        private void but_refresh_det_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_leave_det.ItemsSource = dt_grid_det_leave();
            prop_gr_det_leave(gc_leave_det);

        }


       

       


        ////////////////////////////////////////Отчет по расходу...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void but_report_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report_Window repwindshow = new Report_Window();
            repwindshow.Tag = "one_leave_sh";
            repwindshow.fordoc = this;
            repwindshow.Show();
        }






        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////-----------------Документ перемещение-------///////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////DataTable для списка документов расхода -------------------------------
        public DataTable dt_grid_list_move()
        {
            DataTable dt = new DataTable();

            if (conshow.presh.preh.fb.State == ConnectionState.Closed)
            { conshow.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_DOCUMENT_MOVE_SHOW(" + conshow.grid_di.GetFocusedRowCellValue("ID").ToString() + ", " + conshow.presh.preh.id_main_war.ToString() + ")", conshow.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Номер документа";
            dt.Columns[2].ColumnName = "Создатель";
            dt.Columns[3].ColumnName = "Дата создания";
            dt.Columns[4].ColumnName = "Склад получатель";
            dt.Columns[5].ColumnName = "Сумма";
            dt.Columns[6].ColumnName = "Комментарий";


        
            return dt;
        }


        //////////////////Свойства грида перемещение
        public void prop_grid_move(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[6].Width = 250;

      


        }


        /////////////////////////DataTable для списка деталей документов перемещение -------------------------------
        public DataTable dt_grid_det_move()
        {
            DataTable dt = new DataTable();

            if (conshow.presh.preh.fb.State == ConnectionState.Closed)
            { conshow.presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_DOCUMENT_DETAIL where ID_DOCUMENT = " + gc_move_list.GetFocusedRowCellValue("ID").ToString(), conshow.presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            //dt.Columns[1].ColumnName = "ID документа";
            //dt.Columns[2].ColumnName = "ID документа";
            dt.Columns[3].ColumnName = "Артикул";
            dt.Columns[4].ColumnName = "Номенклатура";
            dt.Columns[5].ColumnName = "Характеристика";
            dt.Columns[6].ColumnName = "Количество";
            dt.Columns[7].ColumnName = "Единица измерения";
            dt.Columns[8].ColumnName = "Цена руб.";
            dt.Columns[9].ColumnName = "Сумма руб.";
          
            return dt;
        }


        /////////Grid_properties для деталей перемещения
        public void prop_gr_det_move(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].Visible = false;
            name_grid.Columns[4].Width = 150;
            name_grid.Columns[5].Width = 250;
            name_grid.Columns[4].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;


        }





        private void gc_move_list_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                gc_move_list.ItemsSource = dt_grid_list_move();
                prop_grid_move(gc_move_list);
            }
            catch { }
        }



      




        private void view_rgid_move_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
             
                gc_move_det.ItemsSource = dt_grid_det_move();
                prop_gr_det_move(gc_move_det);
            }
            catch { }
        }


       




    

        ///////////////////////////////////Кнопка обновления перемещения
        private void but_refresh_list_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_move_list.ItemsSource = dt_grid_list_move();
            prop_grid_move(gc_move_list);
        }


        ///////////////////////////////////Кнопка обновления деталей перемещения
        private void but_refresh_det_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_move_det.ItemsSource = dt_grid_det_move();
            prop_gr_det_move(gc_move_det);

        }


        


       



        ////////////////////////////////////////Отчет по перемещению...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void but_report_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report_Window repwindshow = new Report_Window();
            repwindshow.Tag = "one_move_sh";
            repwindshow.fordoc = this;
            repwindshow.Show();
        }


    }
}

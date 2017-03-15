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
using DevExpress.Xpf.Grid.GroupRowLayout;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Editors.Settings;
using GreatestApplicatioInMyLife.UserControls;



namespace GreatestApplicatioInMyLife
{
    public partial class MainWindow : Window
    {

        //---------------------------------------------------------------------------------------------------------------------
        //----------------Глобальные переменные------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------


        public int indexfocrow;

        //-----Флаг определяет какой справочник требуется открыть
       public string flag_grid_fill;

        //-----Флаг определяет какуя кнопка нажата на ToolBar справочника
       public string flag_task_di_switch;

       //-----Флаг определяет на каком справочнике сейчас фокус
       public string flag_di_focus;

        //--Флаг определяет какой grid control активен
       public int flag_ind_grid;

       public string return_id_doc;


        public Boolean flag;
        public AutWindow preh;



        public MainWindow()
        {
            InitializeComponent();
        }


        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////Характеристики гридконтролов--------------
        ////////////////////////////////////////////////////////////////////////////


        /////////Grid_nom
        public void prop_gr_nom(GridControl name_grid)
        {
            name_grid.Columns[1].Visible = false;

            FbCommand sqlforcomb = new FbCommand("select * from GET_KIND_NOM", preh.fb);
            FbDataReader readercomb = sqlforcomb.ExecuteReader();
            DataTable dtcomb = new DataTable();
            dtcomb.Load(readercomb);
            ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            cb_set_k_nom.ItemsSource = dtcomb;
            cb_set_k_nom.DisplayMember = "NAME";
            cb_set_k_nom.ValueMember = "NAME";
            name_grid.Columns[6].EditSettings = cb_set_k_nom;

            FbCommand sqlforcomb1 = new FbCommand("select * from GET_MEASURE_EDIT", preh.fb);
            FbDataReader readercomb1 = sqlforcomb1.ExecuteReader();
            DataTable dtcomb1 = new DataTable();
            dtcomb1.Load(readercomb1);
            ComboBoxEditSettings cb_set_mes = new ComboBoxEditSettings();
            cb_set_mes.ItemsSource = dtcomb1;
            cb_set_mes.DisplayMember = "SN";
            cb_set_mes.ValueMember = "SN";
            name_grid.Columns[4].EditSettings = cb_set_mes;

            name_grid.Columns[0].Width = 20;
        }


        /////////Grid_pro, cus, emp, mes
        public void prop_gr_mean(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
        }


        /////////Grid_war
        public void prop_gr_war(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            FbCommand sqlforcomb = new FbCommand("select * from GET_RES", preh.fb);
            FbDataReader readercomb = sqlforcomb.ExecuteReader();
            DataSet newset1 = new DataSet("newset1");
            DataTable dtcomb = new DataTable();
            dtcomb.Load(readercomb);

            ComboBoxEditSettings cb_set = new ComboBoxEditSettings();
            cb_set.ItemsSource = dtcomb;
            cb_set.DisplayMember = "SN";
            cb_set.ValueMember = "SN";
            name_grid.Columns[4].EditSettings = cb_set;
        }


        




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////Datatables для заполнения справочников///////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Полное наименование";
            dt.Columns[2].ColumnName = "Сокращенное наименование";

            flag = true;
            return dt;
        }



        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника сотрудники------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridEmployee()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_EMPLOYEE", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Полное имя";
            dt.Columns[2].ColumnName = "Сокращенное имя";
            dt.Columns[3].ColumnName = "Должность";
            dt.Columns[4].ColumnName = "ИНН";
            flag = true;
            return dt;
        }



        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника поставщики------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridProvider()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_PROVIDERS", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Имя";
            dt.Columns[2].ColumnName = "Адрес";
            dt.Columns[3].ColumnName = "Телефон";
            dt.Columns[4].ColumnName = "ИНН";
            flag = true;
            return dt;
        }




        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника покупатели------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridCustomers()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_CUSTOMERS", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Имя";
            dt.Columns[2].ColumnName = "Имя представителя";
            dt.Columns[3].ColumnName = "Адрес";
            dt.Columns[4].ColumnName = "Телефон";
            dt.Columns[5].ColumnName = "ИНН";
            flag = true;
            return dt;
        }




        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника склады------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridWarehouse()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_WAREHOUSE", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Полное наименование";
            dt.Columns[2].ColumnName = "Сокращенное наименование";
            dt.Columns[3].ColumnName = "Адрес";
            dt.Columns[4].ColumnName = "Заведующий складом";
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
                dt.Columns[1].ColumnName = "ID";
                dt.Columns[2].ColumnName = "Полное наименование";
                dt.Columns[3].ColumnName = "Сокращенное наименование";
                dt.Columns[4].ColumnName = "Единица измерения";
                dt.Columns[5].ColumnName = "Артикул";
                dt.Columns[6].ColumnName = "Группа";
                dt.Columns[7].ColumnName = "Себестоимость";
                dt.Columns[8].ColumnName = "Цена реализации";

            }
            flag = true;
            return dt;
        }

 
       
        ////////////////Обработчик кнопки выхода из приложения/////////////////////
        private void btExitApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }





        //////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////Сборка элементов окна справочников////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///-----------------------------Сборка справочника номенклатуры-------------------------------------
        private void Nom_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            uc_dockpanel_di di_nom = new uc_dockpanel_di();
            di_nom.presh = this;
            di_nom.grid_di.ItemsSource = LoadGridNom();
            prop_gr_nom(di_nom.grid_di);
            di_nom.dp_main_di.Caption = "Справочник номенклатура";
            di_nom.Tag = "nom";
            DocumentHost.Add(di_nom.dp_main_di);
        }


        ///-----------------------------Сборка справочника единицы измерения-------------------------------------
        private void brbtMeasure_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            uc_dockpanel_di di_mes = new uc_dockpanel_di();
            di_mes.presh = this;
            di_mes.grid_di.ItemsSource = LoadGridMes();
            prop_gr_mean(di_mes.grid_di);
            di_mes.dp_main_di.Caption = "Справочник единицы измерения";
            di_mes.Tag = "mes";
            DocumentHost.Add(di_mes.dp_main_di);
        }


        


        ///-----------------------------Сборка справочника склады-------------------------------------
        private void brbt_warehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_war = new uc_dockpanel_di();
            di_war.presh = this;
            di_war.grid_di.ItemsSource = LoadGridWarehouse();
            prop_gr_war(di_war.grid_di);
            di_war.dp_main_di.Caption = "Справочник склады";
            di_war.Tag = "war";
            DocumentHost.Add(di_war.dp_main_di);


        }



        ///-----------------------------Сборка справочника поставщики-------------------------------------
        private void brbt_provider_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_pro = new uc_dockpanel_di();
            di_pro.presh = this;
            di_pro.grid_di.ItemsSource = LoadGridProvider();
            prop_gr_mean(di_pro.grid_di);
            di_pro.dp_main_di.Caption = "Справочник поставщики";
            di_pro.Tag = "pro";
            DocumentHost.Add(di_pro.dp_main_di);

        }



        ///-----------------------------Сборка справочника сотрудники-------------------------------------
        private void brbt_employee_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_emp = new uc_dockpanel_di();
            di_emp.presh = this;
            di_emp.grid_di.ItemsSource = LoadGridEmployee();
            prop_gr_mean(di_emp.grid_di);
            di_emp.dp_main_di.Caption = "Справочник сотрудники";
            di_emp.Tag = "emp";
            DocumentHost.Add(di_emp.dp_main_di);
        }


        ///-----------------------------Сборка справочника покупатели-------------------------------------
        private void brbt_customer_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_cus = new uc_dockpanel_di();
            di_cus.presh = this;
            di_cus.grid_di.ItemsSource = LoadGridCustomers();
            prop_gr_mean(di_cus.grid_di);
            di_cus.dp_main_di.Caption = "Справочник покупатели";
            di_cus.Tag = "cus";
            DocumentHost.Add(di_cus.dp_main_di);
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
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SELECT_LIST_ARR", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Дата создания";
            dt.Columns[2].ColumnName = "Поставщик";
            dt.Columns[3].ColumnName = "Сумма";
            dt.Columns[4].ColumnName = "Комментарий";
       

            flag = true;
            return dt;
        }


        //////////////////Свойства грида приход
        public void prop_grid_arr(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;

            FbCommand sqlforcomb = new FbCommand("select SN from GET_ID_CONTR", preh.fb);
            FbDataReader readercomb = sqlforcomb.ExecuteReader();
            DataTable dtcomb = new DataTable();
            dtcomb.Load(readercomb);
            ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            cb_set_k_nom.ItemsSource = dtcomb;
            cb_set_k_nom.DisplayMember = "SN";
            cb_set_k_nom.ValueMember = "SN";
            name_grid.Columns[2].EditSettings = cb_set_k_nom;


        }


        /////////////////////////DataTable для списка деталей документов прихода -------------------------------
        public DataTable dt_grid_det_arrived()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SELECT_DET_ARR where ID_DOC = "+gc_arrive_list.GetFocusedRowCellValue("ID").ToString(), preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "ID документа";
            dt.Columns[2].ColumnName = "Товар";
            dt.Columns[3].ColumnName = "Количество";
            dt.Columns[4].ColumnName = "Сумма";
            flag = true;
            return dt;
        }


        /////////Grid_properties для деталей прихода
        public void prop_gr_det_arr(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            name_grid.Columns[4].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;


        }





        private void gc_arrive_list_Loaded(object sender, RoutedEventArgs e)
        {
            gc_arrive_list.ItemsSource = dt_grid_list_arrived();
            prop_grid_arr(gc_arrive_list);
        }



        private void but_add_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            add_arr add_arr_var = new add_arr();
            add_arr_var.con = this;
            add_arr_var.ShowDialog();
        }




        ///////////////////////////////////Кнопка добавления деталей прихода
        private void but_det_arr_add_ItemClick(object sender, ItemClickEventArgs e)
        {
            indexfocrow = view_rgid_arr.FocusedRowHandle;
            add_details_arr con_det = new add_details_arr();
            con_det.con = this;
            con_det.ShowDialog();
        }


        private void view_rgid_arr_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
           
                return_id_doc = gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                prop_gr_det_arr(gc_arrive_det);
            
        }


        /////////////////////////Редактирование прихода------------------------------------------------
        private void gc_arrive_list_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try {
                         //Вытаскиваем ID contarctor
                        FbCommand sqlforidgroup = new FbCommand("select ID from GET_ID_CONTR where SN ='" + gc_arrive_list.GetFocusedRowCellValue("Поставщик").ToString() + "'", preh.fb);
                        FbDataReader readerforidgroup = sqlforidgroup.ExecuteReader();
                        DataTable dt_id_group = new DataTable();
                        dt_id_group.Load(readerforidgroup);

                        //Команда обновления
                        FbCommand sqlforupd = new FbCommand("UPD_ARR", preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@CR_DATE", FbDbType.Date).Value = gc_arrive_list.GetFocusedRowCellValue("Дата создания").ToString();
                        sqlforupd.Parameters.Add("@COM", FbDbType.VarChar).Value = gc_arrive_list.GetFocusedRowCellValue("Комментарий").ToString();
                        sqlforupd.Parameters.Add("@SUMM", FbDbType.Decimal).Value = gc_arrive_list.GetFocusedRowCellValue("Сумма").ToString();
                        sqlforupd.Parameters.Add("@CONTRACTOR", FbDbType.Integer).Value = dt_id_group.Rows[0][0].ToString();
            
                
                      


                        sqlforupd.ExecuteNonQuery();
                        System.Windows.MessageBox.Show("Запись успешно обновлена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }



        ///////////////////////////////////Кнопка удаления прихода
        private void but_del_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Команда удаления
                FbCommand sqlforupd = new FbCommand("DEL_DOC", preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.ExecuteNonQuery();
                //flag = false;
                gc_arrive_list.ItemsSource = dt_grid_list_arrived();
                prop_grid_arr(gc_arrive_list);
                //flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
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
        }


        ///////////////////////////////////Кнопка удаления деталей прихода
        private void but_del_det_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                indexfocrow = view_rgid_arr.FocusedRowHandle;
                //Команда удаления
                FbCommand sqlforupd = new FbCommand("DEL_DET_ARR", preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.ExecuteNonQuery();
                //flag = false;

                //Команда обновления суммы
                FbCommand sqlforin = new FbCommand("GET_SUM_DOC", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@ID_DOC", FbDbType.Integer).Value = return_id_doc;
                sqlforin.ExecuteNonQuery();

                gc_arrive_list.ItemsSource = dt_grid_list_arrived();
                prop_grid_arr(gc_arrive_list);
                view_rgid_arr.MoveFocusedRow(indexfocrow);

                //gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                //flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
        }


        ///////////////////////////Редактирование деталей прихода-------------
        private void gc_arrive_det_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    indexfocrow = view_rgid_arr.FocusedRowHandle;
                    //Команда обновления
                    FbCommand sqlforupd = new FbCommand("UPD_DET_ARR", preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.Parameters.Add("@COUNTING", FbDbType.Decimal).Value = gc_arrive_det.GetFocusedRowCellValue("Количество").ToString();
                    sqlforupd.Parameters.Add("@NOM", FbDbType.VarChar).Value = gc_arrive_det.GetFocusedRowCellValue("Товар").ToString();
                    sqlforupd.ExecuteNonQuery();
                    //flag = false;

                    //Команда обновления суммы
                    FbCommand sqlforin = new FbCommand("GET_SUM_DOC", preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@ID_DOC", FbDbType.Integer).Value = return_id_doc;
                    sqlforin.ExecuteNonQuery();

                    gc_arrive_list.ItemsSource = dt_grid_list_arrived();
                    prop_grid_arr(gc_arrive_list);
                    view_rgid_arr.MoveFocusedRow(indexfocrow);

                    //gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                    //flag = true;
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }
    }
}

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


        public Boolean flag_det;
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
            name_grid.Columns[0].Visible = false;
        

            //FbCommand sqlforcomb = new FbCommand("select * from GET_KIND_NOM", preh.fb);
            //FbDataReader readercomb = sqlforcomb.ExecuteReader();
            //DataTable dtcomb = new DataTable();
            //dtcomb.Load(readercomb);
            //ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            //cb_set_k_nom.ItemsSource = dtcomb;
            //cb_set_k_nom.DisplayMember = "NAME";
            //cb_set_k_nom.ValueMember = "NAME";
            //name_grid.Columns[6].EditSettings = cb_set_k_nom;

            //FbCommand sqlforcomb1 = new FbCommand("select * from GET_MEASURE_EDIT", preh.fb);
            //FbDataReader readercomb1 = sqlforcomb1.ExecuteReader();
            //DataTable dtcomb1 = new DataTable();
            //dtcomb1.Load(readercomb1);
            //ComboBoxEditSettings cb_set_mes = new ComboBoxEditSettings();
            //cb_set_mes.ItemsSource = dtcomb1;
            //cb_set_mes.DisplayMember = "SN";
            //cb_set_mes.ValueMember = "SN";
            //name_grid.Columns[4].EditSettings = cb_set_mes;

            //name_grid.Columns[0].Width = 20;
        }

        public void prop_gr_char(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Width = 200;
        }


        /////////Grid_pro, cus, emp, mes, war
        public void prop_gr_mean(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
        }

        public void prop_gr_wp(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
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
            dt.Columns[4].ColumnName = "Адрес";
            dt.Columns[5].ColumnName = "ИНН";
            dt.Columns[6].ColumnName = "Телефон";
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
            dt.Columns[1].ColumnName = "Полное наименование";
            dt.Columns[2].ColumnName = "Сокращенное наименование";
            dt.Columns[3].ColumnName = "Имя представителя";
            dt.Columns[4].ColumnName = "Адрес";
            dt.Columns[5].ColumnName = "ИНН";
            dt.Columns[6].ColumnName = "Телефон";
            flag = true;
            return dt;
        }




        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для спарвочника объекты------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridObjects()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_OBJECTS", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Полное наименование";
            dt.Columns[2].ColumnName = "Сокращенное наименование";

            flag = true;
            return dt;
        }


        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для рабочих периодов------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridWp()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_WP", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[2].ColumnName = "Дата начала";
            dt.Columns[3].ColumnName = "Дата окончания";
            dt.Columns[4].ColumnName = "Состояние";
            dt.Columns[5].ColumnName = "Количество документов";

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
            flag = true;
            return dt;
        }



        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для дерева группы номенклатуры------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridNom()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_NOM_GROUP", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Наименование";
            dt.Columns[2].ColumnName = "Тип";
         
            flag = true;
            return dt;
        }


        //---------------------------------------------------------------------------------------------------------------------------
        //----------------Создание DataTable для дерева группа характеристика номенклатуры------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public DataTable LoadGridChar()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_TYPE_CHARACTERS", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Наименование";
            //dt.Columns[2].ColumnName = "Тип";

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

        ///-----------------------------Сборка справочника номенклатуры-------------------------------------\
        private void Nom_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            uc_dockpanel_di di_nom = new uc_dockpanel_di();

            //GridLength w_tree = new GridLength(19);

            //di_nom.space_tree.Width = w_tree;
            di_nom.presh = this;
            di_nom.Tree_SP.Visibility = Visibility.Visible;
            di_nom.grid_tree.ItemsSource = LoadGridNom();
            prop_gr_nom(di_nom.grid_tree);

            di_nom.grid_tree.Columns[2].GroupIndex = 0;
            di_nom.dp_main_di.Caption = "Справочник номенклатура";
            di_nom.Tag = "nom";
            di_nom.tab_det.Visibility = Visibility.Visible;
            
            di_nom.tub_title.Header = "Характеристика номенклатуры";
            DocumentHost.Add(di_nom.dp_main_di);
            di_nom.dp_main_di.IsActive = true;
        }

        ///-----------------------------Сборка справочника характеристика номенклатуры-------------------------------------\
        private void Char_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            uc_dockpanel_di di_char = new uc_dockpanel_di();

            //GridLength w_tree = new GridLength(19);

            //di_nom.space_tree.Width = w_tree;
            di_char.presh = this;
            di_char.Tree_SP.Visibility = Visibility.Visible;
            di_char.grid_tree.ItemsSource = LoadGridChar();
            prop_gr_char(di_char.grid_tree);

            //di_char.grid_tree.Columns[2].GroupIndex = 0;
            di_char.dp_main_di.Caption = "Справочник Характеристика номенклатуры";
            di_char.Tag = "char";
            di_char.but_add_tree.IsVisible = true;
            di_char.but_del_tree.IsVisible = true;
            //di_char.tab_det.Visibility = Visibility.Visible;

            //di_char.tub_title.Header = "Характеристика номенклатуры";
            DocumentHost.Add(di_char.dp_main_di);
            di_char.dp_main_di.IsActive = true;
        }


        ///-----------------------------Сборка справочника единицы измерения-------------------------------------
        private void brbtMeasure_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
           
            uc_dockpanel_di di_mes = new uc_dockpanel_di();

            GridLength w_tree = new GridLength(0);

            di_mes.space_tree.Width = w_tree;
            di_mes.presh = this;
            di_mes.grid_di.ItemsSource = LoadGridMes();
            prop_gr_mean(di_mes.grid_di);
            di_mes.dp_main_di.Caption = "Справочник единицы измерения";
            di_mes.Tag = "mes";
            DocumentHost.Add(di_mes.dp_main_di);
            di_mes.dp_main_di.IsActive = true;
        }


        


        ///-----------------------------Сборка справочника склады-------------------------------------
        private void brbt_warehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_war = new uc_dockpanel_di();
            di_war.presh = this;

            GridLength w_tree = new GridLength(0);

            di_war.space_tree.Width = w_tree;

            di_war.grid_di.ItemsSource = LoadGridWarehouse();
            prop_gr_mean(di_war.grid_di);
            di_war.dp_main_di.Caption = "Справочник склады";
            di_war.Tag = "war";
            di_war.tab_det.Visibility = Visibility.Visible;
            di_war.but_del_det.IsVisible = false;
            di_war.but_refresh_det.IsVisible = false;
            di_war.but_add_det.IsVisible = false;
            di_war.tub_title.Header = "Ответственные лица";
            DocumentHost.Add(di_war.dp_main_di);
            di_war.dp_main_di.IsActive = true;


        }



        ///-----------------------------Сборка справочника поставщики-------------------------------------
        private void brbt_provider_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_pro = new uc_dockpanel_di();
            di_pro.presh = this;

            GridLength w_tree = new GridLength(0);

            di_pro.space_tree.Width = w_tree;

            di_pro.grid_di.ItemsSource = LoadGridProvider();
            prop_gr_mean(di_pro.grid_di);
            di_pro.dp_main_di.Caption = "Справочник контрагенты";
            di_pro.Tag = "pro";
            DocumentHost.Add(di_pro.dp_main_di);
            di_pro.dp_main_di.IsActive = true;
        }



        ///-----------------------------Сборка справочника сотрудники-------------------------------------
        private void brbt_employee_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_emp = new uc_dockpanel_di();
            di_emp.presh = this;

            GridLength w_tree = new GridLength(0);

            di_emp.space_tree.Width = w_tree;

            di_emp.grid_di.ItemsSource = LoadGridEmployee();
            prop_gr_mean(di_emp.grid_di);
            di_emp.dp_main_di.Caption = "Справочник сотрудники";
            di_emp.Tag = "emp";
            DocumentHost.Add(di_emp.dp_main_di);
            di_emp.dp_main_di.IsActive = true;
        }


        ///-----------------------------Сборка справочника объекты-------------------------------------
        private void brbt_customer_ItemClick(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_cus = new uc_dockpanel_di();
            di_cus.presh = this;


            GridLength w_tree = new GridLength(0);

            di_cus.space_tree.Width = w_tree;

            di_cus.grid_di.ItemsSource = LoadGridObjects();
            prop_gr_mean(di_cus.grid_di);
            di_cus.dp_main_di.Caption = "Справочник объекты";
            di_cus.Tag = "obj";
            DocumentHost.Add(di_cus.dp_main_di);
            di_cus.dp_main_di.IsActive = true;
        }


        ////////////////////////////////////////  Открытие справочника периодов///////////////////////////////
        private void BarSubItem_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            uc_dockpanel_di di_wp = new uc_dockpanel_di();
            di_wp.presh = this;


            GridLength w_tree = new GridLength(0);

            di_wp.space_tree.Width = w_tree;

            di_wp.grid_di.ItemsSource = LoadGridWp();
            prop_gr_wp(di_wp.grid_di);
            di_wp.dp_main_di.Caption = "Рабочие периоды";
            di_wp.Tag = "wp";
            DocumentHost.Add(di_wp.dp_main_di);
            di_wp.but_closewp.IsVisible = true;
            di_wp.but_nom.IsVisible = false;
            di_wp.but_showdoc.IsVisible = true;
            di_wp.but_openwp.IsVisible = true;
            di_wp.dp_main_di.IsActive = true;
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
          
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_DOCUMENT_ARRIVE("+preh.id_main_war.ToString()+")", preh.fb);
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

            FbCommand sqlforcomb = new FbCommand("select SN from GET_ID_CONTR", preh.fb);
            FbDataReader readercomb = sqlforcomb.ExecuteReader();
            DataTable dtcomb = new DataTable();
            dtcomb.Load(readercomb);
            ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            cb_set_k_nom.ItemsSource = dtcomb;
            cb_set_k_nom.DisplayMember = "SN";
            cb_set_k_nom.ValueMember = "SN";
            name_grid.Columns[4].EditSettings = cb_set_k_nom;


        }


        /////////////////////////DataTable для списка деталей документов прихода -------------------------------
        public DataTable dt_grid_det_arrived()
        {
            DataTable dt = new DataTable();
            
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_DOCUMENT_DETAIL where ID_DOCUMENT = "+gc_arrive_list.GetFocusedRowCellValue("ID").ToString(), preh.fb);
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
            try { 
            flag_det = false;
            gc_arrive_list.ItemsSource = dt_grid_list_arrived();
            prop_grid_arr(gc_arrive_list);
            flag_det = true;
                }
            catch { }
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
            try { 
          
            
                return_id_doc = gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                prop_gr_det_arr(gc_arrive_det);
           
                }
            catch { }
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
                        FbCommand sqlforupd = new FbCommand("IUD_DOCUMENT_ARRIVE", preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@CREATOR", FbDbType.VarChar).Value = null;
                        sqlforupd.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = gc_arrive_list.GetFocusedRowCellValue("Комментарий").ToString();
                        sqlforupd.Parameters.Add("@CONTRACTOR", FbDbType.Integer).Value = dt_id_group.Rows[0][0].ToString();
                        sqlforupd.Parameters.Add("@ID_WH", FbDbType.Integer).Value = null;
            
                
                      


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
                FbCommand sqlforupd = new FbCommand("IUD_DOCUMENT_ARRIVE", preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_list.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.Parameters.Add("@CREATOR", FbDbType.VarChar).Value = null;
                sqlforupd.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = null;
                sqlforupd.Parameters.Add("@CONTRACTOR", FbDbType.Integer).Value = null;
                sqlforupd.Parameters.Add("@ID_WH", FbDbType.Integer).Value = null;
                sqlforupd.ExecuteNonQuery();
                flag = false;
                gc_arrive_list.ItemsSource = dt_grid_list_arrived();
                prop_grid_arr(gc_arrive_list);
                flag = true;
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
            prop_gr_det_arr(gc_arrive_det);

        }


        ///////////////////////////////////Кнопка удаления деталей прихода
        private void but_del_det_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                indexfocrow = view_rgid_arr.FocusedRowHandle;
                //Команда удаления
                FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_ARRIVE", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID_DOCUMENT").ToString();
                sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID_CHAR").ToString();
                sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = null;
                sqlforin.ExecuteNonQuery();
                
                //flag = false;

                //Команда обновления суммы


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
                    FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_ARRIVE", preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID_DOCUMENT").ToString();
                    sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("ID_CHAR").ToString();
                    sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = gc_arrive_det.GetFocusedRowCellValue("Количество").ToString();
                    sqlforin.ExecuteNonQuery();
                    //flag = false;


                    gc_arrive_list.ItemsSource = dt_grid_list_arrived();
                    prop_grid_arr(gc_arrive_list);
                    view_rgid_arr.MoveFocusedRow(indexfocrow);
                    //flag = true;
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }





        ////////////////////////////////////////Отчет по приходу...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void but_report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report_Window repwindshow = new Report_Window();
            repwindshow.Tag = "one_arr";
            repwindshow.con = this;
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
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_DOCUMENT_LEAVE(" + preh.id_main_war.ToString() + ")", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Номер документа";
            dt.Columns[2].ColumnName = "Создатель";
            dt.Columns[3].ColumnName = "Дата создания";
            dt.Columns[4].ColumnName = "Объект";
            dt.Columns[5].ColumnName = "Сумма";
            dt.Columns[6].ColumnName = "Комментарий";


            flag = true;
            return dt;
        }


        //////////////////Свойства грида расход
        public void prop_grid_leave(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[6].Width = 250;

            //FbCommand sqlforcomb = new FbCommand("select SN from GET_ID_CONTR", preh.fb);
            //FbDataReader readercomb = sqlforcomb.ExecuteReader();
            //DataTable dtcomb = new DataTable();
            //dtcomb.Load(readercomb);
            //ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            //cb_set_k_nom.ItemsSource = dtcomb;
            //cb_set_k_nom.DisplayMember = "SN";
            //cb_set_k_nom.ValueMember = "SN";
            //name_grid.Columns[4].EditSettings = cb_set_k_nom;


        }


        /////////////////////////DataTable для списка деталей документов расхода -------------------------------
        public DataTable dt_grid_det_leave()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_DOCUMENT_DETAIL where ID_DOCUMENT = " + gc_leave_list.GetFocusedRowCellValue("ID").ToString(), preh.fb);
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
            flag = true;
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



        private void but_add_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            add_leave add_leave_var = new add_leave();
            add_leave_var.con = this;
            add_leave_var.ShowDialog();
        }




        ///////////////////////////////////Кнопка добавления деталей расхода
        private void but_det_leave_add_ItemClick(object sender, ItemClickEventArgs e)
        {
            indexfocrow = view_rgid_leave.FocusedRowHandle;
            add_detail_leave con_det = new add_detail_leave();
            con_det.con = this;
            con_det.ShowDialog();
        }


        private void view_rgid_leave_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                return_id_doc = gc_leave_list.GetFocusedRowCellValue("ID").ToString();
                gc_leave_det.ItemsSource = dt_grid_det_leave();
                prop_gr_det_leave(gc_leave_det);
            }
            catch { }

        }


        /////////////////////////Редактирование расхода------------------------------------------------
        private void gc_leave_list_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    ////Вытаскиваем ID contarctor
                    //FbCommand sqlforidgroup = new FbCommand("select ID from GET_ID_CONTR where SN ='" + gc_arrive_list.GetFocusedRowCellValue("Поставщик").ToString() + "'", preh.fb);
                    //FbDataReader readerforidgroup = sqlforidgroup.ExecuteReader();
                    //DataTable dt_id_group = new DataTable();
                    //dt_id_group.Load(readerforidgroup);

                    //Команда обновления
                    FbCommand sqlforupd = new FbCommand("IUD_DOCUMENT_LEAVE", preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_leave_list.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.Parameters.Add("@CREATOR", FbDbType.VarChar).Value = null;
                    sqlforupd.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = gc_leave_list.GetFocusedRowCellValue("Комментарий").ToString();     
                    sqlforupd.Parameters.Add("@ID_WH", FbDbType.Integer).Value = null;
                    sqlforupd.Parameters.Add("@ID_OBJECT", FbDbType.Integer).Value = null;





                    sqlforupd.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }




        ///////////////////////////////////Кнопка удаления расхода
        private void but_del_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Команда удаления
                FbCommand sqlforupd = new FbCommand("IUD_DOCUMENT_LEAVE", preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_leave_list.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.Parameters.Add("@CREATOR", FbDbType.VarChar).Value = null;
                sqlforupd.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = null;       
                sqlforupd.Parameters.Add("@ID_WH", FbDbType.Integer).Value = null;
                sqlforupd.Parameters.Add("@ID_OBJECT", FbDbType.Integer).Value = null;
                sqlforupd.ExecuteNonQuery();
                flag = false;
                gc_leave_list.ItemsSource = dt_grid_list_leave();
                prop_grid_leave(gc_leave_list);
                flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
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


        ///////////////////////////////////Кнопка удаления деталей расхода
        private void but_del_det_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                indexfocrow = view_rgid_arr.FocusedRowHandle;
                //Команда удаления
                FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_LEAVE", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("ID_DOCUMENT").ToString();
                sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("ID_CHAR").ToString();
                sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = null;
                sqlforin.ExecuteNonQuery();

                //flag = false;

                //Команда обновления суммы


                gc_leave_list.ItemsSource = dt_grid_list_leave();
                prop_grid_leave(gc_arrive_list);
                view_rgid_leave.MoveFocusedRow(indexfocrow);

                //gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                //flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
        }


        ///////////////////////////Редактирование деталей расхода-------------
        private void gc_leave_det_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    indexfocrow = view_rgid_leave.FocusedRowHandle;
                    //Команда обновления
                    FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_LEAVE", preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("ID_DOCUMENT").ToString();
                    sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("ID_CHAR").ToString();
                    sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = gc_leave_det.GetFocusedRowCellValue("Количество").ToString();
                    sqlforin.ExecuteNonQuery();
                    //flag = false;


                    gc_leave_list.ItemsSource = dt_grid_list_leave();
                    prop_grid_leave(gc_leave_list);
                    view_rgid_leave.MoveFocusedRow(indexfocrow);
                    //flag = true;
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }





        ////////////////////////////////////////Отчет по расходу...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void but_report_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report_Window repwindshow = new Report_Window();
            repwindshow.Tag = "one_leave";
            repwindshow.con = this;
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
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_DOCUMENT_MOVE(" + preh.id_main_war.ToString() + ")", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Номер документа";
            dt.Columns[2].ColumnName = "Создатель";
            dt.Columns[3].ColumnName = "Дата создания";
            dt.Columns[4].ColumnName = "Склад получатель";
            dt.Columns[5].ColumnName = "Сумма";
            dt.Columns[6].ColumnName = "Комментарий";


            flag = true;
            return dt;
        }


        //////////////////Свойства грида перемещение
        public void prop_grid_move(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[6].Width = 250;

            //FbCommand sqlforcomb = new FbCommand("select SN from GET_ID_CONTR", preh.fb);
            //FbDataReader readercomb = sqlforcomb.ExecuteReader();
            //DataTable dtcomb = new DataTable();
            //dtcomb.Load(readercomb);
            //ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            //cb_set_k_nom.ItemsSource = dtcomb;
            //cb_set_k_nom.DisplayMember = "SN";
            //cb_set_k_nom.ValueMember = "SN";
            //name_grid.Columns[4].EditSettings = cb_set_k_nom;


        }


        /////////////////////////DataTable для списка деталей документов перемещение -------------------------------
        public DataTable dt_grid_det_move()
        {
            DataTable dt = new DataTable();
            flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_DOCUMENT_DETAIL where ID_DOCUMENT = " + gc_move_list.GetFocusedRowCellValue("ID").ToString(), preh.fb);
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
            flag = true;
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



        private void but_add_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            add_move add_move_var = new add_move();
            add_move_var.con = this;
            add_move_var.ShowDialog();
        }




        ///////////////////////////////////Кнопка добавления деталей перемещения
        private void but_det_move_add_ItemClick(object sender, ItemClickEventArgs e)
        {
            indexfocrow = view_rgid_move.FocusedRowHandle;
            add_detail_move con_det = new add_detail_move();
            con_det.con = this;
            con_det.ShowDialog();
        }


        private void view_rgid_move_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                return_id_doc = gc_move_list.GetFocusedRowCellValue("ID").ToString();
                gc_move_det.ItemsSource = dt_grid_det_move();
                prop_gr_det_move(gc_move_det);
            }
            catch { }
        }


        /////////////////////////Редактирование перемещения------------------------------------------------
        private void gc_move_list_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    ////Вытаскиваем ID contarctor
                    //FbCommand sqlforidgroup = new FbCommand("select ID from GET_ID_CONTR where SN ='" + gc_arrive_list.GetFocusedRowCellValue("Поставщик").ToString() + "'", preh.fb);
                    //FbDataReader readerforidgroup = sqlforidgroup.ExecuteReader();
                    //DataTable dt_id_group = new DataTable();
                    //dt_id_group.Load(readerforidgroup);

                    //Команда обновления
                    FbCommand sqlforupd = new FbCommand("IUD_DOCUMENT_MOVE", preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_move_list.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.Parameters.Add("@CREATOR", FbDbType.VarChar).Value = null;
                    sqlforupd.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = gc_move_list.GetFocusedRowCellValue("Комментарий").ToString();
                    sqlforupd.Parameters.Add("@ID_WH", FbDbType.Integer).Value = null;
                    sqlforupd.Parameters.Add("@ID_WH_REC", FbDbType.Integer).Value = null;





                    sqlforupd.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }




        ///////////////////////////////////Кнопка удаления перемещения
        private void but_del_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Команда удаления
                FbCommand sqlforupd = new FbCommand("IUD_DOCUMENT_MOVE", preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = gc_move_list.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.Parameters.Add("@CREATOR", FbDbType.VarChar).Value = null;
                sqlforupd.Parameters.Add("@COMMENT", FbDbType.VarChar).Value = null;
                sqlforupd.Parameters.Add("@ID_WH", FbDbType.Integer).Value = null;
                sqlforupd.Parameters.Add("@ID_WH_REC", FbDbType.Integer).Value = null;
                sqlforupd.ExecuteNonQuery();
                flag = false;
                gc_move_list.ItemsSource = dt_grid_list_move();
                prop_grid_move(gc_move_list);
                flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
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


        ///////////////////////////////////Кнопка удаления деталей перемещения
        private void but_del_det_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                indexfocrow = view_rgid_move.FocusedRowHandle;
                //Команда удаления
                FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_MOVE", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("ID_DOCUMENT").ToString();
                sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("ID_CHAR").ToString();
                sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = null;
                sqlforin.ExecuteNonQuery();

                //flag = false;

                //Команда обновления суммы


                gc_move_list.ItemsSource = dt_grid_list_move();
                prop_grid_move(gc_move_list);
                view_rgid_move.MoveFocusedRow(indexfocrow);

                //gc_arrive_det.ItemsSource = dt_grid_det_arrived();
                //flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
        }


        ///////////////////////////Редактирование деталей перемещения------------
        private void gc_move_det_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    indexfocrow = view_rgid_move.FocusedRowHandle;
                    //Команда обновления
                    FbCommand sqlforin = new FbCommand("IUD_DOC_DETAIL_MOVE", preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@ID_DOCUMENT", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("ID_DOCUMENT").ToString();
                    sqlforin.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("ID_CHAR").ToString();
                    sqlforin.Parameters.Add("@COUNT_", FbDbType.Integer).Value = gc_move_det.GetFocusedRowCellValue("Количество").ToString();
                    sqlforin.ExecuteNonQuery();
                    //flag = false;


                    gc_move_list.ItemsSource = dt_grid_list_move();
                    prop_grid_move(gc_move_list);
                    view_rgid_move.MoveFocusedRow(indexfocrow);
                    //flag = true;
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }





        ////////////////////////////////////////Отчет по перемещению...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void but_report_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report_Window repwindshow = new Report_Window();
            repwindshow.Tag = "one_move";
            repwindshow.con = this;
            repwindshow.Show();
        }






        ////////////////////////////////////////                 Отчеты...........///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private void BarSubItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            report_frame_ost repframe = new report_frame_ost();
            repframe.confr = this;
            repframe.flag_rep = "ost";
            repframe.ShowDialog();
        }

        private void bt_rep_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            report_frame_ost repframe = new report_frame_ost();
            repframe.confr = this;
            repframe.flag_rep = "allarr";
            repframe.main_lable.Content = "Приход";
            repframe.ShowDialog();
        }

        private void bt_rep_leave_ItemClick(object sender, ItemClickEventArgs e)
        {
            report_frame_ost repframe = new report_frame_ost();
            repframe.confr = this;
            repframe.flag_rep = "allleave";
            repframe.main_lable.Content = "Расход";
            repframe.ShowDialog();
        }

        private void bt_rep_move_ItemClick(object sender, ItemClickEventArgs e)
        {
            report_frame_ost repframe = new report_frame_ost();
            repframe.confr = this;
            repframe.flag_rep = "allmove";
            repframe.main_lable.Content = "Перемещение";
            repframe.ShowDialog();
        }

     
        private void help_ItemClick(object sender, ItemClickEventArgs e)
        {
            instruction winin = new instruction();
            winin.Show();
        }

        private void BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            AutWindow aut = new AutWindow();
            this.Close();
            aut.Show();
        }

        private void but_help_arr_ItemClick(object sender, ItemClickEventArgs e)
        {
            instruction ins = new instruction();
            ins.navBarDoc.IsExpanded = true;
            ins.navBarItem3.IsSelected = true;
            ins.Show();
          
        }

   


      



    }
}

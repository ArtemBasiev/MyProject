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

namespace GreatestApplicatioInMyLife.UserControls
{

    public partial class uc_dockpanel_di : UserControl
    {

        public MainWindow presh;
        public uc_dockpanel_di()
        {
            InitializeComponent();
        }



        /////////////////////////////////Заполнение грида детали склада-----------------------------------------

        public void LoadGridRes(GridControl name_grid, GridControl name_sender)
        {
            DataTable dt = new DataTable();
            presh.flag = false;
            if (presh.preh.fb.State == ConnectionState.Closed)
            { presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select ID, SN, POS from PROC_SELECT_RESPONSIBLE WHERE ID_WAR =" + name_sender.GetFocusedRowCellValue("ID"), presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Имя";
            dt.Columns[2].ColumnName = "Должность";

            name_grid.ItemsSource = dt;
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            name_grid.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            presh.flag = true;



        }






        /////////////////////////////////Заполнение грида характеристики номенлкатуры-----------------------------------------

        public void LoadGridChar(GridControl name_grid, GridControl name_sender)
        {
            DataTable dt = new DataTable();
            presh.flag = false;
            if (presh.preh.fb.State == ConnectionState.Closed)
            { presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select ID, NAME, PRICE from SELECT_CHAR_NOM WHERE ID_NOM =" + name_sender.GetFocusedRowCellValue("ID"), presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Характеристика";
            dt.Columns[2].ColumnName = "Учетная цена";




            name_grid.ItemsSource = dt;
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Width = 268;
            name_grid.Columns[1].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            name_grid.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            presh.flag = true;



        }


        /////////////////////////////////Заполнение справочника номенклатуры-----------------------------------------

        public void LoadGridNom(GridControl name_grid, GridControl name_sender)
        {

            DataTable dt = new DataTable();
            presh.flag = false;
            if (presh.preh.fb.State == ConnectionState.Closed)
            { presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from PROC_SELECT_NOM WHERE ID_KIND_NOM =" + name_sender.GetFocusedRowCellValue("ID"), presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Полное наименование";
            dt.Columns[2].ColumnName = "Сокращенное наименование";
            dt.Columns[3].ColumnName = "Единица измерения";
            dt.Columns[4].ColumnName = "Артикул";


            name_grid.ItemsSource = dt;
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[5].Visible = false;

            FbCommand sqlforcomb = new FbCommand("select * from GET_MEASURE_EDIT", presh.preh.fb);
            FbDataReader readercomb = sqlforcomb.ExecuteReader();
            DataTable dtcomb = new DataTable();
            dtcomb.Load(readercomb);
            ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            cb_set_k_nom.ItemsSource = dtcomb;
            cb_set_k_nom.DisplayMember = "SN";
            cb_set_k_nom.ValueMember = "SN";
            name_grid.Columns[3].EditSettings = cb_set_k_nom;
            presh.flag = true;


        }

        public void LoadGridCharacter(GridControl name_grid, GridControl name_sender)
        {

            DataTable dt = new DataTable();
            presh.flag = false;
            if (presh.preh.fb.State == ConnectionState.Closed)
            { presh.preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_CHAR_VALUES WHERE ID_CHAR =" + name_sender.GetFocusedRowCellValue("ID"), presh.preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[2].ColumnName = "Наименование";
            //dt.Columns[2].ColumnName = "Сокращенное наименование";
            //dt.Columns[3].ColumnName = "Единица измерения";
            //dt.Columns[4].ColumnName = "Артикул";


            name_grid.ItemsSource = dt;
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].Width = 200;
            //name_grid.Columns[5].Visible = false;

            //FbCommand sqlforcomb = new FbCommand("select * from GET_MEASURE_EDIT", presh.preh.fb);
            //FbDataReader readercomb = sqlforcomb.ExecuteReader();
            //DataTable dtcomb = new DataTable();
            //dtcomb.Load(readercomb);
            //ComboBoxEditSettings cb_set_k_nom = new ComboBoxEditSettings();
            //cb_set_k_nom.ItemsSource = dtcomb;
            //cb_set_k_nom.DisplayMember = "SN";
            //cb_set_k_nom.ValueMember = "SN";
            //name_grid.Columns[3].EditSettings = cb_set_k_nom;
            presh.flag = true;


        }



        /////////////////////////////////Добавление записей-----------------------------------------
        private void but_nom_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "nom")
            {
                ////Команда добавления
                //FbCommand sqlforin = new FbCommand("INS_NOM", presh.preh.fb);
                //sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlforin.ExecuteNonQuery();

                Insert_Nom open_unity = new Insert_Nom();
                open_unity.con = this;
                open_unity.ShowDialog();

            }
            else
                if (uc_dp_di.Tag.ToString() == "char")
                {

                    insert_di_char open_unity = new insert_di_char();
                    open_unity.con = this;
                    open_unity.ShowDialog();

                }
                else if (uc_dp_di.Tag.ToString() == "mes")
                {
                    Insert_Mes open_unity = new Insert_Mes();
                    open_unity.con_ins_mes = this;
                    open_unity.ShowDialog();

                }
                else if (uc_dp_di.Tag.ToString() == "pro")
                {
                    Insert_Prov open_unity = new Insert_Prov();
                    open_unity.con_ins_prov = this;
                    open_unity.ShowDialog();

                }
                else if (uc_dp_di.Tag.ToString() == "obj")
                {
                    Insert_Cus open_unity = new Insert_Cus();
                    open_unity.con_ins_cus = this;
                    open_unity.ShowDialog();

                }
                else if (uc_dp_di.Tag.ToString() == "emp")
                {
                    Insert_Emp open_unity = new Insert_Emp();
                    open_unity.con_ins_emp = this;
                    open_unity.ShowDialog();

                }
                else if (uc_dp_di.Tag.ToString() == "war")
                {
                    Insert_War open_unity = new Insert_War();
                    open_unity.con_ins_war = this;
                    open_unity.ShowDialog();

                }
        }


        ////////////////////////////////////////Обновление записей-------------------------------------------
        private void grid_di_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {


                if (uc_dp_di.Tag.ToString() == "nom")
                {

                    try
                    {

                        //Вытаскиваем ID единицы измерения
                        FbCommand sqlforcombsrav = new FbCommand("select ID_MES from GET_ID_MES_UPD where SN ='" + grid_di.GetFocusedRowCellValue("Единица измерения").ToString() + "'", presh.preh.fb);
                        FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
                        DataTable wdf = new DataTable();
                        wdf.Load(readercombsrav);

                        //Команда обновления
                        FbCommand sqlforupd = new FbCommand("UPD_NOM", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное наименование").ToString();
                        sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное наименование").ToString();
                        sqlforupd.Parameters.Add("@MES", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();
                        sqlforupd.Parameters.Add("@ART", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Артикул").ToString();


                        sqlforupd.ExecuteNonQuery();
                        LoadGridNom(grid_di, grid_tree);
                        System.Windows.MessageBox.Show("Запись успешно обновлена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }

                }
                else
                    if (uc_dp_di.Tag.ToString() == "char")
                    {

                        try
                        {
                            //Команда обновления
                            FbCommand sqlforupd = new FbCommand("IUD_DI_CHAR", presh.preh.fb);
                            sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                            sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                            sqlforupd.Parameters.Add("@ID_TYPE", FbDbType.Integer).Value = null;
                            sqlforupd.Parameters.Add("@NAME", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Наименование").ToString();


                            sqlforupd.ExecuteNonQuery();
                            LoadGridCharacter(grid_di, grid_tree);
                            System.Windows.MessageBox.Show("Запись успешно обновлена!");
                        }
                        catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }

                    }
                    else if (uc_dp_di.Tag.ToString() == "mes")
                    {
                        try
                        {



                            //Команда обновления
                            FbCommand sqlforupd = new FbCommand("UPD_MES", presh.preh.fb);
                            sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное наименование").ToString();
                            sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное наименование").ToString();
                            sqlforupd.Parameters.Add("@ID_MES", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();

                            sqlforupd.ExecuteNonQuery();
                            System.Windows.MessageBox.Show("Запись успешно обновлена!");
                        }
                        catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
                    }
                    else if (uc_dp_di.Tag.ToString() == "war")
                    {

                        try
                        {

                            //Вытаскиваем ID сотрудника
                            FbCommand sqlforcombsrav = new FbCommand("select ID_RES from GET_ID_RES where SN ='" + grid_di.GetFocusedRowCellValue("Заведующий складом").ToString() + "'", presh.preh.fb);
                            FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
                            DataTable wdf = new DataTable();
                            wdf.Load(readercombsrav);

                            //Команда обновления
                            FbCommand sqlforupd = new FbCommand("UPD_WAR", presh.preh.fb);
                            sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                            sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное наименование").ToString();
                            sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное наименование").ToString();
                            sqlforupd.Parameters.Add("@ADR", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Адрес").ToString();
                            sqlforupd.Parameters.Add("@RES", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();



                            sqlforupd.ExecuteNonQuery();
                            System.Windows.MessageBox.Show("Запись успешно обновлена!");
                        }
                        catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
                    }
                    else if (uc_dp_di.Tag.ToString() == "pro")
                    {
                        try
                        {
                            //Команда обновления
                            FbCommand sqlforupd = new FbCommand("UPD_CONTRACTORS", presh.preh.fb);
                            sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforupd.Parameters.Add("@FLAG", FbDbType.VarChar).Value = "pro";
                            sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                            sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное наименование").ToString();
                            sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное наименование").ToString();
                            sqlforupd.Parameters.Add("@ADR", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Адрес").ToString();
                            sqlforupd.Parameters.Add("@INN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("ИНН").ToString();
                            sqlforupd.Parameters.Add("@TEL", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Телефон").ToString();
                            sqlforupd.Parameters.Add("@CONT_NAME", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Имя представителя").ToString();
                            sqlforupd.Parameters.Add("@POS", FbDbType.VarChar).Value = null;

                            sqlforupd.ExecuteNonQuery();
                            System.Windows.MessageBox.Show("Запись успешно обновлена!");
                        }
                        catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
                    }
                    else if (uc_dp_di.Tag.ToString() == "emp")
                    {
                        try
                        {
                            //Команда обновления
                            FbCommand sqlforupd = new FbCommand("UPD_CONTRACTORS", presh.preh.fb);
                            sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforupd.Parameters.Add("@FLAG", FbDbType.VarChar).Value = "emp";
                            sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                            sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное имя").ToString();
                            sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное имя").ToString();
                            sqlforupd.Parameters.Add("@ADR", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Адрес").ToString();
                            sqlforupd.Parameters.Add("@INN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("ИНН").ToString();
                            sqlforupd.Parameters.Add("@TEL", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Телефон").ToString();
                            sqlforupd.Parameters.Add("@CONT_NAME", FbDbType.VarChar).Value = null;
                            sqlforupd.Parameters.Add("@POS", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Должность").ToString();

                            sqlforupd.ExecuteNonQuery();
                            System.Windows.MessageBox.Show("Запись успешно обновлена!");
                        }
                        catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
                    }
                    else if (uc_dp_di.Tag.ToString() == "obj")
                    {
                        try
                        {
                            //Команда обновления
                            FbCommand sqlforupd = new FbCommand("UPD_OBJECTS", presh.preh.fb);
                            sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                            sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное наименование").ToString();
                            sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное наименование").ToString();

                            sqlforupd.ExecuteNonQuery();
                            System.Windows.MessageBox.Show("Запись успешно обновлена!");
                        }
                        catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
                    }
            }
        }


        /////////////////////////////Refresh записей-------------------------------------------------------
        private void but_refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "nom")
            {
                LoadGridNom(grid_di, grid_tree);

            }
            else
                if (uc_dp_di.Tag.ToString() == "char")
                {
                    LoadGridCharacter(grid_di, grid_tree);

                }
                else if (uc_dp_di.Tag.ToString() == "mes")
                {
                    grid_di.ItemsSource = presh.LoadGridMes();
                    presh.prop_gr_mean(grid_di);
                }
                else if (uc_dp_di.Tag.ToString() == "pro")
                {
                    grid_di.ItemsSource = presh.LoadGridProvider();
                    presh.prop_gr_mean(grid_di);

                }
                else if (uc_dp_di.Tag.ToString() == "obj")
                {
                    grid_di.ItemsSource = presh.LoadGridObjects();
                    presh.prop_gr_mean(grid_di);
                }
                else if (uc_dp_di.Tag.ToString() == "emp")
                {
                    grid_di.ItemsSource = presh.LoadGridEmployee();
                    presh.prop_gr_mean(grid_di);
                }
                else if (uc_dp_di.Tag.ToString() == "war")
                {
                    grid_di.ItemsSource = presh.LoadGridWarehouse();
                    presh.prop_gr_mean(grid_di);
                }
                else if (uc_dp_di.Tag.ToString() == "wp")
                {
                    grid_di.ItemsSource = presh.LoadGridWp();
                    presh.prop_gr_wp(grid_di);
                }
        }


        /////////////////////////////Удаление записей-------------------------------------------------------
        private void but_del_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "nom")
            {
                try
                {
                    //Команда удаления
                    FbCommand sqlforupd = new FbCommand("DEL_NOM", presh.preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.ExecuteNonQuery();
                    LoadGridNom(grid_di, grid_tree);
                    System.Windows.MessageBox.Show("Запись успешно удалена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
            }
            else
                if (uc_dp_di.Tag.ToString() == "char")
                {
                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("IUD_DI_CHAR", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@ID_TYPE", FbDbType.Integer).Value = null;
                        sqlforupd.Parameters.Add("@NAME", FbDbType.VarChar).Value = null;

                        sqlforupd.ExecuteNonQuery();
                        LoadGridCharacter(grid_di, grid_tree);
                        System.Windows.MessageBox.Show("Запись успешно удалена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
                }
                else if (uc_dp_di.Tag.ToString() == "mes")
                {
                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("DEL_MES", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.ExecuteNonQuery();
                        grid_di.ItemsSource = presh.LoadGridMes();
                        presh.prop_gr_mean(grid_di);
                        System.Windows.MessageBox.Show("Запись успешно удалена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
                }
                else if (uc_dp_di.Tag.ToString() == "pro")
                {

                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("DEL_CONTRACTORS", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.ExecuteNonQuery();
                        grid_di.ItemsSource = presh.LoadGridProvider();
                        presh.prop_gr_mean(grid_di);
                        System.Windows.MessageBox.Show("Запись успешно удалена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
                }
                else if (uc_dp_di.Tag.ToString() == "obj")
                {
                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("DEL_OBJECTS", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.ExecuteNonQuery();
                        grid_di.ItemsSource = presh.LoadGridObjects();
                        presh.prop_gr_mean(grid_di);
                        System.Windows.MessageBox.Show("Запись успешно удалена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
                }
                else if (uc_dp_di.Tag.ToString() == "emp")
                {
                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("DEL_CONTRACTORS", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.ExecuteNonQuery();

                        grid_di.ItemsSource = presh.LoadGridEmployee();
                        presh.prop_gr_mean(grid_di);
                        System.Windows.MessageBox.Show("Запись успешно удалена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
                }
                else if (uc_dp_di.Tag.ToString() == "war")
                {

                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("DEL_WAR", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.ExecuteNonQuery();
                        grid_di.ItemsSource = presh.LoadGridWarehouse();
                        presh.prop_gr_mean(grid_di);
                        System.Windows.MessageBox.Show("Запись успешно удалена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
                }

                else if (uc_dp_di.Tag.ToString() == "wp")
                {

                    try
                    {
                        //Команда удаления
                        FbCommand sqlforupd = new FbCommand("DEL_WP", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID_WP", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.ExecuteNonQuery();

                        grid_di.ItemsSource = presh.LoadGridWp();
                        presh.prop_gr_wp(grid_di);

                        presh.gc_arrive_list.ItemsSource = presh.dt_grid_list_arrived();
                        presh.prop_grid_arr(presh.gc_arrive_list);

                        presh.gc_leave_list.ItemsSource = presh.dt_grid_list_leave();
                        presh.gc_leave_det.ItemsSource = false;
                        presh.prop_grid_leave(presh.gc_leave_list);

                        presh.gc_move_list.ItemsSource = presh.dt_grid_list_move();
                        presh.gc_move_det.ItemsSource = false;

                        presh.prop_grid_move(presh.gc_move_list);

                        System.Windows.MessageBox.Show("Период успешно удален!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно удалить данный период!"); }
                }
        }


        private void grid_di_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (uc_dp_di.Tag.ToString() == "war")
                {

                    GridControl er = sender as GridControl;

                    LoadGridRes(grid_di_det, er);

                }

                else
                {
                    if (uc_dp_di.Tag.ToString() == "nom")
                    {





                        GridControl er = sender as GridControl;

                        LoadGridChar(grid_di_det, er);


                    }
                    else
                    {
                        if (uc_dp_di.Tag.ToString() == "wp")
                        {



                            GridControl er = sender as GridControl;

                            if (er.GetFocusedRowCellValue("IS_OPEN").ToString() == "1")
                            {
                                but_openwp.IsEnabled = false;
                                but_closewp.IsEnabled = true;
                                but_del.IsEnabled = false;
                            }
                            else
                            {
                                but_openwp.IsEnabled = true;
                                but_closewp.IsEnabled = false;
                                but_del.IsEnabled = true;
                            }



                        }
                    }
                }

            }

            catch { }


        }

        private void grid_tree_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            grid_di_det.ItemsSource = null;
            try
            {
                if (uc_dp_di.Tag.ToString() == "nom")
                {



                    GridControl er = sender as GridControl;

                    LoadGridNom(grid_di, er);




                }
                else
                    if (uc_dp_di.Tag.ToString() == "char")
                    {



                        GridControl er = sender as GridControl;

                        LoadGridCharacter(grid_di, er);




                    }

            }

            catch { }
        }




        /////////////////////////////////////////////Добавление деталей///////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void but_add_det_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (uc_dp_di.Tag.ToString() == "nom")
                {

                    insert_char_nom open_unity = new insert_char_nom();
                    open_unity.con = this;
                    open_unity.ShowDialog();

                }

                else
                {

                }

            }

            catch { }
        }


        //////////////////////////////Рефреш записей(detail) //////////////////////////
        private void but_refresh_det_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (uc_dp_di.Tag.ToString() == "nom")
                {

                    LoadGridChar(grid_di_det, grid_di);

                }

                else
                {

                }

            }

            catch { }


        }


        //////////////////////////////Удаление записей(detail) //////////////////////////
        private void but_del_det_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "nom")
            {

                try
                {
                    //Команда удаления
                    FbCommand sqlforupd = new FbCommand("IUD_NOM_CHAR", presh.preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di_det.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.Parameters.Add("@ID_NOM", FbDbType.Integer).Value = null;
                    sqlforupd.Parameters.Add("@ID_CHAR", FbDbType.Integer).Value = null;
                    sqlforupd.Parameters.Add("@ACC_PRICE", FbDbType.Decimal).Value = null;
                    sqlforupd.ExecuteNonQuery();

                    LoadGridChar(grid_di_det, grid_di);
                    System.Windows.MessageBox.Show("Запись успешно удалена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
            }
        }

        private void but_closewp_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Команда закрытия
                FbCommand sqlforupd = new FbCommand("CLOSING_WP", presh.preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;

                sqlforupd.Parameters.Add("@ID_WP", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.Parameters.Add("@ID_CR", FbDbType.Integer).Value = presh.preh.id_main_res;
                sqlforupd.ExecuteNonQuery();

                grid_di.ItemsSource = presh.LoadGridWp();
                presh.prop_gr_wp(grid_di);

                presh.gc_arrive_list.ItemsSource = presh.dt_grid_list_arrived();
                presh.prop_grid_arr(presh.gc_arrive_list);

                presh.gc_leave_list.ItemsSource = presh.dt_grid_list_leave();
                presh.gc_leave_det.ItemsSource = false;
                presh.prop_grid_leave(presh.gc_leave_list);

                presh.gc_move_list.ItemsSource = presh.dt_grid_list_move();
                presh.gc_move_det.ItemsSource = false;

                presh.prop_grid_move(presh.gc_move_list);

                System.Windows.MessageBox.Show("Период успешно закрыт!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно закрыть период!"); }
        }

        private void but_openwp_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Команда открытия
                FbCommand sqlforupd = new FbCommand("OPEN_WP", presh.preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;

                sqlforupd.Parameters.Add("@ID_WP", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.ExecuteNonQuery();

                grid_di.ItemsSource = presh.LoadGridWp();
                presh.prop_gr_wp(grid_di);

                presh.gc_arrive_list.ItemsSource = presh.dt_grid_list_arrived();
                presh.prop_grid_arr(presh.gc_arrive_list);

                presh.gc_leave_list.ItemsSource = presh.dt_grid_list_leave();
                presh.gc_leave_det.ItemsSource = false;
                presh.prop_grid_leave(presh.gc_leave_list);

                presh.gc_move_list.ItemsSource = presh.dt_grid_list_move();
                presh.gc_move_det.ItemsSource = false;

                presh.prop_grid_move(presh.gc_move_list);

                System.Windows.MessageBox.Show("Период успешно открыт!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно открыть период!"); }
        }

        private void but_showdoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frame_doc frdoc = new frame_doc();
            frdoc.conshow = this;
            frdoc.ShowDialog();
        }

        private void but_add_tree_ItemClick(object sender, ItemClickEventArgs e)
        {
            add_group_nom grad = new add_group_nom();
            grad.con = this;
            grad.ShowDialog();
        }

        private void but_del_tree_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Команда удаления
                FbCommand sqlforupd = new FbCommand("IUD_CHAR_GROUP", presh.preh.fb);
                sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforupd.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_tree.GetFocusedRowCellValue("ID").ToString();
                sqlforupd.Parameters.Add("@NAME", FbDbType.Integer).Value = null;

                sqlforupd.ExecuteNonQuery();

                grid_tree.ItemsSource = presh.LoadGridChar();
                presh.prop_gr_char(grid_tree);
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
        }

        private void but_refresh_tree_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "nom")
            {
                grid_tree.ItemsSource = presh.LoadGridNom();
                presh.prop_gr_nom(grid_tree);
                grid_tree.Columns[2].GroupIndex = 0;
            }
            else
                if (uc_dp_di.Tag.ToString() == "char")
                {
                    grid_tree.ItemsSource = presh.LoadGridChar();
                    presh.prop_gr_char(grid_tree);
                }
        }

        private void grid_tree_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {


                if (uc_dp_di.Tag.ToString() == "char")
                {

                    try
                    {


                        //Команда обновления
                        FbCommand sqlforupd = new FbCommand("IUD_CHAR_GROUP", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@FLAG", FbDbType.Integer).Value = "U";
                        sqlforupd.Parameters.Add("@ID", FbDbType.VarChar).Value = grid_tree.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@NAME", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Наименование").ToString();
                    


                        sqlforupd.ExecuteNonQuery();

                        grid_tree.ItemsSource = presh.LoadGridChar();
                        presh.prop_gr_char(grid_tree);
                        System.Windows.MessageBox.Show("Запись успешно обновлена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }

                }
            }
        }

        private void but_help_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "wp")
            {
                instruction ins = new instruction();
                ins.navBarWp.IsExpanded = true;
                ins.navBarWp2.IsSelected = true;
                ins.Show();
            }
            else
            {
                instruction ins = new instruction();
                ins.navBarDi.IsExpanded = true;
                ins.navBarDer2.IsSelected = true;
                ins.Show();
            }
        }
    }
}

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



        /////////////////////////////////Добавление записей-----------------------------------------
        private void but_nom_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (uc_dp_di.Tag.ToString() == "nom")
            {
                Insert_Nom open_unity = new Insert_Nom();
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
            else if (uc_dp_di.Tag.ToString() == "cus")
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


                if (uc_dp_di.Tag.ToString()  == "nom")
                {

                    try
                    {

                        //Вытаскиваем ID единицы измерения
                        FbCommand sqlforcombsrav = new FbCommand("select ID_MES from GET_ID_MES_UPD where SN ='" + grid_di.GetFocusedRowCellValue("Единица измерения").ToString() + "'", presh.preh.fb);
                        FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
                        DataTable wdf = new DataTable();
                        wdf.Load(readercombsrav);

                        //Вытаскиваем ID группы
                        FbCommand sqlforidgroup = new FbCommand("select ID_KIND from GET_ID_KIND_NOM where FN ='" + grid_di.GetFocusedRowCellValue("Группа").ToString() + "'", presh.preh.fb);
                        FbDataReader readerforidgroup = sqlforidgroup.ExecuteReader();
                        DataTable dt_id_group = new DataTable();
                        dt_id_group.Load(readerforidgroup);

                        //Команда обновления
                        FbCommand sqlforupd = new FbCommand("UPD_NOM", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное наименование").ToString();
                        sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное наименование").ToString();
                        sqlforupd.Parameters.Add("@MES", FbDbType.Integer).Value = wdf.Rows[0][0].ToString();
                        sqlforupd.Parameters.Add("@KNOM", FbDbType.Integer).Value = dt_id_group.Rows[0][0].ToString();
                        sqlforupd.Parameters.Add("@ART", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Артикул").ToString();
                        sqlforupd.Parameters.Add("@PURCH", FbDbType.Decimal).Value = grid_di.GetFocusedRowCellValue("Себестоимость").ToString();
                        if (grid_di.GetFocusedRowCellValue("Цена реализации").ToString() == "")
                        { sqlforupd.Parameters.Add("@SEL", FbDbType.Decimal).Value = null; }
                        else
                            sqlforupd.Parameters.Add("@SEL", FbDbType.Decimal).Value = grid_di.GetFocusedRowCellValue("Цена реализации").ToString();


                        sqlforupd.ExecuteNonQuery();
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
                        FbCommand sqlforupd = new FbCommand("UPD_PROV", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@NAME", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Имя").ToString();
                        sqlforupd.Parameters.Add("@ADR", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Адрес").ToString();
                        sqlforupd.Parameters.Add("@INN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("ИНН").ToString();
                        sqlforupd.Parameters.Add("@TEL", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Телефон").ToString();

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
                        FbCommand sqlforupd = new FbCommand("UPD_EMP", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@FN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Полное имя").ToString();
                        sqlforupd.Parameters.Add("@SN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Сокращенное имя").ToString();
                        sqlforupd.Parameters.Add("@INN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("ИНН").ToString();
                        sqlforupd.Parameters.Add("@POS", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Должность").ToString();

                        sqlforupd.ExecuteNonQuery();
                        System.Windows.MessageBox.Show("Запись успешно обновлена!");
                    }
                    catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
                }
                else if (uc_dp_di.Tag.ToString() == "cus")
                {
                    try
                    {
                        //Команда обновления
                        FbCommand sqlforupd = new FbCommand("UPD_CUS", presh.preh.fb);
                        sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                        sqlforupd.Parameters.Add("@NAME", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Имя").ToString();
                        sqlforupd.Parameters.Add("@CONT_NAME", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Имя представителя").ToString();
                        sqlforupd.Parameters.Add("@ADR", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Адрес").ToString();
                        sqlforupd.Parameters.Add("@TEL", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("Телефон").ToString();
                        sqlforupd.Parameters.Add("@INN", FbDbType.VarChar).Value = grid_di.GetFocusedRowCellValue("ИНН").ToString();

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
                grid_di.ItemsSource = presh.LoadGridNom();
                presh.prop_gr_nom(grid_di);
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
            else if (uc_dp_di.Tag.ToString() == "cus")
            {
                grid_di.ItemsSource = presh.LoadGridCustomers();
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
                presh.prop_gr_war(grid_di);
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
                    grid_di.ItemsSource = presh.LoadGridNom();
                    presh.prop_gr_nom(grid_di);
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
                    FbCommand sqlforupd = new FbCommand("DEL_PROV", presh.preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.ExecuteNonQuery();
                    grid_di.ItemsSource = presh.LoadGridProvider();
                    presh.prop_gr_mean(grid_di);
                    System.Windows.MessageBox.Show("Запись успешно удалена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
            }
            else if (uc_dp_di.Tag.ToString() == "cus")
            {
                try
                {
                    //Команда удаления
                    FbCommand sqlforupd = new FbCommand("DEL_CUS", presh.preh.fb);
                    sqlforupd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforupd.Parameters.Add("@ID", FbDbType.Integer).Value = grid_di.GetFocusedRowCellValue("ID").ToString();
                    sqlforupd.ExecuteNonQuery();
                    grid_di.ItemsSource = presh.LoadGridCustomers();
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
                    FbCommand sqlforupd = new FbCommand("DEL_EMP", presh.preh.fb);
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
                    presh.prop_gr_war(grid_di);
                    System.Windows.MessageBox.Show("Запись успешно удалена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using GreatestApplicatioInMyLife.UserControls;

namespace GreatestApplicatioInMyLife
{
    /// <summary>
    /// Логика взаимодействия для edit_roles.xaml
    /// </summary>
    public partial class edit_roles : Window
    {
        public Admin_panel con;

        public string fnom;
        public string fchar;
        public string femp;
        public string fcontr;
        public string fwar;
        public string fmes;
        public string fobj;
        public string farr;
        public string fleave;
        public string fmove;
      


        public edit_roles()
        {
            InitializeComponent();
        }

        private void window_edit_role_Activated(object sender, EventArgs e)
        {
              ////////////////////////////////Процедура проверки номенклатура
                        FbCommand sqlpas = new FbCommand("select * from GET_ITEM_ALLOW("+con.grid_roles.GetFocusedRowCellValue("ID").ToString()+
                            ", 'Справочник Номенклатура')", con.preh.fb);
                        FbDataReader readerpas = sqlpas.ExecuteReader();
                        DataTable dt_pas = new DataTable();
                        dt_pas.Load(readerpas);
                        if (dt_pas.Rows[0][0].ToString() == "0")
                        {
                            chnom.IsChecked = false;
                        }
                        else
                        {
                            chnom.IsChecked = true;
                           
                        }


                        ////////////////////////////////Процедура проверки единиц измерения
                        FbCommand sqlmes = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Справочник Единицы измерения')", con.preh.fb);
                        FbDataReader readermes = sqlmes.ExecuteReader();
                        DataTable dt_mes = new DataTable();
                        dt_mes.Load(readermes);
                        if (dt_mes.Rows[0][0].ToString() == "0")
                        {
                            chmes.IsChecked = false;
                        }
                        else
                        {
                            chmes.IsChecked = true;
                           
                        }


                        ////////////////////////////////Процедура проверки характеристик
                        FbCommand sqlch = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Справочник Характеристики')", con.preh.fb);
                        FbDataReader readerch = sqlch.ExecuteReader();
                        DataTable dt_ch = new DataTable();
                        dt_ch.Load(readerch);
                        if (dt_ch.Rows[0][0].ToString() == "0")
                        {
                            chchar.IsChecked = false;
                        }
                        else
                        {
                            chchar.IsChecked = true;
                           
                        }


                        ////////////////////////////////Процедура проверки контрагентов
                        FbCommand sqlcon = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Справочник Контрагенты')", con.preh.fb);
                        FbDataReader readercon = sqlcon.ExecuteReader();
                        DataTable dt_con = new DataTable();
                        dt_con.Load(readercon);
                        if (dt_con.Rows[0][0].ToString() == "0")
                        {
                            chcontr.IsChecked = false;
                        }
                        else
                        {
                            chcontr.IsChecked = true;
                           
                        }


                        ////////////////////////////////Процедура проверки объектов
                        FbCommand sqlobj = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Справочник Объекты')", con.preh.fb);
                        FbDataReader readerobj = sqlobj.ExecuteReader();
                        DataTable dt_obj = new DataTable();
                        dt_obj.Load(readerobj);
                        if (dt_obj.Rows[0][0].ToString() == "0")
                        {
                            chobj.IsChecked = false;
                        }
                        else
                        {
                            chobj.IsChecked = true;
                            
                        }


                        ////////////////////////////////Процедура проверки сотрудников
                        FbCommand sqlemp = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Справочник Сотрудники')", con.preh.fb);
                        FbDataReader readeremp = sqlemp.ExecuteReader();
                        DataTable dt_emp = new DataTable();
                        dt_emp.Load(readeremp);
                        if (dt_emp.Rows[0][0].ToString() == "0")
                        {
                            chemp.IsChecked = false;
                        }
                        else
                        {
                            chemp.IsChecked = true;
                          
                        }


                        ////////////////////////////////Процедура проверки складов
                        FbCommand sqlpaswar = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Справочник Склады')", con.preh.fb);
                        FbDataReader readerpaswar = sqlpaswar.ExecuteReader();
                        DataTable dt_paswar = new DataTable();
                        dt_paswar.Load(readerpaswar);
                        if (dt_paswar.Rows[0][0].ToString() == "0")
                        {
                            chwar.IsChecked = false;
                        }
                        else
                        {
                            chwar.IsChecked = true;
                           
                        }


                        ////////////////////////////////Процедура проверки прихода
                        FbCommand sqlpasarr = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Журнал прихода')", con.preh.fb);
                        FbDataReader readerpasarr = sqlpasarr.ExecuteReader();
                        DataTable dt_pasarr = new DataTable();
                        dt_pasarr.Load(readerpasarr);
                        if (dt_pasarr.Rows[0][0].ToString() == "0")
                        {
                            charr.IsChecked = false;
                        }
                        else
                        {
                            charr.IsChecked = true;
                           
                        }


                        ////////////////////////////////Процедура проверки расхода
                        FbCommand sqlpasleave = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Журнал расхода')", con.preh.fb);
                        FbDataReader readerpasleave = sqlpasleave.ExecuteReader();
                        DataTable dt_pasleave = new DataTable();
                        dt_pasleave.Load(readerpasleave);
                        if (dt_pasleave.Rows[0][0].ToString() == "0")
                        {
                            chleave.IsChecked = false;
                        }
                        else
                        {
                            chleave.IsChecked = true;
                            
                        }


                        ////////////////////////////////Процедура проверки перемещения
                        FbCommand sqlpasmove = new FbCommand("select * from GET_ITEM_ALLOW (" + con.grid_roles.GetFocusedRowCellValue("ID").ToString() +
                            ",'Журнал перемещения')", con.preh.fb);
                        FbDataReader readerpasmove = sqlpasmove.ExecuteReader();
                        DataTable dt_pasmove = new DataTable();
                        dt_pasmove.Load(readerpasmove);
                        if (dt_pasmove.Rows[0][0].ToString() == "0")
                        {
                            chmove.IsChecked = false;
                           
                        }
                        else
                        {
                            chmove.IsChecked = true;
                        }


        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_apply_Click(object sender, RoutedEventArgs e)
        {
            if (chnom.IsChecked == true) fnom = "1";            
            else fnom = "0";

            if (chmes.IsChecked == true) fmes = "1";
            else fmes = "0";

            if (chobj.IsChecked == true) fobj = "1";
            else fobj = "0";

            if (chcontr.IsChecked == true) fcontr = "1";
            else fcontr = "0";

            if (chemp.IsChecked == true) femp = "1";
            else femp = "0";

            if (chwar.IsChecked == true) fwar = "1";
            else fwar = "0";

            if (chchar.IsChecked == true) fchar = "1";
            else fchar = "0";

            if (charr.IsChecked == true) farr = "1";
            else farr = "0";

            if (chleave.IsChecked == true) fleave = "1";
            else fleave = "0";

            if (chmove.IsChecked == true) fmove = "1";
            else fmove = "0";

            try
            {


         
                //Команда обновления
                FbCommand sqlforin = new FbCommand("CHANGE_ITEM_ALLOW", con.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@ID_ROLE", FbDbType.Integer).Value = con.grid_roles.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ALLOW_NOM", FbDbType.Char).Value = fnom;
                sqlforin.Parameters.Add("@ALLOW_MES", FbDbType.Char).Value = fmes;
                sqlforin.Parameters.Add("@ALLOW_CHAR", FbDbType.Char).Value = fchar;
                sqlforin.Parameters.Add("@ALLOW_CON", FbDbType.Char).Value = fcontr;
                sqlforin.Parameters.Add("@ALLOW_OBJ", FbDbType.Char).Value = fobj;
                sqlforin.Parameters.Add("@ALLOW_EMP", FbDbType.Char).Value = femp;
                sqlforin.Parameters.Add("@ALLOW_WAR", FbDbType.Char).Value = fwar;
                sqlforin.Parameters.Add("@ALLOW_ARR", FbDbType.Char).Value = farr;
                sqlforin.Parameters.Add("@ALLOW_LEAVE", FbDbType.Char).Value = fleave;
                sqlforin.Parameters.Add("@ALLOW_MOVE", FbDbType.Char).Value = fmove;
              




                sqlforin.ExecuteNonQuery();



                this.Close();
                con.grid_roles.ItemsSource = con.dt_grid_roles();
                con.prop_grid_roles(con.grid_roles);
                System.Windows.MessageBox.Show("Изменения успешно применены!");


            }


            catch
            {
                System.Windows.MessageBox.Show("Невозможно применить изменения. Проверьте подключение к базе!");
            }



        }

        private void chnom_GotFocus(object sender, RoutedEventArgs e)
        {
            bt_apply.IsEnabled = true;
        }

       
      






    }
}

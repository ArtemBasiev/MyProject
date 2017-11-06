using System;
using System.Security;
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
using System.Windows.Shapes;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using DevExpress.Xpf;
using DevExpress.Xpf.Editors;
using DevExpress.XtraGrid;
using GreatestApplicatioInMyLife.UserControls;
using System.IO;

namespace GreatestApplicatioInMyLife
{
    /// <summary>
    /// Логика взаимодействия для AutWindow.xaml
    /// </summary>
    public partial class AutWindow : Window
    {
        public FbConnection fb;
        public string id_main_war;
        public string id_main_res;
        public AutWindow()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow openmain = new MainWindow();

            try
            {

                //InsertDialog openinsert = new InsertDialog();
            FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

            fb_con.Charset = "UTF8";
            fb_con.UserID = "SYSDBA";
            fb_con.Password = "masterkey";
            fb_con.Database = "C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\DB\\MAINDB.fdb";
            fb_con.ServerType = 0;
            fb = new FbConnection(fb_con.ToString());
            fb.Open();
         












            try
            {

                ////////////////////////////////Достаем ID склада
                FbCommand sqlforvar_war = new FbCommand("select ID_WAR from GET_WAR WHERE NAME_WAR ='" + cb_choose_war.Text + "'", fb);
                FbDataReader readerwar = sqlforvar_war.ExecuteReader();
                DataTable dt_war = new DataTable();
                dt_war.Load(readerwar);
                id_main_war = dt_war.Rows[0][0].ToString();


                ////////////////////////////////Достаем ID работника
                FbCommand sqlforvar_res = new FbCommand("select ID_RES from GET_RES_FOR_AUT WHERE NAME_RES ='" + cb_choose_user.Text + "'", fb);
                FbDataReader readerres = sqlforvar_res.ExecuteReader();
                DataTable dt_res = new DataTable();
                dt_res.Load(readerres);
                id_main_res = dt_res.Rows[0][0].ToString();

               
                        ////////////////////////////////Процедура проверки пароля
                        FbCommand sqlpas = new FbCommand("select * from PASSWORD_CHECK ('"+pb_user.Text+"','" + cb_choose_user.Text + "')", fb);
                        FbDataReader readerpas = sqlpas.ExecuteReader();
                        DataTable dt_pas = new DataTable();
                        dt_pas.Load(readerpas);
                        if(dt_pas.Rows[0][0].ToString()=="1")
                        {
                            System.Windows.MessageBox.Show("Введите правильный пароль!");
                        }
                        else
                        {
                            try
                            {

                                ////////////////////////////////Доступ к справочнику номенклатура
                                FbCommand sql_itnom = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Номенклатура')", fb);
                                FbDataReader reader_itnom = sql_itnom.ExecuteReader();
                                DataTable dt_itnom = new DataTable();
                                dt_itnom.Load(reader_itnom);
                                if (dt_itnom.Rows[0][0].ToString() == "0")
                                 openmain.Nom.IsVisible = false;

                                ////////////////////////////////Доступ к справочнику единицы измерения
                                FbCommand sql_itmes = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Единицы измерения')", fb);
                                FbDataReader reader_itmes = sql_itmes.ExecuteReader();
                                DataTable dt_itmes = new DataTable();
                                dt_itmes.Load(reader_itmes);
                                if (dt_itmes.Rows[0][0].ToString() == "0")
                                    openmain.brbtMeasure.IsVisible = false;

                                ////////////////////////////////Доступ к справочнику Характеристики
                                FbCommand sql_itchar = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Характеристики')", fb);
                                FbDataReader reader_itchar = sql_itchar.ExecuteReader();
                                DataTable dt_itchar = new DataTable();
                                dt_itchar.Load(reader_itchar);
                                if (dt_itchar.Rows[0][0].ToString() == "0")
                                    openmain.brbt_char.IsVisible = false;

                                ////////////////////////////////Доступ к справочнику Контрагенты
                                FbCommand sql_itcon = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Контрагенты')", fb);
                                FbDataReader reader_itcon = sql_itcon.ExecuteReader();
                                DataTable dt_itcon = new DataTable();
                                dt_itcon.Load(reader_itcon);
                                if (dt_itcon.Rows[0][0].ToString() == "0")
                                    openmain.brbt_provider.IsVisible = false;

                                ////////////////////////////////Доступ к справочнику Объекты
                                FbCommand sql_itobj = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Объекты')", fb);
                                FbDataReader reader_itobj = sql_itobj.ExecuteReader();
                                DataTable dt_itobj = new DataTable();
                                dt_itobj.Load(reader_itobj);
                                if (dt_itobj.Rows[0][0].ToString() == "0")
                                    openmain.brbt_customer.IsVisible = false;

                                ////////////////////////////////Доступ к справочнику Сотрудники
                                FbCommand sql_itemp = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Сотрудники')", fb);
                                FbDataReader reader_itemp = sql_itemp.ExecuteReader();
                                DataTable dt_itemp = new DataTable();
                                dt_itemp.Load(reader_itemp);
                                if (dt_itemp.Rows[0][0].ToString() == "0")
                                    openmain.brbt_employee.IsVisible = false;

                                ////////////////////////////////Доступ к справочнику Склады
                                FbCommand sql_itwar = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Справочник Склады')", fb);
                                FbDataReader reader_itwar = sql_itwar.ExecuteReader();
                                DataTable dt_itwar = new DataTable();
                                dt_itwar.Load(reader_itwar);
                                if (dt_itwar.Rows[0][0].ToString() == "0")
                                    openmain.brbt_warehouse.IsVisible = false;

                                ////////////////////////////////Доступ к журналу прихода
                                FbCommand sql_itarr = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Журнал прихода')", fb);
                                FbDataReader reader_itarr = sql_itarr.ExecuteReader();
                                DataTable dt_itarr = new DataTable();
                                dt_itarr.Load(reader_itarr);
                                if (dt_itarr.Rows[0][0].ToString() == "0")
                                    openmain.arrive_documents.Visibility = Visibility.Collapsed;

                                ////////////////////////////////Доступ к журналу расхода
                                FbCommand sql_itleav = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Журнал расхода')", fb);
                                FbDataReader reader_itleav = sql_itleav.ExecuteReader();
                                DataTable dt_itleav = new DataTable();
                                dt_itleav.Load(reader_itleav);
                                if (dt_itleav.Rows[0][0].ToString() == "0")
                                    openmain.leave_documents.Visibility = Visibility.Collapsed;

                                ////////////////////////////////Доступ к журналу перемещения
                                FbCommand sql_itmove = new FbCommand("select * from ITEM_CHECK ('" + id_main_res + "','Журнал перемещения')", fb);
                                FbDataReader reader_itmove = sql_itmove.ExecuteReader();
                                DataTable dt_itmove = new DataTable();
                                dt_itmove.Load(reader_itmove);
                                if (dt_itmove.Rows[0][0].ToString() == "0")
                                    openmain.movement_documents.Visibility = Visibility.Collapsed;



                                openmain.preh = this;
                           
                                openmain.Show();
                                this.Close();
                            }

                            catch
                            {

                                System.Windows.MessageBox.Show("Введенные данные неверны");


                            }
                        }
                    
                
            }
            catch { System.Windows.MessageBox.Show("Укажите все необходимые данные!"); }

          

          }
            catch { System.Windows.MessageBox.Show("Не удается подключиться к базе данных!"); }
        }

        private void cb_choose_war_Loaded(object sender, RoutedEventArgs e)
        {
            FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

            fb_con.Charset = "UTF8";
            fb_con.UserID = "SYSDBA";
            fb_con.Password = "masterkey";
            fb_con.Database = "C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\DB\\MAINDB.fdb";
            fb_con.ServerType = 0;

            fb = new FbConnection(fb_con.ToString());
            fb.Open();

            

            cb_choose_war.Items.Clear();
            
            FbCommand sqlforcomb = new FbCommand("select NAME_WAR from GET_WAR", fb);

            FbDataReader readercomb = sqlforcomb.ExecuteReader();

            if (readercomb.HasRows) // если есть данные
            {
              


                DataSet newset1 = new DataSet("newset1");
                DataTable dtcomb = new DataTable();
                while (readercomb.Read())
                {
                    try
                    {
                        string resultvalue = readercomb.GetString(0);
                        cb_choose_war.Items.Add(resultvalue);
                    }
                    catch { }

                }
            }
        }

        private void cb_choose_war_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

            fb_con.Charset = "UTF8";
            fb_con.UserID = "SYSDBA";
            fb_con.Password = "masterkey";
            fb_con.Database = "C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\DB\\MAINDB.fdb";
            fb_con.ServerType = 0;

            fb = new FbConnection(fb_con.ToString());
            fb.Open();


            cb_choose_user.Clear();
            cb_choose_user.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select NAME_RES from GET_RES_FOR_AUT WHERE NAME_WAR ='" + cb_choose_war .Text+ "'", fb);

            FbDataReader readercomb = sqlforcomb.ExecuteReader();

            if (readercomb.HasRows) // если есть данные
            {



                DataSet newset1 = new DataSet("newset1");
                DataTable dtcomb = new DataTable();
                while (readercomb.Read())
                {
                    try
                    {
                        string resultvalue = readercomb.GetString(0);
                        cb_choose_user.Items.Add(resultvalue);
                    }
                    catch { }

                }
            }
        }

        private void rb_user_Checked(object sender, RoutedEventArgs e)
        {
            sp_login.Visibility = Visibility.Visible;
            sp_admin.Visibility = Visibility.Collapsed;
        }

        private void rb_admin_Checked(object sender, RoutedEventArgs e)
        {
            sp_login.Visibility = Visibility.Hidden;
            sp_admin.Visibility = Visibility.Visible;
        }

        private void autwindow_Activated(object sender, EventArgs e)
        {
            rb_user.IsChecked = true;
        }




        // Вход администратора
        private void btLoginAdm_Click(object sender, RoutedEventArgs e)
        {
            Admin_panel openmain = new Admin_panel();

            try
            {

     
                FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

                fb_con.Charset = "UTF8";
                fb_con.UserID = "SYSDBA";
                fb_con.Password = "masterkey";
                fb_con.Database = "C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\DB\\MAINDB.fdb";
                fb_con.ServerType = 0;
                fb = new FbConnection(fb_con.ToString());
                fb.Open();


                try
                {


                    ////////////////////////////////Процедура проверки пароля
                    FbCommand sqlpas = new FbCommand("select * from CHECK_ADMIN_PAS('" + pb_admin.Text + "')", fb);
                    FbDataReader readerpas = sqlpas.ExecuteReader();
                    DataTable dt_pas = new DataTable();
                    dt_pas.Load(readerpas);
                    if (dt_pas.Rows[0][0].ToString() == "1")
                    {
                        System.Windows.MessageBox.Show("Введите правильный пароль!");
                    }
                    else
                    {
                        try
                        {
                            openmain.preh = this;

                            openmain.Show();
                            this.Close();
                        }

                        catch
                        {

                            System.Windows.MessageBox.Show("Введенные данные неверны");


                        }
                    }


                }
                catch { System.Windows.MessageBox.Show("Укажите все необходимые данные!"); }



            }
            catch { System.Windows.MessageBox.Show("Не удается подключиться к базе данных!"); }
        }

       
    }
}

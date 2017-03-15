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
            

            //InsertDialog openinsert = new InsertDialog();
            FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

            fb_con.Charset = "UTF8";
            fb_con.UserID = "SYSDBA";
            fb_con.Password = "masterkey";
            fb_con.Database = "C:\\Users\\ARTEM\\Documents\\Visual Studio 2013\\Projects\\GreatestApplicatioInMyLife\\DB\\MAINDB.fdb";
            fb_con.ServerType = 0;

            fb = new FbConnection(fb_con.ToString());


            fb.Open();
            FbCommand sqlforvar_war = new FbCommand("select ID_WAR from GET_WAR_RES WHERE NAME_WAR ='" + cb_choose_war.Text + "'", fb);
            FbDataReader readerwar = sqlforvar_war.ExecuteReader();
            DataTable dt_war = new DataTable();
            dt_war.Load(readerwar);
            id_main_war=dt_war.Rows[0][0].ToString();

            FbCommand sqlforvar_res = new FbCommand("select ID_RES from GET_WAR_RES WHERE NAME_RES ='" + cb_choose_user.Text + "'", fb);
            FbDataReader readerres = sqlforvar_res.ExecuteReader();
            DataTable dt_res = new DataTable();
            dt_res.Load(readerres);
            id_main_res = dt_war.Rows[0][0].ToString();

            try
            {
                
                //openinsert.conforins = this;

                openmain.preh = this;
                //conect_for_uc.presh = this;
                openmain.Show();
                this.Close();
            }

            catch
            {

                System.Windows.MessageBox.Show("Введенные данные неверны");


            }
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
            
            FbCommand sqlforcomb = new FbCommand("select NAME_WAR from GET_WAR_RES", fb);

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
            FbCommand sqlforcomb = new FbCommand("select NAME_RES from GET_WAR_RES WHERE NAME_WAR ='" + cb_choose_war .Text+ "'", fb);

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

       
    }
}

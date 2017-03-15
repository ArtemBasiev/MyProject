using FirebirdSql.Data.FirebirdClient;
using GreatestApplicatioInMyLife.UserControls;
using System;
using System.Collections.Generic;
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

    public partial class Insert_War : Window
    {
        public uc_dockpanel_di con_ins_war;
        public Insert_War()
        {
            InitializeComponent();
        }



        ////----------------------------Заполнение комбобокса ответственный----------------------
        public void load_cb_res()
        {
            cb_res.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_RES", con_ins_war.presh.preh.fb);
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
                        cb_res.Items.Add(resultvalue);
                    }
                    catch { }

                }



            }
        }



        private void bt_create_war_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Вытаскиваем ID сотрудника
                FbCommand sqlforcombsrav = new FbCommand("select ID_RES from GET_ID_RES where SN ='" + cb_res.Text + "'", con_ins_war.presh.preh.fb);
                FbDataReader readercombsrav = sqlforcombsrav.ExecuteReader();
                DataTable wdf = new DataTable();
                wdf.Load(readercombsrav);
                string drr = cb_res.Text;



                FbCommand sqlforin = new FbCommand("INS_WAR", con_ins_war.presh.preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FN", FbDbType.VarChar).Value = tb_fn_war.Text;
                sqlforin.Parameters.Add("@SN", FbDbType.VarChar).Value = tb_sn_war.Text;
                sqlforin.Parameters.Add("@ADR", FbDbType.VarChar).Value = tb_adr_war.Text;
                sqlforin.Parameters.Add("@RES", FbDbType.VarChar).Value = wdf.Rows[0][0].ToString();
                sqlforin.ExecuteNonQuery();


                tb_fn_war.Clear();
                tb_sn_war.Clear();
                tb_adr_war.Clear();
                cb_res.Clear();
                System.Windows.MessageBox.Show("Запись успешно добавлена!");
            }


            catch
            {
                System.Windows.MessageBox.Show("Не все поля заполнены или заполненны некорректно!");
            }
        }

        private void win_ins_war_Activated(object sender, EventArgs e)
        {
            load_cb_res();
        }

    
    }
}

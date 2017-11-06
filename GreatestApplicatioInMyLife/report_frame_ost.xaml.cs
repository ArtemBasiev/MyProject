using FirebirdSql.Data.FirebirdClient;
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
    /// <summary>
    /// Логика взаимодействия для report_frame_ost.xaml
    /// </summary>
    public partial class report_frame_ost : Window
    {

        public MainWindow confr;

        public string flag_rep;


        public string flag_date;
        public string t_date;

        public string flag_nom;
        public string nom;

        public report_frame_ost()
        {
            InitializeComponent();
        }


        /////////////////////Заполнение комбобокса имя номенклатуры------------------------
        public void load_cb_nom_name()
        {
            cb_nom.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_NOM", confr.preh.fb);

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
                        cb_nom.Items.Add(resultvalue);
                    }
                    catch { }

                }
            }
        }



        /////////////////////Заполнение комбобокса группа номенклатуры------------------------
        public void load_cb_nom_group()
        {
            cb_nom.Items.Clear();
            FbCommand sqlforcomb = new FbCommand("select * from GET_GROUP_NOM", confr.preh.fb);

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
                        cb_nom.Items.Add(resultvalue);
                    }
                    catch { }

                }
            }
        }



        /// ////////////////////////////Активация окна---------------------
        private void Window_Activated(object sender, EventArgs e)
        {
            rb_wp.IsChecked = true;
            rb_allnom.IsChecked = true;
            
        }


        /// ////////////////////////////Кнопка рабочий период---------------------
        private void rb_wp_Checked(object sender, RoutedEventArgs e)
        {
            sp_date.Visibility = Visibility.Hidden;
            flag_date = "wp";
            t_date = "01.01.2017";
        }


        /// ////////////////////////////Кнопка произволный период---------------------
        private void rb_cust_Checked(object sender, RoutedEventArgs e)
        {
            sp_date.Visibility = Visibility.Visible;
            flag_date = "cust";
  
            dp_to.Text = DateTime.Today.ToString();
           
        }


        /// ////////////////////////////Кнопка вся номенклатура---------------------
        private void rb_allnom_Checked(object sender, RoutedEventArgs e)
        {
            sp_nom.Visibility = Visibility.Hidden;
            flag_nom="all";
        }


        /// ////////////////////////////Кнопка наименование---------------------
        private void rb_namenom_Checked(object sender, RoutedEventArgs e)
        {
            sp_nom.Visibility = Visibility.Visible;
            flag_nom = "name";
            load_cb_nom_name();
            cb_nom.SelectedIndex=0;
        }


        /// ////////////////////////////Кнопка группа---------------------
        private void rb_groupnom_Checked(object sender, RoutedEventArgs e)
        {
            sp_nom.Visibility = Visibility.Visible;
            flag_nom = "group";
            load_cb_nom_group();
            cb_nom.SelectedIndex = 0;
        }

        private void cb_nom_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            nom = cb_nom.Text;
        }

        private void bt_can_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_show_Click(object sender, RoutedEventArgs e)
        {
            Report_Window repwind = new Report_Window();
            repwind.Tag = flag_rep;
            repwind.rfcon = this;
            repwind.Show();
       
        }

        private void dp_to_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            t_date = dp_to.Text;
        }

        private void bt_help_Click(object sender, RoutedEventArgs e)
        {
            instruction ins = new instruction();
            ins.navBarReport.IsExpanded = true;
            ins.navBarRep2.IsSelected = true;
            ins.Show();
        }
    }
}

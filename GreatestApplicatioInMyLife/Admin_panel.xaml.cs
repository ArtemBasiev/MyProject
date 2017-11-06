using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using FirebirdSql.Data.FirebirdClient;
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
    /// Логика взаимодействия для Admin_panel.xaml
    /// </summary>
    public partial class Admin_panel : Window
    {
        public AutWindow preh;
        public Admin_panel()
        {
            InitializeComponent();
        }


        /////////////////////////DataTable для списка складов -------------------------------
        public DataTable dt_grid_war()
        {
            DataTable dt = new DataTable();
            //flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select ID, SN from PROC_SELECT_WAREHOUSE", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Наименование";


            //flag = true;
            return dt;
        }


        //////////////////Свойства грида склады
        public void prop_grid_war(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Width = 250;

          


        }


        /////////////////////////DataTable для ответственных -------------------------------
        public DataTable dt_grid_res()
        {
            DataTable dt = new DataTable();
            //flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from PROC_SELECT_RESPONSIBLE where ID_WAR = " + grid_war.GetFocusedRowCellValue("ID").ToString(), preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            //dt.Columns[1].ColumnName = "ID документа";
            //dt.Columns[2].ColumnName = "ID документа";
            dt.Columns[2].ColumnName = "Имя";
            dt.Columns[3].ColumnName = "Должность";
            //flag = true;
            return dt;
        }


        /////////Grid_properties для ответственных
        public void prop_gr_res(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].Width = 150;
            name_grid.Columns[3].Width = 250;
            name_grid.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            name_grid.Columns[3].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;


        }









        /////////////////////////DataTable для списка ролей -------------------------------
        public DataTable dt_grid_roles()
        {
            DataTable dt = new DataTable();
            //flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select * from SEL_ROLES", preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Наименование";


            //flag = true;
            return dt;
        }


        //////////////////Свойства грида роли
        public void prop_grid_roles(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Width = 250;


        }


        /////////////////////////DataTable для грила пользователи -------------------------------
        public DataTable dt_grid_users()
        {
            DataTable dt = new DataTable();
            //flag = false;
            if (preh.fb.State == ConnectionState.Closed)
            { preh.fb.Open(); }
            FbCommand command = new FbCommand("select *  from SEL_USERS where ID_ROLE = " + grid_roles.GetFocusedRowCellValue("ID").ToString(), preh.fb);
            FbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[2].ColumnName = "Имя";
            dt.Columns[3].ColumnName = "Пароль";
            //flag = true;
            return dt;
        }


        /////////Grid_properties для грида пользователи
        public void prop_gr_users(GridControl name_grid)
        {
            name_grid.Columns[0].Visible = false;
            name_grid.Columns[1].Visible = false;
            name_grid.Columns[2].Width = 150;
            name_grid.Columns[3].Width = 150;
            name_grid.Columns[2].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;
            //name_grid.Columns[3].ReadOnly = ReadOnlyAttribute.Yes.IsReadOnly;


        }





        private void grid_war_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            grid_res.ItemsSource = dt_grid_res();
            prop_gr_res(grid_res);
        }

        private void grid_war_Loaded(object sender, RoutedEventArgs e)
        {
            grid_war.ItemsSource = dt_grid_war();
            prop_grid_war(grid_war);
        }

        private void grid_roles_Loaded(object sender, RoutedEventArgs e)
        {
            grid_roles.ItemsSource = dt_grid_roles();
            prop_grid_roles(grid_roles);
        }

        private void grid_roles_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            grid_users.ItemsSource = dt_grid_users();
            prop_gr_users(grid_users);
        }

        private void but_nom_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            frame_emp fremp = new frame_emp();
            fremp.con1 = this;
            fremp.ShowDialog();
        }

        private void but_del_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {

                //Команда удаления
                FbCommand sqlforin = new FbCommand("IUD_RESPONSIBLES", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = grid_res.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_WAR", FbDbType.Integer).Value = null;
                sqlforin.Parameters.Add("@ID_RES", FbDbType.Integer).Value = null;

                sqlforin.ExecuteNonQuery();
                //flag = false;


                grid_war.ItemsSource = dt_grid_war();
                prop_grid_war(grid_war);
                //flag = true;
                System.Windows.MessageBox.Show("Запись успешно удалена!");
            }
            catch { System.Windows.MessageBox.Show("Невозможно удалить запись!"); }
        }

        private void but_refresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                grid_war.ItemsSource = dt_grid_war();
                prop_grid_war(grid_war);
            }
            catch { }
       
        }

        private void but_add_user_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            add_user user = new add_user();
            user.con = this;
            user.ShowDialog();
        }

        private void but_del_user_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {




                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_USERS", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = grid_users.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@ID_ROLE", FbDbType.Integer).Value = null;
                sqlforin.Parameters.Add("@NAME_RES", FbDbType.VarChar).Value = null;
                sqlforin.Parameters.Add("@PAS", FbDbType.VarChar).Value = null;


                sqlforin.ExecuteNonQuery();


             
                grid_roles.ItemsSource = dt_grid_roles();
                prop_grid_roles(grid_roles);
                System.Windows.MessageBox.Show("Запись успешно удалена!");
              

            }


            catch
            {
                System.Windows.MessageBox.Show("Невозможно удалить запись!");
            }
        }

        private void grid_users_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    
                    //Команда обновления
                    FbCommand sqlforin = new FbCommand("IUD_USERS", preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = grid_users.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@ID_ROLE", FbDbType.Integer).Value = null;
                    sqlforin.Parameters.Add("@NAME_RES", FbDbType.VarChar).Value = null;
                    sqlforin.Parameters.Add("@PAS", FbDbType.VarChar).Value = grid_users.GetFocusedRowCellValue("Пароль").ToString();
                    sqlforin.ExecuteNonQuery();
                    //flag = false;


                    grid_roles.ItemsSource = dt_grid_roles();
                    prop_grid_roles(grid_roles);
                    //flag = true;
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }

        private void but_refresh_tree_roles_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                grid_roles.ItemsSource = dt_grid_roles();
                prop_grid_roles(grid_roles);
            }
            catch { }
        }

        private void but_refresh_tree_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                grid_war.ItemsSource = dt_grid_war();
                prop_grid_war(grid_war);
            }
            catch { }
        }

        private void but_add_role1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            add_role adrole = new add_role();
            adrole.con = this;
            adrole.ShowDialog();
        }

        private void but_del_role1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {




                //Команда добавления
                FbCommand sqlforin = new FbCommand("IUD_ROLES", preh.fb);
                sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "D";
                sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = grid_roles.GetFocusedRowCellValue("ID").ToString();
                sqlforin.Parameters.Add("@NAME", FbDbType.VarChar).Value = null;




                sqlforin.ExecuteNonQuery();



   
                grid_roles.ItemsSource = dt_grid_roles();
                prop_grid_roles(grid_roles);
                System.Windows.MessageBox.Show("Запись успешно удалена!");


            }


            catch
            {
                System.Windows.MessageBox.Show("Невозможно удалить запись!");
            }
        }

        private void grid_roles1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {

                    //Команда обновления
                    FbCommand sqlforin = new FbCommand("IUD_ROLES", preh.fb);
                    sqlforin.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlforin.Parameters.Add("@FLAG", FbDbType.Char).Value = "U";
                    sqlforin.Parameters.Add("@ID", FbDbType.Integer).Value = grid_roles.GetFocusedRowCellValue("ID").ToString();
                    sqlforin.Parameters.Add("@NAME", FbDbType.VarChar).Value = grid_roles.GetFocusedRowCellValue("Наименование").ToString();
                    sqlforin.ExecuteNonQuery();
                    //flag = false;


                    grid_roles.ItemsSource = dt_grid_roles();
                    prop_grid_roles(grid_roles);
                    //flag = true;
                    System.Windows.MessageBox.Show("Запись успешно обновлена!");
                }
                catch { System.Windows.MessageBox.Show("Невозможно обновить запись!"); }
            }
        }

        private void but_change_role1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            edit_roles edr = new edit_roles();
            edr.con = this;
            edr.ShowDialog();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            pas_change pch = new pas_change();
            pch.conec = this;
            pch.ShowDialog();
        }

        private void btExitApp_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BarSubItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            AutWindow atw = new AutWindow();
            this.Close();
            atw.Show();
        }

        private void but_help_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            instruction ins = new instruction();
           
            ins.Show();
            ins.navBarAdm.IsExpanded = true;
            ins.barAdm2.IsSelected = true;
        }
    }
}

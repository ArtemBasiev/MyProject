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
using DevExpress.XtraReports.UI;

namespace GreatestApplicatioInMyLife
{

    public partial class Report_Window : Window
    {

        public MainWindow con;
        public frame_doc fordoc;

        public report_frame_ost rfcon;
        public Report_Window()
        {
            InitializeComponent();
        }


      

        private void Window_Activated_1(object sender, EventArgs e)
        {
            try
            {
                switch (Tag.ToString())
                {
                    case "one_arr":
                        Report_Arrive report = new Report_Arrive();
                        report.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report;
                        report.CreateDocument();
                        break;

                    case "one_arr_sh":
                        Report_Arrive reportsh1 = new Report_Arrive();
                        reportsh1.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = reportsh1;
                        reportsh1.CreateDocument();
                        break;

                    case "one_leave":
                        report_leave report1 = new report_leave();
                        report1.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report1;
                        report1.CreateDocument();
                        break;

                    case "one_leave_sh":
                        report_leave reportsh2 = new report_leave();
                        reportsh2.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = reportsh2;
                        reportsh2.CreateDocument();
                        break;

                    case "one_move":
                        report_move report2 = new report_move();
                        report2.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report2;
                        report2.CreateDocument();
                        break;

                    case "one_move_sh":
                        report_move reportsh3 = new report_move();
                        reportsh3.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = reportsh3;
                        reportsh3.CreateDocument();
                        break;

                    case "ost":
                        report_ost report3 = new report_ost();
                        report3.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report3;
                        report3.CreateDocument();
                        break;

                    case "allarr":
                        report_arr_all report4 = new report_arr_all();
                        report4.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report4;
                        report4.CreateDocument();
                        break;

                    case "allleave":
                        report_leave_all report5 = new report_leave_all();
                        report5.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report5;
                        report5.CreateDocument();
                        break;

                    case "allmove":
                        report_move_all report6 = new report_move_all();
                        report6.DataSourceDemanded += report_DataSourceDemanded;
                        DocView.DocumentSource = report6;
                        report6.CreateDocument();
                        break;

                }
            }
            catch { }
           
        }

        void report_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                switch (Tag.ToString())
                {
                    case "one_arr":
                        FbCommand command = new FbCommand("select * from SEL_REPORT_ARRIVE(" + con.gc_arrive_list.GetFocusedRowCellValue("ID") + ")", con.preh.fb);
                        FbDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dt.Columns[0].ColumnName = "num";
                        dt.Columns[1].ColumnName = "kom";
                        dt.Columns[2].ColumnName = "date";
                        dt.Columns[3].ColumnName = "war";
                        dt.Columns[4].ColumnName = "prov";
                        dt.Columns[5].ColumnName = "art";
                        dt.Columns[6].ColumnName = "nom";
                        dt.Columns[7].ColumnName = "char";
                        dt.Columns[8].ColumnName = "count";
                        dt.Columns[9].ColumnName = "mes";
                        dt.Columns[10].ColumnName = "price";
                        dt.Columns[11].ColumnName = "summ";
                        dt.Columns[12].ColumnName = "end";
                        dt.TableName = "arrive";
                        XtraReport rep = sender as XtraReport;

                        rep.DataSource = dt;
                        break;


                    case "one_arr_sh":
                        FbCommand commandsh1 = new FbCommand("select * from SEL_REPORT_ARRIVE(" + fordoc.gc_arrive_list.GetFocusedRowCellValue("ID") + ")", fordoc.conshow.presh.preh.fb);
                        FbDataReader readersh1 = commandsh1.ExecuteReader();

                        DataTable dtsh1 = new DataTable();
                        dtsh1.Load(readersh1);
                        dtsh1.Columns[0].ColumnName = "num";
                        dtsh1.Columns[1].ColumnName = "kom";
                        dtsh1.Columns[2].ColumnName = "date";
                        dtsh1.Columns[3].ColumnName = "war";
                        dtsh1.Columns[4].ColumnName = "prov";
                        dtsh1.Columns[5].ColumnName = "art";
                        dtsh1.Columns[6].ColumnName = "nom";
                        dtsh1.Columns[7].ColumnName = "char";
                        dtsh1.Columns[8].ColumnName = "count";
                        dtsh1.Columns[9].ColumnName = "mes";
                        dtsh1.Columns[10].ColumnName = "price";
                        dtsh1.Columns[11].ColumnName = "summ";
                        dtsh1.Columns[12].ColumnName = "end";
                        dtsh1.TableName = "arrive";
                        XtraReport repsh1 = sender as XtraReport;

                        repsh1.DataSource = dtsh1;
                        break;

                    case "one_leave":
                        FbCommand command1 = new FbCommand("select * from SEL_REPORT_LEAVE(" + con.gc_leave_list.GetFocusedRowCellValue("ID") + ")", con.preh.fb);
                        FbDataReader reader1 = command1.ExecuteReader();

                        DataTable dt1 = new DataTable();
                        dt1.Load(reader1);
                        dt1.Columns[0].ColumnName = "num";
                        dt1.Columns[1].ColumnName = "kom";
                        dt1.Columns[2].ColumnName = "date";
                        dt1.Columns[3].ColumnName = "war";
                        dt1.Columns[4].ColumnName = "obj";
                        dt1.Columns[5].ColumnName = "art";
                        dt1.Columns[6].ColumnName = "nom";
                        dt1.Columns[7].ColumnName = "char";
                        dt1.Columns[8].ColumnName = "count";
                        dt1.Columns[9].ColumnName = "mes";
                        dt1.Columns[10].ColumnName = "price";
                        dt1.Columns[11].ColumnName = "summ";
                        dt1.Columns[12].ColumnName = "end";
                        dt1.TableName = "leave";
                        XtraReport rep1 = sender as XtraReport;

                        rep1.DataSource = dt1;
                        break;

                    case "one_leave_sh":
                        FbCommand command1sh = new FbCommand("select * from SEL_REPORT_LEAVE(" + fordoc.gc_leave_list.GetFocusedRowCellValue("ID") + ")", fordoc.conshow.presh.preh.fb);
                        FbDataReader reader1sh = command1sh.ExecuteReader();

                        DataTable dt1sh = new DataTable();
                        dt1sh.Load(reader1sh);
                        dt1sh.Columns[0].ColumnName = "num";
                        dt1sh.Columns[1].ColumnName = "kom";
                        dt1sh.Columns[2].ColumnName = "date";
                        dt1sh.Columns[3].ColumnName = "war";
                        dt1sh.Columns[4].ColumnName = "obj";
                        dt1sh.Columns[5].ColumnName = "art";
                        dt1sh.Columns[6].ColumnName = "nom";
                        dt1sh.Columns[7].ColumnName = "char";
                        dt1sh.Columns[8].ColumnName = "count";
                        dt1sh.Columns[9].ColumnName = "mes";
                        dt1sh.Columns[10].ColumnName = "price";
                        dt1sh.Columns[11].ColumnName = "summ";
                        dt1sh.Columns[12].ColumnName = "end";
                        dt1sh.TableName = "leave";
                        XtraReport rep1sh = sender as XtraReport;

                        rep1sh.DataSource = dt1sh;
                        break;


                    case "one_move":
                        FbCommand command2 = new FbCommand("select * from SEL_REPORT_MOVE(" + con.gc_move_list.GetFocusedRowCellValue("ID") + ")", con.preh.fb);
                        FbDataReader reader2 = command2.ExecuteReader();

                        DataTable dt2 = new DataTable();
                        dt2.Load(reader2);
                        dt2.Columns[0].ColumnName = "num";
                        dt2.Columns[1].ColumnName = "kom";
                        dt2.Columns[2].ColumnName = "date";
                        dt2.Columns[3].ColumnName = "war";
                        dt2.Columns[4].ColumnName = "war_rec";
                        dt2.Columns[5].ColumnName = "art";
                        dt2.Columns[6].ColumnName = "nom";
                        dt2.Columns[7].ColumnName = "char";
                        dt2.Columns[8].ColumnName = "count";
                        dt2.Columns[9].ColumnName = "mes";
                        dt2.Columns[10].ColumnName = "price";
                        dt2.Columns[11].ColumnName = "summ";
                        dt2.Columns[12].ColumnName = "end";
                        dt2.TableName = "move";
                        XtraReport rep2 = sender as XtraReport;

                        rep2.DataSource = dt2;
                        break;


                    case "one_move_sh":
                        FbCommand command2sh = new FbCommand("select * from SEL_REPORT_MOVE(" + fordoc.gc_move_list.GetFocusedRowCellValue("ID") + ")", fordoc.conshow.presh.preh.fb);
                        FbDataReader reader2sh = command2sh.ExecuteReader();

                        DataTable dt2sh = new DataTable();
                        dt2sh.Load(reader2sh);
                        dt2sh.Columns[0].ColumnName = "num";
                        dt2sh.Columns[1].ColumnName = "kom";
                        dt2sh.Columns[2].ColumnName = "date";
                        dt2sh.Columns[3].ColumnName = "war";
                        dt2sh.Columns[4].ColumnName = "war_rec";
                        dt2sh.Columns[5].ColumnName = "art";
                        dt2sh.Columns[6].ColumnName = "nom";
                        dt2sh.Columns[7].ColumnName = "char";
                        dt2sh.Columns[8].ColumnName = "count";
                        dt2sh.Columns[9].ColumnName = "mes";
                        dt2sh.Columns[10].ColumnName = "price";
                        dt2sh.Columns[11].ColumnName = "summ";
                        dt2sh.Columns[12].ColumnName = "end";
                        dt2sh.TableName = "move";
                        XtraReport rep2sh = sender as XtraReport;

                        rep2sh.DataSource = dt2sh;
                        break;

                    case "ost":
                        FbCommand command3 = new FbCommand("select * from SEL_REPORT_OST('" + rfcon.flag_date + "', '"
                                      + rfcon.t_date + "', '" + rfcon.flag_nom + "', '" + rfcon.nom + "', " + rfcon.confr.preh.id_main_war + ")", rfcon.confr.preh.fb);
                        FbDataReader reader3 = command3.ExecuteReader();

                        DataTable dt3 = new DataTable();
                        dt3.Load(reader3);
                        dt3.Columns[0].ColumnName = "group";
                        dt3.Columns[1].ColumnName = "war";
                        dt3.Columns[2].ColumnName = "f_date";
                        dt3.Columns[3].ColumnName = "t_date";
                        dt3.Columns[4].ColumnName = "art";
                        dt3.Columns[5].ColumnName = "nom";
                        dt3.Columns[6].ColumnName = "char";
                        dt3.Columns[7].ColumnName = "count";
                        dt3.Columns[8].ColumnName = "mes";
                        dt3.Columns[9].ColumnName = "summ";
                        dt3.Columns[10].ColumnName = "end";

                        dt3.TableName = "ost";
                        XtraReport rep3 = sender as XtraReport;

                        rep3.DataSource = dt3;
                        break;

                    case "allarr":
                        FbCommand command4 = new FbCommand("select * from SEL_REPORT_ARRIVE_ALL('" + rfcon.flag_date + "', '"
                                      + rfcon.t_date + "', '" + rfcon.flag_nom + "', '" + rfcon.nom + "', " + rfcon.confr.preh.id_main_war + ")", rfcon.confr.preh.fb);
                        FbDataReader reader4 = command4.ExecuteReader();

                        DataTable dt4 = new DataTable();
                        dt4.Load(reader4);
                        dt4.Columns[0].ColumnName = "group";
                        dt4.Columns[1].ColumnName = "war";
                        dt4.Columns[2].ColumnName = "f_date";
                        dt4.Columns[3].ColumnName = "t_date";
                        dt4.Columns[4].ColumnName = "art";
                        dt4.Columns[5].ColumnName = "nom";
                        dt4.Columns[6].ColumnName = "char";
                        dt4.Columns[7].ColumnName = "count";
                        dt4.Columns[8].ColumnName = "mes";
                        dt4.Columns[9].ColumnName = "summ";
                        dt4.Columns[10].ColumnName = "end";

                        dt4.TableName = "arrall";
                        XtraReport rep4 = sender as XtraReport;

                        rep4.DataSource = dt4;
                        break;

                    case "allleave":
                        FbCommand command5 = new FbCommand("select * from SEL_REPORT_LEAVE_ALL('" + rfcon.flag_date + "', '"
                                      + rfcon.t_date + "', '" + rfcon.flag_nom + "', '" + rfcon.nom + "', " + rfcon.confr.preh.id_main_war + ")", rfcon.confr.preh.fb);
                        FbDataReader reader5 = command5.ExecuteReader();

                        DataTable dt5 = new DataTable();
                        dt5.Load(reader5);
                        dt5.Columns[0].ColumnName = "group";
                        dt5.Columns[1].ColumnName = "war";
                        dt5.Columns[2].ColumnName = "f_date";
                        dt5.Columns[3].ColumnName = "t_date";
                        dt5.Columns[4].ColumnName = "art";
                        dt5.Columns[5].ColumnName = "nom";
                        dt5.Columns[6].ColumnName = "char";
                        dt5.Columns[7].ColumnName = "count";
                        dt5.Columns[8].ColumnName = "mes";
                        dt5.Columns[9].ColumnName = "summ";
                        dt5.Columns[10].ColumnName = "end";

                        dt5.TableName = "leaveall";
                        XtraReport rep5 = sender as XtraReport;

                        rep5.DataSource = dt5;
                        break;

                    case "allmove":
                        FbCommand command6 = new FbCommand("select * from SEL_REPORT_MOVE_ALL('" + rfcon.flag_date + "', '"
                                      + rfcon.t_date + "', '" + rfcon.flag_nom + "', '" + rfcon.nom + "', " + rfcon.confr.preh.id_main_war + ")", rfcon.confr.preh.fb);
                        FbDataReader reader6 = command6.ExecuteReader();

                        DataTable dt6 = new DataTable();
                        dt6.Load(reader6);
                        dt6.Columns[0].ColumnName = "group";
                        dt6.Columns[1].ColumnName = "war";
                        dt6.Columns[2].ColumnName = "f_date";
                        dt6.Columns[3].ColumnName = "t_date";
                        dt6.Columns[4].ColumnName = "art";
                        dt6.Columns[5].ColumnName = "nom";
                        dt6.Columns[6].ColumnName = "char";
                        dt6.Columns[7].ColumnName = "count";
                        dt6.Columns[8].ColumnName = "mes";
                        dt6.Columns[9].ColumnName = "summ";
                        dt6.Columns[10].ColumnName = "end";

                        dt6.TableName = "allmove";
                        XtraReport rep6 = sender as XtraReport;

                        rep6.DataSource = dt6;
                        break;
                }

            }
            catch { }
            //if (this.Tag.ToString()=="one_arr")
            //{
            //    FbCommand command = new FbCommand("select * from SEL_REPORT_ARRIVE(" + con.gc_arrive_list.GetFocusedRowCellValue("ID") + ")", con.preh.fb);
            //    FbDataReader reader = command.ExecuteReader();

            //    DataTable dt = new DataTable();
            //    dt.Load(reader);
            //    dt.Columns[0].ColumnName = "num";
            //    dt.Columns[1].ColumnName = "kom";
            //    dt.Columns[2].ColumnName = "date";
            //    dt.Columns[3].ColumnName = "war";
            //    dt.Columns[4].ColumnName = "prov";
            //    dt.Columns[5].ColumnName = "art";
            //    dt.Columns[6].ColumnName = "nom";
            //    dt.Columns[7].ColumnName = "char";
            //    dt.Columns[8].ColumnName = "count";
            //    dt.Columns[9].ColumnName = "mes";
            //    dt.Columns[10].ColumnName = "price";
            //    dt.Columns[11].ColumnName = "summ";
            //    dt.Columns[12].ColumnName = "end";
            //    dt.TableName = "arrive";
            //    XtraReport rep = sender as XtraReport;

            //    rep.DataSource = dt;
            //}
            //else 
            //    if(this.Tag.ToString()=="one_leave")
            //    {
            //        FbCommand command = new FbCommand("select * from SEL_REPORT_LEAVE(" + con.gc_leave_list.GetFocusedRowCellValue("ID") + ")", con.preh.fb);
            //        FbDataReader reader = command.ExecuteReader();

            //        DataTable dt = new DataTable();
            //        dt.Load(reader);
            //        dt.Columns[0].ColumnName = "num";
            //        dt.Columns[1].ColumnName = "kom";
            //        dt.Columns[2].ColumnName = "date";
            //        dt.Columns[3].ColumnName = "war";
            //        dt.Columns[4].ColumnName = "obj";
            //        dt.Columns[5].ColumnName = "art";
            //        dt.Columns[6].ColumnName = "nom";
            //        dt.Columns[7].ColumnName = "char";
            //        dt.Columns[8].ColumnName = "count";
            //        dt.Columns[9].ColumnName = "mes";
            //        dt.Columns[10].ColumnName = "price";
            //        dt.Columns[11].ColumnName = "summ";
            //        dt.Columns[12].ColumnName = "end";
            //        dt.TableName = "leave";
            //        XtraReport rep = sender as XtraReport;

            //        rep.DataSource = dt;
                    
            //    }
            //    else 
            //        if(this.Tag.ToString()=="one_move")
            //        {
            //            FbCommand command = new FbCommand("select * from SEL_REPORT_MOVE(" + con.gc_move_list.GetFocusedRowCellValue("ID") + ")", con.preh.fb);
            //            FbDataReader reader = command.ExecuteReader();

            //            DataTable dt = new DataTable();
            //            dt.Load(reader);
            //            dt.Columns[0].ColumnName = "num";
            //            dt.Columns[1].ColumnName = "kom";
            //            dt.Columns[2].ColumnName = "date";
            //            dt.Columns[3].ColumnName = "war";
            //            dt.Columns[4].ColumnName = "war_rec";
            //            dt.Columns[5].ColumnName = "art";
            //            dt.Columns[6].ColumnName = "nom";
            //            dt.Columns[7].ColumnName = "char";
            //            dt.Columns[8].ColumnName = "count";
            //            dt.Columns[9].ColumnName = "mes";
            //            dt.Columns[10].ColumnName = "price";
            //            dt.Columns[11].ColumnName = "summ";
            //            dt.Columns[12].ColumnName = "end";
            //            dt.TableName = "move";
            //            XtraReport rep = sender as XtraReport;

            //            rep.DataSource = dt;
            //        }
            //        else
            //            if (this.Tag.ToString() == "ost")
            //            {
            //                try
            //                {
            //                    FbCommand command = new FbCommand("select * from SEL_REPORT_OST('" + rfcon.flag_date + "', '"
            //                        + rfcon.t_date + "', '" + rfcon.flag_nom + "', '" + rfcon.nom + "', " + rfcon.confr.preh.id_main_war + ")", rfcon.confr.preh.fb);
            //                    FbDataReader reader = command.ExecuteReader();

            //                    DataTable dt = new DataTable();
            //                    dt.Load(reader);
            //                    dt.Columns[0].ColumnName = "group";
            //                    dt.Columns[1].ColumnName = "war";
            //                    dt.Columns[2].ColumnName = "f_date";
            //                    dt.Columns[3].ColumnName = "t_date";
            //                    dt.Columns[4].ColumnName = "art";
            //                    dt.Columns[5].ColumnName = "nom";
            //                    dt.Columns[6].ColumnName = "char";
            //                    dt.Columns[7].ColumnName = "count";
            //                    dt.Columns[8].ColumnName = "mes";
            //                    dt.Columns[9].ColumnName = "summ";

            //                    dt.TableName = "ost";
            //                    XtraReport rep = sender as XtraReport;

            //                    rep.DataSource = dt;
            //                }
            //                catch { }
            //            }
           
         
            
        }


    }
}

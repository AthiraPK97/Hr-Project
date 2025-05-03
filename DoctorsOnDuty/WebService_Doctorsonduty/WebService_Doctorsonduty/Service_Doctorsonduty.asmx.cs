using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Data.OracleClient;

namespace WebService_Doctorsonduty
{
    /// <summary>
    /// Summary description for Service_Doctorsonduty
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service_Doctorsonduty : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        DataSet ObjDataSet = new DataSet();
        DataTable ObjDatatb = new DataTable();

        [WebMethod]
        public DataSet Get_login(string username, string password)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from LOGIN_USERS where username = '" + username + "' and password = '" + password + "'");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctors(string dept_id, string clinic_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select staff_id, name from HOSPITAL.STAFF_MASTER where dept_id = '" + dept_id + "' and staff_id not in (select " +
                "dr_id from doctorsonduty_drreg where branch_id = '" + clinic_id + "' and dept_id = '" + dept_id + "') ");
            return DS;
        }


        //[WebMethod]
        //public DataSet Get_Doctorsforedit(string dept_id, string clinic_id)
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select distinct dr_id,dr_name from doctorsonduty_drreg where branch_id = '" + clinic_id + "' and dept_id = '" + dept_id + "' ");
        //    return DS;
        //}

        [WebMethod]
        public DataSet Get_Doctorsforshiftchange(int branch_id, int dept_id, string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select d.dr_name, d.dr_id, d.duty_id, d.to_time || '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number" +
                "(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = " +
                "d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id " +
                "= d.dr_id where d.weekly_monthly = 'Monthly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.dept_id = " + dept_id + " " +
                "and d.branch_id = " + branch_id + " " +
                "union select d.dr_name, d.dr_id, d.duty_id, d.to_time || '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number" +
                "(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = " +
                "d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id " +
                "= d.dr_id where d.weekly_monthly = 'Weekly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', " +
                "'DD-MM-YYYY')) and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " " +
                "union select d.dr_name, d.dr_id, s.shiftchange_id, s.updated_to_time || '-' || s.updated_from_time time_, case when d.duty_id > 0 then " +
                "(select nvl(max(to_number(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', " +
                "'dd-MM-yyyy') and c.doctor_id = d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d " +
                "join doctorsonduty_shiftchange s on d.duty_id = s.duty_id join CRM_DRREG cd on cd.doctor_id = d.dr_id where to_date(s.updated_date, " +
                "'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + "");

            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorsforedit(string dept_id, string clinic_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct d.dr_id, d.dr_name from doctorsonduty_drreg d join crm_drreg c on d.dr_id = c.doctor_id where " +
                "d.branch_id = '" + clinic_id + "' and d.dept_id = '" + dept_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorsdtlforedit(string dr_id, string dept_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_drreg where dr_id = '" + dr_id + "' and dept_id = '" + dept_id + "' and branch_id " +
                "= '" + branch_id + "' ");
            return DS;
        }


        [WebMethod]
        public DataSet Get_Branch()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from HOSPITAL.CLINIC_MASTER where firm_id = 16 and branch_type = 1 and status = 1 and clinic_id not in " +
                "(8, 25, 40, 2)");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Branchforaddemployee()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select branch_id, name from HOSPITAL.CLINIC_MASTER where firm_id = 16 and branch_type = 1 and status = 1 and " +
                "clinic_id not in (8, 25, 40, 2) " +
                "union select branch_id, branch_name name from hospital.pharmacy_master where branch_id in (2435, 3348)");
            return DS;
        }


        [WebMethod]
        public DataSet Get_department()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from HOSPITAL.DEPARTMENT where dept_id not in (96, 100)");
            return DS;
        }

        [WebMethod]
        public DataSet Get_duplicationfordrreg(string dr_id, string dept_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_drreg where dr_id = '" + dr_id + "' and dept_id = '" + dept_id + "' and branch_id = " +
                "'" + branch_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet delete_duplicationfordrreg(string dr_id, string dept_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorsonduty_drreg where dr_id = '" + dr_id + "' and dept_id = '" + dept_id + "' and branch_id = " +
                "'" + branch_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet delete_select()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorsonduty_drreg where week_name = '--Select--' or weekno_name = '--Select--' ");
            return DS;
        }

        [WebMethod]
        public int Doctor_registration(string dr_id, string weekormonth, string dayofduty, string week_no, string branch_id, string dept_id, string area, string dr_name, string dept_name, string branch_name, string entered_by, string week, string weekno, string from_time, string to_time)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_drreg (duty_id, dr_id,weekly_monthly, day_of_duty, week_number, branch_id, dept_id, " +
                "dr_sittingarea, dr_name, dept_name, branch_name, entered_by, entered_on, week_name, weekno_name, from_time, to_time) values " +
                "(SEQ_DOCTORSONDUTY.nextval, '" + dr_id + "', '" + weekormonth + "', '" + dayofduty + "', '" + week_no + "', '" + branch_id + "', " +
                "'" + dept_id + "', '" + area + "', '" + dr_name + "', '" + dept_name + "', '" + branch_name + "', '" + entered_by + "', sysdate, " +
                "'" + week + "', '" + weekno + "', '" + from_time + "', '" + to_time + "')");
            return id;
        }


















        //[WebMethod]
        //public DataSet Get_Doctorsforshiftchange(string dept_id,string branch_id)
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select distinct dr_id,dr_name from doctorsonduty_drreg where dept_id='"+dept_id+"' and branch_id=" +
        //        "'"+branch_id+"' ");
        //    return DS;
        //}

        [WebMethod]
        public DataSet Get_departmentforshiftchange(string date, string branchid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct dept_name, dept_id from doctorsonduty_drreg where weekly_monthly = 'Monthly' and day_of_duty = " +
                "(select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date('" + date + "', " +
                "'DD-MM-YYYY'), 'W') from dual) " +
                "union select distinct dept_name, dept_id from doctorsonduty_drreg where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date" +
                "('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and branch_id = '" + branchid + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_monthlyorweekly(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct Weekly_monthly from doctorsonduty_drreg where dr_id='" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_allforshiftchangeweekly(string dept_id, string date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select duty_id, dr_id, weekly_monthly, day_of_duty, week_number, branch_id, dept_id, dr_sittingarea, dr_name, " +
                "dept_name, branch_name, entered_by, entered_on, week_name, weekno_name, payment_terms, to_time || ' - ' || from_time time_ from " +
                "doctorsonduty_drreg where dept_id = '" + dept_id + "' and day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from " +
                "dual) and dr_id = '" + dr_id + "' and branch_id = '" + branch_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_allforshiftchangemonthly(string dept_id, string date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select duty_id, dr_id, weekly_monthly, day_of_duty, week_number, branch_id, dept_id, dr_sittingarea, dr_name, " +
                "dept_name, branch_name, entered_by, entered_on, week_name, weekno_name, payment_terms, to_time || ' - ' || from_time time_ from " +
                "doctorsonduty_drreg where dept_id = '" + dept_id + "' and week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from " +
                "dual) and day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and dr_id = '" + dr_id + "' and branch_id " +
                "= '" + branch_id + "' ");
            return DS;
        }

        [WebMethod]
        public int Shift_change(string duty_id, string old_date, string new_date, string from_time, string to_time)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_shiftchange values (SEQ_DOCTORSONDUTYSHIFTCHANGE.nextval, '" + duty_id + "', " +
                "'" + old_date + "', '" + new_date + "', '" + from_time + "', '" + to_time + "')");
            return id;
        }

        [WebMethod]
        public DataSet Get_duplicateforupdateshift(string duty_id, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_shiftchange where actual_date = '" + date + "' and duty_id = '" + duty_id + "' ");
            return DS;
        }

        [WebMethod]
        public int Update_shiftchange(string date, string frmtime, string totime, string olddate, string duty_id)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update doctorsonduty_shiftchange set updated_date = '" + date + "', updated_from_time = '" + frmtime + "', " +
                "updated_to_time = '" + totime + "' where duty_id = '" + duty_id + "' and actual_date = '" + olddate + "' ");
            return id;
        }











        [WebMethod]
        public DataSet Get_Doctorsdetails(string branch_id, string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct dr_id, dr_name from doctorsonduty_drreg where branch_id = '" + branch_id + "' and dept_id = " +
                "'" + dept_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Branchdetails()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct branch_id, branch_name from doctorsonduty_drreg");
            return DS;
        }

        [WebMethod]
        public DataSet Get_departmentdetails(string branchid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct dept_id, dept_name from doctorsonduty_drreg where branch_id = '" + branchid + "'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_dr_id(string dutyid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select dr_id from doctorsonduty_drreg where duty_id = '" + dutyid + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_duplicateforupdateattendance(string date, string branch)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select x.* from (select d.duty_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.branch_name, a.attend_bool from " +
                "doctorsonduty_drattendance a join doctorsonduty_drreg d on a.duty_id = d.duty_id where a.date_ = '" + date + "' and d.branch_id = " +
                "'" + branch + "' " +
                "union select d.duty_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.branch_name, 1 attend_bool from doctorsonduty_drreg d join crm_drreg c on " +
                "d.dr_id = c.doctor_id where d.weekly_monthly = 'Monthly' and d.branch_id = '" + branch + "' and d.day_of_duty = (select to_char(to_date" +
                "('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and " +
                "d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', " +
                "'DD-MM-YYYY')) and d.duty_id not in (select duty_id from doctorsonduty_drattendance where date_ = '" + date + "') " +
                "union select d.duty_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.branch_name, 1 attend_bool from doctorsonduty_drreg d join crm_drreg c on " +
                "d.dr_id = c.doctor_id where d.weekly_monthly = 'Weekly' and d.branch_id = '" + branch + "' and d.day_of_duty = (select to_char(to_date" +
                "('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date" +
                "(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.duty_id not in (select duty_id from doctorsonduty_drattendance " +
                "where date_ = '" + date + "') " +
                "union select s.duty_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.branch_name, 1 attend_bool from doctorsonduty_drreg d join crm_drreg c on " +
                "d.dr_id = c.doctor_id join doctorsonduty_shiftchange s on d.duty_id = s.duty_id where to_date(s.updated_date, 'DD-MM-YYYY') = to_date" +
                "('" + date + "', 'DD-MM-YYYY') and d.branch_id = '" + branch + "' and d.duty_id not in (select duty_id from doctorsonduty_drattendance where " +
                "date_ = '" + date + "')) x order by x.dr_name");
            return DS;
        }

        //[WebMethod]
        //public DataSet delete_duplicateforupdateattendance(string date)
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("delete from doctorsonduty_drattendance where date_ = '" + date + "' ");
        //    return DS;
        //}

        [WebMethod]
        public DataSet delete_duplicateforupdateattendance(string date, string branch)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorsonduty_drattendance where date_ = '" + date + "' duty_id in (select distinct d.duty_id " +
                "from doctorsonduty_drreg d join doctorsonduty_drattendance a on a.duty_id = d.duty_id where a.date_ = '" + date + "' and d.branch_id = " +
                "'" + branch + "') ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_detailsforattendance(string date, string branch)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select x.* from (select d.duty_id, d.dr_id, d.weekly_monthly, d.day_of_duty, d.week_number, d.branch_id, d.dept_id, d.dr_sittingarea, " +
                "d.to_time || '-' || d.from_time time_, d.dr_name, d.dept_name, d.branch_name from doctorsonduty_drreg d join crm_drreg c on d.dr_id = " +
                "c.doctor_id where d.weekly_monthly = 'Monthly' and d.branch_id = '" + branch + "' and d.day_of_duty = (select to_char(to_date('" + date + "', " +
                "'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in " +
                "(select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) " +
                "union select d.duty_id, d.dr_id, d.weekly_monthly, d.day_of_duty, d.week_number, d.branch_id, d.dept_id, d.dr_sittingarea, d.to_time || '-' " +
                "|| d.from_time time_, d.dr_name, d.dept_name, d.branch_name from doctorsonduty_drreg d join crm_drreg c on d.dr_id = c.doctor_id where " +
                "d.weekly_monthly = 'Weekly' and d.branch_id = '" + branch + "' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), " +
                "'D') from dual) and d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date" +
                "('" + date + "', 'DD-MM-YYYY')) " +
                "union select s.duty_id, d.dr_id, d.weekly_monthly, d.day_of_duty, d.week_number, d.branch_id, d.dept_id, d.dr_sittingarea, s.updated_to_time " +
                "|| '-' || s.updated_from_time time_, d.dr_name, d.dept_name, d.branch_name from doctorsonduty_drreg d join crm_drreg c on d.dr_id = " +
                "c.doctor_id join doctorsonduty_shiftchange s on d.duty_id = s.duty_id where d.branch_id = '" + branch + "' and to_date(s.updated_date, " +
                "'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) x order by x.dr_name ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Insert_drattendance(string date,string duty_id, string name,string attendance,int attend_bool)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_drattendance values ('" + date + "', '" + duty_id + "', '" + name + "', " +
                "'" + attendance + "', " + attend_bool + ", '0', '0')");
            return id;
        }

        [WebMethod]
        public DataSet Get_count_sum(string dr_id, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select count(p.bill_id) as count, sum(p.rcvd_amount) as sum from hospital.clinic_payment_master p join " +
                "hospital.staff_master s on s.staff_id = p.dr_id where to_date(p.bill_date, 'dd-mm-yyyy') = to_date('" + date + "', 'dd-mm-yyyy') and p.dr_id " +
                "= '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public int Update_count_sum(string sum,string count,string duty_id,string date)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update doctorsonduty_drattendance set num_of_bills = '" + count + "', ttl_collection = '" + sum + "' where " +
                "duty_id = '" + duty_id + "' and date_ = '" + date + "' ");
            return id;
        }












        [WebMethod]
        public DataSet report_details(string fromdate,string todate)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_drattendance a join doctorsonduty_drreg d on a.duty_id = d.duty_id where to_date" +
                "(a.date_, 'DD-MM-YYYY') between to_date('" + fromdate+"', 'DD-MM-YYYY') and to_date('" + todate + "', 'DD-MM-YYYY') order by to_date" +
                "(date_, 'DD-MM-YYYY')");
            return DS;
        }

        [WebMethod]
        public DataSet shiftreport_details(string fromdate, string todate)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = s.duty_id where to_date" +
                "(s.actual_date, 'DD-MM-YYYY') between to_date('" + fromdate + "', 'DD-MM-YYYY') and to_date('" + todate + "', 'DD-MM-YYYY') order by " +
                "s.actual_date");
            return DS;
        }

        [WebMethod]
        public DataSet report_doctors(string branch_id,string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.dr_id, d.weekly_monthly, d.day_of_duty, d.week_number, d.branch_id, d.dept_id, d.dr_sittingarea, " +
                "d.dr_name, d.dept_name, d.branch_name, d.entered_by, d.entered_on, d.week_name, d.weekno_name, d.payment_terms, d.from_time, d.to_time from " +
                "doctorsonduty_drreg d join crm_drreg c on d.dr_id = c.doctor_id where d.branch_id = '" + branch_id + "' and d.dept_id = '" + dept_id + "' " +
                "order by dr_id");
            return DS;
        }





        [WebMethod]
        public DataSet Get_ABDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.A%' or d.doctor_name like 'DR.B%' or d.doctor_name like 'DR. A%' or d.doctor_name like 'DR. B%' or d.doctor_name like 'DR A%' or " +
                "d.doctor_name like 'DR B%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_CDDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.C%' or d.doctor_name like 'DR.D%' or d.doctor_name like 'DR. C%' or d.doctor_name like 'DR. D%' or d.doctor_name like 'DR C%' or " +
                "d.doctor_name like 'DR D%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_EFDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.E%' or d.doctor_name like 'DR.F%' or d.doctor_name like 'DR. E%' or d.doctor_name like 'DR. F%' or d.doctor_name like 'DR E%' or " +
                "d.doctor_name like 'DR F%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_GHDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.G%' or d.doctor_name like 'DR.H%' or d.doctor_name like 'DR. G%' or d.doctor_name like 'DR. H%' or d.doctor_name like 'DR G%' or " +
                "d.doctor_name like 'DR H%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_IJDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.I%' or d.doctor_name like 'DR.J%' or d.doctor_name like 'DR. I%' or d.doctor_name like 'DR. J%' or d.doctor_name like 'DR I%' or " +
                "d.doctor_name like 'DR J%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_KLDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.K%' or d.doctor_name like 'DR.L%' or d.doctor_name like 'DR. K%' or d.doctor_name like 'DR. L%' or d.doctor_name like 'DR K%' or " +
                "d.doctor_name like 'DR L%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_MNDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.M%' or d.doctor_name like 'DR.N%' or d.doctor_name like 'DR. M%' or d.doctor_name like 'DR. N%' or d.doctor_name like 'DR M%' or " +
                "d.doctor_name like 'DR N%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_OPDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.O%' or d.doctor_name like 'DR.P%' or d.doctor_name like 'DR. O%' or d.doctor_name like 'DR. P%' or d.doctor_name like 'DR O%' or " +
                "d.doctor_name like 'DR P%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_QRDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.Q%' or d.doctor_name like 'DR.R%' or d.doctor_name like 'DR. Q%' or d.doctor_name like 'DR. R%' or d.doctor_name like 'DR Q%' or " +
                "d.doctor_name like 'DR R%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_STDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.S%' or d.doctor_name like 'DR.T%' or d.doctor_name like 'DR. S%' or d.doctor_name like 'DR. T%' or d.doctor_name like 'DR S%' or " +
                "d.doctor_name like 'DR T%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_UVDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.U%' or d.doctor_name like 'DR.V%' or d.doctor_name like 'DR. U%' or d.doctor_name like 'DR. V%' or d.doctor_name like 'DR U%' or " +
                "d.doctor_name like 'DR V%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_WXDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.W%' or d.doctor_name like 'DR.X%' or d.doctor_name like 'DR. W%' or d.doctor_name like 'DR. X%' or d.doctor_name like 'DR W%' or " +
                "d.doctor_name like 'DR X%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_YZDoctor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where d.subdep_id is null and (d.doctor_name like " +
                "'DR.Y%' or d.doctor_name like 'DR.Z%' or d.doctor_name like 'DR. Y%' or d.doctor_name like 'DR. Z%' or d.doctor_name like 'DR Y%' or " +
                "d.doctor_name like 'DR Z%') order by d.doctor_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorsforincentive(string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_id, d.doctor_name, p.lab_incentive, p.mammo_scan_incentive, p.ct_incentive from " +
                "hospital.doctors_master d left join doctorincentive_percent p on d.doctor_id = p.dr_id where subdep_id = '" + dept_id + "' order by " +
                "d.doctor_name ");
            return DS;
        }

        [WebMethod]
        public int Reg_drincentivepercent(string dept_id, string dr_id, decimal lab,int mammoscan,decimal ct)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorincentive_percent values ('" + dept_id + "', '" + dr_id + "', " + lab + ", " +
                "" + mammoscan + ", " + ct + ")");
            return id;
        }

        [WebMethod]
        public DataSet Get_duplicationfordrincentivepercent(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorincentive_percent where dr_id = '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_departmentforincetiveedit()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct i.dept_id, d.dept_name from doctorincentive_percent i join HOSPITAL.DEPARTMENT d on " +
                "d.dept_id = i.dept_id");
            return DS;
        }

        [WebMethod]
        public DataSet Get_drforincetiveedit(string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select i.dr_id, m.doctor_name from doctorincentive_percent i join HOSPITAL.Doctors_Master m on m.doctor_id " +
                "= i.dr_id where i.dept_id = '" + dept_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_percentageforincetiveedit(string dept_id, string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorincentive_percent where dept_id = '" + dept_id + "' and dr_id = '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public int Update_incentivepercent(string dept_id, string dr_id, decimal lab,int mammoscan,decimal ct)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update doctorincentive_percent set lab_incentive = " + lab + ", mammo_scan_incentive = " + mammoscan + ", " +
                "ct_incentive = " + ct + " where dept_id = '" + dept_id + "' and dr_id = '" + dr_id + "' ");
            return id;
        }

        


        [WebMethod]
        public DataSet Get_incentivereport(string fromdate,string todate)
        {
            DataSet DS = new DataSet();
            //DataSet DS1 = new DataSet();
            //DataTable dt = new DataTable();
            //string dr_id;
            //int scanning=0;
            //int lab = 0;
            //dt = ObjOrclHelper.ExecuteDataSet("select * from doctorincentive_percent").Tables[0];
            //for(int i=0;i<dt.Rows.Count;i++)
            //{
            //    dr_id= dt.Rows[i]["dr_id"].ToString();
            //    scanning= Convert.ToInt32(dt.Rows[i]["mammo_scan_incentive"]);
            //    lab= Convert.ToInt32(dt.Rows[i]["lab_incentive"]);
            //    DS = ObjOrclHelper.ExecuteDataSet("select count(b.patient_id) patient_count,sum(b.rcvd_amt) collection,b.doct_id,m.doctor_name,count(b.patient_id)*"+scanning+" incentive from HOSPITAL.DGN_BILL_MASTER b join hospital.doctors_master m on b.doct_id=m.doctor_id join hospital.dgn_bill_dtl d on d.bill_id=b.bill_id join hospital.dgn_test_master t on t.test_id=d.test_id join hospital.dgn_department_master dm on dm.dep_id=t.dep_id where BRANCH_ID=1256 and b.doct_id='"+dr_id+"' and (to_date(b.tra_dt,'DD-MM-YYYY') BETWEEN to_date('"+fromdate+"','DD-MM-YYYY') AND to_date('"+todate+ "','DD-MM-YYYY')) and m.doctor_id!=0 AND (DM.DEP_NAME='MAMMOGRAM' or DM.DEP_NAME='SCANNING') and upper(t.test_name) not like 'CT%' group by b.doct_id, m.doctor_name");
            //    DS1.Merge(DS);
            //}
            //return DS1;
            DS = ObjOrclHelper.ExecuteDataSet("select count(b.bill_id) patient_count, sum(D.TEST_CHARGE) collection, b.doct_id, m.doctor_name, " +
                "p.mammo_scan_incentive, count(b.patient_id) * p.mammo_scan_incentive incentive from HOSPITAL.DGN_BILL_MASTER b join hospital.clinic_master c " +
                "on c.branch_id = b.branch_id join doctorincentive_percent p on p.dr_id = b.doct_id join hospital.doctors_master m on b.doct_id = m.doctor_id " +
                "join hospital.dgn_bill_dtl d on d.bill_id = b.bill_id join hospital.dgn_test_master t on t.test_id = d.test_id join " +
                "hospital.dgn_department_master dm on dm.dep_id = t.dep_id where (to_date(b.tra_dt, 'DD-MM-YYYY') BETWEEN to_date('" + fromdate+"', " +
                "'DD-MM-YYYY') AND to_date('" + todate + "', 'DD-MM-YYYY')) and m.doctor_id != 0 AND (DM.DEP_NAME = 'MAMMOGRAM' or DM.DEP_NAME = 'SCANNING') " +
                "and upper(t.test_name) not like 'CT%' and c.clinic_id not in (11, 12, 13, 14, 6, 8, 9, 10, 22, 26, 17, 19, 29, 31, 35, 36, 25, 32, 33, 34) " +
                "group by b.doct_id, m.doctor_name, p.mammo_scan_incentive");
            return DS;
        }

        [WebMethod]
        public DataSet Get_labincentivereport1(string fromdate, string todate)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select count(b.bill_id) patient_count, sum(D.TEST_CHARGE) collection, b.doct_id, m.doctor_name, " +
                "p.lab_incentive, (sum(D.TEST_CHARGE) * p.lab_incentive) / 100 incentive from HOSPITAL.DGN_BILL_MASTER b join hospital.clinic_master c on " +
                "c.branch_id = b.branch_id join doctorincentive_percent p on p.dr_id = b.doct_id join hospital.doctors_master m on b.doct_id = m.doctor_id " +
                "join hospital.dgn_bill_dtl d on d.bill_id = b.bill_id join hospital.dgn_test_master t on t.test_id = d.test_id join " +
                "hospital.dgn_department_master dm on dm.dep_id = t.dep_id where (to_date(b.tra_dt, 'DD-MM-YYYY') BETWEEN to_date('" + fromdate + "', " +
                "'DD-MM-YYYY') AND to_date('" + todate + "', 'DD-MM-YYYY')) and m.doctor_id != 0 and DM.DEP_ID in (1, 2, 23, 16, 0, 3, 4, 5, 14, 6, 21, 18, 7, " +
                "11, 9) and upper(t.test_name) not like 'CT%' and c.clinic_id not in (11, 12, 13, 14, 6, 8, 9, 10, 22, 26, 17, 19, 29, 31, 35, 36, 25, 32, 33, " +
                "34) group by b.doct_id, m.doctor_name, p.lab_incentive");
            return DS;
        }


        [WebMethod]
        public DataSet Get_labincentivereport(string fromdate, string todate)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            string dr_id;
            int ttlamt = 0;
            int billamt = 0;
            dt = ObjOrclHelper.ExecuteDataSet("select * from doctorincentive_percent").Tables[0];
            ObjOrclHelper.ExecuteDataSet(" delete from REFINCENTIVE_COLLECTION ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr_id = dt.Rows[i]["dr_id"].ToString();
                dt1 = ObjOrclHelper.ExecuteDataSet("select distinct(b.bill_id), b.patient_id, b. patient_id, b.bill_amt, b.doct_id, m.doctor_name from " +
                    "HOSPITAL.DGN_BILL_MASTER b join hospital.clinic_master c on c.branch_id = b.branch_id join hospital.doctors_master m on b.doct_id = " +
                    "m.doctor_id join hospital.dgn_bill_dtl d on d.bill_id = b.bill_id join hospital.dgn_test_master t on t.test_id = d.test_id join " +
                    "hospital.dgn_department_master dm on dm.dep_id = t.dep_id where (to_date(b.tra_dt, 'DD-MM-YYYY') BETWEEN to_date('" + fromdate + "', " +
                    "'DD-MM-YYYY') AND to_date('" + todate + "', 'DD-MM-YYYY')) and m.doctor_id != 0 AND dm.dep_id in (1, 2, 23, 16, 0, 3, 4, 5, 14, 6, 21, 18, 7, " +
                    "11, 9) and upper(t.test_name) not like 'CT%' and b.doct_id = '" + dr_id + "' and c.clinic_id not in (11, 12, 13, 14, 6, 8, 9, 10, 22, 26, 17, " +
                    "19, 29, 31, 35, 36, 25, 32, 33, 34) ").Tables[0];
                for (int j=0;j<dt1.Rows.Count;j++)
                {
                    billamt = Convert.ToInt32( dt1.Rows[j]["bill_amt"]);
                    ttlamt = ttlamt + billamt;
                }
                ObjOrclHelper.ExecuteNonQuery("insert into REFINCENTIVE_COLLECTION values('" + dr_id + "', " + ttlamt + ")");
                ttlamt = 0;
                billamt = 0;
            }
            DS = ObjOrclHelper.ExecuteDataSet("select d.doctor_name, c.collection, p.lab_incentive, (c.collection * p.lab_incentive) / 100 incentive from " +
                "refincentive_collection c join doctorincentive_percent p on c.ref_drname = p.dr_id join hospital.doctors_master d on d.doctor_id = " +
                "p.dr_id where c.collection != 0");
            return DS;
        }

        

        [WebMethod]
        public DataSet Get_ctincentivereport(string fromdate, string todate)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select count(distinct(b.patient_id)) patient_count, sum(D.TEST_CHARGE) collection_amt, b.doct_id, " +
                "m.doctor_name, i.ct_incentive, (sum(D.TEST_CHARGE) * i.ct_incentive) / 100 incentive from HOSPITAL.DGN_BILL_MASTER b join " +
                "hospital.clinic_master c on c.branch_id = b.branch_id join hospital.doctors_master m on b.doct_id = m.doctor_id join " +
                "doctorincentive_percent i on i.dr_id = m.doctor_id join hospital.dgn_bill_dtl d on d.bill_id = b.bill_id join hospital.dgn_test_master t " +
                "on t.test_id = d.test_id join hospital.dgn_department_master dm on dm.dep_id = t.dep_id where DM.DEP_NAME = 'RADIOLOGY' and (to_date" +
                "(b.tra_dt, 'DD-MM-YYYY') BETWEEN to_date('" + fromdate + "', 'DD-MM-YYYY') AND to_date('" + todate + "', 'DD-MM-YYYY')) and m.doctor_id " +
                "!= 0 and c.clinic_id not in (11, 12, 13, 14, 6, 8, 9, 10, 22, 26, 17, 19, 29, 31, 35, 36, 25, 32, 33, 34) group by b.doct_id, " +
                "m.doctor_name, i.ct_incentive ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_procedureincentivereport(string fromdate, string todate)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select count(distinct(p.bill_id)) patient_count, sum (p.treatment_charge) total_collection, p.dr_id, " +
                "m.name, i.incentive_percent, (sum(p.treatment_charge) * i.incentive_percent) / 100 incentive from hospital.clinic_payment_master p join " +
                "hospital.staff_master m on m.staff_id = p.dr_id join doctorincentiveproc_percent i on i.dr_id = m.staff_id where (to_date(p.bill_date, " +
                "'dd-mm-yyyy') between to_date('" + fromdate + "', 'dd-mm-yyyy') and to_date('" + todate + "', 'dd-mm-yyyy')) and p.clinic_id not in (11, " +
                "12, 13, 14, 6, 8, 9, 10, 22, 26, 17, 19, 29, 31, 35, 36, 25, 32, 33, 34) having sum(p.treatment_charge) != 0group by p.dr_id, m.name, " +
                "i.incentive_percent");
            return DS;
        }









        [WebMethod]
        public DataSet Get_Doctorsforprocincentive(string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select m.staff_id, m.name, p.incentive_percent from hospital.staff_master m left join " +
                "doctorincentiveproc_percent p on m.staff_id = p.dr_id where m.dept_id = '" + dept_id + "' order by m.name");
            return DS;
        }
        [WebMethod]
        public int Reg_procdrincentivepercent(string dept_id, string dr_id, decimal incentive)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorincentiveproc_percent values ('" + dept_id + "', '" + dr_id + "', " + incentive + ")");
            return id;
        }

        [WebMethod]
        public DataSet delete_duplicateprocedurepercent(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorincentiveproc_percent where dr_id = '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet delete_nulldataproc()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorincentiveproc_percent where incentive_percent = '0.00' ");
            return DS;
        }
















        [WebMethod()]
        public DataSet calculate_lab_incentive(string frmdt, string todt)
        {
            ObjDataSet = new DataSet();
            OracleParameter[] pr = new OracleParameter[3];

            pr[0] = new OracleParameter("start_date", OracleType.NVarChar);
            pr[0].Value = frmdt;
            pr[0].Direction = ParameterDirection.Input;

            pr[1] = new OracleParameter("end_date", OracleType.NVarChar);
            pr[1].Value = todt;
            pr[1].Direction = ParameterDirection.Input;
           

            pr[2] = new OracleParameter("prm_cursor", OracleType.Cursor);
            pr[2].Direction = ParameterDirection.Output;

            ObjDataSet= ObjOrclHelper.ExecuteDataSet("PROC_Ref_IncentiveAmount_Lab", pr);            
            return ObjDataSet;
        }



        [WebMethod]
        public DataSet delete_duplicatedoctorpercent(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorincentive_percent where dr_id = '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet delete_nulldata()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from doctorincentive_percent where lab_incentive = '0.00' and mammo_scan_incentive = '0' and " +
                "ct_incentive = '0.00' ");
            return DS;
        }














        [WebMethod]
        public DataSet dashboard_details()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.dr_name, d.dept_name, d.dr_sittingarea, d.from_time, d.to_time, d.branch_name from " +
                "doctorsonduty_drreg d join crm_drreg c on c.doctor_id = d.dr_id where weekly_monthly = 'Monthly' and day_of_duty = (select to_char(to_date" +
                "(sysdate, 'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date(sysdate, 'DD-MM-YYYY'), 'W') from dual) and duty_id " +
                "not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date(sysdate, 'DD-MM-YYYY')) " +
                "union select d.dr_name, d.dept_name, d.dr_sittingarea, d.from_time, d.to_time, d.branch_name from doctorsonduty_drreg d join crm_drreg c " +
                "on c.doctor_id = d.dr_id where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date(sysdate, 'DD-MM-YYYY'), 'D') from " +
                "dual) and duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date(sysdate, " +
                "'DD-MM-YYYY')) " +
                "union select d.dr_name, d.dept_name, d.dr_sittingarea, s.updated_from_time, s.updated_to_time, d.branch_name from doctorsonduty_drreg d " +
                "join doctorsonduty_shiftchange s on d.duty_id = s.duty_id join crm_drreg c on c.doctor_id = d.dr_id where to_date(s.updated_date, " +
                "'DD-MM-YYYY') = to_date(sysdate, 'DD-MM-YYYY')");
            return DS;
        }





        //----------------------------------------Scanning Module-----------------------------------------------------------------------







        //[WebMethod]
        //public DataSet Get_department()
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select * from HOSPITAL.DEPARTMENT where dept_id not in(96,100)");
        //    return DS;
        //}

        [WebMethod]
        public DataSet Get_doctor(string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select staff_id, name from hospital.staff_master where dept_id = '" + dept_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_scanningtypes()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from HOSPITAL.DGN_TEST_MASTER where dep_id = 13");
            return DS;
        }

        [WebMethod]
        public DataSet Get_registereddoctors()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from scanning_doctor_master");
            return DS;
        }

        [WebMethod]
        public DataSet Get_patientdtl(string bill_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select b.patient_id, p.name from hospital.dgn_bill_master b join hospital.patient_master p on b.patient_id " +
                "= p.opnumber where b.bill_id = '" + bill_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_duplicate(string bill_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from scanning_report_master where bill_id = '" + bill_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_duplicatedoc(string bill_id, string test_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from scanning_report_master where bill_id = '" + bill_id + "' and test_id = '" + test_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_duplicatedr(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from scanning_doctor_master where doctor_id = '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_doctorwise(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select r.report_id, r.bill_id, r.patient_id, p.name, r.test_id, t.test_name, r.doctor_id, d.name_, " +
                "r.scanning_doc, to_date(b.tra_dt, 'dd-mm-yyyy') tra_date from scanning_report_master r join hospital.patient_master p on r.patient_id = " +
                "p.opnumber join hospital.dgn_bill_master b on b.bill_id = r.bill_id join hospital.dgn_test_master t on r.test_id = t.test_id join " +
                "scanning_doctor_master d on d.doctor_id = r.doctor_id where r.doctor_id = '" + dr_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_billwise(string bill_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select r.report_id, r.bill_id, r.patient_id, p.name, r.test_id, t.test_name, r.doctor_id, d.name_, " +
                "r.scanning_doc, to_date(b.tra_dt, 'dd-mm-yyyy') tra_date from scanning_report_master r join hospital.patient_master p on r.patient_id = " +
                "p.opnumber join hospital.dgn_bill_master b on b.bill_id = r.bill_id join hospital.dgn_test_master t on r.test_id = t.test_id join " +
                "scanning_doctor_master d on d.doctor_id = r.doctor_id where r.bill_id = '" + bill_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_datewise(string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select r.report_id, r.bill_id, r.patient_id, p.name, r.test_id, t.test_name, r.doctor_id, d.name_, " +
                "r.scanning_doc, to_date(b.tra_dt, 'dd-mm-yyyy') tra_date from scanning_report_master r join hospital.patient_master p on r.patient_id = " +
                "p.opnumber join hospital.dgn_bill_master b on b.bill_id = r.bill_id join hospital.dgn_test_master t on r.test_id = t.test_id join " +
                "scanning_doctor_master d on d.doctor_id = r.doctor_id where to_date(b.tra_dt, 'dd-mm-yyyy') = to_date('" + date + "', 'dd-mm-yyyy') ");
            return DS;
        }

        [WebMethod]
        public DataSet View_patientwise(string patient_name)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select r.report_id, r.bill_id, r.patient_id, p.name, r.test_id, t.test_name, r.doctor_id, d.name_, " +
                "r.scanning_doc, to_date(b.tra_dt, 'dd-mm-yyyy') tra_date from scanning_report_master r join hospital.patient_master p on r.patient_id = " +
                "p.opnumber join hospital.dgn_bill_master b on b.bill_id = r.bill_id join hospital.dgn_test_master t on r.test_id = t.test_id join " +
                "scanning_doctor_master d on d.doctor_id = r.doctor_id where p.name = '" + patient_name + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_scanningwise(string scanning)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select r.report_id, r.bill_id, r.patient_id, p.name, r.test_id, t.test_name, r.doctor_id, d.name_, " +
                "r.scanning_doc, to_date(b.tra_dt, 'dd-mm-yyyy') tra_date from scanning_report_master r join hospital.patient_master p on r.patient_id = " +
                "p.opnumber join hospital.dgn_bill_master b on b.bill_id = r.bill_id join hospital.dgn_test_master t on r.test_id = t.test_id join " +
                "scanning_doctor_master d on d.doctor_id = r.doctor_id where r.test_id = '" + scanning + "'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_registereddoc(string report_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from scanning_report_master where report_id = '" + report_id + "' ");
            return DS;
        }

        [WebMethod]
        public int insert_doctors(string dr_id, string dr_name, string dept_id)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into scanning_doctor_master values ('" + dr_id + "', '" + dr_name + "', '" + dept_id + "')");
            return id;
        }

        [WebMethod]
        public int insert_scanningdoc(string bill_id, string patient_id, string test_id, string doctor_id, string scanning_doc, string Entered_by)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into scanning_report_master values (SEQ_SCANNINGMODULE.nextval, '" + bill_id + "', " +
                "'" + patient_id + "', '" + test_id + "', '" + doctor_id + "', '" + scanning_doc + "', '" + Entered_by + "', sysdate )");
            return id;
        }

        [WebMethod]
        public int Update_doc(string report_id, string scanning_doc)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update scanning_report_master set scanning_doc = '" + scanning_doc + "' where report_id = " +
                "'" + report_id + "'");
            return id;
        }

        [WebMethod]
        public int Delete_doc(string report_id)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("Delete from scanning_report_master where report_id = '" + report_id + "'");
            return id;
        }



















        //------------------------------------------------------Doctors Payment-----------------------------------------------------------------------


        [WebMethod]
        public int insert_payment_mst(string date_, string branch_id, string dr_id, string payment_amt, string status)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_payment_mst values ('" + date_ + "', '" + branch_id + "', '" + dr_id + "', " +
                "'" + payment_amt + "', '" + status + "')");
            return id;
        }

        [WebMethod]
        public DataSet Get_payment_mstduplicate(string dr_id, string date, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_payment_mst where to_date(date_, 'dd-mm-yyyy') = to_date('" + date + "', " +
                "'dd-mm-yyyy') and dr_id = '" + dr_id + "' and branch_id = '" + branch_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_payment_report(string branch_id, string from_date, string to_date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query=("select * from ((select to_date(m.bill_date, 'dd-mm-yyyy') date_, c.name branch_name, s.name dr_name, '-' payment_amt, 'Not Paid' status " +
                "from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on " +
                "s.staff_id = p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id where c.branch_id = '" + branch_id + "' and (to_date" +
                "(m.bill_date, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy')) and " +
                "m.consult_fee != 0 group by to_date(m.bill_date, 'dd-mm-yyyy'), c.name, s.name) " +
                "minus (select to_date(p.date_, 'dd-mm-yyyy') date_, c.name branch_name, s.name dr_name, '-' payment_amt, 'Not Paid' status from " +
                "doctorsonduty_payment_mst p join hospital.clinic_master c on p.branch_id = c.branch_id join hospital.staff_master s on s.staff_id = " +
                "p.dr_id where p.branch_id = '" + branch_id + "' and to_date(p.date_, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and " +
                "to_date('" + to_date + "', 'dd-mm-yyyy')) " +
                "union (select to_date(p.date_, 'dd-mm-yyyy') date_, c.name branch_name, s.name dr_name, p.payment_amt, p.status from " +
                "doctorsonduty_payment_mst p join hospital.clinic_master c on p.branch_id = c.branch_id join hospital.staff_master s on s.staff_id = " +
                "p.dr_id where p.branch_id = '" + branch_id + "' and to_date(p.date_, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and " +
                "to_date('" + to_date + "', 'dd-mm-yyyy'))) x order by to_date(x.date_, 'dd-mm-yyyy'), x.dr_name ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int insert_paymentterms(string dr_id, string pervisit_amt, string max_no_of_visit, string perpatient_amt, string above_max_amt, string above_max_percent, string lab_amt, string lab_percent, string procedure_amt, string procedure_percent, string echo_amt, string echo_percent, string tmt_amt, string tmt_percent, string scan_amt, string scan_percent, string pft_amt, string pft_percent, string ta_all, string ta_sunday)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_paymentterms values ('" + dr_id + "', '" + pervisit_amt + "', " +
                "'" + max_no_of_visit + "', '" + perpatient_amt + "', '" + above_max_amt + "', '" + above_max_percent + "', '" + lab_amt + "', " +
                "'" + lab_percent + "', '" + procedure_amt + "', '" + procedure_percent + "', '" + echo_amt + "', '" + echo_percent + "', " +
                "'" + tmt_amt + "', '" + tmt_percent + "', '" + scan_amt + "', '" + scan_percent + "', '" + pft_amt + "', '" + pft_percent + "', " +
                "'" + ta_all + "', '" + ta_sunday + "')");
            return id;
        }

        [WebMethod]
        public int Update_paymentmst(string date_, string branch_id, string dr_id, string payment_amt, string status)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update doctorsonduty_payment_mst set payment_amt = '" + payment_amt + "', status = '" + status + "' where " +
                "to_date(date_, 'dd-mm-yyyy') = to_date('" + date_ + "', 'dd-mm-yyyy') and dr_id = '" + dr_id + "' and branch_id = '" + branch_id + "' ");
            return id;
        }

        //[WebMethod]
        //public DataSet Get_drtotalcollection(string from_date, string to_date)
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select count(m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) " +
        //        "total_collection, m.dr_id, s.name from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join " +
        //        "hospital.staff_master s on s.staff_id = p.dr_id where to_date(m.bill_date, 'dd-mm-yyyy') between to_date('"+from_date+"', " +
        //        "'dd-mm-yyyy') and to_date('"+to_date+"', 'dd-mm-yyyy') and m.consult_fee != 0 group by m.dr_id, s.name");
        //    return DS;
        //}

        [WebMethod]
        public DataSet Get_drtotalcollection(string from_date, string to_date, string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query=("select count(m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) total_collection, m.dr_id, s.name, dp.status " +
                "from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on s.staff_id = " +
                "p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id join doctorsonduty_payment_mst dp on dp.dr_id = p.dr_id where to_date" +
                "(dp.date_, 'dd-mm-yyyy') = to_date('" + to_date + "', 'dd-mm-yyyy') and c.branch_id = '" + branch_id + "' and (to_date(m.bill_date, " +
                "'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy')) and m.consult_fee != 0 " +
                "group by m.dr_id, s.name, dp.status " +
                "union select count(m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) total_collection, m.dr_id, s.name, 'Not " +
                "Paid' status from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on " +
                "s.staff_id = p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id where m.dr_id not in (select dr_id from " +
                "doctorsonduty_payment_mst where to_date(date_, 'dd-mm-yyyy') = to_date('" + to_date + "', 'dd-mm-yyyy')) and c.branch_id = " +
                "'" + branch_id + "' and (to_date(m.bill_date, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date" +
                "('" + to_date + "', 'dd-mm-yyyy')) and m.consult_fee != 0 group by m.dr_id, s.name");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_drtotalcollection1(string from_date, string to_date, string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select count(m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) total_collection, m.dr_id, s.name, dp.status " +
                "from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on s.staff_id = " +
                "p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id join doctorsonduty_payment_mst dp on dp.dr_id = p.dr_id where to_date" +
                "(dp.date_, 'dd-mm-yyyy') = to_date('" + to_date + "', 'dd-mm-yyyy') and c.branch_id = '" + branch_id + "' and (to_date(m.bill_date, " +
                "'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy')) and m.consult_fee != 0 " +
                "group by m.dr_id, s.name, dp.status " +
                "union select count(m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) total_collection, m.dr_id, s.name, 'Not " +
                "Paid' status from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on " +
                "s.staff_id = p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id where m.dr_id not in (select dr_id from " +
                "doctorsonduty_payment_mst where to_date(date_, 'dd-mm-yyyy') = to_date('" + to_date + "', 'dd-mm-yyyy')) and c.branch_id = " +
                "'" + branch_id + "' and (to_date(m.bill_date, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date" +
                "('" + to_date + "', 'dd-mm-yyyy')) and m.consult_fee != 0 group by m.dr_id, s.name " +
                "union select 0 total_patient, 0 total_collection, m.doct_id, s.name, 'Not Paid' status from hospital.dgn_bill_master m join " +
                "doctorsonduty_paymentterms p on p.dr_id = m.doct_id join hospital.staff_master s on s.staff_id = p.dr_id where m.doct_id not in (select " +
                "dr_id from (select count(m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) total_collection, m.dr_id, s.name, " +
                "dp.status from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on " +
                "s.staff_id = p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id join doctorsonduty_payment_mst dp on dp.dr_id = p.dr_id " +
                "where to_date(dp.date_, 'dd-mm-yyyy') = to_date('" + to_date + "', 'dd-mm-yyyy') and c.branch_id = '" + branch_id + "' and (to_date" +
                "(m.bill_date, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy')) and " +
                "m.consult_fee != 0 group by m.dr_id, s.name, dp.status " +
                "union select count (m.bill_id) total_patient, nvl(sum(m.consult_fee + m.treatment_charge), 0) total_collection, m.dr_id, s.name, 'Not " +
                "Paid' status from HOSPITAL.CLINIC_PAYMENT_MASTER m join doctorsonduty_paymentterms p on m.dr_id = p.dr_id join hospital.staff_master s on " +
                "s.staff_id = p.dr_id join hospital.clinic_master c on c.clinic_id = m.clinic_id where m.dr_id not in (select dr_id from " +
                "doctorsonduty_payment_mst where to_date(date_, 'dd-mm-yyyy') = to_date('" + to_date + "', 'dd-mm-yyyy')) and c.branch_id = " +
                "'" + branch_id + "' and (to_date(m.bill_date, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date" +
                "('" + to_date + "', 'dd-mm-yyyy')) and m.consult_fee != 0 group by m.dr_id, s.name)) and m.branch_id = '" + branch_id + "' and (to_date" +
                "(m.tra_dt, 'dd-mm-yyyy') between to_date('" + from_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy'))");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_drindividualcollection(string from_date,string to_date,string dr_id,string branch_id)
        {
            DataTable DT = new DataTable();
            //DataTable DT1 = new DataTable();
            DataSet DS = new DataSet();
            string total_patient, total_collection,frmdate;
            int difference;
            ObjOrclHelper.ExecuteDataSet("delete from doctorsonduty_payment_temp");
            difference = ObjOrclHelper.executeScalar("select to_date('" + to_date + "', 'dd-mm-yyyy') - to_date('" + from_date + "', 'dd-mm-yyyy') from dual");
            for(int i=0;i<=difference;i++)
            {
                DT = ObjOrclHelper.ExecuteDataSet("select count(p.bill_id) total_patient, nvl(sum(p.consult_fee + p.treatment_charge), 0) total_collection, " +
                    "to_date('" + from_date + "', 'dd-mm-yyyy') + " + i + " frmdate from HOSPITAL.CLINIC_PAYMENT_MASTER p join hospital.clinic_master c on " +
                    "p.clinic_id = c.clinic_id where c.branch_id = '" + branch_id + "' and to_date(p.bill_date, 'dd-mm-yyyy') = to_date('" + from_date + "', " +
                    "'dd-mm-yyyy') + " + i + " and consult_fee != 0 and dr_id = '" + dr_id + "'").Tables[0];
                if(DT.Rows.Count>0)
                {
                    total_patient = DT.Rows[0]["total_patient"].ToString();
                    total_collection = DT.Rows[0]["total_collection"].ToString();
                    frmdate = DT.Rows[0]["frmdate"].ToString();
                    //if(Convert.ToInt32( total_patient)>0)
                    //{
                        ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_payment_temp (dr_id, date_, total_patient, total_collection) values ('" + dr_id + "', " +
                            "'" + frmdate + "', '" + total_patient + "', '" + total_collection + "')");
                    //}                   
                }
                //DT1 = ObjOrclHelper.ExecuteDataSet("select to_date('" + from_date + "','dd-mm-yyyy')+1 frmdate from dual").Tables[0];
                //if(DT1.Rows.Count>0)
                //    from_date = DT1.Rows[0]["frmdate"].ToString();
            }
            
            DS = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_payment_temp");
            return DS;
        }

        [WebMethod]
        public DataSet Get_payment()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(count(t.date_) * p.pervisit_amt, 0) pervisit_payment, case when p.max_no_of_visit > 0 then nvl" +
                "(p.max_no_of_visit * p.perpatient_amt, 0) else nvl(sum(t.total_patient) * p.perpatient_amt, 0) end perpatient_payment from " +
                "doctorsonduty_paymentterms p join doctorsonduty_payment_temp t on p.dr_id = t.dr_id group by p.pervisit_amt, p.perpatient_amt, " +
                "p.max_no_of_visit");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ttlpayment()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(sum(above_max), 0) totalpayment from doctorsonduty_payment_temp");
            return DS;
        }

        [WebMethod]
        public int Get_abovemaxpayment()
        {
            int id = 0;
            DataTable DT = new DataTable();
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();
            DataSet DS = new DataSet();
            string max_no_of_visit, abovemax, totalpatient, date, dr_id, abovemax_amt, abovemax_percent, total;
            DT1 = ObjOrclHelper.ExecuteDataSet("select * from doctorsonduty_payment_temp").Tables[0];
            for(int i=0;i<DT1.Rows.Count;i++)
            {
                totalpatient = DT1.Rows[i]["total_patient"].ToString();
                date = DT1.Rows[i]["date_"].ToString();
                dr_id = DT1.Rows[i]["dr_id"].ToString();
                DT = ObjOrclHelper.ExecuteDataSet("select nvl(max_no_of_visit, 0) max from doctorsonduty_paymentterms where dr_id = '" + dr_id + "' ").Tables[0];
                if (DT.Rows.Count > 0)
                {
                    max_no_of_visit = DT.Rows[0]["max"].ToString();
                    
                    if (Convert.ToInt32(totalpatient) > Convert.ToInt32(max_no_of_visit))
                    {
                        abovemax = (Convert.ToInt32(totalpatient) - Convert.ToInt32(max_no_of_visit)).ToString();
                        int ttl = Convert.ToInt32(totalpatient);
                        int above = Convert.ToInt32(abovemax);
                        string query = ("select nvl((p.above_maximum_amt * '" + abovemax + "'), 0) above_max_amt, nvl(((p.above_maximum_percent * ((t.total_collection " +
                            "/ '" + totalpatient + "') * '" + abovemax + "')) / 100), 0) above_max_percent from doctorsonduty_paymentterms p join " +
                            "doctorsonduty_payment_temp t on p.dr_id = t.dr_id where t.dr_id = '" + dr_id + "'");
                        DT2 = ObjOrclHelper.ExecuteDataSet("select nvl((p.above_maximum_amt * " + above + "), 0) above_max_amt, nvl(((p.above_maximum_percent * " +
                            "((t.total_collection / " + ttl + ") * " + above + ")) / 100), 0) above_max_percent from doctorsonduty_paymentterms p join " +
                            "doctorsonduty_payment_temp t on p.dr_id = t.dr_id where t.dr_id = '" + dr_id + "'").Tables[0];
                        if(DT2.Rows.Count>0)
                        {
                            abovemax_amt = DT2.Rows[0]["above_max_amt"].ToString();
                            abovemax_percent = DT2.Rows[0]["above_max_percent"].ToString();
                            total = (Convert.ToInt32(abovemax_amt) + Convert.ToInt32(abovemax_percent)).ToString();
                            id=ObjOrclHelper.ExecuteNonQuery("update doctorsonduty_payment_temp set above_max = '" + total + "' where dr_id = '" + dr_id + "' ");
                        }
                    }
                }
            }                                
            return id;
        }

        [WebMethod]
        public DataSet Get_lab(string frm_date, string to_date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(nvl((count(distinct(m.bill_id)) * p.lab_amt), 0) + nvl(((sum(m.test_charge) * p.lab_percent) / " +
                "100), 0), 0) total_collection from hospital.dgn_bill_master m join hospital.dgn_bill_dtl d on m.bill_id = d.bill_id join " +
                "hospital.dgn_test_master t on t.test_id = d.test_id join doctorsonduty_paymentterms p on p.dr_id = m.doct_id where m.branch_id = " +
                "'" + branch_id + "' and m.doct_id = '" + dr_id + "' and t.dep_id in (1, 2, 23, 0, 3, 4, 5, 14, 6, 21, 7, 11, 9) and to_date(m.tra_dt, " +
                "'dd-mm-yyyy') between to_date('" + frm_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy') group by p.lab_amt, " +
                "p.lab_percent");
            return DS;
        }

        [WebMethod]
        public DataSet Get_echo(string frm_date, string to_date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(nvl((count(distinct(m.bill_id)) * p.echo_amt), 0) + nvl(((sum(m.test_charge) * p.echo_percent) / " +
                "100), 0), 0) total_collection from hospital.dgn_bill_master m join hospital.dgn_bill_dtl d on m.bill_id = d.bill_id join " +
                "hospital.dgn_test_master t on t.test_id = d.test_id join doctorsonduty_paymentterms p on p.dr_id = m.doct_id where m.branch_id = " +
                "'" + branch_id + "' and m.doct_id = '" + dr_id + "' and t.dep_id = 16 and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date" +
                "('" + frm_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy') group by p.echo_amt, p.echo_percent");
            return DS;
        }

        [WebMethod]
        public DataSet Get_tmt(string frm_date, string to_date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(nvl((count(distinct(m.bill_id)) * p.tmt_amt), 0) + nvl(((sum(m.test_charge) * p.tmt_percent) / " +
                "100), 0), 0) total_collection from hospital.dgn_bill_master m join hospital.dgn_bill_dtl d on m.bill_id = d.bill_id join " +
                "hospital.dgn_test_master t on t.test_id = d.test_id join doctorsonduty_paymentterms p on p.dr_id = m.doct_id where m.branch_id = " +
                "'" + branch_id + "' and m.doct_id = '" + dr_id + "' and t.dep_id = 20 and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date" +
                "('" + frm_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy') group by p.tmt_amt, p.tmt_percent");
            return DS;
        }

        [WebMethod]
        public DataSet Get_scan(string frm_date, string to_date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(nvl((count(distinct(m.bill_id)) * p.scan_amt), 0) + nvl(((sum(m.test_charge) * p.scan_percent) / " +
                "100), 0), 0) total_collection from hospital.dgn_bill_master m join hospital.dgn_bill_dtl d on m.bill_id = d.bill_id join " +
                "hospital.dgn_test_master t on t.test_id = d.test_id join doctorsonduty_paymentterms p on p.dr_id = m.doct_id where m.branch_id = " +
                "'" + branch_id + "' and m.doct_id = '" + dr_id + "' and t.dep_id = 13 and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date" +
                "('" + frm_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy') group by p.scan_amt, p.scan_percent");
            return DS;
        }

        [WebMethod]
        public DataSet Get_procedure(string frm_date, string to_date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query=("select nvl(nvl((count(distinct(p.bill_id)) * d.procedure_amt), 0) + nvl(((sum(p.treatment_charge) * d.procedure_percent) / 100), 0), " +
                "0) total_collection from hospital.clinic_payment_master p join doctorsonduty_paymentterms d on p.dr_id = d.dr_id join " +
                "hospital.clinic_master c on c.clinic_id = p.clinic_id where c.branch_id = '" + branch_id + "' and p.dr_id = '" + dr_id + "' and (to_date" +
                "(p.bill_date, 'dd-mm-yyyy') between to_date('" + frm_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy')) and " +
                "p.clinic_id not in (11, 12, 13, 14, 6, 8, 9, 10, 22, 26, 17, 19, 29, 31, 35, 36, 25, 32, 33, 34) having sum(p.treatment_charge) != 0 " +
                "group by d.procedure_amt, d.procedure_percent");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_pft(string frm_date, string to_date, string dr_id, string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(nvl((count(distinct(m.bill_id)) * p.scan_amt), 0) + nvl(((sum(m.test_charge) * p.scan_percent) / " +
                "100), 0), 0) total_collection from hospital.dgn_bill_master m join hospital.dgn_bill_dtl d on m.bill_id = d.bill_id join " +
                "hospital.dgn_test_master t on t.test_id = d.test_id join doctorsonduty_paymentterms p on p.dr_id = m.doct_id where m.branch_id = " +
                "'" + branch_id + "' and m.doct_id = '" + dr_id + "' and t.dep_id = 18 and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date" +
                "('" + frm_date + "', 'dd-mm-yyyy') and to_date('" + to_date + "', 'dd-mm-yyyy') group by p.scan_amt, p.scan_percent");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ta()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            string sunday="0";
            DT = ObjOrclHelper.ExecuteDataSet("select count(*) sunday from doctorsonduty_payment_temp where to_char(to_date(date_, 'DD-MM-YYYY " +
                "hh24:mi:ss'), 'D') = 1").Tables[0];
            if(DT.Rows.Count>0)
            {
                sunday = DT.Rows[0]["sunday"].ToString();
            }
            DS = ObjOrclHelper.ExecuteDataSet("select nvl((count(t.date_) * p.ta_all + '" + sunday + "' * p.ta_sunday), 0) ta from " +
                "doctorsonduty_payment_temp t join doctorsonduty_paymentterms p on t.dr_id = p.dr_id group by p.ta_all, p.ta_sunday");
            return DS;
        }

        [WebMethod]
        public DataSet Get_drsforpaymentedit()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct d.dr_id, s.name from doctorsonduty_drreg d join hospital.staff_master s on s.staff_id = " +
                "d.dr_id order by s.name ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_paymenttermforedit(string dr_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select payment_terms from doctorsonduty_drreg where dr_id = '" + dr_id + "'");
            return DS;
        }

        [WebMethod]
        public int Update_paymentterms(string dr_id, string payment_terms, string pervisit_amt, string max_no_of_visit, string perpatient_amt, string above_max_amt, string above_max_percent, string lab_amt, string lab_percent, string procedure_amt, string procedure_percent, string echo_amt, string echo_percent, string tmt_amt, string tmt_percent, string scan_amt, string scan_percent, string pft_amt, string pft_percent, string ta_all, string ta_sunday)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update doctorsonduty_drreg set payment_terms = '" + payment_terms + "' where dr_id = '"+dr_id + "' ");
            ObjOrclHelper.ExecuteDataSet("delete from doctorsonduty_paymentterms where dr_id = '" + dr_id + "' ");
            id = ObjOrclHelper.ExecuteNonQuery("insert into doctorsonduty_paymentterms values ('" + dr_id + "', '" + pervisit_amt + "', " +
                "'" + max_no_of_visit + "', '" + perpatient_amt + "', '" + above_max_amt + "', '" + above_max_percent + "', '" + lab_amt + "', " +
                "'" + lab_percent + "', '" + procedure_amt + "', '" + procedure_percent + "', '" + echo_amt + "', '" + echo_percent + "', " +
                "'" + tmt_amt + "', '" + tmt_percent + "', '" + scan_amt + "', '" + scan_percent + "', '" + pft_amt + "', '" + pft_percent + "', " +
                "'" + ta_all + "', '" + ta_sunday + "')");
            return id;
        }



















        //----------------------------------------Staff Shift---------------------------------------------------------------------------


        //[WebMethod]
        //public DataSet Get_allshift()
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select shift_id,shift||' ('||in_time||' - '||out_time||')' shift_name from MACTECH.TIME_TAB order by " +
        //        "shift_name");
        //    return DS;
        //}

        //[WebMethod]
        //public DataSet Get_shift()
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select * from employee_shift_mst");
        //    return DS;
        //}


        [WebMethod]
        public int insert_employeedtl(string dept_id, string emp_code,string branch_id,string entered_by)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into employee_dept_dtl values ('" + dept_id + "', '" + emp_code + "', '" + branch_id + "', sysdate, " +
                "'" + entered_by + "')");
            return id;
        }

        [WebMethod]
        public DataSet Get_Empduplication(string emp_code)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from employee_dept_dtl where employee_code = '" + emp_code + "'");
            return DS;
        }

        [WebMethod]
        public DataSet delete_employee(string emp_code)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from employee_dept_dtl where employee_code = '" + emp_code + "' ");
            return DS;
        }


        [WebMethod]
        public DataSet Get_Empdept()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from employee_dept_mst");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Employees(string branch_id)
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select * from employee_dept_dtl d join hospital.employee_master e on d.employee_code=e.emp_code where " +
            //    "d.department_id='" + dept_id + "' and d.branch_id='"+branch_id+"' ");
            DS = ObjOrclHelper.ExecuteDataSet("select emp_code, emp_name || ' - ' || emp_code emp_name from hospital.employee_master where branch_id = " +
                "'" + branch_id + "' and status_id != 3 and emp_code not in (select employee_code from employee_dept_dtl ) order by emp_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Employees1()
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select * from employee_dept_dtl d join hospital.employee_master e on d.employee_code=e.emp_code where " +
            //    "d.department_id='" + dept_id + "' and d.branch_id='"+branch_id+"' ");
            DS = ObjOrclHelper.ExecuteDataSet("select emp_code, emp_name || ' - ' || emp_code emp_name from hospital.employee_master where emp_code not in " +
                "(select employee_code from employee_dept_dtl ) order by emp_name ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_RegisteredEmployees(string branch_id,string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select m.emp_code, m.emp_name, dm.department from hospital.employee_master m join employee_dept_dtl d on " +
                "d.employee_code = m.emp_code join employee_dept_mst dm on dm.department_id = d.department_id where d.branch_id = '" + branch_id + "' and " +
                "d.department_id = '" + dept_id + "' order by m.emp_name ");
            return DS;
        }

        //[WebMethod]
        //public DataSet Avoid_shiftduplication(string shift_id)
        //{
        //    DataSet DS = new DataSet();
        //    DS = ObjOrclHelper.ExecuteDataSet("select * from employee_shift_mst where shift_id='"+shift_id+"' ");
        //    return DS;
        //}

        //[WebMethod]
        //public int insert_employeeshift(string shift_id, string shift_name)
        //{
        //    int id = 0;
        //    id = ObjOrclHelper.ExecuteNonQuery("insert into employee_shift_mst values('" + shift_id + "','" + shift_name + "')");
        //    return id;
        //}

        //[WebMethod]
        //public int Update_employeeshift(string emp_code,string shift_id,string updated_by)
        //{
        //    int id = 0;
        //    id = ObjOrclHelper.ExecuteNonQuery("update employee_dept_dtl set shift_id='"+shift_id+"',updated_by='"+updated_by+"',updated_on=sysdate " +
        //        "where employee_code='"+emp_code+"' ");
        //    return id;
        //}

        [WebMethod]
        public DataSet Get_currentdoctors(string branch_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.dr_name, d.dept_name, d.from_time, d.to_time, d.dr_sittingarea from doctorsonduty_drreg d join " +
                "crm_drreg c on d.dr_id = c.doctor_id where weekly_monthly = 'Monthly' and day_of_duty = (select to_char(to_date(sysdate, 'DD-MM-YYYY'), " +
                "'D') from dual) and week_number = (select to_char(to_date(sysdate, 'DD-MM-YYYY'), 'W') from dual) and duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date(sysdate, 'DD-MM-YYYY')) and (TO_CHAR(SYSDATE, 'HH24:MI') " +
                "BETWEEN d.to_time AND d.from_time or to_time = '' or to_time is null) and d.branch_id = '" + branch_id + "' " +
                "union select d.dr_name, d.dept_name, d.from_time, d.to_time, d.dr_sittingarea from doctorsonduty_drreg d join crm_drreg c on d.dr_id = " +
                "c.doctor_id where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date(sysdate, 'DD-MM-YYYY'), 'D') from dual) and duty_id " +
                "not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date(sysdate, 'DD-MM-YYYY')) and " +
                "(TO_CHAR(SYSDATE, 'HH24:MI') BETWEEN d.to_time AND d.from_time or to_time = '' or to_time is null) and d.branch_id = '" + branch_id + "' " +
                "union select d.dr_name, d.dept_name, d.from_time, d.to_time, d.dr_sittingarea from doctorsonduty_drreg d join crm_drreg c on d.dr_id = " +
                "c.doctor_id join doctorsonduty_shiftchange s on d.duty_id = s.duty_id where to_date(s.updated_date, 'DD-MM-YYYY') = to_date(sysdate, " +
                "'DD-MM-YYYY') and (TO_CHAR(SYSDATE, 'HH24:MI') BETWEEN s.updated_from_time AND s.updated_to_time or s.updated_from_time = '' or " +
                "s.updated_from_time is null) and d.branch_id = '" + branch_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_currentemployees(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query= "select e.employee_code, m.emp_name, dm.department, t.in_time || ' - ' || t.out_time shift from mactech.DAILY_ATTEND d join " +
                "employee_dept_dtl e on e.employee_code = d.emp_code join hospital.employee_master m on m.emp_code = e.employee_code join " +
                "employee_dept_mst dm on dm.department_id = e.department_id join mactech.time_tab t on m.shift_id = t.shift_id where to_date(d.curr_date, " +
                "'dd-mm-yyyy') = to_date(sysdate, 'dd-mm-yyyy') and d.m_time >= '0' and (TO_CHAR(SYSDATE, 'HH24:MI') between t.in_time and t.out_time) and " +
                "e.branch_id = '" + branch_id + "' order by dm.department";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet doctor_Shiftreport(string branch_id,string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query=("select d.dr_name, d.dept_name, d.dr_sittingarea, d.to_time || '-' || d.from_time time from doctorsonduty_drreg d join crm_drreg c on " +
                "d.dr_id = c.doctor_id where weekly_monthly = 'Monthly' and day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from " +
                "dual) and week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.branch_id = " +
                "'" + branch_id + "' " +
                "union select d.dr_name, d.dept_name, d.dr_sittingarea, d.to_time || '-' || d.from_time time from doctorsonduty_drreg d join crm_drreg c " +
                "on d.dr_id = c.doctor_id where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') " +
                "from dual) and duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date" +
                "('" + date + "', 'DD-MM-YYYY')) and d.branch_id = '" + branch_id + "' " +
                "union select d.dr_name, d.dept_name, d.dr_sittingarea, s.updated_to_time || '-' || s.updated_from_time time from doctorsonduty_drreg d " +
                "join crm_drreg c on d.dr_id = c.doctor_id join doctorsonduty_shiftchange s on d.duty_id = s.duty_id where to_date(s.updated_date, " +
                "'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and d.branch_id = '" + branch_id + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet employee_Shiftreport(string branch_id)
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select e.emp_code,e.emp_name,dm.department,s.shift_name from hospital.employee_master e join " +
            //    "employee_dept_dtl d on e.emp_code=d.employee_code join employee_dept_mst dm on dm.department_id=d.department_id join employee_shift_mst" +
            //    " s on s.shift_id=d.shift_id where d.branch_id='"+branch_id+ "' order by dm.department");

            DS = ObjOrclHelper.ExecuteDataSet("select e.emp_code, e.emp_name, dm.department, S.SHIFT || ' (' || S.IN_TIME || '-' || S.OUT_TIME || ')' " +
                "shift_name from hospital.employee_master e join employee_dept_dtl d on e.emp_code = d.employee_code join employee_dept_mst dm on " +
                "dm.department_id = d.department_id join MACTECH.TIME_TAB s on s.shift_id = e.shift_id where d.branch_id = '" + branch_id + "' order by " +
                "dm.department");

            return DS;
        }



















        //---------------------------------------------------Doctors Punching-------------------------------------------------------------

        [WebMethod]
        public int insert_punchin(string dr_id, string branch_id, string punch_in, string punchin_by)
        {
            int id = 0;
            string query = "";
            query = ("insert into doctorpunching (punch_id, dr_id, branch_id, punch_in, date_, punchin_by) values (SEQ_DRPUNCH.nextval, '" + dr_id + "', " +
                "'" + branch_id + "', '" + punch_in + "', sysdate, '" + punchin_by + "')");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int update_punchout(string punch_id, string punch_out, string punchout_by)
        {
            int id = 0;
            string query = "";
            query = ("update doctorpunching set punch_out = '" + punch_out + "', punchout_by = '" + punchout_by + "', punchout_dt = sysdate where punch_id " +
                "= '" + punch_id + "' ");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_Doctorsforpunch()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct p.dr_id, s.dr_name name from doctorpunching p join doctorsonduty_drreg s on p.dr_id = s.dr_id ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Puncheddoctors( string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct p.*, d.dr_name name from doctorpunching p join doctorsonduty_drreg d on d.dr_id = p.dr_id where p.punch_out is null " +
                "and p.branch_id = '" + branch_id + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorsfrmcrm(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct d.dr_id, d.dr_name from doctorsonduty_drreg d join crm_drreg c on d.dr_id = c.doctor_id where d.branch_id = " +
                "'" + branch_id + "' and c.doctor_id not in (select dr_id from doctorpunching where punch_out is null) ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Duplicationforpunchin(string branch_id, string dr_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from doctorpunching where punch_out is null and dr_id = '" + dr_id + "' and branch_id = '" + branch_id + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Drpunchreport(string dr_id, string frm_dt, string to_dt)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct s.dr_name doctor_name, c.name, p.date_ curr_date, p.punch_in, p.punch_out, p.punchout_dt from DOCTORPUNCHING p join " +
                "HOSPITAL.CLINIC_MASTER c on c.branch_id = p.branch_id join doctorsonduty_drreg s on s.dr_id = p.dr_id where p.dr_id = '" + dr_id + "' and " +
                "to_date(p.date_, 'dd-mm-yyyy') between to_date('" + frm_dt + "', 'dd-mm-yyyy') and to_date('" + to_dt + "', 'dd-mm-yyyy') order by to_date" +
                "(p.date_, 'dd-mm-yyyy') ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet delete_drfrompunch(string punch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = "delete from doctorpunching where punch_id = '" + punch_id + "'";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

























        //--------------------------------------------------------------NORMS------------------------------------------------------------


        [WebMethod]
        public int Insert_Area(string branch_id, string area)
        {
            int id = 0;
            string query = "";
            query = ("insert into NORMS_SITTING_AREA (area_id, branch_id, area_name) values (SEQ_NORMS.nextval, '" + branch_id + "', '" + area + "')");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_Area(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from NORMS_SITTING_AREA a join hospital.clinic_master c on c.branch_id = a.branch_id where a.branch_id = '" + branch_id + "'");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Insert_Area_effect(string dept_id, int pharmacy, int reception, int nurse, int extrastaff)
        {
            int id = 0;
            string query = "";
            query = ("insert into norms_affect_areas (dept_id, pharmacy, reception, nurse, extrastaff) values ('" + dept_id + "', " + pharmacy + ", " +
                "" + reception + ", " + nurse + ", " + extrastaff + ")");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Update_norms_range1(string norms_area, int patient_ratio, int staff_ratio)
        {
            int id = 0;
            string query = "";
            query = ("update norms_range set patient_ratio = " + patient_ratio + ", staff_ratio = " + staff_ratio + " where norms_area = " +
                "'" + norms_area + "' ");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Update_norms_staffs_sitting(int area_id, string emp_code )
        {
            int id = 0;
            string query = "";
            query = ("update norms_staffs_sitting set area_id = " + area_id + " where emp_code = '" + emp_code + "' ");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Insert_norms_staffs_sitting(string emp_code, int area_id)
        {
            int id = 0;
            string query = "";
            query = ("insert into norms_staffs_sitting (area_id, emp_code) values (" + area_id + ", '" + emp_code + "')");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_Areaeffect()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select a.*, d.dept_name From norms_affect_areas a join hospital.department d on a.dept_id = d.dept_id ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Normsrange()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from norms_range ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Normsrange_pharmacy()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from norms_range where norms_area = 'PHARMACY' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Normsrange_nurse()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from norms_range where norms_area = 'NURSE' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Normsrange_reception()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from norms_range where norms_area = 'RECEPTION' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet delete_Areaeffect()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = "delete from norms_affect_areas ";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Areaeffectdummy()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select dept_id, dept_name, 0 pharmacy, 0 reception, 0 nurse, 0 extrastaff from hospital.department ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_EffectedArea(string dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from norms_affect_areas where dept_id = '" + dept_id + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorsfor_Norms(string branch_id, string area, string fromtime, string totime)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select d.dr_id, d.dept_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.from_time, d.to_time, d.branch_name from doctorsonduty_drreg " +
                "d join crm_drreg c on c.doctor_id = d.dr_id where weekly_monthly = 'Monthly' and day_of_duty = (select to_char(to_date(sysdate + 1, " +
                "'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date(sysdate + 1, 'DD-MM-YYYY'), 'W') from dual) and duty_id not in " +
                "(select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date(sysdate + 1, 'DD-MM-YYYY')) and " +
                "d.branch_id = '" + branch_id + "' and d.dr_sittingarea = '" + area + "' and ((d.from_time between '" + fromtime + "' and " +
                "'" + totime + "') or (d.to_time between '" + fromtime + "' and '" + totime + "')) " +
                "union select d.dr_id, d.dept_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.from_time, d.to_time, d.branch_name from doctorsonduty_drreg " +
                "d join crm_drreg c on c.doctor_id = d.dr_id where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date(sysdate + 1, " +
                "'DD-MM-YYYY'), 'D') from dual) and duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') " +
                "= to_date(sysdate + 1, 'DD-MM-YYYY')) and d.branch_id = '" + branch_id + "' and d.dr_sittingarea = '" + area + "' and ((d.from_time " +
                "between '" + fromtime + "' and '" + totime + "') or (d.to_time between '" + fromtime + "' and '" + totime + "')) " +
                "union select d.dr_id, d.dept_id, d.dr_name, d.dept_name, d.dr_sittingarea, s.updated_from_time, s.updated_to_time, d.branch_name from " +
                "doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = s.duty_id join crm_drreg c on c.doctor_id = d.dr_id where to_date" +
                "(s.updated_date, 'DD-MM-YYYY') = to_date(sysdate + 1, 'DD-MM-YYYY') and d.branch_id = '" + branch_id + "' and d.dr_sittingarea = " +
                "'" + area + "' and ((d.from_time between '" + fromtime + "' and '" + totime + "') or (d.to_time between '" + fromtime + "' and " +
                "'" + totime + "')) ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorsfor_Normscalculation(string branch_id, string area, string time)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select d.dr_id, d.dept_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.from_time, d.to_time, d.branch_name from doctorsonduty_drreg " +
                "d join crm_drreg c on c.doctor_id = d.dr_id where weekly_monthly = 'Monthly' and day_of_duty = (select to_char(to_date(sysdate, " +
                "'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date(sysdate, 'DD-MM-YYYY'), 'W') from dual) and duty_id not in " +
                "(select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date(sysdate, 'DD-MM-YYYY')) and d.branch_id " +
                "= '" + branch_id + "' and d.dr_sittingarea = '" + area + "' and d.dr_id in (select dr_id from doctorpunching where to_date(date_, " +
                "'dd-mm-yyyy') = to_date(sysdate, 'dd-mm-yyyy') and '" + time + "' > punch_in and punch_out is null) " +
                "union select d.dr_id, d.dept_id, d.dr_name, d.dept_name, d.dr_sittingarea, d.from_time, d.to_time, d.branch_name from doctorsonduty_drreg " +
                "d join crm_drreg c on c.doctor_id = d.dr_id where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date(sysdate, " +
                "'DD-MM-YYYY'), 'D') from dual) and duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') " +
                "= to_date(sysdate, 'DD-MM-YYYY')) and d.branch_id = '" + branch_id + "' and d.dr_sittingarea = '" + area + "' and d.dr_id in (select " +
                "dr_id from doctorpunching where to_date(date_, 'dd-mm-yyyy') = to_date(sysdate, 'dd-mm-yyyy') and '" + time + "' > punch_in and punch_out " +
                "is null) " +
                "union select d.dr_id, d.dept_id, d.dr_name, d.dept_name, d.dr_sittingarea, s.updated_from_time, s.updated_to_time, d.branch_name from " +
                "doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = s.duty_id join crm_drreg c on c.doctor_id = d.dr_id where to_date" +
                "(s.updated_date, 'DD-MM-YYYY') = to_date(sysdate, 'DD-MM-YYYY') and d.branch_id = '" + branch_id + "' and d.dr_sittingarea = " +
                "'" + area + "' and d.dr_id in (select dr_id from doctorpunching where to_date(date_, 'dd-mm-yyyy') = to_date(sysdate, 'dd-mm-yyyy') and " +
                "'" + time + "' > punch_in and punch_out is null) ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_PatientCount(string branch_id, string dr_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from doctorsonduty_payment where dr_id = '" + dr_id + "' and branch_id = '" + branch_id + "' and date_=(select max(to_date" +
                "(date_)) from doctorsonduty_payment where dr_id = '" + dr_id + "' and branch_id = '" + branch_id + "')  ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_PatientCount1(string branch_id, string dr_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select count(*) total_patient from HOSPITAL.CLINIC_PAYMENT_MASTER p join HOSPITAL.CLINIC_MASTER c on c.clinic_id = p.clinic_id where " +
                "p.dr_id = '" + dr_id + "' and c.branch_id = '" + branch_id + "' and to_date(p.bill_date, 'dd-mm-yyyy') = to_date((select max(to_date" +
                "(p1.bill_date)) from HOSPITAL.CLINIC_PAYMENT_MASTER p1 join HOSPITAL.CLINIC_MASTER c1 on c1.clinic_id = p1.clinic_id where p1.dr_id = " +
                "'" + dr_id + "' and c1.branch_id = '" + branch_id + "'), 'dd-mm-yyyy') ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_ActualEmployeenorms(string branch_id, string area_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select z.department, count(z.emp_name) norms from (select e.employee_code, m.emp_name, dm.department from " +
                "mactech.DAILY_ATTEND d join employee_dept_dtl e on e.employee_code = d.emp_code join hospital.employee_master m on m.emp_code = " +
                "e.employee_code join employee_dept_mst dm on dm.department_id = e.department_id join mactech.time_tab t on m.shift_id = t.shift_id join " +
                "norms_staffs_sitting s on s.emp_code = e.employee_code where to_date(d.curr_date, 'dd-mm-yyyy') = to_date(sysdate, 'dd-mm-yyyy') and " +
                "d.m_time >= '0' and (TO_CHAR(SYSDATE, 'HH24:MI') between t.in_time and t.out_time) and e.branch_id = '" + branch_id + "' and s.area_id = " +
                "'" + area_id + "' and dm.department_id in (11, 12, 2, 1) order by dm.department) z group by z.department ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Norms_Employees(string branch_id, string dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select m.emp_code, m.emp_name, dm.department, nvl(a.area_id,0) area_id, s.area_name from " +
                "hospital.employee_master m join employee_dept_dtl d on d.employee_code = m.emp_code join employee_dept_mst dm on dm.department_id = " +
                "d.department_id left outer join norms_staffs_sitting a on a.emp_code = d.employee_code left outer join norms_sitting_area s on s.area_id " +
                "= a.area_id where d.branch_id = '" + branch_id + "' and d.department_id = '" + dept_id + "' order by m.emp_name ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Norms_Employees_update(string emp_code)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from norms_staffs_sitting where emp_code = '" + emp_code + "' ");
            return DS;
        }



































        [WebMethod]
        public int Insert_Usage(string username)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into module_usage_log values ('Doctors on Duty', '" + username + "', sysdate)");
            return id;
        }


        [WebMethod]
        public int updateUsage(string path, string userid)
        {
            string query; int res;
            query = "insert into CRF_USAGE values (SEQ_CRFUSAGE.nextval, 0, 1, " + userid + ", '" + path + "', sysdate)";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        















    }
}

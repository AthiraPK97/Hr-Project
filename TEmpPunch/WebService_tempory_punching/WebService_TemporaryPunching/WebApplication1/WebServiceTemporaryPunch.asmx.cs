using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OracleClient;
using System.Data;
using WebService;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebServiceTemporaryPunch
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTemporaryPunch : System.Web.Services.WebService
    {

        OracleHelper ObjOrclHelper = new OracleHelper();
        DataTable dt = new DataTable();

        [WebMethod]
        public DataSet login(string name, string password)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from login_users where username='" + name + "' and password='" + password + "' and username like '123%'  ");
            return DS;
        }

        [WebMethod]
        public DataSet getPunchDetails(string name, string date,string endDate)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("SELECT  punchin_time, punchout_time,STATUS  FROM Temporary_punching WHERE username = '" + name + "' AND TO_DATE(punchin_time, 'DD-MON-YYYY')" +
                " between TO_DATE('" + endDate + "', 'DD-MON-YYYY') and  TO_CHAR(TO_DATE('" + date + "', 'DD-MM-YYYY'), 'DD-MON-YYYY')  ");

            return DS;
        }

        [WebMethod]
        public DataSet getPunchDetailsForDate(string name, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("SELECT  punchin_time, punchout_time,STATUS  FROM Temporary_punching WHERE username = '" + name + "' AND TO_CHAR(TO_DATE(punchin_time, 'DD-MM-YYYY'), 'DD-Mon-YYYY') = '" + date + "'"  );

            return DS;
        }
        [WebMethod]
        public DataSet getPunchOutDetailsForDate(string name, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("SELECT  punchin_time, punchout_time,STATUS  FROM Temporary_punching WHERE username = '" + name + "' AND TO_CHAR(TO_DATE(punchout_time, 'DD-MM-YYYY'), 'DD-Mon-YYYY') = '" + date + "'");

            return DS;
        }


        [WebMethod]
        public int Add_details(string username, byte[] punchinImage, string Status, DateTime dateTime)
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
           //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                // Properly use parameter placeholders in the query
                string query = "INSERT INTO Temporary_punching (id,username, punchin_time, punchinimage,Status) VALUES (TEMPORARY_PUNCHING_SEQ.nextval,:username, :dateTime, :punchinimage,:Status)";

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    // Add parameters without the colon (:) prefix
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("dateTime", dateTime);
                    cmd.Parameters.AddWithValue("punchinimage", punchinImage);
                    cmd.Parameters.AddWithValue("Status", Status);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 1;
            return id;
        }

        [WebMethod]
        public int Add_Punchoutdetails(string username, byte[] image, DateTime dateTime, string date,string Status )
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
           // string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                // Properly use parameter placeholders in the query
                string query = "UPDATE Temporary_punching SET punchout_time = :punchout_time,punchoutimage = :PUNCHOUTIMAGE,Status=:Status WHERE username = :username AND TO_CHAR(TO_DATE(punchin_time, 'DD-MM-YYYY'), 'DD-Mon-YYYY') = :Todaydate";

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    // Add parameters without the colon (:) prefix
                    cmd.Parameters.AddWithValue("Todaydate", date);
                    cmd.Parameters.AddWithValue("punchout_time", dateTime);
                    cmd.Parameters.AddWithValue("PUNCHOUTIMAGE", image);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("Status", Status);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 1;
            return id;
        }

        [WebMethod]
        public int  InsertPunchout_details(string username, byte[] PUNCHOUTIMAGE, string Status, DateTime dateTime)
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                // Properly use parameter placeholders in the query
                string query = "INSERT INTO Temporary_punching (id,username, punchout_time, punchoutimage,Status) VALUES (TEMPORARY_PUNCHING_SEQ.nextval,:username, :punchout_time, :PUNCHOUTIMAGE,:Status)";

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    // Add parameters without the colon (:) prefix
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("punchout_time", dateTime);
                    cmd.Parameters.AddWithValue("PUNCHOUTIMAGE", PUNCHOUTIMAGE);
                    cmd.Parameters.AddWithValue("Status", Status);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 1;
            return id;
        }

        [WebMethod]
        public DataSet GetShiftDetails(string name)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct l.userid,l.username,l.designation,l.log_user,t.* from login_users l join TEMPORARY_STAFF_SHIFTS t on t.empcode=l.username where username='"+name+"' ");
            return DS;
        }

        [WebMethod]
        public DataSet GetShiftTimings(string shiftid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from shiftalert_shifts s where s.shift_id='"+shiftid+"' ");
            return DS;
        }


        [WebMethod]
        public int UpdateCoolOffTime(string empcode, string cool_of_time)
        {
            string query; int res;
                query = "update temporary_staff_shifts set cool_of_time='" + cool_of_time + "'  where empcode=" + empcode;
                res = ObjOrclHelper.ExecuteNonQuery(query);
                return res;
        }

        [WebMethod]
        public int UpdateEarlyGoing(string empcode, string early_Going)
        {
            string query; int res;
            query = "update temporary_staff_shifts set early_Going='" + early_Going + "'  where empcode=" + empcode;
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public int UpdatePreviousStatus(string empcode, string absent)
        {
            string query; int res;
            query = "update Temporary_punching set status='" + absent + "'  where username='" + empcode+ "' and TO_DATE(punchin_time, 'DD-MM-YYYY') = TRUNC(SYSDATE - 1)";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public int InsertPreviousStatus(string empcode, string absent)
        {
            string query; int res;
            query = "INSERT INTO Temporary_punching(id, username, punchin_time, Status) VALUES(TEMPORARY_PUNCHING_SEQ.nextval, '"+empcode+ "',TRUNC(SYSDATE - 1),'"+absent+"' )";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet GetShift(string Username)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from shiftalert_shifts s join TEMPORARY_STAFF_SHIFTS t on t.shift_id=s.shift_id where t.empcode='" + Username + "' ");
            return DS;
        }

    }
}

    


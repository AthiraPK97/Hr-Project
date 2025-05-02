using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public partial class TemporyPunching : System.Web.UI.Page
    {
        ServiceReference2.WebServiceTemporaryPunchSoapClient objservice = new ServiceReference2.WebServiceTemporaryPunchSoapClient();
        public int intCoolOfTime = 0;
        public int intEarlygoing = 0;
        public string coolOfTime = "0";
        public string strEarlygoing = "0";
        public int id1 = 0;
        private DateTime StaffInTimes;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                if (eventTarget == "ValidatePostBack")
                {
                    txt_password.Attributes["value"] = passwordHidden.Value;
                    //Session["password"]= passwordHidden.Value;
                    // Call your C# method here
                    UsernameChanged();
                }
                else
                {

                    txt_password.Attributes["value"] = string.Empty;
                }
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = objservice.login(txt_username.Text, txt_password.Text).Tables[0];

        //    if (dt1.Rows.Count > 0)
        //    {
        //        login_user.Text = dt1.Rows[0]["log_user"].ToString();
        //        string username = this.txt_username.Text;
        //        string password = this.txt_password.Text;
        //        string login_users = this.login_user.Text;
        //        string videoDataUrl = this.videoData.Value;
        //        string formattedCoolOff = "";
        //        byte[] imageBytes = null;
        //        DateTime dtNowDate = DateTime.Now;

        //        if (!string.IsNullOrEmpty(videoDataUrl))
        //        {
        //            string base64String = videoData.Value;
        //            // Remove the base64 prefix (e.g., "data:image/png;base64,")
        //            string base64Data = base64String.Substring(base64String.IndexOf(',') + 1);
        //            // Convert base64 string to byte array
        //            imageBytes = Convert.FromBase64String(base64Data);
        //            // Save the byte array to your database
        //        }

        //        // Retrieve punch-in details for the employee
        //        DataTable dt = new DataTable();
        //        DataTable dt2 = new DataTable();
        //        string formattedDate = dtNowDate.ToString("dd-MMM-yyyy").ToUpper();
        //        DateTime startDate = DateTime.ParseExact(formattedDate, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //        DateTime endDate = startDate.AddDays(1);
        //        dt = objservice.getPunchDetails(txt_username.Text, startDate.ToString(), endDate.ToString()).Tables[0];

        //        // Check if there are any records for today's punch-in or punch-out
        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            dt2 = objservice.GetShiftDetails(username).Tables[0];
        //            if (dt2.Rows.Count > 0)
        //            {
        //                string strShift;

        //                string shift_date = dt2.Rows[0]["date_shift_change"].ToString();
        //                string change_shift_date = dt2.Rows[0]["change_shift"].ToString();
        //                string normal_shift = dt2.Rows[0]["shift_id"].ToString();
        //                int strCoolOfTime = 0; // Default value

        //                if (dt2.Rows[0]["cool_of_time"] != DBNull.Value && !string.IsNullOrEmpty(dt2.Rows[0]["cool_of_time"].ToString()))
        //                {
        //                    TimeSpan coolOffTime = TimeSpan.Parse(dt2.Rows[0]["cool_of_time"].ToString());
        //                    strCoolOfTime = (int)coolOffTime.TotalMinutes;
        //                }
        //                DateTime systemDate = DateTime.Now;
        //                if (!string.IsNullOrEmpty(shift_date) && DateTime.TryParse(shift_date, out DateTime inputDate))
        //                {
        //                    if (inputDate.Date == systemDate.Date)
        //                    {
        //                        strShift = dt2.Rows[0]["shift_for_date"].ToString();
        //                    }
        //                    else if (change_shift_date != null && change_shift_date != "")
        //                    {
        //                        strShift = normal_shift;
        //                    }
        //                    else
        //                    {
        //                        strShift = normal_shift;
        //                    }
        //                }
        //                else if (!string.IsNullOrEmpty(change_shift_date))
        //                {
        //                    // If shift_date is missing, check if change_shift_date exists
        //                    strShift = normal_shift;
        //                }
        //                else
        //                {
        //                    // If both shift_date and change_shift_date are missing, use normal_shift
        //                    strShift = normal_shift;
        //                }
        //                DataTable dtShift = objservice.GetShiftDetails(username).Tables[0];
        //                DataTable dtShiftTime = objservice.GetShiftTimings(strShift).Tables[0];
        //                string intime = dtShiftTime.Rows[0]["IN_TIME"].ToString();

        //                DateTime shiftStartTime;
        //                if (DateTime.TryParse(intime, out shiftStartTime))
        //                {
        //                    // Use the current system time as the punch-in time
        //                    DateTime employeePunchInTime = DateTime.Now;
        //                    if (employeePunchInTime.Day == 1)
        //                    {
        //                        // Reset cool-off time at the month's end
        //                        intCoolOfTime = 0;
        //                    }

        //                    else
        //                    {
        //                        intCoolOfTime = strCoolOfTime;
        //                    }

        //                    // Check if the punch-in time is later than the scheduled start time
        //                    if (employeePunchInTime > shiftStartTime)
        //                    {

        //                        // Calculate the number of minutes taken beyond the scheduled intime
        //                        int minutesLate = (int)(employeePunchInTime - shiftStartTime).TotalMinutes;
        //                        intCoolOfTime = minutesLate + strCoolOfTime;
        //                        TimeSpan totalCoolOffTime = TimeSpan.FromMinutes(intCoolOfTime);
        //                        DateTime coolOffDate = new DateTime(1, 1, 1).Add(totalCoolOffTime);
        //                        formattedCoolOff = coolOffDate.ToString("HH:mm");
        //                        id1 = objservice.Add_details(username, imageBytes, dtNowDate);

        //                        if (id1 == 1)
        //                        {
        //                            objservice.UpdateCoolOffTime(username, formattedCoolOff);
        //                            if (intCoolOfTime > 15)
        //                            {
        //                                takeUpdatedCoolOftimeAndEarlygoing(username);
        //                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_user.Text + " Your Punch -in Time is: " + dtNowDate.ToString("g") + "  and cool of time is over Total Cool Of Time used " + coolOfTime + " hrs');", true);
        //                                txt_username.Text = string.Empty;
        //                                txt_password.Text = string.Empty;
        //                                login_user.Text = string.Empty;
        //                                txt_shift.Text = string.Empty;
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                takeUpdatedCoolOftimeAndEarlygoing(username);
        //                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_user.Text + " Punch-in Time is: " + dtNowDate.ToString("g") + " and Monthly Cool Of Time used " + coolOfTime + " Hrs');", true);
        //                                txt_username.Text = string.Empty;
        //                                txt_password.Text = string.Empty;
        //                                login_user.Text = string.Empty;
        //                                txt_shift.Text = string.Empty;
        //                                return;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            Response.Write("Something went wrong...");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        id1 = objservice.Add_details(username, imageBytes, dtNowDate);

        //                    }


        //                }
        //                else
        //                {
        //                    // Handle invalid shift start time format
        //                }

        //            }
        //            else
        //            {
        //                id1 = objservice.Add_details(username, imageBytes, dtNowDate);
        //            }



        //            // No punch-in record exists for today, so this is a first-time punch-in

        //            if (id1 == 1)
        //            {
        //                string name = dt1.Rows[0]["log_user"].ToString();
        //                takeUpdatedCoolOftimeAndEarlygoing(username);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + name + ", Punch-in Time is: " + dtNowDate.ToString("g") + ", and Used cool Of Time is: " + coolOfTime + " Hrs');", true);
        //                txt_username.Text = string.Empty;
        //                txt_password.Text = string.Empty;
        //                login_user.Text = string.Empty;
        //                txt_shift.Text = string.Empty;
        //                return;

        //            }
        //            else
        //            {
        //                Response.Write("Something went wrong...");
        //            }
        //        }
        //        else
        //        {

        //            bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());

        //            bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
        //            DateTime StaffInTimes;
        //            DateTime shiftStartTimes = DateTime.MinValue;

        //            if (DateTime.TryParse(dt.Rows[0]["punchin_time"].ToString(), out StaffInTimes))
        //            {
        //                shiftStartTimes = StaffInTimes.AddHours(-8);
        //            }
        //            // Start of valid shift window (7 hours back)
        //            DateTime shiftEndTimes = dtNowDate.AddDays(1);
        //            // Convert punch-in and punch-out times from DataTable (if they exist)
        //            DateTime? punchInTime = isPunchInNull ? (DateTime?)null : Convert.ToDateTime(dt.Rows[0]["punchin_time"]);
        //            DateTime? punchOutTime = isPunchOutNull ? (DateTime?)null : Convert.ToDateTime(dt.Rows[0]["punchout_time"]);

        //            // Check if today’s date is the same as the punch-in or punch-out date
        //            bool isTodayPunchIn = punchInTime.HasValue && punchInTime.Value.Date == dtNowDate.Date;
        //            bool isTodayPunchOut = punchOutTime.HasValue && punchOutTime.Value.Date == dtNowDate.Date;
        //            bool containsAM = dtNowDate.ToString().Contains("AM");
        //            if (isPunchInNull && isPunchOutNull && isTodayPunchIn /*|| punchInTime.Value >= shiftStartTimes && punchInTime.Value <= shiftStartTimes*/)
        //            {
        //                if (dt == null || dt.Rows.Count == 0)
        //                {
        //                    dt2 = objservice.GetShiftDetails(username).Tables[0];
        //                    if (dt2.Rows.Count > 0)
        //                    {
        //                        string strShift;
        //                        string shift_date = dt2.Rows[0]["date_shift_change"].ToString();
        //                        string change_shift_date = dt2.Rows[0]["change_shift"].ToString();
        //                        string normal_shift = dt2.Rows[0]["shift_id"].ToString();
        //                        int strCoolOfTime = 0; // Default value

        //                        if (dt2.Rows[0]["cool_of_time"] != DBNull.Value && !string.IsNullOrEmpty(dt2.Rows[0]["cool_of_time"].ToString()))
        //                        {

        //                            TimeSpan coolOffTime = TimeSpan.Parse(dt2.Rows[0]["cool_of_time"].ToString());
        //                            strCoolOfTime = (int)coolOffTime.TotalMinutes;
        //                        }
        //                        DateTime systemDate = DateTime.Now;
        //                        if (!string.IsNullOrEmpty(shift_date) && DateTime.TryParse(shift_date, out DateTime inputDate))
        //                        {
        //                            if (inputDate.Date <= systemDate.Date)
        //                            {
        //                                strShift = dt2.Rows[0]["shift_for_date"].ToString();
        //                            }
        //                            else if (change_shift_date != null && change_shift_date != "")
        //                            {
        //                                strShift = normal_shift;
        //                            }
        //                            else
        //                            {
        //                                strShift = normal_shift;
        //                            }
        //                        }
        //                        else if (!string.IsNullOrEmpty(change_shift_date))
        //                        {
        //                            // If shift_date is missing, check if change_shift_date exists
        //                            strShift = normal_shift;
        //                        }
        //                        else
        //                        {
        //                            // If both shift_date and change_shift_date are missing, use normal_shift
        //                            strShift = normal_shift;
        //                        }

        //                        DataTable dtShiftTime = objservice.GetShiftTimings(strShift).Tables[0];
        //                        string intime = dtShiftTime.Rows[0]["IN_TIME"].ToString();
        //                        DateTime shiftStartTime;
        //                        if (DateTime.TryParse(intime, out shiftStartTime))
        //                        {
        //                            // Use the current system time as the punch-in time
        //                            DateTime employeePunchInTime = DateTime.Now;
        //                            if (employeePunchInTime.Day == 1)
        //                            {
        //                                // Reset cool-off time at the month's end
        //                                intCoolOfTime = 0;
        //                            }

        //                            else
        //                            {
        //                                intCoolOfTime = strCoolOfTime;
        //                            }
        //                            if (employeePunchInTime > shiftStartTime)
        //                            {
        //                                // Calculate the number of minutes taken beyond the scheduled intime
        //                                int minutesLate = (int)(employeePunchInTime - shiftStartTime).TotalMinutes;
        //                                intCoolOfTime = minutesLate + strCoolOfTime;
        //                                TimeSpan totalCoolOffTime = TimeSpan.FromMinutes(intCoolOfTime);
        //                                DateTime coolOffDate = new DateTime(1, 1, 1).Add(totalCoolOffTime);
        //                                formattedCoolOff = coolOffDate.ToString("HH:mm");
        //                                id1 = objservice.Add_details(username, imageBytes, dtNowDate);

        //                                if (id1 == 1)
        //                                {
        //                                    objservice.UpdateCoolOffTime(username, formattedCoolOff);
        //                                    if (intCoolOfTime > 15)
        //                                    {
        //                                        takeUpdatedCoolOftimeAndEarlygoing(username);
        //                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_user.Text + "Your cool of time is over Total Cool Of Time used " + coolOfTime + " Hrs');", true);
        //                                        txt_username.Text = string.Empty;
        //                                        txt_password.Text = string.Empty;
        //                                        login_user.Text = string.Empty;
        //                                        txt_shift.Text = string.Empty;
        //                                        return;
        //                                    }
        //                                    else
        //                                    {
        //                                        takeUpdatedCoolOftimeAndEarlygoing(username);
        //                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_user.Text + "Monthly Cool Of Time used " + coolOfTime + " Hrs');", true);
        //                                        txt_username.Text = string.Empty;
        //                                        txt_password.Text = string.Empty;
        //                                        login_user.Text = string.Empty;
        //                                        txt_shift.Text = string.Empty;
        //                                        return;

        //                                    }

        //                                }
        //                                else
        //                                {
        //                                    Response.Write("Something went wrong...");
        //                                }
        //                            }
        //                            else
        //                            {
        //                                id1 = objservice.Add_details(username, imageBytes, dtNowDate);

        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        id1 = objservice.Add_details(username, imageBytes, dtNowDate);
        //                    }
        //                }
        //                // Punch-in logic (in case no punch-in or punch-out exists for today)
        //                //int id = objservice.Add_details(username, imageBytes, dtNowDate);
        //                if (id1 == 1)
        //                {
        //                    string name = dt1.Rows[0]["log_user"].ToString();
        //                    txt_username.Text = string.Empty;
        //                    txt_password.Attributes["value"] = "";
        //                    login_user.Text = string.Empty;
        //                    txt_shift.Text = string.Empty;
        //                    int strCoolOfTime = 0; // Default value
        //                    DataTable dt4 = objservice.GetShiftDetails(username).Tables[0];
        //                    if (dt4.Rows.Count > 0)
        //                    {
        //                        if (dt4.Rows[0]["cool_of_time"] != DBNull.Value && !string.IsNullOrEmpty(dt4.Rows[0]["cool_of_time"].ToString()))
        //                        {
        //                            TimeSpan coolOffTime = TimeSpan.Parse(dt2.Rows[0]["cool_of_time"].ToString());
        //                            strCoolOfTime = (int)coolOffTime.TotalMinutes;
        //                        }
        //                    }
        //                    takeUpdatedCoolOftimeAndEarlygoing(username);
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + name + ", Punch-in Time is: " + dtNowDate.ToString("g") + " , and Used cool Of Time is: " + coolOfTime + " Hrs'); ');", true);
        //                    txt_username.Text = string.Empty;
        //                    txt_password.Text = string.Empty;
        //                    login_user.Text = string.Empty;
        //                    txt_shift.Text = string.Empty;
        //                    return;

        //                }

        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured Try again....');", true);
        //                }
        //            }


        //            else if (!isPunchInNull && isPunchOutNull || punchInTime.Value >= shiftStartTimes && punchInTime.Value <= shiftEndTimes)
        //            {
        //                int id = 0;
        //                TimeSpan totalEarlyGoingTime;
        //                if (containsAM || punchInTime.Value >= shiftStartTimes && punchInTime.Value <= shiftEndTimes)
        //                {
        //                    string punchtime = dt.Rows[0]["punchin_time"].ToString();
        //                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You are already punch_in at':" + punchtime + " );", true);
        //                }
        //                else
        //                {
        //                    dt2 = objservice.GetShiftDetails(username).Tables[0];
        //                    if (dt2.Rows.Count > 0)
        //                    {
        //                        string strShift;
        //                        string formattedEarlygoing = "";
        //                        string shift_date = dt2.Rows[0]["date_shift_change"].ToString();
        //                        string change_shift_date = dt2.Rows[0]["change_shift"].ToString();
        //                        string normal_shift = dt2.Rows[0]["shift_id"].ToString();
        //                        int strEarlyGoing = 0; // Default value

        //                        if (dt2.Rows[0]["early_going"] != DBNull.Value && !string.IsNullOrEmpty(dt2.Rows[0]["early_going"].ToString()))
        //                        {
        //                            TimeSpan tiEarlyGoing = TimeSpan.Parse(dt2.Rows[0]["early_going"].ToString());
        //                            strEarlyGoing = (int)tiEarlyGoing.TotalMinutes;
        //                        }
        //                        DateTime systemDate = DateTime.Now;
        //                        if (!string.IsNullOrEmpty(shift_date) && DateTime.TryParse(shift_date, out DateTime inputDate))
        //                        {
        //                            if (inputDate.Date == systemDate.Date)
        //                            {
        //                                strShift = dt2.Rows[0]["shift_for_date"].ToString();
        //                            }
        //                            else if (change_shift_date != null && change_shift_date != "")
        //                            {
        //                                strShift = normal_shift;
        //                            }
        //                            else
        //                            {
        //                                strShift = normal_shift;
        //                            }
        //                        }
        //                        else if (!string.IsNullOrEmpty(change_shift_date))
        //                        {
        //                            // If shift_date is missing, check if change_shift_date exists
        //                            strShift = normal_shift;
        //                        }
        //                        else
        //                        {
        //                            // If both shift_date and change_shift_date are missing, use normal_shift
        //                            strShift = normal_shift;
        //                        }
        //                        DataTable dtShiftTime = objservice.GetShiftTimings(strShift).Tables[0];
        //                        string Outtime = dtShiftTime.Rows[0]["OUT_TIME"].ToString();
        //                        // int intEarlyGoing = 0;
        //                        DateTime shiftEndTime;
        //                        if (DateTime.TryParse(Outtime, out shiftEndTime))
        //                        {
        //                            // Use the current system time as the punch-in time
        //                            DateTime employeePunchOutTime = DateTime.Now;
        //                            if (employeePunchOutTime.Day == 1)
        //                            {
        //                                // Reset cool-off time at the month's end
        //                                intEarlygoing = 0;
        //                            }

        //                            else
        //                            {
        //                                intEarlygoing = strEarlyGoing;
        //                            }
        //                            if (employeePunchOutTime < shiftEndTime)
        //                            {
        //                                takeUpdatedCoolOftimeAndEarlygoing(username);
        //                                if (intEarlygoing > 45)

        //                                {
        //                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' Your Early Going is Over Total Early going Time used " + strEarlygoing + " Hrs You can Only Punchout After" + shiftEndTime + " ');", true);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    // Calculate the number of minutes taken beyond the scheduled intime
        //                                    int minutesEarly = (int)(shiftEndTime - employeePunchOutTime).TotalMinutes;
        //                                    intEarlygoing = minutesEarly + strEarlyGoing;
        //                                    totalEarlyGoingTime = TimeSpan.FromMinutes(intEarlygoing);
        //                                    DateTime EAarlyDate = new DateTime(1, 1, 1).Add(totalEarlyGoingTime);
        //                                    formattedEarlygoing = EAarlyDate.ToString("HH:mm");

        //                                    id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, formattedDate);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, formattedDate);
        //                            }
        //                            int totalEarlyGoing = 0;
        //                            if (id1 == 1)
        //                            {

        //                                objservice.UpdateEarlyGoing(username, formattedEarlygoing);


        //                                if (intEarlygoing > 45)
        //                                {

        //                                    string name = dt1.Rows[0]["log_user"].ToString();

        //                                    takeUpdatedCoolOftimeAndEarlygoing(name);
        //                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_user.Text + "Punch -out Time is: " + dtNowDate.ToString("g") + " Your Early Going is Over Total Early going Time used " + strEarlygoing + " Hrs');", true);
        //                                    txt_username.Text = string.Empty;
        //                                    txt_password.Text = string.Empty;
        //                                    login_user.Text = string.Empty;
        //                                    txt_shift.Text = string.Empty;
        //                                    return;
        //                                }

        //                                else
        //                                {


        //                                    takeUpdatedCoolOftimeAndEarlygoing(username);
        //                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_user.Text + " Punch -out Time is: " + dtNowDate.ToString("g") + " Monthly Early Going Time used " + strEarlygoing + " Hrs');", true);
        //                                    txt_username.Text = string.Empty;
        //                                    txt_password.Text = string.Empty;
        //                                    login_user.Text = string.Empty;
        //                                    txt_shift.Text = string.Empty;
        //                                    return;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went Wrong.........');", true);
        //                            }


        //                        }

        //                    }
        //                    else
        //                    {
        //                        id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, formattedDate);
        //                    }
        //                }
        //                if (id == 1)
        //                {

        //                    string name = dt1.Rows[0]["log_user"].ToString();
        //                    txt_username.Text = string.Empty;
        //                    txt_password.Text = string.Empty;
        //                    login_user.Text = string.Empty;
        //                    txt_shift.Text = string.Empty;
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + name + ", Punch-out Time is: " + dtNowDate.ToString("g") + " Monthly Early Going Time used " + strEarlygoing + " Hrs ')", true);
        //                    return;

        //                }
        //                else
        //                {

        //                    string punchtime = dt.Rows[0]["punchin_time"].ToString();
        //                    txt_username.Text = string.Empty;
        //                    txt_password.Text = string.Empty;
        //                    login_user.Text = string.Empty;
        //                    txt_shift.Text = string.Empty;
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You are already punch_in at:" + punchtime + "' );", true);
        //                }

        //            }
        //            else
        //            {
        //                txt_username.Text = string.Empty;
        //                txt_password.Text = string.Empty;
        //                login_user.Text = string.Empty;
        //                txt_shift.Text = string.Empty;
        //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You are already punched....');", true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User Name or Password....');", true);

        //    }

        //    txt_username.Text = string.Empty;
        //    txt_password.Text = string.Empty;
        //    login_user.Text = string.Empty;
        //    txt_shift.Text = string.Empty;
        //}

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txt_username.Text = string.Empty;
            txt_password.Text = string.Empty;
            login_user.Text = string.Empty;
            txt_shift.Text = string.Empty;
        }


        //To display shift and Employee name on login_page
        private void UsernameChanged()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = objservice.login(txt_username.Text, txt_password.Text).Tables[0];

            if (dt1.Rows.Count > 0)
            {
                txt_password.Text = dt1.Rows[0]["password"].ToString();
                login_user.Text = dt1.Rows[0]["log_user"].ToString();
                dt2 = objservice.GetShiftDetails(txt_username.Text).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    string shift_date = dt2.Rows[0]["date_shift_change"].ToString();
                    string change_shift_date = dt2.Rows[0]["change_shift"].ToString();
                    string normal_shift = dt2.Rows[0]["normal_shift"].ToString();
                    DateTime systemDate = DateTime.Now;
                    if (!string.IsNullOrEmpty(shift_date) && DateTime.TryParse(shift_date, out DateTime inputDate))
                    {
                        if (inputDate.Date == systemDate.Date)
                        {
                            txt_shift.Text = dt2.Rows[0]["shift_for_date"].ToString();
                        }
                        else if (change_shift_date != null && change_shift_date != "")
                        {
                            txt_shift.Text = change_shift_date;
                        }
                        else
                        {
                            txt_shift.Text = normal_shift;
                        }
                    }
                    else if (!string.IsNullOrEmpty(change_shift_date))
                    {
                        // If shift_date is missing, check if change_shift_date exists
                        txt_shift.Text = change_shift_date;
                    }
                    else
                    {
                        // If both shift_date and change_shift_date are missing, use normal_shift
                        txt_shift.Text = normal_shift;
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "SetFocus", "setFocusOnSubmit();", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User Name or Password....');", true);

            }

        }


        //to display cool off time and early going
        private void takeUpdatedCoolOftimeAndEarlygoing(string username)
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.GetShiftDetails(username).Tables[0];
            if (dt2.Rows.Count > 0)
            {

                if (dt2.Rows[0]["cool_of_time"] != DBNull.Value && !string.IsNullOrEmpty(dt2.Rows[0]["cool_of_time"].ToString()))
                {
                    coolOfTime = dt2.Rows[0]["cool_of_time"].ToString();
                }
                else
                {
                    intCoolOfTime = 0;
                }
                if (dt2.Rows[0]["early_going"] != DBNull.Value && !string.IsNullOrEmpty(dt2.Rows[0]["early_going"].ToString()))
                {
                    TimeSpan tiEarlyGoing = TimeSpan.Parse(dt2.Rows[0]["early_going"].ToString());
                    intEarlygoing = (int)tiEarlyGoing.TotalMinutes;
                    strEarlygoing = dt2.Rows[0]["early_going"].ToString();
                }
                else
                {
                    intEarlygoing = 0;
                }

            }
        }


        //protected void btnSubmit_ClickNew(object sender, EventArgs e)
        //{

        //    DataTable dt1 = new DataTable();

        //    DataTable dt = new DataTable();
        //    DataTable dt2 = new DataTable();
        //    bool isPunchInNull1 = false;
        //    bool isPunchOutNull1 = false;
        //    int id = 0;
        //    dt1 = objservice.login(txt_username.Text, txt_password.Text).Tables[0];

        //    if (dt1.Rows.Count > 0)
        //    {
        //        login_user.Text = dt1.Rows[0]["log_user"].ToString();
        //        string username = this.txt_username.Text;
        //        string password = this.txt_password.Text;
        //        string login_users = this.login_user.Text;
        //        string videoDataUrl = this.videoData.Value;
        //        byte[] imageBytes = null;
        //        DateTime dtNowDate = DateTime.Now;

        //        if (!string.IsNullOrEmpty(videoDataUrl))
        //        {
        //            string base64String = videoData.Value;
        //            string base64Data = base64String.Substring(base64String.IndexOf(',') + 1);
        //            imageBytes = Convert.FromBase64String(base64Data);

        //        }

        //        TimeSpan shiftStartTimes = TimeSpan.Zero;
        //        string formattedDate = dtNowDate.ToString("dd-MMM-yyyy").ToUpper();
        //        DateTime startDate = DateTime.ParseExact(formattedDate, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //        DateTime endDate = startDate.AddDays(-1);
        //        DateTime employeePunchInTime = DateTime.Now;
        //        bool containsAM = dtNowDate.ToString("tt") == "AM";
        //        bool containsPM = dtNowDate.ToString("tt") == "PM";
        //        if (containsAM)
        //        {

        //            dt = objservice.getPunchDetailsForDate(txt_username.Text, endDate.ToString("dd-MMM-yyyy")).Tables[0];

        //            if (dt.Rows.Count > 0)
        //            {

        //                isPunchInNull1 = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
        //                isPunchOutNull1 = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
        //                if (isPunchInNull1 && isPunchOutNull1)
        //                {
        //                    id1 = objservice.InsertPreviousStatus(username, "Absent");
        //                    id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                }
        //                else if (isPunchOutNull1 && !isPunchInNull1)
        //                {
        //                    if (DateTime.TryParse(dt.Rows[0]["punchin_time"].ToString(), out StaffInTimes))
        //                    {
        //                        shiftStartTimes = employeePunchInTime - StaffInTimes;
        //                    }
        //                    if (dt.Rows[0]["STATUS"].ToString() == "Non Marking Evening" && shiftStartTimes.TotalHours > 9 && shiftStartTimes.TotalHours < 22)
        //                    {
        //                        string punchinTime = dt.Rows[0]["punchin_time"].ToString();
        //                        DateTime punchinDate = DateTime.ParseExact(punchinTime, "dd-MMM-yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //                        string dateOnly = punchinDate.ToString("dd-MMM-yyyy");
        //                        id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, dateOnly, "--");
        //                        if (id1 > 0)
        //                        {
        //                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + username + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
        //                            Clear();
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);
        //                        }
        //                    }
        //                    else if (dt.Rows[0]["STATUS"].ToString() == "Non Marking Evening" && shiftStartTimes.TotalHours > 22)
        //                    {

        //                        id = objservice.UpdatePreviousStatus(username, "Non Marking Evening");
        //                        id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + username + " already Punched, Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
        //                        Clear();
        //                        return;
        //                    }
        //                }
        //                else if (!isPunchInNull1 && !isPunchOutNull1)
        //                {
        //                    string punchinTime = dt.Rows[0]["punchin_time"].ToString();
        //                    DateTime punchinDate = DateTime.ParseExact(punchinTime, "dd-MMM-yyyy h:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //                    string dateOnly = punchinDate.ToString("dd-MMM-yyyy");
        //                    if (dateOnly == DateTime.Now.Date.ToString("dd-MMM-yyyy"))
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
        //                        Clear();
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                        if (id1 == 1)
        //                        {
        //                            string name = dt1.Rows[0]["log_user"].ToString();
        //                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + name + ", Punch-in Time is: " + dtNowDate.ToString() + "');", true);
        //                            Clear();
        //                            return;


        //                        }
        //                        else
        //                        {
        //                            Response.Write("Something went wrong...");
        //                        }
        //                    }


        //                }
        //            }
        //            else
        //            {
        //                id = objservice.InsertPreviousStatus(username, "Absent");
        //            }
        //            dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
        //            if (dt.Rows.Count > 0)
        //            {

        //                isPunchInNull1 = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
        //                isPunchOutNull1 = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
        //                if (!isPunchInNull1 && !isPunchOutNull1)
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
        //                    return;

        //                }
        //                else if (isPunchOutNull1 && isPunchInNull1)
        //                {

        //                    id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                }
        //                else if (isPunchOutNull1 && !isPunchInNull1)
        //                {
        //                    if (DateTime.TryParse(dt.Rows[0]["punchin_time"].ToString(), out StaffInTimes))
        //                    {
        //                        shiftStartTimes = employeePunchInTime - StaffInTimes;
        //                    }
        //                    if (shiftStartTimes.TotalHours > 9)
        //                    {
        //                        id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, formattedDate, "--");
        //                        if (id1 > 0)
        //                        {

        //                            dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
        //                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + username + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
        //                            Clear();
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + username + " already Punched, Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
        //                        Clear();
        //                        return;
        //                    }

        //                }
        //            }
        //            else
        //            {

        //                id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //            }


        //            if (id1 == 1)
        //            {
        //                string name = dt1.Rows[0]["log_user"].ToString();

        //                dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
        //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + name + ", Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
        //                Clear();
        //                return;

        //            }
        //            else
        //            {
        //                Response.Write("Something went wrong...");
        //            }


        //        }


        //        if (containsPM)
        //        {
        //            dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
        //            if (dt.Rows.Count > 0)
        //            {
        //                if (DateTime.TryParse(dt.Rows[0]["punchin_time"].ToString(), out StaffInTimes))
        //                {
        //                    shiftStartTimes = employeePunchInTime - StaffInTimes;
        //                }
        //                bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
        //                bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
        //                if (!isPunchInNull && isPunchOutNull && shiftStartTimes.TotalHours < 9)
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + username + " already Punched, Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
        //                    return;
        //                }
        //                else if (!isPunchInNull && isPunchOutNull && shiftStartTimes.TotalHours > 9)
        //                {
        //                    id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, startDate.ToString("dd-MMM-yyyy"), "--");
        //                    if (id1 > 0)
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + username + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
        //                        Clear();
        //                        return;
        //                    }

        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);
        //                    }
        //                }
        //                else if (!isPunchInNull && isPunchOutNull && shiftStartTimes.TotalHours < 9)
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + username + " already Punched, Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
        //                    Clear();
        //                    return;
        //                }
        //                else if (isPunchInNull && isPunchOutNull)
        //                {
        //                    id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
        //                    Clear();
        //                    return;

        //                }
        //            }


        //            else
        //            {
        //                dt = objservice.getPunchDetailsForDate(txt_username.Text, endDate.ToString("dd-MMM-yyyy")).Tables[0];
        //                string status = "";
        //                DateTime punchInTime;
        //                if (dt.Rows.Count > 0)
        //                {
        //                    isPunchInNull1 = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());

        //                    isPunchOutNull1 = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
        //                    if (DateTime.TryParse(dt.Rows[0]["punchin_time"].ToString(), out punchInTime))
        //                    {
        //                        if (punchInTime.Date == DateTime.Now.Date.AddDays(-1))
        //                        {
        //                            status = dt.Rows[0]["status"].ToString();
        //                        }
        //                        shiftStartTimes = employeePunchInTime - punchInTime;
        //                    }

        //                    if (status == "Non Marking Evening" && !isPunchInNull1)
        //                    {

        //                        id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, formattedDate, "--");
        //                    }
        //                    else if (status == "--" && !isPunchInNull1 && !isPunchOutNull1 && shiftStartTimes.TotalHours > 22)
        //                    {

        //                        id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                    }
        //                    else if (status == "--" && !isPunchInNull1 && !isPunchOutNull1 && shiftStartTimes.TotalHours < 22)
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
        //                        Clear();
        //                        return;
        //                    }


        //                }
        //                else
        //                {

        //                    id = objservice.InsertPreviousStatus(username, "Absent");
        //                    id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
        //                }
        //            }
        //            if (id1 == 1)
        //            {
        //                string name = dt1.Rows[0]["log_user"].ToString();
        //                dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];

        //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + name + ", Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
        //                Clear();
        //                return;

        //            }
        //            else
        //            {
        //                Response.Write("Something went wrong...");
        //            }
        //        }

        //    }


        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid UserName Or Password');", true);
        //    }
        //}


        protected void btnSubmit_ClickNew(object sender, EventArgs e)

        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.login(txt_username.Text, txt_password.Text).Tables[0];

            if (dt1.Rows.Count > 0)
            {
                login_user.Text = dt1.Rows[0]["log_user"].ToString();
                string username = this.txt_username.Text;
                string password = this.txt_password.Text;
                string login_users = this.login_user.Text;
                string videoDataUrl = this.videoData.Value;
                string formattedCoolOff = "";
                byte[] imageBytes = null;
                DateTime dtNowDate = DateTime.Now;

            // to store video image
                if (!string.IsNullOrEmpty(videoDataUrl))
                {
                    string base64String = videoData.Value;
                    string base64Data = base64String.Substring(base64String.IndexOf(',') + 1);
                    imageBytes = Convert.FromBase64String(base64Data);
                }
                string shiftTmings = txt_shift.Text;
                string formattedDate = dtNowDate.ToString("dd-MMM-yyyy").ToUpper();
                DateTime startDate = DateTime.ParseExact(formattedDate, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string dateOnly = startDate.ToString("dd-MMM-yyyy");
                DateTime endDate = startDate.AddDays(-1);
                string YesterdaydateOnly = endDate.ToString("dd-MMM-yyyy");
                DataTable dt = objservice.GetShift(txt_username.Text).Tables[0];
            // Check if today’s date is the same as the punch-in or punch-out date

                string dateFormatted = dtNowDate.ToString("dd-MMM-yyyy h:mm:ss tt");
                bool containsAM = dateFormatted.ToString().Contains("AM");
                bool containsPM = dateFormatted.ToString().Contains("PM");
                    if (dt.Rows.Count > 0)    // To select shift
                    {
                        string shift_inTime = dt.Rows[0]["in_time"].ToString();
                        string shift_outTime = dt.Rows[0]["out_time"].ToString();
                        DateTime inTime, outTime;
                    if (DateTime.TryParseExact(shift_inTime, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out inTime))
                    {
                        string inTimePeriod = inTime.ToString("tt");

                    }
                        if (DateTime.TryParseExact(shift_outTime, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out outTime))
                        {
                            string outTimePeriod = outTime.ToString("tt");
                    }
                        if (inTime.ToString("tt") == "AM")    // to check morning shift or evening shift
                        {

                            if (containsAM)     // check punchin time Am or PM
                            {
                                dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
                                    bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
                                    if (!isPunchInNull)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' " + login_users + ",Already Punchin and  Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
                                        Clear();
                                        return;
                                    }
                                    else
                                    {
                                        id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
                                        if (id1 > 0)
                                        {

                                        dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
                                            Clear();
                                            return;
                                        }
                                    }

                                }
                            else
                            {
                                id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
                                if (id1 > 0)
                                {

                                    dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
                                    Clear();
                                    return;
                                }
                            }

                            }
                            else
                            {
                                dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
                                    bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
                                    if (!isPunchInNull && !isPunchOutNull)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
                                        Clear();
                                        return;
                                    }
                                    else
                                    {
                                        id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, dateOnly, "--");
                                        if (id1 > 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
                                            Clear();
                                            return;
                                        }

                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);
                                        }
                                    }
                                }
                            else
                            {

                                dt = objservice.getPunchOutDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
                                    bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
                                    if ( !isPunchOutNull)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
                                        Clear();
                                        return;
                                    }
                                  
                                    else
                                    {
                                        id1 = objservice.InsertPunchout_details(username, imageBytes, "--", dtNowDate);
                                        if (id1 > 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
                                            Clear();
                                            return;
                                        }

                                    }
                                }
                                else
                                {
                                    id1 = objservice.InsertPunchout_details(username, imageBytes, "--", dtNowDate);
                                    if (id1 > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
                                        Clear();
                                        return;
                                    }

                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);
                                    }
                                }
                            }
                            }
                        }
                        // Evening Shift
                    if (inTime.ToString("tt") == "PM")
                    {

                        // Punch Out
                        if (containsAM)
                        {
                            dt = objservice.getPunchDetailsForDate(txt_username.Text, endDate.ToString("dd-MMM-yyyy")).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
                                bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
                                if (!isPunchOutNull && !isPunchInNull)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Punched');", true);
                                    Clear();
                                    return;
                                }
                                else
                                {
                                    id1 = objservice.Add_Punchoutdetails(username, imageBytes, dtNowDate, YesterdaydateOnly, "--");
                                    if (id1 > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + username + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
                                        Clear();
                                        return;
                                    }
                                }
                            }
                            id1 = objservice.InsertPunchout_details(username, imageBytes, "--", dtNowDate);
                            if (id1 > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + username + ", Punch-out Time is: " + dtNowDate.ToString() + " ');", true);
                                Clear();
                                return;
                            }
                        }
                        // Punch In
                        if (containsPM)
                        {


                            dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                bool isPunchInNull = dt.Rows[0]["punchin_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchin_time"].ToString());
                                bool isPunchOutNull = dt.Rows[0]["punchout_time"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[0]["punchout_time"].ToString());
                                if (!isPunchInNull)
                                {
                                    if (!isPunchInNull && !isPunchOutNull)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' " + login_users + ",Already Punched');", true);
                                        Clear();
                                        return;
                                    }
                                    else if (!isPunchInNull && isPunchOutNull)
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' " + login_users + ",Already Punchin and  Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
                                    Clear();
                                    return;
                                }
                                else
                                {
                                    id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
                                    if (id1 > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
                                        Clear();
                                        return;
                                    }
                                }

                            }


                            else
                            {
                                id1 = objservice.Add_details(username, imageBytes, "Non Marking Evening", dtNowDate);
                                if (id1 > 0)
                                {

                                    dt = objservice.getPunchDetailsForDate(txt_username.Text, startDate.ToString("dd-MMM-yyyy")).Tables[0];
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Welcome " + login_users + ", Punch-in Time is: " + dt.Rows[0]["punchin_time"].ToString() + "');", true);
                                    Clear();
                                    return;
                                }

                            }
                        }
                    }


                    }
                
            
            else
            {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You dont have assigned shift');", true);
                }
        }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid UserName Or Password');", true);

            }


        }
       

    }
}

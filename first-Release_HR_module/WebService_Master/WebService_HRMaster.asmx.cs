using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WebService_HRMaster
{
    /// <summary>
    /// Summary description for WebService_HRMaster
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_HRMaster : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        [WebMethod()]
        public DataSet Login(string u_name, string pswd)
        {
            DataSet ds;
            ds = ObjOrclHelper.ExecuteDataSet("select * from Login_users where username ='" + u_name + "' and password='" + pswd + "' and active=1 ");
            return ds;
        }

        [WebMethod()]
        public DataSet Get_Unit_type()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct branch_type from macare_unitmaster");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_branch(string branch_type)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select branch_id,branch_name from MACARE_UNITMASTER where branch_type=" + branch_type);
            return DS;
        }

        [WebMethod()]
        public DataSet Get_HRMaster_AO()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select s.firm_id, s.emp_code, s.emp_name,s.caste, s.religion, case s.identity_id when 8 then 'Aadhar' when 1 then 'Passport' when 7 then 'Nil' when 5 then 'PAN card' when 0 then 'Nil' when 3 then 'Voters Id' when 2 then 'Driving Licence' else 'Others' end Identity_Name, s.idproof_number,/*s.groupid*/case s.groupid when 1 then 'O+ve' " +
           "when 2 then 'O-ve' when 3 then 'A+ve' when 4 then 'A-ve' when 5 then 'B+ve' when 6 then 'B-ve' when 7 then 'AB+ve' when 8 then 'AB-ve' else '' end blood_group, s.spouse_name, s.father_name,s.emp_email," +
           "s.gender, s.birth_date, s.age, s.permanent_Addr, s.present_Addr, s.cont_phone, s.res_phone, s.state, s.shift, s.in_time, s.out_time, to_char(s.join_dt,'dd-MM-yyyy') join_dt, s.exp, s.designation, s.dep_name,s.basic_pay, " +
           "s.post_name, s.year_pass, s.qualification, s.branch_name from (select m.*,(select q.qualification from mactech.EMPLOY_QUALIFICATION_DTL p join mactech.qualification_master q on p.qualification = q.qualification_id where p.emp_code = m.emp_code and to_number(p.year_pass) = to_number(m.year_pass)) qualification " +
           "from(select e.branch_name, a.firm_id, a.emp_code, a.emp_name,k.caste, n.religion, p.identity_id, k.idproof_number,m.groupid, k.spouse_name, k.father_name,k.emp_email, NVL(TO_CHAR(r.gender), 'Female') gender,k.birth_date," +
           "ROUND((SYSDATE - TO_DATE(k.birth_date)) / 365.25) age,k.perm_Add1 permanent_Addr, k.pres_Add1 present_Addr,k.cont_phone,k.res_phone,h.state_name state,f.shift,f.in_time,f.out_time,a.join_dt,trunc(months_between(sysdate, TO_DATE(a.join_dt)) / 12) || '.' || mod(trunc(months_between(sysdate, TO_DATE(a.join_dt))), 12) || '.' ||trunc(sysdate - add_months(TO_DATE(a.join_dt), " +
           "trunc(months_between(sysdate, TO_DATE(a.join_dt))))) exp,b.designation,c.dep_name,a.basic_pay,d.post_name,max(g.year_pass) year_pass from hospital.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id join HOSPITAL.DEPARTMENT_MST c on c.dep_id = a.department_id join mactech.POST_MST d on d.post_id = a.post_id " +
           "join mactech.branch_master e on e.branch_id = a.branch_id left outer join SHIFTALERT_SHIFTS f on f.shift_id = a.shift_id left outer join mactech.EMPLOY_QUALIFICATION_DTL g on g.emp_code = a.emp_code left outer JOIN mactech.qualification_master h on h.qualification_id = g.qualification left outer join mactech.employ_personal_dtl k " +
           "on k.emp_code = a.emp_code left outer join hospital.macare_blood_group m on m.groupid = k.blood_id left outer join mactech.religion_master n on n.religion_id = k.religion_id left outer join mactech.IDENTITY p on p.identity_id = k.Id_proof left outer join hospital.MARITAL_STATUS q on q.statusid = k.marital_status left outer join hospital.EMRM_GENDER_CATEGORY r " +
           "on r.gender_id = k.sex left outer join mactech.state_master h on h.state_id = e.state_id where a.firm_id = 16 and a.branch_id = 0 and a.status_id = 1  and a.emp_code not in ('2000','40002','40004','153045') group by  e.branch_name,a.firm_id,a.emp_code,a.emp_name,f.shift,f.in_time,f.out_time,a.join_dt,b.designation,c.dep_name,a.basic_pay,d.post_name,k.caste,n.religion," +
           "p.identity_id, k.idproof_number,m.groupid,k.spouse_name,k.father_name,k.emp_email,r.gender,k.birth_date,k.perm_Add1,k.pres_Add1,k.cont_phone,k.res_phone,h.state_name)m)s");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_HRMaster_Dashboard()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select s.firm_id, s.emp_code, s.emp_name,s.caste, s.religion,case s.identity_id when 8 then 'Aadhar' when 1 then 'Passport' when 7 then 'Nil' when 5 then 'PAN card' when 0 then 'Nil' when 3 then 'Voters Id' when 2 then 'Driving Licence' else 'Others' end Identity_Name, s.idproof_number,/*s.groupid*/case s.groupid when 1 then 'O+ve' " +
           "when 2 then 'O-ve' when 3 then 'A+ve' when 4 then 'A-ve' when 5 then 'B+ve' when 6 then 'B-ve' when 7 then 'AB+ve' when 8 then 'AB-ve' else '' end blood_group, s.spouse_name, s.father_name,s.emp_email," +
           "s.gender, s.birth_date, s.age, s.permanent_Addr, s.present_Addr, s.cont_phone, s.res_phone, s.state, s.shift, s.in_time, s.out_time, to_char(s.join_dt,'dd-MM-yyyy') join_dt, s.exp, s.designation, s.dep_name,s.basic_pay, " +
           "s.post_name, s.year_pass, s.qualification, s.branch_name from (select n.* from (select m.*,(select q.qualification from mactech.EMPLOY_QUALIFICATION_DTL p join mactech.qualification_master q on p.qualification = q.qualification_id where p.emp_code = m.emp_code and to_number(p.year_pass) = to_number(m.year_pass)) qualification " +
           "from(select e.branch_name, a.firm_id, a.emp_code, a.emp_name,k.caste, n.religion, p.identity_id, k.idproof_number,m.groupid, k.spouse_name, k.father_name,k.emp_email, NVL(TO_CHAR(r.gender), 'Female') gender,k.birth_date,ROUND((SYSDATE - TO_DATE(k.birth_date)) / 365.25) age,k.perm_Add1 permanent_Addr, " +
           "k.pres_Add1 present_Addr,k.cont_phone,k.res_phone,h.state_name state,f.shift,f.in_time,f.out_time,a.join_dt,trunc(months_between(sysdate, TO_DATE(a.join_dt)) / 12) || '.' || mod(trunc(months_between(sysdate, TO_DATE(a.join_dt))), 12) || '.' ||trunc(sysdate - add_months(TO_DATE(a.join_dt), trunc(months_between(sysdate, TO_DATE(a.join_dt))))) exp,b.designation," +
           "c.dep_name,a.basic_pay,d.post_name,max(g.year_pass) year_pass from hospital.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id join HOSPITAL.DEPARTMENT_MST c on c.dep_id = a.department_id join mactech.POST_MST d on d.post_id = a.post_id join mactech.branch_master e " +
           "on e.branch_id = a.branch_id left outer join SHIFTALERT_SHIFTS f on f.shift_id = a.shift_id left outer join mactech.EMPLOY_QUALIFICATION_DTL g on g.emp_code = a.emp_code left outer JOIN mactech.qualification_master h on h.qualification_id = g.qualification left outer join mactech.employ_personal_dtl k on k.emp_code = a.emp_code left outer join " +
           "hospital.macare_blood_group m on m.groupid = k.blood_id left outer join mactech.religion_master n on n.religion_id = k.religion_id left outer join mactech.IDENTITY p on p.identity_id = k.Id_proof left outer join hospital.MARITAL_STATUS q on q.statusid = k.marital_status left outer join hospital.EMRM_GENDER_CATEGORY r on r.gender_id = k.sex " +
           "left outer join mactech.state_master h on h.state_id = e.state_id where firm_id in (16) and  a.status_id = 1 and a.emp_type=1  and a.emp_code not in ('2000','40002','40004','153045') group by  e.branch_name,a.firm_id,a.emp_code,a.emp_name,f.shift,f.in_time,f.out_time,a.join_dt,b.designation,c.dep_name,a.basic_pay,d.post_name,k.caste,n.religion,p.identity_id, k.idproof_number,m.groupid," +
           "k.spouse_name,k.father_name,k.emp_email,r.gender,k.birth_date,k.perm_Add1,k.pres_Add1,k.cont_phone,k.res_phone,h.state_name)m order by m.branch_name)n where n.firm_id not in (8))s");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_HRMaster_Dashboard_Not()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select m.*,(select q.qualification from mactech.EMPLOY_QUALIFICATION_DTL p join mactech.qualification_master q on p.qualification = q.qualification_id where p.emp_code = m.emp_code and to_number(p.year_pass) = to_number(m.year_pass)) qualification from(select e.branch_name, to_char(a.join_dt, 'dd-MM-yyyy') join_dt, e.branch_id, " +
           "a.firm_id, a.status_id, a.emp_code, a.emp_name,NVL(TO_CHAR(r.gender), 'Female') gender, max(g.year_pass) year_pass, k.cont_phone, k.res_phone, h.state_name state, b.designation, c.dep_name, d.post_name from mactech.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id left outer join HOSPITAL.DEPARTMENT_MST c " +
           "on c.dep_id = a.department_id left outer join mactech.POST_MST d on d.post_id = a.post_id  join mactech.branch_master e on e.branch_id = a.branch_id left outer join mactech.employ_personal_dtl k on k.emp_code = a.emp_code left outer join hospital.EMRM_GENDER_CATEGORY r on r.gender_id = k.sex left outer join mactech.EMPLOY_QUALIFICATION_DTL g on " +
           "g.emp_code = a.emp_code left outer join mactech.state_master h on h.state_id = e.state_id where a.firm_id in (16, 33)  and a.status_id <> 1 and e.branch_id in (select branch_id from macare_unitmaster) and a.emp_code not in ('2000','40002','40004') group by  e.branch_name,a.join_dt,e.branch_id, a.firm_id,a.status_id, a.emp_code, a.emp_name, r.gender,h.state_name,k.cont_phone, k.res_phone,b.designation, " +
           "c.dep_name,d.post_name order by branch_id)m");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_HRMaster_Dashboard_Live()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select m.*,(select q.qualification from mactech.EMPLOY_QUALIFICATION_DTL p join mactech.qualification_master q on p.qualification = q.qualification_id where p.emp_code = m.emp_code and to_number(p.year_pass) = to_number(m.year_pass)) qualification from(select e.branch_name, to_char(a.join_dt, 'dd-MM-yyyy') join_dt, e.branch_id, " +
            "a.firm_id, a.status_id, a.emp_code, a.emp_name,NVL(TO_CHAR(r.gender), 'Female') gender, max(g.year_pass) year_pass, k.cont_phone, k.res_phone, h.state_name state, b.designation, c.dep_name, d.post_name from mactech.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id left outer join HOSPITAL.DEPARTMENT_MST c " +
            "on c.dep_id = a.department_id left outer join mactech.POST_MST d on d.post_id = a.post_id  join mactech.branch_master e on e.branch_id = a.branch_id left outer join mactech.employ_personal_dtl k on k.emp_code = a.emp_code left outer join hospital.EMRM_GENDER_CATEGORY r on r.gender_id = k.sex left outer join mactech.EMPLOY_QUALIFICATION_DTL g on " +
            "g.emp_code = a.emp_code left outer join mactech.state_master h on h.state_id = e.state_id where a.firm_id in (16, 33)  and a.status_id =1  and e.branch_id in (select branch_id from macare_unitmaster) and a.emp_code not in ('2000','40002','40004') group by  e.branch_name,a.join_dt,e.branch_id, a.firm_id,a.status_id, a.emp_code, a.emp_name, r.gender,h.state_name,k.cont_phone, k.res_phone,b.designation, " +
            "c.dep_name,d.post_name order by branch_id)m");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_HRMaster_Dashboard_One()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select e.branch_name, to_char(a.join_dt, 'dd-MM-yyyy') join_dt, e.branch_id, a.firm_id, a.status_id, a.emp_code, a.emp_name,NVL(TO_CHAR(r.gender), 'Female') gender,'' year_pass,  k.cont_phone, k.res_phone, h.state_name state, b.designation, c.dep_name, d.post_name, q.qualification from mactech.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id " +
            "left outer join HOSPITAL.DEPARTMENT_MST c on c.dep_id = a.department_id left outer join mactech.POST_MST d on d.post_id = a.post_id  join mactech.branch_master e on e.branch_id = a.branch_id left outer join mactech.employ_personal_dtl k on k.emp_code = a.emp_code left outer join hospital.EMRM_GENDER_CATEGORY r on r.gender_id = k.sex left outer join mactech.EMPLOY_QUALIFICATION_DTL g on g.emp_code = a.emp_code join mactech.qualification_master q " +
            "on g.qualification = q.qualification_id left outer join mactech.state_master h on h.state_id = e.state_id where  a.emp_code = 15215  order by branch_id");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_branches()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from macare_unitmaster");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_branchesBasesedName(string branch_name)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from macare_unitmaster where branch_name like '%"+branch_name+"%'");
            return DS;
        }


        [WebMethod()]
        public DataSet Get_HRMaster()
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select s.firm_id, s.emp_code, s.emp_name,s.caste, s.religion,case s.identity_id when 8 then 'Aadhar' when 1 then 'Passport' when 7 then 'Nil' when 5 then 'PAN card' when 0 then 'Nil' when 3 then 'Voters Id' when 2 then 'Driving Licence' else 'Others' end Identity_Name, s.idproof_number," +
            //    "case s.groupid when 1 then 'O+ve' when 2 then 'O-ve' when 3 then 'A+ve' when 4 then 'A-ve' when 5 then 'B+ve' when 6 then 'B-ve' when 7 then 'AB+ve' when 8 then 'AB-ve' else '' end blood_group,s.spouse_name, s.father_name,s.emp_email,s.gender, s.birth_date,s.age,s.permanent_Addr, s.present_Addr, s.cont_phone, s.res_phone, " +
            //    "s.state, s.shift, s.in_time, s.out_time, to_char(s.join_dt, 'dd-MM-yyyy') join_dt, s.exp, s.designation, s.dep_name, s.basic_pay,s.post_name, s.year_pass, s.branch_name from(select e.branch_name, a.firm_id, a.emp_code, a.emp_name,k.caste, n.religion, p.identity_id, k.idproof_number, nvl(m.groupid, 0) groupid, k.child_number, " +
            //    "q.statusname Marital_status, k.spouse_name, k.father_name,k.emp_email, NVL(TO_CHAR(r.gender), 'Female') gender, k.birth_date, ROUND((SYSDATE - TO_DATE(k.birth_date)) / 365.25) age, k.perm_Add1 permanent_Addr, k.pres_Add1 present_Addr,k.cont_phone, k.res_phone, h.state_name state, f.shift, f.in_time, f.out_time, a.join_dt, " +
            //    "trunc(months_between(sysdate, TO_DATE(a.join_dt)) / 12) || '.' || mod(trunc(months_between(sysdate, TO_DATE(a.join_dt))), 12) || '.' ||trunc(sysdate - add_months(TO_DATE(a.join_dt), trunc(months_between(sysdate, TO_DATE(a.join_dt))))) exp, b.designation, c.dep_name, a.basic_pay, d.post_name, max(g.year_pass) year_pass " +
            //    "from hospital.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id join HOSPITAL.DEPARTMENT_MST c on c.dep_id = a.department_id left outer join mactech.POST_MST d on d.post_id = a.post_id left outer join mactech.branch_master e on e.branch_id = a.branch_id left outer join " +
            //    "SHIFTALERT_SHIFTS f on f.shift_id = a.shift_id left outer join mactech.EMPLOY_QUALIFICATION_DTL g on g.emp_code = a.emp_code left outer JOIN mactech.qualification_master h on h.qualification_id = g.qualification left outer join mactech.employ_personal_dtl k on k.emp_code = a.emp_code left outer join hospital.macare_blood_group m " +
            //    "on m.groupid = k.blood_id left outer join mactech.religion_master n on n.religion_id = k.religion_id left outer join mactech.IDENTITY p on p.identity_id = k.Id_proof left outer join hospital.MARITAL_STATUS q on q.statusid = k.marital_status left outer join hospital.EMRM_GENDER_CATEGORY r on r.gender_id = k.sex left outer join " +
            //    "mactech.state_master h on h.state_id = e.state_id where a.firm_id = 16  and a.status_id = 1 and a.emp_type = 1 and a.emp_code not in ('153045', '10001') group by  e.branch_name, a.firm_id, a.emp_code, a.emp_name, f.shift, f.in_time, f.out_time,a.join_dt, b.designation, c.dep_name, a.basic_pay, d.post_name, k.caste, n.religion, " +
            //    "p.identity_id, k.idproof_number, m.groupid, k.child_number, q.statusname,k.spouse_name, k.father_name, k.emp_email, r.gender, k.birth_date, k.perm_Add1, k.pres_Add1, k.cont_phone, k.res_phone, h.state_name order by e.branch_name)s");



            DS = ObjOrclHelper.ExecuteDataSet("select s.firm_id, s.emp_code, s.emp_name,s.caste, s.religion,case s.identity_id when 8 then 'Aadhar' when 1 then 'Passport' when 7 then 'Nil' when 5 then 'PAN card' when 0 then 'Nil' when 3 then 'Voters Id' when 2 then 'Driving Licence' else 'Others' end Identity_Name, s.idproof_number, " +
                " case s.groupid when 1 then 'O+ve' when 2 then 'O-ve' when 3 then 'A+ve' when 4 then 'A-ve' when 5 then 'B+ve' when 6 then 'B-ve' when 7 then 'AB+ve' when 8 then 'AB-ve' else '' end blood_group, s.spouse_name, s.father_name,s.emp_email,s.gender,to_char(s.birth_date, 'dd-mm-yyyy')Date_Of_Birth,s.age, " +
                " s.permanent_Addr,s.present_Addr, s.cont_phone, s.res_phone,s.state, s.in_time, s.out_time, to_char(s.join_dt, 'dd-MM-yyyy') join_dt, s.designation, s.dep_name, " +
                " s.basic_pay,s.post_name, s.year_pass, s.branch_name from(select e.branch_name, a.firm_id, a.emp_code, a.emp_name, k.caste, n.religion, p.identity_id, k.idproof_number, nvl(m.groupid, 0) groupid, k.child_number,q.statusname Marital_status, k.spouse_name, " +
                " k.father_name,k.emp_email, NVL(TO_CHAR(r.gender), 'Female') gender, k.birth_date, ROUND((SYSDATE - TO_DATE(k.birth_date)) / 365.25) age, " +
                " k.perm_Add1 permanent_Addr, k.pres_Add1 present_Addr, k.cont_phone, k.res_phone, h.state_name state, f.shift, f.in_time, f.out_time, a.join_dt, " +
                " trunc(months_between(sysdate, TO_DATE(a.join_dt)) / 12) || '.' || mod(trunc(months_between(sysdate, TO_DATE(a.join_dt))), 12) || '.' || trunc(sysdate - add_months(TO_DATE(a.join_dt), " +
                "trunc(months_between(sysdate, TO_DATE(a.join_dt))))) exp, b.designation, c.dep_name, a.basic_pay, d.post_name, max(g.year_pass) year_pass " +
                " from hospital.employee_master a left outer join mactech.DESIGNATION_MASTER b on a.designation_id = b.designation_id join HOSPITAL.DEPARTMENT_MST c  " +
                " on c.dep_id = a.department_id left outer join mactech.POST_MST d on d.post_id = a.post_id left outer join mactech.branch_master e " +
                " on e.branch_id = a.branch_id left outer join SHIFTALERT_SHIFTS f on f.shift_id = a.shift_id left outer join mactech.EMPLOY_QUALIFICATION_DTL g on g.emp_code = a.emp_code " +
                " left outer JOIN mactech.qualification_master h on h.qualification_id = g.qualification left outer join mactech.employ_personal_dtl k on k.emp_code = a.emp_code " +
                " left outer join hospital.macare_blood_group m on m.groupid = k.blood_id left outer join mactech.religion_master n on n.religion_id = k.religion_id left outer join " +
                " mactech.IDENTITY p on p.identity_id = k.Id_proof left outer join hospital.MARITAL_STATUS q on q.statusid = k.marital_status left outer join hospital.EMRM_GENDER_CATEGORY r " +
                " on r.gender_id = k.sex left outer join mactech.state_master h on h.state_id = e.state_id where a.firm_id = 16  and a.status_id = 1 and a.emp_type = 1 " +
                " and a.emp_code not in ('153045', '10001') group by  e.branch_name, a.firm_id, a.emp_code, a.emp_name, f.shift, f.in_time, f.out_time,a.join_dt, b.designation, c.dep_name, " +
                " a.basic_pay, d.post_name, k.caste, n.religion, p.identity_id, k.idproof_number, m.groupid, k.child_number, q.statusname,k.spouse_name, k.father_name, k.emp_email, r.gender," +
                " k.birth_date, k.perm_Add1, k.pres_Add1, k.cont_phone, k.res_phone, h.state_name order by e.branch_name)s");


            return DS;
        }

        [WebMethod()]
        public DataSet Get_Qualifn()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct a.emp_code,qq.year_pass,q.qualification from mactech.EMPLOY_QUALIFICATION_DTL qq join mactech.qualification_master q on qq.qualification=q.qualification_id join hospital.employee_master a on a.emp_code = qq.emp_code where qq.year_pass = (select max(year_pass) from " +
                "mactech.EMPLOY_QUALIFICATION_DTL where emp_code = a.emp_code) and a.firm_id = 16  and a.status_id = 1 and a.emp_type = 1 and a.emp_code not in ('153045', '10001') order by a.emp_code");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_branch_lab()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select branch_id,branch_name from MACARE_UNITMASTER where branch_type='Lab' or branch_type='Microlab' order by branch_type");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_Checkup_details(string branchid, string start_date, string end_date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select b.opnumber,b.name,b.address,b.mobile_no,t.test_name,g.group_name,a.test_charge,a.bill_amt,to_char(a.tra_date,'dd-MM-yyyy') tra_dt,m.name branch from hospital.dgn_bill_dtl d join HOSPITAL.DGN_BILL_MASTER a on d.bill_id = a.bill_id join hospital.patient_master b on a.patient_id = b.opnumber " +
                "join hospital.dgn_test_master t on d.test_id = t.test_id join HOSPITAL.LAB_GROUPTEST_MASTER g on g.group_id = t.group_id join hospital.clinic_master m on m.branch_id = a.branch_id where a.branch_id ='" + branchid + "' and to_date(a.tra_date, 'dd-MM-yyyy') between to_date('" + start_date + "', 'dd-MM-yyyy') and to_date('" + end_date + "', 'dd-MM-yyyy')");
            return DS;
        }




        // ........................temporary punching.............................
        [WebMethod()]
        public DataSet Get_Temporarypunchingdetails(string startDate, string enddate, string empcode)
        {
            DataSet DS = new DataSet();
            string query;
            if (!string.IsNullOrEmpty(empcode))
            {
                //query = "select distinct t.username,t.punchin_time,t.punchinimage,t.punchout_time,t.punchoutimage from TEMPORARY_PUNCHING t " +
                //        "where to_date(t.punchin_time,'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') and  to_date('" + enddate + "','dd-mm-yyyy') and t.username='" + empcode + "' order by  t.punchin_time ";
                query = "select * from(select distinct  username from TEMPORARY_PUNCHING WHERE TO_DATE(punchin_time, 'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') " +
                    " and to_date('" + enddate + "', 'dd-mm-yyyy') and username='" + empcode + "') x left outer join(select username, CASE WHEN to_char(punchin_time,'dd-mm-yyyy') is NULL THEN 'NON MArking'" +
                    " ELSE to_char(punchin_time,'dd-mm-yyyy')|| ' ' || TO_CHAR(punchin_time, 'HH24:MI:SS') END AS punchin_time, punchinimage,CASE WHEN punchout_time is NULL " +
                    " THEN 'NON Marking EVENING' ELSE to_char(punchout_time, 'dd-mm-yyyy') || ' ' || TO_CHAR(punchout_time, 'HH24:MI:SS') END AS punchout_time,punchoutimage from " +
                    " TEMPORARY_PUNCHING WHERE TO_DATE(punchin_time, 'dd-mm-yyyy') between to_date('" + startDate + "', 'dd-mm-yyyy') and  to_date('" + enddate + "', 'dd-mm-yyyy')" +
                    " and username='" + empcode + "' )y " +
                    " on y.username = x.username";

            }
            else
            {
                query = "select * from(select distinct  username from TEMPORARY_PUNCHING WHERE TO_DATE(punchin_time, 'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') " +
                     " and to_date('" + enddate + "', 'dd-mm-yyyy')) x left outer join(select username, CASE WHEN to_char(punchin_time,'dd-mm-yyyy') is NULL THEN 'NON MArking'" +
                     " ELSE to_char(punchin_time,'dd-mm-yyyy')|| ' ' || TO_CHAR(punchin_time, 'HH24:MI:SS') END AS punchin_time, punchinimage,CASE WHEN punchout_time is NULL " +
                     " THEN 'NON Marking EVENING' ELSE to_char(punchout_time, 'dd-mm-yyyy') || ' ' || TO_CHAR(punchout_time, 'HH24:MI:SS') END AS punchout_time,punchoutimage from " +
                     " TEMPORARY_PUNCHING WHERE TO_DATE(punchin_time, 'dd-mm-yyyy') between to_date('" + startDate + "', 'dd-mm-yyyy') and  to_date('" + enddate + "', 'dd-mm-yyyy')" +
                     " )y " +
                     " on y.username = x.username";
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public DataSet LoginTempData()
        {
            DataSet ds;
            ds = ObjOrclHelper.ExecuteDataSet("select username as emp_code,log_user from Login_users ");
            return ds;
        }
        [WebMethod()]
        public DataSet Get_TemporarypunchingdetailsWithLOgName(string startDate, string enddate, string empcode)
        {
            DataSet DS = new DataSet();
            string query;
            if (!string.IsNullOrEmpty(empcode))
            {
                query = "select distinct t.username,l.log_user as Emp_name ,to_char(t.punchin_time,'dd-mm-yyyy') punchin_time,t.punchinimage,to_char(t.punchout_time,'dd-mm-yyyy') punchout_time,t.punchoutimage from TEMPORARY_PUNCHING t join Login_users l on " +
                " l.username= t.username where to_date(t.punchin_time,'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') and  to_date('" + enddate + "','dd-mm-yyyy') and t.username='" + empcode + "' ";

            }
            else
            {
                query = "select distinct t.username,l.log_user as Emp_name ,to_char(t.punchin_time,'dd-mm-yyyy') punchin_time,t.punchinimage,to_char(t.punchout_time,'dd-mm-yyyy') punchout_time,t.punchoutimage from TEMPORARY_PUNCHING t join Login_users l on " +
                  " l.username= t.username where to_date(t.punchin_time,'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') and  to_date('" + enddate + "','dd-mm-yyyy') ";
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_branchOfUsers()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from macare_unitmaster where branch_type not in ('Lab')");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_designation()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct type,designation from login_users");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public int createLogin(string username, string password, string type, string designation, string mailid, string role, string branchid, string logusername, string enterduserid)
        {
            string query; int res = 0;
            int count = ObjOrclHelper.executeScalar("select userid from login_users where username='" + username + "' and DESIGNATION='" + designation + "' and branchid=" + branchid + "");
            if (count > 0)
            {
                res = -1;
            }
            else
            {
                query = "insert into LOGIN_USERS (userid,username,password,type,designation,mailid,role,branchid,log_user,updated_date,entered_by) " +
                    "values(SEQ_LOGIN.nextval,'" + username + "','" + password + "','" + type + "','" + designation + "','" + mailid + "','" + role + "','" + branchid + "','" + logusername + "',sysdate," + enterduserid + ")";
                res = ObjOrclHelper.ExecuteNonQuery(query);
            }
            return res;
        }

        [WebMethod]
        public DataSet Get_Employee_Code()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select SEQ_TEMP_STAFF_EMPCODE.NEXTVAL from dual");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_shift()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from SHIFTALERT_SHIFTS");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public int AddShift(string shift_id, string empcode, string shift)
        {
            int res = 0;
            string query;
            query = "insert into temporary_staff_shifts (shift_id,empcode,normal_shift) values('" + shift_id + "','" + empcode + "','" + shift + "') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet Get_ShiftAndName(string EmpCode)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (EmpCode == null)
            {
                query = ("select * from login_users a join TEMPORARY_STAFF_SHIFTS t on t.empcode=a.username");
            }
            else
            {
                query = ("select * from login_users a join TEMPORARY_STAFF_SHIFTS t on t.empcode=a.username where a.username='" + EmpCode + "' ");
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_TEmpName()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("SELECT * FROM login_users l WHERE(l.username LIKE '123%' OR l.username LIKE '200%' OR l.username IN(154524)) and l.active=1 ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int UpdateShift(string shift_id, string updatedShift, string empcode, string ChangeDate)
        {
            string query; int res;
            if (ChangeDate != null && ChangeDate != "")
            {
                query = "update temporary_staff_shifts set SHIFT_FOR_DATE='" + shift_id + "',date_shift_change='" + ChangeDate + "'  where empcode=" + empcode;

            }
            else
            {

                query = "update temporary_staff_shifts set shift_id='" + shift_id + "'," +
               " change_shift='" + updatedShift + "'  where empcode=" + empcode;

            }
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }
        [WebMethod()]
        public DataSet Get_shift_Details(string shift)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from login_users where active=1");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod()]
        public DataSet Get_TemporarypunchingdetailsWithoutPhoto(string startDate, string enddate, string empcode)
        {
            DataSet DS = new DataSet();
            string query;
            if (!string.IsNullOrEmpty(empcode))
            {
                query = "select distinct TO_CHAR(punchin_time,'DD-MM-YYYY') Punchin_Time,t.username as Emp_Code,l.log_user AS Emp_Name,TO_CHAR(punchin_time, ' HH12:MI:SS AM') AS In_Time, TO_CHAR(t.punchout_time, ' HH12:MI:SS AM') AS Out_Time, CASE WHEN t.punchin_time IS " +
                  " NULL AND t.punchout_time IS NULL THEN 'Absent' WHEN t.punchout_time IS NULL THEN 'Non-Marking Evening' ELSE '---'  END AS status from TEMPORARY_PUNCHING t join Login_users l on " +
                  " l.username = t.username where to_date(t.punchin_time, 'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') and " +
                  " to_date('" + enddate + "','dd-mm-yyyy') and t.username='" + empcode + "' order by Punchin_Time ";

            }
            else
            {
                query = "select distinct TO_CHAR(punchin_time,'DD-MM-YYYY') Punchin_Time,t.username as Emp_Code,l.log_user AS Emp_Name,TO_CHAR(punchin_time, ' HH12:MI:SS AM') AS In_Time, TO_CHAR(t.punchout_time, ' HH12:MI:SS AM') AS Out_Time, CASE WHEN t.punchin_time IS " +
                    " NULL AND t.punchout_time IS NULL THEN 'Absent' WHEN t.punchout_time IS NULL THEN 'Non-Marking Evening' ELSE '---'  END AS status from TEMPORARY_PUNCHING t join Login_users l on " +
                    " l.username = t.username where to_date(t.punchin_time,'dd-mm-yyyy') between to_date('" + startDate + "','dd-mm-yyyy') and " +
                    " to_date('" + enddate + "','dd-mm-yyyy') order by Punchin_Time";
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public DataSet Get_daysCountOfEmployees(string startDate, string enddate)
        {
            DataSet DS = new DataSet();
            string query = "";
       
            //query = ("select x.*,x.no_of_daysinmonth-x.PunchInCount diff,case when x.PunchInCount< x.no_of_daysinmonth-x.assign_leave_days " +
            //   " then to_number(x.monthly_salary)-(((x.no_of_daysinmonth - to_number(x.assign_leave_days)) - x.PunchInCount) * CAST((TO_NUMBER(x.monthly_salary) / x.no_of_daysinmonth) AS DECIMAL(10,1)))  " +
            //   " else to_number(x.monthly_salary) end NetSalary  from(select distinct  t.username as EmpCode, l.log_user as UserName, m.branch_name, l.designation as PostName," +
            //   " temp.monthly_salary,1 + trunc(last_day(to_date('" + enddate + "', 'dd-mm-yyyy'))) - trunc(to_date('" + enddate + "', 'dd-mm-yyyy'), 'MM') no_of_daysinmonth," +
            //   " COUNT(DISTINCT TO_CHAR(t.punchin_time, 'dd-mm-yyyy')) AS PunchInCount, temp.leave_days assign_leave_days," +
            //   " count(distinct to_char(ml.leave_date,'dd-mm-yyyy')) as Sanctioned_leave FROM TEMPORARY_PUNCHING t" +
            //   " JOIN Login_users l ON l.username = t.username join macare_unitmaster m  on m.branch_id = l.branchid join  temp_salary_calculation temp on" +
            //   " temp.username = t.username join macare_leave_apply_table ml on ml.username=t.username  where to_date(t.punchin_time, 'dd-mm-yyyy')  " +
            //   " between to_date('" + startDate + "', 'dd-mm-yyyy')  and to_date('" + enddate + "', 'dd-mm-yyyy') " +
            //   " and t.punchin_time IS NOT NULL and   m.BRANCH_TYPE  not in ('Lab')   GROUP BY t.username, l.log_user, l.log_user, m.branch_name, l.designation, " +
            //   "temp.monthly_salary, temp.leave_days)x");
            query = ("select x.*,/*case  when x.PunchInCount< x.no_of_daysinmonth-x.assign_leave_days " +
                " then to_number(x.monthly_salary)-(((x.no_of_daysinmonth - to_number(x.assign_leave_days)) - x.PunchInCount) * CAST((TO_NUMBER(x.monthly_salary) / x.no_of_daysinmonth) AS " +
                " DECIMAL(10, 1)))   else to_number(x.monthly_salary) end NetSalary*/h.Missed_Punchin_Count, case when h.Missed_Punchin_Count > 0 then " +
                " to_number(x.monthly_salary)-(h.Missed_Punchin_Count * (CAST((TO_NUMBER(x.monthly_salary) / x.no_of_daysinmonth) AS DECIMAL(10, 1))))  else to_number(x.monthly_salary) end " +
                " NetSalary from(select distinct  t.username as EmpCode, l.log_user as UserName, m.branch_name, l.designation as PostName," +
                " temp.monthly_salary, 1 + trunc(last_day(to_date('" + enddate + "', 'yyyy-mm-dd'))) - trunc(to_date('" + enddate + "', 'yyyy-mm-dd'), 'MM') no_of_daysinmonth," +
                " COUNT(DISTINCT TO_CHAR(t.punchin_time, 'dd-mm-yyyy')) AS PunchInCount FROM TEMPORARY_PUNCHING t JOIN Login_users l ON l.username = t.username join macare_unitmaster m  " +
                " on m.branch_id = l.branchid join  temp_salary_calculation temp on temp.username = t.username  " +
                " where to_date(t.punchin_time, 'dd-mm-yyyy') between to_date('" + startDate + "', 'yyyy-mm-dd')  and to_date('" + enddate + "', 'yyyy-mm-dd')  and t.punchin_time IS NOT NULL and " +
                " m.BRANCH_TYPE  not in ('Lab') GROUP BY t.username, l.log_user, l.log_user, m.branch_name, l.designation, temp.monthly_salary, temp.leave_days)x " +
                " join(SELECT u.username as EmpCode, COUNT(cal.date_day) AS Missed_Punchin_Count FROM " +
                " (SELECT TO_DATE('" + startDate + "', 'YYYY-MM-DD') + LEVEL - 1 AS date_day FROM DUAL CONNECT BY LEVEL <= LAST_DAY(TO_DATE('" + startDate + "', 'YYYY-MM-DD')) - " +
                " TO_DATE('"+startDate+"', 'YYYY-MM-DD') + 1) cal CROSS JOIN(SELECT DISTINCT username FROM TEMPORARY_PUNCHING " +
                " UNION  SELECT DISTINCT username FROM macare_leave_apply_table) u LEFT JOIN TEMPORARY_PUNCHING t ON TO_DATE(t.punchin_time, 'DD-MM-YYYY') = cal.date_day " +
                " AND t.username = u.username LEFT JOIN macare_leave_apply_table ml ON TO_DATE(ml.leave_date, 'DD-MM-YYYY') = cal.date_day AND ml.username = u.username and ml.status = 1 " +
                " WHERE t.username IS NULL AND ml.username IS NULL  GROUP BY u.username ORDER BY u.username)h on h.EmpCode = x.EmpCode");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod()]
        public DataSet Get_salaryDetails()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select a.ID,a.username as Emp_Code,l.log_user as UserName,a.monthly_salary,a.leave_days from temp_salary_calculation a join login_users l " +
                " on l.username=a.username join mactech.POST_MST d on d.POST_NAME = l.designation ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod()]
        public DataSet Get_salaryDetailsWithUsername(string UserName)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from TEMP_SALARY_CALCULATION t where t.username='"+UserName+"' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public DataSet Get_userDetails(string Designation)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select a.username  ||'-'||  a.log_user AS log_user,a.username from login_users a where a.username like '123%' and a.designation='" + Designation + "'");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod()]
        public DataSet Get_designationDetails()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from DESIGNATION_MACARE");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod()]
        public int InsertSalary(string empcode, string MONTHLY_SALARY, string LEAVE_DAYS)
        {
            int res = 0;
            int id = 0;
            string query = "";
            query = "SELECT NVL(MAX(TO_NUMBER(ID)), 0) + 1 from TEMP_SALARY_CALCULATION";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into TEMP_SALARY_CALCULATION (id,USERNAME,MONTHLY_SALARY,LEAVE_DAYS) values('" + id + "','" + empcode + "','" + MONTHLY_SALARY + "','" + LEAVE_DAYS + "') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public int UpdateSalary(int id, string USERNAME, string MONTHLY_SALARY, string LEAVE_DAYS)
        {
            string query; int res;
            query = "update TEMP_SALARY_CALCULATION set USERNAME='" + USERNAME + "',MONTHLY_SALARY='" + MONTHLY_SALARY + "' ,LEAVE_DAYS='" + LEAVE_DAYS + "' where ID=" + id;
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }


        [WebMethod()]
        public DataSet Get_dept_Details(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct  d.dep_id,d.DEP_NAME from  hospital.employee_master a join hospital.department_mst d on d.dep_id = a.DEPARTMENT_ID where a.firm_id=16" +
                " and a.branch_id='"+ branch_id + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public int InsertNorms(string BRANCH, string POST, string NORMS)
        {
            int res = 0;
            int id = 0;
            string query = "";
            query = "SELECT NVL(MAX(TO_NUMBER(ID)), 0) + 1 from MACARE_STAFF_NORMS";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into MACARE_STAFF_NORMS (id,BRANCH,POST,NORMS) values('" + id + "','" + BRANCH + "','" + POST + "','" + NORMS + "') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public int UpdateNorms(int id, string NORMS)
        {
            string query; int res;
            query = "update MACARE_STAFF_NORMS set NORMS='" + NORMS + "' where ID=" + id;
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Get_staffNormsDetails()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select s.id,d.post_name,m.branch_name,s.norms from MACARE_STAFF_NORMS S JOIN macare_unitmaster m on m.branch_id=s.branch join " +
                " mactech.POST_MST d on d.post_id = s.post");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public DataSet Get_user_Details(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select  distinct a.emp_code AS unique_username,a.emp_name,a.emp_code || '-'|| a.emp_name as username   FROM hospital.employee_master a" +
                "  WHERE firm_id = 16 and a.status_id = 1  and a.branch_id = '" + branch_id + "' AND a.emp_code NOT IN(SELECT username FROM login_users WHERE username LIKE '123%')  " +
                " UNION select distinct TO_NUMBER(l.username) AS unique_username, l.log_user,TO_NUMBER(l.username) || '-' || l.log_user as username  " +
                " FROM login_users l WHERE  username LIKE '123%' and active = 1 and l.branchid = '"+branch_id+"' AND username NOT IN(SELECT emp_code  " +
                " FROM hospital.employee_master WHERE firm_id = 16 and status_id = 1)");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Norms_Count()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("SELECT  (z.CURR_DATE + COALESCE(y.CURR_DATE, 0)) AS CURR_DATE,z.post_name,(z.cempcode + COALESCE(y.cempcode, 0)) AS actual," +
                " g.Shortage_Lag_Days,z.norms,TO_NUMBER(z.NORMS) - (z.cempcode + COALESCE(y.cempcode, 0)) AS shortage_count,CASE WHEN g.under_notice > 0 THEN g.under_notice " +
                " ELSE 0 END under_notice FROM(SELECT DISTINCT COUNT(DISTINCT MC_TIME) AS CURR_DATE, t.POST_NAME, CASE WHEN COUNT(CASE WHEN u.status_id = 1 " +
                " THEN u.emp_code END) > 0 THEN COUNT(CASE WHEN u.status_id = 1 THEN u.emp_code END) ELSE 0 END AS cempcode,w.NORMS FROM  macare_staff_norms w " +
                " join mactech.POST_MST  t on w.post=t.post_id join hospital.employee_master u ON u.post_id = t.post_id left join MACTECH.DAILY_ATTEND a " +
                " on a.EMP_CODE = u.emp_code WHERE u.firm_id = 16   GROUP BY  t.POST_NAME, w.NORMS) z " +
                " LEFT JOIN(SELECT DISTINCT COUNT(DISTINCT TRUNC(a.punchin_time)) AS CURR_DATE, ul.designation AS POST_NAME, COUNT(ul.username) AS cempcode" +
                " FROM temporary_punching a JOIN login_users ul ON ul.username = a.username JOIN macare_unitmaster mn ON mn.branch_id = ul.branchid WHERE " +
                " TRUNC(a.punchin_time) = TRUNC(SYSDATE) AND mn.branch_type NOT IN('Clinic') GROUP BY  ul.designation) y ON z.POST_NAME = y.POST_NAME" +
                " LEFT outer JOIN(SELECT COUNT(hm.emp_name) AS under_notice, round(CAST(SUM(sysdate -  TO_DATE(m.ENTER_DT, 'DD-MM-YYYY'))/ count(hm.emp_name) AS DECIMAL(10,1))) " +
                " AS Shortage_Lag_Days,mst.post_name FROM MACTECH.M_RESIGN_APPL m " +
                " JOIN hospital.employee_master hm ON hm.emp_code = m.emp_code JOIN mactech.POST_MST mst ON mst.post_id = hm.post_id WHERE" +
                " TO_DATE(m.ENTER_DT, 'dd-mm-yyyy') > TO_DATE(SYSDATE - 90) AND TO_DATE(m.CANCEL_DT) IS NULL AND hm.firm_id = 16 GROUP BY mst.post_name) g ON " +
                " g.post_name = z.post_name");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod]
        public DataSet Get_staffNormsDetailsWithBranch(string branch)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select s.id,d.post_name,m.branch_name,s.norms,S.branch,S.post from MACARE_STAFF_NORMS S JOIN macare_unitmaster m" +
                " on m.branch_id = s.branch join mactech.POST_MST d on d.post_id = s.post where s.branch='"+branch+" ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_shiftDetails()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select (a.in_time || '-'|| a.out_time)||'-'|| a.shift as shift,a.shift_id  from SHIFTALERT_SHIFTS a order by a.in_time");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod()]
        public int InsertStaffShift(string Username,string BRANCH, string shift)
        {
            int res = 0;
            int id = 0;
            string query = "";
            query = "SELECT NVL(MAX(TO_NUMBER(ID)), 0) + 1 from MACARE_STAFF_SHIFT";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into MACARE_STAFF_SHIFT (id,USERNAME,BRANCH_ID,SHIFT_ID) values('" + id + "','" + Username + "','" + BRANCH + "','" + shift + "') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }


        [WebMethod]
        public int UpdateStaffShift(string Username, string shift)
        {
            string query; int res;
            query = "update MACARE_STAFF_SHIFT set SHIFT_ID='" + shift + "' where USERNAME='" + Username+"' ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet Get_staffShiftDetails(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (branch_id != null)
            {
                query = ("select distinct  a.emp_code AS unique_username,a.emp_name as emp_name,(h.in_time || '-' || h.out_time) || '-' || h.shift as shift, " +
                    " d.post_name as post_name, m.branch_name as branch_name FROM macare_staff_shift s join hospital.employee_master a on a.emp_code = s.username  " +
                    " join shiftalert_shifts h on h.shift_id = s.shift_id join  macare_unitmaster m on m.branch_id = s.branch_id join mactech.POST_MST d " +
                    " on d.post_id = a.post_id WHERE a.firm_id = 16 and a.status_id = 1  and s.branch_id = '" + branch_id + "' and m.branch_type not in('Clinic')" +
                    " AND a.emp_code NOT IN(SELECT username FROM login_users " +
                    " WHERE username LIKE '123%') union all select distinct to_number(l.username) AS unique_username, l.log_user as emp_name," +
                    " (h.in_time || '-' || h.out_time) || '-' || h.shift as shift,to_char(l.designation) as post_name,mi.branch_name as branch_name" +
                    " FROM macare_staff_shift s join login_users l on s.username = l.username join macare_unitmaster mi on mi.branch_id = s.branch_id " +
                    " join shiftalert_shifts h on h.shift_id = s.shift_id join macare_unitmaster m on m.branch_id = s.branch_id  WHERE l.username" +
                    " LIKE '123%' and active = 1 and s.branch_id = '" + branch_id + "' and mi.branch_type not in('Clinic')  AND l.username NOT IN(SELECT emp_code   FROM hospital.employee_master WHERE firm_id = 16 and " +
                    " status_id = 1)");
            }
            else
            {
                query = ("select distinct  a.emp_code AS unique_username,a.emp_name as emp_name,(h.in_time || '-' || h.out_time) || '-' || h.shift as shift, " +
                  "d.post_name as post_name, m.branch_name as branch_name FROM macare_staff_shift s join hospital.employee_master a on a.emp_code = s.username  " +
                  " join shiftalert_shifts h on h.shift_id = s.shift_id join  macare_unitmaster m on m.branch_id = s.branch_id join mactech.POST_MST d " +
                  " on d.post_id = a.post_id WHERE a.firm_id = 16 and a.status_id = 1  and  m.branch_type not in('Clinic')" +
                  " AND a.emp_code NOT IN(SELECT username FROM login_users " +
                  " WHERE username LIKE '123%') union all select distinct to_number(l.username) AS unique_username, l.log_user as emp_name," +
                  " (h.in_time || '-' || h.out_time) || '-' || h.shift as shift,to_char(l.designation) as post_name,mi.branch_name as branch_name" +
                  " FROM macare_staff_shift s join login_users l on s.username = l.username join macare_unitmaster mi on mi.branch_id = s.branch_id " +
                  " join shiftalert_shifts h on h.shift_id = s.shift_id join macare_unitmaster m on m.branch_id = s.branch_id  WHERE l.username" +
                  " LIKE '123%' and active = 1 and  mi.branch_type not in('Clinic')  AND l.username NOT IN(SELECT emp_code   FROM hospital.employee_master WHERE firm_id = 16 and " +
                  " status_id = 1)");
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_staffShiftDetailsForUnitwise(string branch_name)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct  a.emp_code AS unique_username,a.emp_name as emp_name,(h.in_time || '-' || h.out_time) || '-' || h.shift as shift, " +
                " d.post_name as post_name, m.branch_name as branch_name FROM macare_staff_shift s join hospital.employee_master a on a.emp_code = s.username  " +
                " join shiftalert_shifts h on h.shift_id = s.shift_id join  macare_unitmaster m on m.branch_id = s.branch_id  join mactech.POST_MST d " +
                " on d.post_id = a.post_id WHERE a.firm_id = 16 and a.status_id = 1  and m.branch_name like '%" + branch_name + "%' and m.branch_type not in('Clinic')" +
                " AND a.emp_code NOT IN(SELECT username FROM login_users " +
                " WHERE username LIKE '123%') union all select distinct to_number(l.username) AS unique_username, l.log_user as emp_name," +
                " (h.in_time || '-' || h.out_time) || '-' || h.shift as shift,to_char(l.designation) as post_name,mi.branch_name as branch_name" +
                " FROM macare_staff_shift s join login_users l on s.username = l.username join macare_unitmaster mi on mi.branch_id = s.branch_id " +
                " join shiftalert_shifts h on h.shift_id = s.shift_id join macare_unitmaster m on m.branch_id = s.branch_id  WHERE l.username" +
                " LIKE '123%' and active = 1 and m.branch_name like  '%" + branch_name + "%' and mi.branch_type not in('Clinic')  AND l.username NOT IN(SELECT emp_code   FROM hospital.employee_master WHERE firm_id = 16 and " +
                " status_id = 1)");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_staffShiftDetailsWithoutBranch()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct  a.emp_code AS unique_username,a.emp_name as emp_name,(h.in_time || '-' || h.out_time) || '-' || h.shift as shift, " +
                " d.post_name as post_name, m.branch_name as branch_name FROM macare_staff_shift s join hospital.employee_master a on a.emp_code = s.username  " +
                " join shiftalert_shifts h on h.shift_id = s.shift_id join  macare_unitmaster m on m.branch_id = s.branch_id join mactech.POST_MST d " +
                " on d.post_id = a.post_id WHERE a.firm_id = 16 and a.status_id = 1   and m.branch_type not in('Clinic')" +
                " AND a.emp_code NOT IN(SELECT username FROM login_users " +
                " WHERE username LIKE '123%') union all select distinct to_number(l.username) AS unique_username, l.log_user as emp_name," +
                " (h.in_time || '-' || h.out_time) || '-' || h.shift as shift,to_char(l.designation) as post_name,mi.branch_name as branch_name" +
                " FROM macare_staff_shift s join login_users l on s.username = l.username join macare_unitmaster mi on mi.branch_id = s.branch_id " +
                " join shiftalert_shifts h on h.shift_id = s.shift_id join macare_unitmaster m on m.branch_id = s.branch_id  WHERE l.username" +
                " LIKE '123%' and active = 1 and mi.branch_type not in('Clinic')  AND l.username NOT IN(SELECT emp_code   FROM hospital.employee_master WHERE firm_id = 16 and " +
                " status_id = 1)");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_staffPunchingDetails(string branch)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("SELECT DISTINCT ul.branchid AS branch_id, mn.branch_name, to_char(a.punchin_time,'dd-mm-yyyy')  CURR_DATE,to_char(ul.designation) post_name," +
                " to_char(ul.username) emp_code FROM temporary_punching a JOIN login_users ul ON  ul.username = a.username JOIN macare_unitmaster mn ON " +
                " mn.branch_id = ul.branchid WHERE TRUNC(a.punchin_time) = TRUNC(SYSDATE) AND mn.branch_type NOT in ('Clinic') and mn.branch_id = '" + branch + "'" +
                " union all select DISTINCT u.BRANCH_ID, mn.branch_name, to_char(a.curr_date, 'dd-MM-yyyy') AS CURR_DATE, to_char(t.POST_NAME) post_name," +
                " to_char(u.emp_code) emp_code  FROM MACTECH.DAILY_ATTEND a JOIN hospital.employee_master u ON u.emp_code = a.EMP_CODE JOIN " +
                " mactech.POST_MST t ON t.post_id = u.post_id LEFT JOIN mactech.branch_master e  ON e.branch_id = a.branch_id JOIN macare_unitmaster mn " +
                " ON mn.branch_id = u.branch_id WHERE u.firm_id = 16 and a.mc_time is not null and u.branch_id = '"+branch +"'  and  " +
                " mn.branch_type NOT in ('Clinic') and to_date(a.curr_date,'dd-MM-yyyy')= to_date(sysdate, 'dd-MM-yyyy')");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_Post_Details(string branch_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct  d.post_id,d.post_NAME from  hospital.employee_master a join mactech.POST_MST d on d.post_id = a.post_id " +
                " where a.firm_id = 16 and a.branch_id = '"+branch_id+"' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod]
        public DataSet Get_branchName(string branchid)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from macare_unitmaster where branch_type not in ('Clinic') and branch_id='" + branchid+"' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]

        public int InsertLeaveApplicaton(string Username, string AppliedDate, string LeaveDate,string Reason,string Type)
        {
            int res = 0;
            int id = 0;
            string query = "";
            query = "SELECT NVL(MAX(TO_NUMBER(ID)), 0) + 1 from MACARE_LEAVE_APPLY_TABLE";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into MACARE_LEAVE_APPLY_TABLE (id,USERNAME,APPLY_DATE,LEAVE_DATE,REASON,LEAVE_TYPE) values('" + id + "','" + Username + "','" + AppliedDate + "','" + LeaveDate + "','"+ Reason + "','"+Type+"') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet get_Attendance(string startDate, string enddate,string empcode)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (string.IsNullOrEmpty(empcode))
            {
                query = ("SELECT * FROM (SELECT DISTINCT TO_CHAR(t.punchin_time, 'DD-Mon-YYYY') AS Punchin_Time,t.username AS Emp_Code,l.log_user AS Emp_Name,TO_CHAR(t.punchin_time, 'HH12:MI:SS AM') " +
                    " AS In_Time,TO_CHAR(t.punchout_time, 'HH12:MI:SS AM') AS Out_Time,CASE WHEN t.punchin_time IS NULL AND t.punchout_time IS NULL THEN 'Absent' WHEN t.punchout_time IS NULL " +
                    " THEN 'Non-Marking Evening'  ELSE '---'  END AS status,t.punchin_time AS Punchin_Date  FROM TEMPORARY_PUNCHING t  JOIN Login_users l ON l.username = t.username" +
                    "   WHERE t.punchin_time BETWEEN TO_DATE('" + startDate + "', 'YYYY-MM-DD') AND TO_DATE('" + enddate + "', 'YYYY-MM-DD')  UNION ALL SELECT DISTINCT" +
                    " TO_CHAR(s.leave_date, 'DD-Mon-YYYY') AS Punchin_Time,s.username AS Emp_Code,l.log_user AS Emp_Name,'--' AS In_Time,'--' AS Out_Time,case when s.status=1 then 'Sanctioned'" +
                    "  when s.cancel_status = 1 then 'Cancelled' when s.status = 0 then 'Rejected' when s.status is null or s.status = '' then " +
                    " 'applied' else 'Absent' end AS status,s.leave_date AS Punchin_Date " +
                    " FROM macare_leave_apply_table s JOIN Login_users l ON l.username = s.username  WHERE s.leave_date BETWEEN TO_DATE('" + startDate + "', 'YYYY-MM-DD') AND TO_DATE('" + enddate + "', 'YYYY-MM-DD'))" +
                    " ORDER BY Punchin_Date");

            }
            else
            {
                query = ("select * from(select distinct TO_CHAR(punchin_time,'DD-Mon-YYYY') Punchin_Time,t.username as Emp_Code,l.log_user AS Emp_Name," +
                   "TO_CHAR(punchin_time, ' HH12:MI:SS AM') AS In_Time, TO_CHAR(t.punchout_time, ' HH12:MI:SS AM') AS Out_Time, CASE WHEN t.punchin_time IS  NULL " +
                   " AND t.punchout_time IS NULL THEN 'Absent' WHEN t.punchout_time IS NULL THEN 'Non-Marking Evening' ELSE '---' END AS status from TEMPORARY_PUNCHING t" +
                   " join Login_users l on  l.username = t.username where to_date(t.punchin_time,'dd-mm-yyyy') between to_date('" + startDate + "','YYYY-mm-DD') and " +
                   " to_date('" + enddate + "','YYYY-mm-DD') and t.username = '" + empcode + "' union all" +
                   " select distinct TO_CHAR(s.leave_date,'DD-Mon-YYYY') as Punchin_Time,  s.username as Emp_Code,l.log_user AS Emp_Name,'--' as In_Time,'--' as Out_Time," +
                   "case when s.status=1 then 'Sanctioned'" +
                    "  when s.cancel_status = 1 then 'Cancelled' when s.status = 0 then 'Rejected' when s.status is null or s.status = '' then " +
                    " 'applied' else 'Absent' end AS status from " +
                   " macare_leave_apply_table s join Login_users l on l.username = s.username where to_date(s.leave_date, 'DD-MM-YYYY') " +
                   " between to_date('" + startDate + "','YYYY-MM-DD') and to_date('" + enddate + "','YYYY-MM-DD')  and s.username = '" + empcode + "'" +
                   " union all SELECT DISTINCT TO_CHAR(cal.date_day, 'DD-Mon-YYYY') AS Punchin_Time,COALESCE(t.username, '') AS Emp_Code," +
                   " COALESCE(l.log_user, '') AS Emp_Name, COALESCE(TO_CHAR(t.punchin_time, 'HH12:MI:SS AM'), '') AS In_Time, " +
                   " COALESCE(TO_CHAR(t.punchout_time, 'HH12:MI:SS AM'), '') AS Out_Time,CASE WHEN ml.username IS NOT NULL THEN 'On Leave' " +
                   " WHEN t.punchin_time IS NOT NULL AND t.punchout_time IS NOT NULL THEN 'Present'  WHEN t.punchin_time IS NOT NULL " +
                   " AND t.punchout_time IS NULL THEN 'Non-Marking Evening' ELSE 'Absent' END AS statusF FROM(SELECT" +
                   " TO_DATE('" + startDate + "', 'YYYY-MM-DD') +LEVEL - 1 AS date_day   FROM DUAL CONNECT BY LEVEL <= " +
                   "LAST_DAY(TO_DATE('" + startDate + "', 'YYYY-MM-DD')) - TO_DATE('" + startDate + "', 'YYYY-MM-DD') + 1) cal LEFT JOIN TEMPORARY_PUNCHING t " +
                   " ON TO_DATE(t.punchin_time, 'DD-MM-YYYY') = cal.date_day AND t.username = '" + empcode + "' LEFT JOIN Login_users l ON l.username = t.username " +
                   " LEFT JOIN macare_leave_apply_table ml ON ml.username = '" + empcode + "' AND cal.date_day = TO_DATE(ml.leave_date, 'DD-MM-YYYY')" +
                   " WHERE t.username IS NULL AND ml.username IS NULL" +
                   " and to_date(cal.date_day, 'dd-MM-yyyy') between to_date('" + startDate + "','yyyy-MM-dd') and to_date('" + enddate + "', 'yyyy-MM-dd') ORDER BY Punchin_Time ) ORDER BY " +
                   " TO_DATE(Punchin_Time, 'DD-MM-YYYY') ASC ");
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        //[WebMethod]
        //public DataSet GetLeaveUserDetails(string current_month)
        //{
        //    DataSet DS = new DataSet();
        //    string query = "";
        //    query = ("WITH LeaveData AS (SELECT TO_NUMBER(t.username) AS username,l.log_user,TO_DATE(t.leave_date, 'DD-MM-YYYY') AS leave_date" +
        //        " FROM macare_leave_apply_table t JOIN login_users l ON TO_NUMBER(l.username) = TO_NUMBER(t.username)   WHERE(t.status IS NULL OR t.status = '')" +
        //        " AND EXTRACT(MONTH FROM TO_DATE(t.leave_date, 'DD-MM-YYYY')) = EXTRACT(MONTH FROM to_date('"+current_month+"', 'dd-mm-yyyy'))" +
        //        " AND EXTRACT(YEAR FROM TO_DATE(t.leave_date, 'DD-MM-YYYY')) = EXTRACT(YEAR FROM to_date('" + current_month + "', 'dd-mm-yyyy'))),RankedData " +
        //        " AS(SELECT username, log_user, leave_date, leave_date -DENSE_RANK() OVER(PARTITION BY username ORDER BY leave_date) AS grp" +
        //        " FROM LeaveData)SELECT username, log_user, MIN(leave_date) AS fromDate, MAX(leave_date) AS toDate FROM RankedData GROUP BY username, log_user," +
        //        " grp ORDER BY username, fromDate");
        //    DS = ObjOrclHelper.ExecuteDataSet(query);
        //    return DS;
        //}

        [WebMethod]
        public DataSet GetLeaveUserDetails(string current_month)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("SELECT (x.username || '-' || x.log_user || '-' ||( MIN(TO_DATE(x.leave_date, 'DD-MM-YYYY')) ||'-'||MAX(TO_DATE(x.leave_date, 'DD-MM-YYYY'))))as userData," +
                "x.username , x.log_user, MIN(TO_DATE(x.leave_date, 'DD-MM-YYYY')) AS fromDate,MAX(TO_DATE(x.leave_date, 'DD-MM-YYYY')) AS toDate" +
                ",to_char(x.apply_date,'dd-mm-yyyy')apply_date,x.reason,x.leave_type" +
                " FROM(SELECT TO_NUMBER(t.username) AS username, l.log_user, TO_DATE(t.leave_date, 'DD-MM-YYYY') AS leave_date," +
                "to_date(t.apply_date,'dd-mm-yyyy')apply_date,t.reason,t.leave_type, leave_date - DENSE_RANK() " +
                " OVER(PARTITION BY TO_NUMBER(t.username) ORDER BY TO_DATE(t.leave_date, 'DD-MM-YYYY')) AS grp  FROM macare_leave_apply_table t " +
                " JOIN login_users l ON TO_NUMBER(l.username) = TO_NUMBER(t.username) WHERE(t.status IS NULL OR t.status = '') AND " +
                "  EXTRACT(MONTH FROM TO_DATE(t.leave_date, 'DD-Mon-YYYY')) = EXTRACT(MONTH FROM DATE'" + current_month + "')" +
                " AND EXTRACT(YEAR FROM TO_DATE(t.leave_date, 'DD-MM-YYYY')) = EXTRACT(YEAR FROM TO_DATE('" + current_month + "', 'YYYY-MM-DD')) and t.CANCEL_STATUS!=1) x " +
                " GROUP BY username, log_user, grp,x.apply_date,x.reason,x.leave_type ORDER BY username, fromDate");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet GetLeaveUserDetailsForCancel(string current_month, string Emp_code)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("SELECT (x.username || '-' || x.log_user || '-' ||( MIN(TO_DATE(x.leave_date, 'DD-MM-YYYY')) ||'-'||MAX(TO_DATE(x.leave_date, 'DD-MM-YYYY'))))as userData," +
                "x.username , x.log_user, MIN(TO_DATE(x.leave_date, 'DD-MM-YYYY')) AS fromDate,MAX(TO_DATE(x.leave_date, 'DD-MM-YYYY')) AS toDate" +
                ",to_char(x.apply_date,'dd-mm-yyyy')apply_date,x.reason,x.leave_type" +
                " FROM(SELECT TO_NUMBER(t.username) AS username, l.log_user, TO_DATE(t.leave_date, 'DD-MM-YYYY') AS leave_date," +
                "to_date(t.apply_date,'dd-mm-yyyy')apply_date,t.reason,t.leave_type, leave_date - DENSE_RANK() " +
                " OVER(PARTITION BY TO_NUMBER(t.username) ORDER BY TO_DATE(t.leave_date, 'DD-MM-YYYY')) AS grp  FROM macare_leave_apply_table t " +
                " JOIN login_users l ON TO_NUMBER(l.username) = TO_NUMBER(t.username) WHERE(t.status IS NULL OR t.status = '') AND " +
                "  EXTRACT(MONTH FROM TO_DATE(t.leave_date, 'DD-Mon-YYYY')) = EXTRACT(MONTH FROM DATE'" + current_month + "')" +
                " AND EXTRACT(YEAR FROM TO_DATE(t.leave_date, 'DD-MM-YYYY')) = EXTRACT(YEAR FROM TO_DATE('" + current_month + "', 'YYYY-MM-DD'))" +
                " and t.username='" + Emp_code + "' and  t.CANCEL_STATUS!=1) x " +
                " GROUP BY username, log_user, grp,x.apply_date,x.reason,x.leave_type ORDER BY username, fromDate");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet GetLeaveUserDetailsForuser(string SelectData, string current_month)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("SELECT (x.username || '-' || x.log_user || '-' ||( MIN(TO_CHAR(x.leave_date, 'DD-MM-YYYY')) ||'-'||MAX(TO_CHAR(x.leave_date, 'DD-MM-YYYY'))))as userData," +
                "x.username , x.log_user, MIN(TO_CHAR(x.leave_date, 'DD-MM-YYYY')) AS fromDate,MAX(TO_CHAR(x.leave_date, 'DD-MM-YYYY')) AS toDate" +
                ",to_char(x.apply_date,'dd-mm-yyyy')apply_date,x.reason,x.leave_type,x.designation,x.branch_name" +
                " FROM(SELECT TO_NUMBER(t.username) AS username, l.log_user, TO_DATE(t.leave_date, 'DD-MM-YYYY') AS leave_date," +
                "to_date(t.apply_date,'dd-mm-yyyy')apply_date,t.reason,t.leave_type,l.designation,mi.branch_name, leave_date - DENSE_RANK() " +
                " OVER(PARTITION BY TO_NUMBER(t.username) ORDER BY TO_DATE(t.leave_date, 'DD-MM-YYYY')) AS grp  FROM macare_leave_apply_table t " +
                " JOIN login_users l ON TO_NUMBER(l.username) = TO_NUMBER(t.username) join macare_unitmaster mi on mi.branch_id=l.branchid " +
                "WHERE(t.status IS NULL OR t.status = '') AND mi.branch_type not in('Clinic') and " +
                "  EXTRACT(MONTH FROM TO_DATE(t.leave_date, 'DD-Mon-YYYY')) = EXTRACT(MONTH FROM DATE'" + current_month + "')" +
                " AND EXTRACT(YEAR FROM TO_DATE(t.leave_date, 'DD-MM-YYYY')) = EXTRACT(YEAR FROM TO_DATE('" + current_month + "', 'YYYY-MM-DD'))) x " +
                " GROUP BY username, log_user, grp,x.apply_date,x.reason,x.leave_type,x.designation,x.branch_name " +
                "HAVING (x.username || '-' || x.log_user || '-' || MIN(TO_DATE(x.leave_date, 'DD-MM-YYYY')) || '-' || MAX(TO_DATE(x.leave_date, 'DD-MM-YYYY'))) =" +
                "'"+SelectData+"' ORDER BY username, fromDate");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public int UpdateLeaveApplicationStatus(string Username, string ApprovedStatus,string fromDate,string ToDate, string Remarks)
        {
            string query; int res;
            query = "update macare_leave_apply_table set status='" + ApprovedStatus + "',remarks='"+Remarks+"' where USERNAME='" + Username + "'" +
                "and leave_date BETWEEN TO_DATE('"+fromDate+ "', 'DD-MM-YYYY') AND TO_DATE('" + ToDate + "', 'DD-MM-YYYY') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet GetLeaveAppliedCount(string Username,string Current_month)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select count(distinct t.leave_date) as applied_count from macare_leave_apply_table t where t.username='" + Username+"'  " +
                " and EXTRACT(MONTH FROM TO_DATE(t.leave_date, 'DD-Mon-YYYY')) = EXTRACT(MONTH FROM DATE'" + Current_month + "')" +
                " AND EXTRACT(YEAR FROM TO_DATE(t.leave_date, 'DD-MM-YYYY')) = EXTRACT(YEAR FROM TO_DATE('" + Current_month + "', 'YYYY-MM-DD'))");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet GetLeaveSanctionedCount(string Username, string Current_month)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select count(distinct y.leave_date) as sanctioned_count,to_number(x.leave_days)-count(distinct y.leave_date), " +
                " case when to_number(x.leave_days)-count(distinct y.leave_date) > 0  then to_number(x.leave_days) -count(distinct y.leave_date)else 0 " +
                " end as Remaining_leaves,x.leave_days from(select* from  TEMP_SALARY_CALCULATION t   where t.username= '"+Username+"')x" +
                "  left join(select * from macare_leave_apply_table l where l.username = '" + Username + "'   and" +
                "   EXTRACT(MONTH FROM TO_DATE(l.leave_date, 'DD-Mon-YYYY')) = EXTRACT(MONTH FROM DATE '"+ Current_month + "')" +
                "  AND EXTRACT(YEAR FROM TO_DATE(l.leave_date, 'DD-MM-YYYY')) = EXTRACT(YEAR FROM TO_DATE('" + Current_month + "', 'YYYY-MM-DD'))" +
                "    and l.status = 1)y on y.username = x.username group by y.username,x.leave_days  ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int UpdateLeaveCancelStatus(string Username, string CancelStatus, string fromDate, string ToDate)
        {
            string query; int res;
            query = "update macare_leave_apply_table set CANCEL_STATUS='" + CancelStatus + "' where USERNAME='" + Username + "'" +
                "and leave_date BETWEEN TO_DATE('" + fromDate + "', 'DD-MM-YYYY') AND TO_DATE('" + ToDate + "', 'DD-MM-YYYY') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }


        [WebMethod]
        public DataSet ViewStatusOfLeave(string Username, string From_date,string To_date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select  distinct id,username,to_char(apply_date,'dd-mm-yyyy')apply_date,to_char(leave_date,'dd-mm-yyyy')leave_date,reason,case when status=1 then 'Approved' when status=0 then 'Rejected' else 'Pending' end As " +
                " Approve_Status, remarks, leave_type,case when cancel_status = 1 then 'Cancelled' when cancel_status = 0 then 'Applied' else '--' end as " +
                " Cancel_Status,status,cancel_status  from macare_leave_apply_table where username='" + Username+"'  and leave_date BETWEEN TO_DATE('"+From_date+"', 'DD-MM-YYYY') " +
                " AND TO_DATE('"+To_date+"', 'DD-MM-YYYY')");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_branchesMicrolab()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from macare_unitmaster where branch_type in ('Microlab') ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod]
        public DataSet Get_TempStaffDetails(string username)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from login_users l  join macare_unitmaster m on m.branch_id=l.branchid where active=1 and l.username='"+username+ "' and  branch_type not in ('Lab') ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod]
        public DataSet Get_TempStaffPersonalDetails(string username)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select id, USERNAME,address,to_char(date_of_joining,'dd-mm-yyyy')date_of_joining,to_char(dob,'dd-mm-yyyy')dob  from MACARE_TEMP_STAFFS_DETAILS where USERNAME='" + username+"' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public int UpdateTempPersonalData(string Address, string DateOfJoining, string DateOfBirth, string EmpCode)
        {
            string query; int res;
            query = "update MACARE_TEMP_STAFFS_DETAILS set address='" + Address + "',date_of_joining='" + DateOfJoining + "',dob='" + DateOfBirth + "' where username='" + EmpCode + "' ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }


        [WebMethod]

        public int insertTempPersonalData(string Address, string DateOfJoining, string DateOfBirth, string EmpCode)
        {
            int res = 0;
            int id = 0;
            string query = "";
            query = "SELECT NVL(MAX(TO_NUMBER(ID)), 0) + 1 from MACARE_TEMP_STAFFS_DETAILS";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into MACARE_TEMP_STAFFS_DETAILS (id,USERNAME,address,date_of_joining,dob) values('" + id + "','" + EmpCode + "','" + Address + "','" + DateOfJoining + "'" +
                ",'" + DateOfBirth + "') ";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet Get_TempStaffPersonalReport()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct m.branch_name as Branch_Name,s.USERNAME as Emp_Code,l.log_user as Emp_Name,s.address as Address," +
                " to_char(s.date_of_joining,'dd-mm-yyyy')Date_of_Joining,to_char(s.dob,'dd-mm-yyyy')DOB from login_users l  " +
                " join MACARE_TEMP_STAFFS_DETAILS s on s.username = l.username join macare_unitmaster m on m.branch_id = l.branchid " +
                " where m.branch_type not in ('Clinic') ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

    }
}

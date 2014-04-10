using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCMS
{
    public partial class FacultyPage : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection conDatabase;
        SqlCommand cmd;
        int checkID;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkID = Convert.ToInt32(Session["UserId"]);
            CreateConnection();
            cmd = new SqlCommand();
            cmd.CommandText = "Select FirstName + ' ' + LastName As FullName FROM Users where UserID=" + checkID;

            cmd.Connection = conDatabase;

            try
            {
                OpenConnection();

                LblWelcome.ForeColor = System.Drawing.Color.Black;
                LblWelcome.Text = "Log in as : " + cmd.ExecuteScalar().ToString();

                LblDate.Text = "Today's Date : " + DateTime.Now.ToShortDateString();
                LblDate.ForeColor = System.Drawing.Color.Black;

                recordDateV.Text = DateTime.Now.ToShortDateString();

                if (checkID >= 1)
                {
                    displaySubjectLinkFaculty(checkID);

                }
            }
            finally
            {
                CloseConnection();
            }
        }


        private void displaySubjectLinkFaculty(int checkID)
        {
            CreateConnection();
            cmd = new SqlCommand();
            cmd.CommandText = "Select F.Fid,R.SectionName,B.BatchName,Sb.SubName from faculty F inner join routine R on F.Fid=R.Fid inner join Batch B on R.BatchId = B.BatchId inner join Subject Sb on Sb.SubjectId=R.SubjectId where F.UserId=" + checkID;
            cmd.Connection = conDatabase;

            try
            {
                OpenConnection();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string sectionName = sdr["SectionName"].ToString();
                    string batchName = sdr["BatchName"].ToString();
                    string subjectName = sdr["SubName"].ToString();
                    lnksubject.Text = batchName + ' ' + sectionName + ' ' + subjectName;
                    Session["SubName"] = subjectName;
                    Session["Fid"] = checkID;
                    
                }

            }
            finally
            {
                CloseConnection();
            }

        }


        #region SQL Connection
        public void CreateConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            conDatabase = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            conDatabase.Open();
        }

        public void CloseConnection()
        {
            conDatabase.Close();
        }

        #endregion

        protected void Faculty_Calendar_Button_Click(object sender, ImageClickEventArgs e)
        {

            if (calendar.Visible)
            {
                calendar.Visible = false;
            }
            else
            {
                calendar.Visible = true;
            }
        }

        protected void Faculty_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            recordDateV.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
        }

        protected void sublink(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceEntry.aspx");
        }

    }
}


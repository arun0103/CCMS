using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCMS
{

    public partial class AddRoutine : System.Web.UI.Page
    {
        string connectionString;
        private DataService objDataService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindFacultyDropdown();
                BindClassDropdown();
                BindSemesterDropDown();
            }
        }

        public void ClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BatchName = ClassList.SelectedValue;

            String connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT Year, Semester, Section  FROM  batch WHERE GETDATE() <=EndDate And BatchName = @BatchName";
            cmd.Parameters.AddWithValue("@BatchName", ClassList.SelectedItem.ToString());
            section_drp.Enabled = true;
            section_drp.SelectedIndex = 0;
            try
            {

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int count = 0;
                    while (dr.Read())
                    {
                        count++;

                        YearList.SelectedIndex = Convert.ToInt32(dr["Year"]);
                        YearList.Enabled = false;

                        Semester_drp.SelectedValue = Convert.ToString(dr["Semester"]);
                        Semester_drp.Enabled = false;
                    }
                    if (count <2 ) // this shows there is only one section, so that section is selected and made not modifiable
                    {
                        section_drp.SelectedIndex = 3;
                        section_drp.Enabled = false;
                    }


                    dr.Close();
                }

            }
            catch
            {
                Console.WriteLine("Some exception Occured");
            }
            finally
            {
                con.Close();
            }
            Semester_drp_SelectedIndexChanged(sender, e);

        }

        public void BindClassDropdown()
        {
            string command = "Select BatchId, BatchName from batch";
            DataTable ClassTable = new DataTable();
            objDataService = new DataService();

            ClassTable = objDataService.GetDataWithoutParameter(command);
            ClassList.DataValueField = "BatchId";
            ClassList.DataTextField = "BatchName";
            ClassList.DataSource = ClassTable;

            ClassList.DataBind();
            ClassList.Items.Insert(0, new ListItem("--- Select Class ---", "0"));


        }
        public void BindFacultyDropdown()
        {
            string command = "Select Fid, FirstName + ' ' + LastName as FacultyName from faculty";
            DataTable FacultyTable = new DataTable();
            objDataService = new DataService();

            FacultyTable = objDataService.GetDataWithoutParameter(command);

            FacultyList.DataValueField = "Fid";
            FacultyList.DataTextField = "FacultyName";
            FacultyList.DataSource = FacultyTable;
            FacultyList.DataBind();
            FacultyList.Items.Insert(0, new ListItem("--- Select Faculty ---", "0"));


        }
        public void BindSemesterDropDown()
        {
            string command = "Select distinct Semester from Syllabus";

            DataTable SemesterTable = new DataTable();
            objDataService = new DataService();

            SemesterTable = objDataService.GetDataWithoutParameter(command);
            Semester_drp.DataValueField = "Semester";
            Semester_drp.DataTextField = "Semester";
            Semester_drp.DataSource = SemesterTable;
            Semester_drp.DataBind();
            Semester_drp.Items.Insert(0, new ListItem("--- Select Semester ---", "0"));

        }
        //public int findFid(string FacultyName)
        //{

        //    connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        //    string query = "Select FId from faculty where FirstName + ' ' + LastName = @FacultyName";
        //    SqlCommand cmd = new SqlCommand { CommandText = query };
        //    cmd.Parameters.AddWithValue("@FacultyName", FacultyName);
        //    string[] parameter = new string[] { FacultyName };

        //    DataService ds1 = new DataService();

        //    DataTable result = ds1.GetDataWithParameters(cmd);
        //    int FacultyID = Convert.ToInt32(result.Rows[0]["FId"].ToString());
        //    return FacultyID;
        //}
        protected void RoutineAddBtn_Click(object sender, EventArgs e)
        {
            RFV_ClassList.Enabled = true;
            RFV_FacultyList.Enabled = true;
            RFV_section_drp.Enabled = true;
            RFV_Semester_drp.Enabled = true;
            RFV_subjectlist_drp.Enabled = true;
            RFV_YearList.Enabled = true;
            Page.Validate();
            //if (Page.IsValid)
            //{
                
            //    //Reset();

            //}

            if (ClassList.SelectedIndex != 0 && FacultyList.SelectedIndex != 0 && section_drp.SelectedIndex != 0 && Semester_drp.SelectedIndex != 0 && subjectlist_drp.SelectedIndex != 0 && YearList.SelectedIndex != 0)
            {

                Routine routine = new Routine
                {
                    Fid = Convert.ToInt16(FacultyList.SelectedValue),
                    ClassId = Convert.ToInt16(ClassList.SelectedValue),
                    EnrollYear = YearList.SelectedItem.Text,
                    Semester = Semester_drp.SelectedItem.Text,
                    SubjectID = subjectlist_drp.SelectedItem.Value,
                    SectionName = section_drp.SelectedItem.Text
                };

                int added = CCMSBusinessLayer.AddRoutine(routine);

                if (added > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success !! ", "alert('Routine details has been added.');", true);
                }
                connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                string sqlQuery = "select routine.routineId, faculty.FirstName + ' ' + faculty.LastName as FacultyName from routine inner join faculty on routine.Fid = faculty.FId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    RoutineGridView.DataSource = rdr;
                    RoutineGridView.DataBind();
                }
                ContentPlaceHolder mcon = new ContentPlaceHolder();
                mcon = (ContentPlaceHolder)Master.FindControl("pageContent2");
                mcon.Visible = true;
            }
                //DataService objDataService = new DataService();
                //string sqlQuery1 = "INSERT INTO routine(Fid,BatchID,EnrollYear, Semester, SubjectID, SectionName) VALUES (@Fid,@BatchID,@yeartb,@Semester,@SubjectID,@SectionName)";

                ////int FacultyID = findFid(FacultyList.Text);
                //SqlCommand dataCommand1 = new SqlCommand();
                ////dataCommand1.CommandType = CommandType.Text;
                ////dataCommand1.CommandText = findFid;

                //dataCommand1.CommandType = CommandType.Text;
                //dataCommand1.CommandText = sqlQuery1;

                //dataCommand1.Parameters.AddWithValue("@Fid", FacultyList.SelectedItem.Value);
                //dataCommand1.Parameters.AddWithValue("@BatchID", BatchList.SelectedItem.Value);
                //dataCommand1.Parameters.AddWithValue("@yeartb", YearList.SelectedItem.Text);
                //dataCommand1.Parameters.AddWithValue("@Semester", Semester_drp.SelectedItem.Text);
                //dataCommand1.Parameters.AddWithValue("@SubjectID", subjectlist_drp.SelectedItem.Value);
                //dataCommand1.Parameters.AddWithValue("@SectionName", section_drp.SelectedItem.Text);

                /* Need to modify .... Donot delete this comment*/
                /************** Warning ******************************/
                //int affectedRowsOfRoutine = objDataService.InsertIntoDatabase(dataCommand1);

                //if (affectedRowsOfRoutine > 0)
                //{
                //    //updateMsg.Visible = true;
                //    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Routine Details has been added.');", true);
                //}
            


        }
        public void clear()
        {
            FacultyList.SelectedIndex = 0;
            ClassList.SelectedIndex = 0;
            YearList.SelectedIndex = 0;
            section_drp.SelectedIndex = 0;
            Semester_drp.SelectedIndex = 0;
            subjectlist_drp.SelectedIndex = 0;

            RFV_ClassList.Enabled = false;
            RFV_FacultyList.Enabled = false;
            RFV_section_drp.Enabled = false;
            RFV_Semester_drp.Enabled = false;
            RFV_subjectlist_drp.Enabled = false;
            RFV_YearList.Enabled = false;

            section_drp.Enabled = true;
            Semester_drp.Enabled = true;
            YearList.Enabled = true;
        }

        protected void clearBtn_Routine(object sender, EventArgs e)
        {
            clear();
        }

       // public string connectionString1 { get; set; }

        protected void Semester_drp_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "select SubjectId, Subject_Name from Syllabus where Semester = @semester",
                CommandType = CommandType.Text
            };

            cmd.Parameters.AddWithValue("@semester", Semester_drp.SelectedItem.Text);
            DataService objDataService = new DataService();
            DataTable result = objDataService.GetDataWithParameters(cmd);
            subjectlist_drp.DataSource = result;
            subjectlist_drp.DataValueField = "SubjectId";
            subjectlist_drp.DataTextField = "Subject_Name";
            subjectlist_drp.DataBind();
            subjectlist_drp.Items.Insert(0, new ListItem("--- Select Subject ---", "0"));

        }

        protected void RoutineGrid_Edit(object sender, GridViewEditEventArgs e)
        {
            RoutineGridView.EditIndex = e.NewEditIndex;
            RoutineGridView.DataBind();
        }


    }
}
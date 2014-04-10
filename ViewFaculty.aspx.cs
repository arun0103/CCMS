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
    public partial class ViewFaculty : System.Web.UI.Page
    {
        string connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                string sqlQuery = "select * from faculty";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery,con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    FacultyGridView.DataSource = rdr;
                    FacultyGridView.DataBind();
                }
                //using (SqlConnection dataConnection = new SqlConnection(connectionString))
                //{
                //    using (SqlCommand dataCommand = dataConnection.CreateCommand())
                //    {
                //        dataConnection.Open();
                //        dataCommand.CommandType = CommandType.Text;
                //        dataCommand.CommandText = sqlQuery;
                //        //facultySet = new DataSet();
                //        //facultyTable = new DataTable();
                //        //dataCommand.Parameters.AddWithValue("@BatchName", batchName.Text);
                //        //dataCommand.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(startDate.Text));
                //        //dataCommand.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(endDate.Text));
                //        //dataCommand.Parameters.AddWithValue("@active", activeCB.Checked);
                //        //dataCommand.Parameters.AddWithValue("@CreatedBy", User.Identity.Name);
                //        //dataCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Today);
                //        //dataCommand.Parameters.AddWithValue("@BatchId", );

                //        dataCommand.ExecuteNonQuery();
                //        //dataConnection.Close();
                //    }
                //}
                //DataTable faculty = new DataTable();
                //faculty.Columns.Add("F_Id", typeof(string));
                //faculty.Columns.Add("firstName", typeof(string));
                //faculty.Columns.Add("lastName", typeof(string));
                //faculty.Columns.Add("email", typeof(string));
                //faculty.Columns.Add("user_Id", typeof(string));
                //faculty.Columns.Add("contact", typeof(string));
                //faculty.Columns.Add("Active", typeof(Boolean));

                //DataRow row = faculty.NewRow();
                //row["F_Id"] = "test";
                //faculty.Rows.Add(row);
                //FacultyGridView.Width = 200;
                //FacultyGridView.DataSource = faculty;
                //FacultyGridView.DataBind();
            }
        }
    }
}
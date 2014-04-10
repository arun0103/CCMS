using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Drawing;

namespace CCMS
{
    public partial class AddNewBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Batch batch = new Batch
            {
                BatchName = batchName.Text,
                Year = year.Text,
                Semester = ddl_semester.Text,
                Section = ddl_section.Text,
                StartDate = Convert.ToDateTime(startDate.Text),
                EndDate = Convert.ToDateTime(endDate.Text),
                Active = activeCB.Checked,
                CreatedDate = DateTime.Today,
                LastModifiedDate = DateTime.Now,
            };

            int added = CCMSBusinessLayer.AddBatch(batch);

            if (added > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success !! ", "alert('You still missed some of the required field.');", true);
                Reset();

            }
        }

        protected void startDateCalendar_SelectionChanged1(object sender, EventArgs e)
        {
            startDate.Text = startDateCalendar.SelectedDate.ToShortDateString();
            startDateCalendar.Visible = false;

            endDate.Text = startDateCalendar.SelectedDate.AddMonths(6).ToShortDateString();
        }

        protected void endDateCalendar_SelectionChanged2(object sender, EventArgs e)
        {
            endDate.Text = endDateCalendar.SelectedDate.ToShortDateString();
            endDateCalendar.Visible = false;
        }

        protected void startDateCalendar_Button_Click(object sender, ImageClickEventArgs e)
        {
            if (startDateCalendar.Visible)
            {
                startDateCalendar.Visible = false;
            }
            else
            {
                startDateCalendar.Visible = true;
                startDateCalendar.VisibleDate = DateTime.Now;
            }
        }

        protected void endDateCalendar_Button_Click(object sender, ImageClickEventArgs e)
        {
            if (endDateCalendar.Visible)
            {
                endDateCalendar.Visible = false;
            }
            else
            {
                endDateCalendar.Visible = true;
                DateTime dt = Convert.ToDateTime(endDate.Text);
                endDateCalendar.VisibleDate = dt;
            }
        }

        private void Reset()
        {
            batchName.Text = "";
            year.Text = "";
            ddl_semester.Items.Clear();
            ddl_section.Items.Clear();
            startDate.Text = "";
            endDate.Text = "";
            activeCB.Checked = false;
        }
        protected void clearBtn_Click(object sender, EventArgs e)
        {
            Reset();            
        }
    }

}


/*if (batchName.Text != "" && year.Text != null)
{
connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
string sqlQuery = "insert into batch (BatchName, Year, Semester, Section,StartDate, EndDate, Active, CreatedDate, LastModifiedDate) values (@BatchName, @Year, @Semester, @Section, @StartDate, @EndDate, @active, @CreatedDate, @LastModifiedDate)";
using (SqlConnection dataConnection = new SqlConnection(connectionString))
{
    using (SqlCommand dataCommand = dataConnection.CreateCommand())
    {
        dataConnection.Open();
        dataCommand.CommandType = CommandType.Text;
        dataCommand.CommandText = sqlQuery;

        dataCommand.Parameters.AddWithValue("@BatchName", batchName.Text);
        dataCommand.Parameters.AddWithValue("@Year", year.Text);
        dataCommand.Parameters.AddWithValue("@Semester", ddl_semester.Text);
        dataCommand.Parameters.AddWithValue("@Section", ddl_section.Text);
        dataCommand.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(startDate.Text));
        dataCommand.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(endDate.Text));
        dataCommand.Parameters.AddWithValue("@active", activeCB.Checked);

        dataCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Today);
        dataCommand.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
        //dataCommand.Parameters.AddWithValue("@BatchId", );

        dataCommand.ExecuteNonQuery();
        dataConnection.Close();
        ScriptManager.RegisterStartupScript(this, GetType(), "Success !! ", "alert('Batch is successfully recorded.');", true);
    }
}
}
else {
ScriptManager.RegisterStartupScript(this, GetType(), "Success !! ", "alert('You still missed some of the required field.');", true);
}*/
        
              
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
    public partial class AddFacultyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int findUserID(string email)
        {

            return CCMSBusinessLayer.FindUserIdfromEmail(email);
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            EmailFieldValidator.Enabled = true;

            Faculty faculty = new Faculty
            {
                Active = activeCB.Checked,
                Contact = contact.Text,
                Email = txtEmail.Text,
                LastName = lastName.Text,
                FirstName = firstName.Text,
                UserId = findUserID(txtEmail.Text)
            };

            int added = CCMSBusinessLayer.AddFaculty(faculty);

            if (added > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Faculty detail is successfully recorded.');", true);
                string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                string sqlQuery = "select * from faculty";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    FacultyGridView.DataSource = rdr;
                    FacultyGridView.DataBind();
                }
                ContentPlaceHolder mcon = new ContentPlaceHolder();
                mcon = (ContentPlaceHolder)Master.FindControl("pageContent2");
                mcon.Visible = true;
                Reset();
            }
            
        }

        private void Reset()
        {
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            contact.Text = String.Empty;
            activeCB.Checked = false;
            updateMsg.Visible = false;
        }

        protected void clearBtn_Click1(object sender, EventArgs e)
        {
            Reset();
        }
    }
}


//user_Id.Text = String.Empty;
//f_Id.Text = String.Empty;
//batch.Text = String.Empty;
// timeto.Text = String.Empty;
//section_drp.SelectedIndex = default;
//subjectlist_drp.SelectedIndex=default;
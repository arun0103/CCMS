using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCMS
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageContent2.Visible = false;
            if (Session["UserId"] == null)
            {
                btnLogout.Visible = false;
                Label emptyLabel = new Label();
                emptyLabel.Text = string.Empty;
                
            } 
            

            if (Session["Role"] != null && String.Compare(Session["Role"].ToString(),"Admin",true)==0)
            {
                
                lnkAddUser.Visible = true;
                lnkAddUser.Text = "Add User";
                lnkAddUser.PostBackUrl = "~/AddUser.aspx";

                lnkEditUser.Visible = true;
                lnkEditUser.Text = "Edit User Details";
                lnkEditUser.PostBackUrl = "~/EditUserDetails.aspx";
                
                lnkTimeEntry.Text = "Time Entry";
                lnkTimeEntry.Visible = true;
                lnkTimeEntry.PostBackUrl = "~/TimeEntry.aspx";

                lnkEditTimeSheet.Text = "Edit Time Entry";
                lnkEditTimeSheet.Visible = true;
                lnkEditTimeSheet.PostBackUrl = "~/EditTimeEntry.aspx";

                lnkAddBatch.Visible = true;
                lnkAddBatch.Text = "Add Batch";
                lnkAddBatch.PostBackUrl = "~/AddNewBatch.aspx";

                lnkAddFacultyDetail.Visible = true;
                lnkAddFacultyDetail.Text = "Add Faculty Detail";
                lnkAddFacultyDetail.PostBackUrl = "~/AddFacultyDetail.aspx";

                lnkAddRoutine.Visible = true;
                lnkAddRoutine.Text = "Add Routine";
                lnkAddRoutine.PostBackUrl = "~/AddRoutine.aspx";

                lnkViewFaculty.Visible = true;
                lnkViewFaculty.Text = "View Faculty";
                lnkViewFaculty.PostBackUrl = "~/ViewFaculty.aspx";

                lnkViewRoutine.Visible = true;
                lnkViewRoutine.Text = "View Routine";
                lnkViewRoutine.PostBackUrl = "~/viewRoutine.aspx";
                pageContent2.Visible = true;
             
           
            }
            else if (Session["Role"] != null  && String.Compare(Session["Role"].ToString() ,"User",true)==0)
            {
                
                lnkTimeEntry.Text = "Time Entry";
                lnkTimeEntry.Visible = true;
                lnkTimeEntry.PostBackUrl = "~/TimeEntry.aspx";

                lnkFacultyPage.Visible = true;
                lnkFacultyPage.Text = "Faculty";
                lnkFacultyPage.PostBackUrl = "~/FacultyPage.aspx";
               
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}
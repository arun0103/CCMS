using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.Services.Description;
using CCMS;


namespace MyCCMS
{
    public partial class addUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void DropDownRole_TextChanged(object sender, EventArgs e)
        {
            // code to be displayed in the same page.
           

        }

        private void Reset()
        {
            txtEmail.Text = String.Empty;
            txtFirstname.Text = String.Empty;
            txtLastname.Text = String.Empty;
            txtContact.Text = String.Empty;
            DropDownRole.SelectedIndex = 0;
            chkActive.Checked = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
        }

        #region Save user
        protected void Button1_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
            Page.Validate();
            if (Page.IsValid)
            {
                if (CCMSBusinessLayer.isExistingUser(txtEmail.Text))
                {
                   Save();
                  // BindGrid();
                }

                else
                {
                   // ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Record already exist. ');", true);
                }
                Reset();
           
            }
        }

        #endregion
        

       
        public int findUserID(string email)
        {

            return CCMSBusinessLayer.FindUserIdfromEmail(email);
        }
        private void Save()
        {
            User newUser = new User { Active = chkActive.Checked, Contact = txtContact.Text , Email = txtEmail.Text , FirstName = txtFirstname.Text,
                                     LastName = txtLastname.Text, Role = DropDownRole.SelectedItem.Text};
                          
          int affectedRows = CCMSBusinessLayer.AddUser(newUser);        
          if (affectedRows > 0)
                        {
                            
                            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('User Successfully Saved');", true);

                           

                                  
                                    ContentPlaceHolder mcon = new ContentPlaceHolder();
                                    mcon = (ContentPlaceHolder)Master.FindControl("pageContent2");
                                    mcon.Visible = true;
                                    Reset();
                                
                            
                        }
                    }


        //public void BindGrid()
        //{
        //    DataTable Users = CCMSBusinessLayer.GetUsers("faculty");
        //    FacultyGridView.DataSource = Users;
        //    FacultyGridView.DataBind();
        //}
                  
    }
}








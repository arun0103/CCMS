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
    public partial class Login : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void UserLogin(object sender, EventArgs e)
       {
           String cmdStr = null;
           string concatenateDomain = "@deerwalk.edu.np";
           SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);

           //check whether the username contains @deerwalk.edu.np
           if (txtUserName.Text.Contains('@'))
           {
               cmdStr = "select UserId from Users where userEmail = '" + txtUserName.Text + "'";
           }
           else
           {
               cmdStr = "select UserId from Users where userEmail = '" + txtUserName.Text + concatenateDomain + "'";
           }
            
           SqlCommand CheckUser = new SqlCommand(cmdStr, con);
            con.Open();


            object UserID = CheckUser.ExecuteScalar();
            if (UserID != null)
            {
                if (Convert.ToInt32(UserID.ToString()) >= 1)
                {
                    String cmdStr2 = "select password,Role from Users where password  = '" + txtPassword.Text + "' and UserId = " + UserID;
                    SqlCommand pass = new SqlCommand(cmdStr2, con);
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    DataTable userDetail = new DataTable();
                    sqlAdapter.SelectCommand = pass;
                    sqlAdapter.Fill(userDetail);
                    
                    
                    if (userDetail.Rows.Count > 0)
                    {
                        string password = userDetail.Rows[0][0].ToString();


                        if (password == txtPassword.Text)
                        {

                            Session["UserId"] = UserID;
                            Session["Role"] = userDetail.Rows[0][1].ToString();
                            Response.Redirect("TimeEntry.aspx");
                            

                            
                        }
                        
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "Invalid password .........!!";
                    }
                    con.Close();

                   
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Invalid userName.....!!";

            }

            
        }

    }
    
    }
        

      
         
      

        
        

    

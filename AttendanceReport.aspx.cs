using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCMS
{
    public partial class AttendanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFacultyDropdown();
                BindStudentDropdown();
            }
            
        }

        private void BindFacultyDropdown()
        {
            DataService objDataService = new DataService();
           
            objDataService.BindFaculty(facultyV);
            facultyV.Items.Insert(0,new ListItem("All Teachers","0"));
            
            
        }
        private void BindStudentDropdown()
        {
            DataService objDataService = new DataService();
            
            objDataService.BindStudent(studentV);
            studentV.Items.Insert(0,new ListItem("All Students","0"));
        }
        protected void showReport_Click(object sender, EventArgs e)
        {
            CCMSBusinessLayer cb = new CCMSBusinessLayer();
            DataTable dt = new DataTable();
            
            dt = cb.GetClassCount(Convert.ToInt32(facultyV.Text), startDate.Text, endDate.Text);

            lblText.Visible = true;
            lblText.Text = "Total classes taken : "+dt.Rows.Count.ToString();

        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            facultyV.SelectedIndex = 0;
            studentV.SelectedIndex = 0;
            startDate.Text = "";
            endDate.Text = "";
            
        }
        protected void startDateCalendar_SelectionChanged1(object sender, EventArgs e)
        {
            
            startDate.Text = startDateCalendar.SelectedDate.ToShortDateString();
            startDateCalendar.Visible = false;
        }

        protected void endDateCalendar_SelectionChanged2(object sender, EventArgs e)
        {
            endDate.Text = endDateCalendar.SelectedDate.ToShortDateString();
            endDateCalendar.Visible = false;
            endDateCalendar.VisibleDate = DateTime.Now;
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
                endDateCalendar.VisibleDate = DateTime.Now;
            }
        }

        
    }
}
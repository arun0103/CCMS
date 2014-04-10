using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Net.Mail;
using System.Data;
namespace CCMS
{
    public class CCMSBusinessLayer
    {
        string connectionString;
        SqlConnection conDatabase;
        SqlCommand cmd; 
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

        public SqlDataReader GetStudentListForAttendance()
        {
            CreateConnection();
            cmd = new SqlCommand();
            cmd.CommandText = "Select RollNo, FirstName + ' ' + LastName As Name from students";

            cmd.Connection = conDatabase;


            try
            {
                OpenConnection();

                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;
            }

            catch
            {
                throw new Exception();
                
            }
            
        }

        public SqlDataReader EditStudentListForAttendance(string changeDate)
        {

            CreateConnection();
            cmd = new SqlCommand();
            cmd.CommandText = "select S.RollNo,E.FirstName+' '+E.LastName as Name,S.Attendance from StudentAttendance S inner join students E on S.RollNo = E.RollNo where convert(varchar(10) , AttendanceDate, 120) = @changeDate";
            cmd.Parameters.AddWithValue("@changeDate", changeDate);

            cmd.Connection = conDatabase;




            try
            {
                OpenConnection();

                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;

            }

            catch
            {
                throw new Exception();

            }


        }

        internal string getMd5Hash(System.Security.Cryptography.MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static int FindUserIdfromEmail(string email)
        {

            int UserId = 0;
            string query = "select UserID from Users Where UserEmail = @email";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@email",email);

            UserId = Convert.ToInt32(DataService.ReadDatabaseSingle(query, param));
           
            return UserId;
            
        }

        public static int AddFaculty(Faculty faculty)
        {
            int inserted = 0;
            string sqlQuery = "insert into Faculty (UserId,FirstName,LastName,Email,Contact, Active) values ( @UserID, @FirstName, @LastName, @Email, @Contact, @active)";
            SqlParameter[] parameter = new SqlParameter[6];
                   //dataCommand.Parameters.AddWithValue("@FId", f_Id.Text);
                   parameter[0] = new SqlParameter("@UserId", faculty.UserId);
                   parameter[1] = new SqlParameter("@FirstName",faculty.FirstName);
                   parameter[2] = new SqlParameter("@LastName", faculty.LastName);
                   parameter[3] = new SqlParameter("@Email", faculty.Email);
                   parameter[4] = new SqlParameter("@Contact", faculty.Contact);
                   parameter[5] = new SqlParameter("@Active", faculty.Active);

                   inserted = DataService.InsertIntoDatabase(sqlQuery, parameter);

            return inserted;
        }

        public static int AddBatch(Batch batch)
        {
            int inserted = 0;
            string sqlQuery = "insert into batch (BatchName, Year, Semester, Section,StartDate, EndDate, Active, CreatedDate, LastModifiedDate) values (@BatchName, @Year, @Semester, @Section, @StartDate, @EndDate, @active, @CreatedDate, @LastModifiedDate)";
            SqlParameter[] parameter = new SqlParameter[9];

            parameter[0] = new SqlParameter("@BatchName", batch.BatchName);
            parameter[1] = new SqlParameter("@Year", batch.Year);
            parameter[2] = new SqlParameter("@Semester", batch.Semester);
            parameter[3] = new SqlParameter("@Section", batch.Section);
            parameter[4] = new SqlParameter("@StartDate", batch.StartDate);
            parameter[5] = new SqlParameter("@EndDate", batch.EndDate);
            parameter[6] = new SqlParameter("@active", batch.Active);
            parameter[7] = new SqlParameter("@CreatedDate", batch.CreatedDate);
            parameter[8] = new SqlParameter("@LastModifiedDate", batch.LastModifiedDate);

            inserted = DataService.InsertIntoDatabase(sqlQuery, parameter);

            return inserted;
        }

        public static int AddRoutine(Routine routine)
        {
            int inserted = 0;
            string sqlQuery = "INSERT INTO routine(Fid,ClassId,EnrollYear, Semester, SubjectID, SectionName) VALUES (@Fid,@ClassId,@yeartb,@Semester, @SubjectID, @SectionName)";
            SqlParameter[] parameter = new SqlParameter[6];

            parameter[0] = new SqlParameter("@Fid", routine.Fid);
            parameter[1] = new SqlParameter("@ClassID", routine.ClassId);
            parameter[2] = new SqlParameter("@yeartb", routine.EnrollYear);
            parameter[3] = new SqlParameter("@Semester", routine.Semester);
            parameter[4] = new SqlParameter("@SubjectID", routine.SubjectID);
            parameter[5] = new SqlParameter("@SectionName", routine.SectionName);

            inserted = DataService.InsertIntoDatabase(sqlQuery, parameter);

            return inserted;
        }

        public static bool isExistingUser(string email)
        {

            string sqlQuery = "select userId from Users where email= @email";
            SqlParameter[] parameter = new SqlParameter[6];

            parameter[0] = new SqlParameter("@email", email);
           

            string UserId = DataService.ReadDatabaseSingle(sqlQuery, parameter);

            if (UserId != String.Empty)
            {
                return true;
            }
            return false;
        }

        #region Add User

        public static int AddUser(User user)
        { 
             
            int inserted = 0;
            user.Password = GetRandomPassword(5);
            string sqlQuery = "INSERT INTO users(userEmail,Password,FirstName,LastName,active,role) VALUES (@userEmail,@password,@firstName,@lastName,@Active,@Role)";
            SqlParameter[] parameter = new SqlParameter[6];
                   
            parameter[0] = new SqlParameter("@Role", user.Role);
            parameter[1] = new SqlParameter("@FirstName", user.FirstName);
            parameter[2] = new SqlParameter("@LastName", user.LastName);
            parameter[3] = new SqlParameter("@Email", user.Email);
            parameter[4] = new SqlParameter("@Contact", user.Contact);
            parameter[5] = new SqlParameter("@Active", user.Active);
            parameter[5] = new SqlParameter("@password", user.Password);
            inserted = DataService.InsertIntoDatabase(sqlQuery, parameter);


            if (inserted > 0)
            {
                SendGeneratedPassword(user.Email, user.Password, user.FirstName);
            }
            return inserted;


        

        }

        #endregion


        public static string GetRandomPassword(int length)
        {
            char[] chars = "#@!abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow Repetition of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }

        public static void SendGeneratedPassword(string email, string password, string fname)
        {

            string college = "DWIT";
            MailMessage message = new MailMessage();
            MailAddress Sender = new MailAddress(ConfigurationManager.AppSettings["smtpUser"]);
            MailAddress receiver = new MailAddress(email);
            message.Subject = "Password for CCMS";
            SmtpClient smtp = new SmtpClient();
            {
                smtp.Host = ConfigurationManager.AppSettings["smtpServer"];
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(
                  ConfigurationManager.AppSettings["smtpUser"],
                  ConfigurationManager.AppSettings["smtpPass"]);

            }
            message.From = Sender;
            message.To.Add(receiver);
            message.Body = "Dear " + fname + "," + Environment.NewLine + Environment.NewLine + "Welcome to CCMS. Your password for login is: " + password + Environment.NewLine + Environment.NewLine + "Thanks," + Environment.NewLine + college;

            smtp.Send(message);


        }

        public static DataTable GetUsers(string role)

        {
            
            string query = "select * from Users  where role = @role ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@role",role);

            DataTable Users = DataService.ReadDB( query,param);
            return Users;

 
            

        }

    }
}
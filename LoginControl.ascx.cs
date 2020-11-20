using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginControl : System.Web.UI.UserControl
{
    clsDataAccess _objclsDataAccess = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
        {
            lblAlertMessage.Text = "Enter User Name";
            lblAlertMessage.Visible = true; 
        }
        else if (txtPassword.Text == "")
        {
            lblAlertMessage.Text = "Enter Password";
            lblAlertMessage.Visible = true;
        }
        else
        { 
            string Password = EncodePassword(txtPassword.Text.Trim());
            DataSet ds = _objclsDataAccess.Get_LoginDetails(UserName: txtUserName.Text.Trim(), Password: Password);
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["ErrorMsg"].ToString() == "" || ds.Tables[0].Rows[0]["ErrorMsg"].ToString() == null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["UserID"] = ds.Tables[0].Rows[0]["fUserId"].ToString();
                        Session["UserLevel"] = ds.Tables[0].Rows[0]["fLevelCode"].ToString();
                        Session["UserName"] = ds.Tables[0].Rows[0]["fUserName"].ToString();
                        Session["LastLoginDate"] = ds.Tables[0].Rows[0]["fLastLogin"].ToString();
                        Response.Redirect("~/Dashboard.aspx", false);

                    }
                    else
                    {
                        lblAlertMessage.Text = "User Details Not Found";
                        lblAlertMessage.Visible = true; 
                    }
                }
                else
                {
                    lblAlertMessage.Text = ds.Tables[0].Rows[0]["ErrorMsg"].ToString();
                    lblAlertMessage.Visible = true; 
                }
            }
        }
    }
    public string EncodePassword(string originalPassword)
    {
        Byte[] originalBytes;
        Byte[] encodedBytes;
        MD5 md5;
        md5 = new MD5CryptoServiceProvider();
        originalBytes = ASCIIEncoding.ASCII.GetBytes(originalPassword);
        encodedBytes = md5.ComputeHash(originalBytes);
        return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes), "-", "").ToLower();
    }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('User Details Not Found..');", true);
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('" + ds.Tables[0].Rows[0]["ErrorMsg"].ToString() + "');", true);

        //    }
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('User Details Not Found..');", true);

        //} 
}
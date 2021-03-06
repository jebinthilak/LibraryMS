﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Publisher : System.Web.UI.Page
{
    clsDataAccess _objclsDataAccess = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            if (Session["UserLevel"].ToString() == "1")
            {
                divAdd.Visible = true;
            }
            if (!IsPostBack == true)
            {
                BindGrid();

            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('" + ex.Message + "');", true);
        }

    }
    private void BindGrid()
    {
        DataSet ds = _objclsDataAccess.Get_PublisherDetails();
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptPublisher.DataSource = ds.Tables[0];
            rptPublisher.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('No Records Found');", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Text == "Save")
            {
                int rowaffected = _objclsDataAccess.insert_Publisher(PublisherName: txtPublisherName.Text, UserName: Session["UserID"].ToString());
                if (rowaffected > 0)
                {
                    txtPublisherName.Text = "";
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "SuccessSwal('Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('Save Failed');", true);
                }
            }
            else
            {
                int rowaffected = _objclsDataAccess.Update_Publisher(PublisherName: txtPublisherName.Text, PublisherID: hdnPublisherID.Value, UserName: Session["UserID"].ToString());
                if (rowaffected > 0)
                {
                    txtPublisherName.Text = "";
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "SuccessSwal('Updated Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('Update Failed');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('" + ex.Message + "');", true);
        }
    }
    protected void rptPublisher_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditData")
            {
                ImageButton Details = e.CommandSource as ImageButton;
                RepeaterItem gvr = (RepeaterItem)Details.NamingContainer;
                Label lblPublisherName = (Label)gvr.FindControl("lblPublisherName");
                hdnPublisherID.Value = e.CommandArgument.ToString();
                txtPublisherName.Text = lblPublisherName.Text;
                btnSave.Text = "Update";
            }
            if (e.CommandName == "DeleteData")
            {
                ImageButton Details = e.CommandSource as ImageButton;
                RepeaterItem gvr = (RepeaterItem)Details.NamingContainer;
                int rowaffected = _objclsDataAccess.Delete_Publisher(PublisherID: e.CommandArgument.ToString());
                if (rowaffected > 0)
                {
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "SuccessSwal('Deleted Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('Delete Failed');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('" + ex.Message + "');", true);
        }
    }
    protected void rptPublisher_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lnkEdit = e.Item.FindControl("lnkEdit") as ImageButton;
            ImageButton lnkDelete = e.Item.FindControl("lnkDelete") as ImageButton;
            if (Session["UserLevel"].ToString() == "1")
            {
                lnkEdit.Visible = true;
                lnkDelete.Visible = true;
            }
            else
            {
                lnkEdit.Visible = false;
                lnkDelete.Visible = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book : System.Web.UI.Page
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
        DataSet ds = _objclsDataAccess.Get_BookDetails();
        binddropdwonlistWithDatatable(ds.Tables[0], drpPublisher, "fPublisherID", "fPublisherName");
        binddropdwonlistWithDatatable(ds.Tables[1], drpAuthor, "fAuthorID", "fAuthorName");
        binddropdwonlistWithDatatable(ds.Tables[2], drpBookCategory, "fBookCategoryID", "fBookCategoryDesc");
        if (ds.Tables[3].Rows.Count > 0)
        {
            rptBook.DataSource = ds.Tables[3];
            rptBook.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('No Records Found');", true);
        }
    }
    public static void binddropdwonlistWithDatatable(System.Data.DataTable dds = null, System.Web.UI.WebControls.DropDownList drp = null, string value = null, string text = null, string additionaltext = null, string str = "Select")
    {
        try
        {
            drp.Items.Clear();
            if (dds != null)
            {
                if (dds.Rows.Count > 0)
                {
                    if (additionaltext == null || additionaltext == "")
                    {
                        drp.DataSource = dds;
                        drp.DataTextField = text;
                        drp.DataValueField = value;
                        drp.DataBind();

                    }
                    else
                    {
                        foreach (System.Data.DataRow dr in dds.Rows)
                        {
                            drp.Items.Add(new System.Web.UI.WebControls.ListItem(dr[text].ToString() + " - " + dr[additionaltext].ToString(), dr[value].ToString()));
                        }
                    }
                }
            }
            drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem(str, "0"));
            drp.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (drpBookCategory.SelectedValue == "0" || drpBookCategory.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('select Category');", true);
                return;
            }
            else if (drpAuthor.SelectedValue == "0" || drpAuthor.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('select Author');", true);
                return;
            }
            else if (drpPublisher.SelectedValue == "0" || drpPublisher.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('select Publisher');", true);
                return;
            }
            if (btnSave.Text == "Save")
            {
                int rowaffected = _objclsDataAccess.insert_Book(txtBookName.Text, drpBookCategory.SelectedValue, Convert.ToInt32(txtbookCount.Text), drpPublisher.SelectedValue, drpAuthor.SelectedValue, Session["UserID"].ToString());
                if (rowaffected > 0)
                {
                    txtBookName.Text = "";
                    txtbookCount.Text = "";
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
                int rowaffected = _objclsDataAccess.Update_Book(txtBookName.Text, drpBookCategory.SelectedValue, Convert.ToInt32(txtbookCount.Text), drpPublisher.SelectedValue, drpAuthor.SelectedValue, Session["UserID"].ToString(), hdnBookID.Value);
                if (rowaffected > 0)
                {
                    txtBookName.Text = "";
                    txtbookCount.Text = "";
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
    protected void rptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditData")
            {
                ImageButton Details = e.CommandSource as ImageButton;
                RepeaterItem gvr = (RepeaterItem)Details.NamingContainer;
                Label lblBookName = (Label)gvr.FindControl("lblBookName");
                Label lblBookCategoryID = (Label)gvr.FindControl("lblBookCategoryID");
                Label lblAuthorID = (Label)gvr.FindControl("lblAuthorID");
                Label lblPublisherID = (Label)gvr.FindControl("lblPublisherID");
                Label lblBookCount = (Label)gvr.FindControl("lblBookCount");
                hdnBookID.Value = e.CommandArgument.ToString();
                txtBookName.Text = lblBookName.Text;
                drpBookCategory.SelectedValue = lblBookCategoryID.Text;
                drpPublisher.SelectedValue = lblPublisherID.Text;
                drpAuthor.SelectedValue = lblAuthorID.Text;
                txtbookCount.Text = lblBookCount.Text;
                btnSave.Text = "Update";
            }
            if (e.CommandName == "DeleteData")
            {
                ImageButton Details = e.CommandSource as ImageButton;
                RepeaterItem gvr = (RepeaterItem)Details.NamingContainer;
                int rowaffected = _objclsDataAccess.Delete_Book(BookID: e.CommandArgument.ToString());
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
            if (e.CommandName == "LendBook")
            {
                Button Details = e.CommandSource as Button;
                RepeaterItem gvr = (RepeaterItem)Details.NamingContainer;
                int rowaffected = _objclsDataAccess.Insert_BookLend(e.CommandArgument.ToString(), Session["UserID"].ToString());
                if (rowaffected > 1)
                {
                    BindGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "SuccessSwal('Book Lend Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('Book Lend Failed');", true);
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "ErrorSwal('" + ex.Message + "');", true);
        }
    }
    protected void rptBook_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
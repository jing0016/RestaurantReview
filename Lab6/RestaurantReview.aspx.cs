using Lab_2.Lab6Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

public partial class RestaurantReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            RestaurantReviewServiceClient reviewer = new RestaurantReviewServiceClient();
            string[] restaurantNames = reviewer.GetRestaurantNames(); 

            foreach (string restName in restaurantNames)
            {
                ListItem item = new ListItem(restName);
                drpRestaurants.Items.Add(item);
            }
            pnlViewRestaurant.Visible = false;
        }
    }

    protected void drpRestaurants_SelectedIndexChanged(object sender, EventArgs e)
    {

        //show the selected restaurant data as specified in the lab requirements

        if (drpRestaurants.SelectedValue != "-1")
        {
            string restaurantSelected = drpRestaurants.SelectedItem.Value;

            RestaurantReviewServiceClient reviewer = new RestaurantReviewServiceClient();
            RestaurantInfo rest = reviewer.GetRestaurantByName(restaurantSelected);

            txtAddress.Text = rest.Location.Street;
            txtCity.Text = rest.Location.City;
            txtProvinceState.Text = rest.Location.Province;
            txtPostalZipCode.Text = rest.Location.PostalCode;

            txtAddress.Enabled = false;
            txtCity.Enabled = false;
            txtProvinceState.Enabled = false;
            txtPostalZipCode.Enabled = false;

            txtSummary.Text = rest.Summary;
            drpRating.SelectedValue = rest.Rating.ToString();
            pnlViewRestaurant.Visible = true;
        }
        else pnlViewRestaurant.Visible = false;
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Save the changed restaurant restaurant data back to the XML file.
        
        RestaurantReviewServiceClient reviewer = new RestaurantReviewServiceClient();

        foreach (ListItem item in drpRestaurants.Items)
        {
            if (item.Selected == true && item.Value != "-1")
            {
                RestaurantInfo rest = reviewer.GetRestaurantByName(item.Value);

                rest.Summary = txtSummary.Text;
                Int32.TryParse(drpRating.SelectedValue, out int ratings);
                rest.Rating = ratings;
                if (reviewer.SaveRestaurant(rest))
                {
                    lblConfirmation.Text = "Revised restaurant has been saved to restaurant_reviews.xml";
                }
                else lblConfirmation.Text = "Save error";
            }
        }                     
    }

}
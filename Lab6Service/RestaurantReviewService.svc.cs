using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Lab6Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class RestaurantReviewService : IRestaurantReviewService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<string> GetRestaurantNames()
        {
            List<string> names = new List<string>();

            restaurants allRestaurants = GetRestaurantsFromXml();
            if(allRestaurants != null)
            {
                foreach(restaurant rest in allRestaurants.restaurant)
                {
                    names.Add(rest.name);
                }
            }
            return names;
        }

        public RestaurantInfo GetRestaurantByName(string name)
        {
            restaurants allRestaurants = GetRestaurantsFromXml();
            foreach (restaurant rest in allRestaurants.restaurant)
            {
                if (rest.name == name)
                {
                    RestaurantInfo restInfo = new RestaurantInfo();
                    restInfo.Location = new Address();

                    restInfo.Name = rest.name;
                    restInfo.Summary = rest.summary;
                    restInfo.Rating = rest.rating;
                    restInfo.Location.Street = rest.location.street;
                    restInfo.Location.City = rest.location.city;
                    restInfo.Location.Province = rest.location.provstate;
                    restInfo.Location.PostalCode = rest.location.postalzipcode;
                    return restInfo;
                }
            }
            return null;
        }

        public List<RestaurantInfo> GetRestaurantsByRating(int rating)
        {
            restaurants allRestauants = GetRestaurantsFromXml(); 
            List<RestaurantInfo> restInfos = new List<RestaurantInfo>(); 
            foreach (restaurant rest in allRestauants.restaurant)
            {
                if (rest.rating >= rating)
                {
                    RestaurantInfo restInfo = new RestaurantInfo(); 
                    restInfo.Name = rest.name; 
                    restInfo.Summary = rest.summary; 
                    restInfo.Rating = rest.rating;

                    restInfo.Location = new Address(); 
                    restInfo.Location.Street = rest.location.street; 
                    restInfo.Location.City = rest.location.city; 
                    restInfo.Location.Province = rest.location.provstate.ToString(); 
                    restInfo.Location.PostalCode = rest.location.postalzipcode;

                    restInfos.Add(restInfo);
                }
            }
            return restInfos;
        }

        public bool SaveRestaurant(RestaurantInfo restInfo)
        {
            restaurants allRestaurants = GetRestaurantsFromXml();
            foreach (restaurant rest in allRestaurants.restaurant)
            {
                if (rest.name == restInfo.Name)
                {
                    rest.summary = restInfo.Summary;
                    rest.rating = restInfo.Rating;
                    rest.location.street = restInfo.Location.Street;
                    rest.location.city = restInfo.Location.City;
                    rest.location.provstate = restInfo.Location.Province;
                    rest.location.postalzipcode = restInfo.Location.PostalCode;

                    XmlSerializer serializor = new XmlSerializer(typeof(restaurants));
                    string xmlFile = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/restaurant_reviews.xml");

                    XmlTextWriter tw = new XmlTextWriter(xmlFile, Encoding.UTF8);
                    serializor.Serialize(tw, allRestaurants);
                    tw.Close();
                    return true;
                }
            }
            return false;           
        }

        protected restaurants GetRestaurantsFromXml()
        {
            string xmlFile = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/restaurant_reviews.xml");

            FileStream xs = new FileStream(xmlFile, FileMode.Open);

            XmlSerializer serializor = new XmlSerializer(typeof(restaurants));

            restaurants allRestaurants = (restaurants)serializor.Deserialize(xs);

            xs.Close();

            return allRestaurants;
        }
    }
}

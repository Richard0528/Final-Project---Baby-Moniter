using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace BabyMonitor
{
    public partial class InfoChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetChartData();
                GetChartTypes();
                //DropDownList1_SelectedIndexChanged(sender, e);
            }
        }

        private void GetChartData()
        {
            string cs = ConfigurationManager.ConnectionStrings["BabyInfoEntities"].ConnectionString;
            //var efConnectionString = ConfigurationManager.ConnectionStrings["entityFramework"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(cs);
            var regularConnectionString = builder.ProviderConnectionString;
            using (SqlConnection con = new SqlConnection(regularConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT temp, humidity, sound, event_date FROM Temp_Hum_Sound", con);
                // Retrieve the Series to which we want to add DataPoints
                Series series = Chart1.Series["Series1"];
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // Add X and Y values using AddXY() method
                    series.Points.AddXY(rdr["event_date"].ToString(), rdr["temp"].ToString());
                }
            }
            
        }

        private void GetChartTypes()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType),
                    chartType), chartType.ToString());
                DropDownList1.Items.Add(li);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChartData();
            this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(
                typeof(SeriesChartType), DropDownList1.SelectedValue);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CScharEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }


        EgitimKampiEfTravelDbEntities db= new EgitimKampiEfTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            LblLocationCount.Text=db.Location.Count().ToString();
            LblSumCapacity.Text=db.Location.Sum(X => X.Capacity).ToString();
            GuideCount.Text=db.Guide.Count().ToString();
            LblAvgCapacity.Text=db.Location.Average(X => X.Capacity).ToString();
            LblAvgLocationPrice.Text=db.Location.Average(x => x.Price).ToString();

            int LastCountryId=db.Location.Max(x => x.LocationId);
            LblLastCountryName.Text = db.Location.Where(x => x.LocationId==LastCountryId).Select(y => y.Country).FirstOrDefault();

            LblCapodokyaCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            LblTurkeyAvgCapacity.Text=db.Location.Where(x =>x.Country == "Türkiye").Average(y=>y.Capacity).ToString();

            var romeGuideId=db.Location.Where(x=>x.City == "Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();

            LblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId== romeGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault();

            var maxCapacity=db.Location.Max(x=>x.Capacity);

            LblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();


            var mostExpensivePrice =db.Location.Max(x=>x.Price);

            LblMostExpensiveLocation.Text=db.Location.Where(x=>x.Price==mostExpensivePrice).Select(y=>y.City).FirstOrDefault();

            var aysegulId=db.Guide.Where(x=>x.GuideName=="Ayşegül" && x.GuideSurname=="Çınar").Select(y=>y.GuideId).FirstOrDefault();

            LblAysegulCinarLocationCount.Text=db.Location.Count(y=>y.GuideId==aysegulId).ToString();

        }

        private void LblAvgLocationPrice_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

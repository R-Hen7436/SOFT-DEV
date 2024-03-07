using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAMPUS_NAVIGATION
{
    public partial class Recommendation : UserControl
    {
        private FirestoreDb _db;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (int nleft, int nTop,
       int nRight, int nBottom,
       int nWidthEllipse,
       int nHeightEllipse);

        public Recommendation()
        {
            InitializeComponent();
            FirestoreHelper.SetEnvironmentVariable();
            _db = FirestoreHelper.Database;
            LoadRatingsData();
        }

        private async void LoadRatingsData()
        {
            CollectionReference ratingsCollection = _db.Collection("Ratings");

            QuerySnapshot querySnapshot = await ratingsCollection.GetSnapshotAsync();

            List<RatingData> ratings = new List<RatingData>();

            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                var data = documentSnapshot.ToDictionary();

                if (data.ContainsKey("restaurant") && data.ContainsKey("rate"))
                {
                    ratings.Add(new RatingData
                    {
                        Restaurant = data["restaurant"].ToString(),
                        Rate = double.Parse(data["rate"].ToString())
                    });
                }
            }



            // Bind the original ratings to dataGridView1
            dataGridView1.DataSource = ratings.Select(r => new { r.Restaurant, r.Rate }).ToList();

            // Calculate average rates per restaurant for dataGridView2
            var averageRates = ratings
                .GroupBy(r => r.Restaurant)
                .Select(g => new RatingData
                {
                    Restaurant = g.Key,
                    Rate = g.Average(r => r.Rate)
                })
                .ToList();

            // Remove duplicates from dataGridView2
            var distinctAverages = averageRates.GroupBy(r => r.Restaurant)
                                              .Select(g => g.First())
                                              .ToList();

            // Sort the distinct average rates by Rate in descending order
            var distinctAveragesSorted = distinctAverages.OrderByDescending(a => a.Rate).ToList();

            // Bind the sorted list of distinct average rates to dataGridView2
            dataGridView2.DataSource = distinctAveragesSorted.Select(a => new { Restaurant = a.Restaurant, Average_Ratings = a.Rate }).ToList();



            // Center-align content in DataGridView1 cells
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Center-align content in DataGridView2 cells
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }


        private void Recommendation_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class RatingData
    {
        public double Rate { get; set; }
        public string Restaurant { get; set; }
    }
}

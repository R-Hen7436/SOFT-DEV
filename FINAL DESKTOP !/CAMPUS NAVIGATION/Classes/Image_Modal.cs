using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
   [FirestoreData]
    internal class Image_Modal
    {
        [FirestoreProperty]
        public string Img { get; set; }

        [FirestoreProperty]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
    }
}

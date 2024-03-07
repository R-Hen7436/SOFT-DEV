using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
    [FirestoreData]
    internal class Helpcenter
    {

        [FirestoreProperty]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Question { get; set; }

        [FirestoreProperty]
        public string Answer { get; set; }

    }
}

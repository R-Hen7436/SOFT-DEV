using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
    [FirestoreData]
    internal class LostFound
    {
        [FirestoreProperty]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Place { get; set; }

        [FirestoreProperty]
        public string Items { get; set; }

        [FirestoreProperty]
        public string Others { get; set; }

        [FirestoreProperty]
        public string ClaimHere { get; set; }
    }
}

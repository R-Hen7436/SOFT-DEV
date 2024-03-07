using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
    [FirestoreData]
    internal class Emergency_Contacts
    {
        [FirestoreProperty]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Number { get; set; }

        [FirestoreProperty]
        public string Location { get; set; }
    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
    [FirestoreData]
    internal class Department_Directory
    {
        [FirestoreProperty]
        public string Courses { get; set; }

        [FirestoreProperty]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }
    }
}

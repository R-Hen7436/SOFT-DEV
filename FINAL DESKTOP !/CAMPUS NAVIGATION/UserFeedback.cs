using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION
{
    [FirestoreData]
    internal class UserFeedback
    {
        [FirestoreProperty("Comment")]
        public string Comment { get; set; }

        [FirestoreProperty("Email")]
        public string Email { get; set; }

        [FirestoreProperty("Timestamp")]
        public Timestamp Timestamp { get; set; }
    }
}

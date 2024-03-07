using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;

namespace CAMPUS_NAVIGATION
{
   internal class UserDataService
    {
        private FirestoreDb db;
        private CollectionReference userDataCollection;
        public UserDataService()
        {
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            db = FirestoreHelper.Database;
        }
        public async Task<List<UserData>> LoadUserData()
        {
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "UserData" collection
            userDataCollection = db.Collection("UserData");

            // Create a query to retrieve all users
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store user data
            List<UserData> users = new List<UserData>();

            // Loop through the documents and populate the users list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                // Convert the document to UserData
                UserData user = documentSnapshot.ConvertTo<UserData>();

                if (user != null)
                {
                    // Decrypt the password before adding it to the list
                    user.Password = Security.Decrypt(user.Password);
                    users.Add(user);
                }
            }

            return users;
        }

        public async Task<bool> EditUser(string currentAccountID, string institutionalId, string newName, string newPassword, string newEmail)
        {
            try
            {
                FirestoreHelper.SetEnvironmentVariable();
                FirestoreDb db = FirestoreHelper.Database;
                userDataCollection = db.Collection("UserData");

                Query query = userDataCollection.WhereEqualTo("Name", currentAccountID);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                if (querySnapshot.Count > 0)
                {
                    var documentSnapshot = querySnapshot.Documents[0];
                    var existingUserData = documentSnapshot.ConvertTo<UserData>();

                    existingUserData.InstitutionalID = institutionalId;
                    existingUserData.Name = newName;
                    existingUserData.Password = Security.Encrypt(newPassword);
                    existingUserData.Email = newEmail;

                    await documentSnapshot.Reference.SetAsync(existingUserData);

                    return true; // Update successful
                }
                else
                {
                    return false; // User not found
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show($"Error editing user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public async Task<bool> UpdateSecurityID(string userId, string newSecurityID)
        {
            try
            {
                // Reference to the "UserData" collection
                CollectionReference userDataCollection = db.Collection("UserData");

                // Update the SecurityID for the user in the Firebase collection
                var userDoc = userDataCollection.Document(userId);

                // Assuming "SecurityID" is the correct field name in Firestore
                await userDoc.UpdateAsync(nameof(UserData.SecurityID), newSecurityID);

                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show($"Error updating SecurityID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

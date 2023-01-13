using Firebase.Database;
using UnityEngine;

public class databaseManager : MonoBehaviour
{
    string userId;
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        CreateUser(0);
    }

    void CreateUser(int toggle)
    {
        Users newUser=new Users(PlayerPrefs.GetInt("setting"));
        string json=JsonUtility.ToJson(newUser);  
        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);  
    }


}

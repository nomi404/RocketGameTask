using Firebase.Database;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    [SerializeField] Toggle setting;
    string userId;
    DatabaseReference reference;
    
    int getSetting;
    // Start is called before the first frame update
    void Start()
    {

        userId = SystemInfo.deviceUniqueIdentifier;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine(FetchToggle());


    }

    public void SetToggle()
    {
        int value;
        if (setting.isOn)
        {
            value = 1;
        }
        else
        {
            value = 0;
        }
        getSetting = value;
        Users newUser = new Users(value);
        string json = JsonUtility.ToJson(newUser);
        reference.Child("users").Child(userId).SetValueAsync(json);
         

    }

    IEnumerator FetchToggle()
    {
        var data = reference.Child("users").Child(userId).Child("toggle").GetValueAsync();
        yield return new WaitUntil(predicate: () => data.IsCompleted);
        if (data != null)
        {
            DataSnapshot snapshot = data.Result;
            PlayerPrefs.SetInt("setting",int.Parse(snapshot.Value.ToString()));
            
            getSetting = int.Parse(snapshot.Value.ToString());
            if (getSetting == 1)
            {
                setting.isOn = true;
            }

            else
            {
                setting.isOn = false;
            }


        }
    }

    public void UnSaveValue()
    {
        if (getSetting == 1)
        {
            setting.isOn = true;
        }

        else
        {
            setting.isOn = false;
        }
    }


    public void startScene()
    {
        SceneManager.LoadScene(1);
    }

}

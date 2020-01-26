using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Category : MonoBehaviour
{
    public string categoryName = "";


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoundRecording"))
        {
            SoundRecording soundRecording =  (SoundRecording)other.gameObject.GetComponent("SoundRecording");
            StartCoroutine(Post("http://192.168.10.165:1880/categoryenter",
                "{\"soundname\":\""+soundRecording.soundName+"\"}" ));
        }

    }

    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
    }
}
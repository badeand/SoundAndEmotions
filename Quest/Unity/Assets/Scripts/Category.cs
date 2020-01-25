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
        StartCoroutine(Post("http://192.168.10.165:1880/hello-json", "{\"sound\" : \"" + categoryName + "\"}"));
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
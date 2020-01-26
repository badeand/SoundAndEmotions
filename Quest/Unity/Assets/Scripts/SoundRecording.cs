using System.Collections;
using System.Text;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class SoundRecording : OVRGrabbable
{
    public AudioSource sound;
    public string Name = "";
    public GameStateManager gameStateManager;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        sound.Play();
        // StartCoroutine(Post("http://192.168.10.165:1880/categoryenter", "{\"sound\" : \"" + Name + "\"}"));
        gameStateManager.AddToPickedUpSoundRecordings(this);

    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        sound.Stop();
        gameStateManager.RemovedFromPickupedUpSoundRecordings(this);
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
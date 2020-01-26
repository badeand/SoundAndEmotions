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
        gameStateManager.AddToPickedUpSoundRecordings(this);

    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        sound.Stop();
        gameStateManager.RemovedFromPickupedUpSoundRecordings(this);
    }

}
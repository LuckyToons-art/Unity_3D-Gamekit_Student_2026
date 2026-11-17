using UnityEngine;
using  FMOD.Studio;
using FMODUnity;

[CreateAssetMenu(fileName = "InteractableAudio", menuName = "Scriptable Objects/InteractableAudio")]
public class InteractableAudio : ScriptableObject
{
    [SerializeField] private EventReference pickupHealthAudio, boxDestroyedAudio, switchAudio, doorAudio;


    public void PickupHealthPlay()
    {
        RuntimeManager.PlayOneShot(pickupHealthAudio);
    }

    public void BoxDestroyedPlay(Transform objectTransform)
    {
        RuntimeManager.PlayOneShot(boxDestroyedAudio, objectTransform.position);
    }
}

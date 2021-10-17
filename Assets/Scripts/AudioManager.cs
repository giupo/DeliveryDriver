using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip pickupClip;
    [SerializeField] AudioClip deliveryClip;
    [SerializeField] AudioClip[] crashSounds;


    [SerializeField] AudioSource audioSource;

    void OnEnable() {
        EventManager.onPickUp += onPickUp;
        EventManager.onDelivery += onDelivery;
        EventManager.onCrash += onCrash;
    }

    void OnDisable() {
        EventManager.onPickUp -= onPickUp;
        EventManager.onDelivery -= onDelivery;
        EventManager.onCrash -= onCrash;
    }

    void onPickUp() {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(pickupClip);
    }

    void onDelivery() {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(deliveryClip);
    }

    void onCrash() {
        int index = Random.Range(0, crashSounds.Length);
        audioSource.volume = 1f;
        audioSource.PlayOneShot(crashSounds[index]);
    }
}

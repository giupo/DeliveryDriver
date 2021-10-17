using UnityEngine;

public class DeliveryHandler : MonoBehaviour {

    private bool hasPackage = false;

    void Start() {
        hasPackage = false;
    }

    void OnEnable() {
        EventManager.onPickUp += onPickUp;
        EventManager.onDelivery += onDelivery;
    }

    void OnDisable() {
        EventManager.onPickUp -= onPickUp;
        EventManager.onDelivery -= onDelivery;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PickUp" && !hasPackage) {
            EventManager.current.PickUp();
        }

        if(other.tag == "Delivery" && hasPackage) {
            EventManager.current.Delivery();
        }
    }

    void onPickUp() {
        hasPackage = true;
    }

    void onDelivery() {
        hasPackage = false;
    }
}

using UnityEngine;

public class DeliveryHandler : MonoBehaviour {

    [SerializeField] bool hasPackage = false;

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

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PickUp" && !hasPackage) {
            Debug.Log("PickUp");            
            EventManager.current.PickUp();
        }   

        if(other.tag == "Delivery" && hasPackage) {
            Debug.Log("Delivery");
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

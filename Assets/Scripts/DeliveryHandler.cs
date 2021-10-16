using UnityEngine;

public class DeliveryHandler : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PickUp") {
            Debug.Log("PickUp");
            EventManager.current.PickUp();
        }   

        if(other.tag == "Delivery") {
            Debug.Log("Delivery");
            EventManager.current.Delivery();
        } 
    }
}

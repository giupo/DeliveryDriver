using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }
}

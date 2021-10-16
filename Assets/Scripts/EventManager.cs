using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake() {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



	public void GameOver() => onGameOver?.Invoke();
    public void Delivery() => onDelivery?.Invoke();
    public void PickUp() => onPickUp?.Invoke();

	public delegate void GameOverAction();
    public static event GameOverAction onGameOver;


    public delegate void PickUpAction();
    public static event PickUpAction onPickUp;
    public delegate void DeliveryAction();
    public static event DeliveryAction onDelivery;
}

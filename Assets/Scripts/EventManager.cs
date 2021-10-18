using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake() {
        if (current != null) {
            Destroy(gameObject);
            return;
        }

        current = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver() => onGameOver?.Invoke();
    public void Delivery() => onDelivery?.Invoke();
    public void PickUp() => onPickUp?.Invoke();
    public void Crash(int damages) => onCrash?.Invoke(damages);
    public void PackagePaid(int parcel) => onPackagePaid?.Invoke(parcel);

    public void PointsChanged(int points) => onPointsChange?.Invoke(points);

    public delegate void GameOverAction();
    public static event GameOverAction onGameOver;


    public delegate void PickUpAction();
    public static event PickUpAction onPickUp;
    public delegate void DeliveryAction();
    public static event DeliveryAction onDelivery;

    public delegate void CrashAction(int damages);
    public static event CrashAction onCrash;

    public delegate void PackagePaidAction(int parcel);
    public static event PackagePaidAction onPackagePaid;

    public delegate void PointsChangeAction(int points);
    public static event PointsChangeAction onPointsChange;
}
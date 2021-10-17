using System.Linq;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject pickup;
    [SerializeField] GameObject delivery;

    private GameObject pickup_instance = null;
    private GameObject delivery_instance = null;

    void Start() {
        SpawnPoints();
    }

    void OnEnable() {
        EventManager.onPickUp += onPickUp;
        EventManager.onDelivery += onDelivery;
    }

    void OnDisable() {
        EventManager.onDelivery -= onDelivery;
        EventManager.onPickUp -= onPickUp;
    }

    void SpawnPoints() {

        if (pickup_instance != null) {
            Destroy(pickup_instance);
        }

        if (delivery_instance != null) {
            Destroy(delivery_instance);
        }

        int first = Random.Range(0, spawnPoints.Length);
        // extract excluding first.
        var range = Enumerable.Range(0, spawnPoints.Length).Where(i => i != first);
        var rand = new System.Random();
        int index = rand.Next(0, spawnPoints.Length - 1);
        int second = range.ElementAt(index);

        pickup_instance = Instantiate(pickup, spawnPoints[first].position, Quaternion.identity);
        delivery_instance = Instantiate(delivery, spawnPoints[second].position, Quaternion.identity);

        Debug.Log(sqrDistance(first, second));
    }

    void onPickUp() {
        Destroy(pickup_instance);
        pickup_instance = null;
    }

    void onDelivery() {
        Destroy(delivery_instance);
        delivery_instance = null;
        SpawnPoints();
    }

    float sqrDistance(int first, int second) {
        return (spawnPoints[first].position - spawnPoints[second].position).sqrMagnitude;
    }
}

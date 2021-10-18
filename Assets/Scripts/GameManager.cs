using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager current;
    private int points = 0;

    private void Awake() {
        if (current != null) {
            Destroy(gameObject);
            return;
        }

        current = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() {
        EventManager.onPackagePaid += onPackagePaid;
        EventManager.onCrash += onCrash;
    }

    void OnDisable() {
        EventManager.onPackagePaid -= onPackagePaid;
        EventManager.onCrash -= onCrash;
    }
    
    void onPackagePaid(int parcel) {
        points += parcel;
        EventManager.current.PointsChanged(points);
    }

    void onCrash(int damages) {
        points -= damages;
        EventManager.current.PointsChanged(points);
    }
}

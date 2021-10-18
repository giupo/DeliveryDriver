using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {

    [SerializeField] Text pointText;
    [SerializeField] Text transactionText;

    private IEnumerator coroutine = null;

    int points;
    int transaction;
    Color transactionColor;
    void OnEnable() {
        EventManager.onPackagePaid += onPackagePaid;        
        EventManager.onCrash += onCrash;
        EventManager.onPointsChange += onPointsChange;
    }

    void OnDisable() {
        EventManager.onPackagePaid -= onPackagePaid;        
        EventManager.onCrash -= onCrash;
        EventManager.onPointsChange -= onPointsChange;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = points.ToString();
        
        string transactionString = transaction.ToString();
        if (transaction > 0) {                                
            transactionString = "+" + transactionString;
        }

        transactionText.color = transactionColor;
        transactionText.text = transactionString;
    }

    void onPackagePaid(int parcel) {
        if (coroutine != null) StopCoroutine(coroutine);
        transaction = parcel;
        coroutine = dissolveTransaction();
        transactionColor = new Color(0, 1, 0, 1);    
        StartCoroutine(coroutine);
    }

    void onCrash(int damages) {
        if (coroutine != null) StopCoroutine(coroutine);
        transaction = -damages;        
        coroutine = dissolveTransaction();
        transactionColor = new Color(1, 0, 0, 1);    
        StartCoroutine(coroutine);
    }

    void onPointsChange(int points) {
        this.points = points;
    }

    IEnumerator dissolveTransaction() {
         yield return new WaitForSeconds(1f);         
         float alpha_step = .005f;         
         do {             
             transactionColor.a -= alpha_step;             
             yield return new WaitForSeconds(.02f);                              
         } while(transactionColor.a > 0);
    }
}

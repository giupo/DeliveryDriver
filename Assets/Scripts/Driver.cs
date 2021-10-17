using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationSpeed;
    [SerializeField] float engineForce;
    [SerializeField] float retroScaleFactor;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input_turn = Input.GetAxis("Horizontal");
        float input_move = Input.GetAxis("Vertical");

        if (input_move < 0) {
            input_move /= retroScaleFactor;
            input_turn /= retroScaleFactor;
            input_turn = -input_turn;
        }

        if (Mathf.Abs(input_move) > 0.001) {
            Rotate(-input_turn * rotationSpeed * Time.deltaTime);
            Move(input_move * engineForce * Time.deltaTime);
        }
    }


    void Rotate(float degrees) {
        transform.Rotate(0, 0, degrees);
    }

    void Move(float amount) {
        //Vector3 force = Vector3.forward * amount;
        transform.Translate(0, amount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        EventManager.current.Crash();
    }
}

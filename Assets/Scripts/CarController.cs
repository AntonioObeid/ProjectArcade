using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float throttle, turnSpeed;
    public Rigidbody carRigidbody;
    public Transform type;

    [SerializeField] private GasController gasCar;
    [SerializeField] private CarCollider carCollider;

    private float _yAxisRotation, _turnInput;
    private bool _throttleInput, _brakeInput;
    private Vector3 _initialTypeOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialTypeOffset = type.transform.localPosition;

        gasCar.Init();
        Debug.Log("has gas?" + gasCar.hasGas);
    }

    private void TurnAngle()
    {
        _yAxisRotation += _turnInput * turnSpeed * Time.deltaTime;

        type.position = transform.position + _initialTypeOffset;
        type.eulerAngles = new Vector3(0, _yAxisRotation, 0);
        carCollider.transform.eulerAngles = type.eulerAngles;
    }

    // FixedUpdate has a constant 60 frames per second
    void FixedUpdate()
    {
        if (gasCar.hasGas)
        {
            TurnAngle();
            CarInMotion();
        }
    }

    private void CarInMotion()
    {
        if (_throttleInput)
        {
            carRigidbody.AddForce(type.forward * throttle, ForceMode.Acceleration);
        }

        if (_brakeInput)
        {
            _throttleInput = false;
            carRigidbody.velocity = Vector3.zero;
        }
    }

    //The throttleInput is called
    public void OnThrottleInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            _throttleInput = true;
        else
            _throttleInput = false;
    }
    
    //TurnInput is called
    public void OnTurnInput(InputAction.CallbackContext context)
    {
        _turnInput = context.ReadValue<float>();
    }

    public void OnBrakeInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _brakeInput = true;
        }
        else
        {
            _brakeInput = false;
        }
    }
    
}

using UnityEngine;

public class CarCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private CarHealth _carHealth;
    [SerializeField] private CarInfo carInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        carInfo = gameObject.GetComponentInParent<CarInfo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallsOfDoom"))
        {
            Debug.Log("DoomedByWalls" + other.gameObject.name);
        }
        /*else if (other.gameObject.GetComponentInParent<CarInfo>().ID != carInfo.ID)
        {
            Debug.Log("TheRideToHell has been Hit" + other.gameObject.name);
            int amount = other.gameObject.GetComponentInParent<CarDamage>().DamageAmount;
            _carHealth.UpdateHealthPulse(amount);
        }*/
    }
}

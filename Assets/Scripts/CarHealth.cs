using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public int healthPulse;
    [SerializeField] private int currentHealthPulse;

    private void Start() => Init();
    public void Init() => InitialHealth(healthPulse);

    internal void InitialHealth(int value) => currentHealthPulse = value;

    internal void UpdateHealthPulse(int value)
    {
        currentHealthPulse += value;
        if (currentHealthPulse <= 0)
        {
            Debug.Log("Vaporized to the Eternal Kingdom!!");
        }
    }
}

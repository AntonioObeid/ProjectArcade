using UnityEngine;

public class CarDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    public int DamageAmount
    {
        get => damageAmount;
        set => damageAmount = value;
    }
}

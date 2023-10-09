using UnityEngine;

public class CarInfo : MonoBehaviour
{
    public int ID
    {
        get => id;
        set => id = value;
    }

    [SerializeField] private int id;
}

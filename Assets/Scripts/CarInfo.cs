using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CarInfo : MonoBehaviour
{
    public int ID
    {
        get => _id;
        set => _id = value;
    }

    [SerializeField] private int _id;
}

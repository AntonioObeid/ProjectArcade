using System.Collections;
using UnityEngine;

public class GasController : MonoBehaviour
{
    public bool hasGas = true;
    [SerializeField] private float gasAmounts;

    internal void Init() => StartCoroutine(GasRoutine());

    private IEnumerator GasRoutine()
    {
        float gasRemaining = gasAmounts;
        while (hasGas)
        {
            yield return new WaitForSeconds(1.0f);
            gasRemaining--;
            gasAmounts = gasRemaining;
            if (gasAmounts <= 0)
            {
                Debug.Log("Depleted Gas Tank!!");
                hasGas = false;
                break;
            }
        }
    }

    public float GetGas()
    {
        return gasAmounts;
    }

    private void OnDisable()
    {
        StopCoroutine(GasRoutine());
    }
}

using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public int spinSpeed = 1;

    void Update()
    {
        transform.Rotate(0, spinSpeed, 0, Space.World);
    }
}
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{

    public Transform player;
    public float distanceBehind = 51f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = player.position.z - distanceBehind;
        GetComponent<Rigidbody>().MovePosition(pos);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Section"))
        {
            Destroy(other.gameObject);
        }
    }
}

using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject section;
    [SerializeField] private int zPos = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SectionTrigger"))
        {
            Instantiate(section, new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 50;
        }
    }
}

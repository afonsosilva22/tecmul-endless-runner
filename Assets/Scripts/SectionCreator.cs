using UnityEngine;

public class SectionCreator : MonoBehaviour
{
    public GameObject[] sections;
    [SerializeField] private int zPos = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SectionTrigger"))
        {
            Instantiate(sections[Random.Range(0, sections.Length)], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 50;
        }
    }
}
using UnityEngine;

public class DiscoTrigger : MonoBehaviour
{
    public GameObject discoNight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            discoNight.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            discoNight.SetActive(false);
        }
    }
}

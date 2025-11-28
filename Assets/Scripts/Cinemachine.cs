using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Cinemachine : MonoBehaviour
{
    public CinemachineCamera MainCam;
    public CinemachineCamera BossCam;
    private CinemachineCamera activeCam;
    private Collider2D lineCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCam.gameObject.SetActive(true);
        BossCam.gameObject.SetActive(false);
        lineCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered boss area");
            MainCam.gameObject.SetActive(false);
            Debug.Log("MainCam deactivated");
            BossCam.gameObject.SetActive(true);
            Debug.Log("BossCam activated");
            lineCollider.isTrigger = false;
        }
    }

}

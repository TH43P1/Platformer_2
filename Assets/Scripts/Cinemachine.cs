using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class Cinemachine : MonoBehaviour
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CinemachineConfiner2D confiner = GetComponent<CinemachineConfiner2D>();
        }
    }
}

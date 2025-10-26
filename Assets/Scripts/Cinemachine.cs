using UnityEngine;

public class Cinemachine : MonoBehaviour
{
    public Transform Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x, transform.position.y, transform.position.z);
    }
}

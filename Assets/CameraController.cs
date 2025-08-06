using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Input.GetAxisRaw("Horizontal");
        if (angle != 0)
        {
            transform.Rotate(new Vector3(0, angle, 0));
        }
    }
}

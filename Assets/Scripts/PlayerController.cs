using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float gravity = -9.81f;
    
    
    private Vector3 velocity;
    
    private void Start()
    {
        Debug.Log("PlayerController Start");
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Transform trans = transform;
        Vector3 move = trans.right * x + trans.forward * z;

        controller.Move(move * (Time.deltaTime * speed));
        
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }
    
}
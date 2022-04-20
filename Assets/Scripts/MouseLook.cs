using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Public fields
    
    
    // Serialized fields
    [SerializeField] private Transform playerBody;
    
    
    // Private fields
    private float xSensitivity = 100f;
    private float ySensitivity = 100f;
    
    private float xRotation = 0f;
    
    // Awake is called before start
    private void Awake() => GameManager.SetCameraController(this);

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
    public void SetSensitivity(float x, float y)
    {
        xSensitivity = x;
        ySensitivity = y;
    }
}

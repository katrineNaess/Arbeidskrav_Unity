using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float mouseSensetivity = 1500f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;
    
    public float topClamp = -90f;
    public float bottomClamp = 90f;
    void Start()
    {
        // låser musepeker i midten
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Henter musens bevegelse i X- og Y-retning og justerer den med følsomhet og delta-tid
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
        
        // Justere x-bevegelse (se opp og ned)
        _xRotation -= mouseY;
        
        // Begrenser hvor langt man kan se opp og ned
        _xRotation = Mathf.Clamp(_xRotation, topClamp, bottomClamp);
        
        // Justere y-bevegelse (se høyre og venstre)
        _yRotation += mouseX;
        
        // Setter objektets rotasjon basert på x- og yRotasjon, men holder zRotasjon fast (hindrer velting)
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        
    }
}

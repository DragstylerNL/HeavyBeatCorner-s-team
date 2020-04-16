using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    
    
    // ============================================================================================= 'Private' Variables
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _playerCam; 
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _cameraMoveSpeed = 400f;
    
    // =============================================================================================== Private Variables
    
    // =========================================================================================================== Start
    void Start()
    {
        
    }

    // ========================================================================================================== Update
    void Update()
    {
        PlayerMove();
        MouseInput();
    }


    // ================================================================================================= Player movement
    private void PlayerMove()
    {
        var position = _playerTransform.position;
        position += _playerTransform.transform.forward * (Input.GetAxis("Vertical") * Time.deltaTime * _playerSpeed);
        position += _playerTransform.transform.right * (Input.GetAxis("Horizontal") * Time.deltaTime * _playerSpeed);
        _playerTransform.position = position;
    }
    
    private void MouseInput()
    {
        float y = _cameraMoveSpeed * Input.GetAxis ("Mouse X") * Time.deltaTime;
        float x = _cameraMoveSpeed * -Input.GetAxis ("Mouse Y") * Time.deltaTime;
        _playerTransform.Rotate(0,y,0);
        _playerCam.Rotate(x,0,0);
    }
}

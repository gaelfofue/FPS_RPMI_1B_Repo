using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{
    #region GENERAL VARIABLES
    [Header("Movement & Look")]
    [SerializeField] GameObject camHolder; // Ref en el inspector del objeto a rotar
    [SerializeField] float speed = 5f; // Si habra modificadores que cambien la velocidad del player, seria mejor hacerlo publico
    [SerializeField] float crouchSpeed = 3f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float maxForce = 1f; // Fuerza maxima de aceleracion
    [SerializeField] float sensitiviy = 0.1f; // Sensibilidad del ratón

    [Header("Player State Bools")]
    [SerializeField] bool isSprinting;
    [SerializeField] bool isCrouching;


    #endregion

    // Variables de autoreferencia
    Rigidbody rb;

    // Variables de input
    Vector2 moveInput;
    Vector2 lookInput;
    float lookRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Lock del cursor del ratón
        Cursor.lockState = CursorLockMode.Locked; // Lockea el cursoer en el centro de la pantalla
        Cursor.visible = false; // "Apaga" la visualización del cursor
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region INPUT METHODS
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnCrouch(InputAction.CallbackContext context)
    {

    }

    public void OnSripnt(InputAction.CallbackContext context)
    {
        
    }
    #endregion


}

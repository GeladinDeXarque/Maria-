using UnityEngine;




[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{


    [Header("Movimento")]
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Verificação do chão")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform npc;

    DialogoSistema dialogoSistema;



    private void Awake()
    {
        dialogoSistema = FindFirstObjectByType<DialogoSistema>();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // força para manter o personagem colado no chão
        }

        // Entrada de movimento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - npc.position.x) < 2.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoSistema.Next();
            }
        }

    }
}



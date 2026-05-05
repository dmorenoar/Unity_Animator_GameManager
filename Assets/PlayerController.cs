using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables visibles en el Inspector
    [SerializeField]
    private float velocity = 5f;

    [SerializeField] 
    private float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator animator;

    private float horizontalMovement; 
    private bool shouldJump;


    void Start()
    {
        // Guardamos el componente al empezar
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // Leemos el teclado (A/D o Flechas)
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(horizontalMovement * velocity, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SpaceBar clicked!");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked!");
            animator.SetTrigger("Attack");

            GameManager.instance.AddLive();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right mouse button clicked!");

        }

        /*OLD METHOD
        if (horizontalMovement > 0.0 || horizontalMovement < 0.0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }*/

        //*****************
        //Combinar el movimiento horizontal con la animación
        //*****************

        float treshold = 0.1f; // Umbral para considerar que el jugador se está moviendo

        //No importa si el movimiento es positivo o negativo,
        //lo importante es que se esté moviendo, por eso usamos el valor absoluto
        animator.SetBool("isRunning", Mathf.Abs(horizontalMovement) > treshold);

        if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Mirar a la derecha
        }
        else if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Mirar a la izquierda
        }
    }

    void FixedUpdate()
    {
        // Movemos el objeto directamente

    }
}

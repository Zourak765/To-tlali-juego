using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadNormal = 7f;
    public float velocidadCorrer = 12f;

    public Transform playerGraphic; 
    public Canvas uiCanvas;         

    private float movimientoX;
    private float movimientoY;
    private bool mirandoDerecha = true;

    private PlayerTeleport estado;
    private Animator animator;

    void Start()
    {
        estado = GetComponent<PlayerTeleport>();
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
            Debug.LogWarning("No se encontró Animator en el Player o sus hijos.");
    }

    void Update()
    {
        if (estado != null && !estado.puedeTeletransportarse)
            return;

        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");

        bool corriendo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float velocidadActual;

        if (movimientoX != 0 && movimientoY != 0)
            velocidadActual = corriendo ? 8f : 4f;
        else if (movimientoX != 0 || movimientoY != 0)
            velocidadActual = corriendo ? velocidadCorrer : velocidadNormal;
        else
            velocidadActual = 0f;

        if (animator != null)
        {
            animator.SetFloat("Velocidad", velocidadActual);
            animator.SetBool("Corriendo", corriendo);
        }

        if (movimientoX > 0 && mirandoDerecha)
            Flip();
        else if (movimientoX < 0 && !mirandoDerecha)
            Flip();

        transform.Translate(new Vector3(movimientoX * velocidadActual, movimientoY * velocidadActual, 0) * Time.deltaTime);

        if (uiCanvas != null)
            uiCanvas.transform.position = uiCanvas.transform.position;
    }

    void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = playerGraphic.localScale;
        escala.x = mirandoDerecha ? Mathf.Abs(escala.x) : -Mathf.Abs(escala.x);
        playerGraphic.localScale = escala;
    }
}
using UnityEngine;

public class Movimiento_Pez : MonoBehaviour
{
    private GameObject objetivo;
    public float distanciaDerrape = 1f;
    public float velocidad = 2f;
    public float toleranciaLlegada = 0.1f;
    public float fuerzaSalto = 7f;

    private Vector2 lloc;
    private float lastDistancia = 0;
    private bool haSaltado = false;
    private bool activarMovimiento = false;

    private Rigidbody2D rb;
    Animator ator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ator = GetComponent<Animator>();

        objetivo = GameObject.Find("Personaje");

        CalcularDistancia();

        if (!haSaltado)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            haSaltado = true;
        }
    }

    void Update()
    {
        if (!activarMovimiento && rb.velocity.y <= 0)
        {
            activarMovimiento = true;
        }

        if (activarMovimiento)
        {
            ator.SetBool("Caminar", true);
            Vector2 posicionActual = transform.position;
            float direccionX = Mathf.Sign(lloc.x - posicionActual.x);
            float nuevaX = posicionActual.x + direccionX * velocidad * Time.deltaTime;

            if (Mathf.Abs(lloc.x - posicionActual.x) <= toleranciaLlegada)
            {
                CalcularDistancia();
            }
            else
            {
                transform.position = new Vector3(nuevaX, posicionActual.y, transform.position.z);
            }
        }
    }

    void CalcularDistancia()
    {
        if (objetivo == null) return;

        float distancia = objetivo.transform.position.x - transform.position.x;

        if (distancia > 0)
        {
            gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            lastDistancia = distancia;
            lloc = new Vector2(transform.position.x + distancia + distanciaDerrape, objetivo.transform.position.y);
        }
        else if (distancia < 0)
        {
            gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            lastDistancia = distancia;
            lloc = new Vector2(transform.position.x + distancia - distanciaDerrape, objetivo.transform.position.y);
        }
        else
        {
            if (lastDistancia > 0)
                lloc = new Vector2(transform.position.x + lastDistancia + distanciaDerrape, objetivo.transform.position.y);
            else if (lastDistancia < 0)
                lloc = new Vector2(transform.position.x + lastDistancia - distanciaDerrape, objetivo.transform.position.y);
        }
    }
}

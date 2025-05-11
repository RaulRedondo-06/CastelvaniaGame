using UnityEngine;

public class GiantBatBoss : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float waitTime = 1f;
    public Vector2 movementRange = new Vector2(20f, 20f);  
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireCooldown = 3f;
    private Vector2 targetPosition;
    private float waitTimer = 0f;
    private float fireTimer;
    private Vector2 initialPosition;  
    private bool isWaiting = false;
    Animator boss_1;

    void Start()
    {
        initialPosition = transform.position;  // Guardamos la posición inicial del jefe
        ChooseNewTarget();
        fireTimer = fireCooldown;
        boss_1 = GetComponent<Animator>();
        boss_1.SetBool("Player", true);
    }

    void Update()
    {
        
        Vector3 targetPos = new Vector3(targetPosition.x, targetPosition.y, -1.5f);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Movimiento y cambio de destino
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                ChooseNewTarget();
            }
        }
        else
        {
            // No modificar la posición Z al mover el personaje
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isWaiting = true;
                waitTimer = waitTime;
            }
        }

        // Ataque
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireCooldown;
        }
    }



    // Método para elegir un nuevo destino dentro del área limitada
    void ChooseNewTarget()
    {
        // Generamos un nuevo destino dentro del rango limitado
        float x = Random.Range(initialPosition.x - movementRange.x, initialPosition.x + movementRange.x);
        float y = Random.Range(initialPosition.y - movementRange.y, initialPosition.y + movementRange.y);
        targetPosition = new Vector3(x, y, -1);

        Debug.Log("Nuevo destino: " + targetPosition);  // Debug para ver el destino
    }

    // Método para disparar proyectiles
    void Fire()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}

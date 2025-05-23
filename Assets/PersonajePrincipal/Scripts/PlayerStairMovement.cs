using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStairMovement : MonoBehaviour
{
    public float stairMoveSpeed = 3f;

    public bool up = false;
    public bool down = false;

    private bool onStair = false;
    private bool isMoving = false;

    private Transform targetPoint = null;
    private Transform startPoint = null;
    private Transform endPoint = null;

    private Rigidbody2D rb;
    private float originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1f);
        if (onStair && targetPoint != null && isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, stairMoveSpeed * Time.deltaTime);

            float distanceToTarget = Vector2.Distance(transform.position, targetPoint.position);
            if (distanceToTarget < 0.05f)
            {
                transform.position = targetPoint.position;
                EndStairMovement();
            }
        }

        if (onStair)
        {
            if (Input.GetKey(KeyCode.W) && !isMoving)
            {
                up = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
                targetPoint = endPoint;
                StartStairMovement();
                if (endPoint.position.x > transform.position.x)
                {
                    gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                }
                if (endPoint.position.x < transform.position.x)
                {
                    gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }

            }

            if (Input.GetKey(KeyCode.S) && !isMoving)
            {
                down = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
                targetPoint = startPoint;
                StartStairMovement();
                if (startPoint.position.x > transform.position.x)
                {
                    gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                }
                if (startPoint.position.x < transform.position.x)
                {
                    gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
            }
        }
    }

    private void StartStairMovement()
    {
        if (targetPoint == null) return;
        isMoving = true;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1f);
    }

    private void EndStairMovement()
    {
        up = false;
        down = false;
        isMoving = false;
        targetPoint = null;
        rb.gravityScale = originalGravity;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stair"))
        {
            startPoint = other.transform.Find("StartPoint");
            endPoint = other.transform.Find("EndPoint");

            if (startPoint == null || endPoint == null)
            {
                Debug.LogError("StartPoint o EndPoint no encontrados en: " + other.name);
                return;
            }

            onStair = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Stair"))
        {
            onStair = false;
            EndStairMovement();
        }
    }
}

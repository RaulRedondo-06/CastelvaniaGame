using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class following_camera : MonoBehaviour
{
    public Transform Personaje;
    public Transform ActiveRoom ;

    public static following_camera instance;

    [Range(-5, 5)]
    public float minModY, maxModY, minModX, maxModX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mynPosY = ActiveRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = ActiveRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var mynPosX = ActiveRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = ActiveRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(Personaje.position.x, mynPosX, maxPosX),
            Mathf.Clamp(Personaje.position.y, mynPosY, maxPosY),
            Mathf.Clamp(Personaje.position.z, -10f, -10f)
            );

        transform.position = new Vector3(clampedPos.x, clampedPos.y, clampedPos.z);
    }
}

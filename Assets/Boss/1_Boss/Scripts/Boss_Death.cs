using UnityEngine;

public class Boss_Death : MonoBehaviour
{
    [SerializeField]
    float vida;
    [SerializeField]
    float romper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomNumbre = Random.Range(0, 5) + 1;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            vida--;
            if (romper > 0)
            {
                Debug.Log(vida);
                if (romper == -(vida - 1))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

using UnityEngine;

public class UIBringToFront : MonoBehaviour
{
    void Start()
    {
        // Esto mover� el objeto al frente al iniciar
        transform.SetAsFirstSibling();
    }

    public void TraerAlFrente()
    {
        transform.SetAsFirstSibling();
    }
}

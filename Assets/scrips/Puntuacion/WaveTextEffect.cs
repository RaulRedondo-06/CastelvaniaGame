using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WaveTextEffect : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private Mesh mesh;
    private Vector3[] vertices;

    public float amplitude = 5f;      // Altura del movimiento
    public float frequency = 2f;      // Velocidad del movimiento

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.ForceMeshUpdate();
        mesh = tmp.mesh;
        vertices = mesh.vertices;
    }

    void Update()
    {
        tmp.ForceMeshUpdate();
        mesh = tmp.mesh;
        vertices = mesh.vertices;

        int charCount = tmp.textInfo.characterCount;

        for (int i = 0; i < charCount; i++)
        {
            var charInfo = tmp.textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            int vertexIndex = charInfo.vertexIndex;
            Vector3 offset = new Vector3(0, Mathf.Sin(Time.time * frequency + i) * amplitude, 0);

            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j] = tmp.textInfo.meshInfo[charInfo.materialReferenceIndex].vertices[vertexIndex + j] + offset;
            }
        }

        // Actualizar los datos del mesh
        for (int i = 0; i < tmp.textInfo.meshInfo.Length; i++)
        {
            tmp.textInfo.meshInfo[i].mesh.vertices = vertices;
            tmp.UpdateGeometry(tmp.textInfo.meshInfo[i].mesh, i);
        }
    }
}

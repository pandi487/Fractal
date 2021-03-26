using System.Collections;
using UnityEngine;

public class CudeFractal : MonoBehaviour
{

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    [SerializeField] private int maxDepth;
    [SerializeField] private Rotation rotation;
    float speed;
    private int depth;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    private static Vector3[] chilDirections =
    {
        Vector3.up,
        Vector3.down,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back,
        //Vector3.zero
    };

    private static Quaternion[] childOrientations =
    {
        Quaternion.identity,
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(90f, 0f, 0f),
    };

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < chilDirections.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            new GameObject("Fractal Child").AddComponent<CudeFractal>().Initialized(this, i);
        }

    }
    [SerializeField] private float childScale;

    private void Initialized(CudeFractal parent, int childIndex)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
       
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = chilDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }
    // Update is called once per frame
    void Update()
    {

    }
}

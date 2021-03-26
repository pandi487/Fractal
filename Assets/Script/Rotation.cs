using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10f, 20f, 30f) * Time.deltaTime);

        transform.Rotate(new Vector3(10f, 20f, 30f) * Time.deltaTime, Space.World);

    }
}

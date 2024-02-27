using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private readonly float speed = 5.0f;
    private readonly float zBound = -10.0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);

        if (transform.position.z < zBound) Destroy(gameObject);
    }
}

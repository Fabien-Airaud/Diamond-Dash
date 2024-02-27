using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.back);
    }
}

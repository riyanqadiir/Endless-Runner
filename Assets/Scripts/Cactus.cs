using UnityEngine;

public class Cactus : MonoBehaviour
{
public float speed;
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
Invoke("destroyAfterTime",5);
}

// Update is called once per frame
void Update()
{
transform.Translate(Vector3.left * speed * Time.deltaTime);
}

void destroyAfterTime()
{
Destroy(gameObject);
}
}
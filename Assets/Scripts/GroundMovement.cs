using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject groundPrefab;
    public float speed;
    private bool hasSpawnedGround = false;

    private void Update()
    {
        if (Vector3.Distance(new Vector3(0.596819997f, -4.12195015f, 0), transform.position) < 0.2f && !hasSpawnedGround)
        {
            Instantiate(groundPrefab, new Vector3(0.596819997f + 20, -4.12195015f, 0), Quaternion.identity);
            hasSpawnedGround = true;
        }
        else if (Vector3.Distance(new Vector3(-20, -4.12195015f, 0), transform.position) < 0.2f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
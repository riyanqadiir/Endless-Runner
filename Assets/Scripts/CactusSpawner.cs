using Unity.Mathematics;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
public GameObject cactusA;
public GameObject cactusB;
public GameObject cactusC;
public float minTimeBetweenSpawns;
public float maxTimeBetweenSpawns;
void Start()
{
SpawnCactus();
}
void SpawnCactus()
{
Instantiate(ChooseRandomCactus(),transform.position,Quaternion.identity);
Invoke("SpawnCactus", UnityEngine.Random.Range(minTimeBetweenSpawns,maxTimeBetweenSpawns));
}
GameObject ChooseRandomCactus()
{
int random = UnityEngine.Random.Range(0,3);
GameObject[] Cactus = { cactusA, cactusB, cactusC };
return Cactus[random];
}
}

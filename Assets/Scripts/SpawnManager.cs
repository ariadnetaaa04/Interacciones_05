using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; //Array de los animales
    private int animalIndex; //indice del array de los animales

    private float spawnRangeX = 15;
    private float spawnPosZ = 20;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Llama periodicamente a la funcion SpawnRandomAnimal
        InvokeRepeating("SpawnRandomAnimal", startDelay, //segundos primera llamada,
 spawnInterval); //segundos entre llamadas);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    //funcion que hace aparecer un animal aleatorio en una posicion aleatoria
    private void SpawnRandomAnimal()
    {
        //Instantianehacer aparecer algo en la pantalla
        animalIndex = Random.Range(0, animalPrefabs.Length); //genera un indice aleatorio
        Instantiate(animalPrefabs[animalIndex],
        RandomSpawnPos(), animalPrefabs[animalIndex].transform.rotation);
    }

    //funcion que guenera un vector aleatorio
    private Vector3 RandomSpawnPos()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX); //Genera numero aleatorio para la posicion en x
        return new Vector3(randomX, 0, spawnPosZ);
    }
}

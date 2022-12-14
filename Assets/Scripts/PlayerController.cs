using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //velocidad player
    private float speed = 10f;
    //rango de movimiento del player (horizontal)
    private float xRange = 16f;

    //publica para poder arrastar en el inspector los prefabs al grupo
    public GameObject projectilePrefab;

    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Valor del Input. Movimineto horizontal del player
        horizontalInput = Input.GetAxis("Horizontal");
        //Movimiento manual... Time delta time (tiempo entre frame y frame, da un movimiento fluido)
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        //llamamos la funcion: Mantiene el player en la pantalla
        PlayerInBounds();

        //cuando va a disparar? Mecanica de disparo

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    //funcion que no devuelva nada ni recibe nada. Se encarga de hacer aparecer el proyectil.
    //mantiene el player en el limite inferior horizontal
    private void PlayerInBounds()
    {
        //guarda la posicion del player cada vez que llame a la funcion
        Vector3 pos = transform.position;
        //limite izquierdo. Pos.x (coordenada) -xRange (limite izq)
        if (pos.x < -xRange)
        {
            //se sobreescribe la cordenada en x para que no se pase 
            transform.position = new Vector3(-xRange, pos.y, pos.z);
        }
        //limite derecho
        if (pos.x > xRange)
        {
            transform.position = new Vector3(xRange, pos.y, pos.z);
        }
    }

    private void FireProjectile()
    {
        //aparece el prefab del proyectil. Game object, posicion i rotacion)
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala

    private void Update()
    {
        MoveBullet();
    }

    // Método para mover la bala hacia adelante en el eje Z
    void MoveBullet()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Método para desactivar la bala cuando sale de la pantalla
    void OnBecameInvisible()
    {
        gameObject.SetActive(false); // Desactivar la bala
    }

    // Método para activar la bala
    public void ActivateBullet(Vector3 position, Quaternion rotation)
    {
        transform.position = position; // Establecer la posición de la bala
        transform.rotation = rotation; // Establecer la rotación de la bala
        gameObject.SetActive(true); // Activar la bala
    }
}

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public int poolSize = 10; // Tamaño del pool
    private List<GameObject> bulletPool; // Pool de balas

    void Start()
    {
        // Inicializar el pool de balas
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    // Método para obtener una bala del pool
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
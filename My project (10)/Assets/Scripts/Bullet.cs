using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 

    private void Update()
    {
        MoveBullet();
    }


    void MoveBullet()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void ActivateBullet(Vector3 position, Quaternion rotation)
    {
        transform.position = position; 
        transform.rotation = rotation; 
        gameObject.SetActive(true);
    }
}

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public int poolSize = 10; 
    private List<GameObject> bulletPool;

    void Start()
    {

        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

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
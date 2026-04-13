using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> pool_of_bullets = new List<Bullet>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableAllBullets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisableAllBullets()
    {
        foreach(Bullet bullet in pool_of_bullets)
        {
            bullet.gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        Bullet bullet = pool_of_bullets[0];
        bullet.gameObject.SetActive(true);
        pool_of_bullets.Remove(bullet);
        pool_of_bullets.Add(bullet);
    }
}

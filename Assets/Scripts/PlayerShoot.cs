using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerShoot : MonoBehaviour
{

    public bool movingLeft;
    public bool readyToShoot;
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && readyToShoot)
        {
            Debug.Log("space key is pressed");
            SpawnProjectile();
            StartCoroutine(Cooldown());
        }
    }

    private void SpawnProjectile()
    {
        GameObject bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().goingLeft = movingLeft;
    }




    IEnumerator Cooldown()
    {
        readyToShoot = false;
        yield return new WaitForSeconds(1);
        readyToShoot = true;
    }


}
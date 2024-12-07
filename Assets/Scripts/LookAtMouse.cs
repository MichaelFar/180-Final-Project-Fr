using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objectToLook;

    public Vector3 mouseDirection;

    public GameObject projectile;

    public float fireRate = 0.3f;

    private float nextFire = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = WaveSingleton.Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 19.53f));
        objectToLook.transform.LookAt(mouseDirection);
        
        if(Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireProjectile();
        }
        
    }

    private void FireProjectile()
    {
        var projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = objectToLook.transform.position;
        projectileInstance.GetComponent<Bullet>().owner = gameObject;
        projectileInstance.GetComponent<Bullet>().direction = new Vector3(mouseDirection.x, 1.0f, mouseDirection.z);
    }
}

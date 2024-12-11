using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: Handles logic for rotating the player to look at the mouse, also handles shooting the player's projectile
public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    //Thing we make rotate
    public GameObject objectToLook;

    public Vector3 mouseDirection;
    // Player's projectile
    public GameObject projectile;

    public float fireRate = 0.3f;

    private float nextFire = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Handles the act of looking at the mouse, also handles the player shooting logic
    /// </summary>
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
    /// <summary>
    /// Spawns the projectile and initializes important values
    /// </summary>
    private void FireProjectile()
    {
        var projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = objectToLook.transform.position;
        projectileInstance.GetComponent<Bullet>().owner = gameObject;
        projectileInstance.GetComponent<Bullet>().direction = new Vector3(mouseDirection.x, 1.0f, mouseDirection.z);
    }
}

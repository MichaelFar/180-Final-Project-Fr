using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: Handles how the projectiles move, also contains owner to prevent friendly fire and self harm
public class Bullet : MonoBehaviour
{

    public float speed;

    public Vector3 direction;

    public GameObject owner;
    // Start is called before the first frame update
    /// <summary>
    /// Invokes deleteSelf so that bullets don't last forever, sets the rotation to the direction which is supplied by whatever spawned it (BaseEnemy or LookAtMouse)
    /// </summary>
    void Start()
    {
        Invoke(nameof(deleteSelf), 10.0f);
        gameObject.transform.LookAt(direction);
        gameObject.GetComponent<Damager>().owner = owner;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }


    /// <summary>
    /// Moves the bullet towards where its facing
    /// </summary>
    private void BulletMove()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    /// <summary>
    /// Deletes self
    /// </summary>
    private void deleteSelf()
    {
        Destroy(gameObject);
    }
}   
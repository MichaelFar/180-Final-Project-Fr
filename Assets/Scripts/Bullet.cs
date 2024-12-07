using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    public Vector3 direction;

    public GameObject owner;
    // Start is called before the first frame update
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



    private void BulletMove()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void deleteSelf()
    {
        Destroy(gameObject);
    }
}   
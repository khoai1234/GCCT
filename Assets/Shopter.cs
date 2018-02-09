
using UnityEngine;

class Shopter : MonoBehaviour
{
    public Rigidbody prefab;
    public float speed = 10.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var obj = (Rigidbody)Instantiate(this.prefab, transform.position, transform.rotation);
            obj.velocity = (transform.forward + transform.up / 2) * speed;
        }

    }

}

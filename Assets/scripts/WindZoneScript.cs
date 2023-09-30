using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneScript : MonoBehaviour
{
    public Vector2 windForce;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Movable"))
        {
            Rigidbody2D rb2D = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                rb2D.AddForce(windForce);
            }
        }
    }
}

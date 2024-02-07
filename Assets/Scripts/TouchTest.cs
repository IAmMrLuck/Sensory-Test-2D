using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Sensory")
            return;

        Vector3 contactPoint = collision.ClosestPoint(transform.position);
        spriteRenderer.color = Color.red;
        Debug.Log("Touched " + contactPoint);

    }

}

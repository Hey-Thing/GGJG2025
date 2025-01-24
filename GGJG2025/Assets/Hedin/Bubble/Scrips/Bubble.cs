using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float initialSpeed = 10f;
    private float speed;
    private Rigidbody2D rb;
    private float elapsedTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(1f, 3f);
        initialSpeed = Random.Range(10f, 35f);
        speed = initialSpeed;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        rb.velocity = transform.right * speed;

        speed = initialSpeed * Mathf.Exp(-elapsedTime * 2f);
    }
}

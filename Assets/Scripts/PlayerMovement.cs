using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float colliderResolveDist = 0.05f;

    private Rigidbody2D rb;

    private bool isWalking;
    private Vector2 targetPos;
    private Vector2 startPos;
    private float clickTime;
    private float destinationTime; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouse();

        if (isWalking) {
            float lerpPos = Mathf.Abs(Time.realtimeSinceStartup - clickTime) / destinationTime;
            rb.position = Vector2.Lerp(startPos, targetPos, lerpPos);
            isWalking = lerpPos < 1;
        }
    }

    void HandleMouse()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var mousePos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        startPos = rb.position;
        clickTime = Time.realtimeSinceStartup;
        destinationTime = (targetPos - startPos).magnitude;
        isWalking = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 cPos = collision.contacts[0].point;
        var resolveVec = (rb.position - cPos).normalized;
        rb.position += resolveVec * colliderResolveDist;
        isWalking = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isWalking = false;
    } 
}

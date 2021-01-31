using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    private enum WalkDir
    {
        Front = 0,
        Back,
        Side
    }

    [SerializeField]
    private float colliderResolveDist = 0.05f;

	public float minScale = 0.75f, maxScale = 2;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private bool isWalking;
    private WalkDir walkDir = WalkDir.Front;

    private Vector2 targetPos;
    private Vector2 startPos;
    private float clickTime;
    private float destinationTime;
    private bool mouseActive = true;
    public bool MouseActive {
		get => mouseActive;
		set {
			mouseActive = value;
			if (!value) isWalking = false;
		}
	}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
		transform.localScale = Vector3.one * ((maxScale - minScale) * (1 - Camera.main.WorldToViewportPoint(transform.position).y) + minScale);

        if (mouseActive)
        {
            HandleMouse();
        }

        // Always set this because we are lazy
        anim.SetBool("isWalking", isWalking);
        anim.SetInteger("walkDir", (int) walkDir);

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
        var walkDirVector = targetPos - startPos;
        destinationTime = walkDirVector.magnitude;
        isWalking = true;

        // Calculate walk direction
        float angle = Vector2.SignedAngle(Vector2.right, walkDirVector.normalized);
        if (angle > -45 && angle < 45)
        {
            walkDir = WalkDir.Side;
            sr.flipX = false;
        } else if (angle > 135 && angle <= 180 || angle >= -180 && angle < -135)
        {
            walkDir = WalkDir.Side;
            sr.flipX = true;
        } else if (angle >= 45 && angle <= 135)
        {
            walkDir = WalkDir.Back;
        } else if (angle <= -45 && angle >= -135)
        {
            walkDir = WalkDir.Front;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 cPos = collision.collider.ClosestPoint(transform.position);
        var resolveVec = (targetPos - startPos).normalized;
        rb.position -= resolveVec * colliderResolveDist;
        isWalking = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isWalking = false;
    } 
}

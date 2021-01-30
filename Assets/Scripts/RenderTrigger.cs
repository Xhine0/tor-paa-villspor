using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RenderTrigger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerRender;

    [SerializeField]
    private int enterLayer;

    private int exitLayer;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerRender)
        {
            Debug.LogError($"Missing player render in {gameObject.name}!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        exitLayer = playerRender.sortingOrder;
        playerRender.sortingOrder = enterLayer;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerRender.sortingOrder = exitLayer;
    }
}

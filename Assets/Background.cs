using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] float xSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.mainTextureOffset += new Vector2(xSpeed * Time.deltaTime, 0);
    }
}

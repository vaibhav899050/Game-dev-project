using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneMove : MonoBehaviour
{
    // Start is called before the first frame update
    private List<replay> input;
    public playerscript sc;
    private SpriteRenderer renderer;
    public LayerMask groundlayer;
    bool isgrounded;
    public Transform groundcheck;
    int i = 0;
    Rigidbody2D rb;
    public float jumpforce = 5f;
    void Start()
    {
        float a = Random.Range(0.5f, 1f);
        float b = Random.Range(0.5f, 1f);
        float c = Random.Range(0.4f, 1f);
        float d = Random.Range(0.3f, 1f);

        input = sc.InputRecord;
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        renderer.color = new Color(a, b, c, d);
    }

    // Update is called once per frame
    void Update()


    {

        isgrounded = Physics2D.OverlapCapsule(groundcheck.position, new Vector2(0.99f, 0.16f), CapsuleDirection2D.Horizontal, 0, groundlayer);
        if (Time.time > 1.5)
        {
            replay temp = input[i];
            transform.position = new Vector2(transform.position.x + temp.x * Time.deltaTime * 10f, transform.position.y);
            if (temp.y == 1 && isgrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x,jumpforce);
            }
            i++;
            
        }

    }
}

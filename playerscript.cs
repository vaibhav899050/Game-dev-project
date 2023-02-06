using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour


{
    public float speed = 10f;
    public GameObject player;
    public List<replay> InputRecord = new List<replay>();
    public float jumpforce = 5f;
    Rigidbody2D rb;
    public Transform groundcheck;
    public LayerMask groundlayer;
    public LayerMask clonelayer;
    bool isgrounded;
    bool isgroundclone;
    int spacepress = 0;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {

            spacepress = 1;
        }
        else
        {
            spacepress = 0;
        }
        
        replay temp = new replay { x = horizontal , y = spacepress};
        isgrounded = Physics2D.OverlapCapsule(groundcheck.position, new Vector2(0.99f, 0.16f), CapsuleDirection2D.Horizontal, 0, groundlayer);
        isgroundclone = Physics2D.OverlapCapsule(groundcheck.position, new Vector2(0.99f, 0.16f), CapsuleDirection2D.Horizontal, 0, clonelayer);
        InputRecord.Add(temp);
        
        player.transform.position =new Vector3(player.transform.position.x + horizontal * speed * Time.deltaTime, player.transform.position.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isgroundclone|| isgrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
            

        }


    }
}

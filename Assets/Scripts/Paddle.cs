using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isAI;
    public GameObject ball;
    public float speed = 3;

    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(isAI)
        {
            float targetPY = Movement();

            transform.position = new Vector3(transform.position.x, targetPY, transform.position.z);

            //rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }

    private float Movement()
    {

        float result = transform.position.y;
        foreach(Touch touch in Input.touches)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 myPos = rb.position;

            if(Mathf.Abs(touchPos.x - myPos.x)<=2 && !isAI)
            {
                myPos.y = Mathf.Lerp(myPos.y, touchPos.y, 10);

                myPos.y = Mathf.Clamp(myPos.y, -3.7f, 3.7f);

                rb.position = myPos;
            }


           
        }

        if(isAI)
        {
           result= Mathf.MoveTowards(transform.position.y, ball.transform.position.y, speed * Time.deltaTime);
        }

        return result;
    }

   
}

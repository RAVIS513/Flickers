using UnityEngine;
using System.Collections;

/*******************************************
 *
 * @file	EnemyScript.cs
 * @brief	敵処理
 * @author	goto
 * @date	2016/12/25
 *
 *******************************************/
public class EnemyScript : MonoBehaviour {

    private float speed;
    private bool vector;
    private bool adder;

    void Awake()
    {

        speed = 0.2f;
        vector = false;
        adder = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (speed <= 0.0f)
        {

            if (vector)
            {

                vector = false;

            }
            else
            {

                vector = true;

            }

        }

        if (speed <= 0.0f)
        {

            adder = true;

        }
        else if (speed >= 0.2f)
        {

            adder = false;

        }

        if (adder)
        {

            speed += 0.02f;

        }
        else
        {

            speed -= 0.02f;

        }


        Vector2 pos = transform.position;

        if (vector)
        {

            pos.x += speed;

        }
        else
        {

            pos.x -= speed;

        }

        transform.position = pos;

    }
}

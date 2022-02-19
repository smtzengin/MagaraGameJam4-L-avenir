using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LavenirGamesMAGARAJAM4.Movements
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 5f;

        public float Speed => speed;

        public void HorizontalMove(float horizontal)
        {
            //transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
            if(horizontal > 0)
            {
                transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
            }

            if (horizontal < 0)
            {
                transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
            }
        }
    }
}

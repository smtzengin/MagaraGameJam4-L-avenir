using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LavenirGamesMAGARAJAM4.Movements
{
    public class Flip : MonoBehaviour
    {
         public void FlipCharacter(float horizontal)
        {
            if(horizontal != 0)
            {
                float mathfvalue = Mathf.Sign(horizontal);
                if (transform.localScale.x == mathfvalue) return;

                transform.localScale = new Vector2(mathfvalue, 1f);
            }
        }
    }
}

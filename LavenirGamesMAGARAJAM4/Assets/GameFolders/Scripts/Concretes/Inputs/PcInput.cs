using LavenirGamesMAGARAJAM4.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LavenirGamesMAGARAJAM4.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public float Vertical => Input.GetAxis("Vertical");

        public bool isJumpButtonDown => Input.GetButtonDown("Jump");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LavenirGamesMAGARAJAM4.Abstracts
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }

        bool isJumpButtonDown { get; }
    }
}

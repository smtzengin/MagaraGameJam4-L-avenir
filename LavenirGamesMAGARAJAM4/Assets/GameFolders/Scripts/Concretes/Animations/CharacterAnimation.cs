using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LavenirGamesMAGARAJAM4.Animations
{ 
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void MoveAnimation(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (_animator.GetFloat("moveSpeed") == mathfValue) return;

            _animator.SetFloat("moveSpeed", mathfValue);
        }

        public void JumpAnimation(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", isJump);
        }

        public void CrouchAnimation(bool isCrouch)
        {
            if (isCrouch == _animator.GetBool("isCrouch")) return;
            _animator.SetBool("isCrouch", isCrouch);
        }

        public void CrouchWalkingAnimation(bool isCrouchWalking)
        {
            if (isCrouchWalking == _animator.GetBool("isCrouchWalking")) return;
            _animator.SetBool("isCrouchWalking", isCrouchWalking);
        }
    }
}

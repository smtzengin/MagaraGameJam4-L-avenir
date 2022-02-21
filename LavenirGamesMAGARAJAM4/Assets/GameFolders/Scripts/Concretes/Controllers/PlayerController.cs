using LavenirGamesMAGARAJAM4.Abstracts;
using LavenirGamesMAGARAJAM4.Animations;
using LavenirGamesMAGARAJAM4.Inputs;
using LavenirGamesMAGARAJAM4.Managers;
using LavenirGamesMAGARAJAM4.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LavenirGamesMAGARAJAM4.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        CharacterAnimation _characterAnimation;
        bool _isJump;
        float _horizontal;
        float _vertical;
        bool IsTouch;
        
       

        IPlayerInput _input;
        Mover _mover;
        Flip _flip;
        Jump _jump;
        OnGround _onGround;
        Crouch _crouch;
        AudioSource audioSource;



        public void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _jump = GetComponent<Jump>();
            _onGround = GetComponent<OnGround>();
            _input = new PcInput();
            _crouch = GetComponent<Crouch>();
            audioSource = GetComponent<AudioSource>();




        }

        public void Update()
        {
           

            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;
            if (_input.isJumpButtonDown && _onGround.IsOnGround)
            {
                _jump.JumpAction();
                _isJump = true;
                audioSource.PlayOneShot(audioSource.clip, 0.5f);
            }



            if (_crouch.isCrouch && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                _characterAnimation.CrouchWalkingAnimation(true);

            }
            else
            {
                _characterAnimation.CrouchWalkingAnimation(false);

            }

            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJump);

        }

        public void FixedUpdate()
        {
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == ("FinalCollider"))
            {
                if (!IsTouch)
                {
                    GameManager.Instance.LoadScene(2);
                    IsTouch = true;
                    StartCoroutine(TouchDelay(5f));
                }
                
            }

            if (collision.gameObject.tag == "DeadZone")
            {
                GameManager.Instance.LoadScene(0);
            }
        }

        public IEnumerator TouchDelay(float delayClickTime)
        {
            yield return new WaitForSeconds(delayClickTime);
            IsTouch = false;

        }
    }
}

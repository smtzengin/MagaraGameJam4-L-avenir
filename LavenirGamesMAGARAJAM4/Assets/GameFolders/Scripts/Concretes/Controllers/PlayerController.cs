using LavenirGamesMAGARAJAM4.Abstracts;
using LavenirGamesMAGARAJAM4.Animations;
using LavenirGamesMAGARAJAM4.Combats;
using LavenirGamesMAGARAJAM4.Inputs;
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

        IPlayerInput _input;
        Mover _mover;
        Flip _flip;
        Jump _jump;
        OnGround _onGround;
        Health _health;
        Damage _damage;


        public void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _jump = GetComponent<Jump>();
            _onGround = GetComponent<OnGround>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _input = new PcInput();


        }

        public void Update()
        {
            if (_health.IsDead) return;

            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;
            if (_input.isJumpButtonDown && _onGround.IsOnGround)
            {
                _jump.JumpAction();
                _isJump = true;
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
            
        }
    }
}
using LavenirGamesMAGARAJAM4.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LavenirGamesMAGARAJAM4.Movements
{
    public class Crouch : MonoBehaviour
    {
        Vector2 _colSize;
        Vector2 _offset;

        CharacterAnimation _characterAnimation;

        bool _isCrouch;
        public bool isCrouch => _isCrouch;
        int _pushCButton = 0;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _colSize = gameObject.GetComponent<BoxCollider2D>().size;
            _offset = gameObject.GetComponent<BoxCollider2D>().offset;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _colSize = gameObject.GetComponent<BoxCollider2D>().size;
                _offset = gameObject.GetComponent<BoxCollider2D>().offset;
                if (_pushCButton == 0)
                {
                    _pushCButton += 1;
                    _isCrouch = true;
                    _characterAnimation.CrouchAnimation(_isCrouch);
                    gameObject.GetComponent<BoxCollider2D>().size = new Vector2(_colSize.x, _colSize.y - 0.5f);
                    gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(_offset.x, _offset.y - 0.25f);
                }
                else if (_pushCButton >= 0)
                {
                    _isCrouch = false;
                    _characterAnimation.CrouchAnimation(_isCrouch);
                    gameObject.GetComponent<BoxCollider2D>().size = new Vector2(_colSize.x, _colSize.y + 0.5f);
                    gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(_offset.x, _offset.y + 0.25f);
                    _pushCButton = 0;

                }


            }
            
        }
    }
}


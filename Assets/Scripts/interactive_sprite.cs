using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class interactive_sprite : MonoBehaviour
{
    [SerializeField] private Button _loadSceneButton;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private string _animName;
    private Animator _animator;
    private bool _isAnimationStart = false;

    private void Awake()
    {
        if (_collider == null)
            _collider = GetComponent<BoxCollider2D>();

        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_collider.OverlapPoint(mousePosition))
            {
                if (_isAnimationStart == false)
                {
                    _animator.Play(_animName);
                    _isAnimationStart = true;
                }
                else
                {
                    _loadSceneButton.gameObject.SetActive(true);
                }
            }


        }
    }
}
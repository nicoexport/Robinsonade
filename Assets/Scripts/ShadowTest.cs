using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTest : MonoBehaviour
{
   [SerializeField] private Sprite _happySprite;
   [SerializeField] private Color _happyColor;
   [SerializeField] private Sprite _uncomfortableSprite;
   [SerializeField] private Color _uncomfortableColor;
   [SerializeField] private GameObject _desireObject;
   private SpriteRenderer _rend;

   private void Awake()
   {
      _rend = GetComponent<SpriteRenderer>();
      _rend.sprite = _uncomfortableSprite;
      _rend.color = _uncomfortableColor;
   }

   public void Solve()
   {
      _rend.sprite = _happySprite;
      _rend.color = _happyColor;
      _desireObject.SetActive(false);
   }
}

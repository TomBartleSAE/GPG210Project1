using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Tom
{
    public class MainMenu : MonoBehaviour
    {
        public MovingTween background;
        public CanvasAlphaTween title;
        public CanvasAlphaTween buttons;

        private bool menuShowing = false;
        
        private void Start()
        {
            ShowMenu();
        }

        private void Update()
        {
            // HACK
            // Change to new input system
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuShowing)
                {
                    HideMenu();
                }
                else
                {
                    ShowMenu();
                }
            }
        }

        public void ShowMenu()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(background.Move(1000, 0, 2).SetEase(Ease.OutBounce));
            sequence.Append(title.Fade(0, 1, 1));
            sequence.Append(buttons.Fade(0, 1, 1));

            menuShowing = true;
        }

        public void HideMenu()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(background.Move(0, 1000, 2).SetEase(Ease.InBounce));

            menuShowing = false;
        }
    }
}
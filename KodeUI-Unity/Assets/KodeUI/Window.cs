﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KodeUI
{
    public class Window : LayoutPanel
    {
        private RectTransform canvasRectTransform;
		Titlebar titlebar;
        
        public override void CreateUI()
        {
            base.CreateUI();

            // Should be handled in UIObject with more Properties ? It would make moving to a new canvas easier ?
            Canvas canvas = GetComponentInParent<Canvas>();
            canvasRectTransform = canvas.GetComponent<RectTransform>();

			Add<Titlebar>(out titlebar).Window(this).Finish();
        }

        public override void Style()
        {
            base.Style();

            BackGround.sprite = style.sprite;
            BackGround.color = style.color ?? UnityEngine.Color.white;

            Padding(4, 4, 0, 4);
        }

		public Window Title (string title)
		{
			titlebar.Title (title);
			return this;
		}
    }
}

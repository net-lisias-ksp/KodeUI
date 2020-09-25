﻿using UnityEngine;
using UnityEngine.UI;

namespace KodeUI
{
    public class LayoutPanel : Layout
    {
        private Image backGround;

        public Image BackGround
        {
            get { return backGround; }
        }

        public override void CreateUI()
        {
            base.CreateUI();

            Anchor(AnchorPresets.StretchAll).Pivot(PivotPresets.TopLeft);
            
            rectTransform.anchoredPosition = Vector2.zero;
            
            backGround = gameObject.AddComponent<Image>();
            backGround.type = Image.Type.Sliced;
            backGround.color = UnityEngine.Color.clear;;
        }

        public override void Style()
        {
            base.Style();
            backGround.sprite = style.sprite;
            backGround.color = style.color ?? UnityEngine.Color.clear;
        }

        public LayoutPanel Background(Sprite sprite, Image.Type type =  Image.Type.Simple)
        {
            backGround.sprite = sprite;
            backGround.type = type;
            return this;
        }

        public LayoutPanel Background(string image)
        {
            ImageLoader.SetupImage(backGround,image);
            return this;
        }

        public LayoutPanel BackgroundColor(Color color)
        {
            backGround.color = color;
            return this;
        }


    }
}

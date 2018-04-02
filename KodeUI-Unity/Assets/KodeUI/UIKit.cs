﻿using System;
using UnityEngine;

namespace KodeUI
{
   public class UIKit
    {
        public static T CreateUI<T>(RectTransform rectTransform, string id) where T : UIObject
        {
            var childObj = new GameObject(id);
            childObj.transform.SetParent(rectTransform, true);
            RectTransform rect = childObj.AddComponent<RectTransform>();
            T child = childObj.AddComponent<T>();

            rect.anchoredPosition3D = Vector3.zero;

            child.CreateUI();
            return child;
        }
    }
}

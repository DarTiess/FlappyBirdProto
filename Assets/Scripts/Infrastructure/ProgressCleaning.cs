﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Infrastructure
{
    public class ProgressCleaning : EditorWindow
    {
        [MenuItem("ClearProgress/Clear")]
        static void Init()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Progress Clear");
        }
    }
}
#endif
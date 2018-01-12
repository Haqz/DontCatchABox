using System;
using UnityEngine;

namespace Polarith.AI.Examples
{
    /// <summary>
    /// Computes and displays the framerate.
    /// <para/>
    /// Note, this is just a script for our example scenes and therefore not part of the actual API. We do not guarantee
    /// that this script is working besides our examples.
    /// </summary>
    public sealed class FramesPerSecond : MonoBehaviour
    {
        #region Fields =================================================================================================

        /// <summary>
        /// If <c>true</c>, the framerate will be shown in the top right of the screen.
        /// </summary>
        [Tooltip("If true, the framerate will be shown in the top right of the screen.")]
        public bool showFramesPerSecond = true;

        /// <summary>Sets the font color.</summary>
        [Tooltip("Sets the font color.")]
        public Color fontColor = Color.white;

        //--------------------------------------------------------------------------------------------------------------

        private Rect position = new Rect(0.0f, 0.0f, 100.0f, 20.0f);
        private string framerateStr;
        private float deltaTime = 0.0f;

        #endregion // Fields

        #region Methods ================================================================================================

        private void Start()
        {
            DontDestroyOnLoad(this);

            position.x = Screen.width - position.width - 10.0f;
            position.y = 10.0f;
        }

        //--------------------------------------------------------------------------------------------------------------

        private void Update()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }

        //--------------------------------------------------------------------------------------------------------------

        private void OnGUI()
        {
            if (!showFramesPerSecond)
                return;

            float fps = 1.0f / deltaTime;
            framerateStr = String.Format("{0:f1}", fps);

            GUI.contentColor = fontColor;
            GUI.Label(position, string.Format("<b><size=16>FPS: {0}</size></b>", framerateStr));
        }

        #endregion // Methods
    } // class FramesPerSecond
} // namespace Polarith.AI.Examples

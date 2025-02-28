using UnityEngine;
using UnityEngine.UI;

namespace TCG.Utils
{
    public static class UIUtils
    {

        /// <summary>
        /// Go through all the child transforms of an object and call ForceRebuildLayoutImmediate on any RectTransform components found
        /// </summary>
        /// <typeparam name="T">Type of the singleton</typeparam>
        public static void ForceRebuildFromChildBackwards(this Transform transformToRebuild )
        {
            foreach ( Transform child in transformToRebuild )
            {
                ForceRebuildFromChildBackwards( child );
            }
            RectTransform rectTransform = transformToRebuild as RectTransform;
            if ( rectTransform != null )
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate( rectTransform );
            }
        }        
    }
}
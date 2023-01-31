using UnityEngine;
using UnityEditor;

namespace OccaSoftware.Buto.Editor
{
    [CustomEditor(typeof(FogDensityMask)), CanEditMultipleObjects]
    public class FogDensityMaskEditor : UnityEditor.Editor
    {
        SerializedObject o;

        private static class Props
		{
            public static SerializedProperty mode;
            public static SerializedProperty densityMultiplier;
            public static SerializedProperty radius;
            public static SerializedProperty falloff;
		}


        private void OnEnable()
		{
            o = serializedObject;
            Props.mode = o.FindProperty(nameof(Props.mode));
            Props.densityMultiplier = o.FindProperty(nameof(Props.densityMultiplier));
            Props.radius = o.FindProperty(nameof(Props.radius));
            Props.falloff = o.FindProperty(nameof(Props.falloff));
        }

		public override void OnInspectorGUI()
		{
            o.Update();
            EditorGUILayout.PropertyField(Props.mode, new GUIContent("Blend Mode", "Set the blend mode of this fog mask. When set to Multiplicative, the mask will multiply the base fog density by the value set in Density Multiplier. When set to Exclusive, the mask will hide fog outside of its radius."));
            bool isExclusiveMode = (FogDensityMask.BlendMode)Props.mode.enumValueIndex == FogDensityMask.BlendMode.Exclusive ? true : false;
            using (new EditorGUI.DisabledScope(isExclusiveMode))
            {
                EditorGUILayout.PropertyField(Props.densityMultiplier, new GUIContent("Density Multiplier", "Set the multiplier for the base fog. Values below 1 decrease the fog; values above 1 increase the fog. Disabled when in Exclusive blend mode."));
            }

            EditorGUILayout.PropertyField(Props.radius, new GUIContent("Radius", "Defines the extent of the mask effect."));
            EditorGUILayout.PropertyField(Props.falloff, new GUIContent("Falloff", "Set the distance from the mask's center at which mask will take full effect. For example, a value of 0.9 indicates that the mask will take full effect just 10% of the way inside of the mask bounds."));

            o.ApplyModifiedProperties();
        }
	}
}

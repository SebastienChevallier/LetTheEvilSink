using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueTrigger))]
public class Editor_Dialogues : Editor
{
    private SerializedProperty canBeTriggerProperty;
    private SerializedProperty autoDialogProperty;
    private SerializedProperty newObjectifProperty;
    private SerializedProperty objectifProperty;
    private SerializedProperty newDialogueProperty;
    private SerializedProperty listDialogueProperty;
    private SerializedProperty disProperty;
    private SerializedProperty pnjDespawnProperty;

    private void OnEnable()
    {
        canBeTriggerProperty = serializedObject.FindProperty("canBeTrigger");
        autoDialogProperty = serializedObject.FindProperty("autoDialog");
        newObjectifProperty = serializedObject.FindProperty("newObjectif");
        objectifProperty = serializedObject.FindProperty("objectif");
        newDialogueProperty = serializedObject.FindProperty("newDialogue");
        listDialogueProperty = serializedObject.FindProperty("_ListDialogue");
        disProperty = serializedObject.FindProperty("_Dis");
        pnjDespawnProperty = serializedObject.FindProperty("pnjDespawn");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(canBeTriggerProperty);
        EditorGUILayout.PropertyField(disProperty);
        EditorGUILayout.PropertyField(autoDialogProperty);
        EditorGUILayout.PropertyField(pnjDespawnProperty);

        if (canBeTriggerProperty.boolValue)
        {

            EditorGUILayout.PropertyField(newDialogueProperty);

            if (newDialogueProperty.boolValue)
            {
                EditorGUILayout.PropertyField(listDialogueProperty);
            }

            EditorGUILayout.PropertyField(newObjectifProperty);
            if (newObjectifProperty.boolValue)
            {
                EditorGUILayout.PropertyField(objectifProperty);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}

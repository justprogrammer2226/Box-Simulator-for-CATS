using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameResourceData))]
[CanEditMultipleObjects]
public class GameResourceDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameResourceData gameResourceData = (GameResourceData)target;

        // Get all variables
        SerializedProperty id = serializedObject.FindProperty("_id");
        SerializedProperty type = serializedObject.FindProperty("_type");
        SerializedProperty targetValue = serializedObject.FindProperty("_targetValue");
        SerializedProperty sprite = serializedObject.FindProperty("_sprite");

        // Display id
        id.intValue = EditorGUILayout.IntField("Id", id.intValue);

        // Display enum
        type.enumValueIndex = (int)(GameResourceType)EditorGUILayout.EnumPopup("Type:", (GameResourceType)type.enumValueIndex);

        // Display target value
        if (type.enumValueIndex == (int)GameResourceType.Box)
        {
            targetValue.intValue = EditorGUILayout.IntField("Target Value", targetValue.intValue);
        }

        // Display sprite
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Source Image");
        sprite.objectReferenceValue = (Sprite)EditorGUILayout.ObjectField(sprite.objectReferenceValue, typeof(Sprite), false);
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
            SetObjectDirty(gameResourceData);
        }
    }

    public static void SetObjectDirty(GameResourceData obj)
    {
        EditorUtility.SetDirty(obj);
    }
}


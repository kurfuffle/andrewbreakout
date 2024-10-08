using UnityEngine;
using UnityEditor;

[CustomeEditor(typeof(Level))]
public class LevelEditor : Editor
{

    Level level;

    void OnEnable(){
        level = (Level)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();

        DrawLevelGrid();
    }

    void DrawLevelGrid(){
        GUILayout.BeginVertical();
        for (int y = 0; y < 7; y++){
            GUILayout.BeginHorizontal();
            for (int x = 0; x < 7; x++){

                GUI.backgroundColor = Brick.hpColors[]
            }
        }
    }
}

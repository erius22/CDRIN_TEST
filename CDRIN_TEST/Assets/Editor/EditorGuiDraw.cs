using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectProperty))]
[CanEditMultipleObjects]
public class EditorGUIDrawRectExample : Editor
{
    //This is the value of the Slider
    float m_Value;

    float x;
    float y;
    float width;
    float depth;

    Vector3 rectPos;
    Vector3 rectCenter;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectProperty myScript = (ObjectProperty)target;


        myScript.rectSize = EditorGUILayout.Vector3Field("Rectangle size", myScript.rectSize);
        myScript.rectOffset = EditorGUILayout.Vector3Field("Rectangle offset", myScript.rectOffset);


       // OnDrawGizmos(); 
    }


}

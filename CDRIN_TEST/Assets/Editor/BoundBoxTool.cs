using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEditor;

/**
 * ressource utilise : https://docs.unity3d.com/560/Documentation/ScriptReference/IMGUI.Controls.PrimitiveBoundsHandle.DrawHandle.html
 * 
 */
[CustomEditor(typeof(ObjectProperty))]
[CanEditMultipleObjects]
public class BoundBoxTool : Editor
{

    private BoxBoundsHandle boundsHandle = new BoxBoundsHandle();


    protected virtual void OnSceneGUI()
    {

        //vas chercher l'objet
        ObjectProperty myObject = (ObjectProperty)target;


        //modifie la box
        boundsHandle.center = myObject.gameObject.transform.position + myObject.bounds.center;
        boundsHandle.size = myObject.bounds.size;

        //change la couleur de la box au choix
        boundsHandle.SetColor(myObject.colorBoundsBox);

        // dessine la box
        EditorGUI.BeginChangeCheck();
        boundsHandle.DrawHandle();
        if (EditorGUI.EndChangeCheck())
        {
            // sauvegarde de l'objet pour faire un undo/redo sur la modification de la box
            Undo.RecordObject(myObject, "Change Bounds");

            // copie la box updater vers l'objet
            Bounds newBounds = new Bounds();
            newBounds.center = myObject.bounds.center;
            newBounds.size = boundsHandle.size;
            myObject.bounds = newBounds;
        }
    }

    //pour l'affichage des propriete avec l'outil
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}

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

    private bool zoneModifiable;


    protected virtual void OnSceneGUI()
    {

        //vas chercher l'objet
        ObjectProperty myObject = (ObjectProperty)target;



        //affiche ou non de la zone autour de l'objet
        /*
        if (zoneModifiable == true)
        {
            boundsHandle.axes = PrimitiveBoundsHandle.Axes.All;
        }
        else
        {
            boundsHandle.axes = PrimitiveBoundsHandle.Axes.None;
        }
        */

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

        //bouton pour activer/desactive l'affichage de la zone autour de l'objet
        /*
        if (GUILayout.Button("Modifier zone"))
        {
            zoneModifiable = !zoneModifiable;

            boundsHandle.DrawHandle();
        }*/


        DrawDefaultInspector();

        ObjectProperty myObject = (ObjectProperty)target;


        myObject.VariablePrive = EditorGUILayout.FloatField("Ma variable prive", myObject.VariablePrive);



    }

    //bouton pour ajouter le script "ObjectProperty" automatiquement a tout les objets avec le tag "environnement"
    [MenuItem("Tool/Add ObjectProperty")]
    private static void ObjectProertyOption()
    {
        foreach (GameObject environnementObject in GameObject.FindGameObjectsWithTag("Environnement"))
        {
            if (environnementObject.GetComponent<ObjectProperty>() == null)
            {
                environnementObject.AddComponent<ObjectProperty>();
            }
        }
    }
}

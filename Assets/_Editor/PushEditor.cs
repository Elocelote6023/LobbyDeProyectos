using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PushRigidBody))]
public class PushEditor : Editor
{
    int force;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PushRigidBody myTaget = (PushRigidBody)target;

        // Puedes editar el numero
        //myTaget.PushPower = EditorGUILayout.FloatField("Fuerza de empuje: ", myTaget.PushPower);

        // No puedes editar el numero:
        EditorGUILayout.LabelField("Fuerza de empuje: ", myTaget.PushPower.ToString());

        force = EditorGUILayout.IntField("Fuerza a sumar", force);

        if (GUILayout.Button("Sumar Fuerza: " + force.ToString()))
        {
            myTaget.SumarFuerza(force);
        }
    }
}

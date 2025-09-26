using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    [MenuItem("NuevaOpción/Mi Ventana")]
    public static void ShowWindow()
    {
        // Crea una instancia de la ventana y la muestra
        EditorWindow.GetWindow<MyWindow>("Mi Ventana");
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.Label("Botón:");

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Haz clic aquí"))
        {
            Debug.Log("Hola");
        }
    }

    [MenuItem("NuevaOpción/My Options/Girar Objeto", priority = 0)]
    private static void GirarObjeto()
    {
        // Obtiene el objeto seleccionado en la escena
        GameObject selectedObject = Selection.activeGameObject;

        // Verifica si hay un objeto seleccionado
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(new Vector3(0, 45, 0));
        }
        else
        {
            Debug.Log("No has seleccionado un objeto");
        }
    }

    [MenuItem("NuevaOpción/My Options/Deseleccionar Objetos", priority = 1)]
    private static void Deseleccionar()
    {
        Selection.activeObject = null;
    }
}
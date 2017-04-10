using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Ship))]

public class ShipInspector : Editor
{
    int selChoose = 0;
    string[] selStrings = new string[] { "Ship", "Crew Member"};
    public int total = 0;

    public override void OnInspectorGUI()
    {
        Ship myShip = (Ship)target;

        GUILayout.BeginVertical("Box");
        selChoose = GUILayout.SelectionGrid(selChoose, selStrings, 2);

        if (selChoose == 0)
        {  
            EditorGUILayout.LabelField(new GUIContent("Ship Stats", "Must be 10, total for att, armor, agi can't be over 100"));
            myShip.attack = EditorGUILayout.IntSlider("Attack", myShip.attack, 10, 80);
            myShip.armor = EditorGUILayout.IntSlider("Armor", myShip.armor, 10, 80);
            myShip.agility = EditorGUILayout.IntSlider("Agility", myShip.agility, 10, 80);
            total = (myShip.attack + myShip.armor + myShip.agility);
            total = EditorGUILayout.IntField(new GUIContent("Total points assign", "Total can't be over 100"), total);

            myShip.hitPoints = EditorGUILayout.IntSlider("Hit Points", myShip.hitPoints, 1, 1000);


            if (myShip.attack + myShip.armor + myShip.agility > 100)
            {
                EditorGUILayout.HelpBox("Total can't exceed 100", MessageType.Warning);
                myShip.attack = 10;
                myShip.armor = 10;
                myShip.agility = 10;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Space(12);
            SerializedProperty gunStyle = serializedObject.FindProperty("shipGuns");
            EditorGUILayout.PropertyField(gunStyle, new GUIContent("Gun Style"), true);
            GUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }

        if (selChoose == 1) 
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(12);
            SerializedProperty crewMembers = serializedObject.FindProperty("crewMembers");
            EditorGUILayout.PropertyField(crewMembers, new GUIContent("crewMembers"), true);
            GUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();   
        }
        GUILayout.EndVertical();
    }
}

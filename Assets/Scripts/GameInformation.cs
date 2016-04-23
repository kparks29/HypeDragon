﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameInformation
{
    public enum TableObjectNames { PlainTable, Cup, Plate };

    private static Dictionary<TableObjectNames, TableObject> tableObjects;
    public static Dictionary<TableObjectNames, TableObject> TableObjects
    {
        get
        {
            if (tableObjects == null)
            {
                LoadTableObjects();
            }
            return tableObjects;
        }
    }

    public static void LoadTableObjects()
    {
        tableObjects = new Dictionary<TableObjectNames, TableObject>();

        tableObjects.Add(TableObjectNames.PlainTable, new TableObject(null, null, 5, 1));
        tableObjects.Add(TableObjectNames.Cup, new TableObject(null, null, 1, 1));
        tableObjects.Add(TableObjectNames.Plate, new TableObject(null, null, 1, 1));
    }

	public class TableObject
    {
        public Mesh ObjectMesh;
        public AudioClip SoundEffect;
        public float Mass;
        public float Drag;

        public TableObject(Mesh objectMesh = null, AudioClip soundEffect = null, float mass = 1, float drag = 1)
        {
            ObjectMesh = objectMesh;
            SoundEffect = soundEffect;
            Mass = mass;
            Drag = drag;
        }
    }
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class GameInformation
{
    public enum TableObjectNames { PlainTable = -1, Cup = 0, Plate = 1, Duck = 2, Cat = 3 };

	public static int Score = 0;

	private static List<TableObjectNames> allTableObjects;
	public static List<TableObjectNames> AllTableObjects
	{
		get
		{
			if (allTableObjects == null)
			{
				allTableObjects = Enum.GetValues(typeof(GameInformation.TableObjectNames)).Cast<GameInformation.TableObjectNames>().ToList();
				allTableObjects = AllTableObjects.Where(o => o >= 0).ToList();
			}
			return allTableObjects;
		}
	}

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

        tableObjects.Add(TableObjectNames.PlainTable, new TableObject(null, null, 0.1f, 1));
        tableObjects.Add(TableObjectNames.Cup, new TableObject(null, null, 0.0005f, 1));
        tableObjects.Add(TableObjectNames.Plate, new TableObject(null, null, 0.0005f, 1));
		tableObjects.Add(TableObjectNames.Duck, new TableObject(null, null, 0.0001f, 1));
        tableObjects.Add(TableObjectNames.Cat, new TableObject(null, null, 0.0001f, 1));
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

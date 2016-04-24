using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class GameInformation
{
    public enum TableObjectNames { Barrel = -2, PlainTable = -1, Cup = 0, Plate = 1, Duck = 2, Cat = 3, Banana = 4, Boom_Box = 5 };

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
		var whiteMaterial = Resources.Load("Models/Materials/WhiteMaterial") as Material;
		var redMaterial = Resources.Load("Models/Materials/RedMaterial") as Material;
		var blueMaterial = Resources.Load("Models/Materials/BlueMaterial") as Material;
		var yellowMaterial = Resources.Load("Models/Materials/YellowMaterial") as Material;
		var greenMaterial = Resources.Load("Models/Materials/GreenMaterial") as Material;
		var blackMaterial = Resources.Load("Models/Materials/BlackMaterial") as Material;
		var brownMaterial = Resources.Load("Models/Materials/BrownMaterial") as Material;
		var tableMaterial = Resources.Load("Models/Materials/TableMaterial") as Material;

        tableObjects.Add(TableObjectNames.Barrel, new TableObject(null, null, brownMaterial, 0.1f, 0.5f));
        tableObjects.Add(TableObjectNames.PlainTable, new TableObject(null, null, tableMaterial, 0.1f, 0.5f));
        tableObjects.Add(TableObjectNames.Cup, new TableObject(null, null, redMaterial, 0.0005f, 0.01f));
        tableObjects.Add(TableObjectNames.Plate, new TableObject(null, null, whiteMaterial, 0.0005f, 0.01f));
		tableObjects.Add(TableObjectNames.Duck, new TableObject(null, null, yellowMaterial, 0.0001f, 0.01f));
        tableObjects.Add(TableObjectNames.Cat, new TableObject(null, null, blueMaterial, 0.0005f, 0.1f));
        tableObjects.Add(TableObjectNames.Banana, new TableObject(null, null, yellowMaterial, 0.0001f, 0.005f));
        tableObjects.Add(TableObjectNames.Boom_Box, new TableObject(null, null, blackMaterial, 0.0001f, 0.15f));
    }

	public class TableObject
    {
        public Mesh ObjectMesh;
        public AudioClip SoundEffect;
		public Material Material;
        public float Mass;
        public float Drag;

        public TableObject(Mesh objectMesh = null, AudioClip soundEffect = null, Material material = null, float mass = 1, float drag = 1)
        {
            ObjectMesh = objectMesh;
            SoundEffect = soundEffect;
			Material = material;
            Mass = mass;
            Drag = drag;
        }
    }
}

﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class GameInformation
{
    public enum TableObjectNames {
        Barrel = -2,
        PlainTable = -1,
        Cup = 0,
        Plate = 1,
        Duck = 2,
        Cat = 3,
        Banana = 4,
        Boom_Box = 5,
        Hot_Dog = 6,
        Lobster = 7,
        Mosquito = 8,
        Flipper = 9,
        Eggplant = 10,
        Pizza = 11
    };

	public static int Score = 0;

	private static List<TableObjectNames> allTableObjects;
    public static List<TableObjectNames> AllTableObjects
	{
		get
		{
			if (allTableObjects == null)
			{
				allTableObjects = Enum.GetValues(typeof(TableObjectNames)).Cast<GameInformation.TableObjectNames>().ToList();
				allTableObjects = allTableObjects.Where(o => (int)o >= 0).ToList();
			}
			return allTableObjects;
		}
	}

    private static List<TableObjectNames> allObstacles;
    public static List<TableObjectNames> AllObstacles
    {
        get
        {
            if (allObstacles == null)
            {
                allObstacles = Enum.GetValues(typeof(TableObjectNames)).Cast<GameInformation.TableObjectNames>().ToList();
                allObstacles = allObstacles.Where(o => (int)o < -1).ToList();
            }
            return allObstacles;
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
        var textureMaterial = Resources.Load("Models/Materials/TextureMaterial") as Material;

        var sfxCat = Resources.Load("Audio/SoundEffects/SFX_CatMeow1") as AudioClip;
		var sfxDuck = Resources.Load("Audio/SoundEffects/SFX_Duck1") as AudioClip;
		var sfxObjSpawn1 = Resources.Load("Audio/SoundEffects/SFX_ObjSpawn1") as AudioClip;
		var sfxObjSpawn2 = Resources.Load("Audio/SoundEffects/SFX_ObjSpawn2") as AudioClip;
		var sfxObjSpawn3 = Resources.Load("Audio/SoundEffects/SFX_ObjSpawn3") as AudioClip;
		var sfxExplosion = Resources.Load("Audio/SoundEffects/SFX_EXPLODE1") as AudioClip;
		var sfxWoosh = Resources.Load("Audio/SoundEffects/SFX_Woosh1") as AudioClip;

		tableObjects.Add(TableObjectNames.Barrel, new TableObject(null, sfxExplosion, null, brownMaterial, 0.5f, 0.5f));
        tableObjects.Add(TableObjectNames.PlainTable, new TableObject(null, null, null, tableMaterial, 0.01f, 0.005f));
        tableObjects.Add(TableObjectNames.Cup, new TableObject(null, sfxObjSpawn2, null, redMaterial, 0.0005f, 0.01f));
        tableObjects.Add(TableObjectNames.Plate, new TableObject(null, null, null, whiteMaterial, 0.0005f, 0.01f));
		tableObjects.Add(TableObjectNames.Duck, new TableObject(null, sfxDuck, null, yellowMaterial, 0.0001f, 0.01f));
        tableObjects.Add(TableObjectNames.Cat, new TableObject(null, sfxCat, sfxWoosh, blueMaterial, 0.0005f, 0.1f, 0.01f));
        tableObjects.Add(TableObjectNames.Banana, new TableObject(null, null, null, yellowMaterial, 0.0001f, 0.005f));
        tableObjects.Add(TableObjectNames.Boom_Box, new TableObject(null, sfxObjSpawn1, sfxWoosh, blackMaterial, 0.0001f, 0.15f, 0.01f));
        tableObjects.Add(TableObjectNames.Lobster, new TableObject(null, null, null, redMaterial, 0.0005f, 0.1f));
        tableObjects.Add(TableObjectNames.Hot_Dog, new TableObject(null, sfxExplosion, null, textureMaterial, 0.0001f, 0.005f));
        tableObjects.Add(TableObjectNames.Mosquito, new TableObject(null, sfxObjSpawn3, null, brownMaterial, 0.0001f, 0.0001f));
        tableObjects.Add(TableObjectNames.Flipper, new TableObject(null, null, null, textureMaterial, 0.005f, 0.05f));
        tableObjects.Add(TableObjectNames.Eggplant, new TableObject(null, null, null, textureMaterial, 0.005f, 0.01f));
        tableObjects.Add(TableObjectNames.Pizza, new TableObject(null, sfxExplosion, null, textureMaterial, 0.005f, 0.01f, 0.01f));
    }

	public class TableObject
    {
        public Mesh ObjectMesh;
        public AudioClip SoundEffect;
		public AudioClip FlySoundEffect;
		public Material Material;
        public float Mass;
        public float Drag;
		public float Limit;

        public TableObject(Mesh objectMesh = null, AudioClip soundEffect = null, AudioClip flySoundEffect = null, Material material = null, float mass = 1, float drag = 1, float limit = 1f)
        {
            ObjectMesh = objectMesh;
            SoundEffect = soundEffect;
			FlySoundEffect = flySoundEffect;
			Material = material;
            Mass = mass;
            Drag = drag;
			Limit = limit;
        }
    }
}

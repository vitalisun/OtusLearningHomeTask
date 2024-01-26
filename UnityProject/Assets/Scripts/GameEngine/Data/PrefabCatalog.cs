using System.Collections;
using System.Collections.Generic;
using GameEngine;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "PrefabCatalog", menuName = "Catalogs/PrefabCatalog", order = 1)]
public class PrefabCatalog : ScriptableObject
{
    public Unit[] prefabs;
}

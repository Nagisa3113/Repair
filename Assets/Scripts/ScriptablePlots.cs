using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plots", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

public class ScriptablePlots : ScriptableObject
{
    public List<Plot> plots;
}

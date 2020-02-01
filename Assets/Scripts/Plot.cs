using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Plot
{
    [TextArea]
    public List<string> texts;
    public bool canInterrupt;
    public int nextPlotNum;
    public int interruptPlotNum;
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using System.Linq;

public class Layer : MonoBehaviour
{
    public int GetCountChild()
    {
        return this.transform.childCount;
    }
}

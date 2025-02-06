using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource list", menuName = "Factory/Resource List", order = 1)]
public class SO_Resources : ScriptableObject
{
    public Struct_Resource[] resources;
}

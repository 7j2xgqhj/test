using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOption : MonoBehaviour
{
    [Header("ループ可否")]public bool isRoop=false;
    [Header("反射可否(回数制限付き)")]public bool isLimitedReflect=false;
    [Header("反射可否(回数制限無し)")]public bool isUnlimitReflect=false;
    [Header("反射回数制限")]public float ReflectLimit=1;
    [Header("停止可否")]public bool isStop=false;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scannable")]
public class ScannableObj : ScriptableObj
{
    [SerializeField] string Name;
    [SerializeField] string Desc;
    [SerializeField] bool canWalk;
    [SerializeField] bool canRun;
    [SerializeField] bool canJump;
    [SerializeField] bool hasScanned;

    public int a = 0;
    public override void Apply(GameObject target)
    {

        a++;

    }
}

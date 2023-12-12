using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationType : StateMachineBehaviour
{
    [SerializeField] public AbilityType Type;
    public string StateName {  get; set; }

}



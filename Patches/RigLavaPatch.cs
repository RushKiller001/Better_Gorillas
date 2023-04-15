using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Better_Gorillas;
namespace Better_Gorillas.Patches
{
    /// <summary>
    /// This is an example patch, made to demonstrate how to use Harmony. You should remove it if it is not used.
    /// </summary>
    [HarmonyPatch(typeof(VRRig))]
    [HarmonyPatch("Awake", MethodType.Normal)]
    public class RigLavaPatch
    {
        public Material material;
        private static void Postfix(VRRig __instance)
        {
            if (__instance.gameObject.GetComponent<Matchanger>() == null)
            {
                __instance.gameObject.AddComponent<Matchanger>();
            }
        }
    }
}
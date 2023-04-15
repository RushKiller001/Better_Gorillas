using BepInEx;
using System;
using UnityEngine;
using Utilla;
using HarmonyLib;
using Better_Gorillas.Patches;
using System.IO;
using System.Reflection;

namespace Better_Gorillas
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public Material material;
        public Material material2;
        public Material material3;
        AssetBundle bundle;
        void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Better_Gorillas.Mat.mat");
            bundle = AssetBundle.LoadFromStream(s);
            material = bundle.LoadAsset<Material>("Animated");
            material2 = bundle.LoadAsset<Material>("BetterIce");
            material3 = bundle.LoadAsset<Material>("ChestFace");
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            FindObjectOfType<VRRig>().gameObject.AddComponent<Matchanger>();
        }
    }
    public class Matchanger : MonoBehaviour
    {
        Plugin p = FindObjectOfType<Plugin>();
        void Awake()
        {
            gameObject.GetComponent<VRRig>().materialsToChangeTo[2] = p.material;
            gameObject.GetComponent<VRRig>().materialsToChangeTo[3] = p.material2;
            gameObject.GetComponent<VRRig>().mainSkin.transform.parent.Find("rig/body/head/gorillaface").gameObject.GetComponent<Renderer>().material = p.material3;
            gameObject.GetComponent<VRRig>().mainSkin.transform.parent.Find("rig/body/gorillachest").gameObject.GetComponent<Renderer>().material = p.material3;
        }
    }
}

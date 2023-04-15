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
        AssetBundle bundle;
        void Start()
        {
            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Better_Gorillas.Mat.mat");
            bundle = AssetBundle.LoadFromStream(s);
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            HarmonyPatches.ApplyHarmonyPatches();
            FindObjectOfType<VRRig>().gameObject.AddComponent<Matchanger>();
            material = bundle.LoadAsset<Material>("Animated");
            material2 = bundle.LoadAsset<Material>("BetterIce");
        }
    }
    public class Matchanger : MonoBehaviour
    {
        Plugin p = FindObjectOfType<Plugin>();
        void Awake()
        {
            gameObject.GetComponent<VRRig>().materialsToChangeTo[2] = p.material;
            gameObject.GetComponent<VRRig>().materialsToChangeTo[3] = p.material2;
        }
    }
}

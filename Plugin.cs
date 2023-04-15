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
        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Better_Gorillas.Mat.rushspinmat");
            AssetBundle bundle = AssetBundle.LoadFromStream(s);
            Stream sT = Assembly.GetExecutingAssembly().GetManifestResourceStream("Better_Gorillas.Mat.betterice");
            AssetBundle bundle2 = AssetBundle.LoadFromStream(sT);
            material = bundle.LoadAsset<Material>("Animated");
            material2 = bundle2.LoadAsset<Material>("BetterIce");
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

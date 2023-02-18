using System;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using Newtonsoft.Json;
using EFT;
using System.IO;
using System.Reflection;

namespace NoGrenadeESP
{

    [BepInPlugin("com.dvize.NoGrenadeESP", "dvize.NoGrenadeESP", "1.0.0")]
    class NoGrenadeESPPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<int> PercentageNotRunFromGrenade
        {
            get;
            private set;
        }


        private void Awake()
        {
            PercentageNotRunFromGrenade = Config.Bind(
                "Main Settings",
                "Percentage Chance They Do Not Run Away from Grenade",
                50,
                "Set the percentage chance here");

            new GrenadePatch().Enable();

        }
        
    }
}

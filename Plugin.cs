using System;
using BepInEx;
using BepInEx.Configuration;
using Comfort.Common;
using UnityEngine;
using Newtonsoft.Json;
using EFT;
using System.IO;
using System.Reflection;
using static MineDirectional;

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

       /* public ConfigEntry<float> ChanceWarnGrenade
        {
            get;
            private set;
        }

        public ConfigEntry<float> EnemyGrenadeThrowAccuracy
        {
            get;
            private set;
        }

        public ConfigEntry<float> BotReactionTimeToGrenade
        {
            get;
            private set;
        }*/

        private void Awake()
        {
            PercentageNotRunFromGrenade = Config.Bind(
                "Main Settings",
                "Percentage Chance They Do Not Run Away from Grenade",
                35,
                "Set the percentage chance here");

            /*ChanceWarnGrenade = Config.Bind(
                "Main Settings",
                "Percentage Chance They Warn About the Grenade",
                25f,
                "Default is 95");

            EnemyGrenadeThrowAccuracy = Config.Bind(
                "Main Settings",
                "Grenade Throw Per Meter Accuracy",
                0.5f,
                "Default is 0.25. Smaller is more accurate");

            BotReactionTimeToGrenade = Config.Bind(
                "Main Settings",
                "Grenade Throw Per Meter Accuracy",
                1.5f,
                "Default is 0.7. Larger is longer");*/

            new GrenadePatch().Enable();
            new GrenadePatch2().Enable();

        }

        /*private void Update()
        {
            try
            {
                BotDifficultySettingsClass botDifficultySettings = Singleton<BotDifficultySettingsClass>.Instance;

                botDifficultySettings.FileSettings.Grenade.CHANCE_TO_NOTIFY_ENEMY_GR_100 = ChanceWarnGrenade.Value;
                botDifficultySettings.FileSettings.Grenade.GrenadePerMeter = EnemyGrenadeThrowAccuracy.Value;
                botDifficultySettings.FileSettings.Grenade.DELTA_GRENADE_START_TIME = BotReactionTimeToGrenade.Value;

            }
            catch (Exception e)
            {
                Logger.LogInfo("NoGrenadeESP: " + e);
            }

        }*/
    
    
    }
}

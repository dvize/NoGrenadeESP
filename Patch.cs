using Aki.Reflection.Patching;
using EFT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NoGrenadeESP
{

    public class GrenadePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            try
            {
                //this isn't a general method.. looks like this engrained in every bot so i have to find the specific bot.
                return typeof(GClass514).GetMethod("ShallRunAway", BindingFlags.Instance | BindingFlags.Public);
            }
            catch
            {
                Logger.LogInfo("NoGrenadeESP: Failed to get target method");
            }

            return null;
        }

        [PatchPrefix]
        static bool Prefix(GClass514 __instance, ref bool __result)
        {
            try
            {
                //get private readonly field botOwner_0 from GClass514
                var botOwner = typeof(GClass514).GetField("botOwner_0", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance) as BotOwner;

                bool isDangerous = (botOwner.Transform.position - __instance.DangerPoint).sqrMagnitude >= GClass555.Core.DELTA_GRENADE_SAFE_DIST_SQRT;

                if (isDangerous)
                {
                    // give random chance based off PercentageNotRunFromGrenade config setting to run away from grenade and __result = false and return false to not run the original method
                    if (UnityEngine.Random.Range(0, 100) < NoGrenadeESPPlugin.PercentageNotRunFromGrenade.Value)
                    {
                        __result = false;
                        return false;
                    }
                }
            }
            catch
            {
                Logger.LogInfo("NoGrenadeESP: Something messed up trying to set the __result or isDangerous bool");
            }

            return true; // continue with original method
        }
    }
}
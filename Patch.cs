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
        static bool Prefix(ref bool __result)
        {

            if (UnityEngine.Random.Range(0, 100) < NoGrenadeESPPlugin.PercentageNotRunFromGrenade.Value)
            {
                __result = false;
                return false; // Skip the original method
            }

            return true; // Continue with the original method
        }
    }

    public class GrenadePatch2 : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            try
            {
                //this isn't a general method.. looks like this engrained in every bot so i have to find the specific bot.
                return typeof(GClass452).GetMethod("ShallRunAway", BindingFlags.Instance | BindingFlags.Public);
            }
            catch
            {
                Logger.LogInfo("NoGrenadeESP: Failed to get target method");
            }

            return null;
        }
        
        [PatchPrefix]
        static bool Prefix(ref bool __result)
        {

            if (UnityEngine.Random.Range(0, 100) < NoGrenadeESPPlugin.PercentageNotRunFromGrenade.Value)
            {
                __result = false;
                return false; // Skip the original method
            }

            return true; // Continue with the original method
        }
    }



}
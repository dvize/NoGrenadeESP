using System.Reflection;
using Aki.Reflection.Patching;
using HarmonyLib;

namespace NoGrenadeESP
{

    public class GrenadePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(BewareGrenade), "ShallRunAway");
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
            return AccessTools.Method(typeof(GrenadeDangerPoint), "ShallRunAway");
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
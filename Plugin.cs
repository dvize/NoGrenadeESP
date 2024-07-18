using BepInEx;
using BepInEx.Configuration;

namespace NoGrenadeESP
{

    [BepInPlugin("com.dvize.NoGrenadeESP", "dvize.NoGrenadeESP", "1.7.0")]
    //[BepInDependency("com.spt-aki.core", "3.7.1")]
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
                35,
                "Set the percentage chance here");

            new GrenadePatch().Enable();
            new GrenadePatch2().Enable();

        }

    }
}

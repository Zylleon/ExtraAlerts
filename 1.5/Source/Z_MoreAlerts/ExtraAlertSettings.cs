using Verse;
using UnityEngine;


namespace Z_MoreAlerts
{
    public class ExtraAlertSettings : ModSettings
    {
        // Urgent
        public static bool cb_enemies = true;
        public static bool cb_enemyRescue = true;
        public static bool cb_allyRescue = true;
        public static bool cb_neutralRescue = true;
        public static bool cb_blight = true;

        // Mood
        public static bool cb_bondedAnimal = true;
        public static bool cb_deadApparel = true;
        public static bool cb_humanApparel = true;
        public static bool cb_Lovers = true;
        public static bool cb_sharedBed = true;
        public static bool cb_asceticBedroom = true;

        // Animals
        public static bool cb_animalHypothermia = true;
        public static bool cb_animalHeatstroke = true;

        // Misc
        public static bool cb_unroofedElectrical = true;
        public static bool cb_trader = true;
        public static bool cb_tradeOrbital = true;


        public override void ExposeData()
        {
            // Urgent
            Scribe_Values.Look(ref cb_enemies, "cb_enemies", true);
            Scribe_Values.Look(ref cb_enemyRescue, "cb_enemyRescue", true);
            Scribe_Values.Look(ref cb_allyRescue, "cb_allyRescue", true);
            Scribe_Values.Look(ref cb_neutralRescue, "cb_neutralRescue", true);
            Scribe_Values.Look(ref cb_blight, "cb_blight", true);

            // Mood
            Scribe_Values.Look(ref cb_bondedAnimal, "cb_bondedAnimal", true);
            Scribe_Values.Look(ref cb_deadApparel, "cb_deadApparel", true);
            Scribe_Values.Look(ref cb_humanApparel, "cb_humanApparel", true);
            Scribe_Values.Look(ref cb_Lovers, "cb_Lovers", true);
            Scribe_Values.Look(ref cb_sharedBed, "cb_sharedBed", true);
            Scribe_Values.Look(ref cb_asceticBedroom, "cb_asceticBedroom", true);

            // Animals
            Scribe_Values.Look(ref cb_animalHypothermia, "cb_animalHypothermia", true);
            Scribe_Values.Look(ref cb_animalHeatstroke, "cb_animalHeatstroke", true);

            // Other
            Scribe_Values.Look(ref cb_unroofedElectrical, "cb_unroofedElectrical", true);
            Scribe_Values.Look(ref cb_trader, "cb_trader", true);
            Scribe_Values.Look(ref cb_tradeOrbital, "cb_tradeOrbital", true);

        }
    }


    public class ExtraAlertsMod : Mod
    {
        ExtraAlertSettings settings;

        public ExtraAlertsMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<ExtraAlertSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            inRect.width = 400f;
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            // Urgent
            Text.Font = GameFont.Medium;
            listing.Label("ExtraAlerts_Urgent".Translate());
            Text.Font = GameFont.Small;
            listing.CheckboxLabeled("AlertEnemies".Translate(), ref ExtraAlertSettings.cb_enemies, "AlertEnemiesDesc".Translate());
            listing.CheckboxLabeled("AlertEnemyNeedsRescue".Translate(), ref ExtraAlertSettings.cb_enemyRescue, "AlertEnemyNeedsRescueDesc".Translate());
            listing.CheckboxLabeled("AlertAllyNeedsRescue".Translate(), ref ExtraAlertSettings.cb_allyRescue, "AlertAllyNeedsRescueDesc".Translate());
            listing.CheckboxLabeled("AlertNeutralNeedsRescue".Translate(), ref ExtraAlertSettings.cb_neutralRescue, "AlertNeutralNeedsRescueDesc".Translate());
            listing.CheckboxLabeled("AlertBlight".Translate(), ref ExtraAlertSettings.cb_blight, "AlertBlightDesc".Translate());
            listing.Gap();

            // Mood
            Text.Font = GameFont.Medium;
            listing.Label("ExtraAlerts_Mood".Translate());
            Text.Font = GameFont.Small;
            listing.CheckboxLabeled("AlertNotBondedAnimalMaster".Translate(), ref ExtraAlertSettings.cb_bondedAnimal, "AlertNotBondedAnimalMasterDesc".Translate());
            listing.CheckboxLabeled("AlertDeadMansApparel".Translate(), ref ExtraAlertSettings.cb_deadApparel, "AlertDeadMansApparelDesc".Translate());
            listing.CheckboxLabeled("AlertHumanLeatherApparelSad".Translate(), ref ExtraAlertSettings.cb_humanApparel, "AlertHumanLeatherApparelSadDesc".Translate());
            listing.CheckboxLabeled("AlertWantToSleepWith".Translate(), ref ExtraAlertSettings.cb_Lovers, "AlertWantToSleepWithDesc".Translate());
            listing.CheckboxLabeled("AlertSharingBedUnhappy".Translate(), ref ExtraAlertSettings.cb_sharedBed, "AlertSharingBedUnhappyDesc".Translate());
            listing.CheckboxLabeled("AlertAsceticBedroomQuality".Translate(), ref ExtraAlertSettings.cb_asceticBedroom, "AlertAsceticBedroomQualityDesc".Translate());
            listing.Gap();

            // Animals
            Text.Font = GameFont.Medium;
            listing.Label("ExtraAlerts_Animals".Translate());
            Text.Font = GameFont.Small;
            listing.CheckboxLabeled("AlertAnimalHypothermia".Translate(), ref ExtraAlertSettings.cb_animalHypothermia, "AlertAnimalHypothermiaDesc".Translate());
            listing.CheckboxLabeled("AlertAnimalHeatstroke".Translate(), ref ExtraAlertSettings.cb_animalHeatstroke, "AlertAnimalHeatstrokeDesc".Translate());
            listing.Gap();

            // Misc
            Text.Font = GameFont.Medium;
            listing.Label("ExtraAlerts_Misc".Translate());
            Text.Font = GameFont.Small;
            listing.CheckboxLabeled("AlertUnroofedElectrical".Translate(), ref ExtraAlertSettings.cb_unroofedElectrical, "AlertUnroofedElectricalDesc".Translate());
            listing.CheckboxLabeled("AlertTradeCaravan".Translate(), ref ExtraAlertSettings.cb_trader, "AlertTradeCaravanDesc".Translate());
            listing.CheckboxLabeled("AlertOrbitalTrader".Translate(), ref ExtraAlertSettings.cb_tradeOrbital, "AlertOrbitalTraderDesc".Translate());



            listing.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "ExtraAlerts_ModName".Translate();
        }

    }




}

using Verse;
using UnityEngine;


namespace Z_MoreAlerts
{
    public class ExtraAlertSettings : ModSettings
    {
        public static bool cb_bondedAnimal = true;
        public static bool cb_deadApparel = true;
        public static bool cb_Lovers = true;
        public static bool cb_sharedBed = true;
        public static bool cb_asceticBedroom = true;
        public static bool cb_humanApparel = true;
        public static bool cb_enemyRescue = true;
        public static bool cb_allyRescue = true;
        public static bool cb_neutralRescue = true;
        public static bool cb_unroofedElectrical = true;


        public override void ExposeData()
        {
            Scribe_Values.Look(ref cb_bondedAnimal, "cb_bondedAnimal", true);
            Scribe_Values.Look(ref cb_deadApparel, "cb_deadApparel", true);
            Scribe_Values.Look(ref cb_Lovers, "cb_Lovers", true);
            Scribe_Values.Look(ref cb_sharedBed, "cb_sharedBed", true);
            Scribe_Values.Look(ref cb_asceticBedroom, "cb_asceticBedroom", true);
            Scribe_Values.Look(ref cb_humanApparel, "cb_humanApparel", true);
            Scribe_Values.Look(ref cb_enemyRescue, "cb_enemyRescue", true);
            Scribe_Values.Look(ref cb_allyRescue, "cb_allyRescue", true);
            Scribe_Values.Look(ref cb_neutralRescue, "cb_neutralRescue", true);
            Scribe_Values.Look(ref cb_unroofedElectrical, "cb_unroofedElectrical", true);

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

            inRect.width = 450f;
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("AlertNotBondedAnimalMaster".Translate(), ref ExtraAlertSettings.cb_bondedAnimal, "AlertNotBondedAnimalMasterDesc".Translate());
            listingStandard.CheckboxLabeled("AlertDeadMansApparel".Translate(), ref ExtraAlertSettings.cb_deadApparel, "AlertDeadMansApparelDesc".Translate());
            listingStandard.CheckboxLabeled("AlertWantToSleepWith".Translate(), ref ExtraAlertSettings.cb_Lovers, "AlertWantToSleepWithDesc".Translate());
            listingStandard.CheckboxLabeled("AlertSharingBedUnhappy".Translate(), ref ExtraAlertSettings.cb_sharedBed, "AlertSharingBedUnhappyDesc".Translate());
            listingStandard.CheckboxLabeled("AlertAsceticBedroomQuality".Translate(), ref ExtraAlertSettings.cb_asceticBedroom, "AlertAsceticBedroomQualityDesc".Translate());
            listingStandard.CheckboxLabeled("AlertHumanLeatherApparelSad".Translate(), ref ExtraAlertSettings.cb_humanApparel, "AlertHumanLeatherApparelSadDesc".Translate());
            listingStandard.CheckboxLabeled("AlertEnemyNeedsRescue".Translate(), ref ExtraAlertSettings.cb_enemyRescue, "AlertEnemyNeedsRescueDesc".Translate());
            listingStandard.CheckboxLabeled("AlertAllyNeedsRescue".Translate(), ref ExtraAlertSettings.cb_allyRescue, "AlertAllyNeedsRescueDesc".Translate());
            listingStandard.CheckboxLabeled("AlertNeutralNeedsRescue".Translate(), ref ExtraAlertSettings.cb_neutralRescue, "AlertNeutralNeedsRescueDesc".Translate());
            listingStandard.CheckboxLabeled("AlertUnroofedElectrical".Translate(), ref ExtraAlertSettings.cb_unroofedElectrical, "AlertUnroofedElectricalDesc".Translate());


            listingStandard.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "ExtraAlerts_ModName".Translate();
        }

    }




}

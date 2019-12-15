using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
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
        public static bool cb_caravanWaiting = true;
        public static bool cb_asceticBedroom = true;
        public static bool cb_humanApparel = true;



        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref cb_bondedAnimal, "cb_bondedAnimal", true);
            Scribe_Values.Look(ref cb_deadApparel, "cb_deadApparel", true);
            Scribe_Values.Look(ref cb_Lovers, "cb_Lovers", true);
            Scribe_Values.Look(ref cb_sharedBed, "cb_sharedBed", true);
            Scribe_Values.Look(ref cb_caravanWaiting, "cb_caravanWaiting", true);
            Scribe_Values.Look(ref cb_asceticBedroom, "cb_asceticBedroom", true);
            Scribe_Values.Look(ref cb_humanApparel, "cb_humanApparel", true);

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
            listingStandard.CheckboxLabeled("AlertPausedCaravan".Translate(), ref ExtraAlertSettings.cb_caravanWaiting, "AlertPausedCaravanDesc".Translate());
            listingStandard.CheckboxLabeled("AlertAsceticBedroomQuality".Translate(), ref ExtraAlertSettings.cb_asceticBedroom, "AlertAsceticBedroomQualityDesc".Translate());
            listingStandard.CheckboxLabeled("AlertHumanLeatherApparelSad".Translate(), ref ExtraAlertSettings.cb_humanApparel, "AlertHumanLeatherApparelSadDesc".Translate());

            listingStandard.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "ExtraAlerts_ModName".Translate();
        }

    }




}

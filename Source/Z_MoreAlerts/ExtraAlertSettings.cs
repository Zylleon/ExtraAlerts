using System.Collections.Generic;
using UnityEngine;
using Verse;


namespace Z_MoreAlerts
{
    public class ExtraAlertSettings : ModSettings
    {
        // Urgent
        public static bool cb_enemies = true;
        public static bool cb_hiddenEnemies = true;
        public static bool cb_enemyRescue = true;
        public static bool cb_allyRescue = true;
        public static bool cb_entityDowned = true;
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
        public static bool cb_unarmedCombatant = true;
        public static bool cb_childCombatant = false;
        public static bool cb_trader = true;
        public static bool cb_tradeOrbital = true;

        //Odyssey
        public static bool cb_porqupineQuills = true;


        public override void ExposeData()
        {
            // Urgent
            Scribe_Values.Look(ref cb_enemies, "cb_enemies", true);
            Scribe_Values.Look(ref cb_hiddenEnemies, "cb_hiddenEnemies", false);
            Scribe_Values.Look(ref cb_enemyRescue, "cb_enemyRescue", true);
            Scribe_Values.Look(ref cb_allyRescue, "cb_allyRescue", true);
            Scribe_Values.Look(ref cb_entityDowned, "cb_entityDowned", true);
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

            // Misc
            Scribe_Values.Look(ref cb_unroofedElectrical, "cb_unroofedElectrical", true);
            Scribe_Values.Look(ref cb_unarmedCombatant, "cb_unarmedCombatant", true);
            Scribe_Values.Look(ref cb_childCombatant, "cb_childCombatant", false);
            Scribe_Values.Look(ref cb_trader, "cb_trader", true);
            Scribe_Values.Look(ref cb_tradeOrbital, "cb_tradeOrbital", true);

            //Odyssey
            Scribe_Values.Look(ref cb_porqupineQuills, "cb_porqupineQuills", true);

        }
    }


    public class ExtraAlertsMod : Mod
    {
        ExtraAlertSettings settings;
        private static Vector2 scrollPosition = Vector2.zero;
        private static float viewHeight;

        public ExtraAlertsMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<ExtraAlertSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            inRect.width = 450f;
            Listing_Standard outerListing = new Listing_Standard();
            outerListing.Begin(inRect);

            Rect windowRect = outerListing.GetRect(inRect.height - outerListing.CurHeight).ContractedBy(4f);

            float viewheight = 650f;
            if (ModsConfig.OdysseyActive)
            {
                viewheight += 100f;
            }

            Rect viewRect = new Rect(0f, 0f, 275f, viewheight);
            Widgets.BeginScrollView(windowRect, ref scrollPosition, viewRect, true);


            Listing_Standard listing = new Listing_Standard();
            listing.Begin(viewRect);

            // Urgent
            Text.Font = GameFont.Medium;
            listing.Label("ExtraAlerts_Urgent".Translate());
            Text.Font = GameFont.Small;
            listing.CheckboxLabeled("AlertEnemies".Translate(), ref ExtraAlertSettings.cb_enemies, "AlertEnemiesDesc".Translate());

            if(!ExtraAlertSettings.cb_enemies)
            {
                GUI.color = Color.gray;
            }
            listing.CheckboxLabeled("AlertHiddenEnemies".Translate(), ref ExtraAlertSettings.cb_hiddenEnemies, "AlertHiddenEnemiesLabel".Translate());
            GUI.color = Color.white;

            listing.CheckboxLabeled("AlertEnemyNeedsRescue".Translate(), ref ExtraAlertSettings.cb_enemyRescue, "AlertEnemyNeedsRescueDesc".Translate());
            listing.CheckboxLabeled("AlertAllyNeedsRescue".Translate(), ref ExtraAlertSettings.cb_allyRescue, "AlertAllyNeedsRescueDesc".Translate());
            listing.CheckboxLabeled("AlertNeutralNeedsRescue".Translate(), ref ExtraAlertSettings.cb_neutralRescue, "AlertNeutralNeedsRescueDesc".Translate());
            //listing.CheckboxLabeled("AlertEntityDowned".Translate(), ref ExtraAlertSettings.cb_entityDowned, "AlertEntityDownedDesc".Translate());
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
            listing.CheckboxLabeled("AlertUnarmedCombatant".Translate(), ref ExtraAlertSettings.cb_unarmedCombatant, "AlertUnarmedCombatantDesc".Translate());
            if (!ExtraAlertSettings.cb_unarmedCombatant)
            {
                GUI.color = Color.gray;
            }
            listing.CheckboxLabeled("AlertChildCombatant".Translate(), ref ExtraAlertSettings.cb_childCombatant, "AlertChildCombatantDesc".Translate());
            GUI.color = Color.white;

            listing.CheckboxLabeled("AlertTradeCaravan".Translate(), ref ExtraAlertSettings.cb_trader, "AlertTradeCaravanDesc".Translate());
            listing.CheckboxLabeled("AlertOrbitalTrader".Translate(), ref ExtraAlertSettings.cb_tradeOrbital, "AlertOrbitalTraderDesc".Translate());

            //Odyssey
            if (ModsConfig.OdysseyActive)
            {
                listing.Gap();
                Text.Font = GameFont.Medium;
                listing.Label("ExtraAlerts_Odyssey".Translate());
                Text.Font = GameFont.Small;

                listing.CheckboxLabeled("AlertPorcupineQuills".Translate(), ref ExtraAlertSettings.cb_porqupineQuills, "AlertPorcupineQuillsDesc".Translate());
            }

            listing.End();

            Widgets.EndScrollView();
            outerListing.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "ExtraAlerts_ModName".Translate();
        }

    }




}

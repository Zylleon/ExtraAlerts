using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace Z_MoreAlerts
{
    public class Alert_NotBondedAnimalMaster : Alert
    {

        //private static List<string> tmpAnimals = new List<string>();

        private static List<Pawn> tmpAnimals = new List<Pawn>();




        private IEnumerable<Pawn> NotBondedAnimalMasters
        {
            get
            {
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsSpawned)
                {
                    tmpAnimals.Clear();
                    this.GetAnimals(p, tmpAnimals);

                    foreach(Pawn animal in tmpAnimals)
                    {
                        yield return animal;
                    }


                    if (p.workSettings.WorkIsActive(WorkTypeDefOf.Hunting) && !WorkGiver_HunterHunt.HasHuntingWeapon(p) && !p.Downed)
                    {
                        yield return p;
                    }

                }
            }
        }

        protected virtual bool AnimalMasterCheck(Pawn p, Pawn animal)
        {
            return animal.playerSettings.RespectedMaster != p && TrainableUtility.MinimumHandlingSkill(animal) <= p.skills.GetSkill(SkillDefOf.Animals).Level;
        }

        public void GetAnimals(Pawn p, List<Pawn> outAnimals)
        {
            outAnimals.Clear();
            List<DirectPawnRelation> directRelations = p.relations.DirectRelations;
            for (int i = 0; i < directRelations.Count; i++)
            {
                DirectPawnRelation directPawnRelation = directRelations[i];
                Pawn otherPawn = directPawnRelation.otherPawn;
                if (directPawnRelation.def == PawnRelationDefOf.Bond && !otherPawn.Dead && otherPawn.Spawned && otherPawn.Faction == Faction.OfPlayer && otherPawn.training.HasLearned(TrainableDefOf.Obedience) && p.skills.GetSkill(SkillDefOf.Animals).Level >= TrainableUtility.MinimumHandlingSkill(otherPawn) && this.AnimalMasterCheck(p, otherPawn))
                {
                    //Log.Message("Pawn 1: " + p.Name);
                    //Log.Message("Other Pawn: " + otherPawn.Name);
                    outAnimals.Add(otherPawn);
                }
            }
        }



        public Alert_NotBondedAnimalMaster()
        {
            this.defaultLabel = "NotBondedAnimalMaster".Translate();
            this.defaultExplanation = "NotBondedAnimalMasterDesc".Translate();
            this.defaultPriority = AlertPriority.Medium;
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritsAre(this.NotBondedAnimalMasters);
        }

    }
}

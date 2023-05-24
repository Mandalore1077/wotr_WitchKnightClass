using ExpandedContent.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;

namespace WitchKnightClass.Classes
{
    internal class WitchKnight
    {
        /*
         *  class feature outline:
         *      Ring of Power
         *      *   Item starts equiped, cant be removed
         *      *   aura
         *          *   add char modifier to all alied attack and fortitude save rolls
         *          *   undead also gain bonus to AC and damage
         *          *   minus char modifier to will saves of living non-you creatures within aura including allies
         *      *   add 1/2 ranks to intimidation
         *      *   add 1/2 ranks in class to charisma
         *      *   minus ranks to diplomacy
         *      *   effects add slowly over progression, progression also increase aura radius
         *      Morgul Blade
         *      *   special attack [function] per day uses
         *      *   standard damage roll plus effects
         *          *   fail save causes high instant damage and DoT
         *          *   pass save only DoT
         *          *   target dies while under morgul poison automatically resurected as allied zombie
         *      *   starts as full round action upgrades to attack action then swift action
         *      Fell Beast/Bane weapon
         *      Deity -- restricted
         *      Domain selection x2
         *      charisma arcane caster
         *      *   paladin spell levels
         *      *   wizard/necromancer spell list
         *      alignment restriction
         *      Command undead
         *      *   undead in aura have disadvantage
         *      *   start as single target upgrade to AoE
         *      *   full round action
         *      Bonus combat feats lvls 4,8,12,16
         *      Oracle curse wasting
         *      Additional capstone option - become wraith
         *
         */

        public static void AddWitchKnightClass()
        {
            var PaladinClass = Resources.GetBlueprint<BlueprintCharacterClass>("bfa11238e7ae3544bbeb4d0b92e897ec");
            var PaladinSpellLevels = Resources.GetBlueprint<BlueprintSpellsTable>("9aed4803e424ae8429c392d8fbfb88ff");
            var WizardSpellList = Resources.GetBlueprint<BlueprintSpellsTable>("ba0401fdeb4062f40a7aa95b6f07fe89");
            var WizardSpellBook = Resources.GetBlueprint<BlueprintSpellbook>("5a38c9ac8607890409fcb8f6342da6f4");
            var WitchKnightSpellBook = Helpers.CreateBlueprint<BlueprintSpellbook>("WitchKnightSpellBook", bp =>
            {
                bp.Name = Helpers.CreateString("$DreadKnightSpellbook.Name", "Dread Knight");
                bp.CastingAttribute = PaladinClass.Spellbook.CastingAttribute;
                bp.AllSpellsKnown = PaladinClass.Spellbook.AllSpellsKnown;
                bp.CantripsType = PaladinClass.Spellbook.CantripsType;
                bp.HasSpecialSpellList = PaladinClass.Spellbook.HasSpecialSpellList;
                bp.SpecialSpellListName = PaladinClass.Spellbook.SpecialSpellListName;
                bp.GetType().GetProperty("m_SpellsPerDay").SetValue(PaladinSpellLevels.ToReference<BlueprintSpellsTableReference>(), null);
                bp.GetType().GetProperty("m_SpellsKnown").SetValue(WizardSpellBook.SpellsKnown, null);
                bp.GetType().GetProperty("m_SpellSlots").SetValue(WizardSpellBook.SpellSlots, null);
                bp.GetType().GetProperty("m_SpellList").SetValue(WizardSpellBook.SpellList, null);
                bp.GetType().GetProperty("m_MythicSpellList").SetValue(WizardSpellBook.MythicSpellList, null);
                bp.m_MythicSpellList = null;
                bp.IsArcane = false;
                bp.Spontaneous = true;
            });
            var WitchKnightProgression = Helpers.CreateBlueprint<BlueprintProgression>("WitchKnightProgression", bp =>
            {
                bp.GetType().GetProperty("m_Name").SetValue("Witch Knight", null);
                bp.GetType().GetProperty("m_Description").SetValue("Witch Knight", null);
            });
            var WitchKnightClass = Helpers.CreateBlueprint<BlueprintCharacterClass>("WitchKnightClass", bp =>
            {

            });
        }
    }
}

using System;

namespace WoR
{
/// <summary>
///     Factory that constructs the Wizards and Rogues. This could be expanded in the future to allow different weapon types, HP, and allow takeover of tiles.
/// </summary>

    public abstract class CharacterFactory
    {
        public abstract Character CreateCharacter(string subClass);
    }


    public class WizardCharacterFactory : CharacterFactory
    {
        public override Character CreateCharacter(string subClass)
        {
            switch (subClass.ToLower())
            {
                case "fire": return new FireWizard();
                case "ice": return new IceWizard();
                default: throw new ArgumentException("Invalid subClass.", "subClass");
            }
        }
        //Creates new Wizard and Wizard Subclass
    }
    public class RogueCharacterFactory : CharacterFactory
    {
        public override Character CreateCharacter(string subClass)
        {
            switch (subClass.ToLower())
            {
                case "stealth": return new StealthRogue();
                case "trapper": return new TrapperRogue();

                default: throw new ArgumentException("Invalid subClass.", "subClass");
            }
        }
        //Creates new Rogue and Rogue subclass.
    }


    public abstract class Character
    {
        public  char DrawSymbol { get; set; }

    }

    public class FireWizard : Character
    {
        public FireWizard()
        {
        this.DrawSymbol = 'F';
        }
    } // Sets FireWizard marker as 'F'

    public class IceWizard : Character { 
        public IceWizard()
        {
        this.DrawSymbol = 'I';
        }
    } //Sets IceWizard marker as 'I'

    public class StealthRogue : Character { 
        public StealthRogue()
        {
        this.DrawSymbol = 'S';
        }
    } //Sets StealthRogue marker as 'S'

    public class TrapperRogue : Character { 
        public TrapperRogue()
        {
        this.DrawSymbol = 'T';
        }
    } //Sets TrapperRogue marker as 'T

}
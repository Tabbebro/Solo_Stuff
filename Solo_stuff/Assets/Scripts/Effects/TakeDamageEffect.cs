using UnityEngine;

[CreateAssetMenu(menuName = "Character Effects/Instant Effects/Take Damage")]
public class TakeDamageEffect : InstantCharacterEffect
{
    [Header("Character Causing Damage")]
    public CharacterManager CharacterCausingDamage; // Character That Deals Damage

    [Header("Damage")]
    public float PhysicalDamage = 0; // TODO: Split Into Slashing, Piercing & Bludgeoning
    public float MagicDamage = 0;
    public float FireDamage = 0;
    public float LightningDamage = 0;
    public float HolyDamage = 0;
    // TODO: Make More Damage Types

    // Build Ups
    // TODO: Add Build Ups

    [Header("Final Damage")]
    int _finalDamage = 0; // Damage Dealt After All Calculations

    [Header("Poise")]
    public float PoiseDamage = 0;
    public bool PoiseIsBroken = false;

    [Header("Animation")]
    public bool PlayeDamageAnimation = true;
    public bool ManuallySelectDamageAnimation = false;
    public string DamageAnimation;

    [Header("Sound FX")]
    public bool WillPlayDamageSFX = true;
    public AudioClip ElementalDamageSoundFX;

    [Header("Direction Damage Taken From")]
    public float AngleHitFrom; // Direction Where Hit Came From For Animations
    public Vector3 ContactPoint; // Point Where Hit Happened For Blood Instantiation


    public override void ProcessEffect(CharacterManager character) {
        base.ProcessEffect(character);

        // If Character Is Dead Return
        if (character.IsDead.Value) { return; }

        // Check For I Frames

        // Calculate DMG
        CalculateDamage(character);

        // Check DMG Direction

        // Play Animation

        // Check For Build Ups

        // Play SFX

        // Play VFX


    }

    void CalculateDamage(CharacterManager character) {

        if (!character.IsOwner) { return; }

        if (CharacterCausingDamage != null) {
            // TODO: Check For Damage Modifiers
        }

        // TODO: Check For Defences / Absorptions

        _finalDamage = Mathf.RoundToInt(PhysicalDamage + MagicDamage + FireDamage + LightningDamage + HolyDamage);

        if (_finalDamage <= 0) {
            _finalDamage = 1;
        }

        character.CharacterNetworkManager.CurrentHealth.Value -= _finalDamage;

        // TODO: Calculate Poise Damage
    }
}

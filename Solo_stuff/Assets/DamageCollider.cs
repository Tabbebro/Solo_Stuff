using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [Header("Damage")]
    public float PhysicalDamage = 0; // TODO: Split Into Slashing, Piercing & Bludgeoning
    public float MagicDamage = 0;
    public float FireDamage = 0;
    public float LightningDamage = 0;
    public float HolyDamage = 0;
    // TODO: Make More Damage Types

    [Header("Contact Point")]
    protected Vector3 _contactPoint;

    [Header("Characters Damaged")]
    protected List<CharacterManager> _charactersDamaged = new();

    private void OnTriggerEnter(Collider other) {
        CharacterManager damageTarget = other.GetComponent<CharacterManager>();

        if(damageTarget == null) { return; }

        _contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

        // TODO: Check For Friendly Fire

        // TODO: Check If Blocking

        // TODO: Check I Frames

        DamageTarget(damageTarget);
    }

    protected virtual void DamageTarget(CharacterManager damageTarget) {
        // If target already on list return
        if (_charactersDamaged.Contains(damageTarget)) { return; }

        _charactersDamaged.Add(damageTarget);

        TakeDamageEffect damageEffect = Instantiate(WorldCharacterEffectsManager.Instance.TakeDamageEffect);

        // Give Damages
        damageEffect.PhysicalDamage = PhysicalDamage;
        damageEffect.MagicDamage = MagicDamage;
        damageEffect.FireDamage = FireDamage;   
        damageEffect.LightningDamage = LightningDamage;
        damageEffect.HolyDamage = HolyDamage;

        // Give Contact Point
        damageEffect.ContactPoint = _contactPoint;

        // Process The Damage Effect
        damageTarget.CharacterEffectsManager.ProcessInstantEffect(damageEffect);
    }
}

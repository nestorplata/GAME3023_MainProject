using UnityEngine;

public delegate void SimpleDelegate(string name);

public class BattleUnit : MonoBehaviour
{
    [SerializeField] public PokemonBase Base;
    [SerializeField] public UnitUI StatsHUD;
    [SerializeField] public bool isPlayerUnit;
    Animator animator;

    public Pokemon Pokemon { get; set; }



    public AnimationEventDispatcher AnimationDispatcher { get; set; }

    public SimpleDelegate OnAnimationComplete;


    public void Setup()
    {
        animator = GetComponent<Animator>();
        Pokemon = new Pokemon(Base);

        animator.runtimeAnimatorController = Base.animatorController;
        animator.speed = 0.1f;
       
        OnAnimationComplete = OnNonAssignedDelegate;

        AnimationType[] StateTypes = animator.GetBehaviours<AnimationType>();
        AnimationClip[] AnimationClips = animator.runtimeAnimatorController.animationClips;
        AnimationDispatcher = new AnimationEventDispatcher(StateTypes, AnimationClips, Pokemon.Abilities);
        StatsHUD.SetData(Pokemon);
    }

    public AbilityBase GetAbilityBase(int index)
    {
        return Pokemon.Abilities[index].Base;
    }

    public Ability GetAbility(string Name)
    {
        foreach (var Ability in Pokemon.Abilities)
        {
            if(Ability.Base.Name == Name)
            {
                return Ability;
            }
        }
        return Pokemon.Abilities[0];
    }

    internal void PlayAbility(int index)
    {

        Debug.Log(isPlayerUnit +","+Pokemon.Abilities[index].StateName);
        animator.Play(Pokemon.Abilities[index].StateName);
    }

    public void StopaAbility()
    {
        animator.Play(AnimationDispatcher.IdleAnimation.StateName);
    }

    public void PlayDead()
    {
        animator.Play(AnimationDispatcher.DeathAnimation.StateName);
    }

    public void AnimationCompleteHandler(string name)
    {
        Debug.Log($"{gameObject.name} animation complete.");
        OnAnimationComplete(name);
    }

    private void OnNonAssignedDelegate(string name)
    {
        Debug.Log($"{gameObject.name} Delegate not Assigned");
    }


    public void UpdateHPStats()
    {
        StatsHUD.SetHPBar(Pokemon);
    }
}

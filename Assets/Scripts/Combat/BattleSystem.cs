using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleCore
{
    public class BattleSystem : MonoBehaviour
    {
        private BattleState _state;
        
        [SerializeField] private BattleUI ui;
        [SerializeField] private Fighter player;
        [SerializeField] private Fighter enemy;

        [SerializeField] private BattleTransitionHandler transition1;
        [SerializeField] private BattleTransitionHandler transition2;
        [SerializeField] private BattleTransitionHandler transition3;
        [SerializeField] private BattleTransitionHandler transition4;
        [SerializeField] private AudioHandler audioStore;
        public Fighter Player => player;
        public Fighter Enemy => enemy;
        public BattleUI Interface => ui;

        private void Start()
        {
            Interface.Initialize(player, enemy);

            _state = BattleState.Beginning;
            StartCoroutine(BeginBattle());
        }

        public void OnAttackButton()
        {
            Debug.Log("AttackChosen");
            if (_state != BattleState.PlayerTurn) return;
            StartCoroutine(PlayerAttack());
        }
        public void OnFireballButton()
        {
            if (_state != BattleState.PlayerTurn) return;
            StartCoroutine(PlayerFireball());
        }
        public void OnRunButton()
        {
            if (_state != BattleState.PlayerTurn) return;
            StartCoroutine(PlayerRuns());
        }


        public void OnHealButton()
        {
            if (_state != BattleState.PlayerTurn) return;
            StartCoroutine(PlayerHeal());
        }

        private IEnumerator BeginBattle()
        {
            Interface.SetDialogText($"The final battle against {Enemy.Name} begins!");
            Debug.Log("BeginBattleRuns");
            Debug.Log(_state.ToString());
            Player.StatReset();
            Enemy.StatReset();
            Enemy.ApplyEnrage(Random.Range(7,12));
            Player.ApplyEnrage(Random.Range(2,12));
            yield return new WaitForSeconds(6f);

            _state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }

        private IEnumerator PlayerTurn()
        {
            Debug.Log("PlayerTurnReached");
            Debug.Log(_state.ToString());
            if(Player.Enrage == 0){
                Interface.SetDialogText("You feel in safe hands knowing LearnHowToProgram has your back. Full Heal. Choose an Action.");
                Player.Heal(Player.TotalHealth, 0);
                Player.ApplyEnrage(Random.Range(2,20));
                Enemy.BurnReduction(3);
            } else if (Player.Burning > 0){
                Player.Damage(25);
                Interface.SetDialogText("You take 25 damage as you are ON FIRE! Choose an action.");
            } else {
                Interface.SetDialogText("Choose an action.");
            }

            yield break;
        }

        private IEnumerator PlayerAttack()
        {
            Debug.Log("PlayerAttackRan");
            var isDead = Enemy.Damage(0);
            if (Player.Burning > 0){
                isDead = Enemy.Damage(Player.Attack / 2);
                Interface.SetDialogText($"You are on fire! You deal reduced damage! Attack for {Player.Attack / 2}. Your determination grows stronger by the second.");
            } else {
                isDead = Enemy.Damage(Player.Attack);
                Interface.SetDialogText($"You attack for {Player.Attack}. You grow stronger by the second.");
            }

            Player.EnrageReduction(2);

            _state = BattleState.PlayerTransition;

            yield return new WaitForSeconds(4f);

            if (isDead)
            {
                _state = BattleState.Won;
                StartCoroutine(EndGame());
            }
            else
            {
                _state = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
        }

        private IEnumerator PlayerFireball()
        {
            var isDead = Enemy.Damage(0);

            if ((Player.CurrentMana - 20) > 0){
                Player.CastSpell(20);
                isDead = Enemy.Damage(250);
                Enemy.ApplyBurn();
                Interface.SetDialogText($"{Player.Name} casted a fireball dealing 250 damage!");
            } else {
                Interface.SetDialogText($"{Player.Name} failed to cast a fireball.");
            }

            _state = BattleState.PlayerTransition;

            yield return new WaitForSeconds(3f);

            if (isDead)
            {
                _state = BattleState.Won;
                StartCoroutine(EndGame());
            }
            else
            {
                _state = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
        }
        private IEnumerator PlayerRuns()
        {
            Interface.SetDialogText($"ToDoList laughs at your incompetence. You cannot run.");
            audioStore.laughTrack = true;

            _state = BattleState.PlayerTransition;

            yield return new WaitForSeconds(4f);

            // SceneManager.LoadScene(2); 
            _state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }

        private IEnumerator PlayerHeal()
        {
            int quote = Random.Range(0,3);
            if (Player.Burning > 0){
                Player.HealBurn();
                Player.Heal(Player.Healing, 0);
                Interface.SetDialogText($"You heal yourself and curing you of your flames, consuming 10 mana and healing for {Player.Healing}");
            } else if (Player.Burning == 0){
                if (quote == 0){
                    Interface.SetDialogText($"{Player.Name} feels like it's possible! You take a 15 and heal for {Player.Healing} and restore 10 mana!");
                } else if (quote == 1){
                    Interface.SetDialogText($"{Player.Name} wishes to live to tell the tale!");
                } else if (quote == 2){
                    Interface.SetDialogText($"{Player.Name} heals for {Player.Healing} and restore 10 mana.");
                } else if (quote == 3){
                    Interface.SetDialogText($"{Player.Name} knows it ain't over yet!");
                }
                Player.Heal(Player.Healing, 10);
            }
        
            _state = BattleState.PlayerTransition;

            yield return new WaitForSeconds(5f);

            _state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }

        private IEnumerator EnemyTurn()
        {
            var isDead = Player.Damage(0);
            if(Enemy.Enrage == 0){
                isDead = Player.Damage(400);
                Interface.SetDialogText($"{Enemy.Name} has had enough of your foolishness, the battle is over. Nuking you with 400 damage!!!");
                audioStore.laughTrack = true;
                Enemy.ApplyEnrage(Random.Range(7,12));
            } else {
                if(Enemy.Burning > 0){
                isDead = Player.Damage(Enemy.Attack / 2);
                isDead = Enemy.Damage(25);
                Enemy.BurnReduction(1);
                Interface.SetDialogText($"{Enemy.Name} Attacks for {Enemy.Attack/2} damage, but deals half damage because its ON FIRE and takes 50 damage! RAGE BUILDS FASTER.");
                Enemy.EnrageReduction(2);
                } else {
                    int AI = Random.Range(0,99);
                    if (AI > 10) {
                        isDead = Player.Damage(Enemy.Attack);
                        int quote = Random.Range(0,10);
                        if (quote == 0){
                            Interface.SetDialogText($"{Enemy.Name} reminds you there is a code review this friday. Dealing {Enemy.Attack} mental damage.");
                        } else if (quote == 1){
                            Interface.SetDialogText($"{Enemy.Name} welcomes you to another week. Remake ToDoList. Dealing {Enemy.Attack} damage.");
                        } else if (quote == 2){
                            Interface.SetDialogText($"{Enemy.Name} has had enough. Beats you with a baseball bat dealing {Enemy.Attack} damage.");
                        } else if (quote > 3){
                            Interface.SetDialogText($"{Enemy.Name} attacks dealing {Enemy.Attack} damage.");
                        }
                    } else if (AI <= 10) {
                        Player.ApplyBurn();
                        isDead = Enemy.Damage(150);
                        int quote = Random.Range(0,10);
                        if (quote < 3){
                            Interface.SetDialogText($"{Enemy.Name} knows we fireBallin'. You took 150 damage.");
                        } else if (quote > 3){
                            Interface.SetDialogText($"{Enemy.Name} can throw fireballs too, causing 150 damage.");
                        }
                    }
                    Enemy.EnrageReduction(1);
                }
            }

            _state = BattleState.PlayerTransition;

            yield return new WaitForSeconds(5f);

            if (isDead)
            {
                _state = BattleState.Lost;
                StartCoroutine(EndGame());
            }
            else
            {
                _state = BattleState.PlayerTurn;
                StartCoroutine(PlayerTurn());
            }
        }

        private IEnumerator EndGame()
        {
            switch (_state)
            {
                case BattleState.Won:
                    Interface.SetDialogText("You feel strange, you defeated ToDoList and your imposter syndrome. But it feels like it isn't over yet. You continue onward looking towards the future.");
                    transition1.battleFinish = true;
                    transition2.battleFinish = true;
                    transition3.battleFinish = true;
                    transition4.battleFinish = true;
                    yield return new WaitForSecondsRealtime(6f);
                    SceneManager.LoadScene(0);  
                    break;
                case BattleState.Lost:
                    Interface.SetDialogText("ToDoList will forever live on.");
                    transition1.battleFinish = true;
                    transition2.battleFinish = true;
                    transition3.battleFinish = true;
                    transition4.battleFinish = true;
                    yield return new WaitForSecondsRealtime(6f);
                    SceneManager.LoadScene(0);
                    break;
                default:
                    Interface.SetDialogText("How?");
                    transition1.battleFinish = true;
                    transition2.battleFinish = true;
                    transition3.battleFinish = true;
                    transition4.battleFinish = true;
                    yield return new WaitForSecondsRealtime(6f);
                    SceneManager.LoadScene(0);
                    break;
            }
            yield break;
        }
    }
}
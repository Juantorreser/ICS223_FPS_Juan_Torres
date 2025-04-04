using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private bool isAlive = true; 
    public void ReactToHit()
    {
        if (isAlive)
        {
            WanderingAI enemyAI = GetComponent<WanderingAI>();
            if (enemyAI != null)
            {
                enemyAI.ChangeState(EnemyStates.dead);
            }

            Animator enemyAnimator = GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Die");
            }
        

            this.isAlive = false;

            Messenger.Broadcast(GameEvent.ENEMY_DEAD);
        }
        //StartCoroutine(Die());
    }

    
    private void DeadEvent ()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Die()
    {
        // Enemy falls over and disappears after two seconds
        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    
}

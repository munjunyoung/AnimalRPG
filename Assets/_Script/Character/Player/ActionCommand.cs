using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//text
public class ActionCommand 
{
    public virtual void ExecuteAction(GameObject actor) { }
}
//TestTest!
public class JumpAction : ActionCommand
{
    public override void ExecuteAction(GameObject actor)
    {
        base.ExecuteAction(actor);
        var pos = actor.transform.position;
        pos.y += 10;
        actor.transform.position = pos;
        //Jump
    }
}


public class PlayerAction : MonoBehaviour
{
    ActionCommand Spacebar;

    public void Start()
    {
        Spacebar = new JumpAction();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spacebar.ExecuteAction(this.gameObject);
        }
            
    }
}
    

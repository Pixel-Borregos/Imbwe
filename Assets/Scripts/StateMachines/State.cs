using Unity.VisualScripting;
using UnityEngine;

public class State
{
    public State nextState;

    public GameObject gameObject;

    public enum STAGE
    {
        Enter, Update, Exit, None
    }

    public State(GameObject go)
    {
        this.gameObject = go;
    }

    public STAGE stage;

    public virtual void Enter()
    {
        this.stage = STAGE.Update;
    }

    public virtual void Update()
    {
        this.stage = STAGE.Update;
    }

    public virtual void Exit()
    {
        this.stage = STAGE.Exit;
    }

    public virtual void None()
    {
        return;
    }

    public State Process()
    {
        if (stage == STAGE.Exit)
        {
            Exit();
            return nextState;
        }

        if (stage == STAGE.Enter)
            Enter();

        else if (stage == STAGE.Update)
            Update();
        else if (stage == STAGE.None)
            None();

        return this;
    }

}
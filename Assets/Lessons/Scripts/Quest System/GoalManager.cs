using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public Dictionary<GoalSO, GoalData> goalLibrary = new();
    public static GoalManager instance;
    public event Action<GoalData> onGoalComplete;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetBoolRequirement(BoolRequirementSO requirement, bool newValue)
    {
        foreach(GoalData goalData in goalLibrary.Values)
        {
            if (goalData.isActive == false) continue;
            if(goalData.requirements.TryGetValue(requirement, out RequirementData
                baseData) && baseData is BoolRequirementData reqData)
            {
                reqData.value = newValue;
            }
        }
    }

    public void SetIntRequirement(IntRequirementSO requirement, int increment)
    {
        foreach (GoalData goalData in goalLibrary.Values)
        {
            if (goalData.isActive == false) continue;
            if (goalData.requirements.TryGetValue(requirement, out RequirementData
                baseData) && baseData is IntRequirementData reqData)
            {
                reqData.Increment(increment);
            }
        }
    }

    public void ActivateGoal(int goalID)
    {
        foreach(GoalData goal in goalLibrary.Values)
        {
            goal.onGoalUpdated += UpdateGoal;
            if(goal.goalID == goalID)
            {
                goal.ActivateGoal();
            }
        }
    }

    public void UpdateGoal(GoalData goalData)
    {
        if(goalData.isActive && goalData.isComplete)
        {
            if(goalData.nextGoalID > -1)
            {
                ActivateGoal(goalData.nextGoalID);
            }

            goalData.isActive = false;
            onGoalComplete(goalData);
        }
    }

    public void TrackQuest(QuestData questData)
    {
        goalLibrary.AddRange(questData.goals);
        ActivateGoal(questData.initialGoalID);
    }
}

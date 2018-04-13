using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMpxjLib
{
    public partial class mpxWrapper
    {
        //Snow Project from Chrome DOM
        public class jsonSnowProjListRoot
        {
            public SnowProjFmChrome[] result;
        }
        public class SnowProjFmChrome
        {
            public string level;
            public lvDataNode portfolio;
            public lvDataNode program;
            public lvDataNode cmdbci;
            public lvDataNode projectnum;
            public lvDataNode projectname;
            public lvDataNode projectmgr;
            public lvDataNode phase;
            public lvDataNode phasetype;
            public lvDataNode calculationtype;
            public lvDataNode schedule;
            public lvDataNode state;
            public lvDataNode priority;
            public lvDataNode risk;
            public lvDataNode strategicpriority;
            public lvDataNode hotitem;
            public lvDataNode needsfollowup;
            public lvDataNode plannedstartdate;
            public lvDataNode plannedenddate;
            public lvDataNode actualstartdate;
            public lvDataNode actualenddate;
            public lvDataNode isrollup;
            public SnowTaskFmChrome[] childlist;
        }
        public class SnowTaskFmChrome
        {
            public string level;
            public lvDataNode tasknum;
            public lvDataNode taskname;
            public lvDataNode taskassignmentgroup;
            public lvDataNode taskassignedto;
            public lvDataNode taskstate;
            public lvDataNode taskpriority;
            public lvDataNode taskimpact;
            public lvDataNode tasktype;
            public lvDataNode taskconstraint;
            public lvDataNode taskkeymilestone;
            public lvDataNode taskmilestone;
            public lvDataNode taskplannedstartdate;
            public lvDataNode taskplannedenddate;
            public lvDataNode taskactualstartdate;
            public lvDataNode taskactualenddate;
            public lvDataNode isrollup;
            public SnowTaskFmChrome[] childlist;
        }


        //Snow Project class
        public class SnowProject
        {
            private int _myIlevel = 0;
            public string level { get { return _myIlevel.ToString(); } set { _myIlevel = Int32.Parse(value); } }
            public int ilevel { get { return _myIlevel; } set { _myIlevel = value; } }

            private lvDataNode _myPortfolio = Utility.mtLvDataNode;
            public lvDataNode Portfolio() { return _myPortfolio; }
            public void Portfolio(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.PortfolioDict.ContainsKey(argValStr))
                    _myPortfolio = new lvDataNode(argValStr, Utility.PortfolioDict[argValStr], argStatus);
                else
                    _myPortfolio = Utility.mtLvDataNode;
            }
            public void Portfolio(lvDataNode argPortfolio)
            {
                if (argPortfolio.isNotNullOrEmpty())
                    _myPortfolio = argPortfolio;
                else
                    _myPortfolio = Utility.mtLvDataNode;
            }


            private lvDataNode _myProgram = Utility.mtLvDataNode;
            public lvDataNode Program() { return _myProgram; }
            public void Program(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.ProgramDict.ContainsKey(argValStr))
                    _myProgram = new lvDataNode(argValStr, Utility.ProgramDict[argValStr], argStatus);
                else
                    _myProgram = Utility.mtLvDataNode;
            }
            public void Program(lvDataNode argProgram)
            {
                if (argProgram.isNotNullOrEmpty())
                    _myProgram = argProgram;
                else
                    _myProgram = Utility.mtLvDataNode;
            }

            private lvDataNode _myCmdbci = Utility.mtLvDataNode;
            public lvDataNode Cmdbci() { return _myCmdbci; }
            public void Cmdbci(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.CmdbciDict.ContainsKey(argValStr))
                    _myCmdbci = new lvDataNode(argValStr, Utility.CmdbciDict[argValStr], argStatus);
                else
                    _myCmdbci = Utility.mtLvDataNode;
            }
            public void Cmdbci(lvDataNode argCmdbci)
            {
                if (argCmdbci.isNotNullOrEmpty())
                    _myCmdbci = argCmdbci;
                else
                    _myCmdbci = Utility.mtLvDataNode;
            }

            private lvDataNode _myProjectNum = Utility.mtLvDataNode;
            public lvDataNode ProjectNum() { return _myProjectNum; }
            public void ProjectNum(string argValStr, string argLblStr, dStatus argStatus = dStatus._snow) { _myProjectNum = new lvDataNode(argValStr, argLblStr, argStatus); }
            public void ProjectNum(lvDataNode argProjectNum) { _myProjectNum = argProjectNum; }

            private lvDataNode _myProjectName = Utility.mtLvDataNode;
            public lvDataNode ProjectName() { return _myProjectName; }
            public void ProjectName(string argStr, dStatus argStatus = dStatus._new) { _myProjectName = new lvDataNode(argStr, argStr, argStatus); }
            public void ProjectName(lvDataNode argProjectName)
            {
                if (argProjectName.isNotNullOrEmpty())
                    _myProjectName = argProjectName;
                else
                    _myProjectName = Utility.mtLvDataNode;
            }

            private lvDataNode _myCalculationType = Utility.mtLvDataNode;
            public lvDataNode CalculationType() { return _myCalculationType; }
            public void CalculationType(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.CalculationTypeDict.ContainsKey(argValStr))
                    _myCalculationType = new lvDataNode(argValStr, Utility.CalculationTypeDict[argValStr], argStatus);
                else
                    _myCalculationType = Utility.mtLvDataNode;
            }
            public void CalculationType(lvDataNode argCalculationType)
            {
                if (argCalculationType.isNotNullOrEmpty())
                    _myCalculationType = argCalculationType;
                else
                    _myCalculationType = Utility.mtLvDataNode;
            }

            private lvDataNode _myProjMgr = Utility.mtLvDataNode;
            public lvDataNode ProjMgr() { return _myProjMgr; }
            public void ProjMgr(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.ProjMgrDict.ContainsKey(argValStr))
                    _myProjMgr = new lvDataNode(argValStr, Utility.ProjMgrDict[argValStr], argStatus);
                else
                    _myProjMgr = Utility.mtLvDataNode;
            }
            public void ProjMgr(lvDataNode argProjMgr)
            {
                if (argProjMgr.isNotNullOrEmpty())
                    _myProjMgr = argProjMgr;
                else
                    _myProjMgr = Utility.mtLvDataNode;
            }

            private lvDataNode _myPhase = Utility.mtLvDataNode;
            public lvDataNode Phase() { return _myPhase; }
            public void Phase(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.PhaseDict.ContainsKey(argValStr))
                    _myPhase = new lvDataNode(argValStr, Utility.PhaseDict[argValStr], argStatus);
                else
                    _myPhase = Utility.mtLvDataNode;
            }
            public void Phase(lvDataNode argPhase)
            {
                if (argPhase.isNotNullOrEmpty())
                    _myPhase = argPhase;
                else
                    _myPhase = Utility.mtLvDataNode;
            }

            private lvDataNode _myPhaseType = Utility.mtLvDataNode;
            public lvDataNode PhaseType() { return _myPhaseType; }
            public void PhaseType(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.PhaseTypeDict.ContainsKey(argValStr))
                    _myPhaseType = new lvDataNode(argValStr, Utility.PhaseTypeDict[argValStr], argStatus);
                else
                    _myPhaseType = Utility.mtLvDataNode;
            }
            public void PhaseType(lvDataNode argPhaseType)
            {
                if (argPhaseType.isNotNullOrEmpty())
                    _myPhaseType = argPhaseType;
                else
                    _myPhaseType = Utility.mtLvDataNode;
            }

            private lvDataNode _mySchedule = Utility.mtLvDataNode;
            public lvDataNode Schedule() { return _mySchedule; }
            public void Schedule(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.ScheduleDict.ContainsKey(argValStr))
                    _mySchedule = new lvDataNode(argValStr, Utility.ScheduleDict[argValStr], argStatus);
                else
                    _mySchedule = Utility.mtLvDataNode;
            }
            public void Schedule(lvDataNode argSchedule)
            {
                if (argSchedule.isNotNullOrEmpty())
                    _mySchedule = argSchedule;
                else
                    _mySchedule = Utility.mtLvDataNode;
            }

            private lvDataNode _myState = Utility.mtLvDataNode;
            public lvDataNode State() { return _myState; }
            public void State(int argVal, dStatus argStatus = dStatus._new)
            {
                State(argVal.ToString(), argStatus);
            }
            public void State(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.StateDict.ContainsKey(argValStr))
                    _myState = new lvDataNode(argValStr, Utility.StateDict[argValStr], argStatus);
                else
                    _myState = Utility.mtLvDataNode;
            }
            public void State(lvDataNode argState)
            {
                if (argState.isNotNullOrEmpty())
                    _myState = argState;
                else
                    _myState = Utility.mtLvDataNode;
            }

            private lvDataNode _myPriority = Utility.mtLvDataNode;
            public lvDataNode Priority() { return _myPriority; }
            public void Priority(int argVal, dStatus argStatus = dStatus._new)
            {
                Priority(argVal.ToString(), argStatus);
            }
            public void Priority(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.PriorityDict.ContainsKey(argValStr))
                    _myPriority = new lvDataNode(argValStr, Utility.PriorityDict[argValStr], argStatus);
                else
                    _myPriority = Utility.mtLvDataNode;
            }
            public void Priority(lvDataNode argPriority)
            {
                if (argPriority.isNotNullOrEmpty())
                    _myPriority = argPriority;
                else
                    _myPriority = Utility.mtLvDataNode;
            }

            private lvDataNode _myRisk = Utility.mtLvDataNode;
            public lvDataNode Risk() { return _myRisk; }
            public void Risk(int argVal, dStatus argStatus = dStatus._new)
            {
                {
                    Risk(argVal.ToString(), argStatus);
                }
            }
            public void Risk(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.RiskDict.ContainsKey(argValStr))
                    _myRisk = new lvDataNode(argValStr, Utility.RiskDict[argValStr], argStatus);
                else
                    _myRisk = Utility.mtLvDataNode;
            }
            public void Risk(lvDataNode argRisk)
            {
                if (argRisk.isNotNullOrEmpty())
                    _myRisk = argRisk;
                else
                    _myRisk = Utility.mtLvDataNode;
            }

            private lvDataNode _myStrategicPriority = Utility.mtLvDataNode;
            public lvDataNode StrategicPriority() { return _myStrategicPriority; }
            public void StrategicPriority(string argStr, dStatus argStatus = dStatus._new) { _myStrategicPriority = new lvDataNode(argStr, argStr, argStatus); }
            public void StrategicPriority(lvDataNode argStrategicPriority)
            {
                if (argStrategicPriority.isNotNullOrEmpty())
                    _myStrategicPriority = argStrategicPriority;
                else
                    _myStrategicPriority = Utility.mtLvDataNode;
            }

            private lvDataNode _myHotItem = Utility.mtLvDataNode;
            public lvDataNode HotItem() { return _myHotItem; }
            public void HotItem(string argBoolStr, dStatus argStatus = dStatus._new) { _myHotItem = new lvDataNode(argBoolStr, argBoolStr, argStatus); }
            public void HotItem(lvDataNode argHotItem)
            {
                if (argHotItem.isNotNullOrEmpty())
                    _myHotItem = argHotItem;
                else
                    _myHotItem = Utility.mtLvDataNode;
            }

            private lvDataNode _myNeedsFollowUp = Utility.mtLvDataNode;
            public lvDataNode NeedsFollowUp() { return _myNeedsFollowUp; }
            public void NeedsFollowUp(string argBoolStr, dStatus argStatus = dStatus._new) { _myNeedsFollowUp = new lvDataNode(argBoolStr, argBoolStr, argStatus); }
            public void NeedsFollowUp(lvDataNode argNeedsFollowUp)
            {
                if (argNeedsFollowUp.isNotNullOrEmpty())
                    _myNeedsFollowUp = argNeedsFollowUp;
                else
                    _myNeedsFollowUp = Utility.mtLvDataNode;
            }

            private lvDataNode _myPlannedStartDate = Utility.mtLvDateDataNode;
            public lvDataNode PlannedStartDate() { return _myPlannedStartDate; }
            public void PlannedStartDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myPlannedStartDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myPlannedStartDate = Utility.mtLvDateDataNode;
            }
            public void PlannedStartDate(lvDataNode argPlannedStartDate)
            {
                if (argPlannedStartDate.isNotNullOrEmpty())
                    _myPlannedStartDate = argPlannedStartDate;
                else
                    _myPlannedStartDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myPlannedEndDate = Utility.mtLvDateDataNode;
            public lvDataNode PlannedEndDate() { return _myPlannedEndDate; }
            public void PlannedEndDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myPlannedEndDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myPlannedEndDate = Utility.mtLvDateDataNode;
            }
            public void PlannedEndDate(lvDataNode argPlannedEndDate)
            {
                if (argPlannedEndDate.isNotNullOrEmpty())
                    _myPlannedEndDate = argPlannedEndDate;
                else
                    _myPlannedEndDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myActualStartDate = Utility.mtLvDateDataNode;
            public lvDataNode ActualStartDate() { return _myActualStartDate; }
            public void ActualStartDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myActualStartDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myActualStartDate = Utility.mtLvDateDataNode;
            }
            public void ActualStartDate(lvDataNode argActualStartDate)
            {
                if (argActualStartDate.isNotNullOrEmpty())
                    _myActualStartDate = argActualStartDate;
                else
                    _myActualStartDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myActualEndDate = Utility.mtLvDateDataNode;
            public lvDataNode ActualEndDate() { return _myActualEndDate; }
            public void ActualEndDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myActualEndDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myActualEndDate = Utility.mtLvDateDataNode;
            }
            public void ActualEndDate(lvDataNode argActualEndDate)
            {
                if (argActualEndDate.isNotNullOrEmpty())
                    _myActualEndDate = argActualEndDate;
                else
                    _myActualEndDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myIsRollUp = Utility.mtLvDataNode;
            public lvDataNode IsRollUp() { return _myIsRollUp; }
            public void IsRollUp(string argBoolStr, dStatus argStatus = dStatus._new) { _myIsRollUp = new lvDataNode(argBoolStr, argBoolStr, argStatus); }
            public void IsRollUp(lvDataNode argIsRollUp)
            {
                if (argIsRollUp.isNotNullOrEmpty())
                    _myIsRollUp = argIsRollUp;
                else
                    _myIsRollUp = Utility.mtLvDataNode;
            }

            private List<SnowTask> _childtasks = new List<SnowTask>();
            public List<SnowTask> ChildTasks { get { return _childtasks; } set { _childtasks = value; } }

            public SnowProject(projectTree p)
            {
                this.Priority(p.priority);
                this.Risk(p.risk);
                this.State(p.state);
                this.CalculationType(p.calculation_type);
                this.ProjectName(p.short_description);
                this.PlannedStartDate(p.schedule_start_date);
                this.PlannedEndDate(p.schedule_end_date);
                this.ActualStartDate(p.start_date);
                this.ActualEndDate(p.end_date);
                if (ActualStartDate().value.IndexOf("YYYY-MM-DD") < 0 && ActualStartDate().value.Trim().Length > 0)
                {
                    DateTime myStartDtm = DateTime.Parse(p.start_date);
                    DateTime myNowDtm = DateTime.Now;
                    if (myNowDtm > myStartDtm)
                    {
                        this.State(2); //Make Work-In-Progress;
                    }

                }
                if (p.childtasks.Count > 0)
                {
                    foreach (taskTree t in p.childtasks)
                    {
                        //Note: If child state is "WIP", then also applies to parent!
                        var st = new SnowTask(t, this.ilevel + 1);
                        this.ChildTasks.Add(st);
                        if (Int32.Parse(st.State().value) > 1)
                        {
                            this.State(2);
                        }
                    }
                }
            }
            public SnowProject(SnowProjFmChrome p)
            {
                this.Portfolio(p.portfolio);
                this.Program(p.program);
                this.Cmdbci(p.cmdbci);
                this.ProjectNum(p.projectnum);
                this.ProjectName(p.projectname);
                this.ProjMgr(p.projectmgr);
                this.Phase(p.phase);
                this.PhaseType(p.phasetype);
                this.CalculationType(p.calculationtype);
                this.Schedule(p.schedule);
                this.State(p.state);
                this.Priority(p.priority);
                this.Risk(p.risk);
                this.StrategicPriority(p.strategicpriority);
                this.HotItem(p.hotitem);
                this.IsRollUp(p.isrollup);
                this.NeedsFollowUp(p.needsfollowup);
                this.PlannedStartDate(p.plannedstartdate);
                this.PlannedEndDate(p.plannedenddate);
                this.ActualStartDate(p.actualstartdate);
                this.ActualEndDate(p.actualenddate);
                int iLen;
                if (p.childlist.Length > 0)
                {
                    iLen = p.childlist.Length;
                    for (int i = 0; i < iLen; i++)
                    {
                        var st = new SnowTask(p.childlist[i], this.ilevel + 1);
                        this.ChildTasks.Add(st);
                    }
                }
            }
        }

        // Snow Task
        public class SnowTask
        {
            private int _myIlevel = 0;
            public string level { get { return _myIlevel.ToString(); } set { _myIlevel = Int32.Parse(value); } }
            public int ilevel { get { return _myIlevel; } set { _myIlevel = value; } }

            private lvDataNode _myTaskNum = Utility.mtLvDataNode;
            public lvDataNode TaskNum() { return _myTaskNum; }
            public void TaskNum(string argValStr, string argLblStr, dStatus argStatus = dStatus._snow) { _myTaskNum = new lvDataNode(argValStr, argLblStr, argStatus); }
            public void TaskNum(lvDataNode argTaskNum)
            {
                if (argTaskNum.isNotNullOrEmpty())
                    _myTaskNum = argTaskNum;
                else
                    _myTaskNum = Utility.mtLvDataNode;
            }

            private lvDataNode _myTaskName = Utility.mtLvDataNode;
            public lvDataNode TaskName() { return _myTaskName; }
            public void TaskName(string argStr, dStatus argStatus = dStatus._new) { _myTaskName = new lvDataNode(argStr, argStr, argStatus); }
            public void TaskName(lvDataNode argTaskName)
            {
                if (argTaskName.isNotNullOrEmpty())
                    _myTaskName = argTaskName;
                else
                    _myTaskName = Utility.mtLvDataNode;
            }

            private lvDataNode _myAssignmentGroup = Utility.mtLvDataNode;
            public lvDataNode AssignmentGroup() { return _myAssignmentGroup; }
            public void AssignmentGroup(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.TaskAssignmentGroupDict.ContainsKey(argValStr))
                    _myAssignmentGroup = new lvDataNode(argValStr, Utility.TaskAssignmentGroupDict[argValStr], argStatus);
                else
                    _myAssignmentGroup = Utility.mtLvDataNode;
            }
            public void AssignmentGroup(string argValStr, string argLblStr) { _myAssignmentGroup = new lvDataNode(argValStr, argLblStr); }
            public void AssignmentGroup(lvDataNode argAssignmentGroup)
            {
                if (argAssignmentGroup.isNotNullOrEmpty())
                    _myAssignmentGroup = argAssignmentGroup;
                else
                    _myAssignmentGroup = Utility.mtLvDataNode;
            }

            private lvDataNode _myAssignedTo = Utility.mtLvDataNode;
            public lvDataNode AssignedTo() { return _myAssignedTo; }
            public void AssignedTo(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.TaskAssignedToDict.ContainsKey(argValStr))
                    _myAssignedTo = new lvDataNode(argValStr, Utility.TaskAssignedToDict[argValStr], argStatus);
                else
                    _myAssignedTo = Utility.mtLvDataNode;
            }
            public void AssignedTo(lvDataNode argAssignedTo)
            {
                if (argAssignedTo.isNotNullOrEmpty())
                    _myAssignedTo = argAssignedTo;
                else
                    _myAssignedTo = Utility.mtLvDataNode;
            }

            private lvDataNode _myState = Utility.mtLvDataNode;
            public lvDataNode State() { return _myState; }
            public void State(int argVal, dStatus argStatus = dStatus._new)
            {
                State(argVal.ToString(), argStatus);
            }
            public void State(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.StateDict.ContainsKey(argValStr))
                    _myState = new lvDataNode(argValStr, Utility.StateDict[argValStr], argStatus);
                else
                    _myState = Utility.mtLvDataNode;
            }
            public void State(lvDataNode argState)
            {
                if (argState.isNotNullOrEmpty())
                    _myState = argState;
                else
                    _myState = Utility.mtLvDataNode;
            }

            private lvDataNode _myPriority = Utility.mtLvDataNode;
            public lvDataNode Priority() { return _myPriority; }
            public void Priority(int argVal, dStatus argStatus = dStatus._new)
            {
                Priority(argVal.ToString(), argStatus);
            }
            public void Priority(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.PriorityDict.ContainsKey(argValStr))
                    _myPriority = new lvDataNode(argValStr, Utility.PriorityDict[argValStr], argStatus);
                else
                    _myPriority = Utility.mtLvDataNode;
            }
            public void Priority(lvDataNode argPriority)
            {
                if (argPriority.isNotNullOrEmpty())
                    _myPriority = argPriority;
                else
                    _myPriority = Utility.mtLvDataNode;
            }

            private lvDataNode _myImpact = Utility.mtLvDataNode;
            public lvDataNode Impact() { return _myImpact; }
            public void Impact(int argVal, dStatus argStatus = dStatus._new)
            {
                Impact(argVal.ToString(), argStatus);
            }
            public void Impact(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.ImpactDict.ContainsKey(argValStr))
                    _myImpact = new lvDataNode(argValStr, Utility.ImpactDict[argValStr], argStatus);
                else
                    _myImpact = Utility.mtLvDataNode;
            }
            public void Impact(lvDataNode argImpact)
            {
                if (argImpact.isNotNullOrEmpty())
                    _myImpact = argImpact;
                else
                    _myImpact = Utility.mtLvDataNode;
            }

            private lvDataNode _myTaskType = Utility.mtLvDataNode;
            public lvDataNode TaskType() { return _myTaskType; }
            public void TaskType(int argVal, dStatus argStatus = dStatus._new)
            {
                TaskType(argVal.ToString(), argStatus);
            }
            public void TaskType(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.TaskTypeDict.ContainsKey(argValStr))
                    _myTaskType = new lvDataNode(argValStr, Utility.TaskTypeDict[argValStr], argStatus);
                else
                    _myTaskType = Utility.mtLvDataNode;
            }
            public void TaskType(lvDataNode argTaskType)
            {
                if (argTaskType.isNotNullOrEmpty())
                    _myTaskType = argTaskType;
                else
                    _myTaskType = Utility.mtLvDataNode;
            }

            private lvDataNode _myConstraint = Utility.mtLvDataNode;
            public lvDataNode Constraint() { return _myConstraint; }
            public void Constraint(int argVal, dStatus argStatus = dStatus._new)
            {
                Constraint(argVal.ToString(), argStatus);
            }
            public void Constraint(string argValStr, dStatus argStatus = dStatus._new)
            {
                if (Utility.ConstraintDict.ContainsKey(argValStr))
                    _myConstraint = new lvDataNode(argValStr, Utility.ConstraintDict[argValStr], argStatus);
                else
                    _myConstraint = Utility.mtLvDataNode;
            }
            public void Constraint(lvDataNode argConstraint)
            {
                if (argConstraint.isNotNullOrEmpty())
                    _myConstraint = argConstraint;
                else
                    _myConstraint = Utility.mtLvDataNode;
            }

            private lvDataNode _myKeyMilestone = Utility.mtLvDataNode;
            public lvDataNode KeyMilestone() { return _myKeyMilestone; }
            public void KeyMilestone(string argBoolStr, dStatus argStatus = dStatus._new) { _myKeyMilestone = new lvDataNode(argBoolStr, argBoolStr, argStatus); }
            public void KeyMilestone(lvDataNode argKeyMilestone)
            {
                if (argKeyMilestone.isNotNullOrEmpty())
                    _myKeyMilestone = argKeyMilestone;
                else
                    _myKeyMilestone = Utility.mtLvDataNode;
            }

            private lvDataNode _myMilestone = Utility.mtLvDataNode;
            public lvDataNode Milestone() { return _myMilestone; }
            public void Milestone(string argBoolStr, dStatus argStatus = dStatus._new) { _myMilestone = new lvDataNode(argBoolStr, argBoolStr, argStatus); }
            public void Milestone(lvDataNode argMilestone)
            {
                if (argMilestone.isNotNullOrEmpty())
                    _myMilestone = argMilestone;
                else
                    _myMilestone = Utility.mtLvDataNode;
            }

            private lvDataNode _myPlannedStartDate = Utility.mtLvDateDataNode;
            public lvDataNode PlannedStartDate() { return _myPlannedStartDate; }
            public void PlannedStartDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myPlannedStartDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myPlannedStartDate = Utility.mtLvDateDataNode;
            }
            public void PlannedStartDate(lvDataNode argPlannedStartDate)
            {
                if (argPlannedStartDate.isNotNullOrEmpty())
                    _myPlannedStartDate = argPlannedStartDate;
                else
                    _myPlannedStartDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myPlannedEndDate = Utility.mtLvDateDataNode;
            public lvDataNode PlannedEndDate() { return _myPlannedEndDate; }
            public void PlannedEndDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myPlannedEndDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myPlannedEndDate = Utility.mtLvDateDataNode;
            }
            public void PlannedEndDate(lvDataNode argPlannedEndDate)
            {
                if (argPlannedEndDate.isNotNullOrEmpty())
                    _myPlannedEndDate = argPlannedEndDate;
                else
                    _myPlannedEndDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myActualStartDate = Utility.mtLvDateDataNode;
            public lvDataNode ActualStartDate() { return _myActualStartDate; }
            public void ActualStartDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myActualStartDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myActualStartDate = Utility.mtLvDateDataNode;
            }
            public void ActualStartDate(lvDataNode argActualStartDate)
            {
                if (argActualStartDate.isNotNullOrEmpty())
                    _myActualStartDate = argActualStartDate;
                else
                    _myActualStartDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myActualEndDate = Utility.mtLvDateDataNode;
            public lvDataNode ActualEndDate() { return _myActualEndDate; }
            public void ActualEndDate(string argDtmStr, dStatus argStatus = dStatus._new)
            {
                if ((argDtmStr.Trim().Length > 0) && (argDtmStr.IndexOf("YYYY-MM-DD") < 0))
                    _myActualEndDate = new lvDataNode(argDtmStr, argDtmStr, argStatus);
                else
                    _myActualEndDate = Utility.mtLvDateDataNode;
            }
            public void ActualEndDate(lvDataNode argActualEndDate)
            {
                if (argActualEndDate.isNotNullOrEmpty())
                    _myActualEndDate = argActualEndDate;
                else
                    _myActualEndDate = Utility.mtLvDateDataNode;
            }

            private lvDataNode _myIsRollUp = Utility.mtLvDataNode;
            public lvDataNode IsRollUp() { return _myIsRollUp; }
            public void IsRollUp(string argBoolStr, dStatus argStatus = dStatus._new) { _myIsRollUp = new lvDataNode(argBoolStr, argBoolStr, argStatus); }
            public void IsRollUp(lvDataNode argIsRollUp)
            {
                if (argIsRollUp.isNotNullOrEmpty())
                    _myIsRollUp = argIsRollUp;
                else
                    _myIsRollUp = Utility.mtLvDataNode;
            }


            private List<SnowTask> _childtasks = new List<SnowTask>();
            public List<SnowTask> ChildTasks { get { return _childtasks; } set { _childtasks = value; } }

            public SnowTask(taskTree t, int argIlevel)
            {
                this.ilevel = argIlevel;
                this.Priority(t.priority);
                this.State(t.state);
                this.TaskName(t.short_description);
                this.Constraint(t.time_constraint);
                this.PlannedStartDate(t.schedule_start_date);
                this.PlannedEndDate(t.schedule_end_date);
                this.ActualStartDate(t.start_date);
                this.ActualEndDate(t.end_date);
                if (ActualStartDate().value.IndexOf("YYYY-MM-DD") < 0 && ActualStartDate().value.Trim().Length > 0)
                {
                    DateTime myStartDtm = DateTime.Parse(t.start_date);
                    DateTime myNowDtm = DateTime.Now;
                    if (myNowDtm > myStartDtm)
                    {
                        State(2); //Make Work-In-Progress;
                    }
                }
                if (t.childtasks.Count > 0)
                {
                    foreach (taskTree ct in t.childtasks)
                    {
                        //Note: If child state is "WIP", then also applies to parent!
                        var st = new SnowTask(ct, this.ilevel + 1);
                        this.ChildTasks.Add(st);
                        if (Int32.Parse(st.State().value) > 1)
                        {
                            this.State(2);
                        }
                    }
                }
            }
            public SnowTask(SnowTaskFmChrome t, int argIlevel)
            {
                this.ilevel = argIlevel;
                this.TaskNum(t.tasknum);
                this.TaskName(t.taskname);
                this.AssignmentGroup(t.taskassignmentgroup);
                this.AssignedTo(t.taskassignedto);
                this.State(t.taskstate);
                this.Priority(t.taskpriority);
                this.Impact(t.taskimpact);
                this.TaskType(t.tasktype);
                this.Constraint(t.taskconstraint);
                this.KeyMilestone(t.taskkeymilestone);
                this.Milestone(t.taskmilestone);
                this.IsRollUp(t.isrollup);
                this.PlannedStartDate(t.taskplannedstartdate);
                this.PlannedEndDate(t.taskplannedenddate);
                this.ActualStartDate(t.taskactualstartdate);
                this.ActualEndDate(t.taskactualenddate);
                int iLen;
                if (t.childlist.Length > 0)
                {
                    iLen = t.childlist.Length;
                    for (int i = 0; i < iLen; i++)
                    {
                        var st = new SnowTask(t.childlist[i], this.ilevel + 1);
                        this.ChildTasks.Add(st);
                    }
                }
            }
        }
    }
}

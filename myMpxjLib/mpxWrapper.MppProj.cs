using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using nj = Newtonsoft.Json;

namespace myMpxjLib
{
    public partial class mpxWrapper
    {

        // MPP Project 
        public class MppProject
        {
            public MppProject()
            {
                Tasks = new List<MppTask>();
                AllTasks = new List<MppTask>();
                Resources = new List<MppResource>();
            }
            public MppProjectHeader Header { get; set; }
            public int MppFileType { get; set; }
            public List<MppTask> AllTasks { get; private set; }
            public List<MppTask> Tasks { get; private set; }
            public List<MppResource> Resources { get; private set; }
            public string ProjectFilePath { get; set; }
        }

        // Project Header
        public class MppProjectHeader
        {
            public string UniqueId { get; set; }
            public string Name { get; set; }
        }

        // Project Task
        public class MppTask
        {
            public MppTask()
            {
                ChildTasks = new List<MppTask>();
                Resources = new List<MppResource>();
                PredecessorTaskIds = new List<long>();
            }
            public long Id { get; set; }
            public long UniqueId { get; set; }
            public string Name { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? FinishDate { get; set; }
            public DateTime? ActualStartDate { get; set; }
            public DateTime? ActualFinishDate { get; set; }
            public DateTime? ConstraintDate { get; set; }
            public TimeSpan Duration { get; set; }
            public List<MppTask> ChildTasks { get; private set; }
            public List<MppResource> Resources { get; private set; }
            public List<long> PredecessorTaskIds { get; private set; }
            public string PredecessorTaskIdsString
            {
                get { return String.Join(", ", PredecessorTaskIds); }
            }
            public long ParentTaskId { get; set; }
            public string ResourceNames { get; set; }
            public double PercentageComplete { get; set; }
            public MppPriority Priority { get; set; }
            public string Notes { get; set; }
            public MppConstraintType ConstraintType { get; set; }
        }

        //Project Priority
        public enum MppPriority
        {
            Lowest = 100,
            VeryLow = 200,
            Lower = 300,
            Low = 400,
            Medium = 500,
            High = 600,
            Higher = 700,
            VeryHigh = 800,
            Highest = 900,
            DoNotLevel = 1000
        }

        //Project Constraint Type
        public enum MppConstraintType
        {
            AsSoonAsPossible = 0,
            AsLateAsPossible = 1,
            MustStartOn = 2,
            MustFinishOn = 3,
            StartNoEarlierThan = 4,
            StartNoLaterThan = 5,
            FinishNoEarlierThan = 6,
            FinishNoLaterThan = 7,
        }

        //Project Resource
        public class MppResource
        {
            public MppResource()
            {
                Tasks = new List<MppTask>();
            }
            public long Id { get; set; }
            public long UniqueId { get; set; }
            public string Name { get; set; }
            public string Initials { get; set; }
            public string Group { get; set; }
            public string Email { get; set; }
            public string Code { get; set; }
            public string MaterialLabel { get; set; }
            public string StandardRate { get; set; }
            public string OvertimeRate { get; set; }
            public string Notes { get; set; }
            public List<MppTask> Tasks { get; private set; }
        }
        //
        public class taskTree
        {
            public string short_description;
            public string start_date;
            public string end_date;
            public string schedule_start_date;
            public string schedule_end_date;
            public int priority;
            public string calculation_type = "manual"; //automatic, manual
            public string time_constraint = "start_on"; //asap, start_on
            public int state = 1;
            public int urgency = 2;
            public List<taskTree> childtasks = new List<taskTree>();

            public taskTree(MppTask argTask)
            {
                this.short_description = argTask.Name;
                this.start_date = fmtStartDtm(argTask.ActualStartDate);
                this.end_date = fmtEndDtm(argTask.ActualFinishDate);
                this.schedule_start_date = fmtStartDtm(argTask.ConstraintDate, argTask.StartDate, argTask.ActualStartDate);
                this.schedule_end_date = fmtEndDtm(argTask.FinishDate, argTask.ActualFinishDate);
                //trapInvalidDate();
                switch (argTask.Priority)
                {
                    case MppPriority.Lowest:
                    case MppPriority.VeryLow:
                    case MppPriority.Lower:
                    case MppPriority.Low:
                        this.priority = 4;
                        break;
                    case MppPriority.Medium:
                        this.priority = 3;
                        break;
                    case MppPriority.High:
                    case MppPriority.Higher:
                        this.priority = 2;
                        break;
                    case MppPriority.VeryHigh:
                    case MppPriority.Highest:
                        this.priority = 1;
                        break;
                    default:
                        this.priority = 5;
                        break;
                }
                this.time_constraint = (argTask.ConstraintType != MppConstraintType.AsSoonAsPossible) ? "start_on" : "asap";
                foreach (MppTask c in argTask.ChildTasks.ToList())
                {
                    childtasks.Add(new taskTree(c));
                }
            }
            private DateTime? getBestDtm(DateTime? argFirstGuess, DateTime? argNextGuess, DateTime? argLastGuess)
            {
                DateTime? myResult = null;
                if (argFirstGuess != null)
                {
                    myResult = argFirstGuess;
                }
                else if (argNextGuess != null)
                {
                    myResult = argNextGuess;
                }
                else if (argLastGuess != null)
                {
                    myResult = argLastGuess;
                }
                return myResult;
            }
            private DateTime? getBestDtm(DateTime? argFirstGuess, DateTime? argNextGuess)
            {
                DateTime? myResult = null;
                if (argFirstGuess != null)
                {
                    myResult = argFirstGuess;
                }
                else if (argNextGuess != null)
                {
                    myResult = argNextGuess;
                }
                return myResult;
            }
            private string fmtStartDtm(DateTime? argStart)
            {
                return fmtDtm(argStart, true);
            }
            private string fmtEndDtm(DateTime? argEnd)
            {
                return fmtDtm(argEnd, false);
            }
            private string fmtStartDtm(DateTime? argFirstStartGuess, DateTime? argNextStartGuess)
            {
                return fmtDtm(getBestDtm(argFirstStartGuess, argNextStartGuess), true);
            }
            private string fmtEndDtm(DateTime? argFirstEndGuess, DateTime? argNextEndGuess)
            {
                return fmtDtm(getBestDtm(argFirstEndGuess, argNextEndGuess), false);
            }
            private string fmtStartDtm(DateTime? argFirstStartGuess, DateTime? argNextStartGuess, DateTime? argLasStarttGuess)
            {
                return fmtDtm(getBestDtm(argFirstStartGuess, argNextStartGuess, argLasStarttGuess), true);
            }
            private string fmtEndDtm(DateTime? argFirstEndGuess, DateTime? argNextEndGuess, DateTime? argLastEndGuess)
            {
                return fmtDtm(getBestDtm(argFirstEndGuess, argNextEndGuess, argLastEndGuess), false);
            }
            private string fmtDtm(DateTime? argDtm, bool isStart)
            {
                string myResult = "YYYY-MM-DD HH:MM";
                if (argDtm != null)
                {
                    myResult = Convert.ToDateTime(argDtm).ToString("yyyy-MM-dd") + (isStart ? " 08:00" : " 17:00");
                }
                return myResult;
            }
            private string reFmt8amStart(string argStart)
            {
                string myResult = "YYYY-MM-DD HH:MM";
                if (argStart != String.Empty && argStart.IndexOf("YYYY-MM-DD") < 0)
                {
                    var myDateString = argStart.Split(' ')[0].Trim();
                    if (myDateString.Length == 10)
                    {
                        myResult = myDateString + " 08:00";
                    }
                }
                return myResult;
            }
            private string reFmt5pmEnd(string argEnd)
            {
                string myResult = "YYYY-MM-DD HH:MM";
                if (argEnd != String.Empty && argEnd.IndexOf("YYYY-MM-DD") < 0)
                {
                    var myDateString = argEnd.Split(' ')[0].Trim();
                    if (myDateString.Length == 10)
                    {
                        myResult = myDateString + " 17:00";
                    }
                }
                return myResult;
            }
            private bool trapInvalidDate()
            {
                DateTime myDtmLower = DateTime.Now.AddYears(-2);
                DateTime myDtmUpper = DateTime.Now.AddYears(2);
                DateTime _thisStart = Convert.ToDateTime(this.start_date);
                DateTime _thisEnd = Convert.ToDateTime(this.end_date);
                DateTime _thisScheduleStart = Convert.ToDateTime(this.schedule_start_date);
                DateTime _thisScheduleEnd = Convert.ToDateTime(this.schedule_start_date);
                bool isValid = (_thisStart > myDtmLower || _thisStart < myDtmUpper) &&
                               (_thisEnd > myDtmLower || _thisEnd < myDtmUpper) &&
                               (_thisScheduleStart > myDtmLower || _thisScheduleStart < myDtmUpper) &&
                               (_thisScheduleEnd > myDtmLower || _thisScheduleEnd < myDtmUpper);
                return isValid;
            }

        }
        public class projectTree : taskTree
        {
            public string risk = "moderate";
            public projectTree(MppTask argProject) : base(argProject)
            {
            }
        }

    }
}

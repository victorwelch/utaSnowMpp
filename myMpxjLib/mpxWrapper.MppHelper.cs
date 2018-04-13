using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net.sf.mpxj;
using Mpxj = net.sf.mpxj;
using MpxjReader = net.sf.mpxj.reader;
using java.util;

namespace myMpxjLib
{
    public partial class mpxWrapper
    {
        //File Loading Helper
        public partial class MppHelper
        {
            public MppProject LoadProjectFile(string filePath)
            {
                MppProject project = new MppProject() { ProjectFilePath = filePath };

                MpxjReader.ProjectReader reader = MpxjReader.ProjectReaderUtility.getProjectReader(filePath);
                Mpxj.ProjectFile projectFile = reader.read(filePath);
                Mpxj.ProjectProperties projectProperties = projectFile.ProjectProperties;

                project.Header = new MppProjectHeader() { UniqueId = projectProperties.UniqueID, Name = projectProperties.Name };

                PopulateTasks(projectFile, project);
                PopulateResources(projectFile, project);

                return project;
            }

            private void PopulateResources(ProjectFile projectFile, MppProject project)
            {
                java.util.List resourcesList = projectFile.Resources;
                Mpxj.Resource resource = null;

                for (int i = 0; i < resourcesList.size(); i++)
                {
                    resource = resourcesList.get(i) as Mpxj.Resource;

                    project.Resources.Add(GetResource(resource, true));
                }
            }

            private MppResource GetResource(Mpxj.Resource resource, bool loadTasks)
            {
                MppResource returnResource = null;

                if (resource != null)
                {
                    returnResource = new MppResource();

                    returnResource.Id = resource.ID.longValue();
                    returnResource.Name = resource.Name;
                    returnResource.UniqueId = resource.UniqueID.longValue();
                    returnResource.Initials = resource.Initials;
                    returnResource.Group = resource.Group;
                    returnResource.Code = resource.Code;
                    returnResource.MaterialLabel = resource.MaterialLabel;
                    returnResource.Email = resource.EmailAddress;
                    returnResource.StandardRate = String.Format("{1} / {0}", resource.StandardRate.Units, resource.StandardRate.Amount);
                    returnResource.OvertimeRate = String.Format("{1} / {0}", resource.OvertimeRate.Units, resource.OvertimeRate.Amount);
                    returnResource.Notes = resource.Notes;

                    if (loadTasks)
                        GetAssignedTasks(resource, returnResource);
                }

                return returnResource;
            }

            private void GetAssignedTasks(Resource resource, MppResource returnResource)
            {
                java.util.List tasksList = resource.TaskAssignments;
                ResourceAssignment task = null;
                for (int i = 0; i < tasksList.size(); i++)
                {
                    task = tasksList.get(i) as ResourceAssignment;
                    returnResource.Tasks.Add(GetTask(task.Task));
                }
            }

            private void PopulateTasks(ProjectFile projectFile, MppProject project)
            {
                java.util.List tasksList = projectFile.AllTasks;
                Mpxj.Task task = null;
                for (int i = 0; i < tasksList.size(); i++)
                {
                    task = tasksList.get(i) as Mpxj.Task;
                    project.AllTasks.Add(GetTask(task));
                }
                BuildTaskHiererchy(project);
            }

            private void BuildTaskHiererchy(MppProject project)
            {
                foreach (MppTask task in project.AllTasks)
                {
                    if (task.ParentTaskId == -1)
                    {
                        project.Tasks.Add(task);
                    }

                    IEnumerable<MppTask> tasks = project.AllTasks.Where(childTask => childTask.ParentTaskId == task.UniqueId);

                    task.ChildTasks.AddRange(tasks);
                }
            }

            private MppTask GetTask(Mpxj.Task task)
            {
                if (task != null)
                {
                    java.util.Date taskStartDate = task.Start;
                    java.util.Date taskFinishDate = task.Finish;
                    java.util.Date taskActualStartDate = task.ActualStart;
                    java.util.Date taskActualFinishDate = task.ActualFinish;
                    java.util.Date taskConstraintDate = task.ConstraintDate;

                    Mpxj.Task parentTask = task.ParentTask;
                    java.util.List predecessors = task.Predecessors;
                    MppTask returnTask = new MppTask();

                    returnTask.Id = task.ID.longValue();
                    returnTask.UniqueId = task.UniqueID.longValue();
                    returnTask.ParentTaskId = (parentTask == null) ? -1 : parentTask.UniqueID.longValue();
                    returnTask.ConstraintType = (MppConstraintType)task.ConstraintType.Value;

                    returnTask.Name = task.Name;

                    returnTask.StartDate = Utility.GetDateTimme(taskStartDate);
                    returnTask.ConstraintDate = Utility.GetDateTimme(taskConstraintDate);
                    returnTask.FinishDate = Utility.GetDateTimme(taskFinishDate);
                    returnTask.ActualStartDate = Utility.GetDateTimme(taskActualStartDate);
                    returnTask.ActualFinishDate = Utility.GetDateTimme(taskActualFinishDate);

                    returnTask.PercentageComplete = task.PercentageComplete.doubleValue();
                    returnTask.Priority = (MppPriority)task.Priority.Value;
                    returnTask.ResourceNames = task.ResourceNames;
                    returnTask.Notes = task.Notes;

                    if (predecessors != null)
                    {
                        for (int i = 0; i < predecessors.size(); i++)
                        {
                            Relation relation = predecessors.get(i) as Mpxj.Relation;
                            if (relation != null)
                            {
                                returnTask.PredecessorTaskIds.Add(relation.TargetTask.ID.longValue());
                            }
                        }
                    }

                    java.util.List resourcesList = task.ResourceAssignments;
                    Mpxj.Resource resource = null;

                    for (int i = 0; i < resourcesList.size(); i++)
                    {
                        resource = ((Mpxj.ResourceAssignment)resourcesList.get(i)).Resource as Mpxj.Resource;
                        returnTask.Resources.Add(GetResource(resource, false));
                    }


                    return returnTask;
                }

                return null;
            }
        }
    }
}

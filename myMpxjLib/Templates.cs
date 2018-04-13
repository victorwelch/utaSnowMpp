using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMpxjLib.Templates
{
    public partial class templateWebPage
    {
        private List<myMpxjLib.mpxWrapper.SnowProject> twpProject;
        private int twpDepth;
        private bool twpIsMpp;
        public templateWebPage(List<myMpxjLib.mpxWrapper.SnowProject> argProject, int argDepth, bool argIsMpp = true)
        {
            this.twpProject = argProject;
            this.twpDepth = argDepth;
            this.twpIsMpp = argIsMpp;
        }
    }

    public partial class templateProjLuPage
    {
        private string tplProjectList;
        public templateProjLuPage(string argProjectList)
        {
            this.tplProjectList = argProjectList;
        }
    }
}

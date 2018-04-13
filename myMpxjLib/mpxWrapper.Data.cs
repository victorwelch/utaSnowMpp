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

        //
        protected class jsonResult
        {
            public object result;
        }
        public class jsonListRoot
        {
            public jsonList result;
        }
        public class jsonCommon
        {
            public jsonListRoot objData;
            public string strData;
            public jsonCommon(jsonListRoot argObjData, string argStrData)
            {
                this.objData = argObjData;
                this.strData = argStrData;
            }
        }
        public class jsonList
        {
            public lvNode[] portfolio;
            public lvNode[] program;
            public lvflNode[] projmgr;
            public lvflNode[] assignedto;
            public lvNode[] phase;
            public lvNode[] phasetype;
            public lvNode[] calculationtype;
            public lvNode[] schedule;
            public lvNode[] state;
            public lvNode[] priority;
            public lvNode[] risk;
            public lvNode[] constraint;
            public lvNode[] cmdbci;
            public lvNode[] pmtimpact;
            public lvNode[] pmttasktype;
            public lvGrNode[] pmtassignmentgroup;
            public lvflNode[] pmtassignedto;
        }
        public class lvNode
        {
            public string value;
            public string label;
            public lvNode() { }
            public lvNode(string argValueStr, string argLabelStr)
            {
                this.value = argValueStr;
                this.label = argLabelStr;
            }
        }
        public class lvflNode : lvNode
        {
            public string userid;
            public string lname;
            public string fname;
        }
        public class lvGrNode : lvNode
        {
            public lvflNode[] memberlist;
        }
        //
        public class jsonProjListRoot
        {
            public jsonProjList result;
        }
        public class jsonProjList
        {
            public lvProjNode[] project;
        }
        public class jsonProjCommon
        {
            public jsonProjListRoot objData;
            public string strData;
            public jsonProjCommon(jsonProjListRoot argObjData, string argStrData)
            {
                this.objData = argObjData;
                this.strData = argStrData;
            }
        }
        public class lvProjNode
        {
            public string label;
            public string value;
            public string name;
            public string createdon;
            public string createdby;
            public string updatedon;
            public string updatedby;
        }
        //
        public class lvlDict : Dictionary<string, string>
        {
            public lvlDict() : base() { }
            public lvlDict(lvNode[] argLvList) : base()
            {
                int iLen = argLvList.Length;
                for (int i = 0; i < iLen; i++)
                {
                    this.Add(argLvList[i].value, argLvList[i].label);
                }
            }
            public lvlDict(lvflNode[] argLvList) : base()
            {
                int iLen = argLvList.Length;
                for (int i = 0; i < iLen; i++)
                {
                    this.Add(argLvList[i].value, argLvList[i].label);
                }
            }
        }
        public class jsonRoot
        {
            public jsonNode[] result { get; set; }
        }
        public class jsonNode
        {
            public string sysId { get; set; }
            public string number { get; set; }
            public string name { get; set; }
            public jsonNode[] childlist { get; set; }
        }

        public enum dStatus
        {
            _new,
            _snow,
            _update,
            _empty
        }
        public class lvDataNode : lvNode
        {
            public string datastatus;
            public lvDataNode(string argVal, string argLabel, dStatus argStatus = dStatus._new) : base(argVal, argLabel)
            {
                if (((lvNode)this) == Utility.mtLvNode || ((lvNode)this) == Utility.mtLvDateNode)
                {
                    datastatus = "empty";
                }
                switch (argStatus)
                {
                    case dStatus._new:
                        datastatus = "new";
                        break;
                    case dStatus._snow:
                        datastatus = "snow";
                        break;
                    case dStatus._update:
                        datastatus = "update";
                        break;
                    case dStatus._empty:
                        datastatus = "empty";
                        break;
                    default:
                        datastatus = "empty";
                        break;
                }
            }
            public lvDataNode(lvNode argLvNode, dStatus argStatus = dStatus._new) : base(argLvNode.value, argLvNode.label)
            {
                if (((lvNode)this) == Utility.mtLvNode || ((lvNode)this) == Utility.mtLvDateNode)
                {
                    datastatus = "empty";
                }
                switch (argStatus)
                {
                    case dStatus._new:
                        datastatus = "new";
                        break;
                    case dStatus._snow:
                        datastatus = "snow";
                        break;
                    case dStatus._update:
                        datastatus = "update";
                        break;
                    case dStatus._empty:
                        datastatus = "empty";
                        break;
                    default:
                        datastatus = "empty";
                        break;
                }
            }
            [nj.JsonConstructor]
            public lvDataNode()
            {
            }
            public bool isNullOrEmpty()
            {
                return (String.IsNullOrEmpty(this.label) || String.IsNullOrEmpty(this.value));
            }
            public bool isNotNullOrEmpty()
            {
                return !this.isNullOrEmpty();
            }
        }

    }
}

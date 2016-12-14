using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Proficy.CIMPLICITY;
using Proficy.CIMPLICITY.CimServer;

namespace JLR.CFM.DCP.Import
{
    class CimProject
    {
        public delegate void SequenceHandler(Sequence s);
        public event SequenceHandler NewSequence;

        public delegate void RobotHandler(Robot r);
        public event RobotHandler NewRobot;

        public delegate void TrimStationHandler(TrimStation t);
        public event TrimStationHandler NewTrimStation;

        private Dictionary<string, Sequence> _Sequences = new Dictionary<string, Sequence>();
        private Dictionary<string, Robot> _Robots = new Dictionary<string, Robot>();
        private Dictionary<string, TrimStation> _TrimStations = new Dictionary<string, TrimStation>();

        private cimProject _Project = new cimProject();
        private bool _dynamic = false;

        public CimProject()
        {
            //string Project = CimpConfig.Settings.Project;
            //string Path = CimpConfig.Settings.Path;

            //if (!Path.EndsWith(@"\")) Path += @"\";

            //_Project.OpenLocalProject($"{Path}{Project}\\{Project}.gef");
            //_Project.ProjectUserName = "ADMINISTRATOR";
            //_Project.ProjectPassword = "";
            //_Project.dynamicMode = _dynamic; 
        }

        public void test()
        {
            CreateProject();
            AddParams();
            AddClasses();
            SetUpDSN();
            kjr();
        }

        private void kjr()
        {
            Proficy.CIMPLICITY.CimServer.CimSystem oSystem = new Proficy.CIMPLICITY.CimServer.CimSystem();
            Proficy.CIMPLICITY.CimServer.CimProductList oProducts;
            int iCount;
            string s;
            oProducts = oSystem.InstalledProducts;
            iCount = oProducts.Count;
            foreach (CimProduct p in oProducts)
                s = p.ProductID;


        }

        private void CreateProject()
        { 
            string d = CimpConfig.Settings.Path + CimpConfig.Settings.Project;
            if(Directory.Exists(d))
                Directory.Delete(d , true);

            _Project.NewProject(CimpConfig.Settings.Path, CimpConfig.Settings.Project, CimpConfig.Settings.User, CimpConfig.Settings.Password);
        }

        private void AddParams()
        {
            foreach (CimpParam p in CimpConfig.Settings.GlobalParams)
            {
                CimGlobalParm g = _Project.GlobalParms.New(p.ID);
                g.Value = p.Value;
                _Project.GlobalParms.Save(g, 0);
            }
        }

        private void AddClasses()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            foreach (CimpClass c in CimpConfig.Settings.Classes)
            {
                _Project.ClassImport($"{path}CimpFiles\\Classes\\{c.Id}.soc");
            }
        }

        private void SetUpDSN()
        {
            _Project.Database.AlarmLoggingStoreForward = -1;
            _Project.Database.AlarmLoggingSource = CimpConfig.Settings.Database.DSN;
            _Project.Database.AlarmLoggingUser = CimpConfig.Settings.Database.User;
            _Project.Database.AlarmLoggingPassword = CimpConfig.Settings.Database.Password;

            _Project.Database.PointLoggingStoreForward = -1;
            _Project.Database.PointLoggingSource = CimpConfig.Settings.Database.DSN;
            _Project.Database.PointLoggingUser = CimpConfig.Settings.Database.User;
            _Project.Database.PointLoggingPassword = CimpConfig.Settings.Database.Password;

        }

        public void GetZones(string ClassId)
        {
            //string ClassId = 
            foreach (CimObjectInstance o in _Project.Objects)
            {
                if (o.ClassID == ClassId)
                {
                    string plc = o.Attributes["PLC"].Value;
                    int ms = int.Parse(o.Attributes["MS"].Value.Substring(2, 2));
                    string MS = o.Attributes["AL"].Value;
                    int seq = int.Parse(o.Attributes["SEQ"].Value);
                    string desc = o.Attributes["$DESCRIPTION"].Value;
                    string device = o.Attributes["$DEVICE_ID"].Value;
                    string zone = o.Attributes["$RESOURCE_ID"].Value;

                    //Plc p = AddPLC(plc, device);

                    //Sequence s = AddSequence(p, seq, zone, ms, desc);
                    //NewSeq?.Invoke(p, s);

                }
            }
        }

        public void Add(Robot r)
        {
            if (!_Robots.ContainsKey(r.ID))
            {
                _Robots.Add(r.ID, r);
                NewRobot?.Invoke(r);
            }
        }

        public void Add(Sequence s)
        {
            if (!_Sequences.ContainsKey(s.ID))
            {
                _Sequences.Add(s.ID, s);
                NewSequence?.Invoke(s);
            }
        }

        public void Add(TrimStation t)
        {
            if (!_TrimStations.ContainsKey(t.ID))
            {
                _TrimStations.Add(t.ID, t);
                NewTrimStation?.Invoke(t);
            }
        }

        public void Delete(Robot r)
        {
            if (_Robots.ContainsKey(r.ID))
                _Robots.Remove(r.ID);

        }

        public void Delete(Sequence s)
        {
            if (_Sequences.ContainsKey(s.ID))
                _Sequences.Remove(s.ID);

        }

        public void Delete(TrimStation t)
        {
            if (_TrimStations.ContainsKey(t.ID))
                _TrimStations.Remove(t.ID);

        }

        public IEnumerable Stations()
        {
            foreach (KeyValuePair<string, TrimStation> t in _TrimStations)
                yield return t.Value;

            foreach (KeyValuePair<string, Robot> r in _Robots)
                yield return r.Value;
        }

        public IEnumerable Sequnces()
        {
            foreach (KeyValuePair<string, Sequence> s in _Sequences)
                yield return s.Value;

        }

        public IEnumerable Robots()
        {
            foreach (KeyValuePair<string, Robot> r in _Robots)
                yield return r.Value;

        }

        public IEnumerable TrimStations()
        {
            foreach (KeyValuePair<string, TrimStation> t in _TrimStations)
                yield return t.Value;

        }

        public Sequence Sequnces(string id)
        {
            if (_Sequences.ContainsKey(id))
                return _Sequences[id];
            else
                return null;

        }

        public Robot Robots(string id)
        {
            if (_Robots.ContainsKey(id))
                return _Robots[id];
            else
                return null;

        }

        public TrimStation TrimStations(string id)
        {
            if (_TrimStations.ContainsKey(id))
                return _TrimStations[id];
            else
                return null;

        }

    }
}

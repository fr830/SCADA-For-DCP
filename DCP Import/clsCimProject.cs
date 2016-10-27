using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    class CimProject
    {
        internal delegate void SequenceHandler(Sequence s);
        internal event SequenceHandler NewSequence;

        internal delegate void RobotHandler(Robot r);
        internal event RobotHandler NewRobot;

        internal delegate void TrimStationHandler(TrimStation t);
        internal event TrimStationHandler NewTrimStation;

        private Dictionary<string, Sequence> _Sequences = new Dictionary<string, Sequence>();
        private Dictionary<string, Robot> _Robots = new Dictionary<string, Robot>();
        private Dictionary<string, TrimStation> _TrimStations = new Dictionary<string, TrimStation>();

        internal CimProject()
        {


        }

        internal void Add(Robot r)
        {
            if (!_Robots.ContainsKey(r.ID))
            {
                _Robots.Add(r.ID, r);
                NewRobot?.Invoke(r);
            }
        }

        internal void Add(Sequence s)
        {
            if (!_Sequences.ContainsKey(s.ID))
            {
                _Sequences.Add(s.ID, s);
                NewSequence?.Invoke(s);
            }
        }

        internal void Add(TrimStation t)
        {
            if (!_TrimStations.ContainsKey(t.ID))
            {
                _TrimStations.Add(t.ID, t);
                NewTrimStation?.Invoke(t);
            }
        }

        internal void Delete(Robot r)
        {
            if (_Robots.ContainsKey(r.ID))
                _Robots.Remove(r.ID);

        }

        internal void Delete(Sequence s)
        {
            if (_Sequences.ContainsKey(s.ID))
                _Sequences.Remove(s.ID);

        }

        internal void Delete(TrimStation t)
        {
            if (_TrimStations.ContainsKey(t.ID))
                _TrimStations.Remove(t.ID);

        }

        internal IEnumerable Stations()
        {
            foreach (KeyValuePair<string, TrimStation> t in _TrimStations)
                yield return t.Value;

            foreach (KeyValuePair<string, Robot> r in _Robots)
                yield return r.Value;
        }

        internal IEnumerable Sequnces()
        {
            foreach (KeyValuePair<string, Sequence> s in _Sequences)
                yield return s.Value;

        }

        internal IEnumerable Robots()
        {
            foreach (KeyValuePair<string, Robot> r in _Robots)
                yield return r.Value;

        }

        internal IEnumerable TrimStations()
        {
            foreach (KeyValuePair<string, TrimStation> t in _TrimStations)
                yield return t.Value;

        }

        internal Sequence Sequnces(string id)
        {
            if (_Sequences.ContainsKey(id))
                return _Sequences[id];
            else
                return null;

        }

        internal Robot Robots(string id)
        {
            if (_Robots.ContainsKey(id))
                return _Robots[id];
            else
                return null;

        }

        internal TrimStation TrimStations(string id)
        {
            if (_TrimStations.ContainsKey(id))
                return _TrimStations[id];
            else
                return null;

        }

    }
}

using System.Configuration;

namespace JLR.CFM.DCP.Import
{
    public class CimpParam : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string ID { get { return (string)base["id"]; } }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value { get { return (string)base["value"]; } }
    }

    public class CimpParams : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CimpParam();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as CimpParam).ID;
        }

        public CimpParam this[int index]
        {
            get { return (CimpParam)base.BaseGet(index); }
            //set
            //{
            //    if (base.BaseGet(index) != null)
            //    {
            //        base.BaseRemoveAt(index);
            //    }
            //    base.BaseAdd(index, value);
            //}
        }

        public new CimpParam this[string id]
        {
            get { return (CimpParam)base.BaseGet(id); }
        }
    }

}

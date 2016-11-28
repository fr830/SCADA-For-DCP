using System.Configuration;

namespace JLR.CFM.DCP.Import
{
    public class CimpClass : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id { get { return (string)base["id"]; } }

        [ConfigurationProperty("plctag", IsRequired = true)]
        public string PlcTag { get { return (string)base["plctag"]; } }

        [ConfigurationProperty("attributes")]
        public ClassAttributes Attributes { get { return (ClassAttributes)base["attributes"]; } }
    }

    public class CimpClasses : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        { get { return ConfigurationElementCollectionType.BasicMap; } }

        protected override string ElementName
        { get { return "class"; } }

        protected override ConfigurationElement CreateNewElement()
        { return new CimpClass(); }

        protected override object GetElementKey(ConfigurationElement element)
        { return (element as CimpClass).Id; }

        public CimpClass this[int index]
        {
            get { return (CimpClass)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        public new CimpClass this[string title]
        { get { return (CimpClass)base.BaseGet(title); } }
    }


}
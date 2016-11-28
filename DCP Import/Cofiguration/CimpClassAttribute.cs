using System.Configuration;

namespace JLR.CFM.DCP.Import
{
    public class ClassAttribute : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string ID { get { return (string)base["id"]; } }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value { get { return (string)base["value"]; } }
    }

    public class ClassAttributes : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ClassAttribute();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ClassAttribute).ID;
        }

        public ClassAttribute this[int index]
        {
            get { return (ClassAttribute)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        public new ClassAttribute this[string id]
        {
            get { return (ClassAttribute)base.BaseGet(id); }
        }
    }
}

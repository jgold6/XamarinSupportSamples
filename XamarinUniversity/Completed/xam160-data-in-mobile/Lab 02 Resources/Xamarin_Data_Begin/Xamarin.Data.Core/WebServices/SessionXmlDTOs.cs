using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Xamarin.Data.Core.WebServices
{
    /*
        <?xml version="1.0" encoding="UTF-8"?>
        <events>
            <event>
                <event_key>4</event_key>
                <active>Y</active>
                <title>Training Keynote/Introduction to Mobile Development</title>
                <event_start>2013-04-14 09:00</event_start>
                <event_end>2013-04-14 10:00</event_end>
                <description>Welcome to Xamarin Evolve Training Days and Introduction to Mobile Development</description>
                <venue>Dawkins Salon (4th Floor)</venue>
                <speakers>
                    <person>
                        <name>Nat Friedman</name>
                        <bio></bio>
                    </person>
                    <person>
                        <name>Bryan Costanich</name>
                        <bio></bio>
                    </person>
                </speakers>
                <tags>Fundamentals</tags>
            </event>
        </events>
    */


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class events
    {
        /// <remarks/>
        [XmlElement("event")]
        public eventsEvent[] @event { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eventsEvent
    {
        /// <remarks/>
        public byte event_key { get; set; }

        /// <remarks/>
        public string active { get; set; }

        /// <remarks/>
        public string title { get; set; }

        /// <remarks/>
        public string event_start { get; set; }

        /// <remarks/>
        public string event_end { get; set; }

        /// <remarks/>
        public string description { get; set; }

        /// <remarks/>
        public string venue { get; set; }

        /// <remarks/>
        [XmlArrayItem("person", IsNullable = false)]
        public eventsEventPerson[] speakers { get; set; }

        /// <remarks/>
        public string tags { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eventsEventPerson
    {
        /// <remarks/>
        public string name { get; set; }

        /// <remarks/>
        public object bio { get; set; }
    }


}


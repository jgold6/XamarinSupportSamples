using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Data.Core.Model;

namespace Xamarin.Data.Core.WebServices
{
    public static class SessionsXmlParser
    {
        /// <summary>
        /// Example of parsing a XML data file into 
        /// </summary>
        /// <returns>The sessions.</returns>
        public async static Task<List<Session>> GetSessionsAsync(Stream stream)
        {
            var sessions = new List<Session>();
            await Task.Run(() =>
            {
                // Deserialize XML into DTO that matches the transport XML format (since we don't have control over it)
                var serializer = new XmlSerializer(typeof(events));
                var events = serializer.Deserialize(stream) as events;

				if (events != null)
                {

                    foreach (var evnt in events.@event)
                    {
                        var session = new Session()
                        {
                            Id = Convert.ToInt32(evnt.event_key),
                            Title = evnt.title,
                            Location = evnt.venue,
                            Abstract = evnt.description,
                            Begins = DateTime.Parse(evnt.event_start),
                            Ends = DateTime.Parse(evnt.event_end),
                        };

                        if (evnt.speakers != null)
                        {
                            // which happens for LUNCH and TBA sessions without a Speaker
                            foreach (var sp in evnt.speakers)
                            {
                                if (!String.IsNullOrWhiteSpace(sp.name))
                                    session.Speaker = new Speaker() { Name = sp.name }; // hacky: replaces speaker if more than one
                            }
                        }
                        sessions.Add(session);
                    }
                }
            }).ConfigureAwait(false);

            return sessions;
        }

    }
}
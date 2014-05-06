﻿namespace CodeFormatting
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private readonly MultiDictionary<string, EventCreator> eventsByTitle = new MultiDictionary<string, EventCreator>(true);
        private readonly OrderedBag<EventCreator> eventsByDate = new OrderedBag<EventCreator>();

        public void AddEvent(DateTime date, string title, string location)
        {
            EventCreator newEvent = new EventCreator(date, title, location);
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.eventsByTitle[title])
            {
                removed++;
                this.eventsByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(title);

            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<EventCreator>.View eventsToShow = this.eventsByDate.RangeFrom(new EventCreator(date, ", ", "tam"), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);

                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}

# PeopleEvents
<b>People and Event demo</b>

Display People and their associated Events.

<hr>

<b>Assumptions</b>

- Each event can only be matched to one person (though with the linking table, we could have a many-to-many relationship)
- Modifying a person's date of birth does not imply they lose any previously linked events, nor are any existing events that match the new details attached (though this would obviously require discussion on what the exact requirements are - in any case, date of birth changes could well be something that was not required)

<hr>

<b>Design Notes</b>

- Whilst the data sources would be presumably from different places, say from external APIs - we'd still want to store them locally in a database (from the spec: "<i>...as the Event's database is updated...</i>")
- This led to the data model of having People and Events separately, with a table linking the two
- This would also give flexibility in a real life scenario, allowing the clinicians to unlink an event (as if there's no strong link, we may get false positives), or even potentially link them (by giving them an unlinked event page or something similar)
- My thought would be that in a real life scenario, we'd probably have separate services to poll the APIs and import the data to the local databases, and these services would handle the reconciliation of the data

<hr>

<b>Project Set-up / Running Notes</b>

- Written in ASP.NET MVC (IDE: Visual Studio 2019)
- Additional nuget packages added were for EntityFramework, jQuery UI Datepicker and Moq for unit testing
- Should be able to compile and run straight away (assuming automatic nuget package download)
- Additional Event API was added to simulate Event data entering the system to demonstrate the auto-refresh of the events. Simply need to make the GET call (e.g. go to https://localhost:44373/api/Event in the web browser) to generate a random event (though you could also use POST to submit a custom event)
- Initial database values are initialized in the PEInitializer class. To reset the database on load, simply change the Interface used from System.Data.Entity.DropCreateDatabaseIfModelChanges to System.Data.Entity.DropCreateDatabaseAlways

<hr>

<b>Question / Answers:</b>

1. If I had more time I'd:
  a. A search system for the people (and possibly events)
  b. Implement a true real-time event refresh using SignalR or similar
  c. Add more detailed error logging / handling
  d. Improve the validations on the data
  e. Improve the look / feel of the GUI
  f. Complete the unit tests (only added one as a demonstration)
  g. Add proper services to simulate the extra data sources
2. I spent the most time getting things together in my head, trying to picture how everything would fit together (and deciding whether I should use the linking table vs. just displaying events from the data source separately). Technically, I probably took the longest doing the modal pop-up windows to add/edit people.
3. Suggestions to the clinicians:
  a. Main suggestion would be around the handling of events - i.e. the linking / unlinking that I mentioned above
  b. Would they want user logging - e.g. who viewed which records when, and which users linked / unlinked records

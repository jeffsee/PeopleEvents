# PeopleEvents
<b>People and Event demo</b>

Display People and their associated Events.

<hr>

<b>Assumptions</b>

- Each event can only be matched to one person (though with the linking table, we could have a many-to-many relationship)

<hr>

<b>Design Notes</b>

- Whilst the data sources would be presumably from different places, say from external APIs - we'd still want to store them locally in a database (from the spec: "<i>...as the Event's database is updated...</i>")
- This led to the data model of having People and Events separately, with a table linking the two
- This would also give flexibility in a real life scenario, allowing the clinicians to unlink an event (as if there's no strong link, we may get false positives), or even potentially link them (by giving them an unlinked event page or something similar)
- My thought would be that in a real life scenario, we'd probably have separate services to poll the APIs and import the data to the local databases, and these services would handle the reconciliation of the data

<hr>

<b>Project Set-up / Running Notes</b>

- Written in ASP.NET MVC (IDE: Visual Studio 2019)
- Only additional nuget package added was EntityFramework
- Should be able to compile and run straight away (assuming automatic nuget package download)
- Additional Event API was added to simulate Event data entering the system to demonstrate the auto-refresh of the events. Simply need to make the GET call (e.g. go to https://localhost:44373/api/Event in the web browser) to generate a random event (though you could also use POST to submit a custom event)

<hr>

<b>Question / Answers:</b>

1. If I had more time...
2. I spent the most time on...
3. Suggestions to the clinicians:

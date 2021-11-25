# PeopleEvents
<b>People and Event demo</b>

Here's some of my reasoning behind the design choices / assumptions I've made:
- Whilst the data sources would be presumably from different places, say from external APIs - we'd still want to store them locally in a database (from the spec: "...as the Event's database is updated...")
- Hence the data model of having People and Events separately, with a table linking the two
- This would also give flexibility in a real life scenario, allowing the clinicians to unlink an event (as if there's no strong link, we may get false positives), or even potentially link them (by giving them an unlinked event page or something similar)
- I've used EntityFramework as that seemed like a good way to set up the database with the least overhead and ease of use for running this project elsewhere
- My thought would be that in a real life scenario, I'd probably have separate services to poll the APIs and import the data to the local databases, and these services would do the reconciliation of the data. But planning on demonstrating this somehow within this project.

<b>Question / Answers:</b>
1. If I had more time...
2. I spent the most time on...
3. Suggestions to the clinicians:

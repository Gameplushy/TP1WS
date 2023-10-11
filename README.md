# Calendar API

## Methods

### Calendar.CreateCalendar(string monthAndYear)
This entry point will return an ASCII art version of the chosen month and year.

monthAndYear: The awaitted format is MM/YYYY. The year must be positive and land in the int range (it doesn't have to be 4 digits long).

Example :
```cs
TP1WS.Calendar.CreateCalendar("01/5"); returns the following:

┌────────────────────┐
│     January 5      │
├──┬──┬──┬──┬──┬──┬──┤
│Su|Mo|Tu|We|Th|Fr|Sa│
├──┼──┼──┼──┼──┼──┼──┤
│--│--│--│--│--│--│01|
├──┼──┼──┼──┼──┼──┼──┤
│02│03│04│05│06│07│08|
├──┼──┼──┼──┼──┼──┼──┤
│09│10│11│12│13│14│15|
├──┼──┼──┼──┼──┼──┼──┤
│16│17│18│19│20│21│22|
├──┼──┼──┼──┼──┼──┼──┤
│23│24│25│26│27│28│29|
├──┼──┼──┼──┼──┼──┼──┤
│30│31│--│--│--│--│--|
└──┴──┴──┴──┴──┴──┴──┘
```

### Calendar.CreateCalendarWithSpecialDates(string monthAndYear, List\<string\> specialDates)
This entry point will return an ASCII art version of the chosen month and year, while highlighting special events occuring during this month.

monthAndYear: The awaitted format is MM/YYYY. The year must be positive and land in the int range (it doesn't have to be 4 digits long).

specialDates: The awaitted format is DD/MM/YYYY. The year must be positive and land in the int range (it doesn't have to be 4 digits long).

Example :
```cs
Calendar.CreateCalendarWithSpecialDates("01/5", new List<string>() { "08/01/2002", "01/01/5", "10/01/0005"}); returns the following:

┌──────────────────────────────────┐
│            January 5             │
├────┬────┬────┬────┬────┬────┬────┤
│ Su │ Mo │ Tu │ We │ Th │ Fr │ Sa │
├────┼────┼────┼────┼────┼────┼────┤
│ -- │ -- │ -- │ -- │ -- │ -- │ 01 │
├────┼────┼────┼────┼────┼────┼────┤
│ 02 │ 03 │ 04 │ 05 │ 06 │ 07 │ 08 │
├────┼────┼────┼────┼────┼────┼────┤
│ 09 │!10!│ 11 │ 12 │ 13 │ 14 │ 15 │
├────┼────┼────┼────┼────┼────┼────┤
│ 16 │ 17 │ 18 │ 19 │ 20 │ 21 │ 22 │
├────┼────┼────┼────┼────┼────┼────┤
│ 23 │ 24 │ 25 │ 26 │ 27 │ 28 │ 29 │
├────┼────┼────┼────┼────┼────┼────┤
│ 30 │ 31 │ -- │ -- │ -- │ -- │ -- │
└────┴────┴────┴────┴────┴────┴────┘
```




## How to install

Build the project TP1WS. This will create a dll in the bin of the project. Copy-paste it to your project's bin folder and reference it in order to use it.


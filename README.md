# Calendar API

This API will return an ASCII art version of the chosen month and year.

Example :
```
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

## How to use

Use the Calendar class, and the CreateCalendar method. The awaitted format is MM/YYYY. The year must be positive and land in the int range (it doesn't have to be 4 digits long).

Example : `TP1WS.Calendar.CreateCalendar("01/5");` 

## How to install

Build the project TP1WS. This will create a dll in the bin of the project. Copy-paste it to your project's bin folder and reference it in order to use it.


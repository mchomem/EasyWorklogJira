# Easy Worklog Jira

 This project arose from the need for a more practical system for recording task hours, including all the necessary information, making it easier to track timekeeping.

## Features

System resources:

| Item | Description | Available? |
| :--- | :----       | :---:      |
| 1    | Querying tasks recorded by the user | Yes   |
| 2    | Querying tasks from the previous day based on the daily meeting period. Depending on the time a daily meeting occurs, the user can configure the system to automatically, when opening the activity query, query the previous day's tasks within the daily period | Yes   |
| 3    | Insertion of activity log           | Yes   |
| 4    | Edition of activity log             | Yes   |
| 5    | Details of activity                 | Yes   |
| 6    | Delete activity log                 | Yes   |
| 7    | Configuration form of the application | Yes   |

> **Observation**: the system was built using the old but functional .NET Windows Forms technology.
Once all features are complete, a [WFP](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/) (Windows Presentation Foundation) version will be implemented to utilize modern features.

## Main menu of system (windows forms version)

![Main menu](Docs/Images/main-menu-with-forms.png)
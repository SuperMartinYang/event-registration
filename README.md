# Event Registration Dashboard

## Requirements 
* CRUD events
* Record operation (logs)
* Login
* CRUD email
* CRUD form
* CRUD participants
* waitlist auto register
* add extra participants
* download lists 

## Models
* events
    * id (int)
    * form_id (int)
    * user_id (int)
    * title (varchar)
    * description (text)
    * category (varchar)
    * start_time (timestamp)
    * end_time (timestamp)
    * seat (int)

* forms
    * id (int)
    * title (varchar)
    * fields_json (json)
    * create_time (timestamp)
* participants
    * id (int)
    * event_id (int)
    * answers (json)
    * priority (int)
* emails
    * id (int)
    * title (varchar)
    * content (text)
* users
    * id (int)
    * username (varchar)
    * password (varchar)
    * email (varchar)
    * phone_no (varchar)
* histories
    * id (int)
    * event_id (int)
    * operator (varchar)
    * action_time (timestamp)
    * action (varchar)
## Design Front-end
photos of front end
* Layout (header and footer):


* Home (Login):


* Create Event (dashboard, with adding fields):


* View My Event (Calender like, support search):

    * Edit Event Participants (view the answers, can delete)
    * View Histories (list of histories toward this event):

* Create Email (several fix fields):

* View Announcements (list of announcements)



## Design APIs
* EventsAPIController
* ParticipantsAPIController
* EmailsAPIController
* UsersAPIController
* FormsAPIController

## Testing
* test all apis with test framework

## Deploy
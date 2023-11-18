# CpPartOne

This repo contains files for C# Cumulative one assignment.

---

### Sumarry
- C# .net project which has basic Read functionality from mysql database.
- Display list of teachers also user can clicks on teacher's name to see more info about teacher.
- Shows classes of teachers when user clicks on teacher's name.
- Display list of student also user can clicks on student's name to see more info about teacher.
- Search functionality
  - User cans search for studnet by name, student number or enrol date.
- Added CSS for better look.

---

## Home page

Home displays two clickable container of students and teacher which navigate to specific list page.

### Views
 `Views -> Home -> Index.cshtml`

---

## Teachers Controller

This controller handles another DataController (TeacherDataController)

TeacherDataController contains method which return object of teacher model to teacher controller and controller binds that it with views.

### `GET: Teacher/list`

Displays list of teacher from database

It utilize ListTeacher method from TeacherDataController via api

`Route("api/teachersdata/listteachers")`

### `GET: Teacher/show`


Displays teachers info from database based on user click

It utilize ShowTeacher(id) method from TeacherDataController via api

`Route("api/teachersdata/listteachers/findteacher/{id}")`


---

## Student Controller

This controller handles another DataController (StudentDataController)

StudentDataController contains method which return object of student model to student controller and controller binds that it with views.

### `GET Student/list`

Displays list of student from database

It utilize ListStudent method from StudentDataController via api

`Route("api/StudentData/ListStudent")`

### `GET Student/show/{id}`

Displays student info from database based on user click

It utilize ShowTeacher(id) method from TeacherDataController via api

`Route("api/studentdata/showstudent/{id}")`


### `GET Student/list/searchInput`

Displays student info from database based on user search

It utilize SearchStudent(string searchInput) method from TeacherDataController via api

`Route("api/studentdata/showstudent/{id}")`



---

### Future Funtionality
- Different kind of search (by salary rane, by hire date)
- Better UI
- Classes Read Functionality

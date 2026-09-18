# 🔋 SocialCharge

SocialCharge is a web application designed to help users track how their daily social activities affect their energy, enjoyment, and social battery.

The application allows users to record activities, compare their energy levels before and after each activity, and review their activity patterns through a dashboard.

This project was developed as a portfolio project using **ASP.NET Core MVC, C#, Entity Framework Core, and Bootstrap**.

---

## ✨ Features

- User registration and login
- Create, view, edit, and delete social activity records
- Track energy levels before and after each activity
- Track enjoyment scores
- Record the number of people involved in each activity
- Add personal notes to activity records
- Categorize activities such as:
  - Work
  - Study
  - Exercise
  - Friends
  - Family
  - Other activities
- Dashboard for viewing activity statistics
- Automatic energy status calculation
- Responsive user interface using Bootstrap
- User-specific data access through authentication

---

## 🧠 Project Concept

Different activities can affect a person's social energy in different ways.

Some activities may make a user feel more energized, while others may leave them feeling drained.

SocialCharge helps users record these experiences and better understand how different social activities affect their energy.

The core calculation used by the application is:

```text
Energy Change = Energy After - Energy Before
```

The result is used to classify the activity into an energy status.

```text
Positive Energy Change  → Charged
No Energy Change        → Neutral
Negative Energy Change  → Drained
```

This makes it easier for users to recognize which activities tend to recharge or drain their social battery.

---

## 🛠️ Tech Stack

### Backend / Framework

- ASP.NET Core MVC
- C#

### Database / Data Access

- Entity Framework Core

### Frontend

- HTML
- CSS
- Bootstrap
- Razor Views

### Authentication

- ASP.NET Core Authentication

### Development Tools

- Visual Studio
- Git
- GitHub

---

## 🏗️ Application Architecture

SocialCharge follows the **Model-View-Controller (MVC)** architecture.

```text
User
  |
  v
View
  |
  v
Controller
  |
  v
Model
  |
  v
Entity Framework Core
  |
  v
Database
```

### Model

The Model represents application data such as social activities, categories, energy levels, enjoyment scores, and other activity information.

### View

The View displays the user interface using Razor Views and Bootstrap.

### Controller

The Controller handles user requests, application logic, and communication between the Model and View.

### Entity Framework Core

Entity Framework Core is used to manage application data and communicate with the database.

---

## ⚙️ How It Works

1. The user registers an account or logs in.
2. The user creates a new social activity record.
3. The user selects an activity category.
4. The user records their energy level before the activity.
5. The user records their energy level after the activity.
6. The user can also record:
   - Enjoyment score
   - Number of people involved
   - Personal notes
7. SocialCharge calculates the energy change.

```text
Energy Change = Energy After - Energy Before
```

8. The application determines whether the activity was:

```text
Charged
Neutral
Drained
```

9. The activity is stored and displayed in the user's activity history.
10. The dashboard summarizes activity information and statistics for the user.

---

## 📊 Activity Tracking

Each social activity can contain information such as:

- Activity name
- Activity category
- Energy before
- Energy after
- Energy change
- Enjoyment score
- Number of people involved
- Personal notes

This information allows users to compare different activities and understand how they affect their social energy.

---

## 📈 Dashboard

The dashboard provides users with a summary of their recorded activities.

It helps users review their activity data and understand patterns in their social battery over time.

The dashboard is designed to make activity information easier to understand without requiring users to manually compare every record.

---

## 🔐 User Authentication

SocialCharge includes user authentication so that each user can access and manage their own activity records.

Users can:

- Register an account
- Log in
- Access their own activity data
- Create new records
- Edit existing records
- Delete records
- View their activity history

User-specific data access helps keep each user's activity information separated from other accounts.

---

## 📱 Responsive Design

The user interface is built with Bootstrap to support responsive layouts.

The application is designed to remain usable across different screen sizes, including desktop and mobile displays.

---

## 📸 Screenshots

### Home Page

![SocialCharge Home](screenshot/SocialCharge%20Home.png)

### Activity List

![SocialCharge Activities](screenshot/SocialCharge%20Activities.png)

### Create Activity

![SocialCharge Create](screenshot/SocialCharge%20Create.png)

---

## 🎯 Project Purpose

SocialCharge was developed as a portfolio project to practice full-stack web application development using the ASP.NET Core ecosystem.

The project demonstrates the integration of:

- ASP.NET Core MVC
- C# programming
- MVC architecture
- CRUD operations
- Entity Framework Core
- User authentication
- Database management
- Responsive web design
- Frontend and backend integration
- Data-driven application logic

The project also explores how software can transform simple user-entered data into useful information through calculations, categorization, and dashboard summaries.

---

## 📚 What I Learned

Through this project, I gained practical experience with:

- Building web applications using ASP.NET Core MVC
- Programming application logic with C#
- Working with the MVC architecture
- Implementing CRUD operations
- Managing application data with Entity Framework Core
- Implementing user authentication
- Restricting data access based on the authenticated user
- Building responsive interfaces with Bootstrap
- Creating dashboard-style interfaces
- Integrating frontend, backend, and database components
- Using Git and GitHub for source code management

---

## 💡 Why SocialCharge?

Most activity tracking applications focus on productivity, time, or physical activity.

SocialCharge approaches activity tracking from a different perspective by focusing on how activities affect a user's personal energy.

Instead of only asking:

> "What did I do today?"

SocialCharge also helps users consider:

> "How did this activity affect my energy?"

The goal is to provide a simple way for users to observe patterns in the activities that make them feel **Charged, Neutral, or Drained**.

---

## 👨‍💻 Developer

**Weeratat Kwandee**  
Information Technology Student  
University of the Thai Chamber of Commerce (UTCC)

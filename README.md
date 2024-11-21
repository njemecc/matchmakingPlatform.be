# Matchmaking API (Backend)

The Matchmaking API is a backend web service designed to manage players, teams, and matches for a matchmaking system. It provides RESTful endpoints to handle player statistics, team management, and match results, including ELO rating calculations and gameplay statistics.

---

## **Technologies Used**

- **.NET 8**: Modern framework for building robust web applications.
- **Entity Framework Core**: Used with an InMemory database for quick development and testing.
- **Repository Pattern**: Clean separation of data access logic from business logic.
- **Swagger**: Automatically generates API documentation and testing interface.

---

## **System Requirements**

To build and run the application, you need the following:

- **.NET SDK 8.0** or later.
- A code editor like Visual Studio 2022, JetBrains Rider, or Visual Studio Code.
- **Postman** or any API testing tool (optional, for testing the endpoints).

---

## **How to Set Up and Run**

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/njemecc/matchmakingPlatform.be
   cd matchmaking.be
   ```
2. **Install Dependencies: Restore all required .NET dependencies:**

   ```bash
   dotnet restore
   ```

3. **Build and Run application**

   ```bash
   dotnet build dotnet run
   ```


## Features

- **Player Management**: 
  Manage players with the ability to add new players, retrieve player details, and track individual statistics such as:
  - ELO rating.
  - Total wins and losses.
  - Total hours played.

- **Team Management**: 
  Create and manage teams with built-in validation, ensuring:
  - Each team has exactly five players.
  - Team names are unique.
  - Players cannot belong to multiple teams.

- **Match Management**: 
  Add match results between two teams, supporting:
  - Win, loss, or draw scenarios.
  - Automatic updates to player statistics based on match outcomes.
  - Validation for match duration and team existence.

- **Dynamic ELO Calculation**: 
  Automatically calculate and update player ELO ratings using the official ELO formula. The system adjusts:
  - Player ratings based on match results (win, loss, or draw).
  - ELO rating progression using a dynamic `K-factor` determined by total hours played.




   

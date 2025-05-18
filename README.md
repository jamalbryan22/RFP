# RFP Application

A full-stack Request For Proposal (RFP) management application built with ASP.NET Core for the backend and React (TypeScript) for the frontend. This application allows users to post service requests, submit proposals, and manage project interactions seamlessly.

## 🚀 Technologies Used

### Frontend:

React (TypeScript)

Axios for HTTP requests

Vite as the build tool

CSS for styling

### Backend:

ASP.NET Core Web API

Entity Framework Core (EF Core)

SQLite Database

JWT-based authentication

### DevOps:

GitHub Codespaces for cloud-based development

Azure + Docker (planned for deployment)

✅ Features Implemented

User Authentication with JWT

Post service requests

Submit proposals to service requests

Dashboard view with stats and recent activity

Protected routes with React Router

API calls with Axios interceptor for JWT authorization

## 🚀 Getting Started

### Prerequisites:

Node.js (>= 16)

.NET 7.0 SDK

### Installation:

### Clone the repository
git clone <repository-url>

### Navigate to the frontend
cd RFP_App.Client

### Install dependencies
npm install

### Navigate to the backend
cd ../RFP_App.Server

### Install dependencies
dotnet restore

## Running the Application:

### Navigate to the backend
cd ../RFP_App.Server
dotnet build 
dotnet run (will launch both front and backend)  

## 🔄 API Endpoints

POST /applicationuser/login - User login

POST /servicerequest/ - Create a new service request

GET /dashboard/stats - Fetch dashboard statistics

## 👥 Contributing

Fork the repository.

Create a new feature branch (git checkout -b feature/my-feature).

Commit your changes (git commit -m 'Add new feature').

Push to the branch (git push origin feature/my-feature).

Open a Pull Request.

## 🔍 License

MIT License. See LICENSE for more information.

## 📞 Contact

Author: Jamal Bryan

Email: JamalBryan1@gmail.com

LinkedIn: https://www.linkedin.com/in/jamal-bryan/

Feel free to reach out if you have any questions or suggestions!

## Background
#### I was contacted by my insurance who told me that I needed to replace my roof in the next 12 months or I would get dropped from my homeowners insurance.
#### I started the process of soliciting quotes from roofing companies. I got about two in, and realized how inefficient and time-consuming the process was.
#### Searching companies in my area (there are a lot of them), getting in contact with them, providing my information. Then having to wait for someone to come out, physically look at the house, and finally
#### get a quote. Who has time for this? How do I make sure I get the best deal without speaking to almost every company in a 300-mile radius (maybe even more)?
#### I work a lot, and have a family to take care of that also demands time and attention. There has to be a more efficient way to do this.
#### Why can't I just throw the fact that I need a roof out to the universe and let the interested companies contact me with their best price, timeframes,
#### constraints, etc.? Maybe a company is doing a job in my area already and could cut me a nice deal if I go with them.
#### Why don't / can't we as individuals operate like companies and governments when it comes to getting work done by requesting proposals?
#### This leads us to the RFP (Request for Proposal) repo containing a frontend React-TypeScript and backend ASP.NET web application.

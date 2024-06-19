# Job Candidate Hub API

This project is a web application developed using the .NET stack that provides a REST API for storing, updating and deleting job candidate information. The application is designed with scalability in mind to handle large volumes of candidate data in the future.

## Features

- **REST API Endpoint**: Create or update, delete and get an candidate information.
- **N-Tier Architecture**: Ensures separation of concerns and scalability.
- **Repository Pattern**: Abstracts data access logic for easier maintenance and potential future database migrations.
- **Result Wrapper Pattern**: Standardizes API responses for consistency.
- **Auto-Migration**: Automatically applies database migrations on startup.
- **Unit Tests**: Ensures code reliability and quality.

## API Endpoint

The application provides one API endpoint for adding or updating, deleting and listing candidate information. The candidate's email is used as the unique identifier. If the candidate exists, their information is updated; otherwise, a new candidate record is created.

## Guidelines

Change the **ConnectionString** in **appsettings.json** according to your database setup.

## Prerequisites

- **.NET SDK 8.0 or later**
- **SQL Server (or another compatible SQL database)**



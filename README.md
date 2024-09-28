# Cafe Point of Sale

## Overview

The **Cafe Point of Sale** (POS) system is designed to manage orders, track sales, and facilitate payment processing for a cafe. This application is built with scalability in mind, allowing for future expansion into tablet and web applications by reusing the core application and data layers. The system is intended for use in terminal view by cafe staff, with plans for future UI development.

## Architecture

### Pattern (n-Tier-architecture)

- __UI__: Provides a CLI for the cafe point of sale system. Contains Utilities for display, input, and menu helpers, as well as Workflows for orders and reports.
- __Application__: Contains Services (OrderService and ReportService) and a ServiceFactory, suggesting it handles the business logic and orchestration of operations.
- __Core__: Defines the domain models, including:
  * Entities: DTOs (CurrentItem, DailySalesSummary, ItemSummary, Result)
  * Enums: DatabaseMode
  * Tables: Various domain objects like CafeOrder, Category, Item, etc.
  * Interfaces: For AppConfiguration, Repositories, and Services
- __Data__: Manages data persistence through repositories (CafeRepository and TimeOfDayRepository) and includes a CafeContext, likely for database operations.
- __UnitTests__: Contains mock repositories and test classes to ensure the correctness of the system's components.

## Technology Stack

### Programming Languages
- C#

### Frameworks & Libraries
- ASP.NET Core
- Entity Framework (or any data access framework of choice)
- LINQ (for data querying)

### Tools
- Visual Studio
- Docker (for containerization)
- Azure Data Studio (for database management)

## Features

### Current Functionalities

- **Order Management**: 
  - Create new orders with active server validation
  - Add items to existing orders with real-time price updates
  - View open orders
  - Process payments and close orders
  - Cancel open orders that have not been paid.
- **Sales Reporting**: Generate and view daily sales reports by category for a specific date.

### Future Features to Add

- **UI Expansion**: Develop tablet and web interfaces that reuse the existing application and data layers.
- **Advanced Reporting**: Add more detailed reporting features, such as filtering by server or item.
- **Integration with Payment Systems**: Implement integration with real payment processing systems.

## Video Demonstration

### Order Workflow 

https://github.com/user-attachments/assets/d843545e-929e-4f1a-beec-98140a0a6ec7

### Report Workflow (Monthly Report to be implemented)

https://github.com/user-attachments/assets/5290c306-a8c5-4027-9033-e65411f1c1e1

## What I learned

- **N-Tier Architecture**: Separating concerns goes a long way. Planning is worth the time it takes to do because lack of planning leads to technical debt, which then makes refractoring a hell. The trade-off is more time efforts now, and less headaches later. 

- **Interface Implementation**: Implementing interfaces between the layers made testing and refactoring easier for me. I understand now the value of loose coupling in software design. 

- **Mocking and Testing**: Creating a training mode using mock data was both challenging and educational. It pushed me to think critically about how to simulate different environments and how crucial testing is in catching potential issues early. This experience has made me more aware of the importance of testing in the development cycle and how it contributes to building reliable software.

- **Database Management**: Working with the database connection and performing CRUD operations was a great opportunity to strengthen my skills in data management. I gained a deeper understanding of how to efficiently interact with databases and the importance of clean, organized data access layers. This experience has given me more confidence in handling data-driven applications in future projects.


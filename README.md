# Cafe Point of Sale

## Project Overview

The **Cafe Point of Sale** (POS) system is designed to manage orders, track sales, and facilitate payment processing for a cafe. This application is built with scalability in mind, allowing for future expansion into tablet and web applications by reusing the core application and data layers. The system is intended for use in terminal view by cafe staff, with plans for future UI development.

### Project Type

This is a terminal-based point-of-sale application with a layered architecture that separates the presentation, business logic, and data access. The focus is on building a robust and extendable foundation that can evolve to meet the needs of various user interfaces.

### Product Use Cases

The POS system can be used by cafe staff to:
- Create and manage customer orders
- Add items to orders and process payments
- View and cancel open orders
- Generate sales reports by category and date

### Problem Solved

This system streamlines cafe operations by automating order processing, ensuring accurate billing, and providing detailed sales insights. It also lays the groundwork for a more comprehensive POS system that can integrate with various front-end interfaces in the future.

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

- **Main Menu**: Displays options for creating orders, adding items, processing payments, viewing open orders, canceling orders, and generating sales reports.
- **Order Management**: 
  - Create new orders with active server validation
  - Add items to existing orders with real-time price updates
  - Process payments and close orders
- **Sales Reporting**: Generate and view sales reports by category for a specific date.
- **Order Cancellation**: Cancel open orders that have not been paid.

### Future Enhancements

- **UI Expansion**: Develop tablet and web interfaces that reuse the existing application and data layers.
- **Advanced Reporting**: Add more detailed reporting features, such as filtering by server or item.
- **Integration with Payment Systems**: Implement integration with real payment processing systems.
- **Loyalty Program**: Add functionality for managing customer loyalty programs.

## Learning Outcomes

- **N-Tier Architecture**: Separating concerns goes a long way. Planning is worth the time it takes to do because lack of planning leads to technical debt, which then makes refractoring a hell. The trade-off is more time efforts now, and less headaches later. 

- **Interface Implementation**: Implementing interfaces between the layers made testing and refactoring easier for me. I understand now the value of loose coupling in software design. 

- **Mocking and Testing**: Creating a training mode using mock data was both challenging and educational. It pushed me to think critically about how to simulate different environments and how crucial testing is in catching potential issues early. This experience has made me more aware of the importance of testing in the development cycle and how it contributes to building reliable software.

- **Database Management**: Working with the database connection and performing CRUD operations was a great opportunity to strengthen my skills in data management. I gained a deeper understanding of how to efficiently interact with databases and the importance of clean, organized data access layers. This experience has given me more confidence in handling data-driven applications in future projects.


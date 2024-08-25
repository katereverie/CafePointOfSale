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

Working on this project provided insights into the following areas:

- **N-Tier Architecture**: Understanding the separation of concerns and how to build scalable applications.
- **Interface Implementation**: Using interfaces to ensure loose coupling and making the application easier to test an

# CRUD operation Web Application Using ASP.NET Core
## 📖 Overview

Welcome to the **CRUD Operation ASP.NET Core Application**! This web application is a comprehensive solution for managing products and their associated categories using the ASP.NET Core MVC framework. It allows users to perform seamless Create, Read, Update, and Delete operations on both products and categories.

### 🌟 Features

- **User-Friendly Interface**: A clean and intuitive UI for easy navigation.
- **Product Management**:
  - Add new products with details like name, price, quantity, and tags.
  - Edit existing product information.
  - Delete products from the database.
  - View all products in a structured list.
- **Category Management**:
  - Create and manage product categories.
  - Assign multiple categories to products, enabling better organization.
- **Responsive Design**: Optimized for both desktop and mobile devices, ensuring a smooth experience across platforms.
- **Data Validation**: Robust validation for product and category inputs, preventing errors and ensuring data integrity.

## 🚀 Technologies Used

- **Backend**:
  - ASP.NET Core 6.0
  - Entity Framework Core for database interactions
  - MySQL for data storage

- **Frontend**:
  - HTML5, CSS3 for dynamic web content
  - Bootstrap for responsive design

- **Development Tools**:
  - Visual Studio 2022 (or your preferred IDE)
  - Git and GitHub for version control

## 📦 Installation

### Prerequisites

Make sure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or any preferred IDE)

### Steps to Set Up and Run the Application

1. **Clone the Repository**:
   Open your terminal or Git Bash and run:
   ```bash
   git clone https://github.com/Aghashezi/CRUD-operation-Using-ASP.NET-Core-and-MySQL.git
   cd CRUD_Operation

2. Set Up the Database:
    -Create an database with any name
    -Update the Connection String:
        Open appsettings.json and modify the connection string to match your database credentials:
3. Add a Migration:
    -Add-Migration InitialCreate
            paste the command in the package manager console
4.update the database
    -update-databse
           paste the command in package manager console to update the database
🛠️ Usage
Managing Products:
Navigate to the Products tab to view, add, edit, or delete products.
Each product entry includes fields for the product name, price, quantity, and associated categories.
Managing Categories:
Visit the Categories section to create and manage product categories.
Assign categories to products to enhance organization and searchability




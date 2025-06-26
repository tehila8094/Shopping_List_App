# Shopping List Application

## Project Description

A modern shopping list application built with **React** and **TypeScript** on the client side and **C# .NET 8** on the server side. The application allows users to create and manage shopping lists efficiently and conveniently.

## Technologies

### Client Side
- **React 18** with **TypeScript**
- **Redux Toolkit** for state management
- **Bootstrap 5** for responsive design
- **React Hooks** for component state management

### Server Side
- **C# .NET 8**
- **Entity Framework Core** (ORM)
- **SQL Server** for data storage
- **ASP.NET Core Web API**

## Key Features

### User Interface
- **Add Products** - Free text field with category selection
- **Product Counter** - Display total items in cart
- **Quantity Management** - Add and organize identical products
- **Responsive Design** - Optimized for mobile and desktop
- **Category Organization** - Filter and organize products

### Advanced Functionality
- **Advanced State Management** with Redux Toolkit
- **Data Persistence** in SQL Server database
- **Secure API** for client-server communication


## Installation & Setup

### System Requirements
- **.NET 8 SDK**
- **SQL Server** (Local or Cloud)

### Client Side

```bash
# Clone the project
git clone https://github.com/YOUR_USERNAME/shopping-list-app.git
cd shopping-list-app

# Install dependencies
npm install

# Run the application in development mode
npm start
```

Application will run on: `http://localhost:3000`

### Server Side

# manually
Navigate to Shopping_list_server directory
open with vs 2022 the Shopping_list.sln file

# By command
``` bash
cd shopping-list-server

# Restore NuGet packages
dotnet restore

# Update database
dotnet ef database update

# Build the server
dotnet build

# Run the server
dotnet run
```
Server will run on: `https://localhost:5001`



## Advanced Features Developed

### Advanced State Management
- Using **Redux Toolkit** with **createAsyncThunk**
- Loading and error state management
- Efficient data caching

### Security
- **Data encryption** in transit
- **Server-side validation**
- **CORS protection**

### Performance
- **Lazy loading** of components
- **Database query optimization**
- **Intelligent caching**


## 📞 Contact

**Developer:** Tehila Edri  
**Email:** t0533188094@gmail.com  
**GitHub:** @tehila8094 (https://github.com/tehila8094)  


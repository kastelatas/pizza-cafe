# 🍕 Pizza Cafe

Welcome to the Pizza Cafe project! This web application is designed to help you manage a pizza cafe. It includes features for managing the menu, orders, and customers.

## 🚀 Features

- **Menu Management**: Add, edit, and delete menu items.
- **Order Processing**: Place and track orders.
- **Customer Management**: Manage customer information.
- **User Authentication**: Secure login and registration system.

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core
- **Frontend**: Blazor
- **Database**: Entity Framework Core
- **Styling**: CSS

## 📦 Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/kastelatas/pizza-cafe.git
    cd pizza-cafe
    ```

2. **Install dependencies**:
   Open the project in Visual Studio and restore dependencies.

3. **Environment variables**:
   Create an `appsettings.json` file in the `pizza_cafe.Server` directory and add the following settings:
    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "your_connection_string"
        },
        "Jwt": {
            "Key": "your_jwt_key",
            "Issuer": "your_jwt_issuer",
            "Audience": "your_jwt_audience"
        }
    }
    ```

4. **Run the application**:
   Click the "Start" button in Visual Studio or run the following command:
    ```bash
    dotnet run --project pizza_cafe.Client
    dotnet run --project pizza_cafe.Server
    ```

## 🌐 Usage

1. Open your browser and navigate to `http://localhost:5153`.
2. Register a new account or log in with your existing credentials.
3. Start managing your pizza cafe!

## 📂 Project Structure

```plaintext
pizza_cafe/
│
├── pizza_cafe.Client/        # Blazor client-side
│   ├── wwwroot/              # Static files
│   ├── Layout/               # Page layouts
│   ├── Pages/                # Application pages
│   ├── Services/             # Services
│   ├── Shared/               # Shared components
│   ├── Store/                # State management
│   ├── App.razor             # Main application component
│   └── Program.cs            # Application configuration
│
├── pizza_cafe.Server/        # ASP.NET Core server-side
│   ├── Controllers/          # API controllers
│   ├── Services/             # Application services
│   ├── appsettings.json      # Application settings
│   └── Program.cs            # Application configuration
│
├── pizza_cafe.Shared/        # Shared models and enums
│   ├── Enums/                # Enumerations
│   └── Models/               # Data models
│
└── README.md                 # Project description
```



## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature/your-feature`).
6. Open a pull request.

## 📝 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 📧 Contact

If you have any questions or feedback, feel free to reach out:

- GitHub: [kastelatas](https://github.com/kastelatas)
---

Thank you for checking out the Pizza Cafe project! Enjoy managing your cafe! 🍕

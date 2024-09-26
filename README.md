# **Individual Equipment Management App**  

This application helps in managing equipment, tracking their availability and assignments. The app is built using an ASP.NET Core REST API for the backend, React.js for the frontend, and SQL Server as the database.

## **Features**
- **Equipment Tracking**: View and manage all individual pieces of equipment.
- **Assignment Management**: Assign equipment to users and track who has what.
- **Maintenance Scheduling**: Keep track of maintenance dates and reminders.
- **Responsive Design**: Built with modern, responsive design principles.

---

## **Technologies Used**
- **ASP.NET Core REST API**: Backend framework for handling API requests.
- **React.js**: Frontend library for building interactive UIs.
- **SQL Server**: Database for storing equipment information.
- **Entity Framework Core**: For database management and migrations.

---

## **Installation**

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/equipment-management-app.git
    ```
2. **Backend Setup (ASP.NET Core)**:
    - Navigate to the backend project folder:
      ```bash
      cd backend
      ```
    - Restore the dependencies:
      ```bash
      dotnet restore
      ```
    - Update the SQL Server connection string in `appsettings.json`.
    - Apply migrations and update the database:
      ```bash
      dotnet ef database update
      ```
    - Run the backend server:
      ```bash
      dotnet run
      ```
3. **Frontend Setup (React.js)**:
    - Navigate to the frontend project folder:
      ```bash
      cd frontend
      ```
    - Install dependencies:
      ```bash
      npm install
      ```
    - Start the development server:
      ```bash
      npm start
      ```

4. **Access the App**:
    - Open your browser and go to `http://localhost:3000` for the frontend.
    - The backend API will run at `http://localhost:5000`.

---

## **Usage**

1. **Dashboard**: View the list of all equipment, their status, and upcoming maintenance.
2. **Add Equipment**: Add new equipment using the "Add Equipment" form.
3. **Assign Equipment**: Assign equipment to users and manage assignments.
4. **View Maintenance Schedule**: Check upcoming maintenance dates for each piece of equipment.

---

## **Screenshots**

**Dashboard**  
![Dashboard](./assets/dashboard.png)

**Add Equipment Form**  
![Add Equipment](./assets/add-equipment.png)

---

## **API Endpoints**

- `GET /api/equipment`: Fetch all equipment.
- `POST /api/equipment`: Add new equipment.
- `PUT /api/equipment/{id}`: Update equipment details.
- `DELETE /api/equipment/{id}`: Delete equipment.

For more detailed API documentation, refer to the [API Docs](./api-docs.md).

---

## **Contributing**

We welcome contributions! If you'd like to add features or fix bugs, feel free to open a pull request.

---

## **License**
This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.

---

## **Contact**

For any inquiries, reach out via GitHub or email at [your.email@example.com](mailto:your.email@example.com).

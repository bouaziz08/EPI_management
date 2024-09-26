# **Individual Equipment Management App**  

This application helps in managing equipment, tracking their availability and assignments. The app is built using an ASP.NET Core REST API for the backend, React.js for the frontend, and SQL Server as the database.

## **Features**
- **Demand Tracking**: Track demand of an equipment.
- **Equipment management**: Assign equipment to users and track who has what.
- **Update store**: track store and update quantity of every equipment.
- **Display store details**: Dashboard to diplay details of every equipment.

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
    git clone https://github.com/bouaziz08/EPI_management.git
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

1. **Dashboard**: View the list of all equipment, their status.
2. **Add Demand**: Add new Demand using the "Add Demand" form.
3. **Assign Equipment**: Assign equipment to users and manage assignments.
4. **View and maintain store**: Display details and update the store.

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

## **License**
This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.

---

## **Contact**

For any inquiries, reach out via GitHub or email at [your.email@example.com](mailto:your.email@example.com).

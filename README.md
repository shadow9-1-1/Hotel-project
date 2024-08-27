# Hotel Website Project

## Overview

This project is a web development initiative aimed at creating a dynamic and user-friendly website for a hotel. The website is designed to serve the hotel's business goals, enhance user experience, and facilitate efficient hotel management.

## Features

### User Roles

1. **Guest**:
   - **Home Page**: Displays essential information about the hotel, including available rooms and services.
   - **Reservation Page**: Allows users to book private rooms and view additional information about their booking.
   - **Feedback Page**: Enables users to provide feedback on their stay and view feedback from other guests.
   - **Services**: Shows the services provided by the hotel.
   - **Rooms**: Displays information about the available rooms, their prices, and any special offers.
   - **About Us**: Provides an overview of the hotel, its rating, and contact details for inquiries.
   - **Guest Login**: Enables users to log in to their accounts.
   - **Guest Sign Up**: Allows new users to create an account.
   - **User Profile**: Enables users to modify account data, view reservation history, make reservations, and provide feedback.

2. **Employee**:
   - **Employee Login**: Enables employees to access their accounts and perform their duties.

3. **Admin**:
   - **Admin Page**: Provides tools for administrators to manage the website.
   - **Add Manager**: Allows the admin to add new managers.
   - **Add Staff**: Enables the admin to add new staff members.
   - **Add Admin**: Allows the admin to add new administrators.
   - **Add Room Type**: Enables the admin to add different types of rooms.
   - **Add Service**: Allows the admin to add hotel services.
   - **Add Room**: Enables the admin to add new rooms.
   - **Show Table**: Allows the admin, managers, and staff to view data tables related to their roles.

## Database

- **ER Diagram**: The Entity-Relationship Diagram for the database is available in the attached PDF file.
- **Database Schema**: The database schema used in this project is also provided in the attached PDF file.

## Usage

### Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/username/hotel-website.git
   cd hotel-website
   ```

2. **Setup the Environment**
   - Ensure you have the necessary environment variables configured, such as database credentials.

3. **Database Setup**
   - Execute the SQL scripts provided in the `/database` directory to create the necessary tables and relationships.
   - Refer to the `/database` for detailed database setup.

4. **Running the Application**
   ```bash
   npm install
   npm start
   ```
   - Navigate to `http://localhost:3000` in your browser to access the platform.

### How to Use

1. **Guests**: 
   - Create an account or log in to browse rooms, make reservations, and provide feedback.
   - Use the profile page to manage your account and view your reservation history.

2. **Employees**: 
   - Log in to access your account and manage daily operations related to guests and hotel services.

3. **Admin**:
   - Access the admin panel to manage the site, including adding new managers, staff, and services.



## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


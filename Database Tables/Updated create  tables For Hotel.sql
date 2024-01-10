CREATE TABLE Guest (
    UserName VARCHAR(50) PRIMARY KEY, 
    Password VARCHAR(50),
    Name VARCHAR(50),
    UserInformation VARCHAR(MAX)
);

CREATE TABLE RoomType (
    RoomTypeID INT,
    CategoryName VARCHAR(50) PRIMARY KEY,
	Price INT,
    Description VARCHAR(MAX)
);

CREATE TABLE Room (
    RoomNumber INT PRIMARY KEY,
	CategoryName VARCHAR(50),
    PricePerNight DECIMAL(10, 2),
    /*PRIMARY KEY (RoomTypeID, RoomNumber),*/
    FOREIGN KEY (CategoryName) REFERENCES RoomType(CategoryName)
);

CREATE TABLE Manager (
    UserName VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50),
	ManagerName VARCHAR(50),
    ModifyInformation INT,
    InformationAboutStaff INT,
    InformationAboutHotel INT
);

CREATE TABLE Admin (
    UserName VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50),
    SystemAdministration INT,
    CreateOtherAdminUser INT,
    CreateStaff INT,
	aimg image,
);

CREATE TABLE RoomManager (
    CategoryName VARCHAR(50),
    ManagerUserName VARCHAR(50),
    FOREIGN KEY (CategoryName) REFERENCES RoomType(CategoryName),
    FOREIGN KEY (ManagerUserName) REFERENCES Manager(UserName)
);

CREATE TABLE Reservation (
    ReservationID INT PRIMARY KEY,
    RoomNumber INT,
    UserName VARCHAR(50),
    CheckInDate DATE,
    CheckOutDate DATE,
    FOREIGN KEY (RoomNumber) REFERENCES Room(RoomNumber),
    FOREIGN KEY (UserName) REFERENCES Guest(UserName)
);

/*CREATE TABLE Receptionist (
    UserName VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50)
);*/

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY,
	PaymentKinde VARCHAR(50),
	GUserName VARCHAR(50),
    ReservationID INT,
    Amount DECIMAL(10, 2),
    TransactionDate DATE,
	FOREIGN KEY (GUserName) REFERENCES Guest(UserName),
    FOREIGN KEY (ReservationID) REFERENCES Reservation(ReservationID)
);

CREATE TABLE Billing (
    PaymentID INT,
    ReservationID INT,
    InvoiceDetails VARCHAR(MAX),
    PaymentStatus VARCHAR(50),
    DueDate DATE,
    GuestName VARCHAR(50),
    FOREIGN KEY (PaymentID) REFERENCES Payment(PaymentID),
    FOREIGN KEY (ReservationID) REFERENCES Reservation(ReservationID)
);

CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY,
    UserName VARCHAR(50),
    FeedbackDate DATE,
    Comments VARCHAR(MAX),
    Rating INT,
    FOREIGN KEY (UserName) REFERENCES Guest(UserName)
);

CREATE TABLE Event (
    EventID INT PRIMARY KEY,
    EventName VARCHAR(50),
    EventDate DATE,
    Attendees INT,
    CateringDetails VARCHAR(MAX),
    RoomBookingID INT,
    FOREIGN KEY (RoomBookingID) REFERENCES Reservation(ReservationID)
);



CREATE TABLE Services (
    ServiceID INT PRIMARY KEY,
    AmenityName VARCHAR(50),
    Description VARCHAR(MAX),
    Availability INT,
    AdditionalCharges DECIMAL(10, 2)
);

CREATE TABLE StafRoles (
    SRoleName VARCHAR(50) PRIMARY KEY
);

CREATE TABLE Staff (
    StaffEmployeeID INT PRIMARY KEY,
	Accessibility INT,
    SUsername VARCHAR(50),
    Password VARCHAR(50),
    Name VARCHAR(50),
    Role VARCHAR(50),
	ManagerUserName VARCHAR(50),
    AdminUserName VARCHAR(50),
    FOREIGN KEY (ManagerUserName) REFERENCES Manager(UserName),
	FOREIGN KEY (Role) REFERENCES StafRoles(SRoleName),
    FOREIGN KEY (AdminUserName) REFERENCES Admin(UserName)
);

CREATE TABLE Offers(
	OffersName VARCHAR(50),
	days INT,
	Person INT,
	Price DECIMAL(10, 2),
	Description VARCHAR(MAX)
);


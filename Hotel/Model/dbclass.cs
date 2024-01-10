using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Model
{
    public class dbclass
    {
        [BindProperty]
        public string AUsername { get; set; }
        public string Ausername1(string Ausername)
        {
            AUsername = Ausername;
            return AUsername;
        }
        [BindProperty]
        public string Username {  get; set; }
        public string username1 (string username)
        {
            Username = username;
            return Username;
        }
        

        public SqlConnection con { get; set; }
        public dbclass()
        {
            string SQLcon = "Data Source=Ahmed;Initial Catalog=Hotel;Integrated Security=True;";
            
            con = new SqlConnection(SQLcon);
        }

        /*-------------------------Show Table Query----------------------*/
        public DataTable ShowTable(string Tname)
        {
            DataTable dt = new DataTable();
            string query = "select* from " + Tname;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }
        public DataTable ShowGuestTable(string UserName)
        {
            DataTable dt = new DataTable();
            string query = "SELECT* from Guest where UserName= @UserName";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }
        public DataTable ShowReservationHistoryTable(string UserName)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * from Reservation where UserName = @UserName";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }
        public DataTable ShowFeadbackTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT G.Name ,F.UserName,  F.FeedbackDate, F.Comments, F.Rating FROM Feedback F JOIN Guest G ON F.UserName = G.UserName";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }
        public DataTable ShowEventTable()
        {
            DataTable dt = new DataTable();
            string query ="SELECT S.AmenityName, S.Description FROM Event E JOIN Services S ON E.AmenityID = S.ServiceID";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }


        /*-------------------------Insert Table Query----------------------*/
        public string SignUp(string userName, string password, string name, string Email)
        {
            string cr = string.Empty;
            
            string query = "INSERT INTO Guest (UserName, Password, Name, Email) VALUES (@UserName, @Password, @Name, @Email);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", Email);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertRoomType(int roomTypeID, string categoryName, int price, string description,int bed, int bath, string photo)
        {
            string cr = string.Empty;
            string query = "INSERT INTO RoomType (RoomTypeID, CategoryName, Price, Description, bed, bath, photo) VALUES (@RoomTypeID, @CategoryName, @Price, @Description, @bed, @bath, @photo);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RoomTypeID", roomTypeID);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@bed", bed);
                cmd.Parameters.AddWithValue("@bath", bath);
                cmd.Parameters.AddWithValue("@photo", photo);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertRoom(int roomNumber, string categoryName, decimal pricePerNight)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Room (RoomNumber, CategoryName, PricePerNight) VALUES (@RoomNumber, @CategoryName, @PricePerNight);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@PricePerNight", pricePerNight);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertManager(string userName, string password, string managerName, int modifyInformation, int informationAboutStaff, int informationAboutHotel)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Manager (UserName, Password, ManagerName, ModifyInformation, InformationAboutStaff, InformationAboutHotel) VALUES (@UserName, @Password, @ManagerName, @ModifyInformation, @InformationAboutStaff, @InformationAboutHotel);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@ManagerName", managerName);
                cmd.Parameters.AddWithValue("@ModifyInformation", modifyInformation);
                cmd.Parameters.AddWithValue("@InformationAboutStaff", informationAboutStaff);
                cmd.Parameters.AddWithValue("@InformationAboutHotel", informationAboutHotel);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertAdmin(string userName, string password)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Admin (UserName, Password, SystemAdministration, CreateOtherAdminUser,CreateStaff) VALUES (@UserName, @Password, 1, 1, 1);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertRoomManager(int managerID, int roomID)
        {
            string cr = string.Empty;
            string query = "INSERT INTO RoomManager (ManagerID, RoomID) VALUES (@ManagerID, @RoomID);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ManagerID", managerID);
                cmd.Parameters.AddWithValue("@RoomID", roomID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertReservation(int ReservationID, int RoomNumber, string UserName, DateTime CheckInDate, DateTime CheckOutDate)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Reservation (ReservationID, RoomNumber, UserName, CheckInDate, CheckOutDate) VALUES (@ReservationID, @RoomNumber, @UserName, @CheckInDate, @CheckOutDate);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
                cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@CheckInDate", CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertPayment(int reservationID, decimal paymentAmount, DateTime paymentDate)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Payment (ReservationID, PaymentAmount, PaymentDate) VALUES (@ReservationID, @PaymentAmount, @PaymentDate);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                cmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertBilling(string InvoiceDetails, string PaymentStatus, DateTime DueDate, string GuestName)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Billing (InvoiceDetails, PaymentStatus, DueDate, GuestName) VALUES (@InvoiceDetails, @PaymentStatus, @DueDate, @GuestName);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@InvoiceDetails", InvoiceDetails);
                cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                cmd.Parameters.AddWithValue("@DueDate", DueDate);
                cmd.Parameters.AddWithValue("@GuestName", GuestName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertFeedback(int ID, string UserName, DateTime FeedbackDate, string Comments, int Rating)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Feedback (FeedbackID, UserName, FeedbackDate, Comments, Rating) VALUES (@ID, @UserName, @FeedbackDate, @Comments, @Rating);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@FeedbackDate", FeedbackDate);
                cmd.Parameters.AddWithValue("@Comments", Comments);
                cmd.Parameters.AddWithValue("@Rating", Rating);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertEvent(string EventName, DateTime EventDate, int Attendees, string CateringDetails, int RoomBookingID)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Event (EventName, EventDate, Attendees, CateringDetails, RoomBookingID) VALUES (@EventName, @EventDate, @Attendees, @CateringDetails, @RoomBookingID);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EventName", EventName);
                cmd.Parameters.AddWithValue("@EventDate", EventDate);
                cmd.Parameters.AddWithValue("@Attendees", Attendees);
                cmd.Parameters.AddWithValue("@CateringDetails", CateringDetails);
                cmd.Parameters.AddWithValue("@RoomBookingID", RoomBookingID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertService(int ServiceID, string AmenityName, string Description, int Availability, decimal AdditionalCharges, string icon)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Services (ServiceID, AmenityName, Description, Availability, AdditionalCharges, icon) VALUES (@ServiceID, @AmenityName, @Description, @Availability, @AdditionalCharges, @icon);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                cmd.Parameters.AddWithValue("@AmenityName", AmenityName);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Availability", Availability);
                cmd.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                cmd.Parameters.AddWithValue("@icon", icon);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertStaffRole(string SRoleName)
        {
            string cr = string.Empty;
            string query = "INSERT INTO StafRoles (SRoleName) VALUES (@SRoleName);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SRoleName", SRoleName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertStaff(int StaffEmployeeID, int Accessibility, string SUsername, string Password, string Name, string Role, string ManagerUserName, string AdminUserName)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Staff (StaffEmployeeID, Accessibility, SUsername, Password, Name, Role, ManagerUserName, AdminUserName) VALUES (@StaffEmployeeID, @Accessibility, @SUsername, @Password, @Name, @Role, @ManagerUserName, @AdminUserName);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StaffEmployeeID", StaffEmployeeID);
                cmd.Parameters.AddWithValue("@Accessibility", Accessibility);
                cmd.Parameters.AddWithValue("@SUsername", SUsername);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Role", Role);
                cmd.Parameters.AddWithValue("@ManagerUserName", ManagerUserName);
                cmd.Parameters.AddWithValue("@AdminUserName", AdminUserName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string InsertOffer(string OffersName, int days, int Person, decimal Price, string Description)
        {
            string cr = string.Empty;
            string query = "INSERT INTO Offers (OffersName, days, Person, Price, Description) VALUES (@OffersName, @days, @Person, @Price, @Description);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OffersName", OffersName);
                cmd.Parameters.AddWithValue("@days", days);
                cmd.Parameters.AddWithValue("@Person", Person);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Description", Description);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }

        /*-------------------------Delete Table Query----------------------*/
        public string DeleteGuest(string UserName)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Guest WHERE UserName = @UserName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteRoomType(string CategoryName)
        {
            string cr = string.Empty;
            string query = "DELETE FROM RoomType WHERE CategoryName = @CategoryName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteRoom(int RoomNumber)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Room WHERE RoomNumber = @RoomNumber;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteManager(string UserName)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Manager WHERE UserName = @UserName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteAdmin(string UserName)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Admin WHERE UserName = @UserName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteReservation(int ReservationID)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Reservation WHERE ReservationID = @ReservationID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeletePayment(int PaymentID)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Payment WHERE PaymentID = @PaymentID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteBilling(int PaymentID)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Billing WHERE PaymentID = @PaymentID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteEvent(int EventID)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Event WHERE EventID = @EventID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EventID", EventID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteService(int ServiceID)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Services WHERE ServiceID = @ServiceID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteStaffRole(string SRoleName)
        {
            string cr = string.Empty;
            string query = "DELETE FROM StafRoles WHERE SRoleName = @SRoleName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SRoleName", SRoleName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string DeleteOffer(string OffersName)
        {
            string cr = string.Empty;
            string query = "DELETE FROM Offers WHERE OffersName = @OffersName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OffersName", OffersName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }

        /*-------------------------Update Table Query----------------------*/
        public string UpdateGuest(string UserName, string Password, string Name, string UserInformation)
        {
            string cr = string.Empty;
            string query = "UPDATE Guest SET Password = @Password, Name = @Name, UserInformation = @UserInformation WHERE UserName = @UserName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@UserInformation", UserInformation);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateRoomType(int RoomTypeID, string CategoryName, int Price, string Description)
        {
            string cr = string.Empty;
            string query = "UPDATE RoomType SET Price = @Price, Description = @Description WHERE RoomTypeID = @RoomTypeID AND CategoryName = @CategoryName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Description", Description);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateRoom(int RoomNumber, string CategoryName, decimal PricePerNight)
        {
            string cr = string.Empty;
            string query = "UPDATE Room SET PricePerNight = @PricePerNight WHERE RoomNumber = @RoomNumber AND CategoryName = @CategoryName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("@PricePerNight", PricePerNight);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateManager(string UserName, string Password, string ManagerName, int ModifyInformation, int InformationAboutStaff, int InformationAboutHotel)
        {
            string cr = string.Empty;
            string query = "UPDATE Manager SET Password = @Password, ManagerName = @ManagerName, ModifyInformation = @ModifyInformation, InformationAboutStaff = @InformationAboutStaff, InformationAboutHotel = @InformationAboutHotel WHERE UserName = @UserName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@ManagerName", ManagerName);
                cmd.Parameters.AddWithValue("@ModifyInformation", ModifyInformation);
                cmd.Parameters.AddWithValue("@InformationAboutStaff", InformationAboutStaff);
                cmd.Parameters.AddWithValue("@InformationAboutHotel", InformationAboutHotel);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateAdmin(string UserName, string Password, int SystemAdministration, int CreateOtherAdminUser, int CreateStaff)
        {
            string cr = string.Empty;
            string query = "UPDATE Admin SET Password = @Password, SystemAdministration = @SystemAdministration, CreateOtherAdminUser = @CreateOtherAdminUser, CreateStaff = @CreateStaff WHERE UserName = @UserName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@SystemAdministration", SystemAdministration);
                cmd.Parameters.AddWithValue("@CreateOtherAdminUser", CreateOtherAdminUser);
                cmd.Parameters.AddWithValue("@CreateStaff", CreateStaff);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateRoomManager(string CategoryName, string ManagerUserName)
        {
            string cr = string.Empty;
            string query = "UPDATE RoomManager SET ManagerUserName = @ManagerUserName WHERE CategoryName = @CategoryName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("@ManagerUserName", ManagerUserName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateReservation(int ReservationID, int RoomNumber, string UserName, DateTime CheckInDate, DateTime CheckOutDate)
        {
            string cr = string.Empty;
            string query = "UPDATE Reservation SET RoomNumber = @RoomNumber, UserName = @UserName, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate WHERE ReservationID = @ReservationID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
                cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@CheckInDate", CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdatePayment(int PaymentID, string PaymentKinde, string GUserName, int ReservationID, decimal Amount, DateTime TransactionDate)
        {
            string cr = string.Empty;
            string query = "UPDATE Payment SET PaymentKinde = @PaymentKinde, GUserName = @GUserName, ReservationID = @ReservationID, Amount = @Amount, TransactionDate = @TransactionDate WHERE PaymentID = @PaymentID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                cmd.Parameters.AddWithValue("@PaymentKinde", PaymentKinde);
                cmd.Parameters.AddWithValue("@GUserName", GUserName);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateBilling(int PaymentID, int ReservationID, string InvoiceDetails, string PaymentStatus, DateTime DueDate, string GuestName)
        {
            string cr = string.Empty;
            string query = "UPDATE Billing SET InvoiceDetails = @InvoiceDetails, PaymentStatus = @PaymentStatus, DueDate = @DueDate, GuestName = @GuestName WHERE PaymentID = @PaymentID AND ReservationID = @ReservationID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
                cmd.Parameters.AddWithValue("@InvoiceDetails", InvoiceDetails);
                cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                cmd.Parameters.AddWithValue("@DueDate", DueDate);
                cmd.Parameters.AddWithValue("@GuestName", GuestName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateFeedback(int FeedbackID, string UserName, DateTime FeedbackDate, string Comments, int Rating)
        {
            string cr = string.Empty;
            string query = "UPDATE Feedback SET UserName = @UserName, FeedbackDate = @FeedbackDate, Comments = @Comments, Rating = @Rating WHERE FeedbackID = @FeedbackID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FeedbackID", FeedbackID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@FeedbackDate", FeedbackDate);
                cmd.Parameters.AddWithValue("@Comments", Comments);
                cmd.Parameters.AddWithValue("@Rating", Rating);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateServices(int ServiceID, string AmenityName, string Description, int Availability, decimal AdditionalCharges)
        {
            string cr = string.Empty;
            string query = "UPDATE Services SET AmenityName = @AmenityName, Description = @Description, Availability = @Availability, AdditionalCharges = @AdditionalCharges WHERE ServiceID = @ServiceID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                cmd.Parameters.AddWithValue("@AmenityName", AmenityName);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Availability", Availability);
                cmd.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateStafRoles(string SRoleName)
        {
            string cr = string.Empty;
            string query = "UPDATE StafRoles SET SRoleName = @SRoleName WHERE SRoleName = @SRoleName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SRoleName", SRoleName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateStaff(int StaffEmployeeID, int Accessibility, string SUsername, string Password, string Name, string Role, string ManagerUserName, string AdminUserName)
        {
            string cr = string.Empty;
            string query = "UPDATE Staff SET Accessibility = @Accessibility, Password = @Password, Name = @Name, Role = @Role, ManagerUserName = @ManagerUserName, AdminUserName = @AdminUserName WHERE StaffEmployeeID = @StaffEmployeeID;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StaffEmployeeID", StaffEmployeeID);
                cmd.Parameters.AddWithValue("@Accessibility", Accessibility);
                cmd.Parameters.AddWithValue("@SUsername", SUsername);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Role", Role);
                cmd.Parameters.AddWithValue("@ManagerUserName", ManagerUserName);
                cmd.Parameters.AddWithValue("@AdminUserName", AdminUserName);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }
        public string UpdateOffers(string OffersName, int days, int Person, decimal Price, string Description)
        {
            string cr = string.Empty;
            string query = "UPDATE Offers SET days = @days, Person = @Person, Price = @Price, Description = @Description WHERE OffersName = @OffersName;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OffersName", OffersName);
                cmd.Parameters.AddWithValue("@days", days);
                cmd.Parameters.AddWithValue("@Person", Person);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Description", Description);
                int rowsAffected = cmd.ExecuteNonQuery();
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception
                cr = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cr;
        }








        /*public string SignUp(string Tname, string cid, string cname, string cemail)
        {
            string cr = string.Empty;
            string query = "INSERT INTO @Tname VALUES (@cid, @cname, @cemail);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Tname", Tname);
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@cemail", cemail);
                int rowsAffected = cmd.ExecuteNonQuery();
                //cr = string.Empty;
                cr = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }
            return cr;
        }
        public DataTable read(string readid, string readname, string reademail)
        {
            DataTable dr = new DataTable();
            string query = "SELECT * FROM table$ WHERE Id LIKE @readid AND Name LIKE @readname AND Email LIKE @reademail";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@readid", "%" + readid + "%");
                    cmd.Parameters.AddWithValue("@readname", "%" + readname + "%");
                    cmd.Parameters.AddWithValue("@reademail", "%" + reademail + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dr);
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }

            return dr;
        }
        public string Delete(string did)
        {
            string cr = string.Empty;
            string query = "DELETE FROM table$ WHERE id = @did";
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@did", did);
                    //cmd.Parameters.AddWithValue("@dname", dname);
                    //cmd.Parameters.AddWithValue("@demail", demail);

                    int rowsAffected = cmd.ExecuteNonQuery();


                    cr = rowsAffected.ToString();
                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }

            return cr;
        }
        public string Update(string Uname, string Uemail, string Oid)
        {
            string cr = string.Empty;
            string query = "UPDATE table$ SET name = @Uname , email = @Uemail WHERE id = @Oid";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                //cmd.Parameters.AddWithValue("@Uid", Uid);
                cmd.Parameters.AddWithValue("@Uname", Uname);
                cmd.Parameters.AddWithValue("@Uemail", Uemail);
                cmd.Parameters.AddWithValue("@Oid", Oid);
                //cmd.Parameters.AddWithValue("@Oname", Oname);
                //cmd.Parameters.AddWithValue("@Oemail", Oemail);

                int rowsAffected = cmd.ExecuteNonQuery();


                //cr = rowsAffected.ToString();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }

            return cr;
        }*/
    }
}

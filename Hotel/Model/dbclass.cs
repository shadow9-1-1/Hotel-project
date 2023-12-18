using System.Data;
using System.Data.SqlClient;

namespace Hotel.Model
{
    public class dbclass
    {
        public SqlConnection con { get; set; }
        public dbclass()
        {
            string SQLcon = "Data Source=AHMED;Initial Catalog=\"Prelab 8\";Integrated Security=True";
            con = new SqlConnection(SQLcon);
        }
        public DataTable DTable(string Tname)
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
        public string create(string cid, string cname, string cemail)
        {
            string cr = string.Empty;
            string query = "INSERT INTO table$ VALUES (@cid, @cname, @cemail);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
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
        }
    }
}

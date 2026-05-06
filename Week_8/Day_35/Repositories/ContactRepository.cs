using WebApplication2.Data;
using WebApplication2.Models;
using Dapper;

namespace WebApplication2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        // GET ALL (JOIN)
        public IEnumerable<ContactInfo> GetAllContacts()
        {
            var sql = @"SELECT c.*, comp.CompanyName, dept.DepartmentName
                    FROM ContactInfo c
                    LEFT JOIN Company comp ON c.CompanyId = comp.CompanyId
                    LEFT JOIN Department dept ON c.DepartmentId = dept.DepartmentId";

            using var db = _context.CreateConnection();
            return db.Query<ContactInfo>(sql);
        }

        //GET BY ID
        public ContactInfo GetContactById(int id)
        {
            var sql = "SELECT * FROM ContactInfo WHERE ContactId = @Id";

            using var db = _context.CreateConnection();
            return db.QueryFirstOrDefault<ContactInfo>(sql, new { Id = id });
        }

        //INSERT
        public void AddContact(ContactInfo contact)
        {
            var sql = @"INSERT INTO ContactInfo 
                    (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                    VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using var db = _context.CreateConnection();
            db.Execute(sql, contact);
        }

        // UPDATE
        public void UpdateContact(ContactInfo contact)
        {
            var sql = @"UPDATE ContactInfo SET
                    FirstName=@FirstName,
                    LastName=@LastName,
                    EmailId=@EmailId,
                    MobileNo=@MobileNo,
                    Designation=@Designation,
                    CompanyId=@CompanyId,
                    DepartmentId=@DepartmentId
                    WHERE ContactId=@ContactId";

            using var db = _context.CreateConnection();
            db.Execute(sql, contact);
        }

        // DELETE
        public void DeleteContact(int id)
        {
            using var db = _context.CreateConnection();
            db.Execute("DELETE FROM ContactInfo WHERE ContactId=@Id", new { Id = id });
        }

        // DROPDOWN DATA
        public IEnumerable<Company> GetCompanies()
        {
            using var db = _context.CreateConnection();
            return db.Query<Company>("SELECT * FROM Company");
        }

        public IEnumerable<Department> GetDepartments()
        {
            using var db = _context.CreateConnection();
            return db.Query<Department>("SELECT * FROM Department");
        }
    }
}

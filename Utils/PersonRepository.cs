using mreyesS5B.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mreyesS5B.Utils
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string status { get; set; }
        public PersonRepository(string path) 
        {
            dbPath = path;
        }

        public void Init()
        {
            if (conn is not null) 
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new Exception("El nombre es requerido");
                }
                Persona person = new() {Name = nombre};
                result = conn.Insert(person);
                status = string.Format("Dato ingresado");
            }
            catch (Exception ex)
            {
                status = string.Format("error al ingresar: " + ex.Message);
            }
        }

        public List<Persona> GetAllPeople() 
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                status = string.Format("error al listar: " + ex.Message);
            }

            return new List<Persona>();
        }

        // Update Delete
    }
}
